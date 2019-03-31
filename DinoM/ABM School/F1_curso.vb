Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Public Class F1_curso


#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Dim _IdProfesor As Integer = 0
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
        _prCargarComboProfesores(cbtutor)
        _prAsignarPermisos()
        _PMIniciarTodo()
        SuperTabControl1.SelectedTabIndex = 0

        Dim blah As New Bitmap(New Bitmap(My.Resources.cursos), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        Me.Text = "CURSOS"
    End Sub

    Private Sub _prCargarDetalleMaterias(_numi As String)
        Dim dt As New DataTable

        dt = L_fnDetalleMaterias(_numi)
        grdetalle_telefono.DataSource = dt
        grdetalle_telefono.RetrieveStructure()
        grdetalle_telefono.AlternatingColors = True
        '    detalle.canumi , detalle.cacu001, detalle.cama001, materia.manombre As canombre, cast(materia.maespecial As bit) As caespecial,
        'cast(materia.maestado As bit) As caestado, 1 As estado , cast('' as bit) as img
        With grdetalle_telefono.RootTable.Columns("canumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("cacu001")
            .Width = 90
            .Visible = False
        End With
        With grdetalle_telefono.RootTable.Columns("cama001")
            .Width = 150
            .Visible = True
            .Caption = "Codigo Materia"
        End With
        With grdetalle_telefono.RootTable.Columns("canombre")
            .Width = 250
            .Visible = True
            .Caption = "Nombre Materia"
        End With
        With grdetalle_telefono.RootTable.Columns("caespecial")
            .Width = 120
            .Visible = True
            .Caption = "Es Especial?"
        End With
        With grdetalle_telefono.RootTable.Columns("caestado")
            .Width = 120
            .Visible = True
            .Caption = "Estado"
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

    Private Sub _prCargarDetalleParalelo(_numi As String)
        Dim dt As New DataTable

        dt = L_fnDetalleParalelo(_numi)
        grparalelo.DataSource = dt
        grparalelo.RetrieveStructure()
        grparalelo.AlternatingColors = True
        ''a.cbnumi , a.cbcu001, a.cbparalelo, paralelo.ycdes3 As paralelo , 1 As estado, cast('' as image) as img 
        With grparalelo.RootTable.Columns("cbnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False
        End With
        With grparalelo.RootTable.Columns("cbcu001")
            .Width = 90
            .Visible = False
        End With
        With grparalelo.RootTable.Columns("cbparalelo")
            .Width = 150
            .Visible = False
            .Caption = "Codigo Paralelo".ToUpper
        End With
        With grparalelo.RootTable.Columns("paralelo")
            .Width = 250
            .Visible = True
            .Caption = "PARALELO"
        End With
        'With grparalelo.RootTable.Columns("nombrep")
        '    .Width = 250
        '    .Visible = True
        '    .Caption = "TUTOR"
        'End With
        With grparalelo.RootTable.Columns("estado")
            .Width = 90
            .Visible = False
        End With
        If (_fnActionAccesible()) Then

            With grparalelo.RootTable.Columns("img")
                .Width = 120
                .Caption = ""
                .Visible = True
            End With
        Else
            With grparalelo.RootTable.Columns("img")
                .Width = 120
                .Caption = ""
                .Visible = False
            End With
        End If



        With grparalelo
            .GroupByBoxVisible = False
            'diseño de la grilla
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .VisualStyle = VisualStyle.Office2007
        End With
        _prCargarIconELiminarParalelo()

    End Sub

    Public Sub _prCargarIconELiminarParalelo()
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)

        For i As Integer = 0 To CType(grparalelo.DataSource, DataTable).Rows.Count - 1 Step 1

            CType(grparalelo.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            'grdetalle_telefono.RootTable.Columns("img").Visible = True
        Next

    End Sub
    Public Sub _prCargarIconELiminar()
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        For i As Integer = 0 To CType(grdetalle_telefono.DataSource, DataTable).Rows.Count - 1 Step 1

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
            Dim _numi As Integer = CType(grdetalle_telefono.DataSource, DataTable).Rows(i).Item("canumi")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub

    Public Sub _fnObtenerFilaDetalleParalelo(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(grparalelo.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(grparalelo.DataSource, DataTable).Rows(i).Item("cbnumi")
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
                Dim lin As Integer = grdetalle_telefono.GetValue("canumi")
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

    Public Sub _prEliminarFilaParalelo()
        If (grparalelo.Row >= 0) Then
            If (grparalelo.RowCount >= 1) Then
                Dim estado As Integer = grparalelo.GetValue("estado")
                Dim pos As Integer = -1
                Dim lin As Integer = grparalelo.GetValue("cbnumi")
                _fnObtenerFilaDetalleParalelo(pos, lin)
                If (estado = 0) Then
                    CType(grparalelo.DataSource, DataTable).Rows(pos).Item("estado") = -2

                End If
                If (estado = 1) Then
                    CType(grparalelo.DataSource, DataTable).Rows(pos).Item("estado") = -1
                End If
                grparalelo.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(grparalelo.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))

                grparalelo.Select()
                If (grparalelo.RowCount > 1) Then
                    grparalelo.Col = 4
                    grparalelo.Row = grparalelo.RowCount - 1
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
        'tbdescripcion.MaxLength = 150
        cbnivel.MaxLength = 40
        cbgrado.MaxLength = 40
        cbparalelo.MaxLength = 40
        cbgestion.MaxLength = 40
        cbtutor.MaxLength = 80
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
    Private Sub _prCargarComboProfesores(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prprofesores()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("ponumi").Width = 70
            .DropDownList.Columns("ponumi").Caption = "COD"
            .DropDownList.Columns.Add("nombre").Width = 200
            .DropDownList.Columns("nombre").Caption = "DESCRIPCION"
            .ValueMember = "ponumi"
            .DisplayMember = "nombre"
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


        'tbdescripcion.ReadOnly = False
        cbgestion.ReadOnly = False
        cbparalelo.ReadOnly = False
        cbgrado.ReadOnly = False
        cbnivel.ReadOnly = False
        cbtutor.ReadOnly = False
        swEstado.IsReadOnly = False

        PanelDatosTelefono.Visible = True
        PanelDatosParalelo.Visible = True
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
        If (CType(cbtutor.DataSource, DataTable).Rows.Count > 0) Then
            cbtutor.SelectedIndex = 0
        End If
        grdetalle_telefono.RootTable.Columns("img").Visible = True
        grparalelo.RootTable.Columns("img").Visible = True
        btnImprimir.Visible = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()


        tbCodigo.ReadOnly = True
        'tbdescripcion.ReadOnly = True
        cbgestion.ReadOnly = True
        cbparalelo.ReadOnly = True
        cbgrado.ReadOnly = True
        cbnivel.ReadOnly = True
        cbtutor.ReadOnly = True
        swEstado.IsReadOnly = True
        tbdescripcion.ReadOnly = True
        PanelDatosTelefono.Visible = False
        JGrM_Buscador.Focus()
        Limpiar = False
        btnImprimir.Visible = True
        PanelDatosParalelo.Visible = False
        grdetalle_telefono.RootTable.Columns("img").Visible = False
        grparalelo.RootTable.Columns("img").Visible = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbCodigo.Clear()
        'tbdescripcion.Clear()
        _IdProfesor = 0
        tbprofesor.Clear()
        tbmateria.Clear()
        swEstado.Value = True
        _prCargarDetalleMaterias(-1)
        _prCargarDetalleParalelo(-1)
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
        If (CType(cbtutor.DataSource, DataTable).Rows.Count > 0) Then
            cbtutor.SelectedIndex = 0
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
        'tbdescripcion.BackColor = Color.White
        cbgestion.BackColor = Color.White
        cbgrado.BackColor = Color.White
        cbparalelo.BackColor = Color.White
        cbnivel.BackColor = Color.White
        cbtutor.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean

        'ByRef _cunumi As String, _cudescripcion As String,
        '                                    _cunivel As Integer, _cugrado As Integer, _cuparalelo As Integer,
        '                                    _cugestion As Integer, _cupo001 As Integer, _cuestado As Integer, _dt As DataTable

        Dim numi As String = ""

        Dim res As Boolean = L_fnGrabarCurso(numi, tbdescripcion.Text, cbnivel.Value, cbgrado.Value, cbparalelo.Value, cbgestion.Value, _IdProfesor, IIf(swEstado.Value = True, 1, 0), CType(grdetalle_telefono.DataSource, DataTable), CType(grparalelo.DataSource, DataTable)) 'ojo 


        If res Then
            Modificado = False
            '_fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Titulares", nameImg)
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Curso ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbCodigo.Focus()
            Limpiar = True
            _IdProfesor = 0
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Curso no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean

        res = L_fnModificarCurso(tbCodigo.Text, tbdescripcion.Text, cbnivel.Value, cbgrado.Value, cbparalelo.Value, cbgestion.Value, _IdProfesor, IIf(swEstado.Value = True, 1, 0), CType(grdetalle_telefono.DataSource, DataTable), CType(grparalelo.DataSource, DataTable)) 'ojo

        If res Then



            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Curso ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "EL Curso no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

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
            Dim res As Boolean = L_fnEliminarCurso(tbCodigo.Text, mensajeError)
            If res Then


                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Curso ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
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

        If cbgestion.SelectedIndex < 0 Then
            cbgestion.BackColor = Color.Red

            MEP.SetError(cbgestion, "Seleccione una gestion!".ToUpper)
            _ok = False
        Else
            cbgestion.BackColor = Color.White
            MEP.SetError(cbgestion, "")
        End If
        If cbnivel.SelectedIndex < 0 Then
            cbnivel.BackColor = Color.Red

            MEP.SetError(cbnivel, "Seleccione un nivel!".ToUpper)
            _ok = False
        Else
            cbnivel.BackColor = Color.White
            MEP.SetError(cbnivel, "")
        End If
        If cbparalelo.SelectedIndex < 0 Then
            cbparalelo.BackColor = Color.Red

            MEP.SetError(cbparalelo, "Seleccione un Paralelo!".ToUpper)
            _ok = False
        Else
            cbparalelo.BackColor = Color.White
            MEP.SetError(cbparalelo, "")
        End If

        If cbgrado.SelectedIndex < 0 Then
            cbgrado.BackColor = Color.Red

            MEP.SetError(cbgrado, "Seleccione un Grado!".ToUpper)
            _ok = False
        Else
            cbgrado.BackColor = Color.White
            MEP.SetError(cbgrado, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_fnGeneralCurso()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        '      a.cunumi , a.cudescripcion, a.cunivel, nivel.ycdes3 As nivel, a.cugrado, grado.ycdes3 As grado, a.cuparalelo, paralelo.ycdes3 as paralelo
        ',a.cugestion ,gestion .ycdes3 as gestion,a.cupo001 , concat(profesor .ponombre ,' ',profesor .poapellido_p ,' ',profesor .poapellido_m )as profesor
        ',cast(a.cuestado  as bit)as estado,a.cufact ,a.cuhact ,a.cuuact 
        listEstCeldas.Add(New Modelo.Celda("cunumi", True, "Código".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("cudescripcion", True, "Descripcion".ToUpper, 300))
        listEstCeldas.Add(New Modelo.Celda("cunivel", False))
        listEstCeldas.Add(New Modelo.Celda("nivel", True, "Nivel".ToUpper, 120))

        listEstCeldas.Add(New Modelo.Celda("cugrado", False))
        listEstCeldas.Add(New Modelo.Celda("grado", True, "Grado".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("cuparalelo", False))
        listEstCeldas.Add(New Modelo.Celda("paralelo", False, "paralelo".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("cugestion", False))
        listEstCeldas.Add(New Modelo.Celda("gestion", True, "gestion".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("cupo001", False))
        listEstCeldas.Add(New Modelo.Celda("profesor", True, "Profesor".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("estado", True, "Estado".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("cufact", False))
        listEstCeldas.Add(New Modelo.Celda("cuhact", False))
        listEstCeldas.Add(New Modelo.Celda("cuuact", False))


        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        '      a.cunumi , a.cudescripcion, a.cunivel, nivel.ycdes3 As nivel, a.cugrado, grado.ycdes3 As grado, a.cuparalelo, paralelo.ycdes3 as paralelo
        ',a.cugestion ,gestion .ycdes3 as gestion,a.cupo001 , concat(profesor .ponombre ,' ',profesor .poapellido_p ,' ',profesor .poapellido_m )as profesor
        ',cast(a.cuestado  as bit)as estado,a.cufact ,a.cuhact ,a.cuuact 
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
        Try
            tbCodigo.Text = JGrM_Buscador.GetValue("cunumi").ToString
        Catch ex As Exception
            Exit Sub
        End Try
        With JGrM_Buscador
            tbCodigo.Text = .GetValue("cunumi").ToString
            'tbdescripcion.Text = .GetValue("cudescripcion").ToString
            cbnivel.Value = .GetValue("cunivel")
            cbgrado.Value = .GetValue("cugrado")
            cbparalelo.Value = .GetValue("cuparalelo")
            cbgestion.Value = .GetValue("cugestion")
            _IdProfesor = .GetValue("cupo001")
            tbprofesor.Text = .GetValue("profesor").ToString
            swEstado.Value = .GetValue("estado")
            lbFecha.Text = CType(.GetValue("cufact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("cuhact").ToString
            lbUsuario.Text = .GetValue("cuuact").ToString
            _prCargarDetalleMaterias(.GetValue("cunumi").ToString)
            _prCargarDetalleParalelo(.GetValue("cunumi").ToString)
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





    Private Sub cbnivel_ValueChanged(sender As Object, e As EventArgs) Handles cbnivel.ValueChanged
        If cbnivel.SelectedIndex < 0 And cbnivel.Text <> String.Empty Then
            btcbnivel.Visible = True
        Else
            btcbnivel.Visible = False
        End If
    End Sub

    Private Sub cbgrado_ValueChanged(sender As Object, e As EventArgs) Handles cbgrado.ValueChanged
        If cbgrado.SelectedIndex < 0 And cbgrado.Text <> String.Empty Then
            btcbgrado.Visible = True
        Else
            btcbgrado.Visible = False
        End If
    End Sub

    Private Sub cbparalelo_ValueChanged(sender As Object, e As EventArgs) Handles cbparalelo.ValueChanged
        If cbparalelo.SelectedIndex < 0 And cbparalelo.Text <> String.Empty Then
            btcbparalelo.Visible = True
        Else
            btcbparalelo.Visible = False
        End If
    End Sub

    Private Sub cbgestion_ValueChanged(sender As Object, e As EventArgs) Handles cbgestion.ValueChanged
        If cbgestion.SelectedIndex < 0 And cbgestion.Text <> String.Empty Then
            btcbgestion.Visible = True
        Else
            btcbgestion.Visible = False
        End If
    End Sub

    Private Sub btcbnivel_Click(sender As Object, e As EventArgs) Handles btcbnivel.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "7", "3", cbnivel.Text, "") Then
            _prCargarComboLibreria(cbnivel, "7", "3")
            cbnivel.SelectedIndex = CType(cbnivel.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btcbgrado_Click(sender As Object, e As EventArgs) Handles btcbgrado.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "7", "2", cbgrado.Text, "") Then
            _prCargarComboLibreria(cbgrado, "7", "2")
            cbgrado.SelectedIndex = CType(cbgrado.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btcbparalelo_Click(sender As Object, e As EventArgs) Handles btcbparalelo.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "7", "4", cbparalelo.Text, "") Then
            _prCargarComboLibreria(cbparalelo, "7", "4")
            cbparalelo.SelectedIndex = CType(cbparalelo.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub btcbgestion_Click(sender As Object, e As EventArgs) Handles btcbgestion.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "7", "1", cbgestion.Text, "") Then
            _prCargarComboLibreria(cbgestion, "7", "1")
            cbgestion.SelectedIndex = CType(cbgestion.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub F1_curso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
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

    Private Sub tbprofesor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub tbprofesor_KeyDown(sender As Object, e As KeyEventArgs) Handles tbprofesor.KeyDown
        If (_fnActionAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnGeneralProfesorObtener()
                '            titular.ponumi , titular.ponrodoc, concat(titular.ponombre,' ',titular .poapellido_p ,' ',titular .poapellido_m )as nombre,
                'titular.podireccion, titular.poemail, pofnac

                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("ponumi,", True, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("ponrodoc", True, "Nro Documento", 100))
                listEstCeldas.Add(New Modelo.Celda("nombre", True, "Nombre Profesor", 280))
                listEstCeldas.Add(New Modelo.Celda("podireccion", True, "Direccion", 220))
                listEstCeldas.Add(New Modelo.Celda("poemail", True, "Email", 200))
                listEstCeldas.Add(New Modelo.Celda("pofnac", True, "F.Nacimiento", 150, "MM/dd,YYYY"))
                Dim ef = New Efecto
                ef.tipo = 3
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione TITULAR".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row

                    _IdProfesor = Row.Cells("ponumi").Value
                    tbprofesor.Text = Row.Cells("nombre").Value


                End If

            End If

        End If

    End Sub

    Private Sub tbnumero_KeyDown(sender As Object, e As KeyEventArgs) Handles tbmateria.KeyDown
        If (_fnActionAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnGeneralListarMaterias()
                '              a.manumi , a.manombre, a.madescripcion, cast(a.maespecial As bit)as  maespecial 
                ',cast(a.maestado as bit) as maestado 

                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("manumi,", True, "Codigo", 50))
                listEstCeldas.Add(New Modelo.Celda("manombre", True, "Nombre Materia", 200))
                listEstCeldas.Add(New Modelo.Celda("maarea", False, "Area", 280))
                listEstCeldas.Add(New Modelo.Celda("maespecial", True, "Es Especial?", 120))
                listEstCeldas.Add(New Modelo.Celda("maestado", True, "Estado", 120))

                Dim ef = New Efecto
                ef.tipo = 3
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione Materia".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then

                    '              a.manumi , a.manombre, a.madescripcion, cast(a.maespecial As bit)as  maespecial 
                    ',cast(a.maestado as bit) as maestado 


                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row


                    Dim Bin As New MemoryStream
                    Dim img As New Bitmap(My.Resources.delete, 28, 28)
                    img.Save(Bin, Imaging.ImageFormat.Png)
                    ''detalle.canumi , detalle.cacu001, detalle.cama001, materia.manombre As canombre, cast(materia.maespecial As bit) As caespecial,
                    'cast(materia.maestado As bit) As caestado, 1 As estado , cast('' as bit) as img
                    CType(grdetalle_telefono.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, Row.Cells("manumi").Value, Row.Cells("manombre").Value, Row.Cells("maespecial").Value, Row.Cells("maestado").Value, 0, Bin.GetBuffer)

                    tbmateria.Clear()


                End If

            End If

        End If
    End Sub
    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(grdetalle_telefono.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("canumi=MAX(canumi)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("canumi")
        End If
        Return 1
    End Function
    Public Function _fnSiguienteNumiParalelo()
        Dim dt As DataTable = CType(grparalelo.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("cbnumi=MAX(cbnumi)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("cbnumi")
        End If
        Return 1
    End Function
    Function _fnvalidardatos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()


        If cbparalelo.SelectedIndex < 0 Then
            cbparalelo.BackColor = Color.Red

            MEP.SetError(cbparalelo, "seleccione un paralelo!".ToUpper)

        Else
            cbparalelo.BackColor = Color.White
            MEP.SetError(cbparalelo, "")
        End If
        If cbtutor.SelectedIndex < 0 Then
            cbtutor.BackColor = Color.Red

            MEP.SetError(cbtutor, "seleccione un tutor!".ToUpper)

        Else
            cbtutor.BackColor = Color.White
            MEP.SetError(cbtutor, "")
        End If
        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If (_fnvalidardatos() = True) Then
            cbparalelo.BackColor = Color.White
            MEP.SetError(cbparalelo, "")
            cbtutor.BackColor = Color.White
            MEP.SetError(cbtutor, "")
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)
            'a.cbnumi ,a.cbcu001 ,a.cbparalelo, paralelo .ycdes3 as paralelo ,1 as estado,cast('' as image) as img 
            CType(grparalelo.DataSource, DataTable).Rows.Add(_fnSiguienteNumiParalelo() + 1, 0, cbparalelo.Value, cbparalelo.Text, 0, Bin.GetBuffer)

            cbparalelo.Focus()

        End If
    End Sub

    Private Sub grparalelo_MouseClick(sender As Object, e As MouseEventArgs) Handles grparalelo.MouseClick
        If (Not _fnActionAccesible()) Then
            Return
        End If

        If (grparalelo.RowCount >= 1 And Not IsNothing(grparalelo.CurrentColumn)) Then
            If (grparalelo.CurrentColumn.Index = grparalelo.RootTable.Columns("img").Index) Then
                _prEliminarFilaParalelo()
            End If
        End If
    End Sub
End Class