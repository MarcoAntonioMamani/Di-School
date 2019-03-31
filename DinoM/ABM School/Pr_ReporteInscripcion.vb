Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Public Class Pr_ReporteInscripcion


    Public _nameButton As String
    Public _tab As SuperTabItem

    Public Sub _prIniciarTodo()

        _PMIniciarTodo()
        _prCargarComboLibreria(cbgestion, 7, 1)
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "REPORTE DE INSCRITOS"
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        If (CType(cbgestion.DataSource, DataTable).Rows.Count > 0) Then
            cbgestion.SelectedIndex = 0
        End If
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
        Dim _dt As New DataTable
        _dt = fn_Listarinscritos(cbgestion.Value)
        If (_dt.Rows.Count > 0) Then

            Dim objrep As New R_ReporteInscritos
            objrep.SetDataSource(_dt)

            objrep.SetParameterValue("gestion", cbgestion.Text)
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
    Private Sub Pr_ReporteInscripcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _tab.Close()
    End Sub
End Class