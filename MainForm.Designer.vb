<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        tabMain = New System.Windows.Forms.TabControl()
        tabCreationMap = New System.Windows.Forms.TabPage()
        tlpCreationMap = New System.Windows.Forms.TableLayoutPanel()
        pnlMap = New System.Windows.Forms.Panel()
        tlpParametres = New System.Windows.Forms.TableLayoutPanel()
        tlpDimensions = New System.Windows.Forms.TableLayoutPanel()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        nudMapX = New System.Windows.Forms.NumericUpDown()
        nudMapY = New System.Windows.Forms.NumericUpDown()
        tlpParametresGeneraux = New System.Windows.Forms.TableLayoutPanel()
        tlpPoids = New System.Windows.Forms.TableLayoutPanel()
        Label3 = New System.Windows.Forms.Label()
        nudPoidsMax = New System.Windows.Forms.NumericUpDown()
        tlpDensite = New System.Windows.Forms.TableLayoutPanel()
        Label4 = New System.Windows.Forms.Label()
        trkDensite = New System.Windows.Forms.TrackBar()
        lblValeurDensite = New System.Windows.Forms.Label()
        btnGenerer = New System.Windows.Forms.Button()
        tlpRepartition = New System.Windows.Forms.TableLayoutPanel()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        trkLeger = New System.Windows.Forms.TrackBar()
        trkLourd = New System.Windows.Forms.TrackBar()
        trkEtage = New System.Windows.Forms.TrackBar()
        lblValeurLeger = New System.Windows.Forms.Label()
        lblValeurLourd = New System.Windows.Forms.Label()
        lblValeurEtage = New System.Windows.Forms.Label()
        tabGestionBDD = New System.Windows.Forms.TabPage()
        tlpGestionBDD = New System.Windows.Forms.TableLayoutPanel()
        btnAjouterPiece = New System.Windows.Forms.Button()
        flpPieces = New System.Windows.Forms.FlowLayoutPanel()
        tabMain.SuspendLayout()
        tabCreationMap.SuspendLayout()
        tlpCreationMap.SuspendLayout()
        tlpParametres.SuspendLayout()
        tlpDimensions.SuspendLayout()
        CType(nudMapX, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMapY, ComponentModel.ISupportInitialize).BeginInit()
        tlpParametresGeneraux.SuspendLayout()
        tlpPoids.SuspendLayout()
        CType(nudPoidsMax, ComponentModel.ISupportInitialize).BeginInit()
        tlpDensite.SuspendLayout()
        CType(trkDensite, ComponentModel.ISupportInitialize).BeginInit()
        tlpRepartition.SuspendLayout()
        CType(trkLeger, ComponentModel.ISupportInitialize).BeginInit()
        CType(trkLourd, ComponentModel.ISupportInitialize).BeginInit()
        CType(trkEtage, ComponentModel.ISupportInitialize).BeginInit()
        tabGestionBDD.SuspendLayout()
        tlpGestionBDD.SuspendLayout()
        SuspendLayout()
        ' 
        ' tabMain
        ' 
        tabMain.Controls.Add(tabCreationMap)
        tabMain.Controls.Add(tabGestionBDD)
        tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        tabMain.ItemSize = New System.Drawing.Size(690, 20)
        tabMain.Location = New System.Drawing.Point(0, 0)
        tabMain.Name = "tabMain"
        tabMain.SelectedIndex = 0
        tabMain.Size = New System.Drawing.Size(1384, 861)
        tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        tabMain.TabIndex = 0
        ' 
        ' tabCreationMap
        ' 
        tabCreationMap.Controls.Add(tlpCreationMap)
        tabCreationMap.Location = New System.Drawing.Point(4, 24)
        tabCreationMap.Name = "tabCreationMap"
        tabCreationMap.Padding = New System.Windows.Forms.Padding(3)
        tabCreationMap.Size = New System.Drawing.Size(1376, 833)
        tabCreationMap.TabIndex = 0
        tabCreationMap.Text = "CREATION DE MAP"
        tabCreationMap.UseVisualStyleBackColor = True
        ' 
        ' tlpCreationMap
        ' 
        tlpCreationMap.ColumnCount = 1
        tlpCreationMap.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpCreationMap.Controls.Add(pnlMap, 0, 0)
        tlpCreationMap.Controls.Add(tlpParametres, 0, 1)
        tlpCreationMap.Dock = System.Windows.Forms.DockStyle.Fill
        tlpCreationMap.Location = New System.Drawing.Point(3, 3)
        tlpCreationMap.Name = "tlpCreationMap"
        tlpCreationMap.RowCount = 2
        tlpCreationMap.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 650F))
        tlpCreationMap.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpCreationMap.Size = New System.Drawing.Size(1370, 827)
        tlpCreationMap.TabIndex = 0
        ' 
        ' pnlMap
        ' 
        pnlMap.Anchor = System.Windows.Forms.AnchorStyles.None
        pnlMap.BackColor = Drawing.Color.Silver
        pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        pnlMap.Location = New System.Drawing.Point(135, 10)
        pnlMap.Name = "pnlMap"
        pnlMap.Size = New System.Drawing.Size(1100, 630)
        pnlMap.TabIndex = 0
        ' 
        ' tlpParametres
        ' 
        tlpParametres.ColumnCount = 3
        tlpParametres.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F))
        tlpParametres.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F))
        tlpParametres.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F))
        tlpParametres.Controls.Add(tlpDimensions, 0, 0)
        tlpParametres.Controls.Add(tlpParametresGeneraux, 1, 0)
        tlpParametres.Controls.Add(tlpRepartition, 2, 0)
        tlpParametres.Dock = System.Windows.Forms.DockStyle.Fill
        tlpParametres.Location = New System.Drawing.Point(3, 653)
        tlpParametres.Name = "tlpParametres"
        tlpParametres.RowCount = 1
        tlpParametres.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpParametres.Size = New System.Drawing.Size(1364, 171)
        tlpParametres.TabIndex = 1
        ' 
        ' tlpDimensions
        ' 
        tlpDimensions.ColumnCount = 2
        tlpDimensions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpDimensions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpDimensions.Controls.Add(Label1, 0, 0)
        tlpDimensions.Controls.Add(Label2, 0, 1)
        tlpDimensions.Controls.Add(nudMapX, 1, 0)
        tlpDimensions.Controls.Add(nudMapY, 1, 1)
        tlpDimensions.Dock = System.Windows.Forms.DockStyle.Fill
        tlpDimensions.Location = New System.Drawing.Point(3, 3)
        tlpDimensions.Name = "tlpDimensions"
        tlpDimensions.RowCount = 2
        tlpDimensions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpDimensions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        tlpDimensions.Size = New System.Drawing.Size(335, 165)
        tlpDimensions.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Segoe UI", 36F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label1.Location = New System.Drawing.Point(55, 8)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(56, 65)
        Label1.TabIndex = 0
        Label1.Text = "X"
        Label1.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' Label2
        ' 
        Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Segoe UI", 36F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label2.Location = New System.Drawing.Point(56, 91)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(55, 65)
        Label2.TabIndex = 1
        Label2.Text = "Y"
        ' 
        ' nudMapX
        ' 
        nudMapX.Anchor = System.Windows.Forms.AnchorStyles.None
        nudMapX.Font = New System.Drawing.Font("Segoe UI", 36F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        nudMapX.Location = New System.Drawing.Point(170, 5)
        nudMapX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudMapX.Name = "nudMapX"
        nudMapX.Size = New System.Drawing.Size(162, 71)
        nudMapX.TabIndex = 2
        nudMapX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        nudMapX.Value = New Decimal(New Integer() {22, 0, 0, 0})
        ' 
        ' nudMapY
        ' 
        nudMapY.Anchor = System.Windows.Forms.AnchorStyles.None
        nudMapY.Font = New System.Drawing.Font("Segoe UI", 36F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        nudMapY.Location = New System.Drawing.Point(170, 88)
        nudMapY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudMapY.Name = "nudMapY"
        nudMapY.Size = New System.Drawing.Size(162, 71)
        nudMapY.TabIndex = 3
        nudMapY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        nudMapY.Value = New Decimal(New Integer() {30, 0, 0, 0})
        ' 
        ' tlpParametresGeneraux
        ' 
        tlpParametresGeneraux.ColumnCount = 1
        tlpParametresGeneraux.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpParametresGeneraux.Controls.Add(tlpPoids, 0, 0)
        tlpParametresGeneraux.Controls.Add(tlpDensite, 0, 1)
        tlpParametresGeneraux.Controls.Add(btnGenerer, 0, 2)
        tlpParametresGeneraux.Dock = System.Windows.Forms.DockStyle.Fill
        tlpParametresGeneraux.Location = New System.Drawing.Point(344, 3)
        tlpParametresGeneraux.Name = "tlpParametresGeneraux"
        tlpParametresGeneraux.RowCount = 3
        tlpParametresGeneraux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F))
        tlpParametresGeneraux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F))
        tlpParametresGeneraux.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F))
        tlpParametresGeneraux.Size = New System.Drawing.Size(471, 165)
        tlpParametresGeneraux.TabIndex = 1
        ' 
        ' tlpPoids
        ' 
        tlpPoids.ColumnCount = 2
        tlpPoids.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F))
        tlpPoids.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F))
        tlpPoids.Controls.Add(Label3, 0, 0)
        tlpPoids.Controls.Add(nudPoidsMax, 1, 0)
        tlpPoids.Dock = System.Windows.Forms.DockStyle.Fill
        tlpPoids.Location = New System.Drawing.Point(3, 3)
        tlpPoids.Name = "tlpPoids"
        tlpPoids.RowCount = 1
        tlpPoids.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpPoids.Size = New System.Drawing.Size(465, 43)
        tlpPoids.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Segoe UI", 15.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label3.Location = New System.Drawing.Point(13, 6)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(112, 30)
        Label3.TabIndex = 0
        Label3.Text = "Poids max."
        Label3.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' nudPoidsMax
        ' 
        nudPoidsMax.Anchor = System.Windows.Forms.AnchorStyles.None
        nudPoidsMax.Font = New System.Drawing.Font("Segoe UI", 18F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        nudPoidsMax.Location = New System.Drawing.Point(142, 3)
        nudPoidsMax.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        nudPoidsMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudPoidsMax.Name = "nudPoidsMax"
        nudPoidsMax.Size = New System.Drawing.Size(320, 39)
        nudPoidsMax.TabIndex = 1
        nudPoidsMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        nudPoidsMax.Value = New Decimal(New Integer() {100, 0, 0, 0})
        ' 
        ' tlpDensite
        ' 
        tlpDensite.ColumnCount = 3
        tlpDensite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
        tlpDensite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F))
        tlpDensite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
        tlpDensite.Controls.Add(Label4, 0, 0)
        tlpDensite.Controls.Add(trkDensite, 1, 0)
        tlpDensite.Controls.Add(lblValeurDensite, 2, 0)
        tlpDensite.Dock = System.Windows.Forms.DockStyle.Fill
        tlpDensite.Location = New System.Drawing.Point(3, 52)
        tlpDensite.Name = "tlpDensite"
        tlpDensite.RowCount = 1
        tlpDensite.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpDensite.Size = New System.Drawing.Size(465, 43)
        tlpDensite.TabIndex = 1
        ' 
        ' Label4
        ' 
        Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Segoe UI", 15.75F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label4.Location = New System.Drawing.Point(5, 6)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(83, 30)
        Label4.TabIndex = 0
        Label4.Text = "Densité"
        Label4.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' trkDensite
        ' 
        trkDensite.Dock = System.Windows.Forms.DockStyle.Fill
        trkDensite.LargeChange = 10
        trkDensite.Location = New System.Drawing.Point(96, 3)
        trkDensite.Maximum = 100
        trkDensite.Name = "trkDensite"
        trkDensite.Size = New System.Drawing.Size(273, 37)
        trkDensite.TabIndex = 1
        trkDensite.TickFrequency = 10
        trkDensite.Value = 50
        ' 
        ' lblValeurDensite
        ' 
        lblValeurDensite.Anchor = System.Windows.Forms.AnchorStyles.None
        lblValeurDensite.AutoSize = True
        lblValeurDensite.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblValeurDensite.Location = New System.Drawing.Point(395, 3)
        lblValeurDensite.Name = "lblValeurDensite"
        lblValeurDensite.Size = New System.Drawing.Size(47, 37)
        lblValeurDensite.TabIndex = 2
        lblValeurDensite.Text = "50"
        ' 
        ' btnGenerer
        ' 
        btnGenerer.Anchor = System.Windows.Forms.AnchorStyles.None
        btnGenerer.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        btnGenerer.Location = New System.Drawing.Point(60, 106)
        btnGenerer.Name = "btnGenerer"
        btnGenerer.Size = New System.Drawing.Size(350, 50)
        btnGenerer.TabIndex = 2
        btnGenerer.Text = "Générer"
        btnGenerer.UseVisualStyleBackColor = True
        ' 
        ' tlpRepartition
        ' 
        tlpRepartition.ColumnCount = 3
        tlpRepartition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
        tlpRepartition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F))
        tlpRepartition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
        tlpRepartition.Controls.Add(Label5, 0, 0)
        tlpRepartition.Controls.Add(Label6, 0, 1)
        tlpRepartition.Controls.Add(Label7, 0, 2)
        tlpRepartition.Controls.Add(trkLeger, 1, 0)
        tlpRepartition.Controls.Add(trkLourd, 1, 1)
        tlpRepartition.Controls.Add(trkEtage, 1, 2)
        tlpRepartition.Controls.Add(lblValeurLeger, 2, 0)
        tlpRepartition.Controls.Add(lblValeurLourd, 2, 1)
        tlpRepartition.Controls.Add(lblValeurEtage, 2, 2)
        tlpRepartition.Dock = System.Windows.Forms.DockStyle.Fill
        tlpRepartition.Location = New System.Drawing.Point(821, 3)
        tlpRepartition.Name = "tlpRepartition"
        tlpRepartition.RowCount = 3
        tlpRepartition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpRepartition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpRepartition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpRepartition.Size = New System.Drawing.Size(540, 165)
        tlpRepartition.TabIndex = 2
        ' 
        ' Label5
        ' 
        Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label5.Location = New System.Drawing.Point(12, 9)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(83, 37)
        Label5.TabIndex = 0
        Label5.Text = "Léger"
        Label5.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' Label6
        ' 
        Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label6.Location = New System.Drawing.Point(11, 64)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(86, 37)
        Label6.TabIndex = 1
        Label6.Text = "Lourd"
        Label6.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' Label7
        ' 
        Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Label7.Location = New System.Drawing.Point(12, 119)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(84, 37)
        Label7.TabIndex = 2
        Label7.Text = "Étage"
        Label7.TextAlign = Drawing.ContentAlignment.MiddleRight
        ' 
        ' trkLeger
        ' 
        trkLeger.Dock = System.Windows.Forms.DockStyle.Fill
        trkLeger.LargeChange = 10
        trkLeger.Location = New System.Drawing.Point(111, 3)
        trkLeger.Maximum = 100
        trkLeger.Name = "trkLeger"
        trkLeger.Size = New System.Drawing.Size(318, 49)
        trkLeger.TabIndex = 3
        trkLeger.TickFrequency = 10
        trkLeger.Value = 50
        ' 
        ' trkLourd
        ' 
        trkLourd.Dock = System.Windows.Forms.DockStyle.Fill
        trkLourd.LargeChange = 10
        trkLourd.Location = New System.Drawing.Point(111, 58)
        trkLourd.Maximum = 100
        trkLourd.Name = "trkLourd"
        trkLourd.Size = New System.Drawing.Size(318, 49)
        trkLourd.TabIndex = 4
        trkLourd.TickFrequency = 10
        trkLourd.Value = 50
        ' 
        ' trkEtage
        ' 
        trkEtage.Dock = System.Windows.Forms.DockStyle.Fill
        trkEtage.LargeChange = 10
        trkEtage.Location = New System.Drawing.Point(111, 113)
        trkEtage.Maximum = 100
        trkEtage.Name = "trkEtage"
        trkEtage.Size = New System.Drawing.Size(318, 49)
        trkEtage.TabIndex = 5
        trkEtage.TickFrequency = 10
        trkEtage.Value = 50
        ' 
        ' lblValeurLeger
        ' 
        lblValeurLeger.Anchor = System.Windows.Forms.AnchorStyles.None
        lblValeurLeger.AutoSize = True
        lblValeurLeger.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblValeurLeger.Location = New System.Drawing.Point(462, 9)
        lblValeurLeger.Name = "lblValeurLeger"
        lblValeurLeger.Size = New System.Drawing.Size(47, 37)
        lblValeurLeger.TabIndex = 6
        lblValeurLeger.Text = "50"
        ' 
        ' lblValeurLourd
        ' 
        lblValeurLourd.Anchor = System.Windows.Forms.AnchorStyles.None
        lblValeurLourd.AutoSize = True
        lblValeurLourd.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblValeurLourd.Location = New System.Drawing.Point(462, 64)
        lblValeurLourd.Name = "lblValeurLourd"
        lblValeurLourd.Size = New System.Drawing.Size(47, 37)
        lblValeurLourd.TabIndex = 7
        lblValeurLourd.Text = "50"
        ' 
        ' lblValeurEtage
        ' 
        lblValeurEtage.Anchor = System.Windows.Forms.AnchorStyles.None
        lblValeurEtage.AutoSize = True
        lblValeurEtage.Font = New System.Drawing.Font("Segoe UI", 20.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        lblValeurEtage.Location = New System.Drawing.Point(462, 119)
        lblValeurEtage.Name = "lblValeurEtage"
        lblValeurEtage.Size = New System.Drawing.Size(47, 37)
        lblValeurEtage.TabIndex = 8
        lblValeurEtage.Text = "50"
        ' 
        ' tabGestionBDD
        ' 
        tabGestionBDD.Controls.Add(tlpGestionBDD)
        tabGestionBDD.Location = New System.Drawing.Point(4, 24)
        tabGestionBDD.Name = "tabGestionBDD"
        tabGestionBDD.Padding = New System.Windows.Forms.Padding(3)
        tabGestionBDD.Size = New System.Drawing.Size(1376, 833)
        tabGestionBDD.TabIndex = 1
        tabGestionBDD.Text = "GESTION BASE DES PIECES"
        tabGestionBDD.UseVisualStyleBackColor = True
        ' 
        ' tlpGestionBDD
        ' 
        tlpGestionBDD.ColumnCount = 1
        tlpGestionBDD.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpGestionBDD.Controls.Add(btnAjouterPiece, 0, 0)
        tlpGestionBDD.Controls.Add(flpPieces, 0, 1)
        tlpGestionBDD.Dock = System.Windows.Forms.DockStyle.Fill
        tlpGestionBDD.Location = New System.Drawing.Point(3, 3)
        tlpGestionBDD.Name = "tlpGestionBDD"
        tlpGestionBDD.RowCount = 2
        tlpGestionBDD.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F))
        tlpGestionBDD.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpGestionBDD.Size = New System.Drawing.Size(1370, 827)
        tlpGestionBDD.TabIndex = 0
        ' 
        ' btnAjouterPiece
        ' 
        btnAjouterPiece.Anchor = System.Windows.Forms.AnchorStyles.None
        btnAjouterPiece.AutoSize = True
        btnAjouterPiece.Font = New System.Drawing.Font("Segoe UI", 18F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        btnAjouterPiece.Location = New System.Drawing.Point(385, 9)
        btnAjouterPiece.Name = "btnAjouterPiece"
        btnAjouterPiece.Size = New System.Drawing.Size(600, 42)
        btnAjouterPiece.TabIndex = 0
        btnAjouterPiece.Text = "Ajouter une pièce de décor"
        btnAjouterPiece.UseVisualStyleBackColor = True
        ' 
        ' flpPieces
        ' 
        flpPieces.AutoScroll = True
        flpPieces.Dock = System.Windows.Forms.DockStyle.Fill
        flpPieces.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        flpPieces.Location = New System.Drawing.Point(3, 63)
        flpPieces.Name = "flpPieces"
        flpPieces.Size = New System.Drawing.Size(1364, 761)
        flpPieces.TabIndex = 1
        flpPieces.WrapContents = False
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(1384, 861)
        Controls.Add(tabMain)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "MainForm"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "Randomap"
        tabMain.ResumeLayout(False)
        tabCreationMap.ResumeLayout(False)
        tlpCreationMap.ResumeLayout(False)
        tlpParametres.ResumeLayout(False)
        tlpDimensions.ResumeLayout(False)
        tlpDimensions.PerformLayout()
        CType(nudMapX, ComponentModel.ISupportInitialize).EndInit()
        CType(nudMapY, ComponentModel.ISupportInitialize).EndInit()
        tlpParametresGeneraux.ResumeLayout(False)
        tlpPoids.ResumeLayout(False)
        tlpPoids.PerformLayout()
        CType(nudPoidsMax, ComponentModel.ISupportInitialize).EndInit()
        tlpDensite.ResumeLayout(False)
        tlpDensite.PerformLayout()
        CType(trkDensite, ComponentModel.ISupportInitialize).EndInit()
        tlpRepartition.ResumeLayout(False)
        tlpRepartition.PerformLayout()
        CType(trkLeger, ComponentModel.ISupportInitialize).EndInit()
        CType(trkLourd, ComponentModel.ISupportInitialize).EndInit()
        CType(trkEtage, ComponentModel.ISupportInitialize).EndInit()
        tabGestionBDD.ResumeLayout(False)
        tlpGestionBDD.ResumeLayout(False)
        tlpGestionBDD.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabCreationMap As System.Windows.Forms.TabPage
    Friend WithEvents tabGestionBDD As System.Windows.Forms.TabPage
    Friend WithEvents tlpCreationMap As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlMap As System.Windows.Forms.Panel
    Friend WithEvents tlpParametres As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpDimensions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudMapX As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMapY As System.Windows.Forms.NumericUpDown
    Friend WithEvents tlpParametresGeneraux As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpPoids As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpDensite As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGenerer As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudPoidsMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents trkDensite As System.Windows.Forms.TrackBar
    Friend WithEvents tlpRepartition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents trkLeger As System.Windows.Forms.TrackBar
    Friend WithEvents trkLourd As System.Windows.Forms.TrackBar
    Friend WithEvents trkEtage As System.Windows.Forms.TrackBar
    Friend WithEvents tlpGestionBDD As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAjouterPiece As System.Windows.Forms.Button
    Friend WithEvents flpPieces As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblValeurDensite As System.Windows.Forms.Label
    Friend WithEvents lblValeurLeger As System.Windows.Forms.Label
    Friend WithEvents lblValeurLourd As System.Windows.Forms.Label
    Friend WithEvents lblValeurEtage As System.Windows.Forms.Label
End Class
