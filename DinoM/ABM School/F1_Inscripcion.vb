Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls

Public Class F1_Inscripcion



#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Dim _IdCurso As Integer = 0
    Dim _IdAlumno As Integer = 0
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
#End Region
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()

        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        _prMaxLength()
        _prCargarComboLibreria(cbnivel, 7, 3)
        _prCargarComboLibreria(cbgrado, 7, 2)
        _prCargarComboLibreria(cbparalelo, 7, 4)
        _prCargarComboLibreria(cbgestion, 7, 1)
        _prCargarComboLibreria(cbconcepto, 8, 1)
        _prAsignarPermisos()
        _PMIniciarTodo()
        SuperTabControl1.SelectedTabIndex = 0

        Dim blah As New Bitmap(New Bitmap(My.Resources.cursos), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        Me.Text = "INSCRIPCION"
    End Sub

    Private Sub _prCargarDetalleMaterias(_numi As String)
        Dim dt As New DataTable

        dt = L_fnGeneralInscripcionMaterias(_numi)
        grdetalle_materia.DataSource = dt
        grdetalle_materia.RetrieveStructure()
        grdetalle_materia.AlternatingColors = True
        '    a.itnumi , a.itis001, a.itma001, materia.manombre As materia, materia.maespecial As especial,
        'Cast(a.itestado As bit) As estado2 ,1 As estado
        With grdetalle_materia.RootTable.Columns("itnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grdetalle_materia.RootTable.Columns("itis001")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_materia.RootTable.Columns("itma001")
            .Width = 150
            .Visible = True
            .Caption = "Codigo Materia"
        End With
        With grdetalle_materia.RootTable.Columns("materia")
            .Width = 250
            .Visible = True
            .Caption = "Nombre Materia"
        End With
        With grdetalle_materia.RootTable.Columns("especial")
            .Width = 120
            .Visible = False
            .Caption = "Es Especial?"
        End With
        With grdetalle_materia.RootTable.Columns("estado2")
            .Width = 120
            .Visible = True
            .Caption = "Estado"
        End With
        With grdetalle_materia.RootTable.Columns("estado")
            .Width = 90
            .Visible = False
        End With


        With grdetalle_materia
            .GroupByBoxVisible = False
            'diseño de la grilla
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .VisualStyle = VisualStyle.Office2007
        End With

        _prAplicarCondiccionJanusSinLote()
    End Sub

    Private Sub _prCargarDetalleMateriasAyuda(_numi As String)
        Dim dt As New DataTable

        dt = L_fnGeneralInscripcionMateriasAyuda(_numi)
        grdetalle_materia.DataSource = dt
        grdetalle_materia.RetrieveStructure()
        grdetalle_materia.AlternatingColors = True
        '    a.itnumi , a.itis001, a.itma001, materia.manombre As materia, materia.maespecial As especial,
        'Cast(a.itestado As bit) As estado2 ,1 As estado
        With grdetalle_materia.RootTable.Columns("itnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grdetalle_materia.RootTable.Columns("itis001")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_materia.RootTable.Columns("itma001")
            .Width = 150
            .Visible = True
            .Caption = "Codigo Materia"
        End With
        With grdetalle_materia.RootTable.Columns("materia")
            .Width = 250
            .Visible = True
            .Caption = "Nombre Materia"
        End With
        With grdetalle_materia.RootTable.Columns("especial")
            .Width = 120
            .Visible = False
            .Caption = "Es Especial?"
        End With
        With grdetalle_materia.RootTable.Columns("estado2")
            .Width = 120
            .Visible = True
            .Caption = "Estado"
        End With
        With grdetalle_materia.RootTable.Columns("estado")
            .Width = 90
            .Visible = False
        End With


        With grdetalle_materia
            .GroupByBoxVisible = False
            'diseño de la grilla
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .VisualStyle = VisualStyle.Office2007
        End With

        _prAplicarCondiccionJanusSinLote()
    End Sub

    Public Sub _prAplicarCondiccionJanusSinLote()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grdetalle_materia.RootTable.Columns("estado2"), ConditionOperator.Equal, 1)
        fc.FormatStyle.FontBold = TriState.True
        fc.FormatStyle.ForeColor = Color.White
        fc.FormatStyle.BackColor = Color.DodgerBlue

        grdetalle_materia.RootTable.FormatConditions.Add(fc)
    End Sub


    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(grdetalle_materia.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grdetalle_materia.DataSource, DataTable).Rows(i).Item("itnumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub





    Public Sub _prStyleJanus()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub

    Public Sub _prMaxLength()
        tbdescripcion.MaxLength = 150
        cbnivel.MaxLength = 40
        cbgrado.MaxLength = 40
        cbparalelo.MaxLength = 40
        cbgestion.MaxLength = 40
        cbconcepto.MaxLength = 40

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



#End Region
#Region "METODOS SOBRECARGADOS"

    Public Overrides Sub _PMOHabilitar()


        tbdescripcion.ReadOnly = False
        cbgestion.ReadOnly = False
        cbparalelo.ReadOnly = False
        cbgrado.ReadOnly = False
        cbnivel.ReadOnly = False
        cbconcepto.ReadOnly = False
        tbFechaNac.IsInputReadOnly = False

        If (CType(cbgestion.DataSource, DataTable).Rows.Count > 0) Then
            cbgestion.SelectedIndex = 0
        End If
        If (CType(cbparalelo.DataSource, DataTable).Rows.Count > 0) Then
            cbparalelo.SelectedIndex = 0
        End If
        If (CType(cbgrado.DataSource, DataTable).Rows.Count > 0) Then
            cbgrado.SelectedIndex = 0
        End If
        If (CType(cbnivel.DataSource, DataTable).Rows.Count > 0) Then
            cbnivel.SelectedIndex = 0
        End If
        If (CType(cbconcepto.DataSource, DataTable).Rows.Count > 0) Then
            cbconcepto.SelectedIndex = 0
        End If
        tbalumno.Focus()
        btnImprimir.Visible = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()


        tbCodigo.ReadOnly = True
        tbdescripcion.ReadOnly = True
        cbgestion.ReadOnly = True
        cbparalelo.ReadOnly = True
        cbgrado.ReadOnly = True
        cbnivel.ReadOnly = True
        cbconcepto.ReadOnly = True
        tbFechaNac.IsInputReadOnly = True
        JGrM_Buscador.Focus()
        Limpiar = False
        btnImprimir.Visible = True
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbCodigo.Clear()
        tbdescripcion.Clear()
        _IdCurso = 0
        tbprofesor.Clear()
        tbalumno.Clear()
        _prCargarDetalleMaterias(-1)
        If (CType(cbgestion.DataSource, DataTable).Rows.Count > 0) Then
            cbgestion.SelectedIndex = 0
        End If
        If (CType(cbparalelo.DataSource, DataTable).Rows.Count > 0) Then
            cbparalelo.SelectedIndex = 0
        End If
        If (CType(cbgrado.DataSource, DataTable).Rows.Count > 0) Then
            cbgrado.SelectedIndex = 0
        End If
        If (CType(cbnivel.DataSource, DataTable).Rows.Count > 0) Then
            cbnivel.SelectedIndex = 0
        End If
        If (CType(cbconcepto.DataSource, DataTable).Rows.Count > 0) Then
            cbconcepto.SelectedIndex = 0
        End If
        tbFechaNac.Value = Now.Date
        tbalumno.Focus()
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
        tbdescripcion.BackColor = Color.White
        cbgestion.BackColor = Color.White
        cbgrado.BackColor = Color.White
        cbparalelo.BackColor = Color.White
        cbnivel.BackColor = Color.White


    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean

        'ByRef _isnumi As String, _isfecha As String,
        '                                    _isal001 As Integer, _iscu001 As Integer, _isparalelo As Integer,
        '                                    _isconcepto As Integer, _isdescripcion As String, _dt As DataTable

        Dim numi As String = ""

        Dim res As Boolean = L_fnGrabarInscripcion(numi, tbFechaNac.Value.ToString("yyyy/MM/dd"), _IdAlumno, _IdCurso, cbparalelo.Value, cbconcepto.Value, tbdescripcion.Text, CType(grdetalle_materia.DataSource, DataTable))


        If res Then
            Modificado = False
            '_fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Titulares", nameImg)
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Inscripcion ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbCodigo.Focus()
            Limpiar = True
            _IdCurso = 0
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Inscripcion no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean

        res = L_fnModificarInscripcion(tbCodigo.Text, tbFechaNac.Value.ToString("yyyy/MM/dd"), _IdAlumno, _IdCurso, cbparalelo.Value, cbconcepto.Value, tbdescripcion.Text, CType(grdetalle_materia.DataSource, DataTable))

        If res Then



            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Inscripcion ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Inscripcion no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        _PMInhabilitar()
        _PMPrimerRegistro()
        Return res
    End Function



    Public Function _fnActionNuevo() As Boolean
        Return tbCodigo.Text = String.Empty And tbdescripcion.ReadOnly = False
    End Function

    Public Function _fnActionAccesible() As Boolean
        Return tbdescripcion.ReadOnly = False
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
            Dim res As Boolean = L_fnEliminarInscripcion(tbCodigo.Text, mensajeError)
            If res Then


                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Inscripcion ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
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

        'If tbdescripcion.Text = String.Empty Then
        '    tbdescripcion.BackColor = Color.Red

        '    MEP.SetError(tbdescripcion, "ingrese nombre del descripcion!".ToUpper)
        '    _ok = False
        'Else
        '    tbdescripcion.BackColor = Color.White
        '    MEP.SetError(tbdescripcion, "")
        'End If

        If _IdCurso <= 0 Then
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "POR FAVOR SELECCIONE UN CURSO", img, 3000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            _ok = False

        End If
        If _IdAlumno <= 0 Then
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "POR FAVOR SELECCIONE UN ALUMNO", img, 3000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            _ok = False

        End If
        If cbconcepto.SelectedIndex < 0 Then
            cbconcepto.BackColor = Color.Red

            MEP.SetError(cbconcepto, "Seleccione un concepto!".ToUpper)
            _ok = False
        Else
            cbconcepto.BackColor = Color.White
            MEP.SetError(cbconcepto, "")
        End If


        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_fnGeneralInscripion()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        '     a.isnumi, a.isfecha , a.isal001, a.iscu001,alumno, b.cugrado, Upper(grado.ycdes3)As grado , a.isparalelo, Upper(paralelo.ycdes3)as paralelo 
        ',b.cunivel ,Upper(nivel.ycdes3 ) as nivel,b.cugestion ,Upper(gestion .ycdes3 )as gestion,a.isconcepto
        ' ,a.isdescripcion ,a.isfact ,a.ishact ,a.isuact 
        listEstCeldas.Add(New Modelo.Celda("isnumi", True, "Código".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("isfecha", True, "Fecha".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("isal001", False))
        listEstCeldas.Add(New Modelo.Celda("iscu001", False))
        listEstCeldas.Add(New Modelo.Celda("alumno", True, "Alumno".ToUpper, 400))
        listEstCeldas.Add(New Modelo.Celda("titular", True, "Titular".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("cugrado", False))
        listEstCeldas.Add(New Modelo.Celda("grado", True, "Grado".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("isparalelo", False))
        listEstCeldas.Add(New Modelo.Celda("paralelo", False, "paralelo".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("cunivel", False))
        listEstCeldas.Add(New Modelo.Celda("nivel", True, "nivel".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("cugestion", False))
        listEstCeldas.Add(New Modelo.Celda("gestion", True, "gestion".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("isconcepto", False))
        listEstCeldas.Add(New Modelo.Celda("isdescripcion", False))
        listEstCeldas.Add(New Modelo.Celda("isfact", False))
        listEstCeldas.Add(New Modelo.Celda("ishact", False))
        listEstCeldas.Add(New Modelo.Celda("isuact", False))


        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        '     a.isnumi, a.isfecha , a.isal001, a.iscu001,alumno, b.cugrado, Upper(grado.ycdes3)As grado , a.isparalelo, Upper(paralelo.ycdes3)as paralelo 
        ',b.cunivel ,Upper(nivel.ycdes3 ) as nivel,b.cugestion ,Upper(gestion .ycdes3 )as gestion,a.isconcepto
        ' ,a.isdescripcion ,a.isfact ,a.ishact ,a.isuact 
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
        Try
            tbCodigo.Text = JGrM_Buscador.GetValue("isnumi").ToString
        Catch ex As Exception
            Exit Sub
        End Try
        With JGrM_Buscador
            tbCodigo.Text = .GetValue("isnumi").ToString
            tbdescripcion.Text = .GetValue("isdescripcion").ToString
            cbnivel.Value = .GetValue("cunivel")
            cbgrado.Value = .GetValue("cugrado")
            cbparalelo.Value = .GetValue("isparalelo")
            cbgestion.Value = .GetValue("cugestion")
            tbFechaNac.Value = .GetValue("isfecha")
            _IdCurso = .GetValue("iscu001")
            _IdAlumno = .GetValue("isal001")
            tbalumno.Text = .GetValue("alumno").ToString
            tbprofesor.Text = .GetValue("titular").ToString
            cbconcepto.Value = .GetValue("isconcepto")
            lbFecha.Text = CType(.GetValue("isfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("ishact").ToString
            lbUsuario.Text = .GetValue("isuact").ToString
            _prCargarDetalleMaterias(.GetValue("isnumi").ToString)
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

    Private Sub cbconcepto_ValueChanged(sender As Object, e As EventArgs) Handles cbconcepto.ValueChanged
        If cbconcepto.SelectedIndex < 0 And cbconcepto.Text <> String.Empty Then
            btcbconcepto.Visible = True
        Else
            btcbconcepto.Visible = False
        End If
    End Sub

    Private Sub btcbconcepto_Click(sender As Object, e As EventArgs) Handles btcbconcepto.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "8", "1", cbconcepto.Text, "") Then
            _prCargarComboLibreria(cbconcepto, "8", "1")
            cbconcepto.SelectedIndex = CType(cbconcepto.DataSource, DataTable).Rows.Count - 1
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

    Private Sub tbalumno_KeyDown(sender As Object, e As KeyEventArgs) Handles tbalumno.KeyDown
        If (_fnActionAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable
                dt = L_fnGeneralAlumnoCurso()
                '        a.alnumi, alrude, libreria.ycdes3 As documento, a.alnrodoc,
                'concat(alnombre,' ',alapellido_p ,' ',alapellido_m )as nombre,aldirec ,alfnac ,altelf

                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("alnumi", True, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("alrude", True, "Rude", 80))
                listEstCeldas.Add(New Modelo.Celda("documento", True, "Tipo Documento", 100))
                listEstCeldas.Add(New Modelo.Celda("alnrodoc", True, "Nro Documento", 100))
                listEstCeldas.Add(New Modelo.Celda("nombre", True, "Nombre Alumno", 220))
                listEstCeldas.Add(New Modelo.Celda("aldirec", True, "Direccion", 140))
                listEstCeldas.Add(New Modelo.Celda("alfnac", True, "F.Nacimiento", 150, "MM/dd,YYYY"))
                listEstCeldas.Add(New Modelo.Celda("altelf", True, "Telefono", 120))

                Dim ef = New Efecto
                ef.tipo = 3
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione Alumno".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

                    _IdAlumno = Row.Cells("alnumi").Value
                    tbalumno.Text = Row.Cells("nombre").Value


                End If

            End If

        End If
    End Sub

    Private Sub tbprofesor_KeyDown(sender As Object, e As KeyEventArgs) Handles tbprofesor.KeyDown
        If (_fnActionAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable
                dt = L_fnGeneralCursoParalelo()
                '                a.cunumi , a.cugrado, UPPER(grado.ycdes3) As grado, a.cunivel, UPPER(nivel.ycdes3) As nivel,
                'a.cugestion , gestion.ycdes3 As gestion, paralelo.cbparalelo, UPPER(libreria.ycdes3) as paralelo
                ',a.cupo001 ,concat(profesor .ponombre ,' ',profesor .poapellido_p ,' ',profesor .poapellido_m )as profesor

                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("cunumi", True, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("cugrado", False, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("grado", True, "GRADO", 120))
                listEstCeldas.Add(New Modelo.Celda("cunivel", False, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("nivel", True, "NIVEL", 120))
                listEstCeldas.Add(New Modelo.Celda("cugestion", False, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("gestion", True, "GESTION", 120))
                listEstCeldas.Add(New Modelo.Celda("cbparalelo", False, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("paralelo", True, "PARALELO", 120))
                listEstCeldas.Add(New Modelo.Celda("cupo001", False, "Codigo", 50))

                listEstCeldas.Add(New Modelo.Celda("profesor", True, "TITULAR", 200))

                Dim ef = New Efecto
                ef.tipo = 3
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione Curso".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    '                a.cunumi , a.cugrado, UPPER(grado.ycdes3) As grado, a.cunivel, UPPER(nivel.ycdes3) As nivel,
                    'a.cugestion , gestion.ycdes3 As gestion, paralelo.cbparalelo, UPPER(libreria.ycdes3) as paralelo
                    ',a.cupo001 ,concat(profesor .ponombre ,' ',profesor .poapellido_p ,' ',profesor .poapellido_m )as profesor
                    _IdCurso = Row.Cells("cunumi").Value
                    tbprofesor.Text = Row.Cells("profesor").Value
                    cbparalelo.Value = Row.Cells("cbparalelo").Value
                    cbgrado.Value = Row.Cells("cugrado").Value
                    cbnivel.Value = Row.Cells("cunivel").Value
                    cbgestion.Value = Row.Cells("cugestion").Value
                    _prCargarDetalleMateriasAyuda(_IdCurso)
                End If

            End If

        End If
    End Sub

    Private Sub F1_Inscripcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub grdetalle_materia_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grdetalle_materia.EditingCell
        If (_fnActionAccesible()) Then
            'Habilitar solo las columnas de Precio, %, Monto y Observación
            'If (e.Column.Index = grdetalle.RootTable.Columns("yfcbarra").Index Or
            If (e.Column.Index = grdetalle_materia.RootTable.Columns("estado2").Index) Then
                e.Cancel = False

            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grdetalle_materia_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grdetalle_materia.CellEdited
        If (e.Column.Index = grdetalle_materia.RootTable.Columns("estado2").Index) Then


            grdetalle_materia.SetValue("estado", 1)



        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

    End Sub



#End Region

End Class