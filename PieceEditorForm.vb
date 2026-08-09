Imports System.Windows.Forms

Public Class PieceEditorForm

    Private _pieceGrid As PieceGridView

    Public Sub New()

        InitializeComponent()

        _pieceGrid = New PieceGridView()

        _pieceGrid.Name = "pieceGridCreerPiece"
        _pieceGrid.Dock = DockStyle.Fill

        pnlCreerPieceGrille.Controls.Add(_pieceGrid)

        _pieceGrid.Rows =
            CInt(nudCreerPieceX.Value)

        _pieceGrid.Columns =
            CInt(nudCreerPieceY.Value)

    End Sub

    Private Sub nudCreerPieceX_ValueChanged(sender As Object, e As EventArgs) Handles nudCreerPieceX.ValueChanged

        If _pieceGrid Is Nothing Then
            Return
        End If

        _pieceGrid.Rows = CInt(nudCreerPieceX.Value)

    End Sub

    Private Sub nudCreerPieceY_ValueChanged(sender As Object, e As EventArgs) Handles nudCreerPieceY.ValueChanged

        If _pieceGrid Is Nothing Then
            Return
        End If

        _pieceGrid.Columns = CInt(nudCreerPieceY.Value)

    End Sub

    Private Sub btnCreerPieceAnnuler_Click(sender As Object, e As EventArgs) Handles btnCreerPieceAnnuler.Click

        DialogResult = DialogResult.Cancel
        Close()

    End Sub

    Private Sub btnCreerPieceEnregistrer_Click(sender As Object, e As EventArgs) Handles btnCreerPieceEnregistrer.Click

        DialogResult = DialogResult.OK
        Close()

    End Sub

End Class