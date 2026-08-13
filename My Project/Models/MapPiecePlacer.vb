Imports System.Drawing

Public Class MapPiecePlacer

    ' =========================================================
    ' PARAMETRES DE PLACEMENT
    ' =========================================================

    ' Nombre maximum de tentatives pour placer UNE pièce.
    ' Ce compteur est réinitialisé à chaque appel de TryPlacePiece.
    Private Const MaxPiecePlacementAttempts As Integer = 1000

    Private Const TerrainClearanceCells As Integer = 8

    ' =========================================================
    ' CLASSE DE STOCKAGE DES COORDONNEES DE RACCORDEMENT DE PIECES
    ' =========================================================

    Private Class ConnectionCandidate

        Public Property StartX As Integer
        Public Property StartY As Integer
        Public Property PieceConnectionX As Integer
        Public Property PieceConnectionY As Integer
        Public Property MapConnectionX As Integer
        Public Property MapConnectionY As Integer

    End Class

    ' =========================================================
    ' VERIFICATION D'UNE POSITION
    ' =========================================================

    Private Function CanPlacePiece(generation As MapGeneration, piece As TerrainPiece, startX As Integer, startY As Integer, rotation As PieceRotation, connectionCandidate As ConnectionCandidate) As Boolean

        Dim mapHeight As Integer = generation.Template.HeightCells

        Dim mapWidth As Integer = generation.Template.WidthCells

        ' ---------------------------------------------------------
        ' Parcours de toutes les cellules de la pièce
        ' ---------------------------------------------------------

        Dim rotatedHeight As Integer
        Dim rotatedWidth As Integer
        If rotation = PieceRotation.Deg0 OrElse rotation = PieceRotation.Deg180 Then
            rotatedHeight = piece.X
            rotatedWidth = piece.Y
        Else
            rotatedHeight = piece.Y
            rotatedWidth = piece.X
        End If


        For row As Integer = 0 To rotatedHeight - 1

            For column As Integer = 0 To rotatedWidth - 1

                Dim state As TerrainCellState = MapPieceGeometry.GetRotatedCellState(piece, row, column, rotation)


                ' -------------------------------------------------
                ' Les cellules vides ne bloquent rien.
                '
                ' Elles peuvent même se retrouver hors de la map.
                ' -------------------------------------------------

                If state = TerrainCellState.Empty Then

                    Continue For

                End If


                ' -------------------------------------------------
                ' Position réelle de cette cellule sur la carte
                ' -------------------------------------------------

                Dim mapX As Integer = startX + row

                Dim mapY As Integer = startY + column

                ' -------------------------------------------------
                ' 1. La cellule active doit rester dans la carte
                ' -------------------------------------------------

                If mapX < 0 OrElse mapX >= mapHeight OrElse mapY < 0 OrElse mapY >= mapWidth Then

                    Return False

                End If


                ' -------------------------------------------------
                ' 2. Vérification des zones d'insertion
                ' -------------------------------------------------

                For Each zone As InsertionZone In generation.InsertionZones

                    If IsInsideInsertionZone(mapX, mapY, zone) Then

                        Return False

                    End If

                Next


                ' -------------------------------------------------
                ' 3. Vérification des zones d'objectif
                ' -------------------------------------------------

                For Each zone As ObjectiveZone In generation.ObjectiveZones

                    If IsInsideObjectiveZone(mapX, mapY, zone) Then

                        Return False

                    End If

                Next


                ' -------------------------------------------------
                ' 4. Vérification des pièces déjà placées
                ' -------------------------------------------------

                If generation.OccupiedCells(mapX, mapY) Then

                    Return False

                End If


                ' -------------------------------------------------
                ' 5. Vérification des pièces adjacentes (espacement)
                ' -------------------------------------------------

                If state = TerrainCellState.Occupied OrElse state = TerrainCellState.Connection Then

                    If HasTerrainClearanceViolation(generation, mapX, mapY, connectionCandidate) Then

                        Return False

                    End If

                End If

            Next

        Next


        ' Toutes les cellules actives sont valides.
        Return True

    End Function

    ' =========================================================
    ' VERIFICATION DES ESPACES ADJACENT DISPONIBLES
    ' =========================================================
    Private Function HasTerrainClearanceViolation(generation As MapGeneration, mapX As Integer, mapY As Integer, connectionCandidate As ConnectionCandidate) As Boolean

        ' =========================================================
        ' Détermination de l'axe de connexion
        ' =========================================================

        Dim hasConnection As Boolean = connectionCandidate IsNot Nothing

        Dim connectionIsVertical As Boolean = False

        Dim connectionCoordinate As Integer = 0

        If hasConnection Then

            If connectionCandidate.PieceConnectionY = connectionCandidate.MapConnectionY Then

                ' Même colonne :
                ' le raccordement est vertical.

                connectionIsVertical = True
                connectionCoordinate = connectionCandidate.MapConnectionY

            Else

                ' Même ligne :
                ' le raccordement est horizontal.

                connectionIsVertical = False
                connectionCoordinate = connectionCandidate.MapConnectionX

            End If

        End If


        ' =========================================================
        ' Détermination de l'appartenance à l'axe de raccordement
        ' =========================================================

        Dim isOnConnectionAxis As Boolean = False

        If hasConnection Then

            If connectionIsVertical Then

                isOnConnectionAxis = mapY = connectionCoordinate

            Else

                isOnConnectionAxis = mapX = connectionCoordinate

            End If

        End If


        ' =========================================================
        ' Vérification verticale
        ' =========================================================

        For distance As Integer = 1 To TerrainClearanceCells

            Dim targetX As Integer = mapX - distance

            Dim targetY As Integer = mapY

            ' -----------------------------------------------------
            ' HAUT
            ' -----------------------------------------------------

            ' Si la nouvelle cellule est sur un axe vertical de
            ' connexion, la direction verticale est libre.
            If Not (hasConnection AndAlso connectionIsVertical AndAlso isOnConnectionAxis) Then

                If IsOccupiedTerrainCell(generation, targetX, targetY) Then

                    Return True

                End If

            End If


            ' -----------------------------------------------------
            ' BAS
            ' -----------------------------------------------------

            If Not (hasConnection AndAlso connectionIsVertical AndAlso isOnConnectionAxis) Then

                targetX = mapX + distance

                If IsOccupiedTerrainCell(generation, targetX, targetY) Then

                    Return True

                End If

            End If

        Next


        ' =========================================================
        ' Vérification horizontale
        ' =========================================================

        For distance As Integer = 1 To TerrainClearanceCells

            Dim targetX As Integer = mapX

            Dim targetY As Integer = mapY - distance

            ' -----------------------------------------------------
            ' GAUCHE
            ' -----------------------------------------------------

            If Not (hasConnection AndAlso Not connectionIsVertical AndAlso isOnConnectionAxis) Then

                If IsOccupiedTerrainCell(generation, targetX, targetY) Then

                    Return True

                End If

            End If


            ' -----------------------------------------------------
            ' DROITE
            ' -----------------------------------------------------

            If Not (hasConnection AndAlso Not connectionIsVertical AndAlso isOnConnectionAxis) Then

                targetY = mapY + distance

                If IsOccupiedTerrainCell(generation, targetX, targetY) Then

                    Return True

                End If

            End If

        Next


        Return False

    End Function

    ' =========================================================
    ' TEST D'APPARTENANCE A UNE ZONE D'INSERTION
    ' =========================================================

    Private Function IsInsideInsertionZone(x As Integer, y As Integer, zone As InsertionZone) As Boolean

        Return x >= zone.X AndAlso x < zone.X + zone.Height AndAlso y >= zone.Y AndAlso y < zone.Y + zone.Width

    End Function

    ' =========================================================
    ' TEST D'APPARTENANCE A UNE ZONE D'OBJECTIF
    ' =========================================================

    Private Function IsInsideObjectiveZone(x As Integer, y As Integer, zone As ObjectiveZone) As Boolean

        Return x >= zone.X AndAlso x < zone.X + zone.Size AndAlso y >= zone.Y AndAlso y < zone.Y + zone.Size

    End Function

    ' =========================================================
    ' VERIFICATION DE LA PRESENCE DE POINTS DE CONNECTIONS SUR LA PIECE
    ' =========================================================

    Public Function HasConnectionCells(piece As TerrainPiece) As Boolean

        For row As Integer = 0 To piece.X - 1

            For column As Integer = 0 To piece.Y - 1

                If piece.Cells(row, column) = TerrainCellState.Connection Then

                    Return True

                End If

            Next

        Next

        Return False

    End Function

    ' =========================================================
    ' VERIFICATION DE LA PRESENCE DE CONNECTIONS DANS LA MAP
    ' =========================================================

    Public Function HasAvailableConnections(generation As MapGeneration) As Boolean

        For row As Integer = 0 To generation.Template.HeightCells - 1

            For column As Integer = 0 To generation.Template.WidthCells - 1

                If generation.ConnectionCells(row, column) Then

                    Return True

                End If

            Next

        Next

        Return False

    End Function

    ' =========================================================
    ' VERIFICATION DE LA DISPONIBILITE D'UNE CELLULE
    ' =========================================================

    Private Function IsOccupiedTerrainCell(generation As MapGeneration, mapX As Integer, mapY As Integer) As Boolean

        ' ---------------------------------------------------------
        ' Hors carte :
        ' ce n'est pas une collision de terrain.
        '
        ' La vérification "hors carte" est déjà réalisée
        ' séparément par CanPlacePiece.
        ' ---------------------------------------------------------

        If mapX < 0 OrElse
            mapX >= generation.Template.HeightCells OrElse
            mapY < 0 OrElse
            mapY >= generation.Template.WidthCells Then

            Return False

        End If


        Return generation.OccupiedCells(mapX, mapY)

    End Function

    ' =========================================================
    ' ENREGISTREMENT D'UNE PIECE PLACEE
    ' =========================================================

    Private Sub RegisterPlacedPiece(generation As MapGeneration, piece As TerrainPiece, startX As Integer, startY As Integer, rotation As PieceRotation)

        ' ---------------------------------------------------------
        ' Marquage des cases réellement occupées
        ' ---------------------------------------------------------

        Dim rotatedHeight As Integer
        Dim rotatedWidth As Integer
        If rotation = PieceRotation.Deg0 OrElse rotation = PieceRotation.Deg180 Then
            rotatedHeight = piece.X
            rotatedWidth = piece.Y
        Else
            rotatedHeight = piece.Y
            rotatedWidth = piece.X
        End If

        For row As Integer = 0 To rotatedHeight - 1

            For column As Integer = 0 To rotatedWidth - 1

                Dim state As TerrainCellState = MapPieceGeometry.GetRotatedCellState(piece, row, column, rotation)

                ' Les cases blanches ne réservent aucune place.
                If state = TerrainCellState.Empty Then

                    Continue For

                End If


                Dim mapX As Integer =
                    startX + row

                Dim mapY As Integer =
                    startY + column


                generation.OccupiedCells(
                    mapX,
                    mapY) = True

                If state = TerrainCellState.Connection Then

                    generation.ConnectionCells(
                        mapX,
                        mapY) = True

                End If

            Next

        Next


        ' ---------------------------------------------------------
        ' Enregistrement de la pièce et de sa position
        ' ---------------------------------------------------------

        generation.PlacedPieces.Add(New PlacedTerrainPiece With {
            .Piece = piece,
            .X = startX,
            .Y = startY,
            .Rotation = rotation
        })

    End Sub

    ' =========================================================
    ' TIRAGE ALEATOIRE DE LA ROTATION
    ' =========================================================

    Private Function RollPieceRotation() As PieceRotation

        Dim value As Integer = Random.Shared.Next(0, 4)

        Select Case value

            Case 0
                Return PieceRotation.Deg0

            Case 1
                Return PieceRotation.Deg90

            Case 2
                Return PieceRotation.Deg180

            Case Else
                Return PieceRotation.Deg270

        End Select

    End Function

    Private Function GetPieceRotationOrder() As List(Of PieceRotation)

        Dim firstRotation As PieceRotation = RollPieceRotation()

        Dim rotations As New List(Of PieceRotation)()


        Select Case firstRotation

            Case PieceRotation.Deg0

                rotations.Add(PieceRotation.Deg0)
                rotations.Add(PieceRotation.Deg90)
                rotations.Add(PieceRotation.Deg180)
                rotations.Add(PieceRotation.Deg270)


            Case PieceRotation.Deg90

                rotations.Add(PieceRotation.Deg90)
                rotations.Add(PieceRotation.Deg180)
                rotations.Add(PieceRotation.Deg270)
                rotations.Add(PieceRotation.Deg0)


            Case PieceRotation.Deg180

                rotations.Add(PieceRotation.Deg180)
                rotations.Add(PieceRotation.Deg270)
                rotations.Add(PieceRotation.Deg0)
                rotations.Add(PieceRotation.Deg90)


            Case PieceRotation.Deg270

                rotations.Add(PieceRotation.Deg270)
                rotations.Add(PieceRotation.Deg0)
                rotations.Add(PieceRotation.Deg90)
                rotations.Add(PieceRotation.Deg180)

        End Select

        Return rotations

    End Function

    ' =========================================================
    ' TIRAGE ALEATOIRE DE LA CONNEXTION D'UNE PIECE
    ' =========================================================

    Public Function RollConnection(density As Integer) As Boolean

        If density <= 0 Then
            Return False
        End If
        If density >= 100 Then
            Return True
        End If

        Return Random.Shared.Next(0, 100) < density

    End Function

    ' =========================================================
    ' TENTATIVE DE PLACEMENT D'UNE PIECE
    ' =========================================================

    Public Function TryPlacePiece(generation As MapGeneration, piece As TerrainPiece, connectPiece As Boolean) As Boolean

        ' =========================================================
        ' Détermination de l'ordre des rotations
        '
        ' Exemple :
        ' 90° → 180° → 270° → 0°
        ' =========================================================

        Dim rotations As List(Of PieceRotation) = GetPieceRotationOrder()

        ' =========================================================
        ' 1. TENTATIVE EN MODE CONNECTÉ
        ' =========================================================

        If connectPiece Then

            For Each rotation As PieceRotation In rotations

                If TryPlacePieceConnected(generation, piece, rotation) Then

                    Return True

                End If

            Next


            ' -----------------------------------------------------
            ' Les quatre rotations connectées ont échoué.
            '
            ' On abandonne maintenant la contrainte de connexion.
            ' Cela reste autorisé même avec une densité de 100 %.
            ' -----------------------------------------------------

        End If


        ' =========================================================
        ' 2. TENTATIVE SANS CONNEXION
        ' =========================================================

        For Each rotation As PieceRotation In rotations

            If TryPlacePieceWithoutConnection(generation, piece, rotation) Then

                Return True

            End If

        Next


        ' =========================================================
        ' 3. ÉCHEC DÉFINITIF
        ' =========================================================

        Return False

    End Function

    Private Function TryPlacePieceWithoutConnection(generation As MapGeneration, piece As TerrainPiece, rotation As PieceRotation) As Boolean

        Dim mapHeight As Integer = generation.Template.HeightCells

        Dim mapWidth As Integer = generation.Template.WidthCells


        ' =========================================================
        ' Dimensions de la pièce après rotation
        ' =========================================================

        Dim rotatedHeight As Integer
        Dim rotatedWidth As Integer
        If rotation = PieceRotation.Deg0 OrElse rotation = PieceRotation.Deg180 Then
            rotatedHeight = piece.X
            rotatedWidth = piece.Y
        Else
            rotatedHeight = piece.Y
            rotatedWidth = piece.X
        End If


        ' =========================================================
        ' Tentatives de placement
        ' =========================================================

        For attempt As Integer = 1 To MaxPiecePlacementAttempts

            ' -----------------------------------------------------
            ' Le rectangle X/Y peut dépasser de la map.
            ' Seules les cellules actives devront rester dedans.
            ' -----------------------------------------------------

            Dim startX As Integer = Random.Shared.Next(-(rotatedHeight - 1), mapHeight)
            Dim startY As Integer = Random.Shared.Next(-(rotatedWidth - 1), mapWidth)

            ' -----------------------------------------------------
            ' Vérification complète de la position
            ' -----------------------------------------------------

            If CanPlacePiece(generation, piece, startX, startY, rotation, Nothing) Then

                ' -------------------------------------------------
                ' Position valide
                ' -------------------------------------------------

                RegisterPlacedPiece(generation, piece, startX, startY, rotation)
                Return True

            End If

        Next

        ' =========================================================
        ' Aucune position valide pour cette rotation
        ' =========================================================

        Return False

    End Function

    ' =========================================================
    ' TENTATIVE DE PLACEMENT D'UNE PIECE EN MODE CONNECTE
    ' =========================================================

    Private Function TryPlacePieceConnected(generation As MapGeneration, piece As TerrainPiece, rotation As PieceRotation) As Boolean

        ' ---------------------------------------------------------
        ' Construction des positions candidates.
        ' ---------------------------------------------------------

        Dim candidates As New List(Of ConnectionCandidate)


        ' ---------------------------------------------------------
        ' Recherche de toutes les cases Connection de la pièce.
        ' ---------------------------------------------------------

        Dim pieceHeight As Integer
        Dim pieceWidth As Integer
        If rotation = PieceRotation.Deg0 OrElse rotation = PieceRotation.Deg180 Then
            pieceHeight = piece.X
            pieceWidth = piece.Y
        Else
            pieceHeight = piece.Y
            pieceWidth = piece.X
        End If

        For pieceRow As Integer = 0 To pieceHeight - 1

            For pieceColumn As Integer = 0 To pieceWidth - 1

                Dim state As TerrainCellState = MapPieceGeometry.GetRotatedCellState(piece, pieceRow, pieceColumn, rotation)
                If state <> TerrainCellState.Connection Then
                    Continue For
                End If


                ' -------------------------------------------------
                ' Une Connection de la pièce doit être placée
                ' à côté d'une Connection déjà présente.
                ' -------------------------------------------------

                For mapRow As Integer = 0 To generation.Template.HeightCells - 1

                    For mapColumn As Integer = 0 To generation.Template.WidthCells - 1

                        If Not generation.ConnectionCells(mapRow, mapColumn) Then

                            Continue For

                        End If


                        ' -----------------------------------------
                        ' Haut
                        ' -----------------------------------------

                        AddConnectionCandidate(candidates, mapRow - 1, mapColumn, pieceRow, pieceColumn)


                        ' -----------------------------------------
                        ' Bas
                        ' -----------------------------------------

                        AddConnectionCandidate(candidates, mapRow + 1, mapColumn, pieceRow, pieceColumn)


                        ' -----------------------------------------
                        ' Gauche
                        ' -----------------------------------------

                        AddConnectionCandidate(candidates, mapRow, mapColumn - 1, pieceRow, pieceColumn)


                        ' -----------------------------------------
                        ' Droite
                        ' -----------------------------------------

                        AddConnectionCandidate(candidates, mapRow, mapColumn + 1, pieceRow, pieceColumn)

                    Next

                Next

            Next

        Next


        ' ---------------------------------------------------------
        ' Aucune position candidate.
        ' ---------------------------------------------------------

        If candidates.Count = 0 Then

            Return False

        End If


        ' ---------------------------------------------------------
        ' Mélange aléatoire des candidats.
        '
        ' Cela évite de toujours favoriser les premières
        ' connexions parcourues.
        ' ---------------------------------------------------------

        ShuffleCandidates(candidates)


        ' ---------------------------------------------------------
        ' Test des positions candidates.
        ' ---------------------------------------------------------

        For Each candidate As ConnectionCandidate In candidates

            If CanPlacePiece(generation, piece, candidate.StartX, candidate.StartY, rotation, candidate) Then

                RegisterPlacedPiece(generation, piece, candidate.StartX, candidate.StartY, rotation)

                Return True

            End If

        Next

        Return False

    End Function

    ' =========================================================
    ' AJOUT D'UNE POSITION CANDIDATE
    ' =========================================================

    Private Sub AddConnectionCandidate(candidates As List(Of ConnectionCandidate), connectionMapX As Integer, connectionMapY As Integer, connectionPieceX As Integer, connectionPieceY As Integer)

        Dim startX As Integer = connectionMapX - connectionPieceX

        Dim startY As Integer = connectionMapY - connectionPieceY

        Dim candidate As New ConnectionCandidate With {
            .StartX = startX,
            .StartY = startY,
            .PieceConnectionX = connectionPieceX,
            .PieceConnectionY = connectionPieceY,
            .MapConnectionX = connectionMapX,
            .MapConnectionY = connectionMapY
        }

        ' ---------------------------------------------------------
        ' Evite les doublons.
        ' ---------------------------------------------------------

        For Each existing As ConnectionCandidate In candidates

            If existing.StartX = candidate.StartX AndAlso
                existing.StartY = candidate.StartY AndAlso
                existing.PieceConnectionX = candidate.PieceConnectionX AndAlso
                existing.PieceConnectionY = candidate.PieceConnectionY AndAlso
                existing.MapConnectionX = candidate.MapConnectionX AndAlso
                existing.MapConnectionY = candidate.MapConnectionY Then

                Return

            End If

        Next


        candidates.Add(candidate)

    End Sub

    ' =========================================================
    ' MELANGE ALEATOIRE DES POSITIONS CANDIDATES
    ' =========================================================

    Private Sub ShuffleCandidates(candidates As List(Of ConnectionCandidate))

        For index As Integer = candidates.Count - 1 To 1 Step -1

            Dim otherIndex As Integer = Random.Shared.Next(0, index + 1)

            Dim temporary As ConnectionCandidate = candidates(index)

            candidates(index) = candidates(otherIndex)

            candidates(otherIndex) = temporary

        Next

    End Sub

End Class
