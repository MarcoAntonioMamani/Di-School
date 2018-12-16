Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Public Class F1_Profesor
#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
#End Region
#Region "Metodos Privados"
    Public Sub _prIniciarTodo()
        Me.Text = "PROFESORES"
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        _prMaxLength()
        _prCargarComboLibreria(cbtipodoc, 5, 2)
        _prAsignarPermisos()
        _PMIniciarTodo()


        Dim blah As New Bitmap(New Bitmap(My.Resources.profesore_icono), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico


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
        tbtelefono.MaxLength = 20
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
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes Titulares\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Titulares\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Titulares") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Titulares")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Titulares") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Titulares")

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


        tbemail.ReadOnly = False
        tbnombre.ReadOnly = False
        tbapellido_materno.ReadOnly = False
        tbapellido_paterno.ReadOnly = False
        tbdireccion.ReadOnly = False
        swEstado.IsReadOnly = False
        tbnrodoc.ReadOnly = False
        cbtipodoc.ReadOnly = False
        tbFechaCompra.IsInputReadOnly = False

        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()
        If (CType(cbtipodoc.DataSource, DataTable).Rows.Count > 0) Then
            cbtipodoc.SelectedIndex = 0
        End If

        btnImprimir.Visible = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()


        tbCodigo.ReadOnly = True
        tbemail.ReadOnly = True
        tbnombre.ReadOnly = True
        tbapellido_materno.ReadOnly = True
        tbapellido_paterno.ReadOnly = True
        tbdireccion.ReadOnly = True
        swEstado.IsReadOnly = True
        tbnrodoc.ReadOnly = True

        cbtipodoc.ReadOnly = True
        tbFechaCompra.IsInputReadOnly = True

        JGrM_Buscador.Focus()
        Limpiar = False
        btnImprimir.Visible = True

    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbCodigo.Clear()
        tbnombre.Clear()
        tbapellido_materno.Clear()
        tbapellido_paterno.Clear()
        tbnrodoc.Clear()
        tbemail.Clear()
        tbdireccion.Clear()
        tbFechaCompra.Value = Now.Date
        swEstado.Value = True
        tbemail.Clear()

        tbnombre.Focus()

        If (CType(cbtipodoc.DataSource, DataTable).Rows.Count > 0) Then
            cbtipodoc.SelectedIndex = 0
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

        Dim res As Boolean = L_fnGrabarProfesor(tbCodigo.Text, cbtipodoc.Value, tbnrodoc.Text, tbnombre.Text, tbapellido_paterno.Text, tbapellido_materno.Text, tbtelefono.Text, tbdireccion.Text, tbemail.Text, tbFechaCompra.Value.ToString("yyyy/MM/dd"), IIf(swEstado.Value = True, 1, 0))


        If res Then
            Modificado = False
            '_fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Titulares", nameImg)
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Profesor ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbCodigo.Focus()
            Limpiar = True
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Profesor no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean
        'ByRef _ponumi As String, _potipdoc As String,
        '                                      _ponrodoc As String, _ponombre As String,
        '                                      _poapellido_p As String, _poapellido_m As String, _potelf As String, _podirecc As String,
        '                                      _poemail As String, _pofnac As String, _poestado As Integer

        res = L_fnModificarProfesor(tbCodigo.Text, cbtipodoc.Value, tbnrodoc.Text, tbnombre.Text, tbapellido_paterno.Text, tbapellido_materno.Text, tbtelefono.Text, tbdireccion.Text, tbemail.Text, tbFechaCompra.Value.ToString("yyyy/MM/dd"), IIf(swEstado.Value = True, 1, 0))

        If res Then

            If (Modificado = True) Then
                '_fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Titulares", nameImg)
                Modificado = False
            End If
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Profesor ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "EL Profesor no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

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
            Dim res As Boolean = L_fnEliminarProfesor(tbCodigo.Text, mensajeError)
            If res Then


                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Profesor ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
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
        Dim dtBuscador As DataTable = L_fnGeneralProfesor()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        'a.ponumi , a.potipdoc, libreria.ycdes3 As documento, a.ponrodoc,
        'concat(ponombre,' ',poapellido_p ,' ',poapellido_m )as nombre,a.podireccion,a.potelefono   ,
        'a.poemail, a.pofnac, a.poestado, a.pofact, a.pohact, a.pouact, a.ponombre, a.poapellido_p, a.poapellido_m 
        listEstCeldas.Add(New Modelo.Celda("ponumi", True, "Código".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("potipdoc", False))
        listEstCeldas.Add(New Modelo.Celda("documento", True, "Tipo Documento".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("ponrodoc", True, "Nro Documento".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("ponombre", False))
        listEstCeldas.Add(New Modelo.Celda("poapellido_p", False))
        listEstCeldas.Add(New Modelo.Celda("poapellido_m", False))
        listEstCeldas.Add(New Modelo.Celda("nombre", True, "NOMBRE PROFESOR".ToUpper, 220))
        listEstCeldas.Add(New Modelo.Celda("podireccion", True, "DIRECCION", 150))
        listEstCeldas.Add(New Modelo.Celda("pofnac", False))
        listEstCeldas.Add(New Modelo.Celda("estado", True, "Estado".ToUpper, 100))
        listEstCeldas.Add(New Modelo.Celda("poestado", False))
        listEstCeldas.Add(New Modelo.Celda("pofact", False))
        listEstCeldas.Add(New Modelo.Celda("potelefono", True, "TELEFONO", 120))
        listEstCeldas.Add(New Modelo.Celda("pohact", False))
        listEstCeldas.Add(New Modelo.Celda("pouact", False))
        listEstCeldas.Add(New Modelo.Celda("poemail", False))


        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        '  @ponumi ,@potipdoc ,@ponrodoc ,@ponombre ,@poapellido_p ,@poapellido_m 
        ',@potelefono ,@poemail ,@podireccion  ,@pofnac ,@poestado 
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
        Try
            tbCodigo.Text = JGrM_Buscador.GetValue("ponumi").ToString
        Catch ex As Exception
            Exit Sub
        End Try
        With JGrM_Buscador
            tbCodigo.Text = .GetValue("ponumi").ToString
            tbnombre.Text = .GetValue("ponombre").ToString
            tbapellido_paterno.Text = .GetValue("poapellido_p").ToString
            tbapellido_materno.Text = .GetValue("poapellido_m").ToString
            tbemail.Text = .GetValue("poemail").ToString
            cbtipodoc.Value = .GetValue("potipdoc")
            tbtelefono.Text = .GetValue("potelefono")
            tbdireccion.Text = .GetValue("podireccion")
            tbFechaCompra.Value = .GetValue("pofnac")
            tbnrodoc.Text = .GetValue("ponrodoc")
            swEstado.Value = .GetValue("poestado")
            lbFecha.Text = CType(.GetValue("pofact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("pohact").ToString
            lbUsuario.Text = .GetValue("pouact").ToString

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

    Private Sub F1_Profesor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub
End Class