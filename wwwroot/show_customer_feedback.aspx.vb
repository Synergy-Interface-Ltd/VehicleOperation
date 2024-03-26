Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.Activities.Expressions
Imports System.Drawing

Partial Class show_customer_feedback
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
            strnewrecord = "SELECT  [new_job_cart].[job_id] as 'Job Id',(case when (select name from OpinionStatus where id=CustomerOpinion.status) is null then 'Not Received Yet' else (select name from OpinionStatus where id=CustomerOpinion.status) end)  as Status,"
            strnewrecord &= "[Text] as Details,Format([OpinionTime].[OpinionDate],'dd/MM/yyyy') as 'Opi. Date',Format([issue_date],'dd/MM/yyyy') as 'Issue Date',[Enter_by],[customer_name],[address],[email],[mobile],Format([in_date],'dd/MM/yyyy') as 'In Date',"
            strnewrecord &= " Format([dlv_date],'dd/MM/yyyy') as 'Del. Date',[vehicle],[reg_no],[model],[eng_no],[chesis_no],[bill_no],[engineer],[customer_id] "
            strnewrecord &= " From [OpinionTime] left join [new_job_cart] on [OpinionTime].[job_id]=[new_job_cart].[job_id]"
            strnewrecord &= "left join CustomerOpinion on CustomerOpinion.Job_Id=new_job_cart.[job_id] order by [issue_date] desc"
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()
            Dim adp As SqlDataAdapter = New SqlDataAdapter(strnewrecord, Myconnection)
            Dim dt As DataTable = New System.Data.DataTable()
            adp.Fill(dt)
            GridView1.DataSource = dt
            GridView1.DataBind()
            Myconnection.Close()

        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            If e.Row.Cells(1).Text = "Satisfied" Then
                e.Row.Cells(1).ForeColor = Color.Green
                e.Row.Cells(1).Font.Bold = True
            ElseIf e.Row.Cells(1).Text = "Warning" Then
                e.Row.Cells(1).ForeColor = Color.Red
                e.Row.Cells(1).Font.Bold = True
            Else
                e.Row.Cells(1).ForeColor = Color.Yellow
                e.Row.Cells(1).Font.Bold = True
            End If
        End If
    End Sub



    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click

        strnewrecord = "SELECT  [new_job_cart].[job_id] as 'Job Id',(case when (select name from OpinionStatus where id=CustomerOpinion.status) is null then 'Not Received Yet' else (select name from OpinionStatus where id=CustomerOpinion.status) end)  as Status,"
        strnewrecord &= "[Text] as Details,Format([OpinionTime].[OpinionDate],'dd/MM/yyyy') as 'Opi. Date',Format([issue_date],'dd/MM/yyyy') as 'Issue Date',[Enter_by],[customer_name],[address],[email],[mobile],Format([in_date],'dd/MM/yyyy') as 'In Date',"
        strnewrecord &= " Format([dlv_date],'dd/MM/yyyy') as 'Del. Date',[vehicle],[reg_no],[model],[eng_no],[chesis_no],[bill_no],[engineer],[customer_id] "
        strnewrecord &= " From [OpinionTime] left join [new_job_cart] on [OpinionTime].[job_id]=[new_job_cart].[job_id]"
        strnewrecord &= "left join CustomerOpinion on CustomerOpinion.Job_Id=new_job_cart.[job_id] where issue_date >='" & genf.getdate(TextBox4.Text).ToString("yyyy/MM/dd") & "' and issue_date <='" & genf.getdate(TextBox9.Text).ToString("yyyy/MM/dd") & "' order by [issue_date] desc"


        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter(strnewrecord, Myconnection)
        Dim dt As DataTable = New System.Data.DataTable()
        adp.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
        Myconnection.Close()

    End Sub
    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click

        strnewrecord = "SELECT  [new_job_cart].[job_id] as 'Job Id',(case when (select name from OpinionStatus where id=CustomerOpinion.status) is null then 'Not Received Yet' else (select name from OpinionStatus where id=CustomerOpinion.status) end)  as Status,"
        strnewrecord &= "[Text] as Details,Format([OpinionTime].[OpinionDate],'dd/MM/yyyy') as 'Opi. Date',Format([issue_date],'dd/MM/yyyy') as 'Issue Date',[Enter_by],[customer_name],[address],[email],[mobile],Format([in_date],'dd/MM/yyyy') as 'In Date',"
        strnewrecord &= " Format([dlv_date],'dd/MM/yyyy') as 'Del. Date',[vehicle],[reg_no],[model],[eng_no],[chesis_no],[bill_no],[engineer],[customer_id] "
        strnewrecord &= " From [OpinionTime] left join [new_job_cart] on [OpinionTime].[job_id]=[new_job_cart].[job_id]"
        strnewrecord &= "left join CustomerOpinion on CustomerOpinion.Job_Id=new_job_cart.[job_id] where OpinionTime.[job_id]='" & TextBox21.Text & "' order by [issue_date] desc"


        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter(strnewrecord, Myconnection)
        Dim dt As DataTable = New System.Data.DataTable()
        adp.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
        Myconnection.Close()



    End Sub


End Class
