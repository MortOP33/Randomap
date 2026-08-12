Imports System.Drawing
Imports System.Windows.Forms

Public Class MainForm

    Private ReadOnly _terrainPieceRepository As New TerrainPieceRepository()

    Private ReadOnly _terrainPieces As New List(Of TerrainPiece)

    Public Sub New()

        InitializeComponent()

        Dim loadedPieces As List(Of TerrainPiece) = _terrainPieceRepository.Load()

        _terrainPieces.AddRange(loadedPieces)

        lblValeurDensite.Text = $"{trkDensite.Value}%"

        RefreshGestionBDD()

    End Sub

    Private Sub trkDensite_Scroll(sender As Object, e As EventArgs) Handles trkDensite.Scroll

        lblValeurDensite.Text = $"{trkDensite.Value}%"

    End Sub

    Private Sub btnGenerer_Click(sender As Object, e As EventArgs) Handles btnGenerer.Click

        Dim selectedTemplate As MapTemplate = GetSelectedTemplate()

        Dim definition As MapTemplateDefinition = MapTemplates.GetDefinition(selectedTemplate)

        Dim generation As MapGeneration = MapTemplateGenerator.Generate(definition, CInt(nudPoidsMax.Value), CInt(trkDensite.Value))

        mapView.Generation = generation

    End Sub

    Private Function GetSelectedTemplate() As MapTemplate

        If rdoStandard.Checked Then
            Return MapTemplate.Standard
        ElseIf rdoGrand.Checked Then
            Return MapTemplate.Grand
        ElseIf rdoGeant.Checked Then
            Return MapTemplate.Geant
        Else
            Return MapTemplate.Standard
        End If

    End Function

    Private Sub btnAjouterPiece_Click(sender As Object, e As EventArgs) Handles btnAjouterPiece.Click

        Using formPiece As New PieceEditorForm()

            If formPiece.ShowDialog(Me) = DialogResult.OK Then

                If formPiece.Piece Is Nothing Then
                    Return
                End If

                _terrainPieces.Add(formPiece.Piece)

                _terrainPieceRepository.Save(
                _terrainPieces)

                RefreshGestionBDD()

            End If

        End Using

    End Sub

    Private Sub RefreshGestionBDD()

        flpPieces.SuspendLayout()

        flpPieces.Controls.Clear()

        Dim pieces As List(Of TerrainPiece) =
        GetTerrainPiecesSorted()

        For Each piece As TerrainPiece In pieces

            Dim panelPiece As Panel =
            CreatePiecePanel(piece)

            flpPieces.Controls.Add(panelPiece)

        Next

        flpPieces.ResumeLayout()

    End Sub

    Private Function GetTerrainPiecesSorted() As List(Of TerrainPiece)

        Return _terrainPieces _
            .OrderBy(Function(piece) GetTypeOrder(piece.Type)) _
            .ThenBy(Function(piece) piece.Name) _
            .ToList()

    End Function

    Private Function GetTypeOrder(type As TerrainPieceType) As Integer

        Select Case type

            Case TerrainPieceType.LEGER
                Return 0

            Case TerrainPieceType.LOURD
                Return 1

            Case TerrainPieceType.ETAGE
                Return 2

            Case Else
                Return Integer.MaxValue

        End Select

    End Function

    Private Function CreatePiecePanel(piece As TerrainPiece) As Panel

        ' =========================================================
        ' PANEL PRINCIPAL DE LA LIGNE
        ' =========================================================

        Dim panelPiece As New Panel()

        panelPiece.Width = flpPieces.ClientSize.Width - 25
        panelPiece.Height = 375
        panelPiece.Margin = New Padding(5)
        panelPiece.BorderStyle = BorderStyle.FixedSingle


        ' =========================================================
        ' TABLE PRINCIPALE : 3 COLONNES
        '
        ' Colonne 0 : informations
        ' Colonne 1 : aperçu
        ' Colonne 2 : boutons
        ' =========================================================

        Dim tlpPiece As New TableLayoutPanel()

        tlpPiece.Dock = DockStyle.Fill
        tlpPiece.ColumnCount = 3
        tlpPiece.RowCount = 1

        tlpPiece.ColumnStyles.Add(
        New ColumnStyle(
            SizeType.Absolute,
            260))

        tlpPiece.ColumnStyles.Add(
        New ColumnStyle(
            SizeType.Percent,
            100))

        tlpPiece.ColumnStyles.Add(
        New ColumnStyle(
            SizeType.Absolute,
            200))

        tlpPiece.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            100))


        ' =========================================================
        ' COLONNE 1 : INFORMATIONS DE LA PIECE
        ' =========================================================

        Dim infoPanel As New TableLayoutPanel()

        infoPanel.Dock = DockStyle.Fill
        infoPanel.ColumnCount = 1
        infoPanel.RowCount = 4
        infoPanel.Padding = New Padding(10)


        ' Répartition équitable des 4 informations
        infoPanel.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            25.0F))

        infoPanel.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            25.0F))

        infoPanel.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            25.0F))

        infoPanel.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            25.0F))


        ' =========================================================
        ' NOM
        ' =========================================================

        Dim lblNom As New Label()

        lblNom.Text = piece.Name
        lblNom.Dock = DockStyle.Fill
        lblNom.TextAlign = ContentAlignment.MiddleCenter
        lblNom.Font = New Font(
        lblNom.Font.FontFamily,
        15.0F,
        FontStyle.Bold)

        infoPanel.Controls.Add(
        lblNom,
        0,
        0)


        ' =========================================================
        ' TYPE
        ' =========================================================

        Dim lblType As New Label()

        lblType.Text = piece.Type.ToString()
        lblType.Dock = DockStyle.Fill
        lblType.TextAlign = ContentAlignment.MiddleCenter
        lblType.Font = New Font(
        lblType.Font.FontFamily,
        12.0F,
        FontStyle.Regular)

        infoPanel.Controls.Add(
        lblType,
        0,
        1)


        ' =========================================================
        ' NOMBRE MAXIMUM
        ' =========================================================

        Dim lblNb As New Label()

        lblNb.Text =
        $"Occurrences max : {piece.MaxOccurrences}"

        lblNb.Dock = DockStyle.Fill
        lblNb.TextAlign = ContentAlignment.MiddleCenter
        lblNb.Font = New Font(
        lblNb.Font.FontFamily,
        12.0F,
        FontStyle.Regular)

        infoPanel.Controls.Add(
        lblNb,
        0,
        2)


        ' =========================================================
        ' POIDS
        ' =========================================================

        Dim lblPoids As New Label()

        lblPoids.Text =
        $"Poids : {piece.Weight}"

        lblPoids.Dock = DockStyle.Fill
        lblPoids.TextAlign = ContentAlignment.MiddleCenter
        lblPoids.Font = New Font(
        lblPoids.Font.FontFamily,
        12.0F,
        FontStyle.Regular)

        infoPanel.Controls.Add(
        lblPoids,
        0,
        3)


        ' Ajout de la colonne informations
        tlpPiece.Controls.Add(
        infoPanel,
        0,
        0)


        ' =========================================================
        ' COLONNE 2 : APERCU
        '
        ' Le TerrainPiecePreview adapte automatiquement
        ' l'affichage de la pièce à l'espace disponible.
        ' =========================================================

        Dim preview As New TerrainPiecePreview()

        preview.Dock = DockStyle.Fill
        preview.Margin = New Padding(10)

        preview.Piece = piece

        tlpPiece.Controls.Add(
        preview,
        1,
        0)


        ' =========================================================
        ' COLONNE 3 : BOUTONS
        ' =========================================================

        Dim actionsPanel As New TableLayoutPanel()

        actionsPanel.Dock = DockStyle.Fill
        actionsPanel.ColumnCount = 1
        actionsPanel.RowCount = 2
        actionsPanel.Padding = New Padding(10)

        actionsPanel.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            50))

        actionsPanel.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            50))


        ' =========================================================
        ' BOUTON MODIFIER
        ' =========================================================

        Dim btnModifier As New Button()

        btnModifier.Text = "Modifier"
        btnModifier.Dock = DockStyle.Fill

        ' On associe directement la pièce au bouton
        btnModifier.Tag = piece

        AddHandler btnModifier.Click,
        AddressOf BtnModifier_Click

        actionsPanel.Controls.Add(
        btnModifier,
        0,
        0)


        ' =========================================================
        ' BOUTON SUPPRIMER
        ' =========================================================

        Dim btnSupprimer As New Button()

        btnSupprimer.Text = "Supprimer"
        btnSupprimer.Dock = DockStyle.Fill

        ' On associe directement la pièce au bouton
        btnSupprimer.Tag = piece

        AddHandler btnSupprimer.Click,
        AddressOf BtnSupprimer_Click

        actionsPanel.Controls.Add(
        btnSupprimer,
        0,
        1)


        ' Ajout de la colonne actions
        tlpPiece.Controls.Add(
        actionsPanel,
        2,
        0)


        ' =========================================================
        ' AJOUT DU TABLELAYOUTPANEL AU PANEL PRINCIPAL
        ' =========================================================

        panelPiece.Controls.Add(
        tlpPiece)


        Return panelPiece

    End Function

    Private Sub BtnSupprimer_Click(sender As Object, e As EventArgs)

        Dim button As Button =
            DirectCast(sender, Button)

        Dim piece As TerrainPiece =
            DirectCast(button.Tag, TerrainPiece)


        Dim result As DialogResult =
            MessageBox.Show(
                $"Voulez-vous vraiment supprimer la pièce « {piece.Name} » ?",
                "Suppression d'une pièce",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)


        If result <> DialogResult.Yes Then
            Return
        End If


        ' Retrait de la pièce de la liste en mémoire
        _terrainPieces.Remove(piece)


        ' Sauvegarde du nouveau contenu JSON
        _terrainPieceRepository.Save(
            _terrainPieces)


        ' Reconstruction de l'affichage
        RefreshGestionBDD()

    End Sub

    Private Sub BtnModifier_Click(sender As Object, e As EventArgs)

        Dim button As Button =
            DirectCast(sender, Button)

        Dim piece As TerrainPiece =
            DirectCast(button.Tag, TerrainPiece)


        Using formPiece As New PieceEditorForm(piece)

            If formPiece.ShowDialog(Me) =
                DialogResult.OK Then

                _terrainPieceRepository.Save(
                    _terrainPieces)

                RefreshGestionBDD()

            End If

        End Using

    End Sub

End Class