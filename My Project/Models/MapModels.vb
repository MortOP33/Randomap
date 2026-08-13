' ============================================================
' Modèles utilisés pour la génération des cartes de Randomap
' ============================================================

Imports System.Drawing

Public Enum MapTemplate
    Standard
    Grand
    Geant
End Enum

Public Enum InsertionAxis
    X
    Y
End Enum

Public Enum GameMode
    PurCentre
    Offset
End Enum

Public Enum PieceRotation
    Deg0
    Deg90
    Deg180
    Deg270
End Enum


Public Class MapTemplateDefinition

    Public Property Template As MapTemplate

    ' Dimensions utilisateur, en pouces
    Public Property X As Integer
    Public Property Y As Integer

    ' Taille des zones d'objectif, en pouces
    Public Property ObjectiveSize As Double

    ' Dimensions internes, en cases de 0,1 pouce
    Public ReadOnly Property HeightCells As Integer
        Get
            Return X * MapScale.CellsPerInch
        End Get
    End Property

    Public ReadOnly Property WidthCells As Integer
        Get
            Return Y * MapScale.CellsPerInch
        End Get
    End Property

    Public ReadOnly Property ObjectiveSizeCells As Integer
        Get
            Return CInt(ObjectiveSize * MapScale.CellsPerInch)
        End Get
    End Property

End Class


Public Class InsertionZone

    ' Coordonnée de départ en cases
    Public Property X As Integer
    Public Property Y As Integer

    ' Dimensions en cases
    Public Property Width As Integer
    Public Property Height As Integer

End Class


Public Class ObjectiveZone

    ' Coordonnée de départ en cases
    Public Property X As Integer
    Public Property Y As Integer

    ' Taille du carré en cases
    Public Property Size As Integer

End Class

Public Class PlacedTerrainPiece

    Public Property Piece As TerrainPiece

    Public Property X As Integer

    Public Property Y As Integer

    Public Property Rotation As PieceRotation

End Class

Public Module MapPieceGeometry

    Public Function GetRotatedCellState(piece As TerrainPiece, row As Integer, column As Integer, rotation As PieceRotation) As TerrainCellState

        Select Case rotation

            Case PieceRotation.Deg0

                Return piece.Cells(
                    row,
                    column)

            Case PieceRotation.Deg90

                Return piece.Cells(
                    piece.X - 1 - column,
                    row)

            Case PieceRotation.Deg180

                Return piece.Cells(
                    piece.X - 1 - row,
                    piece.Y - 1 - column)

            Case PieceRotation.Deg270

                Return piece.Cells(
                    column,
                    piece.Y - 1 - row)

            Case Else

                Return TerrainCellState.Empty

        End Select

    End Function

End Module

Public Module MapTemplates

    Public ReadOnly Standard As New MapTemplateDefinition With {
        .Template = MapTemplate.Standard,
        .X = 22,
        .Y = 30,
        .ObjectiveSize = 2
    }

    Public ReadOnly Grand As New MapTemplateDefinition With {
        .Template = MapTemplate.Grand,
        .X = 30,
        .Y = 44,
        .ObjectiveSize = 2
    }

    Public ReadOnly Geant As New MapTemplateDefinition With {
        .Template = MapTemplate.Geant,
        .X = 44,
        .Y = 60,
        .ObjectiveSize = 7.5
    }


    Public Function GetDefinition(template As MapTemplate) As MapTemplateDefinition

        Select Case template

            Case MapTemplate.Standard
                Return Standard

            Case MapTemplate.Grand
                Return Grand

            Case MapTemplate.Geant
                Return Geant

            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(template))

        End Select

    End Function

    Public Class MapGeneration

        ' Gabarit utilisé pour cette génération
        Public Property Template As MapTemplateDefinition

        ' Axe d'insertion tiré au sort
        Public Property InsertionAxis As InsertionAxis

        ' Mode de jeu tiré au sort
        Public Property GameMode As GameMode

        ' Paramètres géométriques tirés au sort.
        ' Toutes les valeurs géométriques internes sont
        ' exprimées en cases de 1/4 de pouce.

        ' Distance entre la médiane et le bord intérieur
        ' des objectifs secondaires.
        Public Property A As Integer

        ' Distance signée entre les bords des objectifs.
        Public Property B As Integer

        ' Décalage du carré central en mode Offset.
        Public Property Z As Integer


        ' =========================================================
        ' ZONES ET PIECES
        ' =========================================================

        ' Zones d'insertion
        Public Property InsertionZones As New List(Of InsertionZone)

        ' Zones d'objectif
        Public Property ObjectiveZones As New List(Of ObjectiveZone)

        ' Liste des pièces effectivement placées
        Public Property PlacedPieces As New List(Of PlacedTerrainPiece)

        ' Grille interne des cases connectées
        Public Property ConnectionCells As Boolean(,)

        ' Grille interne des cases occupées
        Public Property OccupiedCells As Boolean(,)

        ' Positions des équipements sur la carte.
        Public Property EquipmentPositions As New List(Of Point)


        ' =========================================================
        ' CONSTRUCTEUR
        ' =========================================================

        Public Sub New(template As MapTemplateDefinition)

            Me.Template = template

            Me.OccupiedCells =
            New Boolean(
                template.HeightCells - 1,
                template.WidthCells - 1
            ) {}

            Me.ConnectionCells =
            New Boolean(
                template.HeightCells - 1,
                template.WidthCells - 1) {}

            Me.PlacedPieces =
                New List(Of PlacedTerrainPiece)()

        End Sub

    End Class

End Module
