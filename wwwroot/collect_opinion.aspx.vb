Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.Drawing
Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Partial Class collect_opinion
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

            genf.populate_grid("SELECT [new_job_cart].[job_id],[customer_name],[address],[email],[tel],[mobile],Format([in_date],'dd/MM/yyyy'),Format([dlv_date],'dd/MM/yyyy'),[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],(select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no) as ""Bill No"",engineer, customer_id FROM [new_job_cart]   where job_id ='" & Request.QueryString("id") & "'", GridView1)
            genf.populate_dropdownlist("select id,name from opinionstatus where status=1 order by id", DropdownList1, "name", "id")
            strnewrecord = "SELECT [Text],[status] From [CustomerOpinion]  where [Job_Id]='" & Request.QueryString("id") & "'"

            FeedBack.Text = genf.returnvaluefromdv(strnewrecord, 0)
            If FeedBack.Text <> "" Then
                Button10.Visible = False

            Else
                Button11.Visible = False
            End If
            Dim statusId = genf.returnvaluefromdv(strnewrecord, 1)

            Dim i
            For i = 0 To DropdownList1.Items.Count - 1
                If DropdownList1.Items(i).Value = i + 1 Then
                    DropdownList1.SelectedIndex = i
                End If
            Next

        End If
    End Sub

    Protected Sub Button10_Click(sender As Object, e As System.EventArgs) Handles Button10.Click

        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim maxId = genf.returnvaluefromdv("Select max(Id) from CustomerOpinion  ", 0)
        strnewrecord = "Insert into  CustomerOpinion(ID ,Job_Id ,Text ,Enter_by ,issue_date ,opinion_date ,status ) values('" & Val(maxId) + 1 & "',"
        strnewrecord &= "'" & GridView1.Rows(0).Cells(0).Text & "','" + FeedBack.Text + "','" + Session("uid") + "','" & genf.getdate(DateTime.Now.ToString("dd/MM/yyyy")).ToString("MM/dd/yyyy") & "',null,'" & DropdownList1.SelectedValue & "') "

        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Dim alertScript = "alert('This Data Has Been Inserted Succesfully ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

    End Sub
    Protected Sub Button11_Click(sender As Object, e As System.EventArgs) Handles Button11.Click

        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "update  CustomerOpinion set Text='" & FeedBack.Text & "',Enter_by='" & Session("uid") & "',issue_date='" & genf.getdate(DateTime.Now.ToString("dd/MM/yyyy")).ToString("MM/dd/yyyy") & "',status='" & DropdownList1.SelectedValue & "' where Job_Id='" & GridView1.Rows(0).Cells(0).Text & "'"

        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Dim alertScript = "alert('This Data Has Been Updated Succesfully ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

    End Sub
End Class
