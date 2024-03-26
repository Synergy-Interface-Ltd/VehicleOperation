Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class estimate_report
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
        strnewrecord = "SELECT [job_id] as [Estimate ID]"
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"
        'strnewrecord = strnewrecord & ",[in_date] as [Date In]"
        'strnewrecord = strnewrecord & ",[dlv_date] as [Delivery Date]"
        'strnewrecord = strnewrecord & ",[manual_ro] as [Manual RO]"
        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"
        strnewrecord = strnewrecord & ",[km] as [KM]"
        '  strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History], tnc as [Terms & Condition]"
        strnewrecord = strnewrecord & " FROM [estimate_new_job_cart] " & whcls
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells(7).Text = genf.getdatetimefromdb(e.Row.Cells(7).Text)
            'e.Row.Cells(8).Text = genf.getdatetimefromdb(e.Row.Cells(8).Text)
            strnewrecord = "select [estimate_new_job_parts].[Part_ID] as [Parts ID]"
            strnewrecord = strnewrecord & ",[estimate_new_job_parts].[Part_no] as [Parts No]"
            ' strnewrecord = strnewrecord & ",vehicle_parts.[description] as [Parts Description]"
            strnewrecord = strnewrecord & ",[estimate_new_job_parts].[qty] as [Requisit Quantity], price as [Price], total as [Total]"
            'strnewrecord = strnewrecord & ", (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=[estimate_new_job_parts].job_id and j.part_id=[estimate_new_job_parts].part_id) as [Issued Quantity]"
            'strnewrecord = strnewrecord & ", (select sum(j.amount) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=[estimate_new_job_parts].job_id and j.part_id=[estimate_new_job_parts].part_id) as [Issued Value]"

            '  strnewrecord = strnewrecord & ", [estimate_new_job_parts].[qty]- (case when (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=[estimate_new_job_parts].job_id and j.part_id=[estimate_new_job_parts].part_id) is null then '0' else (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=[estimate_new_job_parts].job_id and j.part_id=[estimate_new_job_parts].part_id) end) as [Required Quantity]"
            strnewrecord = strnewrecord & " FROM [estimate_new_job_parts], vehicle_parts where vehicle_parts.id=[estimate_new_job_parts].[Part_ID] and [estimate_new_job_parts].job_id='" & Val(e.Row.Cells(1).Text) & "'"
            e.Row.Cells(13).Text = genf.create_table(strnewrecord)


            strnewrecord = "select service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], [estimate_new_job_service].unit_cost as [Service Charge], [estimate_new_job_service].qty as [Qty of Service], [estimate_new_job_service].cost as [Total Value], spare as [Type] from [estimate_new_job_service], service_master where [estimate_new_job_service].service_id=service_master.service_id  and [estimate_new_job_service].job_id='" & Val(e.Row.Cells(1).Text) & "' "
            e.Row.Cells(14).Text = genf.create_table(strnewrecord)
            e.Row.Cells(15).Text = Server.HtmlDecode(e.Row.Cells(15).Text.Replace(Environment.NewLine, "<br>"))



            If Not IsNothing(Session("uid")) Then
                ' Label2.Text = Session("uid").ToString

                Dim genf As New genfunction

                Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
                'Response.Write(Trim(admin_type.ToString.ToUpper))

                If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                    '  e.Row.Cells(0).Visible = True
                    '  e.Row.Cells(1).Visible = True
                Else
                    '  e.Row.Cells(0).Visible = False
                    ' e.Row.Cells(1).Visible = False
                End If

            Else
                Response.Redirect("login.aspx")
            End If
        End If
        If e.Row.RowType = DataControlRowType.Header Then
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

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('estimate.aspx?url=" & GridView1.SelectedRow.Cells(1).Text & "','Edit_estimate');")
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
        strnewrecord = "SELECT [job_id] as [Job ID]"
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
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History], tnc as [Terms & Condition]"
        strnewrecord = strnewrecord & " FROM [estimate_new_job_cart] " & whcls
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
        strnewrecord = "SELECT [job_id] as [Job ID]"
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
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History], tnc as [Terms & Condition]"
        strnewrecord = strnewrecord & " FROM [estimate_new_job_cart] " & whcls
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub TextBox22_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox22.TextChanged
        strnewrecord = "SELECT distinct [reg_no] FROM [new_job_cart] where reg_no like '%" & Trim(TextBox22.Text) & "%'"

        genf.populate_dropdownlist(strnewrecord, DropDownList1, "reg_no", "reg_no")
    End Sub

    Protected Sub Button8_Click(sender As Object, e As System.EventArgs) Handles Button8.Click
        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no) FROM [new_job_cart] where job_id='" & Val(TextBox23.Text) & "'"

        Dim reg_no
        reg_no = genf.returnvaluefromdv(strnewrecord, 9)
       




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
        whcls = "where reg_no='" & Trim(reg_no.ToString) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        strnewrecord = "SELECT [job_id] as [Job ID]"
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
        strnewrecord = strnewrecord & ",'' as [Item History]"
        strnewrecord = strnewrecord & ",'' as [Service History], tnc as [Terms & Condition]"
        strnewrecord = strnewrecord & " FROM [estimate_new_job_cart] " & whcls
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If


    End Sub
End Class

