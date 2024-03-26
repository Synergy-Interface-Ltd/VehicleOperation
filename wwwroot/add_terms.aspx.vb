Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class add_terms
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
             Button2.Visible = True
            Button3.Visible = False
            Button4.Visible = False
            strnewrecord = "SELECT [Terms] as [Terms & Condition] FROM [Terms]"
            genf.populate_grid(strnewrecord, GridView1)
            TextBox1.Focus()

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "delete from [Terms] "
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        strnewrecord = "INSERT INTO [Terms] ([Terms]) values ('" & TextBox1.Text.Replace("'", "''") & "')"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        Page_Load(sender, e)

    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "update [Terms] set [Terms]='" & TextBox1.Text.Replace("'", "''") & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        Page_Load(sender, e)
    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        strnewrecord = "delete from [Terms] "
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
            e.Row.Cells(1).Text = Server.HtmlDecode(e.Row.Cells(1).Text.Replace(Environment.NewLine, "<br>"))
            '  e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right


        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        TextBox1.Text = GridView1.SelectedRow.Cells(1).Text
        Button2.Visible = False
        Button3.Visible = True
        Button4.Visible = True
        TextBox1.Focus()

    End Sub
End Class

