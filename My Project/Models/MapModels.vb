' ============================================================
' Modèles utilisés pour la génération des cartes de Randomap
' ============================================================

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


Public Class MapTemplateDefinition

    Public Property Template As MapTemplate

    ' Dimensions utilisateur, en pouces
    Public Property X As Integer
    Public Property Y As Integer

    ' Taille des zones d'objectif, en pouces
    Public Property ObjectiveSize As Integer

    ' Dimensions internes, en cases de 0,1 pouce
    Public ReadOnly Property HeightCells As Integer
        Get
            Return X * 10
        End Get
    End Property

    Public ReadOnly Property WidthCells As Integer
        Get
            Return Y * 10
        End Get
    End Property

    Public ReadOnly Property ObjectiveSizeCells As Integer
        Get
            Return ObjectiveSize * 10
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
        ' Toutes les valeurs sont exprimées en cases de 0,1 pouce.

        ' Distance entre la médiane et le bord intérieur
        ' des objectifs secondaires.
        Public Property A As Integer

        ' Distance signée entre les bords des objectifs.
        '
        ' B > 0  : espace entre les objectifs
        ' B = 0  : les objectifs se touchent
        ' B < 0  : les objectifs se recouvrent sur leur axe
        '
        ' En mode PurCentre, la même valeur est appliquée
        ' symétriquement au-dessus et au-dessous du centre.
        Public Property B As Integer

        ' Décalage du carré central en mode Offset.
        Public Property Z As Integer

        ' Zones d'insertion
        Public Property InsertionZones As New List(Of InsertionZone)

        ' Zones d'objectif
        Public Property ObjectiveZones As New List(Of ObjectiveZone)

    End Class

End Module
