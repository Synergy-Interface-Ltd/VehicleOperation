Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.IdentityModel.Protocols.WSTrust
Imports System.Activities.Statements
Imports System.Drawing

Partial Class manage_order
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
    Dim total1, total2, total3

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Button1.Visible = True Then
            Label30.Text = ""
            Label35.Text = ""

            Label31.Text = "Manage Order"
            Me.Title = "Manage Order"
            Button1.Visible = False

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            TextBox14.Text = ""
            TextBox13.Text = ""
            genf.populate_dropdownlist("Select Id,Name from SupplierType where status=1", Dropdownlist5, "Name", "ID")
            genf.populate_dropdownlist("Select Id,Name from [SupplierInfo] where supplier_type =" & Dropdownlist5.Items(0).Value & " and status=1", Dropdownlist6, "Name", "ID")

            genf.populate_dropdownlist("Select Id,Name from orderstatus where status=1", StatusDropdown, "Name", "ID")
            genf.populate_dropdownlist("Select Id,Name from orderstatus where status=1", Dropdownlist7, "Name", "ID")


            TextBox6.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox7.Text = DateTime.Now.ToString("dd/MM/yyyy")


            DropDownList1.Items.Clear()
            DropDownList2.Items.Clear()
            DropDownList3.Items.Clear()
            DropDownList4.Items.Clear()
            Dim i
            For i = 0 To 23
                If i < 10 Then
                    DropDownList1.Items.Add("0" & i.ToString)
                    DropDownList3.Items.Add("0" & i.ToString)
                Else
                    DropDownList1.Items.Add(i)
                    DropDownList3.Items.Add(i)
                End If

            Next
            For i = 0 To 59
                If i < 10 Then
                    DropDownList2.Items.Add("0" & i.ToString)
                    DropDownList4.Items.Add("0" & i.ToString)
                Else
                    DropDownList2.Items.Add(i)
                    DropDownList4.Items.Add(i)
                End If

            Next

            DropDownList1.SelectedIndex = 0
            DropDownList2.SelectedIndex = 0
            DropDownList3.SelectedIndex = 0
            DropDownList4.SelectedIndex = 0
            Label33.Text = ""
            If Not IsNothing(Request.QueryString("url")) Then

                Label33.Text = Request.QueryString("url")
                total1 = 0
                total2 = 0

                'strnewrecord = "select estimate_job_part.job_id as [Issue ID], estimate_job_part.part_no as [Parts Name], vehicle_parts.description as [Description], estimate_job_part.qty as [Quantity], estimate_job_part.amount as [Price] from estimate_job_part, job_sheet, vehicle_parts where estimate_job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_job_part.part_id"
                'genf.populate_grid(strnewrecord, GridView8)

                Label31.Text = "Manage Order"
                Me.Title = "Manage Order"


                strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),   (select r.vbill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), tnc FROM [estimate_new_job_cart] where job_id='" & Val(Request.QueryString("url").ToString) & "'"

                'Dim strnewrecord1
                'strnewrecord1 = "SELECT bill_date, amount, pmnt_mode, chq_date, bank, cheque_no from estimate_payment where job_no='" & Val(Request.QueryString("url").ToString) & "' and b_type='Advance'"


                TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
                TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
                TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
                TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
                TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
                Dim dt1 As New DateTime
                dt1 = genf.returnvaluefromdv(strnewrecord, 5)
                TextBox6.Text = dt1.ToString("dd/MM/yyyy")
                Dim k
                For k = 0 To DropDownList1.Items.Count - 1
                    If Val(DropDownList1.Items(k).Text) = Val(dt1.ToString("HH")) Then
                        DropDownList1.SelectedIndex = k
                    End If
                Next
                For k = 0 To DropDownList2.Items.Count - 1
                    If Val(DropDownList2.Items(k).Text) = Val(dt1.ToString("mm")) Then
                        DropDownList2.SelectedIndex = k
                    End If
                Next

                Dim dt2 As New DateTime
                dt2 = genf.returnvaluefromdv(strnewrecord, 6)
                TextBox7.Text = dt2.ToString("dd/MM/yyyy")
                For k = 0 To DropDownList3.Items.Count - 1
                    If Val(DropDownList3.Items(k).Text) = Val(dt2.ToString("HH")) Then
                        DropDownList3.SelectedIndex = k
                    End If
                Next
                For k = 0 To DropDownList4.Items.Count - 1
                    If Val(DropDownList4.Items(k).Text) = Val(dt2.ToString("mm")) Then
                        DropDownList4.SelectedIndex = k
                    End If
                Next

                TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
                TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
                TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
                TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
                TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
                TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
                TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)



                Label30.Text = genf.returnvaluefromdv(strnewrecord, 16)
                strnewrecord = "Select  [id] ,[estimate_job_id],[parts_id] ,[parts_no],(select parts_name from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Name,(select description from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Description ,[order_quantity] ,Format([order_date],'dd/MM/yyyy') as order_date,Format([app_delivery_date],'dd/MM/yyyy') as app_delivery_date,'' as ""Supplier Type"",[supplier_id] ,'' as ""Supplier Name"",[reference_by],[placed_by],[order_status],'' as ""StatusId"" ,Format([store_order_date],'dd/MM/yyyy') as store_order_date,[status],(SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id ) is null then '0' else (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id) End) + (Case When (Select sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id ) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id) end)  - (Case When (Select sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id) Is null Then '0' else (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id ) end)) as [Available Quantity]  FROM vehicle_parts where  vehicle_parts.id=[parts_id]  ) as [Available Quantity] FROM [estimate_order_placement] e where e.estimate_job_id=" & Request.QueryString("url") & ""
                genf.populate_grid(strnewrecord, GridView1)


                'TextBox24.Text = Val(genf.returnvaluefromdv(strnewrecord1, 1).ToString)
            End If


            'For i = 0 To DropDownList6.Items.Count - 1
            '    If DropDownList6.Items(i).Text = genf.returnvaluefromdv(strnewrecord1, 2).ToString Then
            '        DropDownList6.SelectedIndex = i
            '    End If
            'Next
            'Try
            '    TextBox25.Text = genf.getdatefromdb(genf.returnvaluefromdv(strnewrecord1, 0).ToString).ToString("dd/MM/yyyy")

            'Catch ex As Exception

            'End Try
            'Try
            '    TextBox29.Text = genf.getdatefromdb(genf.returnvaluefromdv(strnewrecord1, 3).ToString).ToString("dd/MM/yyyy")

            'Catch ex As Exception

            'End Try
            'TextBox28.Text = genf.returnvaluefromdv(strnewrecord1, 4).ToString

            'TextBox26.Text = genf.returnvaluefromdv(strnewrecord1, 5).ToString

        End If


        'genf.populate_dropdownlist("Select Id,Name from SupplierType where status=1", Dropdownlist5, "Name", "ID")
        'genf.populate_dropdownlist("Select Id,Name from [SupplierInfo] where SupplierTypeId=" & Dropdownlist5.Items(0).Value & " and status=1", Dropdownlist6, "Name", "ID")

        'genf.populate_dropdownlist("Select Id,Name from orderstatus where status=1", StatusDropdown, "Name", "ID")
        'statusTable = genf.()
        'StatusDropdown.Items.Clear()
        'For i = 0 To statusTable.Rows.Count - 1
        '    StatusDropdown.Items.Add(New ListItem(statusTable.Rows(i)(1).ToString(), statusTable.Rows(i)(0).ToString()))
        'Next
        'StatusDropdown.DataBind()




        If Not IsNothing(Session("uid")) Then

            Dim genf As New genfunction

            Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
            'Response.Write(Trim(admin_type.ToString.ToUpper))
        Else
            Response.Redirect("login.aspx")
        End If


        TextBox1.Focus()


    End Sub



    Protected Sub Dropdownlist5_SelectedIndecChanged(sender As Object, e As System.EventArgs) Handles Dropdownlist5.SelectedIndexChanged
        genf.populate_dropdownlist("Select Id,Name from [SupplierInfo] where Supplier_type=" & Dropdownlist5.SelectedValue & " ", Dropdownlist6, "Name", "ID")
    End Sub
    Protected Sub Button21_Click(sender As Object, e As System.EventArgs) Handles Button21.Click
        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no) FROM [new_job_cart] where job_id='" & Val(TextBox45.Text) & "'"


        TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
        TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
        TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
        TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
        TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
        Dim dt1 As New DateTime
        dt1 = genf.returnvaluefromdv(strnewrecord, 5)


        TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
        TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
        TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
        TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
        TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
        TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
        TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)


        strnewrecord = "select [new_job_parts].[part_id] as [Parts ID], [new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [new_job_parts].[qty] as [Requisit Quantity],(select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity],'' as [Required Quantity], vehicle_parts.unit as [Unit], '0' as [Price], '0' as [Total] from [new_job_parts], vehicle_parts where [new_job_parts].[part_id]=vehicle_parts.id and new_job_parts.job_id='" & Val(TextBox45.Text) & "'"
        strnewrecord = strnewrecord & " union all select [job_part].[part_id] as [Parts ID], [job_part].[part_no] as [Parts No], vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], job_part.qty as [Requisit Quantity], '0' as [Issued Quantity], job_part.qty as [Required Quantity],vehicle_parts.unit  as [Unit], job_part.amount as [Price], job_part.amount * job_part.qty  as [Total] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(TextBox45.Text) & "' and vehicle_parts.id=job_part.part_id"

        genf.populate_grid(strnewrecord, GridView1)

    End Sub

    Protected Sub Button10_Click(sender As Object, e As System.EventArgs) Handles Button10.Click
        Label33.Text = Request.QueryString("url")

        total1 = 0
        total2 = 0

        'strnewrecord = "select estimate_job_part.job_id as [Issue ID], estimate_job_part.part_no as [Parts Name], vehicle_parts.description as [Description], estimate_job_part.qty as [Quantity], estimate_job_part.amount as [Price] from estimate_job_part, job_sheet, vehicle_parts where estimate_job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_job_part.part_id"
        'genf.populate_grid(strnewrecord, GridView8)

        Label31.Text = "Modify Estimate"
        Me.Title = "Modify Estimate"


        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),   (select r.vbill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), tnc FROM [estimate_new_job_cart] where job_id=" & TextBox27.Text & ""

        'Dim strnewrecord1
        'strnewrecord1 = "SELECT bill_date, amount, pmnt_mode, chq_date, bank, cheque_no from estimate_payment where job_no='" & Val(Request.QueryString("url").ToString) & "' and b_type='Advance'"


        TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
        TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
        TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
        TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
        TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
        Dim dt1 As New DateTime
        dt1 = genf.returnvaluefromdv(strnewrecord, 5)
        TextBox6.Text = dt1.ToString("dd/MM/yyyy")
        Dim k
        For k = 0 To DropDownList1.Items.Count - 1
            If Val(DropDownList1.Items(k).Text) = Val(dt1.ToString("HH")) Then
                DropDownList1.SelectedIndex = k
            End If
        Next
        For k = 0 To DropDownList2.Items.Count - 1
            If Val(DropDownList2.Items(k).Text) = Val(dt1.ToString("mm")) Then
                DropDownList2.SelectedIndex = k
            End If
        Next

        Dim dt2 As New DateTime
        dt2 = genf.returnvaluefromdv(strnewrecord, 6)
        TextBox7.Text = dt2.ToString("dd/MM/yyyy")
        For k = 0 To DropDownList3.Items.Count - 1
            If Val(DropDownList3.Items(k).Text) = Val(dt2.ToString("HH")) Then
                DropDownList3.SelectedIndex = k
            End If
        Next
        For k = 0 To DropDownList4.Items.Count - 1
            If Val(DropDownList4.Items(k).Text) = Val(dt2.ToString("mm")) Then
                DropDownList4.SelectedIndex = k
            End If
        Next

        TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
        TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
        TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
        TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
        TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
        TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
        TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)
        Label30.Text = genf.returnvaluefromdv(strnewrecord, 16)
        strnewrecord = "Select  [id] ,[estimate_job_id],[parts_id] ,[parts_no],(select parts_name from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Name,(select description from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Description ,[order_quantity] ,Format([order_date],'dd/MM/yyyy') as order_date,Format([app_delivery_date],'dd/MM/yyyy') as app_delivery_date,'' as ""Supplier Type"",[supplier_id] ,'' as ""Supplier Name"",[reference_by],[placed_by],[order_status],'' as ""StatusId"" ,Format([store_order_date],'dd/MM/yyyy') as store_order_date,[status],(SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id ) is null then '0' else (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id) End) + (Case When (Select sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id ) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id) end)  - (Case When (Select sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id) Is null Then '0' else (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id ) end)) as [Available Quantity]  FROM vehicle_parts where  vehicle_parts.id=[parts_id]  ) as [Available Quantity] FROM [estimate_order_placement] e where e.estimate_job_id=" & Trim(TextBox27.Text) & ""

        genf.populate_grid(strnewrecord, GridView1)
        UpdatePanel122.Update()


    End Sub

    Protected Sub Button20_Click(sender As Object, e As System.EventArgs) Handles Button20.Click
        strnewrecord = "SELECT top 1 [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),job_id FROM [estimate_new_job_cart] where chesis_no='" & Trim(TextBox12.Text) & "' order by job_id desc"
        TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
        TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
        TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
        TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
        TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
        Dim dt1 As New DateTime
        dt1 = genf.returnvaluefromdv(strnewrecord, 5)
        'TextBox6.Text = dt1.ToString("dd/MM/yyyy")
        'Dim k
        'For k = 0 To DropDownList1.Items.Count - 1
        '    If Val(DropDownList1.Items(k).Text) = Val(dt1.ToString("HH")) Then
        '        DropDownList1.SelectedIndex = k
        '    End If
        'Next
        'For k = 0 To DropDownList2.Items.Count - 1
        '    If Val(DropDownList2.Items(k).Text) = Val(dt1.ToString("mm")) Then
        '        DropDownList2.SelectedIndex = k
        '    End If
        'Next

        'Dim dt2 As New DateTime
        'dt2 = genf.returnvaluefromdv(strnewrecord, 6)
        'TextBox7.Text = dt2.ToString("dd/MM/yyyy")
        'For k = 0 To DropDownList3.Items.Count - 1
        '    If Val(DropDownList3.Items(k).Text) = Val(dt2.ToString("HH")) Then
        '        DropDownList3.SelectedIndex = k
        '    End If
        'Next
        'For k = 0 To DropDownList4.Items.Count - 1
        '    If Val(DropDownList4.Items(k).Text) = Val(dt2.ToString("mm")) Then
        '        DropDownList4.SelectedIndex = k
        '    End If
        'Next

        TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
        TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
        TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
        TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
        TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
        TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
        TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)
    End Sub

    Protected Sub Button8_Click(sender As Object, e As System.EventArgs) Handles Button8.Click
        strnewrecord = "SELECT distinct [reg_no] FROM [estimate_new_job_cart] where reg_no like '%" & Trim(TextBox9.Text) & "%'"

        genf.populate_dropdownlist(strnewrecord, DropDownList10, "reg_no", "reg_no")

        If DropDownList10.Items.Count > 0 Then
            TextBox9.Text = DropDownList10.Items(0).Text

            strnewrecord = "SELECT top 1 [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),job_id FROM [estimate_new_job_cart] where reg_no='" & Trim(TextBox9.Text) & "' order by job_id desc"
            TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
            TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
            TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
            TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
            TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
            Dim dt1 As New DateTime
            dt1 = genf.returnvaluefromdv(strnewrecord, 5)
            'TextBox6.Text = dt1.ToString("dd/MM/yyyy")
            'Dim k
            'For k = 0 To DropDownList1.Items.Count - 1
            '    If Val(DropDownList1.Items(k).Text) = Val(dt1.ToString("HH")) Then
            '        DropDownList1.SelectedIndex = k
            '    End If
            'Next
            'For k = 0 To DropDownList2.Items.Count - 1
            '    If Val(DropDownList2.Items(k).Text) = Val(dt1.ToString("mm")) Then
            '        DropDownList2.SelectedIndex = k
            '    End If
            'Next

            'Dim dt2 As New DateTime
            'dt2 = genf.returnvaluefromdv(strnewrecord, 6)
            'TextBox7.Text = dt2.ToString("dd/MM/yyyy")
            'For k = 0 To DropDownList3.Items.Count - 1
            '    If Val(DropDownList3.Items(k).Text) = Val(dt2.ToString("HH")) Then
            '        DropDownList3.SelectedIndex = k
            '    End If
            'Next
            'For k = 0 To DropDownList4.Items.Count - 1
            '    If Val(DropDownList4.Items(k).Text) = Val(dt2.ToString("mm")) Then
            '        DropDownList4.SelectedIndex = k
            '    End If
            'Next

            TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
            TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
            TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
            TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
            TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
            TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
            TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)
        End If

    End Sub

    'Protected Sub SubmitButton_Click(sender As Object, e As System.EventArgs) Handles SubmitButton.Click
    '    Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
    '    Myconnection.Open()

    '    Dim estimateId = Label33.Text
    '    Dim orderDate = DateTime.Now.ToString("dd/MM/yyyy")
    '    Dim referenceBy = Session("uid")

    '    For i = 0 To GridView1.Rows.Count - 1
    '        Dim maxId = genf.returnvaluefromdv("Select max(id) from estimate_order_placement", 0)
    '        Dim Id = (Val(maxId) + 1).ToString()
    '        Dim txt1 As New TextBox
    '        txt1 = GridView1.Rows(i).FindControl("TextBox1")
    '        If Val(txt1.Text) > 0 Or txt1.Text <> "" Then
    '            strnewrecord = "INSERT INTO estimate_order_placement ([Id],[estimate_job_id],[parts_id],[parts_no],"
    '            strnewrecord &= " [order_quantity],[order_date],[app_delivery_date],[supplier_id],[reference_by],[placed_by],[order_status], "
    '            strnewrecord &= " [store_order_date],[status]) values ( " & Id & "," & estimateId & "," & Val(GridView1.Rows(i).Cells(0).Text) & ","
    '            strnewrecord &= " '" & GridView1.Rows(i).Cells(1).Text & "'," & Val(txt1.Text) & ", '" & orderDate & "',null,null,'" & referenceBy & "',"
    '            strnewrecord &= " null,1,null,0)"
    '            Mycommand = New SqlCommand(strnewrecord, Myconnection)
    '            Mycommand.ExecuteNonQuery()
    '        End If
    '    Next
    '    Myconnection.Close()
    '    Dim alertScript = "alert('This Order Has Been Inserted Succesfully ...');"
    '    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
    '    strnewrecord = "select [estimate_new_job_parts].[part_id] as [Parts ID], [estimate_new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [estimate_new_job_parts].[qty] as [Requisit Quantity], vehicle_parts.unit as [Unit],price as [Price], total as [Total],(select [order_quantity] from [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id and [parts_id]=estimate_new_job_parts.[part_id]) as OrderLimit,(select (select Name from orderstatus where id=[estimate_order_placement].[order_status])  from [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id and [parts_id]=estimate_new_job_parts.[part_id]) as Status from [estimate_new_job_parts], vehicle_parts where [estimate_new_job_parts].[part_id]=vehicle_parts.id and estimate_new_job_parts.job_id='" & Val(Request.QueryString("url")) & "'"
    '    genf.populate_grid(strnewrecord, GridView1)
    '    Page_Load(sender, e)
    'End Sub

    'Protected Sub EditButton_Click(sender As Object, e As System.EventArgs) Handles EditButton.Click
    '    Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
    '    Myconnection.Open()

    '    Dim estimateId = Label33.Text
    '    Dim orderDate = DateTime.Now.ToString("dd/MM/yyyy")
    '    Dim referenceBy = Session("uid")

    '    For i = 0 To GridView1.Rows.Count - 1
    '        If genf.checkexistancefromdv("select * from estimate_order_placement where [estimate_job_id]=" & estimateId & " and [parts_id]=" & Val(GridView1.Rows(i).Cells(0).Text) & " and status=1") Then
    '            Dim alertScript1 = "alert('This Order Already Placed ...');"
    '            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript1, True)
    '        Else
    '            strnewrecord = "delete from estimate_order_placement where [estimate_job_id]=" & estimateId & " and [parts_id]=" & Val(GridView1.Rows(i).Cells(0).Text) & " "
    '            Mycommand = New SqlCommand(strnewrecord, Myconnection)
    '            Mycommand.ExecuteNonQuery()
    '            Dim maxId = genf.returnvaluefromdv("Select max(id) from estimate_order_placement", 0)
    '            Dim Id = (Val(maxId) + 1).ToString()
    '            Dim txt1 As New TextBox
    '            txt1 = GridView1.Rows(i).FindControl("TextBox1")
    '            If Val(txt1.Text) > 0 Or txt1.Text <> "" Then
    '                strnewrecord = "INSERT INTO estimate_order_placement ([Id],[estimate_job_id],[parts_id],[parts_no],"
    '                strnewrecord &= " [order_quantity],[order_date],[app_delivery_date],[supplier_id],[reference_by],[placed_by],[order_status], "
    '                strnewrecord &= " [store_order_date],[status]) values ( " & Id & "," & estimateId & "," & Val(GridView1.Rows(i).Cells(0).Text) & ","
    '                strnewrecord &= " '" & GridView1.Rows(i).Cells(1).Text & "'," & Val(txt1.Text) & ", '" & orderDate & "',null,null,'" & referenceBy & "',"
    '                strnewrecord &= " null,1,null,1)"
    '                Mycommand = New SqlCommand(strnewrecord, Myconnection)
    '                Mycommand.ExecuteNonQuery()

    '                Dim alertScript = "alert('This Order Has Been Edited Succesfully ...');"
    '                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
    '            End If
    '        End If
    '    Next
    '    Myconnection.Close()
    '    strnewrecord = "select [estimate_new_job_parts].[part_id] as [Parts ID], [estimate_new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [estimate_new_job_parts].[qty] as [Requisit Quantity], vehicle_parts.unit as [Unit],price as [Price], total as [Total],(select [order_quantity] from [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id and [parts_id]=estimate_new_job_parts.[part_id]) as OrderLimit,(select (select Name from orderstatus where id=[estimate_order_placement].[order_status])  from [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id and [parts_id]=estimate_new_job_parts.[part_id]) as Status from [estimate_new_job_parts], vehicle_parts where [estimate_new_job_parts].[part_id]=vehicle_parts.id and estimate_new_job_parts.job_id='" & Val(Request.QueryString("url")) & "'"
    '    genf.populate_grid(strnewrecord, GridView1)
    '    Page_Load(sender, e)
    'End Sub

    Protected Sub OrderSearchButton_Click(sender As Object, e As System.EventArgs) Handles OrderSearchButton.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        strnewrecord = "Select  [id] ,[estimate_job_id],[parts_id] ,[parts_no],(select parts_name from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Name,(select description from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Description ,[order_quantity] ,Format([order_date],'dd/MM/yyyy') as order_date,Format([app_delivery_date],'dd/MM/yyyy') as app_delivery_date,'' as ""Supplier Type"",[supplier_id] ,'' as ""Supplier Name"",[reference_by],[placed_by],[order_status],'' as ""StatusId"" ,Format([store_order_date],'dd/MM/yyyy') as store_order_date,[status],(SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id ) is null then '0' else (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id) End) + (Case When (Select sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id ) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id) end)  - (Case When (Select sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id) Is null Then '0' else (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id ) end)) as [Available Quantity]  FROM vehicle_parts where  vehicle_parts.id=[parts_id]  ) as [Available Quantity] FROM [estimate_order_placement] e where   e.id=" & TextBox16.Text & ""

        genf.populate_grid(strnewrecord, GridView1)
        UpdatePanel122.Update()
        Myconnection.Close()
    End Sub

    Protected Sub StatusButton_Click(sender As Object, e As System.EventArgs) Handles StatusButton.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        strnewrecord = "Select  [id] ,[estimate_job_id],[parts_id] ,[parts_no],(select parts_name from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Name,(select description from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Description ,[order_quantity] ,Format([order_date],'dd/MM/yyyy') as order_date,Format([app_delivery_date],'dd/MM/yyyy') as app_delivery_date,'' as ""Supplier Type"",[supplier_id] ,'' as ""Supplier Name"",[reference_by],[placed_by],[order_status],'' as ""StatusId"" ,Format([store_order_date],'dd/MM/yyyy') as store_order_date,[status],(SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id ) is null then '0' else (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id) End) + (Case When (Select sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id ) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id) end)  - (Case When (Select sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id) Is null Then '0' else (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id ) end)) as [Available Quantity]  FROM vehicle_parts where  vehicle_parts.id=[parts_id]  ) as [Available Quantity] FROM [estimate_order_placement] e where  e.order_status=" & StatusDropdown.SelectedValue & ""
        genf.populate_grid(strnewrecord, GridView1)
        UpdatePanel122.Update()
        Myconnection.Close()
    End Sub
    Protected Sub GridView1_SelectedRowChange(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        OrderId.Text = GridView1.SelectedRow.Cells(1).Text
        JobId.Text = GridView1.SelectedRow.Cells(2).Text
        PartId.Text = GridView1.SelectedRow.Cells(3).Text
        PartNo.Text = GridView1.SelectedRow.Cells(4).Text
        PartName.Text = GridView1.SelectedRow.Cells(5).Text
        TextBox15.Text = GridView1.SelectedRow.Cells(10).Text

        For k = 0 To Dropdownlist5.Items.Count - 1
            If Dropdownlist5.Items(k).Text = GridView1.SelectedRow.Cells(11).Text Then
                Dropdownlist5.SelectedIndex = k
            End If
        Next

        genf.populate_dropdownlist("Select Id,Name from [SupplierInfo] where Supplier_Type=" & Dropdownlist5.SelectedValue & " ", Dropdownlist6, "Name", "ID")

        For k = 0 To Dropdownlist6.Items.Count - 1
            If Dropdownlist6.Items(k).Value = GridView1.SelectedRow.Cells(12).Text Then
                Dropdownlist6.SelectedIndex = k
            End If
        Next

        For k = 0 To Dropdownlist7.Items.Count - 1
            If Dropdownlist7.Items(k).Value = GridView1.SelectedRow.Cells(17).Text Then
                Dropdownlist7.SelectedIndex = k
            End If
        Next
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        strnewrecord = "Update estimate_order_placement set app_delivery_date='" & genf.getdate(TextBox15.Text).ToString("MM/dd/yyyy") & "',"
        strnewrecord &= "supplier_id=" & Dropdownlist6.SelectedValue & ",placed_by='" & Session("uid") & "',order_status=" & Dropdownlist7.SelectedValue & ","
        strnewrecord &= "store_order_date='" & DateTime.Now.ToString("MM/dd/yyyy") & "',status=1 where id=" & OrderId.Text & ""
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Dim alertScript = "alert('This Order Status Has Been Succesfully Changed ... and Your Order Id is " & OrderId.Text & "');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        strnewrecord = "Select  [id] ,[estimate_job_id],[parts_id] ,[parts_no],(select parts_name from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Name,(select description from vehicle_parts v where v.id=e.parts_id and v.part_no=e.parts_no) as Description ,[order_quantity] ,Format([order_date],'dd/MM/yyyy') as order_date,Format([app_delivery_date],'dd/MM/yyyy') as app_delivery_date,'' as ""Supplier Type"",[supplier_id] ,'' as ""Supplier Name"",[reference_by],[placed_by],[order_status],'' as ""StatusId"" ,Format([store_order_date],'dd/MM/yyyy') as store_order_date,[status],(SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id ) is null then '0' else (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id) End) + (Case When (Select sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id ) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id) end)  - (Case When (Select sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id) Is null Then '0' else (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id ) end)) as [Available Quantity]  FROM vehicle_parts where  vehicle_parts.id=[parts_id]  ) as [Available Quantity] FROM [estimate_order_placement] e where e.estimate_job_id=" & Trim(TextBox27.Text) & ""

        genf.populate_grid(strnewrecord, GridView1)
        Myconnection.Close()
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        e.Row.Cells(12).Visible = False
        e.Row.Cells(17).Visible = False
        If e.Row.RowType = DataControlRowType.DataRow Then

            'e.Row.Cells(1).Visible = False
            'e.Row.Cells(15).Visible = False
            'e.Row.Cells(18).Visible = False
            If e.Row.Cells(12).Text <> "" And e.Row.Cells(12).Text <> "&nbsp;" Then
                e.Row.Cells(11).Text = genf.returnvaluefromdv("select Name from SupplierType where id=(select Supplier_type from SupplierInfo where Id=" & e.Row.Cells(12).Text & " )", 0)
                e.Row.Cells(13).Text = genf.returnvaluefromdv("select Name from SupplierInfo where Id=" & e.Row.Cells(12).Text & " ", 0)
            End If
            If e.Row.Cells(17).Text <> "" And e.Row.Cells(17).Text <> "&nbsp;" Then
                e.Row.Cells(16).Text = genf.returnvaluefromdv("select Name from OrderStatus where Id=" & e.Row.Cells(17).Text & " ", 0)
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            'e.Row.Cells(11).Visible = False
            'e.Row.Cells(15).Visible = False
            'e.Row.Cells(18).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            'e.Row.Cells(11).Visible = False
            'e.Row.Cells(15).Visible = False
            'e.Row.Cells(18).Visible = False
        End If
    End Sub


End Class

