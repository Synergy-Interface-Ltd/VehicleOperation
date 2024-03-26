Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.IdentityModel.Protocols.WSTrust

Partial Class job_against_chesis
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
    Dim total1, total2, total3

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),job_id FROM [estimate_new_job_cart] where chesis_no='" & Request.QueryString("id") & "' order by job_id desc"

        genf.populate_grid(strnewrecord, GridView1)
        Myconnection.Close()
    End Sub
    Protected Sub GridView1_SelectIndex(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Response.Redirect("order_placement.aspx?url=" & Trim(GridView1.SelectedRow.Cells(22).Text) & "")
    End Sub

End Class

