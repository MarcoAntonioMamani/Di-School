Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Public Class F1_Alumno

#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Dim Titular As Integer = 0
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
#End Region
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        Me.Text = "Alumno"
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        _prMaxLength()
        _prCargarComboLibreria(cbtipodoc, 5, 2)
        _prCargarComboLibreria(cbparentesco, 6, 1)
        _prAsignarPermisos()
        _PMIniciarTodo()


        Dim blah As New Bitmap(New Bitmap(My.Resources.cliente), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico

    End Sub

    Private Sub _prCargarDetalleTelefono(_numi As String)
        Dim dt As New DataTable

        dt = L_fnDetalleTitularAlumno(_numi)
        grdetalle_telefono.DataSource = dt
        grdetalle_telefono.RetrieveStructure()
        grdetalle_telefono.AlternatingColors = True
        '    detalle.amnumi , detalle.amal001, detalle.amtit001, concat(Titular.tinombre,' ',titular .tiapellido_p ,' ',titular .tiapellido_m )as titular
        ', detalle.amparentesco, libreria.ycdes3 As parentesco,'' as celular,1 as estado,cast('' as image) as img
        With grdetalle_telefono.RootTable.Columns("amnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("amal001")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("amtit001")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("titular")
            .Width = 400
            .Visible = True
            .Caption = "NOMBRE TITULAR"
        End With
        With grdetalle_telefono.RootTable.Columns("amparentesco")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("parentesco")
            .Width = 150
            .Visible = True
            .Caption = "PARENTESCO"
        End With
        With grdetalle_telefono.RootTable.Columns("celular")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("estado")
            .Width = 90
            .Visible = False
        End With

        If (_fnActionAccesible()) Then

            With grdetalle_telefono.RootTable.Columns("img")
                .Width = 120
                .Caption = ""
                .Visible = True
            End With
        Else
            With grdetalle_telefono.RootTable.Columns("img")
                .Width = 120
                .Caption = ""
                .Visible = False
            End With
        End If



        With grdetalle_telefono
            .GroupByBoxVisible = False
            'diseño de la grilla
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .VisualStyle = VisualStyle.Office2007
        End With
        _prCargarIconELiminar()

    End Sub

    Public Sub _prCargarIconELiminar()

        For i As Integer = 0 To CType(grdetalle_telefono.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)
            CType(grdetalle_telefono.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            'grdetalle_telefono.RootTable.Columns("img").Visible = True
        Next

    End Sub
    Private Sub grdetalle_telefono_MouseClick(sender As Object, e As MouseEventArgs) Handles grdetalle_telefono.MouseClick
        If (Not _fnActionAccesible()) Then
            Return
        End If

        If (grdetalle_telefono.RowCount >= 1 And Not IsNothing(grdetalle_telefono.CurrentColumn)) Then
            If (grdetalle_telefono.CurrentColumn.Index = grdetalle_telefono.RootTable.Columns("img").Index) Then
                _prEliminarFila()
            End If
        End If
    End Sub
    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(grdetalle_telefono.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grdetalle_telefono.DataSource, DataTable).Rows(i).Item("amnumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub
    Public Sub _prEliminarFila()
        If (grdetalle_telefono.Row >= 0) Then
            If (grdetalle_telefono.RowCount >= 1) Then
                Dim estado As Integer = grdetalle_telefono.GetValue("estado")
                Dim pos As Integer = -1
                Dim lin As Integer = grdetalle_telefono.GetValue("amnumi")
                _fnObtenerFilaDetalle(pos, lin)
                If (estado = 0) Then
                    CType(grdetalle_telefono.DataSource, DataTable).Rows(pos).Item("estado") = -2

                End If
                If (estado = 1) Then
                    CType(grdetalle_telefono.DataSource, DataTable).Rows(pos).Item("estado") = -1
                End If
                grdetalle_telefono.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grdetalle_telefono.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))

                grdetalle_telefono.Select()
                If (grdetalle_telefono.RowCount > 1) Then
                    grdetalle_telefono.Col = 4
                    grdetalle_telefono.Row = grdetalle_telefono.RowCount - 1
                End If


            End If
        End If


    End Sub

    Public Sub _prStyleJanus()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub

    Public Sub _prMaxLength()
        tbnombre.MaxLength = 60
        tbapellido_paterno.MaxLength = 50
        tbapellido_materno.MaxLength = 50
        tbnrodoc.MaxLength = 15
        tbdireccion.MaxLength = 150
        tbemail.MaxLength = 70
        cbtipodoc.MaxLength = 40
        cbparentesco.MaxLength = 40
        tbtitular.MaxLength = 150
    End Sub

    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneral(cod1, cod2)
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 70
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 200
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With

    End Sub
    Private Sub _prAsignarPermisos()

        Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then
            btnNuevo.Visible = False
        End If
        If modif = False Then
            btnModificar.Visible = False
        End If
        If del = False Then
            btnEliminar.Visible = False
        End If
    End Sub
    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
                'My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                'System.IO.Directory.CreateDirectory(RutaTemporal)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes Alumno\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Alumno\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Alumno") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Alumno")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Alumno") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Alumno")

                End If
            End If
        End If
    End Sub

    Private Sub _prCrearCarpetaReportes()
        Dim rutaDestino As String = RutaGlobal + "\Reporte\Reporte Productos\"

        If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Productos\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Reporte") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte")
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Productos") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte Productos")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Productos") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte Productos")

                End If
            End If
        End If
    End Sub

