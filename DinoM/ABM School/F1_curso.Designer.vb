<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F1_curso
    Inherits Modelo.ModeloF1

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_curso))
        Dim cbgestion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbparalelo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbgrado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbnivel_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbprofesor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.btcbgestion = New DevComponents.DotNetBar.ButtonX()
        Me.cbgestion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.btcbparalelo = New DevComponents.DotNetBar.ButtonX()
        Me.cbparalelo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.btcbgrado = New DevComponents.DotNetBar.ButtonX()
        Me.cbgrado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lbgrupo1 = New DevComponents.DotNetBar.LabelX()
        Me.btcbnivel = New DevComponents.DotNetBar.ButtonX()
        Me.cbnivel = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbdescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.swEstado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdetalle_telefono = New Janus.Windows.GridEX.GridEX()
        Me.PanelDatosTelefono = New System.Windows.Forms.Panel()
        Me.tbmateria = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelToolBar2.SuspendLayout()
        Me.MPanelSup.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.GroupPanelBuscador.SuspendLayout()
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelNavegacion.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cbgestion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbparalelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbgrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbnivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdetalle_telefono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosTelefono.SuspendLayout()
        Me.SuspendLayout()
        '
        'SuperTabPrincipal
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabPrincipal.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabPrincipal.ControlBox.MenuBox.Name = ""
        Me.SuperTabPrincipal.ControlBox.Name = ""
        Me.SuperTabPrincipal.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabPrincipal.ControlBox.MenuBox, Me.SuperTabPrincipal.ControlBox.CloseBox})
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1282, 953)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1102, 624)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1247, 953)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Size = New System.Drawing.Size(1247, 89)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelSuperior.Style.BackgroundImage = CType(resources.GetObject("PanelSuperior.Style.BackgroundImage"), System.Drawing.Image)
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        '
        'PanelInferior
        '
        Me.PanelInferior.Location = New System.Drawing.Point(0, 909)
        Me.PanelInferior.Size = New System.Drawing.Size(1247, 44)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelInferior.Style.BackgroundImage = CType(resources.GetObject("PanelInferior.Style.BackgroundImage"), System.Drawing.Image)
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        '
        'BubbleBarUsuario
        '
        '
        '
        '
        Me.BubbleBarUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        '
        'btnSalir
        '
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Location = New System.Drawing.Point(1140, 0)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.GroupPanel2)
        Me.MPanelSup.Controls.Add(Me.GroupPanel1)
        Me.MPanelSup.Size = New System.Drawing.Size(1247, 418)
        Me.MPanelSup.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.GroupPanel1, 0)
        Me.MPanelSup.Controls.SetChildIndex(Me.GroupPanel2, 0)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Size = New System.Drawing.Size(1247, 820)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Location = New System.Drawing.Point(0, 418)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1247, 402)
        '
        '
        '
        Me.GroupPanelBuscador.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelBuscador.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelBuscador.Style.BackColorGradientAngle = 90
        Me.GroupPanelBuscador.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderBottomWidth = 1
        Me.GroupPanelBuscador.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelBuscador.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderLeftWidth = 1
        Me.GroupPanelBuscador.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderRightWidth = 1
        Me.GroupPanelBuscador.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderTopWidth = 1
        Me.GroupPanelBuscador.Style.CornerDiameter = 4
        Me.GroupPanelBuscador.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBuscador.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBuscador.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanelBuscador.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.HeaderFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.JGrM_Buscador.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.SelectedFormatStyle.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1241, 375)
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(980, 0)
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Panel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(832, 418)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 21
        Me.GroupPanel1.Text = "Datos Generales"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbprofesor)
        Me.Panel1.Controls.Add(Me.LabelX6)
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Controls.Add(Me.btcbgestion)
        Me.Panel1.Controls.Add(Me.cbgestion)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.btcbparalelo)
        Me.Panel1.Controls.Add(Me.cbparalelo)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.btcbgrado)
        Me.Panel1.Controls.Add(Me.cbgrado)
        Me.Panel1.Controls.Add(Me.lbgrupo1)
        Me.Panel1.Controls.Add(Me.btcbnivel)
        Me.Panel1.Controls.Add(Me.cbnivel)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.tbCodigo)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.tbdescripcion)
        Me.Panel1.Controls.Add(Me.swEstado)
        Me.Panel1.Controls.Add(Me.LabelX9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(826, 393)
        Me.Panel1.TabIndex = 0
        '
        'tbprofesor
        '
        '
        '
        '
        Me.tbprofesor.Border.Class = "TextBoxBorder"
        Me.tbprofesor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbprofesor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbprofesor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbprofesor.Location = New System.Drawing.Point(228, 309)
        Me.tbprofesor.Margin = New System.Windows.Forms.Padding(4)
        Me.tbprofesor.Name = "tbprofesor"
        Me.tbprofesor.PreventEnterBeep = True
        Me.tbprofesor.Size = New System.Drawing.Size(315, 27)
        Me.tbprofesor.TabIndex = 256
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(37, 311)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX6.Size = New System.Drawing.Size(66, 19)
        Me.LabelX6.TabIndex = 257
        Me.LabelX6.Text = "Profesor:"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(38, 265)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX5.Size = New System.Drawing.Size(61, 19)
        Me.LabelX5.TabIndex = 254
        Me.LabelX5.Text = "Gestion:"
        '
        'btcbgestion
        '
        Me.btcbgestion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btcbgestion.BackColor = System.Drawing.Color.Transparent
        Me.btcbgestion.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btcbgestion.Image = Global.DinoM.My.Resources.Resources.add
        Me.btcbgestion.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btcbgestion.Location = New System.Drawing.Point(428, 265)
        Me.btcbgestion.Margin = New System.Windows.Forms.Padding(4)
        Me.btcbgestion.Name = "btcbgestion"
        Me.btcbgestion.Size = New System.Drawing.Size(37, 28)
        Me.btcbgestion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btcbgestion.TabIndex = 255
        Me.btcbgestion.Visible = False
        '
        'cbgestion
        '
        Me.cbgestion.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cbgestion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        cbgestion_DesignTimeLayout.LayoutString = resources.GetString("cbgestion_DesignTimeLayout.LayoutString")
        Me.cbgestion.DesignTimeLayout = cbgestion_DesignTimeLayout
        Me.cbgestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbgestion.Location = New System.Drawing.Point(228, 266)
        Me.cbgestion.Margin = New System.Windows.Forms.Padding(4)
        Me.cbgestion.Name = "cbgestion"
        Me.cbgestion.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbgestion.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbgestion.SelectedIndex = -1
        Me.cbgestion.SelectedItem = Nothing
        Me.cbgestion.Size = New System.Drawing.Size(192, 26)
        Me.cbgestion.TabIndex = 253
        Me.cbgestion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(38, 231)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX4.Size = New System.Drawing.Size(65, 19)
        Me.LabelX4.TabIndex = 251
        Me.LabelX4.Text = "Paralelo:"
        '
        'btcbparalelo
        '
        Me.btcbparalelo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btcbparalelo.BackColor = System.Drawing.Color.Transparent
        Me.btcbparalelo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btcbparalelo.Image = Global.DinoM.My.Resources.Resources.add
        Me.btcbparalelo.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btcbparalelo.Location = New System.Drawing.Point(428, 231)
        Me.btcbparalelo.Margin = New System.Windows.Forms.Padding(4)
        Me.btcbparalelo.Name = "btcbparalelo"
        Me.btcbparalelo.Size = New System.Drawing.Size(37, 28)
        Me.btcbparalelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btcbparalelo.TabIndex = 252
        Me.btcbparalelo.Visible = False
        '
        'cbparalelo
        '
        Me.cbparalelo.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cbparalelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        cbparalelo_DesignTimeLayout.LayoutString = resources.GetString("cbparalelo_DesignTimeLayout.LayoutString")
        Me.cbparalelo.DesignTimeLayout = cbparalelo_DesignTimeLayout
        Me.cbparalelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbparalelo.Location = New System.Drawing.Point(228, 232)
        Me.cbparalelo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbparalelo.Name = "cbparalelo"
        Me.cbparalelo.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbparalelo.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbparalelo.SelectedIndex = -1
        Me.cbparalelo.SelectedItem = Nothing
        Me.cbparalelo.Size = New System.Drawing.Size(192, 26)
        Me.cbparalelo.TabIndex = 250
        Me.cbparalelo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(38, 195)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX3.Size = New System.Drawing.Size(50, 19)
        Me.LabelX3.TabIndex = 248
        Me.LabelX3.Text = "Grado:"
        '
        'btcbgrado
        '
        Me.btcbgrado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btcbgrado.BackColor = System.Drawing.Color.Transparent
        Me.btcbgrado.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btcbgrado.Image = Global.DinoM.My.Resources.Resources.add
        Me.btcbgrado.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btcbgrado.Location = New System.Drawing.Point(428, 195)
        Me.btcbgrado.Margin = New System.Windows.Forms.Padding(4)
        Me.btcbgrado.Name = "btcbgrado"
        Me.btcbgrado.Size = New System.Drawing.Size(37, 28)
        Me.btcbgrado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btcbgrado.TabIndex = 249
        Me.btcbgrado.Visible = False
        '
        'cbgrado
        '
        Me.cbgrado.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cbgrado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        cbgrado_DesignTimeLayout.LayoutString = resources.GetString("cbgrado_DesignTimeLayout.LayoutString")
        Me.cbgrado.DesignTimeLayout = cbgrado_DesignTimeLayout
        Me.cbgrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbgrado.Location = New System.Drawing.Point(228, 196)
        Me.cbgrado.Margin = New System.Windows.Forms.Padding(4)
        Me.cbgrado.Name = "cbgrado"
        Me.cbgrado.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbgrado.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbgrado.SelectedIndex = -1
        Me.cbgrado.SelectedItem = Nothing
        Me.cbgrado.Size = New System.Drawing.Size(192, 26)
        Me.cbgrado.TabIndex = 247
        Me.cbgrado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbgrupo1
        '
        Me.lbgrupo1.AutoSize = True
        Me.lbgrupo1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbgrupo1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbgrupo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbgrupo1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbgrupo1.Location = New System.Drawing.Point(38, 154)
        Me.lbgrupo1.Margin = New System.Windows.Forms.Padding(4)
        Me.lbgrupo1.Name = "lbgrupo1"
        Me.lbgrupo1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbgrupo1.Size = New System.Drawing.Size(42, 19)
        Me.lbgrupo1.TabIndex = 245
        Me.lbgrupo1.Text = "Nivel:"
        '
        'btcbnivel
        '
        Me.btcbnivel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btcbnivel.BackColor = System.Drawing.Color.Transparent
        Me.btcbnivel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btcbnivel.Image = Global.DinoM.My.Resources.Resources.add
        Me.btcbnivel.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btcbnivel.Location = New System.Drawing.Point(428, 154)
        Me.btcbnivel.Margin = New System.Windows.Forms.Padding(4)
        Me.btcbnivel.Name = "btcbnivel"
        Me.btcbnivel.Size = New System.Drawing.Size(37, 28)
        Me.btcbnivel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btcbnivel.TabIndex = 246
        Me.btcbnivel.Visible = False
        '
        'cbnivel
        '
        Me.cbnivel.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cbnivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        cbnivel_DesignTimeLayout.LayoutString = resources.GetString("cbnivel_DesignTimeLayout.LayoutString")
        Me.cbnivel.DesignTimeLayout = cbnivel_DesignTimeLayout
        Me.cbnivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbnivel.Location = New System.Drawing.Point(228, 155)
        Me.cbnivel.Margin = New System.Windows.Forms.Padding(4)
        Me.cbnivel.Name = "cbnivel"
        Me.cbnivel.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbnivel.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbnivel.SelectedIndex = -1
        Me.cbnivel.SelectedItem = Nothing
        Me.cbnivel.Size = New System.Drawing.Size(192, 26)
        Me.cbnivel.TabIndex = 4
        Me.cbnivel.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(38, 37)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(56, 19)
        Me.LabelX1.TabIndex = 234
        Me.LabelX1.Text = "Código:"
        '
        'tbCodigo
        '
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbCodigo.Location = New System.Drawing.Point(228, 37)
        Me.tbCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.Size = New System.Drawing.Size(84, 27)
        Me.tbCodigo.TabIndex = 0
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(37, 75)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX2.Size = New System.Drawing.Size(89, 19)
        Me.LabelX2.TabIndex = 235
        Me.LabelX2.Text = "Descripcion:"
        '
        'tbdescripcion
        '
        '
        '
        '
        Me.tbdescripcion.Border.Class = "TextBoxBorder"
        Me.tbdescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbdescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbdescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbdescripcion.Location = New System.Drawing.Point(228, 75)
        Me.tbdescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.tbdescripcion.MaxLength = 15
        Me.tbdescripcion.Multiline = True
        Me.tbdescripcion.Name = "tbdescripcion"
        Me.tbdescripcion.PreventEnterBeep = True
        Me.tbdescripcion.Size = New System.Drawing.Size(258, 62)
        Me.tbdescripcion.TabIndex = 1
        '
        'swEstado
        '
        '
        '
        '
        Me.swEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swEstado.Location = New System.Drawing.Point(228, 353)
        Me.swEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.swEstado.Name = "swEstado"
        Me.swEstado.OffBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.swEstado.OffText = "PASIVO"
        Me.swEstado.OffTextColor = System.Drawing.Color.White
        Me.swEstado.OnBackColor = System.Drawing.Color.Blue
        Me.swEstado.OnText = "ACTIVO"
        Me.swEstado.OnTextColor = System.Drawing.Color.White
        Me.swEstado.Size = New System.Drawing.Size(181, 27)
        Me.swEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swEstado.TabIndex = 9
        Me.swEstado.Value = True
        Me.swEstado.ValueObject = "Y"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX9.Location = New System.Drawing.Point(38, 351)
        Me.LabelX9.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX9.Size = New System.Drawing.Size(105, 28)
        Me.LabelX9.TabIndex = 238
        Me.LabelX9.Text = "Estado:"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Panel2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Location = New System.Drawing.Point(832, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(415, 418)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 22
        Me.GroupPanel2.Text = "MATERIAS"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdetalle_telefono)
        Me.Panel2.Controls.Add(Me.PanelDatosTelefono)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(409, 393)
        Me.Panel2.TabIndex = 0
        '
        'grdetalle_telefono
        '
        Me.grdetalle_telefono.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdetalle_telefono.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdetalle_telefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdetalle_telefono.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid
        Me.grdetalle_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdetalle_telefono.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdetalle_telefono.Location = New System.Drawing.Point(0, 102)
        Me.grdetalle_telefono.Name = "grdetalle_telefono"
        Me.grdetalle_telefono.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grdetalle_telefono.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grdetalle_telefono.Size = New System.Drawing.Size(409, 291)
        Me.grdetalle_telefono.TabIndex = 1
        Me.grdetalle_telefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        Me.grdetalle_telefono.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelDatosTelefono
        '
        Me.PanelDatosTelefono.Controls.Add(Me.tbmateria)
        Me.PanelDatosTelefono.Controls.Add(Me.LabelX7)
        Me.PanelDatosTelefono.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDatosTelefono.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatosTelefono.Name = "PanelDatosTelefono"
        Me.PanelDatosTelefono.Size = New System.Drawing.Size(409, 102)
        Me.PanelDatosTelefono.TabIndex = 0
        '
        'tbmateria
        '
        '
        '
        '
        Me.tbmateria.Border.Class = "TextBoxBorder"
        Me.tbmateria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbmateria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbmateria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbmateria.Location = New System.Drawing.Point(125, 49)
        Me.tbmateria.Margin = New System.Windows.Forms.Padding(4)
        Me.tbmateria.Name = "tbmateria"
        Me.tbmateria.PreventEnterBeep = True
        Me.tbmateria.Size = New System.Drawing.Size(190, 27)
        Me.tbmateria.TabIndex = 0
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX7.Location = New System.Drawing.Point(55, 49)
        Me.LabelX7.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX7.Size = New System.Drawing.Size(59, 19)
        Me.LabelX7.TabIndex = 250
        Me.LabelX7.Text = "Materia:"
        '
        'F1_curso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 953)
        Me.Name = "F1_curso"
        Me.Text = "F1_curso"
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelToolBar2.ResumeLayout(False)
        Me.MPanelSup.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cbgestion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbparalelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbgrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbnivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdetalle_telefono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosTelefono.ResumeLayout(False)
        Me.PanelDatosTelefono.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbgrupo1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btcbnivel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbnivel As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbdescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents swEstado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdetalle_telefono As Janus.Windows.GridEX.GridEX
    Friend WithEvents PanelDatosTelefono As Panel
    Friend WithEvents tbmateria As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbprofesor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btcbgestion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbgestion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btcbparalelo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbparalelo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btcbgrado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbgrado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
