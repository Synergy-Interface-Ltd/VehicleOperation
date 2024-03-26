Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class sales_report
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
    Dim total1, total2, total3, total4, total5, total6, total7

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button2.Visible = True Then
            Button2.Visible = False
            TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy")
            CheckBox1.Checked = False

            DropDownList1.Items.Clear()
            DropDownList1.Items.Add("-")
            DropDownList1.Items.Add("Individual")
            DropDownList1.Items.Add("Corporate")
            'CheckBox2.Checked = False
            'CheckBox3.Checked = False
        End If
    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If

        'If CheckBox3.Checked = True Then
        '    If whcls1 <> "" Then
        '        whcls1 = whcls1 & " or  (status is null)"
        '    Else
        '        whcls1 = " (status is null)"
        '    End If

        'End If

        'If whcls1 <> "" Then
        '    whcls1 = " and (" & whcls1 & ")"
        'End If

        Dim whcls
        If CheckBox1.Checked = False Then
            whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0) ) and [customer_name] like '" & TextBox12.Text & "%' )" & whcls1

        Else
            whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and ([customer_name] like '" & TextBox12.Text & "%' )" & whcls1

        End If



        Dim pdwhcls
        If CheckBox1.Checked = False Then
            pdwhcls = "where [job_payment].[Job ID]=new_job_cart.[job_id] and job_payment.txno=payment.tx_no and ((datediff(day,'" & genf.getdate(TextBox4.Text) & "',payment.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',payment.bill_date)<=0) )"

        Else
            pdwhcls = "where [job_payment].[Job ID]=new_job_cart.[job_id] and job_payment.txno=payment.tx_no"

        End If




        strnewrecord = "SELECT new_job_cart.[job_id] as [Job ID]"
        strnewrecord = strnewrecord & ",new_job_cart.[customer_ID] as [Customer ID]"
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"

        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"

        strnewrecord = strnewrecord & ",(case when [new_job_cart].[status] is null then 'Job Has Not Been Started Yet' else [new_job_cart].[status] end) as [Status]"
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount],(select sum(job_payment.amount) from job_payment, payment " & pdwhcls & ") as [Paid Amount],'' as [Due Amount],sales_executive  as [Sales Executive],type_of_customer  as [Type of Customer]"
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1 and job_bill.bill_date>'2021/04/12'"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If

        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) ) and customer in (select c.customer_id from new_job_customer c where c.[customer_name] like '" & TextBox12.Text & "%') )" & whcls1

        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], job_payment.amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],payment.status as [Status],[Job ID],[Bill], (select Customer_Name from new_job_customer where customer_id=customer) as [Customer],(select n.sales_executive from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Sales Executive],(select n.type_of_customer from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Type of Customer] from payment, job_payment " & whcls & " and txno=tx_no and job_payment.hstatus=1 and bill_date>'2021/04/12'", GridView2)
        If GridView2.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div2', 'ctl00_ContentPlaceHolder1_GridView2', 'Div1');</Script>")
        End If









        strnewrecord = ""

        ' Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If


        If whcls1 <> "" Then
            whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        Else
            whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        End If



        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        '  Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and [customer_name] like '" & TextBox12.Text & "%'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(18).Text = total1
            e.Row.Cells(16).Text = total2
            e.Row.Cells(17).Text = total3
            e.Row.Cells(19).Text = total4
            e.Row.Cells(20).Text = total5



            e.Row.Cells(18).Text = genf.roundup(Val(e.Row.Cells(18).Text))
            e.Row.Cells(16).Text = genf.roundup(Val(e.Row.Cells(16).Text))
            e.Row.Cells(17).Text = genf.roundup(Val(e.Row.Cells(17).Text))
            e.Row.Cells(19).Text = genf.roundup(Val(e.Row.Cells(19).Text))
            e.Row.Cells(20).Text = genf.roundup(Val(e.Row.Cells(20).Text))

            e.Row.Cells(20).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(19).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(18).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(16).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(17).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(15).Text = "Total"
            e.Row.Cells(0).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(15).Text = genf.getdatetimefromdb(e.Row.Cells(15).Text)


            e.Row.Cells(18).Text = genf.roundup(Val(e.Row.Cells(18).Text))
            e.Row.Cells(16).Text = genf.roundup(Val(e.Row.Cells(16).Text))
            e.Row.Cells(17).Text = genf.roundup(Val(e.Row.Cells(17).Text))
            e.Row.Cells(19).Text = genf.roundup(Val(e.Row.Cells(19).Text))


            e.Row.Cells(18).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(16).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(17).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(20).Text = Val(e.Row.Cells(18).Text) - Val(e.Row.Cells(19).Text)
            e.Row.Cells(20).Text = genf.roundup(Val(e.Row.Cells(20).Text))
            e.Row.Cells(20).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(19).HorizontalAlign = HorizontalAlign.Right

            total1 = total1 + Val(e.Row.Cells(18).Text)
            total2 = total2 + Val(e.Row.Cells(16).Text)
            total3 = total3 + Val(e.Row.Cells(17).Text)
            total4 = total4 + Val(e.Row.Cells(19).Text)
            total5 = total5 + Val(e.Row.Cells(20).Text)

            'strnewrecord = "select new_job_parts.[Part_ID] as [Parts ID]"
            'strnewrecord = strnewrecord & ",new_job_parts.[Part_no] as [Parts No]"
            '' strnewrecord = strnewrecord & ",vehicle_parts.[description] as [Parts Description]"
            'strnewrecord = strnewrecord & ",new_job_parts.[qty] as [Requisit Quantity]"
            'strnewrecord = strnewrecord & ", (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity]"
            'strnewrecord = strnewrecord & ", (select sum(j.amount) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Value]"

            'strnewrecord = strnewrecord & ", new_job_parts.[qty]- (case when (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) is null then '0' else (select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) end) as [Required Quantity]"
            'strnewrecord = strnewrecord & " FROM new_job_parts, vehicle_parts where vehicle_parts.id=new_job_parts.[Part_ID] and new_job_parts.job_id='" & Val(e.Row.Cells(1).Text) & "'"
            'e.Row.Cells(17).Text = genf.create_table(strnewrecord)


            'strnewrecord = "select service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service], new_job_service.cost as [Total Value],new_job_service.technician_id as [Technician ID], technician_master.technician_name as [Technician Name], (case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks] from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id  and new_job_service.job_id='" & Val(e.Row.Cells(1).Text) & "' "
            'e.Row.Cells(18).Text = genf.create_table(strnewrecord)

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('receive_payment.aspx?url=" & GridView1.SelectedRow.Cells(17).Text & "&url1=" & GridView1.SelectedRow.Cells(1).Text & "','receieve_payment');")
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

        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and new_job_cart.job_id='" & Val(TextBox21.Text) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        ' whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0) ) and [customer_name] like '" & TextBox12.Text & "%' )" & whcls1


        Dim pdwhcls

        pdwhcls = "where [job_payment].[Job ID]=new_job_cart.[job_id] and job_payment.txno=payment.tx_no"





        strnewrecord = "SELECT new_job_cart.[job_id] as [Job ID]"
        strnewrecord = strnewrecord & ",new_job_cart.[customer_ID] as [Customer ID]"
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"

        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"

        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount],(select sum(job_payment.amount) from job_payment, payment " & pdwhcls & ") as [Paid Amount],'' as [Due Amount],sales_executive  as [Sales Executive],type_of_customer  as [Type of Customer]"

        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1 and job_bill.bill_date>'2021/04/12'"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If


        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) ) and customer in (select c.customer_id from new_job_customer c where c.[customer_name] like '" & TextBox12.Text & "%') )" & whcls1

        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], job_payment.amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],payment.status as [Status],[Job ID],[Bill], (select Customer_Name from new_job_customer where customer_id=customer) as [Customer],(select n.sales_executive from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Sales Executive],(select n.type_of_customer from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Type of Customer] from payment, job_payment " & whcls & " and txno=tx_no and job_payment.hstatus=1 and bill_date>'2021/04/12'", GridView2)
        If GridView2.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div2', 'ctl00_ContentPlaceHolder1_GridView2', 'Div1');</Script>")
        End If










        strnewrecord = ""

        ' Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If


        If whcls1 <> "" Then
            whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        Else
            whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        End If



        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        '  Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and [customer_name] like '" & TextBox12.Text & "%'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If

    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(6).Text = genf.getdatefromdb(e.Row.Cells(6).Text).ToString("dd/MM/yyyy")
            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right

            If e.Row.Cells(12).Text <> "Bounced" Then
                total1 = total1 + Val(e.Row.Cells(7).Text)
            End If

            If e.Row.Cells(5).Text = "Advance" Then
                e.Row.Cells(0).Enabled = False
                e.Row.Cells(0).Text = ""
            Else
                e.Row.Cells(0).Enabled = True
            End If

            Try
                e.Row.Cells(9).Text = genf.getdatefromdb(e.Row.Cells(9).Text).ToString("dd/MM/yyyy")
            Catch ex As Exception

            End Try
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(0).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(7).Text = total1
            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).Text = "Received Amount"
            '   e.Row.Cells(4).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(0).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            ' e.Row.Cells(4).Visible = False
            e.Row.Cells(0).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""

        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and job_bill.r_bill_no like '" & Trim(TextBox1.Text) & "%'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        ' whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0) ) and [customer_name] like '" & TextBox12.Text & "%' )" & whcls1


        Dim pdwhcls

        pdwhcls = "where [job_payment].[Job ID]=new_job_cart.[job_id] and job_payment.txno=payment.tx_no"





        strnewrecord = "SELECT new_job_cart.[job_id] as [Job ID]"
        strnewrecord = strnewrecord & ",new_job_cart.[customer_ID] as [Customer ID]"
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"

        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"

        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount],(select sum(job_payment.amount) from job_payment, payment " & pdwhcls & ") as [Paid Amount],'' as [Due Amount],sales_executive  as [Sales Executive],type_of_customer  as [Type of Customer]"

        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1 and job_bill.bill_date>'2021/04/12'"
        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If


        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) ) and customer in (select c.customer_id from new_job_customer c where c.[customer_name] like '" & TextBox12.Text & "%') )" & whcls1

        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], job_payment.amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],payment.status as [Status],[Job ID],[Bill], (select Customer_Name from new_job_customer where customer_id=customer) as [Customer],(select n.sales_executive from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Sales Executive],(select n.type_of_customer from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Type of Customer] from payment, job_payment " & whcls & " and txno=tx_no and job_payment.hstatus=1 and bill_date>'2021/04/12'", GridView2)
        If GridView2.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div2', 'ctl00_ContentPlaceHolder1_GridView2', 'Div1');</Script>")
        End If










        strnewrecord = ""

        ' Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If


        If whcls1 <> "" Then
            whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        Else
            whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        End If



        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        '  Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and [customer_name] like '" & TextBox12.Text & "%'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If

    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        Dim whcls11 = ""
        If DropDownList1.SelectedItem.Text = "-" Then
            whcls11 = ""
        Else
            whcls11 = " and type_of_customer='" & DropDownList1.SelectedItem.Text & "'"
        End If


        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and new_job_cart.sales_executive like '" & Trim(TextBox2.Text) & "%' " & whcls11 '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        ' whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0) ) and [customer_name] like '" & TextBox12.Text & "%' )" & whcls1


        Dim pdwhcls

        pdwhcls = "where [job_payment].[Job ID]=new_job_cart.[job_id] and job_payment.txno=payment.tx_no"





        strnewrecord = "SELECT new_job_cart.[job_id] as [Job ID]"
        strnewrecord = strnewrecord & ",new_job_cart.[customer_ID] as [Customer ID]"
        strnewrecord = strnewrecord & ",[customer_name] as [Customer Name]"
        strnewrecord = strnewrecord & ",[address] as [Address]"
        strnewrecord = strnewrecord & ",[email] as [Email]"
        strnewrecord = strnewrecord & ",[tel] as [Telephone No]"
        strnewrecord = strnewrecord & ",[mobile] as [Mobile No]"

        strnewrecord = strnewrecord & ",[vehicle] as [Vehicle]"
        strnewrecord = strnewrecord & ",[reg_no] as [Reg No]"
        strnewrecord = strnewrecord & " ,[model] as [Model]"
        strnewrecord = strnewrecord & ",[eng_no] as [Eng No]"
        strnewrecord = strnewrecord & ",[chesis_no] as [Chesis No]"

        strnewrecord = strnewrecord & ",(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end) as [Status]"
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount],(select sum(job_payment.amount) from job_payment, payment " & pdwhcls & ") as [Paid Amount],'' as [Due Amount],sales_executive  as [Sales Executive],type_of_customer  as [Type of Customer]"

        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1 and job_bill.bill_date>'2021/04/12'"
        genf.populate_grid(strnewrecord, GridView1)
        ' Response.Write(strnewrecord)
        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If


        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) ) and customer in (select c.customer_id from new_job_customer c where c.[customer_name] like '" & TextBox12.Text & "%') )" & whcls1

        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], job_payment.amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],payment.status as [Status],[Job ID],[Bill], (select Customer_Name from new_job_customer where customer_id=customer) as [Customer],(select n.sales_executive from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Sales Executive],(select n.type_of_customer from new_job_cart n where n.job_id=job_payment.[Job ID])  as [Type of Customer] from payment, job_payment " & whcls & " and txno=tx_no and job_payment.hstatus=1 and bill_date>'2021/04/12'", GridView2)
        If GridView2.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div2', 'ctl00_ContentPlaceHolder1_GridView2', 'Div1');</Script>")
        End If










        strnewrecord = ""

        ' Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If


        If whcls1 <> "" Then
            whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        Else
            whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
        End If



        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        '  Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and [customer_name] like '" & TextBox12.Text & "%'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If

    End Sub
End Class
