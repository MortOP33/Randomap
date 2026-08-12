Imports System.Windows.Forms

Public Module MapTemplateGenerator

    Private Const MaxAttempts As Integer = 1000

    Public Function Generate(template As MapTemplateDefinition, targetWeight As Integer) As MapGeneration

        Dim generation As New MapGeneration(template) With {
            .InsertionAxis = RollInsertionAxis(),
            .GameMode = RollGameMode()
        }

        GenerateInsertionZones(generation)
        GenerateObjectiveZones(generation)

        Dim success As Boolean = GenerateTerrainPieces(generation, targetWeight)
        If Not success Then
            Return generation
        End If

        Return generation

    End Function

    ' =========================================================
    ' GENERATION DES PIECES DE DECOR
    ' =========================================================

    Private Function GenerateTerrainPieces(generation As MapGeneration, targetWeight As Integer) As Boolean

        Dim repository As New TerrainPieceRepository()

        Dim pieces As List(Of TerrainPiece) = repository.Load()


        ' ---------------------------------------------------------
        ' Aucun décor demandé
        ' ---------------------------------------------------------

        If targetWeight <= 0 Then

            Return True

        End If


        ' ---------------------------------------------------------
        ' Base complètement vide
        ' ---------------------------------------------------------

        If pieces.Count = 0 Then

            MessageBox.Show(
            "La base de pièces est vide. " &
            "Impossible d'atteindre la pondération demandée.",
            "Génération de la carte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        ' ---------------------------------------------------------
        ' Copie temporaire des occurrences disponibles.
        '
        ' On NE MODIFIE PAS MaxOccurrences dans TerrainPiece.
        ' ---------------------------------------------------------

        Dim remainingOccurrences As New Dictionary(Of TerrainPiece, Integer)


        For Each piece As TerrainPiece In pieces

            remainingOccurrences(piece) = piece.MaxOccurrences

        Next


        Dim currentWeight As Integer = 0


        ' ---------------------------------------------------------
        ' Moteur principal
        ' ---------------------------------------------------------

        While currentWeight < targetWeight


            ' -----------------------------------------------------
            ' Construction du poids disponible.
            ' -----------------------------------------------------

            Dim availableWeight As Integer = 0

            For Each piece As TerrainPiece In pieces

                If remainingOccurrences(piece) <= 0 Then
                    Continue For
                End If

                If piece.Weight <= 0 Then
                    Continue For
                End If

                availableWeight += piece.Weight

            Next


            ' -----------------------------------------------------
            ' Plus aucune pièce sélectionnable.
            ' -----------------------------------------------------

            If availableWeight <= 0 Then

                MessageBox.Show(
                "La base de pièces a été épuisée " &
                "avant d'atteindre la pondération demandée." &
                Environment.NewLine &
                Environment.NewLine &
                $"Pondération demandée : {targetWeight}" &
                Environment.NewLine &
                $"Pondération obtenue : {currentWeight}",
                "Génération incomplète",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Return False

            End If


            ' -----------------------------------------------------
            ' Tirage pondéré d'une pièce
            ' -----------------------------------------------------

            Dim selectedPiece As TerrainPiece = SelectWeightedPiece(pieces, remainingOccurrences)


            If selectedPiece Is Nothing Then

                MessageBox.Show(
                "Impossible de sélectionner une pièce " &
                "pour poursuivre la génération.",
                "Génération interrompue",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Return False

            End If


            ' -----------------------------------------------------
            ' La pièce sort du pool pour UNE occurrence.
            ' -----------------------------------------------------

            remainingOccurrences(selectedPiece) -= 1


            ' -----------------------------------------------------
            ' Tentative de placement
            ' -----------------------------------------------------

            Dim placer As New MapPiecePlacer()

            Dim placed As Boolean = placer.TryPlacePiece(generation, selectedPiece)


            If Not placed Then

                MessageBox.Show(
                $"La pièce « {selectedPiece.Name} » " &
                "n'a pas pu être placée sur la carte." &
                Environment.NewLine &
                Environment.NewLine &
                "Le nombre de décors est probablement trop " &
                "important ou le réseau est trop dense.",
                "Génération interrompue",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Return False

            End If


            ' -----------------------------------------------------
            ' Placement réussi : ajout du poids.
            ' -----------------------------------------------------

            currentWeight += selectedPiece.Weight

        End While

        Return True

    End Function

    ' =========================================================
    ' TIRAGE PONDERE D'UNE PIECE
    ' =========================================================

    Private Function SelectWeightedPiece(pieces As List(Of TerrainPiece), remainingOccurrences As Dictionary(Of TerrainPiece, Integer)) As TerrainPiece

        Dim totalWeight As Integer = 0


        ' ---------------------------------------------------------
        ' Calcul du poids total disponible
        ' ---------------------------------------------------------

        For Each piece As TerrainPiece In pieces

            If remainingOccurrences(piece) <= 0 Then
                Continue For
            End If

            If piece.Weight <= 0 Then
                Continue For
            End If

            totalWeight += piece.Weight

        Next

        If totalWeight <= 0 Then

            Return Nothing

        End If


        ' ---------------------------------------------------------
        ' Tirage d'un nombre dans la plage pondérée.
        ' ---------------------------------------------------------

        Dim roll As Integer = Random.Shared.Next(1, totalWeight + 1)

        Dim cumulativeWeight As Integer = 0


        ' ---------------------------------------------------------
        ' Recherche de l'intervalle correspondant au tirage.
        ' ---------------------------------------------------------

        For Each piece As TerrainPiece In pieces

            If remainingOccurrences(piece) <= 0 Then
                Continue For
            End If

            If piece.Weight <= 0 Then
                Continue For
            End If

            cumulativeWeight += piece.Weight

            If roll <= cumulativeWeight Then

                Return piece

            End If

        Next

        Return Nothing

    End Function

    Private Function RollInsertionAxis() As InsertionAxis

        If Random.Shared.Next(2) = 0 Then
            Return InsertionAxis.X
        Else
            Return InsertionAxis.Y
        End If

    End Function


    Private Function RollGameMode() As GameMode

        If Random.Shared.Next(2) = 0 Then
            Return GameMode.PurCentre
        Else
            Return GameMode.Offset
        End If

    End Function

    Private Sub GenerateInsertionZones(generation As MapGeneration)

        Dim mapHeight As Integer = generation.Template.HeightCells

        Dim mapWidth As Integer = generation.Template.WidthCells

        Dim insertionDepthX As Integer = MapScale.InsertionDepthXCells

        Dim insertionDepthY As Integer = MapScale.InsertionDepthYCells

        generation.InsertionZones.Clear()


        If generation.InsertionAxis = InsertionAxis.X Then

            ' Bande gauche : 6 pouces = 24 cases
            generation.InsertionZones.Add(
            New InsertionZone With {
                .X = 0,
                .Y = 0,
                .Width = insertionDepthX,
                .Height = mapHeight
            })


            ' Bande droite : 6 pouces = 24 cases
            generation.InsertionZones.Add(
            New InsertionZone With {
                .X = 0,
                .Y = mapWidth - insertionDepthX,
                .Width = insertionDepthX,
                .Height = mapHeight
            })


        Else

            ' Bande haute : 3 pouces = 12 cases
            generation.InsertionZones.Add(
            New InsertionZone With {
                .X = 0,
                .Y = 0,
                .Width = mapWidth,
                .Height = insertionDepthY
            })


            ' Bande basse : 3 pouces = 12 cases
            generation.InsertionZones.Add(
            New InsertionZone With {
                .X = mapHeight - insertionDepthY,
                .Y = 0,
                .Width = mapWidth,
                .Height = insertionDepthY
            })

        End If

    End Sub

    Private Sub GenerateObjectiveZones(generation As MapGeneration)

        generation.ObjectiveZones.Clear()

        Select Case generation.GameMode

            Case GameMode.PurCentre
                GeneratePureCentreObjectives(generation)

            Case GameMode.Offset
                GenerateOffsetObjectives(generation)

        End Select

    End Sub

    Private Sub GeneratePureCentreObjectives(generation As MapGeneration)

        Dim mapHeight As Integer = generation.Template.HeightCells

        Dim mapWidth As Integer = generation.Template.WidthCells

        Dim size As Integer = generation.Template.ObjectiveSizeCells

        Dim insertionDepthX As Integer = MapScale.InsertionDepthXCells

        Dim insertionDepthY As Integer = MapScale.InsertionDepthYCells

        Dim maxA As Integer
        Dim minA As Integer


        ' Détermination de la plage de A
        ' selon l'axe d'insertion.

        If generation.InsertionAxis = InsertionAxis.X Then

            ' Insertion gauche/droite :
            ' 6 pouces = 24 cases.

            maxA =
            (mapWidth \ 2) -
            insertionDepthX -
            size

        Else

            ' Insertion haut/bas :
            ' 3 pouces = 12 cases.

            maxA =
            (mapHeight \ 2) -
            insertionDepthY -
            size

        End If

        ' Le carré central est toujours présent.
        AddCentralObjective(generation)

        Dim central As ObjectiveZone = generation.ObjectiveZones(0)

        For attempt As Integer = 1 To MaxAttempts

            ' ----------------------------------------------------
            ' Tirage de A
            ' ----------------------------------------------------

            minA = 0

            If maxA <= minA Then
                Throw New InvalidOperationException(
                "Impossible de déterminer une plage valide pour A.")
            End If

            Dim a As Integer = Random.Shared.Next(minA, maxA + 1)

            ' ----------------------------------------------------
            ' Tirage de B
            ' ----------------------------------------------------

            Dim minB As Integer
            Dim maxB As Integer

            If generation.InsertionAxis = InsertionAxis.X Then

                maxB = (mapHeight \ 2) - size - (size \ 2)

                minB = -((mapHeight \ 2) - (size \ 2))

            Else

                maxB = (mapWidth \ 2) - size - (size \ 2)

                minB = -((mapWidth \ 2) - (size \ 2))

            End If

            If minB >= maxB Then
                Throw New InvalidOperationException(
                "Impossible de déterminer une plage valide pour B.")
            End If

            Dim b As Integer = Random.Shared.Next(minB, maxB + 1)

            ' ----------------------------------------------------
            ' Lorsque B est négatif mais supérieur à -2L,
            ' les carrés se recouvrent verticalement.
            '
            ' Il faut alors au minimum A = L / 2.
            ' ----------------------------------------------------

            If b < 0 AndAlso Math.Abs(b) < (size * 2) Then
                minA = (size + 1) \ 2
            Else
                minA = 0
            End If

            ' A doit respecter la contrainte calculée.
            If a < minA Then
                Continue For
            End If

            ' ----------------------------------------------------
            ' Création des objectifs secondaires
            ' ----------------------------------------------------

            Dim candidateTop As ObjectiveZone
            Dim candidateBottom As ObjectiveZone

            If generation.InsertionAxis = InsertionAxis.X Then
                candidateTop = CreatePureCentreTopObjective(central, mapWidth, size, a, b)
                candidateBottom = CreatePureCentreBottomObjective(central, mapWidth, size, a, b)
            Else
                candidateTop = CreatePureCentreTopObjectiveForY(central, mapHeight, size, a, b)
                candidateBottom = CreatePureCentreBottomObjectiveForY(central, mapHeight, size, a, b)
            End If

            ' ----------------------------------------------------
            ' Validation
            ' ----------------------------------------------------

            If IsValidObjectiveLayout(generation, central, candidateTop, candidateBottom) Then

                generation.A = a
                generation.B = b

                generation.ObjectiveZones.Add(candidateTop)
                generation.ObjectiveZones.Add(candidateBottom)

                Return

            End If

        Next

        Throw New InvalidOperationException(
        $"Impossible de générer une configuration valide après {MaxAttempts} tentatives.")

    End Sub

    Private Function CreatePureCentreTopObjective(central As ObjectiveZone, mapWidth As Integer, size As Integer, a As Integer, b As Integer) As ObjectiveZone

        Dim centerY As Integer = mapWidth \ 2

        Dim y As Integer =
        centerY - a - size

        Dim x As Integer =
        central.X - b - size

        Return New ObjectiveZone With {
        .X = x,
        .Y = y,
        .Size = size
        }

    End Function

    Private Function CreatePureCentreBottomObjective(central As ObjectiveZone, mapWidth As Integer, size As Integer, a As Integer, b As Integer) As ObjectiveZone

        Dim centerY As Integer = mapWidth \ 2

        Dim y As Integer =
        centerY + a

        Dim x As Integer =
        central.X + central.Size + b

        Return New ObjectiveZone With {
        .X = x,
        .Y = y,
        .Size = size
        }

    End Function

    Private Function CreatePureCentreTopObjectiveForY(central As ObjectiveZone, mapHeight As Integer, size As Integer, a As Integer, b As Integer) As ObjectiveZone

        Dim centerX As Integer = mapHeight \ 2

        Dim x As Integer =
        centerX - a - size

        Dim y As Integer =
        central.Y - b - size

        Return New ObjectiveZone With {
        .X = x,
        .Y = y,
        .Size = size
        }

    End Function

    Private Function CreatePureCentreBottomObjectiveForY(central As ObjectiveZone, mapHeight As Integer, size As Integer, a As Integer, b As Integer) As ObjectiveZone

        Dim centerX As Integer = mapHeight \ 2

        Dim x As Integer =
        centerX + a

        Dim y As Integer =
        central.Y + central.Size + b

        Return New ObjectiveZone With {
        .X = x,
        .Y = y,
        .Size = size
        }

    End Function

    Private Function IsValidObjectiveLayout(generation As MapGeneration, central As ObjectiveZone, first As ObjectiveZone, second As ObjectiveZone) As Boolean

        ' Les trois carrés doivent être dans la carte.
        If Not IsInsideMap(generation, central) Then Return False
        If Not IsInsideMap(generation, first) Then Return False
        If Not IsInsideMap(generation, second) Then Return False

        ' Aucun carré ne doit chevaucher une zone d'insertion.
        For Each insertionZone In generation.InsertionZones

            If ObjectiveIntersectsInsertion(central, insertionZone) Then
                Return False
            End If

            If ObjectiveIntersectsInsertion(first, insertionZone) Then
                Return False
            End If

            If ObjectiveIntersectsInsertion(second, insertionZone) Then
                Return False
            End If

        Next

        ' Aucun objectif ne doit chevaucher un autre.
        If ObjectivesOverlap(central, first) Then Return False
        If ObjectivesOverlap(central, second) Then Return False
        If ObjectivesOverlap(first, second) Then Return False

        Return True

    End Function

    Private Function IsInsideMap(generation As MapGeneration, zone As ObjectiveZone) As Boolean

        Dim mapHeight As Integer = generation.Template.HeightCells
        Dim mapWidth As Integer = generation.Template.WidthCells

        If zone.X < 0 Then Return False
        If zone.Y < 0 Then Return False

        If zone.X + zone.Size > mapHeight Then Return False
        If zone.Y + zone.Size > mapWidth Then Return False

        Return True

    End Function

    Private Function ObjectiveIntersectsInsertion(objective As ObjectiveZone, insertion As InsertionZone) As Boolean

        If objective.X + objective.Size <= insertion.X Then Return False
        If insertion.X + insertion.Height <= objective.X Then Return False

        If objective.Y + objective.Size <= insertion.Y Then Return False
        If insertion.Y + insertion.Width <= objective.Y Then Return False

        Return True

    End Function

    Private Function ObjectivesOverlap(a As ObjectiveZone, b As ObjectiveZone) As Boolean

        If a.X + a.Size <= b.X Then Return False
        If b.X + b.Size <= a.X Then Return False

        If a.Y + a.Size <= b.Y Then Return False
        If b.Y + b.Size <= a.Y Then Return False

        Return True

    End Function

    Private Sub GenerateOffsetObjectives(generation As MapGeneration)

        Dim size As Integer =
        generation.Template.ObjectiveSizeCells

        For attempt As Integer = 1 To MaxAttempts

            ' ----------------------------------------------------
            ' 1. Tirage de Z
            ' ----------------------------------------------------

            Dim z As Integer

            If generation.InsertionAxis = InsertionAxis.X Then

                z = Random.Shared.Next(
                0,
                generation.Template.HeightCells - size + 1)

            Else

                z = Random.Shared.Next(
                0,
                generation.Template.WidthCells - size + 1)

            End If

            ' ----------------------------------------------------
            ' 2. Calcul de B
            '
            ' B correspond directement à la position du couple
            ' d'objectifs secondaires sur l'axe de l'insertion.
            ' ----------------------------------------------------

            Dim b As Integer

            If generation.InsertionAxis = InsertionAxis.X Then

                b =
                generation.Template.HeightCells -
                size -
                z

            Else

                b =
                generation.Template.WidthCells -
                size -
                z

            End If

            ' ----------------------------------------------------
            ' 3. Carré central
            ' ----------------------------------------------------

            Dim central As ObjectiveZone =
            CreateOffsetCentralObjective(
                generation,
                z)

            ' ----------------------------------------------------
            ' 4. Création des deux objectifs secondaires
            ' ----------------------------------------------------

            Dim first As ObjectiveZone = Nothing
            Dim second As ObjectiveZone = Nothing

            Dim a As Integer = 0

            Dim success As Boolean

            If generation.InsertionAxis = InsertionAxis.X Then

                success = TryCreateOffsetObjectivesX(
                generation,
                central,
                size,
                b,
                z,
                first,
                second,
                a)

            Else

                success = TryCreateOffsetObjectivesY(
                generation,
                central,
                size,
                b,
                z,
                first,
                second,
                a)

            End If

            If Not success Then
                Continue For
            End If

            ' ----------------------------------------------------
            ' 5. Validation finale
            ' ----------------------------------------------------

            If Not IsValidObjectiveLayout(
            generation,
            central,
            first,
            second) Then

                Continue For

            End If

            ' ----------------------------------------------------
            ' 6. Enregistrement
            ' ----------------------------------------------------

            generation.ObjectiveZones.Clear()

            generation.ObjectiveZones.Add(central)
            generation.ObjectiveZones.Add(first)
            generation.ObjectiveZones.Add(second)

            generation.A = a
            generation.B = b
            generation.Z = z

            Return

        Next

        Throw New InvalidOperationException(
        $"Impossible de générer une configuration Offset valide après {MaxAttempts} tentatives.")

    End Sub

    Private Function CreateOffsetCentralObjective(generation As MapGeneration, z As Integer) As ObjectiveZone

        Dim mapHeight As Integer = generation.Template.HeightCells
        Dim mapWidth As Integer = generation.Template.WidthCells
        Dim size As Integer = generation.Template.ObjectiveSizeCells

        If generation.InsertionAxis = InsertionAxis.X Then

            Return New ObjectiveZone With {
            .X = z,
            .Y = (mapWidth \ 2) - (size \ 2),
            .Size = size
        }

        Else

            Return New ObjectiveZone With {
            .X = (mapHeight \ 2) - (size \ 2),
            .Y = z,
            .Size = size
        }

        End If

    End Function

    Private Function TryCreateOffsetObjectivesX(generation As MapGeneration, central As ObjectiveZone, size As Integer, b As Integer, z As Integer, ByRef first As ObjectiveZone, ByRef second As ObjectiveZone, ByRef a As Integer) As Boolean

        Dim mapWidth As Integer =
        generation.Template.WidthCells

        Dim mapHeight As Integer =
        generation.Template.HeightCells

        ' ----------------------------------------------------
        ' 1. Déterminer la contrainte minimale sur A
        '
        ' Si le carré central se trouve dans la bande critique
        ' autour de la médiane de X, les objectifs secondaires
        ' doivent être suffisamment écartés sur Y.
        ' ----------------------------------------------------

        Dim centerX As Integer =
        mapHeight \ 2

        Dim halfSize As Integer =
        size \ 2

        Dim minA As Integer

        If z >= centerX - halfSize AndAlso
       z <= centerX + halfSize Then

            minA = halfSize

        Else

            minA = 0

        End If

        ' ----------------------------------------------------
        ' 2. Maximum de A
        ' ----------------------------------------------------

        Dim maxA As Integer =
        (mapWidth \ 2) - size

        If maxA < minA Then
            Return False
        End If

        ' ----------------------------------------------------
        ' 3. Tirage de A
        ' ----------------------------------------------------

        a = Random.Shared.Next(
        minA,
        maxA + 1)

        ' ----------------------------------------------------
        ' 4. Positionnement des deux objectifs secondaires
        ' sur l'axe Y.
        '
        ' Ils sont symétriques par rapport à l'axe central.
        ' ----------------------------------------------------

        Dim centerY As Integer =
        mapWidth \ 2

        Dim leftY As Integer =
        centerY - a - size

        Dim rightY As Integer =
        centerY + a

        ' ----------------------------------------------------
        ' 5. Positionnement sur l'axe X
        '
        ' B = X - L - Z
        '
        ' B est directement la position X des secondaires.
        ' ----------------------------------------------------

        Dim x As Integer =
        b

        ' ----------------------------------------------------
        ' 6. Création des objectifs
        ' ----------------------------------------------------

        first = New ObjectiveZone With {
        .X = x,
        .Y = leftY,
        .Size = size
    }

        second = New ObjectiveZone With {
        .X = x,
        .Y = rightY,
        .Size = size
    }

        Return True

    End Function

    Private Function TryCreateOffsetObjectivesY(generation As MapGeneration, central As ObjectiveZone, size As Integer, b As Integer, z As Integer, ByRef first As ObjectiveZone, ByRef second As ObjectiveZone, ByRef a As Integer) As Boolean

        Dim mapHeight As Integer =
        generation.Template.HeightCells

        Dim mapWidth As Integer =
        generation.Template.WidthCells

        ' ----------------------------------------------------
        ' 1. Déterminer la contrainte minimale sur A
        '
        ' A agit sur l'axe X.
        ' ----------------------------------------------------

        Dim centerY As Integer =
        mapWidth \ 2

        Dim halfSize As Integer =
        size \ 2

        Dim minA As Integer

        If z >= centerY - halfSize AndAlso
       z <= centerY + halfSize Then

            minA = halfSize

        Else

            minA = 0

        End If

        ' ----------------------------------------------------
        ' 2. Maximum de A
        ' ----------------------------------------------------

        Dim maxA As Integer =
        (mapHeight \ 2) - size

        If maxA < minA Then
            Return False
        End If

        ' ----------------------------------------------------
        ' 3. Tirage de A
        ' ----------------------------------------------------

        a = Random.Shared.Next(
        minA,
        maxA + 1)

        ' ----------------------------------------------------
        ' 4. Positionnement des deux objectifs secondaires
        ' sur l'axe X.
        ' ----------------------------------------------------

        Dim centerX As Integer =
        mapHeight \ 2

        Dim topX As Integer =
        centerX - a - size

        Dim bottomX As Integer =
        centerX + a

        ' ----------------------------------------------------
        ' 5. Positionnement sur l'axe Y
        '
        ' B = Y - L - Z
        '
        ' B est directement la position Y des secondaires.
        ' ----------------------------------------------------

        Dim y As Integer =
        b

        ' ----------------------------------------------------
        ' 6. Création des objectifs
        ' ----------------------------------------------------

        first = New ObjectiveZone With {
        .X = topX,
        .Y = y,
        .Size = size
    }

        second = New ObjectiveZone With {
        .X = bottomX,
        .Y = y,
        .Size = size
    }

        Return True

    End Function

    Private Sub AddCentralObjective(generation As MapGeneration)

        Dim mapHeight As Integer = generation.Template.HeightCells
        Dim mapWidth As Integer = generation.Template.WidthCells
        Dim size As Integer = generation.Template.ObjectiveSizeCells

        generation.ObjectiveZones.Add(
            New ObjectiveZone With {
                .X = (mapHeight \ 2) - (size \ 2),
                .Y = (mapWidth \ 2) - (size \ 2),
                .Size = size
            })

    End Sub

End Module