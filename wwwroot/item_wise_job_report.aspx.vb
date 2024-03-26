Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class item_wise_job_report
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
    Dim total1, total2, total3, total4, total5

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button2.Visible = True Then
            Button2.Visible = False
            TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy")
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        If CheckBox2.Checked = True Then
            whcls1 = " (status is not null and status='Job Completed')"
        End If

        If CheckBox3.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " or  (status is null)"
            Else
                whcls1 = " (status is null)"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " and (" & whcls1 & ")"
        End If

        If TextBox21.Text <> "" Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " and new_job_cart.job_id='" & Val(TextBox21.Text) & "'"
            Else
                whcls1 = " and new_job_cart.job_id='" & Val(TextBox21.Text) & "'"
            End If
        End If

        If TextBox22.Text <> "" Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " and new_job_cart.manual_ro='" & Trim(TextBox22.Text) & "'"
            Else
                whcls1 = " and new_job_cart.manual_ro='" & Trim(TextBox22.Text) & "'"
            End If
        End If

        Dim whcls
        whcls = "where new_job_cart.job_id=new_job_parts.job_id and vehicle_parts.id=new_job_parts.[Part_ID] and ((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or new_job_cart.[job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' or new_job_parts.[Part_ID] like '%" & TextBox12.Text & "%' or new_job_parts.[Part_no] like '%" & TextBox12.Text & "%')" & whcls1
        strnewrecord = "SELECT new_job_cart.[job_id] as [Job ID]"
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",[manual_ro] as [Manual RO]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",new_job_parts.[Part_ID] as [Parts ID]"
        strnewrecord = strnewrecord & ",new_job_parts.[Part_no] as [Parts No]"
        strnewrecord = strnewrecord & ",vehicle_parts.[description] as [Parts Description]"
        strnewrecord = strnewrecord & ",new_job_parts.[qty] as [Requisit Quantity]"
        strnewrecord = strnewrecord & ", (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity]"
        strnewrecord = strnewrecord & ", (select sum(j.amount) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Value]"

        strnewrecord = strnewrecord & ", '' as [Required Quantity]"
        strnewrecord = strnewrecord & ", '' as [Available Quantity]"
        strnewrecord = strnewrecord & " FROM [new_job_cart], new_job_parts, vehicle_parts " & whcls
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        genf.populate_grid(strnewrecord, GridView1)
        Myconnection.Close()

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(7).Text = genf.getdatetimefromdb(e.Row.Cells(7).Text)
            e.Row.Cells(8).Text = genf.getdatetimefromdb(e.Row.Cells(8).Text)


            Dim stock_qty, stock_value
            stock_qty = 0
            stock_value = 0
            strnewrecord = "SELECT sum(opening_qty), sum(opening_value) from vehicle_parts where id='" & Val(e.Row.Cells(17).Text) & "'  and datediff(day,opening_date,'" & DateTime.Now & "')>0"
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            dv1.Table = mydataset1.Tables(0)
            If dv1.Count > 0 Then
                stock_qty = stock_qty + Val(dv1(0)(0).ToString)
                '    stock_value = stock_value + Val(dv1(0)(1).ToString)
            End If
            dv1.Table.Clear()
            mydataset1.Tables.Clear()

            strnewrecord = "SELECT sum(qty), sum(total) from purchase_item where part_id='" & Val(e.Row.Cells(17).Text) & "'  and datediff(day,date,'" & DateTime.Now & "')>0"
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            dv1.Table = mydataset1.Tables(0)
            If dv1.Count > 0 Then
                stock_qty = stock_qty + Val(dv1(0)(0).ToString)
                ' stock_value = stock_value + Val(dv1(0)(1).ToString)
            End If
            dv1.Table.Clear()
            mydataset1.Tables.Clear()


            strnewrecord = "SELECT sum(qty), sum(total) from purchase_return where part_id='" & Val(e.Row.Cells(17).Text) & "'  and datediff(day,ret_date,'" & DateTime.Now & "')>0"
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            dv1.Table = mydataset1.Tables(0)
            If dv1.Count > 0 Then
                stock_qty = stock_qty - Val(dv1(0)(0).ToString)
                '  stock_value = stock_value - Val(dv1(0)(1).ToString)
            End If
            dv1.Table.Clear()
            mydataset1.Tables.Clear()


            strnewrecord = "SELECT sum(qty), sum(amount) from job_wise_item_issue where part_id='" & Val(e.Row.Cells(17).Text) & "'  and datediff(day,issue_date,'" & DateTime.Now & "')>0"
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            dv1.Table = mydataset1.Tables(0)
            If dv1.Count > 0 Then
                stock_qty = stock_qty - Val(dv1(0)(0).ToString)
                'stock_value = stock_value - Val(dv1(0)(1).ToString)
            End If
            dv1.Table.Clear()
            mydataset1.Tables.Clear()


           



            strnewrecord = "SELECT sum(qty), sum(amount) from job_wise_item_return where part_id='" & Val(e.Row.Cells(17).Text) & "'  and datediff(day,issue_date,'" & DateTime.Now & "')>0"
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            dv1.Table = mydataset1.Tables(0)
            If dv1.Count > 0 Then
                stock_qty = stock_qty - Val(dv1(0)(0).ToString)
                ' stock_value = stock_value - Val(dv1(0)(1).ToString)
            End If
            dv1.Table.Clear()
            mydataset1.Tables.Clear()


          



            strnewrecord = "SELECT sum(qty), sum(amount) from job_wise_item_return where part_id='" & Val(e.Row.Cells(17).Text) & "'  and datediff(day,issue_date,'" & DateTime.Now & "')>0"
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            dv1.Table = mydataset1.Tables(0)
            If dv1.Count > 0 Then
                stock_qty = stock_qty + Val(dv1(0)(0).ToString)
                ' stock_value = stock_value + Val(dv1(0)(1).ToString)
            End If
            dv1.Table.Clear()
            mydataset1.Tables.Clear()


           

            ' e.Row.Cells(5).Text = stock_qty
            '   e.Row.Cells(6).Text = rondup(stock_value)

            e.Row.Cells(24).Text = stock_qty
            e.Row.Cells(21).Text = Val(e.Row.Cells(21).Text)
            e.Row.Cells(22).Text = Val(e.Row.Cells(22).Text)
            e.Row.Cells(23).Text = Val(e.Row.Cells(20).Text) - Val(e.Row.Cells(21).Text)
            e.Row.Cells(20).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(21).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(22).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(23).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(24).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(22).Text = genf.roundup(Val(e.Row.Cells(22).Text))
            total1 = total1 + Val(e.Row.Cells(20).Text)
            total2 = total2 + Val(e.Row.Cells(21).Text)
            total3 = total3 + Val(e.Row.Cells(22).Text)
            total4 = total4 + Val(e.Row.Cells(23).Text)
            total5 = total5 + Val(e.Row.Cells(24).Text)

            If Val(e.Row.Cells(23).Text) > Val(e.Row.Cells(24).Text) Then
                e.Row.Cells(23).BackColor = Drawing.Color.Red
                e.Row.Cells(24).BackColor = Drawing.Color.Red
                e.Row.Cells(23).ForeColor = Drawing.Color.White
                e.Row.Cells(24).ForeColor = Drawing.Color.White
            End If

            e.Row.Cells(0).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(15).Visible = False
            '   e.Row.Cells(16).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(8).Visible = False




            'If Not IsNothing(Session("uid")) Then
            '    ' Label2.Text = Session("uid").ToString

            '    Dim genf As New genfunction

            '    Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
            '    'Response.Write(Trim(admin_type.ToString.ToUpper))

            '    If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
            '        e.Row.Cells(0).Visible = True
            '        '  e.Row.Cells(1).Visible = True
            '    Else
            '        e.Row.Cells(0).Visible = False
            '        ' e.Row.Cells(1).Visible = False
            '    End If

            'Else
            '    Response.Redirect("login.aspx")
            'End If
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(15).Visible = False
            '  e.Row.Cells(16).Visible = False
            e.Row.Cells(19).Visible = False



            'If Not IsNothing(Session("uid")) Then
            '    ' Label2.Text = Session("uid").ToString

            '    Dim genf As New genfunction

            '    Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
            '    'Response.Write(Trim(admin_type.ToString.ToUpper))

            '    If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
            '        e.Row.Cells(0).Visible = True
            '        '  e.Row.Cells(1).Visible = True
            '    Else
            '        e.Row.Cells(0).Visible = False
            '        ' e.Row.Cells(1).Visible = False
            '    End If

            'Else
            '    Response.Redirect("login.aspx")
            'End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(8).Visible = False
            e.Row.Cells(0).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(15).Visible = False
            '   e.Row.Cells(16).Visible = False

            e.Row.Cells(18).Text = "Total"
            e.Row.Cells(20).Text = total1
            e.Row.Cells(21).Text = total2
            e.Row.Cells(22).Text = total3
            e.Row.Cells(23).Text = total4
            e.Row.Cells(24).Text = total5
            e.Row.Cells(18).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(20).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(21).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(22).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(23).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(24).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(22).Text = genf.roundup(Val(e.Row.Cells(22).Text))



            'If Not IsNothing(Session("uid")) Then
            '    ' Label2.Text = Session("uid").ToString

            '    Dim genf As New genfunction

            '    Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
            '    'Response.Write(Trim(admin_type.ToString.ToUpper))

            '    If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
            '        e.Row.Cells(0).Visible = True
            '        '  e.Row.Cells(1).Visible = True
            '    Else
            '        e.Row.Cells(0).Visible = False
            '        ' e.Row.Cells(1).Visible = False
            '    End If

            'Else
            '    Response.Redirect("login.aspx")
            'End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('job_card.aspx?url=" & GridView1.SelectedRow.Cells(1).Text & "','Edit_job');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub
End Class
