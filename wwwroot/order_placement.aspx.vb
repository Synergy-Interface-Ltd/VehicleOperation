Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.IdentityModel.Protocols.WSTrust
Imports System.Runtime.Remoting
Imports CrystalDecisions.CrystalReports.Engine

Partial Class ordery_placement
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

        'If Page.IsPostBack Then
        '    Dim estimateId = Val(Request.QueryString("url"))
        '    If estimateId = 0 Then
        '        estimateId = Val(TextBox27.Text)
        '    End If
        '    Dim count = genf.returnvaluefromdv("select count(*) from estimate_order_placement where estimate_job_id=" & estimateId & "", 0)

        '    If Val(count) > 0 Then
        '        EditButton.Visible = True
        '        SubmitButton.Visible = False
        '    Else
        '        EditButton.Visible = False
        '        SubmitButton.Visible = True
        '    End If
        'End If


        If Button1.Visible = True Then

            Label30.Text = ""
            Label35.Text = ""

            Label31.Text = "Order Placement"
            Me.Title = "Order Placement"
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

                Label31.Text = "Order Palcement"
                Me.Title = "Order Placement"


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
                'strnewrecord = "select [estimate_new_job_parts].[part_id] as [Parts ID], [estimate_new_job_parts].[part_no]"
                'strnewrecord &= " as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as "
                'strnewrecord &= " [Description], [estimate_new_job_parts].[qty] as [Requisit Quantity], vehicle_parts.unit"
                'strnewrecord &= " as [Unit],price as [Price], total as [Total],(select [order_quantity] from "
                'strnewrecord &= " [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id And "
                'strnewrecord &= " [parts_id]=estimate_new_job_parts.[part_id]) as OrderLimit,(select (select Name from"
                'strnewrecord &= " orderstatus where id=[estimate_order_placement].[order_status])  from "
                'strnewrecord &= " [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id"
                'strnewrecord &= " And [parts_id]=estimate_new_job_parts.[part_id]) as Status,(select Format([order_date],"
                'strnewrecord &= " 'dd/MM/yyyy')  from [estimate_order_placement] where [estimate_job_id]="
                'strnewrecord &= " estimate_new_job_parts.job_id And [parts_id]=estimate_new_job_parts.[part_id]) as "
                'strnewrecord &= " [Order Date],(select Format([app_delivery_date],'dd/MM/yyyy')  from "
                'strnewrecord &= " [estimate_order_placement] where [estimate_job_id]=estimate_new_job_parts.job_id "
                'strnewrecord &= " And [parts_id]=estimate_new_job_parts.[part_id]) as ""App delivary date"","
                'strnewrecord &= " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id ) is null then '0' else"
                'strnewrecord &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=vehicle_parts.id) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
                'strnewrecord &= " where pu.part_id=vehicle_parts.id ) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=vehicle_parts.id) end) "
                'strnewrecord &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id) Is null then '0' else "
                'strnewrecord &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=vehicle_parts.id ) end)) as [Available Quantity]  FROM vehicle_parts where  vehicle_parts.id=[estimate_new_job_parts].[part_id] ) as ""Available Quantity"""
                'strnewrecord &= "  from "
                'strnewrecord &= " [estimate_new_job_parts], vehicle_parts where [estimate_new_job_parts].[part_id]="
                'strnewrecord &= " vehicle_parts.id And estimate_new_job_parts.job_id='" & Val(Request.QueryString("url")) & "' order by [Parts ID] "
                strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"","
                strnewrecord &= " PartName as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
                strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
                strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
                strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
                strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
                strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
                strnewrecord &= " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=e.parts_id ) is null then '0' else"
                strnewrecord &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=e.parts_id) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
                strnewrecord &= " where pu.part_id=e.parts_id) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=e.parts_id) end) "
                strnewrecord &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=e.parts_id) Is null then '0' else "
                strnewrecord &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=e.parts_id ) end))) as [Available Quantity], "
                strnewrecord &= " (case when order_quantity is null then e.order_request_qty else order_quantity end ) as OrderLimit, service_id,id from estimate_order_placement e where e.estimate_job_id= '" & Val(Request.QueryString("url")) & "' and e.parts_id!=0 order by e.parts_id"

                genf.populate_grid(strnewrecord, GridView1)


                'TextBox24.Text = Val(genf.returnvaluefromdv(strnewrecord1, 1).ToString)ggg
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





        If Not IsNothing(Session("uid")) Then

            Dim genf As New genfunction

            Dim admin_type = genf.returnvaluefromdv("Select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
            'Response.Write(Trim(admin_type.ToString.ToUpper))


        Else
            Response.Redirect("login.aspx")
        End If


        TextBox1.Focus()


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

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Label33.Text = Request.QueryString("url")
        Dim referenceBy = Session("uid")
        If TextBox27.Text <> "" Then


            total1 = 0
            total2 = 0

            'strnewrecord = "select estimate_job_part.job_id as [Issue ID], estimate_job_part.part_no as [Parts Name], vehicle_parts.description as [Description], estimate_job_part.qty as [Quantity], estimate_job_part.amount as [Price] from estimate_job_part, job_sheet, vehicle_parts where estimate_job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_job_part.part_id"
            'genf.populate_grid(strnewrecord, GridView8)

            Label31.Text = "Modify Order"
            Me.Title = "Modify Order"


            strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),   (select r.vbill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), tnc FROM [estimate_new_job_cart] where job_id='" & Val(TextBox27.Text) & "'"

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

            strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"","
            strnewrecord &= " PartName as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
            strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
            strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
            strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
            strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
            strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
            strnewrecord &= " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=e.parts_id ) is null then '0' else"
            strnewrecord &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=e.parts_id) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
            strnewrecord &= " where pu.part_id=e.parts_id) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=e.parts_id) end) "
            strnewrecord &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=e.parts_id) Is null then '0' else "
            strnewrecord &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=e.parts_id ) end))) as [Available Quantity], "
            strnewrecord &= " (case when order_quantity is null then e.order_request_qty else order_quantity end ) as OrderLimit, service_id,id from estimate_order_placement e where e.estimate_job_id= '" & Val(TextBox27.Text) & "' and e.parts_no= '" & TextBox15.Text.Trim() & "'  and LEN(e.parts_no)>3 order by e.parts_id"
            genf.populate_grid(strnewrecord, GridView1)

            UpdatePanel122.Update()

            'Dim i = 0
            'If GridView1.Rows.Count > 0 Then
            '    For i = 0 To i < GridView1.Rows.Count - 1
            '        If GridView1.Rows(i).Cells(7).Text <> "&nbsp;" Then
            '            EditButton.Visible = True
            '            SubmitButton.Visible = False
            '        Else
            '            EditButton.Visible = False
            '            SubmitButton.Visible = True
            '        End If
            '    Next
            'Else
            '    GridView1.DataSource = Nothing
            '    UpdatePanel122.Update()
            'End If
        Else

            strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"","
            strnewrecord &= " PartName as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
            strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
            strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
            strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
            strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
            strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
            strnewrecord &= " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=e.parts_id ) is null then '0' else"
            strnewrecord &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.id=e.parts_id) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
            strnewrecord &= " where pu.part_id=e.parts_id) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_id=e.parts_id) end) "
            strnewrecord &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=e.parts_id) Is null then '0' else "
            strnewrecord &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_id=e.parts_id ) end))) as [Available Quantity], "
            strnewrecord &= " (case when order_quantity is null then e.order_request_qty else order_quantity end ) as OrderLimit, service_id,id from estimate_order_placement e where e.reference_by= '" & referenceBy & "' and e.parts_no= '" & TextBox15.Text.Trim() & "' and LEN(e.parts_no)>3 order by e.parts_id"
            genf.populate_grid(strnewrecord, GridView1)

            UpdatePanel122.Update()

            'Dim i = 0
            'If GridView1.Rows.Count > 0 Then
            '    For i = 0 To i < GridView1.Rows.Count - 1
            '        If GridView1.Rows(i).Cells(7).Text <> "&nbsp;" Then
            '            EditButton.Visible = True
            '            SubmitButton.Visible = False
            '        Else
            '            EditButton.Visible = False
            '            SubmitButton.Visible = True
            '        End If
            '    Next
            'Else
            '    GridView1.DataSource = Nothing
            '    UpdatePanel122.Update()
            'End If
        End If



    End Sub


    Protected Sub Button10_Click(sender As Object, e As System.EventArgs) Handles Button10.Click
        Label33.Text = Request.QueryString("url")

        total1 = 0
        total2 = 0

        'strnewrecord = "select estimate_job_part.job_id as [Issue ID], estimate_job_part.part_no as [Parts Name], vehicle_parts.description as [Description], estimate_job_part.qty as [Quantity], estimate_job_part.amount as [Price] from estimate_job_part, job_sheet, vehicle_parts where estimate_job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_job_part.part_id"
        'genf.populate_grid(strnewrecord, GridView8)

        Label31.Text = "Modify Order"
        Me.Title = "Modify Order"


        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no),   (select r.vbill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), tnc FROM [estimate_new_job_cart] where job_id='" & Val(TextBox27.Text) & "'"

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


        Dim str = " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no ) is null then '0' else"
        str &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
        str &= " where pu.part_no=e.parts_no) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_no=e.parts_no) end) "
        str &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no) Is null then '0' else "
        str &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no ) end))) as [Available Quantity] "


        strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"","
        strnewrecord &= " PartName as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
        strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
        strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
        strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
        strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
        strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
        strnewrecord &= " " & str & ","

        strnewrecord &= " (case when order_quantity is null then e.order_request_qty else order_quantity end ) as OrderLimit, service_id,id from estimate_order_placement e where e.estimate_job_id= '" & Val(TextBox27.Text) & "' and LEN(e.parts_no)>5 order by e.parts_id"
        genf.populate_grid(strnewrecord, GridView1)

        UpdatePanel122.Update()


        'If Val(countOrdered) > 0 Then
        '    EditButton.Visible = True
        '    SubmitButton.Visible = False
        'Else
        '    EditButton.Visible = False
        '    SubmitButton.Visible = True
        'End If
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

        TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
        TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
        TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
        TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
        TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
        TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
        TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)

        Response.Redirect("job_against_chesis.aspx?id=" & Trim(TextBox12.Text) & "")
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

            TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
            TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
            TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
            TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
            TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
            TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
            TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)
            Dim id = genf.returnvaluefromdv(strnewrecord, 21)

            'Dim rsb1 As StringBuilder
            'rsb1 = New StringBuilder()
            'rsb1.Append("<script language=""JavaScript"">")
            'rsb1.Append("window.open('job_against_reg.aspx?id=" & Trim(TextBox9.Text) & "','print_estimate');")
            'rsb1.Append("</scri")
            'rsb1.Append("pt>")
            Response.Redirect("job_against_reg.aspx?id=" & Trim(TextBox9.Text) & "")
            'Context.Response.Write("<script language='javascript'>window.open('job_against_reg.aspx?id=" & Trim(TextBox9.Text) & "','_newtab');</script>")
            'Page.RegisterStartupScript("rtest1", rsb1.ToString())


        End If

    End Sub
    Dim submitted = False

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        e.Row.Cells(12).Visible = False
        e.Row.Cells(13).Visible = False
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim txt1 As New TextBox
            txt1 = e.Row.FindControl("TextBox1")

            If e.Row.Cells(7).Text <> "Submited" And e.Row.Cells(7).Text <> "&nbsp;" Then
                txt1.ReadOnly = True
            Else
                txt1.ReadOnly = False
            End If

        End If

        'If submitted = True Then
        '    SubmitButton.Visible = False
        '    EditButton.Visible = True
        'Else
        '    EditButton.Visible = False
        '    SubmitButton.Visible = True
        'End If
    End Sub
    Protected Sub SubmitButton_Click(sender As Object, e As System.EventArgs) Handles SubmitButton.Click

        Dim countOrdered = genf.returnvaluefromdv("select count(*) from estimate_order_placement where estimate_job_id='" & Val(TextBox27.Text) & "' and order_status!='' ", 0)

        If Val(countOrdered) = 0 Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()

            Dim estimateId = Label33.Text
            If estimateId = "" Then
                estimateId = TextBox27.Text
            End If
            Dim orderDate = DateTime.Now.ToString("MM/dd/yyyy")
            Dim referenceBy = Session("uid")



            For i = 0 To GridView1.Rows.Count - 1

                Dim txt1 As New TextBox
                txt1 = GridView1.Rows(i).FindControl("TextBox1")
                strnewrecord = "update estimate_order_placement set [reference_by]='" & referenceBy & "', order_quantity=" & txt1.Text & ",order_date='" & orderDate & "',order_status=1 where Id=" & GridView1.Rows(i).Cells(13).Text & ""
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            Next
            Myconnection.Close()
            Dim alertScript = "alert('This Order Has Been Inserted Succesfully ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

            Dim str = " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no ) is null then '0' else"
            str &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
            str &= " where pu.part_no=e.parts_no) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_no=e.parts_no) end) "
            str &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no) Is null then '0' else "
            str &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no ) end))) as [Available Quantity] "


            strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"","
            strnewrecord &= " PartName as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
            strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
            strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
            strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
            strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
            strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
            strnewrecord &= " " & str & ","

            strnewrecord &= " (case when order_quantity is null then e.order_request_qty else order_quantity end ) as OrderLimit, service_id,id from estimate_order_placement e where e.estimate_job_id= '" & Val(TextBox27.Text) & "' and LEN(e.parts_no)>3 order by e.parts_id"
            genf.populate_grid(strnewrecord, GridView1)

            UpdatePanel122.Update()
        Else
            Dim alertScript = "alert('You are already submitted the order ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        End If


    End Sub

    Protected Sub EditButton_Click(sender As Object, e As System.EventArgs) Handles EditButton.Click

        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim estimateId = Label33.Text

        If estimateId = "" Then
            estimateId = TextBox27.Text
        End If
        Dim orderDate = DateTime.Now.ToString("MM/dd/yyyy")
        Dim referenceBy = Session("uid")

        For i = 0 To GridView1.Rows.Count - 1
            If genf.checkexistancefromdv("select * from estimate_order_placement where [estimate_job_id]=" & estimateId & " And [PartName]='" & GridView1.Rows(i).Cells(2).Text & "' And order_status>1 ") Then
                Dim alertScript1 = "alert('This Order Already Placed ...');"
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript1, True)
            Else
                Dim txt1 As New TextBox
                txt1 = GridView1.Rows(i).FindControl("TextBox1")
                strnewrecord = "update estimate_order_placement set [reference_by]='" & referenceBy & "', order_quantity=" & txt1.Text & ",order_date='" & orderDate & "',order_status=1 where Id=" & GridView1.Rows(i).Cells(13).Text & ""
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next
        Dim alertScript11 = "alert('Successfully Updated the ordered ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript11, True)

        Myconnection.Close()
        Dim str = " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no ) is null then '0' else"
        str &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
        str &= " where pu.part_no=e.parts_no) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_no=e.parts_no) end) "
        str &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no) Is null then '0' else "
        str &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no ) end))) as [Available Quantity] "


        strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"","
        strnewrecord &= " PartName as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
        strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
        strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
        strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
        strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
        strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
        strnewrecord &= " " & str & ","

        strnewrecord &= " (case when order_quantity is null then e.order_request_qty else order_quantity end ) as OrderLimit, service_id,id from estimate_order_placement e where e.estimate_job_id= '" & Val(TextBox27.Text) & "' and LEN(e.parts_no)>5  order by e.parts_id"
        genf.populate_grid(strnewrecord, GridView1)
        UpdatePanel122.Update()
    End Sub
End Class

