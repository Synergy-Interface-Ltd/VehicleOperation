Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class job_report
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
        If Button2.Visible = True Then
            Button2.Visible = False
            TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy")
            CheckBox2.Checked = False
            CheckBox3.Checked = False

            CheckBox4.Checked = False
            CheckBox5.Checked = False

            CheckBox1.Checked = False
            CheckBox6.Checked = False
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

        Dim whcls
        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0))  and [customer_name] like '" & TextBox12.Text & "%') " & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(9).Text = genf.getdatetimefromdb(e.Row.Cells(9).Text)
            e.Row.Cells(10).Text = genf.getdatetimefromdb(e.Row.Cells(10).Text)
            strnewrecord = "select new_job_parts.[Part_ID] as [Parts ID]"
            strnewrecord = strnewrecord & ",new_job_parts.[Part_no] as [Parts No]"
            ' strnewrecord = strnewrecord & ",vehicle_parts.[description] as [Parts Description]"
            strnewrecord = strnewrecord & ",new_job_parts.[qty] as [Requisit Quantity]"
            strnewrecord = strnewrecord & ", (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity]"
            strnewrecord = strnewrecord & ", (select sum(j.amount) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Value]"

            strnewrecord = strnewrecord & ", new_job_parts.[qty]- (case when (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) is null then '0' else (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) end) as [Required Quantity]"
            strnewrecord = strnewrecord & " FROM new_job_parts, vehicle_parts where vehicle_parts.id=new_job_parts.[Part_ID] and new_job_parts.job_id='" & Val(e.Row.Cells(1).Text) & "'"
            e.Row.Cells(19).Text = genf.create_table(strnewrecord)

            strnewrecord = "select service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service], new_job_service.cost as [Total Value],new_job_service.technician_id as [Technician ID], technician_master.technician_name as [Technician Name], (case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks],spare as [Type] from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id  and new_job_service.job_id='" & Val(e.Row.Cells(1).Text) & "' and spare='Service' "
            If genf.checkexistancefromdv(strnewrecord) Then

                e.Row.Cells(20).Text = "<b>Service History:</b>" & genf.create_table(strnewrecord)

            End If

      
            strnewrecord = "SELECT [Tx_id] as [Tx ID],[description] as [Description],[qty] as [Quantity],[Price] as [Price] FROM [new_job_dent_paint] where job_id='" & Val(e.Row.Cells(1).Text) & "' order by [Tx_id] asc"
            If genf.checkexistancefromdv(strnewrecord) Then
                e.Row.Cells(20).Text = e.Row.Cells(20).Text & "<b>Dent and Paint:</b>" & genf.create_table(strnewrecord)

            End If
            strnewrecord = "select service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service], new_job_service.cost as [Total Value],new_job_service.technician_id as [Technician ID], technician_master.technician_name as [Technician Name], (case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks],spare as [Type] from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id  and new_job_service.job_id='" & Val(e.Row.Cells(1).Text) & "' and spare='Spare' "
            If genf.checkexistancefromdv(strnewrecord) Then

                e.Row.Cells(20).Text = e.Row.Cells(20).Text & "<b>Spare History:</b>" & genf.create_table(strnewrecord)

            End If



            e.Row.Cells(10).Visible = False
            e.Row.Cells(4).Visible = False


            If Not IsNothing(Session("uid")) Then
                ' Label2.Text = Session("uid").ToString

                Dim genf As New genfunction

                Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
                'Response.Write(Trim(admin_type.ToString.ToUpper))

                If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                    '           e.Row.Cells(0).Visible = True
                    '  e.Row.Cells(1).Visible = True
                Else
                    '            e.Row.Cells(0).Visible = False
                    ' e.Row.Cells(1).Visible = False
                End If

            Else
                Response.Redirect("login.aspx")
            End If

            Dim lnk2 As New LinkButton
            lnk2 = e.Row.FindControl("LinkButton2")
            If Val(genf.returnvaluefromdv("select count(*) from job_bill where job_id='" & Val(e.Row.Cells(1).Text) & "'", 0).ToString) = 0 Then
                lnk2.Visible = False
            Else
                lnk2.Visible = True
            End If

        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(10).Visible = False
            e.Row.Cells(4).Visible = False


            If Not IsNothing(Session("uid")) Then
                ' Label2.Text = Session("uid").ToString

                Dim genf As New genfunction

                Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
                'Response.Write(Trim(admin_type.ToString.ToUpper))

                If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                    e.Row.Cells(0).Visible = True
                    '  e.Row.Cells(1).Visible = True
                Else
                    e.Row.Cells(0).Visible = False
                    ' e.Row.Cells(1).Visible = False
                End If

            Else
                Response.Redirect("login.aspx")
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(10).Visible = False
            e.Row.Cells(4).Visible = False

            If Not IsNothing(Session("uid")) Then
                ' Label2.Text = Session("uid").ToString

                Dim genf As New genfunction

                Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
                'Response.Write(Trim(admin_type.ToString.ToUpper))

                If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                    e.Row.Cells(0).Visible = True
                    '  e.Row.Cells(1).Visible = True
                Else
                    e.Row.Cells(0).Visible = False
                    ' e.Row.Cells(1).Visible = False
                End If

            Else
                Response.Redirect("login.aspx")
            End If
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'If Button7.Text = "Print Bill" Then

        'Else
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        'If Val(Label48.Text) > 0 Then
        '    rsb1.Append("window.open('bill.aspx?url=" & Request.QueryString("url") & "&mode=Modification','gen_bill');")

        'Else
        rsb1.Append("window.open('print_bill.aspx?url=" & Val(GridView1.Rows(e.RowIndex).Cells(1).Text) & "','print_bill');")

        '   End If
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
        '  End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('job_card.aspx?url=" & GridView1.SelectedRow.Cells(1).Text & "','Edit_job');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click



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

        Dim whcls
        whcls = "where job_id='" & Val(TextBox21.Text) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"

        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button7_Click(sender As Object, e As System.EventArgs) Handles Button7.Click



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

        Dim whcls
        whcls = "where reg_no='" & Trim(DropDownList1.SelectedItem.Text) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"

        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button8_Click(sender As Object, e As System.EventArgs) Handles Button8.Click



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

        Dim whcls
        whcls = "where ((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0)) " & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"

        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button9_Click(sender As Object, e As System.EventArgs) Handles Button9.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        If CheckBox5.Checked = True Then
            whcls1 = " (status is not null and status='Job Completed')"
        End If

        If CheckBox4.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " or  (status is null)"
            Else
                whcls1 = " (status is null)"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " and (" & whcls1 & ")"
        End If

        Dim whcls
        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0))  and [customer_id]='" & Val(TextBox23.Text) & "') " & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button10_Click(sender As Object, e As System.EventArgs) Handles Button10.Click



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

        Dim whcls
        whcls = "where chesis_no='" & Trim(TextBox24.Text) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"

        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub TextBox22_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox22.TextChanged
        strnewrecord = "SELECT distinct [reg_no] FROM [new_job_cart] where reg_no like '%" & Trim(TextBox22.Text) & "%'"

        genf.populate_dropdownlist(strnewrecord, DropDownList1, "reg_no", "reg_no")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        If CheckBox6.Checked = True Then
            whcls1 = " (status is not null and status='Job Completed')"
        End If

        If CheckBox1.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " or  (status is null)"
            Else
                whcls1 = " (status is null)"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " and (" & whcls1 & ")"
        End If

        Dim whcls
        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0))  and [mobile] like '" & Trim(TextBox1.Text) & "%') " & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID], customer_id as [Customer ID] "
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name], engineer as [Engineer1]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        strnewrecord = strnewrecord & ",engineer as [Engineer]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History]"
        strnewrecord = strnewrecord & " FROM [new_job_cart] " & whcls & " and hstatus=1 and in_date > '2021/04/12' order by in_date"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub
End Class
