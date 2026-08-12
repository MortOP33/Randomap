Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Serialization

Public Class TerrainPieceRepository

    Private ReadOnly _filePath As String

    Private Shared ReadOnly JsonOptions As JsonSerializerOptions

    Shared Sub New()

        JsonOptions = New JsonSerializerOptions With {
            .WriteIndented = True
        }

        JsonOptions.Converters.Add(
            New JsonStringEnumConverter())

    End Sub

    Public Sub New()

        _filePath = Path.Combine(AppContext.BaseDirectory, "Base de pieces.json")

    End Sub

    Public Function Load() As List(Of TerrainPiece)

        If Not File.Exists(_filePath) Then

            Return New List(Of TerrainPiece)()

        End If

        Dim json As String =
            File.ReadAllText(_filePath)

        If String.IsNullOrWhiteSpace(json) Then

            Return New List(Of TerrainPiece)()

        End If

        Dim database As TerrainPieceDatabaseData =
            JsonSerializer.Deserialize(Of TerrainPieceDatabaseData)(
                json,
                JsonOptions)

        If database Is Nothing OrElse
           database.Pieces Is Nothing Then

            Return New List(Of TerrainPiece)()

        End If

        Dim pieces As New List(Of TerrainPiece)()

        For Each data As TerrainPieceData In database.Pieces

            pieces.Add(
                FromData(data))

        Next

        Return pieces

    End Function

    Public Sub Save(pieces As List(Of TerrainPiece))

        Dim database As New TerrainPieceDatabaseData()

        For Each piece As TerrainPiece In pieces

            database.Pieces.Add(
                piece.ToData())

        Next

        Dim json As String =
            JsonSerializer.Serialize(
                database,
                JsonOptions)

        File.WriteAllText(
            _filePath,
            json)

    End Sub

    Private Function FromData(data As TerrainPieceData) As TerrainPiece

        Dim cells(
            data.X - 1,
            data.Y - 1
        ) As TerrainCellState

        For row As Integer = 0 To data.X - 1

            For column As Integer = 0 To data.Y - 1

                cells(row, column) =
                    CType(
                        data.Cells(row)(column),
                        TerrainCellState)

            Next

        Next

        Return New TerrainPiece With {
            .Name = data.Name,
            .X = data.X,
            .Y = data.Y,
            .MaxOccurrences = data.MaxOccurrences,
            .Weight = data.Weight,
            .Type = data.Type,
            .Cells = cells
        }

    End Function

End Class