#End Region
#Region "METODOS SOBRECARGADOS"

    Public Overrides Sub _PMOHabilitar()
        cbparentesco.BackColor = Color.White
        MEP.SetError(cbparentesco, "")
        tbtitular.BackColor = Color.White
        MEP.SetError(tbtitular, "")

        tbemail.ReadOnly = False
        tbnombre.ReadOnly = False
        tbapellido_materno.ReadOnly = False
        tbapellido_paterno.ReadOnly = False
        tbdireccion.ReadOnly = False
        swEstado.IsReadOnly = False
        tbnrodoc.ReadOnly = False
        cbparentesco.ReadOnly = False
        cbtipodoc.ReadOnly = False
        tbFechaNac.IsInputReadOnly = False
        PanelDatosTelefono.Visible = True
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()
        If (CType(cbtipodoc.DataSource, DataTable).Rows.Count > 0) Then
            cbtipodoc.SelectedIndex = 0
        End If
        If (CType(cbparentesco.DataSource, DataTable).Rows.Count > 0) Then
            cbparentesco.SelectedIndex = 0
        End If

        grdetalle_telefono.RootTable.Columns("img").Visible = True
        btnImprimir.Visible = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()

        cbparentesco.BackColor = Color.White
        MEP.SetError(cbparentesco, "")
        tbtitular.BackColor = Color.White
        MEP.SetError(tbtitular, "")
        tbCodigo.ReadOnly = True
        tbemail.ReadOnly = True
        tbnombre.ReadOnly = True
        tbapellido_materno.ReadOnly = True
        tbapellido_paterno.ReadOnly = True
        tbdireccion.ReadOnly = True
        swEstado.IsReadOnly = True
        tbnrodoc.ReadOnly = True
        cbparentesco.ReadOnly = True
        cbtipodoc.ReadOnly = True
        tbtitular.ReadOnly = True
        tbFechaNac.IsInputReadOnly = True
        PanelDatosTelefono.Visible = False
        JGrM_Buscador.Focus()
        Limpiar = False
        btnImprimir.Visible = True
        Try
            grdetalle_telefono.RootTable.Columns("img").Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbCodigo.Clear()
        tbnombre.Clear()
        tbapellido_materno.Clear()
        tbapellido_paterno.Clear()
        tbtitular.Clear()
        tbnrodoc.Clear()
        tbemail.Clear()
        tbdireccion.Clear()
        tbFechaNac.Value = Now.Date
        swEstado.Value = True
        tbemail.Clear()
        Titular = 0
        tbnombre.Focus()
        _prCargarDetalleTelefono(-1)
        If (CType(cbtipodoc.DataSource, DataTable).Rows.Count > 0) Then
            cbtipodoc.SelectedIndex = 0
        End If
        If (CType(cbparentesco.DataSource, DataTable).Rows.Count > 0) Then
            cbparentesco.SelectedIndex = 0
        End If
    End Sub
    Public Sub _prSeleccionarCombo(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        If (CType(mCombo.DataSource, DataTable).Rows.Count > 0) Then
            mCombo.SelectedIndex = 0
        Else
            mCombo.SelectedIndex = -1
        End If
    End Sub


    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbnombre.BackColor = Color.White
        tbemail.BackColor = Color.White

    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean

        'ByRef _tinumi As String, _titipdoc As String,
        '                                      _tinrodoc As String, _tinombre As String,
        '                                      _tiapellido_p As String, _tiapellido_m As String, _tidirecc As String,
        '                                      _tiemail As String, _tifnac As String, _tiest As Integer, _dt As DataTable
        Dim numi As String = ""

        Dim res As Boolean = L_fnGrabarAlumno(tbCodigo.Text, cbtipodoc.Value, tbnrodoc.Text, tbrude.Text, tbnombre.Text, tbapellido_paterno.Text, tbapellido_materno.Text, tbtelefono.Text, tbdireccion.Text, tbemail.Text, tbFechaNac.Value.ToString("yyyy/MM/dd"), IIf(swEstado.Value = True, 1, 0), CType(grdetalle_telefono.DataSource, DataTable))


        If res Then
            Modificado = False
            '_fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Alumno", nameImg)
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Alumno ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbCodigo.Focus()
            Limpiar = True
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Titular no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean

        'ByRef _alnumi As String, _altipdoc As String,
        '                                      _alnrodoc As String, _alrude As String, _alnombre As String,
        '                                      _alapellido_p As String, _alapellido_m As String, _altelf As String, _aldirecc As String,
        '                                      _alemail As String, _alfnac As String, _alestado As Integer, _dt As DataTable


        res = L_fnModificarAlumno(tbCodigo.Text, cbtipodoc.Value, tbnrodoc.Text, tbrude.Text, tbnombre.Text, tbapellido_paterno.Text, tbapellido_materno.Text, tbtelefono.Text, tbdireccion.Text, tbemail.Text, tbFechaNac.Value.ToString("yyyy/MM/dd"), IIf(swEstado.Value = True, 1, 0), CType(grdetalle_telefono.DataSource, DataTable))

        If res Then

            If (Modificado = True) Then
                '_fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Alumno", nameImg)
                Modificado = False
            End If
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de ALumno ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "EL Titular no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        _PMInhabilitar()
        _PMPrimerRegistro()
        Return res
    End Function



    Public Function _fnActionNuevo() As Boolean
        Return tbCodigo.Text = String.Empty And tbnombre.ReadOnly = False
    End Function

    Public Function _fnActionAccesible() As Boolean
        Return tbnombre.ReadOnly = False
    End Function

    Public Overrides Sub _PMOEliminarRegistro()

        Dim ef = New Efecto


        ef.tipo = 2
        ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
        ef.Header = "mensaje principal".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_fnEliminarAlumno(tbCodigo.Text, mensajeError)
            If res Then


                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de ALumno ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)

                _PMFiltrar()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 3000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If


    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbnombre.Text = String.Empty Then
            tbnombre.BackColor = Color.Red

            MEP.SetError(tbnombre, "ingrese nombre del titular!".ToUpper)
            _ok = False
        Else
            tbnombre.BackColor = Color.White
            MEP.SetError(tbnombre, "")
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_fnGeneralAlumno()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        'a.alnumi, alrude, a.altipdoc, libreria.ycdes3 As documento, a.alnrodoc,
        'concat(alnombre,' ',alapellido_p ,' ',alapellido_m )as nombre,aldirec ,
        'alemail, alfnac, alestado, alfact, alhact, aluact, alnombre, alapellido_p, alapellido_m,altelf 
        listEstCeldas.Add(New Modelo.Celda("alnumi", True, "Código".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("alrude", True, "Nro Rude", 150))
        listEstCeldas.Add(New Modelo.Celda("altipdoc", False))
        listEstCeldas.Add(New Modelo.Celda("documento", True, "Tipo Documento".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("alnrodoc", True, "Nro Documento".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("alnombre", False))
        listEstCeldas.Add(New Modelo.Celda("alapellido_p", False))
        listEstCeldas.Add(New Modelo.Celda("alapellido_m", False))
        listEstCeldas.Add(New Modelo.Celda("nombre", True, "Nombre Alumno".ToUpper, 220))
        listEstCeldas.Add(New Modelo.Celda("aldirec", True, "Direccion".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("altelf", True, "Telelfono".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("alfnac", False))
        listEstCeldas.Add(New Modelo.Celda("alestado", False, "Estado".ToUpper, 100))
        listEstCeldas.Add(New Modelo.Celda("alfact", False))
        listEstCeldas.Add(New Modelo.Celda("alhact", False))
        listEstCeldas.Add(New Modelo.Celda("aluact", False))
        listEstCeldas.Add(New Modelo.Celda("alemail", False))


        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        'a.alnumi, alrude, a.altipdoc, libreria.ycdes3 As documento, a.alnrodoc,
        'concat(alnombre,' ',alapellido_p ,' ',alapellido_m )as nombre,aldirec ,
        'alemail, alfnac, alestado, alfact, alhact, aluact, alnombre, alapellido_p, alapellido_m,altelf 
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
        Try
            tbCodigo.Text = JGrM_Buscador.GetValue("alnumi").ToString
        Catch ex As Exception
            Exit Sub
        End Try
        With JGrM_Buscador
            tbCodigo.Text = .GetValue("alnumi").ToString
            tbnombre.Text = .GetValue("alnombre").ToString
            tbrude.Text = .GetValue("alrude").ToString
            tbtelefono.Text = .GetValue("altelf").ToString
            tbapellido_paterno.Text = .GetValue("alapellido_p").ToString
            tbapellido_materno.Text = .GetValue("alapellido_m").ToString
            tbemail.Text = .GetValue("alemail").ToString
            cbtipodoc.Value = .GetValue("altipdoc")
            tbdireccion.Text = .GetValue("aldirec")
            tbFechaNac.Value = .GetValue("alfnac")
            tbnrodoc.Text = .GetValue("alnrodoc")
            swEstado.Value = .GetValue("alestado")
            lbFecha.Text = CType(.GetValue("alfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("alhact").ToString
            lbUsuario.Text = .GetValue("aluact").ToString
            _prCargarDetalleTelefono(.GetValue("alnumi").ToString)
        End With

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub
    Public Overrides Sub _PMOHabilitarFocus()

        'With MHighlighterFocus
        '    .SetHighlightOnFocus(tbCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbCodProd, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbStockMinimo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbCodBarra, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        '    .SetHighlightOnFocus(tbDescPro, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbDescCort, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo2, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo3, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo4, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUMed, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(swEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUniVenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUnidMaxima, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbConversion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)


        'End With
    End Sub

#End Region


    Private Sub F1_Alumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btcbtip_Click(sender As Object, e As EventArgs) Handles btcbtip.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "5", "2", cbtipodoc.Text, "") Then
            _prCargarComboLibreria(cbtipodoc, "5", "2")
            cbtipodoc.SelectedIndex = CType(cbtipodoc.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub cbtipodoc_ValueChanged(sender As Object, e As EventArgs) Handles cbtipodoc.ValueChanged
        If cbtipodoc.SelectedIndex < 0 And cbtipodoc.Text <> String.Empty Then
            btcbtip.Visible = True
        Else
            btcbtip.Visible = False
        End If
    End Sub

    Private Sub bttipo_Click(sender As Object, e As EventArgs) Handles bttipo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "6", "1", cbparentesco.Text, "") Then
            _prCargarComboLibreria(cbparentesco, "6", "1")
            cbparentesco.SelectedIndex = CType(cbparentesco.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub


    Function _fnvalidardatos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()
        If tbtitular.Text = String.Empty Then
            tbtitular.BackColor = Color.Red

            MEP.SetError(tbtitular, "Seleccione un Titular!".ToUpper)

        Else
            tbtitular.BackColor = Color.White
            MEP.SetError(tbtitular, "")
        End If

        If cbparentesco.SelectedIndex <= 0 Then
            cbparentesco.BackColor = Color.Red

            MEP.SetError(cbparentesco, "seleccione un parentesco!".ToUpper)

        Else
            cbparentesco.BackColor = Color.White
            MEP.SetError(cbparentesco, "")
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If (_fnvalidardatos() = True) Then
            tbtitular.BackColor = Color.White
            MEP.SetError(tbtitular, "")
            cbparentesco.BackColor = Color.White
            MEP.SetError(cbparentesco, "")
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)
            '           'detalle.amnumi ,detalle .amal001 ,detalle.amtit001,concat(titular .tinombre ,' ',titular .tiapellido_p ,' ',titular .tiapellido_m )as titular
            ',detalle .amparentesco ,libreria .ycdes3 as parentesco,'' as celular,1 as estado,cast('' as image) as img
            CType(grdetalle_telefono.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, Titular, tbtitular.Text, cbparentesco.Value, cbparentesco.Text, "", 0, Bin.GetBuffer)

            tbtitular.Clear()
            Titular = 0
        End If
    End Sub

    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(grdetalle_telefono.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("amnumi=MAX(amnumi)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("amnumi")
        End If
        Return 1
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If btnGrabar.Enabled = True Then
            _PMInhabilitar()
            _PMPrimerRegistro()

        Else
            '  Public _modulo As SideNavItem
            _modulo.Select()
            _tab.Close()
        End If
    End Sub

    Private Sub cbparentesco_ValueChanged(sender As Object, e As EventArgs) Handles cbparentesco.ValueChanged
        If cbparentesco.SelectedIndex < 0 And cbparentesco.Text <> String.Empty Then
            bttipo.Visible = True
        Else
            bttipo.Visible = False
        End If
    End Sub

    Private Sub tbtitular_KeyDown(sender As Object, e As KeyEventArgs) Handles tbtitular.KeyDown
        If (_fnActionAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnMostrarTitulares()


                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("tinumi,", True, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("tinrodoc", True, "Nro Documento", 100))
                listEstCeldas.Add(New Modelo.Celda("nombre", True, "Nombre Titular", 280))
                listEstCeldas.Add(New Modelo.Celda("tidirecc", True, "Direccion", 220))
                listEstCeldas.Add(New Modelo.Celda("tiemail", True, "Email", 200))
                listEstCeldas.Add(New Modelo.Celda("tifnac", True, "F.Nacimiento", 150, "MM/dd,YYYY"))
                Dim ef = New Efecto
                ef.tipo = 3
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione Titular".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

                    Titular = Row.Cells("tinumi").Value
                    tbtitular.Text = Row.Cells("nombre").Value


                End If

            End If

        End If


    End Sub
End Class