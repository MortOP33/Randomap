Public Class TerrainPiece

    Public Property Name As String

    Public Property X As Integer

    Public Property Y As Integer

    Public Property MaxOccurrences As Integer

    Public Property Type As TerrainPieceType

    Public Property Cells As TerrainCellState(,)

    Public Function ToData() As TerrainPieceData

        Dim data As New TerrainPieceData With {
            .Name = Name,
            .X = X,
            .Y = Y,
            .MaxOccurrences = MaxOccurrences,
            .Type = Type,
            .Cells = New List(Of List(Of Integer))()
        }

        For row As Integer = 0 To X - 1

            Dim dataRow As New List(Of Integer)()

            For column As Integer = 0 To Y - 1

                dataRow.Add(
                    CInt(Cells(row, column))
                )

            Next

            data.Cells.Add(dataRow)

        Next

        Return data

    End Function

End Class

Public Enum TerrainPieceType
    LEGER
    LOURD
    ETAGE
End Enum

Public Class TerrainPieceData

    Public Property Name As String

    Public Property X As Integer

    Public Property Y As Integer

    Public Property MaxOccurrences As Integer

    Public Property Type As TerrainPieceType

    Public Property Cells As List(Of List(Of Integer))

End Class

Public Class TerrainPieceDatabaseData

    Public Property Pieces As List(Of TerrainPieceData)

    Public Sub New()

        Pieces = New List(Of TerrainPieceData)()

    End Sub

End Class
