Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class money_receipt1
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim Myconnection, myconnection1 As SqlConnection
    Dim Mycommand, Mycommand1, Mycommand2, Mycommand10 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1, Mydataadapter2, Mydataadapter10 As SqlDataAdapter
    Dim dv, dv1, dv2, dv10 As New DataView
    Dim mydataset, mydataset1, mydataset2, mydataset10 As New DataSet
    Dim genf As New genfunction
    Dim amiw As New amtinwords
    Dim total1, total2, total3
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Label9.Text = Request.QueryString("url").ToString
        Label3.Text = genf.returnvaluefromdv("select customer_name from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        '   Label5.Text = genf.returnvaluefromdv("select reg_no from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        Label7.Text = genf.returnvaluefromdv("select payment.amount from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        Label24.Text = genf.roundup(Val(Label7.Text))

        Label7.Text = amiw.SpellNumber(Val(Label7.Text))
        Label11.Text = genf.returnvaluefromdv("select payment.b_type from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)

        Label13.Text = genf.returnvaluefromdv("select payment.cheque_no from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        Label15.Text = genf.returnvaluefromdv("select payment.chq_date from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        Label17.Text = genf.returnvaluefromdv("select payment.bank from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        Label18.Text = "Jobs Under Invoice" 'genf.returnvaluefromdv("select payment.bill_no from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        Label21.Text = genf.returnvaluefromdv("select payment.bill_date from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)
        '   Label43.Text = genf.returnvaluefromdv("select payment.job_no from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0)

        Try
            Label21.Text = genf.getdatefromdb(Label21.Text).ToString("dd/MM/yyyy")
        Catch ex As Exception

        End Try
        Try
            Label15.Text = genf.getdatefromdb(Label15.Text).ToString("dd/MM/yyyy")
        Catch ex As Exception

        End Try
        If genf.returnvaluefromdv("select payment.pmnt_mode from new_job_cart, payment where new_job_cart.customer_id=payment.customer and payment.tx_no='" & Val(Label9.Text) & "'", 0) = "Cash" Then
            Label12.Text = "by Cash"
            Label13.Visible = False
            Label14.Visible = False
            Label15.Visible = False
            Label16.Visible = False
            Label17.Visible = False
        Else
            Label12.Text = "Cheque No"
            Label13.Visible = True
            Label14.Visible = True
            Label15.Visible = True
            Label16.Visible = True
            Label17.Visible = True
        End If
        Dim sb As New StringBuilder()

        'Dim hdr As New Literal
        'hdr = Me.Master.FindControl("Literal1")
        ' hdr.RenderControl(New HtmlTextWriter(New StringWriter(sb)))
        inv.RenderControl(New HtmlTextWriter(New StringWriter(sb)))
        Literal1.Text = Literal1.Text & sb.ToString()


    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
End Class

