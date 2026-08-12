Imports System.Windows.Forms

Public Class PieceEditorForm

    Private _pieceGrid As PieceGridView

    Private _piece As TerrainPiece

    Private _pieceToEdit As TerrainPiece

    Public ReadOnly Property Piece As TerrainPiece
        Get
            Return _piece
        End Get
    End Property

    Public Sub New(Optional pieceToEdit As TerrainPiece = Nothing)

        InitializeComponent()

        _pieceToEdit = pieceToEdit

        ' ---------------------------------------------------------
        ' Création de la grille
        ' ---------------------------------------------------------

        _pieceGrid = New PieceGridView()

        _pieceGrid.Name = "pieceGridCreerPiece"
        _pieceGrid.Dock = DockStyle.Fill

        AddHandler _pieceGrid.GridModified, AddressOf PieceGrid_GridModified

        pnlCreerPieceGrille.Controls.Add(
        _pieceGrid)


        ' ---------------------------------------------------------
        ' Dimensions initiales de la grille
        ' ---------------------------------------------------------

        _pieceGrid.Rows =
        CInt(nudCreerPieceX.Value)

        _pieceGrid.Columns =
        CInt(nudCreerPieceY.Value)


        ' ---------------------------------------------------------
        ' Mode modification
        ' ---------------------------------------------------------

        If _pieceToEdit IsNot Nothing Then

            LoadPieceForEditing()

        End If

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

    Private Sub PieceGrid_GridModified()

        nudCreerPiecePoids.Value = _pieceGrid.CalculateWeight()

    End Sub

    Private Sub btnCreerPieceAnnuler_Click(sender As Object, e As EventArgs) Handles btnCreerPieceAnnuler.Click

        DialogResult = DialogResult.Cancel
        Close()

    End Sub

    Private Sub btnCreerPieceEnregistrer_Click(sender As Object, e As EventArgs) Handles btnCreerPieceEnregistrer.Click

        Dim pieceType As TerrainPieceType


        ' ---------------------------------------------------------
        ' Détermination du type
        ' ---------------------------------------------------------

        If rdoCreerPieceLeger.Checked Then

            pieceType = TerrainPieceType.LEGER

        ElseIf rdoCreerPieceLourd.Checked Then

            pieceType = TerrainPieceType.LOURD

        Else

            pieceType = TerrainPieceType.ETAGE

        End If


        ' =========================================================
        ' MODE MODIFICATION
        ' =========================================================

        If _pieceToEdit IsNot Nothing Then

            _pieceToEdit.Name =
            txtCreerPieceNom.Text.Trim

            _pieceToEdit.X =
            CInt(nudCreerPieceX.Value)

            _pieceToEdit.Y =
            CInt(nudCreerPieceY.Value)

            _pieceToEdit.MaxOccurrences =
            CInt(nudCreerPieceNbMax.Value)

            _pieceToEdit.Weight =
            CInt(nudCreerPiecePoids.Value)

            _pieceToEdit.Type =
            pieceType

            _pieceToEdit.Cells =
            _pieceGrid.GetCellsCopy


            ' La pièce retournée est la pièce existante
            _piece = _pieceToEdit

        Else

            ' =====================================================
            ' MODE CREATION
            ' =====================================================

            _piece = New TerrainPiece With {
            .Name = txtCreerPieceNom.Text.Trim,
            .X = nudCreerPieceX.Value,
            .Y = nudCreerPieceY.Value,
            .MaxOccurrences = nudCreerPieceNbMax.Value,
            .Weight = CInt(nudCreerPiecePoids.Value),
            .Type = pieceType,
            .Cells = _pieceGrid.GetCellsCopy
        }

        End If


        DialogResult = DialogResult.OK
        Close()

    End Sub


    Private Sub LoadPieceForEditing()

        If _pieceToEdit Is Nothing Then
            Return
        End If


        ' ---------------------------------------------------------
        ' Informations générales
        ' ---------------------------------------------------------

        txtCreerPieceNom.Text =
        _pieceToEdit.Name

        nudCreerPieceX.Value =
        _pieceToEdit.X

        nudCreerPieceY.Value =
        _pieceToEdit.Y

        nudCreerPieceNbMax.Value =
        _pieceToEdit.MaxOccurrences

        nudCreerPiecePoids.Value =
        _pieceToEdit.Weight


        ' ---------------------------------------------------------
        ' Type
        ' ---------------------------------------------------------

        Select Case _pieceToEdit.Type

            Case TerrainPieceType.LEGER

                rdoCreerPieceLeger.Checked = True

            Case TerrainPieceType.LOURD

                rdoCreerPieceLourd.Checked = True

            Case TerrainPieceType.ETAGE

                rdoCreerPieceEtage.Checked = True

        End Select


        ' ---------------------------------------------------------
        ' Grille
        ' ---------------------------------------------------------

        If _pieceToEdit.Cells IsNot Nothing Then

            _pieceGrid.SetCells(_pieceToEdit.Cells)

        End If

    End Sub

End Class