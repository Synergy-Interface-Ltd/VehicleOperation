Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class create_services
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
    Dim total1

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button6.Visible = True Then
            Button6.Visible = False
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            CheckBox1.Checked = False
            Button2.Visible = True
            Button3.Visible = False
            Button4.Visible = False
            strnewrecord = "SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Car Type],[service_charge] as [Service Charge], spare as [Type] FROM [service_master] where spare='Service' order by [service_category], [service_name], car_type"
            genf.populate_grid(strnewrecord, GridView1)
            TextBox1.Focus()

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "INSERT INTO [service_master] ([service_category],[service_name],[car_type],[service_charge],spare) values ('" & TextBox1.Text.Replace("'", "''") & "','" & TextBox2.Text.Replace("'", "''") & "','" & TextBox3.Text.Replace("'", "''") & "','" & Val(TextBox4.Text) & "','Service')"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        Page_Load(sender, e)

    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "update [service_master] set spare='Service', [service_category]='" & TextBox1.Text.Replace("'", "''") & "',[service_name]='" & TextBox2.Text.Replace("'", "''") & "',[car_type]='" & TextBox3.Text.Replace("'", "''") & "',[service_charge]='" & Val(TextBox4.Text) & "' where service_id='" & Val(TextBox5.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        Page_Load(sender, e)
    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "delete from [service_master] where service_id='" & Val(TextBox5.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        Page_Load(sender, e)
    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        Button6.Visible = True
        Page_Load(sender, e)
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(2).Text = Server.HtmlDecode(e.Row.Cells(2).Text)
            e.Row.Cells(3).Text = Server.HtmlDecode(e.Row.Cells(3).Text)
            e.Row.Cells(4).Text = Server.HtmlDecode(e.Row.Cells(4).Text)
            e.Row.Cells(5).Text = genf.roundup(Val(e.Row.Cells(5).Text))
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right

            If e.Row.Cells(6).Text = "True" Then
                e.Row.Cells(6).Text = "Yes"
            Else
                e.Row.Cells(6).Text = ""
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        TextBox5.Text = GridView1.SelectedRow.Cells(1).Text
        TextBox1.Text = GridView1.SelectedRow.Cells(2).Text
        TextBox2.Text = GridView1.SelectedRow.Cells(3).Text
        TextBox3.Text = GridView1.SelectedRow.Cells(4).Text
        TextBox4.Text = GridView1.SelectedRow.Cells(5).Text
        If GridView1.SelectedRow.Cells(6).Text = "Yes" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        Button2.Visible = False
        Button3.Visible = True
        Button4.Visible = True
        TextBox1.Focus()

    End Sub
End Class
