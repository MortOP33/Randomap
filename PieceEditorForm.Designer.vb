<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PieceEditorForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        tlpCreationPiece = New System.Windows.Forms.TableLayoutPanel()
        tlpInformationsPiece = New System.Windows.Forms.TableLayoutPanel()
        lblCreerPieceNom = New System.Windows.Forms.Label()
        txtCreerPieceNom = New System.Windows.Forms.TextBox()
        tlpCreerPieceX = New System.Windows.Forms.TableLayoutPanel()
        lblCreerPieceX = New System.Windows.Forms.Label()
        nudCreerPieceX = New System.Windows.Forms.NumericUpDown()
        tlpCreerPieceY = New System.Windows.Forms.TableLayoutPanel()
        lblCreerPieceY = New System.Windows.Forms.Label()
        nudCreerPieceY = New System.Windows.Forms.NumericUpDown()
        tlpCreerPieceType = New System.Windows.Forms.TableLayoutPanel()
        lblCreerPieceLeger = New System.Windows.Forms.Label()
        lblCreerPieceLourd = New System.Windows.Forms.Label()
        lblCreerPieceEtage = New System.Windows.Forms.Label()
        rdoCreerPieceLeger = New System.Windows.Forms.RadioButton()
        rdoCreerPieceLourd = New System.Windows.Forms.RadioButton()
        rdoCreerPieceEtage = New System.Windows.Forms.RadioButton()
        lblCreerPieceNbMax = New System.Windows.Forms.Label()
        nudCreerPieceNbMax = New System.Windows.Forms.NumericUpDown()
        tlpCreerPieceBoutons = New System.Windows.Forms.TableLayoutPanel()
        btnCreerPieceEnregistrer = New System.Windows.Forms.Button()
        btnCreerPieceAnnuler = New System.Windows.Forms.Button()
        pnlCreerPieceGrille = New System.Windows.Forms.Panel()
        tlpCreationPiece.SuspendLayout()
        tlpInformationsPiece.SuspendLayout()
        tlpCreerPieceX.SuspendLayout()
        CType(nudCreerPieceX, ComponentModel.ISupportInitialize).BeginInit()
        tlpCreerPieceY.SuspendLayout()
        CType(nudCreerPieceY, ComponentModel.ISupportInitialize).BeginInit()
        tlpCreerPieceType.SuspendLayout()
        CType(nudCreerPieceNbMax, ComponentModel.ISupportInitialize).BeginInit()
        tlpCreerPieceBoutons.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpCreationPiece
        ' 
        tlpCreationPiece.ColumnCount = 2
        tlpCreationPiece.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F))
        tlpCreationPiece.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F))
        tlpCreationPiece.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        tlpCreationPiece.Controls.Add(tlpInformationsPiece, 0, 0)
        tlpCreationPiece.Controls.Add(pnlCreerPieceGrille, 1, 0)
        tlpCreationPiece.Dock = System.Windows.Forms.DockStyle.Fill
        tlpCreationPiece.Location = New System.Drawing.Point(0, 0)
        tlpCreationPiece.Name = "tlpCreationPiece"
        tlpCreationPiece.RowCount = 1
        tlpCreationPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpCreationPiece.Size = New System.Drawing.Size(1231, 743)
        tlpCreationPiece.TabIndex = 0
        ' 
        ' tlpInformationsPiece
        ' 
        tlpInformationsPiece.ColumnCount = 1
        tlpInformationsPiece.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpInformationsPiece.Controls.Add(lblCreerPieceNom, 0, 0)
        tlpInformationsPiece.Controls.Add(txtCreerPieceNom, 0, 1)
        tlpInformationsPiece.Controls.Add(tlpCreerPieceX, 0, 2)
        tlpInformationsPiece.Controls.Add(tlpCreerPieceY, 0, 3)
        tlpInformationsPiece.Controls.Add(tlpCreerPieceType, 0, 4)
        tlpInformationsPiece.Controls.Add(lblCreerPieceNbMax, 0, 5)
        tlpInformationsPiece.Controls.Add(nudCreerPieceNbMax, 0, 6)
        tlpInformationsPiece.Controls.Add(tlpCreerPieceBoutons, 0, 7)
        tlpInformationsPiece.Dock = System.Windows.Forms.DockStyle.Fill
        tlpInformationsPiece.Location = New System.Drawing.Point(3, 3)
        tlpInformationsPiece.Name = "tlpInformationsPiece"
        tlpInformationsPiece.RowCount = 8
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
        tlpInformationsPiece.Size = New System.Drawing.Size(301, 737)
        tlpInformationsPiece.TabIndex = 0
        ' 
        ' lblCreerPieceNom
        ' 
        lblCreerPieceNom.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        lblCreerPieceNom.AutoSize = True
        lblCreerPieceNom.Font = New System.Drawing.Font("Segoe UI", 21.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceNom.Location = New System.Drawing.Point(110, 33)
        lblCreerPieceNom.Name = "lblCreerPieceNom"
        lblCreerPieceNom.Size = New System.Drawing.Size(81, 40)
        lblCreerPieceNom.TabIndex = 0
        lblCreerPieceNom.Text = "Nom"
        ' 
        ' txtCreerPieceNom
        ' 
        txtCreerPieceNom.Dock = System.Windows.Forms.DockStyle.Fill
        txtCreerPieceNom.Font = New System.Drawing.Font("Segoe UI", 18F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        txtCreerPieceNom.Location = New System.Drawing.Point(3, 76)
        txtCreerPieceNom.Name = "txtCreerPieceNom"
        txtCreerPieceNom.Size = New System.Drawing.Size(295, 39)
        txtCreerPieceNom.TabIndex = 1
        txtCreerPieceNom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' tlpCreerPieceX
        ' 
        tlpCreerPieceX.ColumnCount = 2
        tlpCreerPieceX.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceX.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceX.Controls.Add(lblCreerPieceX, 0, 0)
        tlpCreerPieceX.Controls.Add(nudCreerPieceX, 1, 0)
        tlpCreerPieceX.Dock = System.Windows.Forms.DockStyle.Fill
        tlpCreerPieceX.Location = New System.Drawing.Point(3, 149)
        tlpCreerPieceX.Name = "tlpCreerPieceX"
        tlpCreerPieceX.RowCount = 1
        tlpCreerPieceX.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceX.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceX.Size = New System.Drawing.Size(295, 67)
        tlpCreerPieceX.TabIndex = 2
        ' 
        ' lblCreerPieceX
        ' 
        lblCreerPieceX.AutoSize = True
        lblCreerPieceX.Dock = System.Windows.Forms.DockStyle.Fill
        lblCreerPieceX.Font = New System.Drawing.Font("Segoe UI", 27.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceX.Location = New System.Drawing.Point(3, 0)
        lblCreerPieceX.Name = "lblCreerPieceX"
        lblCreerPieceX.Size = New System.Drawing.Size(141, 67)
        lblCreerPieceX.TabIndex = 0
        lblCreerPieceX.Text = "X :"
        lblCreerPieceX.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' nudCreerPieceX
        ' 
        nudCreerPieceX.Dock = System.Windows.Forms.DockStyle.Fill
        nudCreerPieceX.Font = New System.Drawing.Font("Segoe UI", 30F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        nudCreerPieceX.Location = New System.Drawing.Point(150, 3)
        nudCreerPieceX.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        nudCreerPieceX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudCreerPieceX.Name = "nudCreerPieceX"
        nudCreerPieceX.Size = New System.Drawing.Size(142, 61)
        nudCreerPieceX.TabIndex = 1
        nudCreerPieceX.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' tlpCreerPieceY
        ' 
        tlpCreerPieceY.ColumnCount = 2
        tlpCreerPieceY.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceY.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceY.Controls.Add(lblCreerPieceY, 0, 0)
        tlpCreerPieceY.Controls.Add(nudCreerPieceY, 1, 0)
        tlpCreerPieceY.Dock = System.Windows.Forms.DockStyle.Fill
        tlpCreerPieceY.Location = New System.Drawing.Point(3, 222)
        tlpCreerPieceY.Name = "tlpCreerPieceY"
        tlpCreerPieceY.RowCount = 1
        tlpCreerPieceY.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceY.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceY.Size = New System.Drawing.Size(295, 67)
        tlpCreerPieceY.TabIndex = 3
        ' 
        ' lblCreerPieceY
        ' 
        lblCreerPieceY.AutoSize = True
        lblCreerPieceY.Dock = System.Windows.Forms.DockStyle.Fill
        lblCreerPieceY.Font = New System.Drawing.Font("Segoe UI", 27.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceY.Location = New System.Drawing.Point(3, 0)
        lblCreerPieceY.Name = "lblCreerPieceY"
        lblCreerPieceY.Size = New System.Drawing.Size(141, 67)
        lblCreerPieceY.TabIndex = 0
        lblCreerPieceY.Text = "Y :"
        lblCreerPieceY.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' nudCreerPieceY
        ' 
        nudCreerPieceY.Dock = System.Windows.Forms.DockStyle.Fill
        nudCreerPieceY.Font = New System.Drawing.Font("Segoe UI", 30F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        nudCreerPieceY.Location = New System.Drawing.Point(150, 3)
        nudCreerPieceY.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        nudCreerPieceY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudCreerPieceY.Name = "nudCreerPieceY"
        nudCreerPieceY.Size = New System.Drawing.Size(142, 61)
        nudCreerPieceY.TabIndex = 1
        nudCreerPieceY.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' tlpCreerPieceType
        ' 
        tlpCreerPieceType.ColumnCount = 2
        tlpCreerPieceType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.3333321F))
        tlpCreerPieceType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.6666679F))
        tlpCreerPieceType.Controls.Add(lblCreerPieceLeger, 0, 0)
        tlpCreerPieceType.Controls.Add(lblCreerPieceLourd, 0, 1)
        tlpCreerPieceType.Controls.Add(lblCreerPieceEtage, 0, 2)
        tlpCreerPieceType.Controls.Add(rdoCreerPieceLeger, 1, 0)
        tlpCreerPieceType.Controls.Add(rdoCreerPieceLourd, 1, 1)
        tlpCreerPieceType.Controls.Add(rdoCreerPieceEtage, 1, 2)
        tlpCreerPieceType.Dock = System.Windows.Forms.DockStyle.Fill
        tlpCreerPieceType.Location = New System.Drawing.Point(3, 295)
        tlpCreerPieceType.Name = "tlpCreerPieceType"
        tlpCreerPieceType.RowCount = 3
        tlpCreerPieceType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpCreerPieceType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpCreerPieceType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpCreerPieceType.Size = New System.Drawing.Size(295, 215)
        tlpCreerPieceType.TabIndex = 4
        ' 
        ' lblCreerPieceLeger
        ' 
        lblCreerPieceLeger.AutoSize = True
        lblCreerPieceLeger.Dock = System.Windows.Forms.DockStyle.Fill
        lblCreerPieceLeger.Font = New System.Drawing.Font("Segoe UI", 27.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceLeger.Location = New System.Drawing.Point(3, 0)
        lblCreerPieceLeger.Name = "lblCreerPieceLeger"
        lblCreerPieceLeger.Size = New System.Drawing.Size(166, 71)
        lblCreerPieceLeger.TabIndex = 0
        lblCreerPieceLeger.Text = "Léger"
        lblCreerPieceLeger.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' lblCreerPieceLourd
        ' 
        lblCreerPieceLourd.AutoSize = True
        lblCreerPieceLourd.Dock = System.Windows.Forms.DockStyle.Fill
        lblCreerPieceLourd.Font = New System.Drawing.Font("Segoe UI", 27.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceLourd.Location = New System.Drawing.Point(3, 71)
        lblCreerPieceLourd.Name = "lblCreerPieceLourd"
        lblCreerPieceLourd.Size = New System.Drawing.Size(166, 71)
        lblCreerPieceLourd.TabIndex = 1
        lblCreerPieceLourd.Text = "Lourd"
        lblCreerPieceLourd.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' lblCreerPieceEtage
        ' 
        lblCreerPieceEtage.AutoSize = True
        lblCreerPieceEtage.Dock = System.Windows.Forms.DockStyle.Fill
        lblCreerPieceEtage.Font = New System.Drawing.Font("Segoe UI", 27.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceEtage.Location = New System.Drawing.Point(3, 142)
        lblCreerPieceEtage.Name = "lblCreerPieceEtage"
        lblCreerPieceEtage.Size = New System.Drawing.Size(166, 73)
        lblCreerPieceEtage.TabIndex = 2
        lblCreerPieceEtage.Text = "Etage"
        lblCreerPieceEtage.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' rdoCreerPieceLeger
        ' 
        rdoCreerPieceLeger.Checked = True
        rdoCreerPieceLeger.Dock = System.Windows.Forms.DockStyle.Bottom
        rdoCreerPieceLeger.Location = New System.Drawing.Point(175, 18)
        rdoCreerPieceLeger.Name = "rdoCreerPieceLeger"
        rdoCreerPieceLeger.Size = New System.Drawing.Size(117, 50)
        rdoCreerPieceLeger.TabIndex = 3
        rdoCreerPieceLeger.TabStop = True
        rdoCreerPieceLeger.UseVisualStyleBackColor = True
        ' 
        ' rdoCreerPieceLourd
        ' 
        rdoCreerPieceLourd.Dock = System.Windows.Forms.DockStyle.Bottom
        rdoCreerPieceLourd.Location = New System.Drawing.Point(175, 89)
        rdoCreerPieceLourd.Name = "rdoCreerPieceLourd"
        rdoCreerPieceLourd.Size = New System.Drawing.Size(117, 50)
        rdoCreerPieceLourd.TabIndex = 4
        rdoCreerPieceLourd.UseVisualStyleBackColor = True
        ' 
        ' rdoCreerPieceEtage
        ' 
        rdoCreerPieceEtage.Dock = System.Windows.Forms.DockStyle.Bottom
        rdoCreerPieceEtage.Location = New System.Drawing.Point(175, 162)
        rdoCreerPieceEtage.Name = "rdoCreerPieceEtage"
        rdoCreerPieceEtage.Size = New System.Drawing.Size(117, 50)
        rdoCreerPieceEtage.TabIndex = 5
        rdoCreerPieceEtage.UseVisualStyleBackColor = True
        ' 
        ' lblCreerPieceNbMax
        ' 
        lblCreerPieceNbMax.AutoSize = True
        lblCreerPieceNbMax.Dock = System.Windows.Forms.DockStyle.Fill
        lblCreerPieceNbMax.Font = New System.Drawing.Font("Segoe UI", 21.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblCreerPieceNbMax.Location = New System.Drawing.Point(3, 513)
        lblCreerPieceNbMax.Name = "lblCreerPieceNbMax"
        lblCreerPieceNbMax.Size = New System.Drawing.Size(295, 73)
        lblCreerPieceNbMax.TabIndex = 5
        lblCreerPieceNbMax.Text = "Nb maximum"
        lblCreerPieceNbMax.TextAlign = Drawing.ContentAlignment.BottomCenter
        ' 
        ' nudCreerPieceNbMax
        ' 
        nudCreerPieceNbMax.Dock = System.Windows.Forms.DockStyle.Fill
        nudCreerPieceNbMax.Font = New System.Drawing.Font("Segoe UI", 30F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        nudCreerPieceNbMax.Location = New System.Drawing.Point(3, 589)
        nudCreerPieceNbMax.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        nudCreerPieceNbMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudCreerPieceNbMax.Name = "nudCreerPieceNbMax"
        nudCreerPieceNbMax.Size = New System.Drawing.Size(295, 61)
        nudCreerPieceNbMax.TabIndex = 6
        nudCreerPieceNbMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        nudCreerPieceNbMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' tlpCreerPieceBoutons
        ' 
        tlpCreerPieceBoutons.ColumnCount = 2
        tlpCreerPieceBoutons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceBoutons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpCreerPieceBoutons.Controls.Add(btnCreerPieceEnregistrer, 0, 0)
        tlpCreerPieceBoutons.Controls.Add(btnCreerPieceAnnuler, 1, 0)
        tlpCreerPieceBoutons.Dock = System.Windows.Forms.DockStyle.Fill
        tlpCreerPieceBoutons.Location = New System.Drawing.Point(3, 662)
        tlpCreerPieceBoutons.Name = "tlpCreerPieceBoutons"
        tlpCreerPieceBoutons.RowCount = 1
        tlpCreerPieceBoutons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpCreerPieceBoutons.Size = New System.Drawing.Size(295, 72)
        tlpCreerPieceBoutons.TabIndex = 7
        ' 
        ' btnCreerPieceEnregistrer
        ' 
        btnCreerPieceEnregistrer.Dock = System.Windows.Forms.DockStyle.Fill
        btnCreerPieceEnregistrer.Font = New System.Drawing.Font("Segoe UI", 15.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        btnCreerPieceEnregistrer.Location = New System.Drawing.Point(3, 3)
        btnCreerPieceEnregistrer.Name = "btnCreerPieceEnregistrer"
        btnCreerPieceEnregistrer.Size = New System.Drawing.Size(141, 66)
        btnCreerPieceEnregistrer.TabIndex = 0
        btnCreerPieceEnregistrer.Text = "Enregistrer"
        btnCreerPieceEnregistrer.UseVisualStyleBackColor = True
        ' 
        ' btnCreerPieceAnnuler
        ' 
        btnCreerPieceAnnuler.Dock = System.Windows.Forms.DockStyle.Fill
        btnCreerPieceAnnuler.Font = New System.Drawing.Font("Segoe UI", 15.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        btnCreerPieceAnnuler.Location = New System.Drawing.Point(150, 3)
        btnCreerPieceAnnuler.Name = "btnCreerPieceAnnuler"
        btnCreerPieceAnnuler.Size = New System.Drawing.Size(142, 66)
        btnCreerPieceAnnuler.TabIndex = 1
        btnCreerPieceAnnuler.Text = "Annuler"
        btnCreerPieceAnnuler.UseVisualStyleBackColor = True
        ' 
        ' pnlCreerPieceGrille
        ' 
        pnlCreerPieceGrille.BackColor = Drawing.SystemColors.ControlLight
        pnlCreerPieceGrille.Dock = System.Windows.Forms.DockStyle.Fill
        pnlCreerPieceGrille.Location = New System.Drawing.Point(310, 3)
        pnlCreerPieceGrille.Name = "pnlCreerPieceGrille"
        pnlCreerPieceGrille.Size = New System.Drawing.Size(918, 737)
        pnlCreerPieceGrille.TabIndex = 1
        ' 
        ' PieceEditorForm
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        CancelButton = btnCreerPieceAnnuler
        ClientSize = New System.Drawing.Size(1231, 743)
        Controls.Add(tlpCreationPiece)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Name = "PieceEditorForm"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "Création d'une pièce de décor"
        tlpCreationPiece.ResumeLayout(False)
        tlpInformationsPiece.ResumeLayout(False)
        tlpInformationsPiece.PerformLayout()
        tlpCreerPieceX.ResumeLayout(False)
        tlpCreerPieceX.PerformLayout()
        CType(nudCreerPieceX, ComponentModel.ISupportInitialize).EndInit()
        tlpCreerPieceY.ResumeLayout(False)
        tlpCreerPieceY.PerformLayout()
        CType(nudCreerPieceY, ComponentModel.ISupportInitialize).EndInit()
        tlpCreerPieceType.ResumeLayout(False)
        tlpCreerPieceType.PerformLayout()
        CType(nudCreerPieceNbMax, ComponentModel.ISupportInitialize).EndInit()
        tlpCreerPieceBoutons.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tlpCreationPiece As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpInformationsPiece As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCreerPieceNom As System.Windows.Forms.Label
    Friend WithEvents txtCreerPieceNom As System.Windows.Forms.TextBox
    Friend WithEvents tlpCreerPieceX As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCreerPieceX As System.Windows.Forms.Label
    Friend WithEvents tlpCreerPieceY As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCreerPieceY As System.Windows.Forms.Label
    Friend WithEvents tlpCreerPieceType As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCreerPieceLeger As System.Windows.Forms.Label
    Friend WithEvents lblCreerPieceLourd As System.Windows.Forms.Label
    Friend WithEvents lblCreerPieceEtage As System.Windows.Forms.Label
    Friend WithEvents rdoCreerPieceLeger As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCreerPieceLourd As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCreerPieceEtage As System.Windows.Forms.RadioButton
    Friend WithEvents nudCreerPieceX As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCreerPieceY As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCreerPieceNbMax As System.Windows.Forms.Label
    Friend WithEvents nudCreerPieceNbMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlCreerPieceGrille As System.Windows.Forms.Panel
    Friend WithEvents tlpCreerPieceBoutons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCreerPieceEnregistrer As System.Windows.Forms.Button
    Friend WithEvents btnCreerPieceAnnuler As System.Windows.Forms.Button
End Class
