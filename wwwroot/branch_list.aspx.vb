Imports System.Data
Imports system.data.SqlClient
Partial Class masters_branch_list
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim Myconnection As SqlConnection
    Dim Mycommand, Mycommand1 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim mynewrecord1, strnewrecord As String
    Dim Mydataadapter, Mydataadapter1 As SqlDataAdapter
    Dim dv, dv1 As New DataView
    Dim mydataset, mydataset1 As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Button5.Visible = True Then

            Session("approval") = Nothing
            Session("voucher_no") = Nothing
            If Trim(LCase(Session("uid"))) = "vehiclesolution" Then
                Panel2.Visible = True
            Else
                Panel2.Visible = False
            End If
            Panel2.Visible = False
            TextBox1.Text = Request.QueryString("url")
            Button5.Visible = False
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()
            If Session("uid").ToString.ToLower = "vehiclesolution" Then
                Mycommand = New SqlCommand("select distinct Branch_id,convert(nvarchar(max),Branch_id) + ' - ' + branch_name as [branch_name] from branch order by Branch_id asc", Myconnection)
                Label1.Visible = True



            Else
                Mycommand = New SqlCommand("select distinct Branch_id,convert(nvarchar(max),Branch_id) + ' - ' + branch_name as [branch_name] from branch where (Branch_id='" & Request.Cookies("branch_code").Value & "')  order by Branch_id asc", Myconnection)
                Label1.Visible = False


            End If

            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            DropDownList1.DataSource = mydataset.Tables(0)
            DropDownList1.DataTextField = "branch_name"
            DropDownList1.DataValueField = "Branch_id"
            DropDownList1.DataBind()
            mydataset.Tables.Clear()
            Myconnection.Close()
            If DropDownList1.Items.Count > 0 Then
                DropDownList1.SelectedIndex = 0

            End If
            If DropDownList1.Items.Count = 1 Then
                Response.Cookies("branch_code").Value = DropDownList1.SelectedValue.ToString
                Response.Cookies("branch_code").Expires = Today.AddDays(1)
                Response.Cookies("branch_name").Value = DropDownList1.SelectedItem.Text
                Response.Cookies("branch_name").Expires = Today.AddDays(1)
                Response.Cookies("zone_code").Value = 0
                Response.Cookies("zone_code").Expires = Today.AddDays(1)
                Response.Cookies("zone_name").Value = "-"
                Response.Cookies("zone_name").Expires = Today.AddDays(1)
               

                If Not IsNothing(Request.QueryString("unit")) Then
                    Response.Redirect(TextBox1.Text & "?unit=" & Request.QueryString("unit").ToString)
                Else
                    Response.Redirect(TextBox1.Text)

                End If
            End If
            DropDownList1.Focus()

        End If
    End Sub








    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Mycommand = New SqlCommand("select distinct unit_master.Branch_code as [branch_code],convert(nvarchar(max),branch_master.Branch_code) + ' - ' + branch_name as [branch_name] from branch_master, unit_master where unit_master.branch_code=branch_master.branch_code and agent_code='" & TextBox3.Text & "' order by branch_code asc", Myconnection)
        Mydataadapter = New SqlDataAdapter(Mycommand)
        Mydataadapter.Fill(mydataset, "admin")
        DropDownList1.DataSource = mydataset.Tables(0)
        DropDownList1.DataTextField = "branch_name"
        DropDownList1.DataValueField = "branch_code"
        DropDownList1.DataBind()
        mydataset.Tables.Clear()
        If DropDownList1.Items.Count > 0 Then
            'GridView1.HeaderRow.Cells(1).Text = "RAC Code"
            ' GridView1.HeaderRow.Cells(2).Text = "RAC Name"
            '  GridView1.HeaderRow.Cells(3).Text = "Mail ID"
            'GridView1.HeaderRow.Cells(4).Text = "Contact"
            ' 'GridView1.HeaderRow.Cells(5).Text = "Reg Date"
            'GridView1.HeaderRow.Cells(6).Text = "User ID"
            'GridView1.HeaderRow.Cells(7).Text = "Password"
            Session("bmcode") = TextBox3.Text


        End If


        Myconnection.Close()

        If DropDownList1.Items.Count > 0 Then
            DropDownList1.SelectedIndex = 0

        End If
        If DropDownList1.Items.Count = 1 Then
            Response.Cookies("branch_code").Value = DropDownList1.SelectedValue.ToString
            Response.Cookies("branch_code").Expires = Today.AddDays(1)
            Response.Cookies("branch_name").Value = DropDownList1.SelectedItem.Text
            Response.Cookies("branch_name").Expires = Today.AddDays(1)
            Response.Cookies("zone_code").Value = 0
            Response.Cookies("zone_code").Expires = Today.AddDays(1)
            Response.Cookies("zone_name").Value = "-"
            Response.Cookies("zone_name").Expires = Today.AddDays(1)

            'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            'Myconnection.Open()

            'Mycommand = New SqlCommand("select distinct zone_code, zone_name from   branch_master where branch_code='" & DropDownList1.SelectedValue.ToString & "'", Myconnection)
            'Mydataadapter = New SqlDataAdapter(Mycommand)
            'Mydataadapter.Fill(mydataset, "admin")
            'dv.Table = mydataset.Tables(0)
            'If dv.Count > 0 Then
            '    Response.Cookies("zone_code").Value = dv(0)(0).ToString
            '    Response.Cookies("zone_code").Expires = Today.AddDays(1)
            '    Response.Cookies("zone_name").Value = dv(0)(1).ToString
            '    Response.Cookies("zone_name").Expires = Today.AddDays(1)

            'End If
            'dv.Table.Clear()
            'mydataset.Tables.Clear()
            'Myconnection.Close()


            If Not IsNothing(Request.QueryString("unit")) Then
                Response.Redirect(TextBox1.Text & "?unit=" & Request.QueryString("unit").ToString)
            Else
                Response.Redirect(TextBox1.Text)

            End If
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Mycommand = New SqlCommand("select distinct Branch_code1 as [branch_code],convert(nvarchar(max),Branch_code) + ' - ' + branch_name as [branch_name] from branch_master, agent_scheme where branch_code1=branch_code and policy='" & TextBox4.Text & "' order by branch_code asc", Myconnection)
        Mydataadapter = New SqlDataAdapter(Mycommand)
        Mydataadapter.Fill(mydataset, "admin")
        DropDownList1.DataSource = mydataset.Tables(0)
        DropDownList1.DataTextField = "branch_name"
        DropDownList1.DataValueField = "branch_code"
        DropDownList1.DataBind()
        mydataset.Tables.Clear()
        If DropDownList1.Items.Count > 0 Then
            ' GridView1.HeaderRow.Cells(1).Text = "RAC Code"
            '  GridView1.HeaderRow.Cells(2).Text = "RAC Name"
            ' GridView1.HeaderRow.Cells(3).Text = "Mail ID"
            ' GridView1.HeaderRow.Cells(4).Text = "Contact"
            ' GridView1.HeaderRow.Cells(5).Text = "Reg Date"
            ' GridView1.HeaderRow.Cells(6).Text = "User ID"
            ' GridView1.HeaderRow.Cells(7).Text = "Password"
            Session("bplc") = TextBox3.Text


        End If

        Myconnection.Close()

        If DropDownList1.Items.Count > 0 Then
            DropDownList1.SelectedIndex = 0

        End If
        If DropDownList1.Items.Count = 1 Then
            Response.Cookies("branch_code").Value = DropDownList1.SelectedValue.ToString
            Response.Cookies("branch_code").Expires = Today.AddDays(1)
            Response.Cookies("branch_name").Value = DropDownList1.SelectedItem.Text
            Response.Cookies("branch_name").Expires = Today.AddDays(1)
            Response.Cookies("zone_code").Value = 0
            Response.Cookies("zone_code").Expires = Today.AddDays(1)
            Response.Cookies("zone_name").Value = "-"
            Response.Cookies("zone_name").Expires = Today.AddDays(1)
            'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            'Myconnection.Open()

            'Mycommand = New SqlCommand("select distinct zone_code, zone_name from   branch_master where branch_code='" & DropDownList1.SelectedValue.ToString & "'", Myconnection)
            'Mydataadapter = New SqlDataAdapter(Mycommand)
            'Mydataadapter.Fill(mydataset, "admin")
            'dv.Table = mydataset.Tables(0)
            'If dv.Count > 0 Then
            '    Response.Cookies("zone_code").Value = dv(0)(0).ToString
            '    Response.Cookies("zone_code").Expires = Today.AddDays(1)
            '    Response.Cookies("zone_name").Value = dv(0)(1).ToString
            '    Response.Cookies("zone_name").Expires = Today.AddDays(1)

            'End If
            'dv.Table.Clear()
            'mydataset.Tables.Clear()
            'Myconnection.Close()
            If Not IsNothing(Request.QueryString("unit")) Then
                Response.Redirect(TextBox1.Text & "?unit=" & Request.QueryString("unit").ToString)
            Else
                Response.Redirect(TextBox1.Text)

            End If
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Response.Cookies("branch_code").Value = DropDownList1.SelectedValue.ToString
        Response.Cookies("branch_code").Expires = Today.AddDays(1)
        Response.Cookies("branch_name").Value = DropDownList1.SelectedItem.Text
        Response.Cookies("branch_name").Expires = Today.AddDays(1)
        Response.Cookies("zone_code").Value = 0
        Response.Cookies("zone_code").Expires = Today.AddDays(1)
        Response.Cookies("zone_name").Value = "-"
        Response.Cookies("zone_name").Expires = Today.AddDays(1)
        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        'Mycommand = New SqlCommand("select distinct zone_code, zone_name from   branch_master where branch_code='" & DropDownList1.SelectedValue.ToString & "'", Myconnection)
        'Mydataadapter = New SqlDataAdapter(Mycommand)
        'Mydataadapter.Fill(mydataset, "admin")
        'dv.Table = mydataset.Tables(0)
        'If dv.Count > 0 Then
        '    Response.Cookies("zone_code").Value = dv(0)(0).ToString
        '    Response.Cookies("zone_code").Expires = Today.AddDays(1)
        '    Response.Cookies("zone_name").Value = dv(0)(1).ToString
        '    Response.Cookies("zone_name").Expires = Today.AddDays(1)

        'End If
        'dv.Table.Clear()
        'mydataset.Tables.Clear()
        'Myconnection.Close()
        If Not IsNothing(Request.QueryString("unit")) Then
            Response.Redirect(TextBox1.Text & "?unit=" & Request.QueryString("unit").ToString)
        Else
            Response.Redirect(TextBox1.Text)

        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Response.Cookies("branch_code").Value = DropDownList1.SelectedValue.ToString
        Response.Cookies("branch_code").Expires = Today.AddDays(1)
        Response.Cookies("branch_name").Value = DropDownList1.SelectedItem.Text
        Response.Cookies("branch_name").Expires = Today.AddDays(1)

        Response.Cookies("zone_code").Value = 0
        Response.Cookies("zone_code").Expires = Today.AddDays(1)
        Response.Cookies("zone_name").Value = "-"
        Response.Cookies("zone_name").Expires = Today.AddDays(1)

        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        'Mycommand = New SqlCommand("select distinct zone_code, zone_name from   branch_master where branch_code='" & DropDownList1.SelectedValue.ToString & "'", Myconnection)
        'Mydataadapter = New SqlDataAdapter(Mycommand)
        'Mydataadapter.Fill(mydataset, "admin")
        'dv.Table = mydataset.Tables(0)
        'If dv.Count > 0 Then
        '    Response.Cookies("zone_code").Value = dv(0)(0).ToString
        '    Response.Cookies("zone_code").Expires = Today.AddDays(1)
        '    Response.Cookies("zone_name").Value = dv(0)(1).ToString
        '    Response.Cookies("zone_name").Expires = Today.AddDays(1)

        'End If
        'dv.Table.Clear()
        'mydataset.Tables.Clear()
        'Myconnection.Close()
        If Not IsNothing(Request.QueryString("unit")) Then
            Response.Redirect(TextBox1.Text & "?unit=" & Request.QueryString("unit").ToString)
        Else
            Response.Redirect(TextBox1.Text)

        End If
    End Sub
End Class
