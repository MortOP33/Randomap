Imports System.Drawing

Public Module MapEquipmentPlacer

    ' =========================================================
    ' GENERATION DES POSITIONS DES EQUIPEMENTS
    ' =========================================================

    Public Function GenerateEquipmentPositions(generation As MapGeneration, equipmentCount As Integer) As Boolean

        If generation Is Nothing Then
            Return False
        End If

        If equipmentCount < 4 OrElse equipmentCount Mod 2 <> 0 Then

            Return False

        End If

        ' ---------------------------------------------------------
        ' Les anciens équipements sont toujours supprimés.
        ' ---------------------------------------------------------

        generation.EquipmentPositions.Clear()

        ' ---------------------------------------------------------
        ' Dimensions de la carte
        ' ---------------------------------------------------------

        Dim mapHeight As Integer = generation.Template.HeightCells

        Dim mapWidth As Integer = generation.Template.WidthCells

        ' ---------------------------------------------------------
        ' Détermination de l'ordre des quatre quarts
        ' selon l'axe d'insertion.
        ' ---------------------------------------------------------

        Dim quarterOrder As List(Of Integer) = GetQuarterOrder(generation.InsertionAxis)

        ' ---------------------------------------------------------
        ' Placement des équipements
        ' ---------------------------------------------------------

        For equipmentIndex As Integer = 0 To equipmentCount - 1

            Dim preferredQuarterIndex As Integer = equipmentIndex Mod quarterOrder.Count

            Dim preferredQuarter As Integer = quarterOrder(preferredQuarterIndex)

            ' -----------------------------------------------------
            ' On essaie d'abord le quart prévu.
            ' -----------------------------------------------------

            Dim position As Point? = FindRandomAvailablePositionInQuarter(generation, preferredQuarter, mapHeight, mapWidth)

            ' -----------------------------------------------------
            ' Si le quart prévu est plein, on cherche dans les
            ' autres quarts.
            ' -----------------------------------------------------

            If Not position.HasValue Then

                For Each quarter As Integer In quarterOrder

                    If quarter = preferredQuarter Then
                        Continue For
                    End If

                    position = FindRandomAvailablePositionInQuarter(generation, quarter, mapHeight, mapWidth)

                    If position.HasValue Then
                        Exit For
                    End If

                Next

            End If

            ' -----------------------------------------------------
            ' Aucune case disponible sur toute la carte.
            ' -----------------------------------------------------

            If Not position.HasValue Then

                generation.EquipmentPositions.Clear()

                Return False

            End If

            generation.EquipmentPositions.Add(position.Value)

        Next

        Return True

    End Function


    ' =========================================================
    ' ORDRE DES QUARTS
    ' =========================================================

    Private Function GetQuarterOrder(insertionAxis As InsertionAxis) As List(Of Integer)

        If insertionAxis = InsertionAxis.X Then

            ' Gauche / droite
            '
            ' 0 = haut gauche
            ' 1 = haut droite
            ' 2 = bas gauche
            ' 3 = bas droite
            '
            ' Alternance :
            ' gauche → droite → gauche → droite

            Return New List(Of Integer) From {0, 3, 2, 1}

        Else

            ' Haut / bas
            '
            ' Alternance :
            ' haut → bas → haut → bas

            Return New List(Of Integer) From {0, 3, 1, 2}

        End If

    End Function


    ' =========================================================
    ' RECHERCHE D'UNE CASE LIBRE DANS UN QUART
    ' =========================================================

    Private Function FindRandomAvailablePositionInQuarter(generation As MapGeneration, quarter As Integer, mapHeight As Integer, mapWidth As Integer) As Point?

        Dim halfHeight As Integer = mapHeight \ 2
        Dim halfWidth As Integer = mapWidth \ 2

        Dim minX As Integer
        Dim maxX As Integer

        Dim minY As Integer
        Dim maxY As Integer


        Select Case quarter

            ' -----------------------------------------------------
            ' Haut gauche
            ' -----------------------------------------------------

            Case 0

                minX = 0
                maxX = halfHeight - 1

                minY = 0
                maxY = halfWidth - 1


            ' -----------------------------------------------------
            ' Haut droite
            ' -----------------------------------------------------

            Case 1

                minX = 0
                maxX = halfHeight - 1

                minY = halfWidth
                maxY = mapWidth - 1


            ' -----------------------------------------------------
            ' Bas gauche
            ' -----------------------------------------------------

            Case 2

                minX = halfHeight
                maxX = mapHeight - 1

                minY = 0
                maxY = halfWidth - 1


            ' -----------------------------------------------------
            ' Bas droite
            ' -----------------------------------------------------

            Case 3

                minX = halfHeight
                maxX = mapHeight - 1

                minY = halfWidth
                maxY = mapWidth - 1


            Case Else

                Return Nothing

        End Select


        ' ---------------------------------------------------------
        ' Construction des cases disponibles.
        '
        ' On les mélange ensuite en choisissant directement
        ' une position aléatoire.
        ' ---------------------------------------------------------

        Dim availablePositions As New List(Of Point)()

        For mapX As Integer = minX To maxX

            For mapY As Integer = minY To maxY

                If IsEquipmentPositionAvailable(generation, mapX, mapY) Then

                    availablePositions.Add(New Point(mapX, mapY))

                End If

            Next

        Next

        If availablePositions.Count = 0 Then
            Return Nothing
        End If

        Dim randomIndex As Integer = Random.Shared.Next(0, availablePositions.Count)

        Return availablePositions(randomIndex)

    End Function


    ' =========================================================
    ' VALIDITE D'UNE CASE POUR UN EQUIPEMENT
    ' =========================================================

    Private Function IsEquipmentPositionAvailable(generation As MapGeneration, mapX As Integer, mapY As Integer) As Boolean

        ' ---------------------------------------------------------
        ' Sécurité hors carte
        ' ---------------------------------------------------------

        If mapX < 0 OrElse
           mapX >= generation.Template.HeightCells OrElse
           mapY < 0 OrElse
           mapY >= generation.Template.WidthCells Then

            Return False

        End If

        ' ---------------------------------------------------------
        ' Une pièce de décor occupe déjà cette case.
        '
        ' Cela couvre les états 1 ET 2.
        ' ---------------------------------------------------------

        If generation.OccupiedCells(mapX, mapY) Then

            Return False

        End If

        ' ---------------------------------------------------------
        ' Zone d'insertion
        ' ---------------------------------------------------------

        For Each zone As InsertionZone In generation.InsertionZones

            If IsInsideInsertionZone(mapX, mapY, zone) Then

                Return False

            End If

        Next

        ' ---------------------------------------------------------
        ' Zone d'objectif
        ' ---------------------------------------------------------

        For Each zone As ObjectiveZone In generation.ObjectiveZones

            If IsInsideObjectiveZone(mapX, mapY, zone) Then

                Return False

            End If

        Next

        Return True

    End Function


    ' =========================================================
    ' ZONE D'INSERTION
    ' =========================================================

    Private Function IsInsideInsertionZone(x As Integer, y As Integer, zone As InsertionZone) As Boolean

        Return x >= zone.X AndAlso
               x < zone.X + zone.Height AndAlso
               y >= zone.Y AndAlso
               y < zone.Y + zone.Width

    End Function

    ' =========================================================
    ' ZONE D'OBJECTIF
    ' =========================================================

    Private Function IsInsideObjectiveZone(x As Integer, y As Integer, zone As ObjectiveZone) As Boolean

        Return x >= zone.X AndAlso
               x < zone.X + zone.Size AndAlso
               y >= zone.Y AndAlso
               y < zone.Y + zone.Size

    End Function

End Module