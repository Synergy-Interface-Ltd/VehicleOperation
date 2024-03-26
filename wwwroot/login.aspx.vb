Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Partial Class login
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim Myconnection As SqlConnection
    Dim Mycommand, Mycommand1 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1 As SqlDataAdapter
    Dim dv, dv1 As New DataView
    Dim mydataset, mydataset1 As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Button1.Visible = True Then
            Session.Abandon()
            Button1.Visible = False
            Label47.Text = ""
            TextBox199.Text = ""
            TextBox2.Text = ""
        
            TextBox199.Focus()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Mycommand = New SqlCommand("select * from operation_user_master where [uid]='" & TextBox199.Text & "' and pwd='" & TextBox2.Text & "'", Myconnection)
        Mydataadapter = New SqlDataAdapter(Mycommand)

        Mydataadapter.Fill(mydataset, "sector_master")
        dv.Table = mydataset.Tables(0)
        If dv.Count > 0 Then
            Session("uid") = dv(0)(0)
            Session("user_type") = dv(0)(2)
           dv.Table.Clear()
            mydataset.Tables.Clear()
            Myconnection.Close()
            Label47.Text = ""
            Response.Redirect("default.aspx")

        Else
            Label47.Text = "Login Failed..."
            dv.Table.Clear()
            mydataset.Tables.Clear()
            Myconnection.Close()
        End If
    End Sub
End Class
