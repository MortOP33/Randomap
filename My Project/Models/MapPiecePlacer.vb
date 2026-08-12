Public Class MapPiecePlacer

    ' =========================================================
    ' PARAMETRES DE PLACEMENT
    ' =========================================================

    ' Nombre maximum de tentatives pour placer UNE pièce.
    ' Ce compteur est réinitialisé à chaque appel de TryPlacePiece.
    Private Const MaxPiecePlacementAttempts As Integer = 1000

    ' =========================================================
    ' VERIFICATION D'UNE POSITION
    ' =========================================================

    Private Function CanPlacePiece(generation As MapGeneration, piece As TerrainPiece, startX As Integer, startY As Integer, rotation As PieceRotation) As Boolean

        Dim mapHeight As Integer =
            generation.Template.HeightCells

        Dim mapWidth As Integer =
            generation.Template.WidthCells


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

                Dim mapX As Integer =
                    startX + row

                Dim mapY As Integer =
                    startY + column


                ' -------------------------------------------------
                ' 1. La cellule active doit rester dans la carte
                ' -------------------------------------------------

                If mapX < 0 OrElse
                   mapX >= mapHeight OrElse
                   mapY < 0 OrElse
                   mapY >= mapWidth Then

                    Return False

                End If


                ' -------------------------------------------------
                ' 2. Vérification des zones d'insertion
                ' -------------------------------------------------

                For Each zone As InsertionZone In
                    generation.InsertionZones

                    If IsInsideInsertionZone(
                        mapX,
                        mapY,
                        zone) Then

                        Return False

                    End If

                Next


                ' -------------------------------------------------
                ' 3. Vérification des zones d'objectif
                ' -------------------------------------------------

                For Each zone As ObjectiveZone In
                    generation.ObjectiveZones

                    If IsInsideObjectiveZone(
                        mapX,
                        mapY,
                        zone) Then

                        Return False

                    End If

                Next


                ' -------------------------------------------------
                ' 4. Vérification des pièces déjà placées
                ' -------------------------------------------------

                If generation.OccupiedCells(
                    mapX,
                    mapY) Then

                    Return False

                End If

            Next

        Next


        ' Toutes les cellules actives sont valides.
        Return True

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

        Dim value As Integer =
        Random.Shared.Next(0, 4)

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

    ' =========================================================
    ' TENTATIVE DE PLACEMENT D'UNE PIECE
    ' =========================================================

    Public Function TryPlacePiece(generation As MapGeneration, piece As TerrainPiece) As Boolean

        Dim mapHeight As Integer = generation.Template.HeightCells

        Dim mapWidth As Integer = generation.Template.WidthCells

        Dim rotation As PieceRotation = RollPieceRotation()
        Dim rotatedHeight As Integer
        Dim rotatedWidth As Integer
        If rotation = PieceRotation.Deg0 OrElse rotation = PieceRotation.Deg180 Then
            rotatedHeight = piece.X
            rotatedWidth = piece.Y
        Else
            rotatedHeight = piece.Y
            rotatedWidth = piece.X
        End If


        ' ---------------------------------------------------------
        ' Chaque pièce dispose de son propre compteur de tentatives.
        ' ---------------------------------------------------------

        For attempt As Integer =
            1 To MaxPiecePlacementAttempts


            ' -----------------------------------------------------
            ' Le rectangle X/Y de la pièce peut dépasser de la map.
            '
            ' On autorise donc un départ négatif ou proche
            ' de la dernière ligne/colonne.
            ' -----------------------------------------------------

            Dim startX As Integer = Random.Shared.Next(-(rotatedHeight - 1), mapHeight)
            Dim startY As Integer = Random.Shared.Next(-(rotatedWidth - 1), mapWidth)


            ' -----------------------------------------------------
            ' Vérification de la position
            ' -----------------------------------------------------

            If CanPlacePiece(
                generation,
                piece,
                startX,
                startY,
                rotation) Then

                ' -------------------------------------------------
                ' Position valide : inscription définitive
                ' -------------------------------------------------

                RegisterPlacedPiece(
                    generation,
                    piece,
                    startX,
                    startY,
                    rotation)

                Return True

            End If

        Next


        ' ---------------------------------------------------------
        ' Aucune position valide trouvée.
        ' ---------------------------------------------------------

        Return False

    End Function

End Class
