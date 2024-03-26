Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class add_order_status
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


            genf.populate_dropdownlist("Select Id,Name from SupplierType where status=1", Dropdownlist1, "Name", "ID")
            strnewrecord = "select Id,Name,Address,Mobile,supplier_type,(select name from SupplierType where id=SupplierInfo.supplier_type ) as [Supplier Type],Status from SupplierInfo order by id"
            genf.populate_grid(strnewrecord, Gridview1)


            TextBox1.Focus()

        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Gridview1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(5).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(5).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(5).Visible = False

        End If
    End Sub

    Protected Sub GridView1_SeletedDataRow(sender As Object, e As System.EventArgs) Handles Gridview1.SelectedIndexChanged

        TextBox1.Text = Gridview1.SelectedRow.Cells(2).Text
        TextBox2.Text = Gridview1.SelectedRow.Cells(3).Text
        TextBox3.Text = Gridview1.SelectedRow.Cells(4).Text


        For i = 0 To Dropdownlist1.Items.Count - 1
            If Dropdownlist1.Items(i).Value = Gridview1.SelectedRow.Cells(5).Text Then
                Dropdownlist1.SelectedIndex = i
            End If
        Next

        Dim chk As CheckBox = Gridview1.SelectedRow.Cells(7).Controls(0)
        If chk.Checked Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        Dim statusId = Gridview1.SelectedRow.Cells(1).Text
        Button2.Visible = False
        Button3.Visible = True
        Button4.Visible = True
    End Sub
    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim maxId = genf.returnvaluefromdv("Select max(id) from SupplierInfo", 0)
        Dim statusId = (Val(maxId) + 1).ToString()
        Dim status = 1
        If CheckBox1.Checked Then
            status = 1
        Else
            status = 0
        End If
        strnewrecord = "INSERT INTO SupplierInfo (Id,Name,Address,Mobile,supplier_type,status) values (" + statusId + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + Dropdownlist1.SelectedValue + "'," & status & ")"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        CheckBox1.Checked = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Dropdownlist1.SelectedIndex = 0
        Page_Load(sender, e)
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim statusId = Gridview1.SelectedRow.Cells(1).Text
        Dim status = 1
        If CheckBox1.Checked Then
            status = 1
        Else
            status = 0
        End If
        strnewrecord = "update SupplierInfo set Name='" & TextBox1.Text & "',Address='" & TextBox2.Text & "',Mobile='" & TextBox3.Text & "',supplier_type ='" & Dropdownlist1.SelectedValue & "',Status=" & status & " where Id=" & statusId & ""
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        CheckBox1.Checked = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Dropdownlist1.SelectedIndex = 0
        Page_Load(sender, e)
    End Sub
    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim statusId = Gridview1.SelectedRow.Cells(1).Text
        strnewrecord = "delete from SupplierInfo where Id=" & statusId & ""
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Button6.Visible = True
        CheckBox1.Checked = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Dropdownlist1.SelectedIndex = 0
        Page_Load(sender, e)
    End Sub

    'Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
    '    Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
    '    Myconnection.Open()

    '    strnewrecord = "INSERT INTO [Technician_master] ([technician_name],[contact_no],[mail_id],[expertise]) values ('" & TextBox1.Text.Replace("'", "''") & "','" & TextBox2.Text.Replace("'", "''") & "','" & TextBox3.Text.Replace("'", "''") & "','" & TextBox4.Text.Replace("'", "''") & "')"
    '    Mycommand = New SqlCommand(strnewrecord, Myconnection)
    '    Mycommand.ExecuteNonQuery()
    '    Myconnection.Close()
    '    Button6.Visible = True
    '    Page_Load(sender, e)

    'End Sub
End Class

