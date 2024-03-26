Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class customer_feedback
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
    Dim total1, total2, total3, total4, total5, total6, total7

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button2.Visible = True Then
            Button2.Visible = False
            TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy")
            genf.populate_grid("SELECT [new_job_cart].[job_id],(case when (select name from OpinionStatus where id=CustomerOpinion.status) is null then 'Not Received Yet' else (select name from OpinionStatus where id=CustomerOpinion.status) end)  as Status,[customer_name],[address],[email],[tel],[mobile],Format([in_date],'dd/MM/yyyy') as 'In Date',Format([dlv_date] ,'dd/MM/yyyy') as 'Delivery Date',[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],(select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no) as ""Bill No"",engineer, customer_id FROM OpinionTime  left join [new_job_cart]  on [new_job_cart].job_id= OpinionTime.job_id left join CustomerOpinion on CustomerOpinion.Job_Id=new_job_cart.[job_id] where OpinionDate ='" & genf.getdate(DateTime.Now.ToString("dd/MM/yyyy")).ToString("yyyy/MM/dd") & "'", GridView1)

        End If
    End Sub
    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        genf.populate_grid("SELECT [new_job_cart].[job_id],(case when (select name from OpinionStatus where id=CustomerOpinion.status) is null then 'Not Received Yet' else (select name from OpinionStatus where id=CustomerOpinion.status) end)  as Status,[customer_name],[address],[email],[tel],[mobile],Format([in_date],'dd/MM/yyyy') as 'In Date',Format([dlv_date],'dd/MM/yyyy') as 'Delivery Date',[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],(select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no) as ""Bill No"",engineer, customer_id FROM OpinionTime  left join [new_job_cart] on [new_job_cart].job_id= OpinionTime.job_id  left join CustomerOpinion on CustomerOpinion.Job_Id=new_job_cart.[job_id] where OpinionDate >='" & genf.getdate(TextBox4.Text).ToString("yyyy/MM/dd") & "' and OpinionDate <='" & genf.getdate(TextBox9.Text).ToString("yyyy/MM/dd") & "'", GridView1)
    End Sub
    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click
        genf.populate_grid("SELECT [new_job_cart].[job_id],(case when (select name from OpinionStatus where id=CustomerOpinion.status) is null then 'Not Received Yet' else (select name from OpinionStatus where id=CustomerOpinion.status) end)  as Status,[customer_name],[address],[email],[tel],[mobile],Format([in_date],'dd/MM/yyyy') as 'In Date',Format([dlv_date],'dd/MM/yyyy') as 'Delivery Date',[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],(select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no) as 'Bill No',engineer, customer_id FROM OpinionTime  left join [new_job_cart] on [new_job_cart].job_id= OpinionTime.job_id left join CustomerOpinion on CustomerOpinion.Job_Id=new_job_cart.[job_id] where OpinionTime.[job_id]='" & TextBox21.Text & "'", GridView1)
    End Sub
    Protected Sub GridView1_SelectedRowChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('collect_opinion.aspx?id=" & GridView1.SelectedRow.Cells(1).Text & "','collect_opinion');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub

End Class
