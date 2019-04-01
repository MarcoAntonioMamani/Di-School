Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class Pr_ListaAlumnos

    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _IdCurso As Integer = 0
    Public _IdParalelo As Integer = 0

    Public Sub _prIniciarTodo()

        _PMIniciarTodo()

        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "REPORTE DE ALUMNOS"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        _prCargarComboLibreria(cbgestion, 7, 1)
        cbgestion.ReadOnly = True

        tbprofesor.ReadOnly = True
        tbprofesor.Focus()
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

    Private Sub _prCargarReporte()
        If (cbgestion.SelectedIndex < 0) Then
            ToastNotification.Show(Me, "POR FAVOR SELECCIONE UNA GESTION!!!",
                                    My.Resources.INFORMATION, 2000,
                                    eToastGlowColor.Blue,
                                    eToastPosition.BottomLeft)
            cbgestion.Focus()
            Return
        End If
        If (_IdCurso <= 0) Then
            ToastNotification.Show(Me, "POR FAVOR SELECCIONE UN CURSO!!!",
                                    My.Resources.INFORMATION, 2000,
                                    eToastGlowColor.Blue,
                                    eToastPosition.BottomLeft)
            tbprofesor.Focus()
            Return
        End If
        Dim _dt As New DataTable
        _dt = fn_ListarAlumnos(_IdCurso, _IdParalelo)
        If (_dt.Rows.Count > 0) Then

            Dim objrep As New R_ListaAlumnos
            objrep.SetDataSource(_dt)

            objrep.SetParameterValue("gestion", cbgestion.Text)
            objrep.SetParameterValue("curso", tbprofesor.Text)
            MReportViewer.ReportSource = objrep
            MReportViewer.Show()
            MReportViewer.BringToFront()


        Else
            ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                       eToastPosition.BottomLeft)
            MReportViewer.ReportSource = Nothing
        End If





    End Sub


    Private Sub tbprofesor_KeyDown(sender As Object, e As KeyEventArgs) Handles tbprofesor.KeyDown
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

            listEstCeldas.Add(New Modelo.Celda("profesor", False, "TITULAR", 200))

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
                tbprofesor.Text = Row.Cells("grado").Value + " " + Row.Cells("nivel").Value + " " + Row.Cells("paralelo").Value
                _IdParalelo = Row.Cells("cbparalelo").Value
                cbgestion.Value = Row.Cells("cugestion").Value

            End If

        End If
    End Sub

    Private Sub Pr_ListaAlumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _tab.Close()
    End Sub
End Class