Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Partial Class change_pwd
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
            '  Session.Abandon()
            If Not IsNothing(Session("uid")) Then
                Button1.Visible = False
                Label47.Text = ""
                TextBox199.Text = Session("uid").ToString
                TextBox201.Text = ""

                TextBox2.Text = ""
                TextBox200.Text = ""

                TextBox201.Focus()
            End If

        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Mycommand = New SqlCommand("select * from operation_user_master where [uid]='" & TextBox199.Text & "' and pwd='" & TextBox201.Text & "'", Myconnection)
        Mydataadapter = New SqlDataAdapter(Mycommand)

        Mydataadapter.Fill(mydataset, "sector_master")
        dv.Table = mydataset.Tables(0)
        If dv.Count > 0 Then
            dv.Table.Clear()
            mydataset.Tables.Clear()
            Mycommand1 = New SqlCommand("update operation_user_master set pwd='" & TextBox2.Text & "' where [uid]='" & TextBox199.Text & "' and pwd='" & TextBox201.Text & "'", Myconnection)
            Mycommand1.ExecuteNonQuery()
            Myconnection.Close()
            Label47.Text = "Password Changed..."
        Else
            Label47.Text = "Wrong Old Password..."
            dv.Table.Clear()
            mydataset.Tables.Clear()
            Myconnection.Close()
        End If
    End Sub
End Class
