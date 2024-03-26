Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class customer_wise_sales_report
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
            'CheckBox2.Checked = False
            'CheckBox3.Checked = False
            DropDownList1.Items.Clear()
            DropDownList1.Items.Add("-")
            DropDownList1.Items.Add("Individual")
            DropDownList1.Items.Add("Corporate")
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

        whcls = "where (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) ) and customer in (select c.customer_id from new_job_customer c where c.[customer_name] like '" & TextBox12.Text & "%') )" & whcls1










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
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
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
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Confirmed' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Confirmed' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Float' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Float' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Float Payment]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Bounced' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Bounced' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1) select q1.[Customer ID] as [Customer ID]"

        strnewrecord = strnewrecord & ",(select top 1 n.[customer_name] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Customer Name]"
        strnewrecord = strnewrecord & ",(select top 1 n.[address] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Address]"
        strnewrecord = strnewrecord & ",(select top 1 n.[email] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Email]"
        strnewrecord = strnewrecord & ",(select top 1 n.[tel] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Telephone No]"
        strnewrecord = strnewrecord & ",(select top 1 n.[mobile] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Mobile No]"

        strnewrecord = strnewrecord & ",sum(q1.Gross) as [Gross]"
        strnewrecord = strnewrecord & ",sum(q1.Vat) as [Vat]"
        strnewrecord = strnewrecord & ",sum(q1.[Invoiced Amount]) as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",sum(q1.[Confirmed Payment]) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",sum(q1.[Float Payment]) as [Float Payment]"
        strnewrecord = strnewrecord & ",sum(q1.[Bounced Payment]) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        strnewrecord = strnewrecord & ",(select top 1 n.[sales_executive] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Sales Executive]"
        strnewrecord = strnewrecord & ",(select top 1 n.[type_of_customer] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Type of Customer]"
        strnewrecord = strnewrecord & " from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView3)
        'If GridView3.Rows.Count > 0 Then
        '    ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div4', 'ctl00_ContentPlaceHolder1_GridView3', 'Div3');</Script>")
        'End If
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
        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and new_job_cart.job_id='" & Val(TextBox21.Text) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        ' whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0) ) and [customer_name] like '" & TextBox12.Text & "%' )" & whcls1









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
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and new_job_cart.job_id='" & Val(TextBox21.Text) & "'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
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
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Confirmed' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Confirmed' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Float' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Float' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Float Payment]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Bounced' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Bounced' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1) select q1.[Customer ID] as [Customer ID]"

        strnewrecord = strnewrecord & ",(select top 1 n.[customer_name] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Customer Name]"
        strnewrecord = strnewrecord & ",(select top 1 n.[address] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Address]"
        strnewrecord = strnewrecord & ",(select top 1 n.[email] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Email]"
        strnewrecord = strnewrecord & ",(select top 1 n.[tel] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Telephone No]"
        strnewrecord = strnewrecord & ",(select top 1 n.[mobile] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Mobile No]"

        strnewrecord = strnewrecord & ",sum(q1.Gross) as [Gross]"
        strnewrecord = strnewrecord & ",sum(q1.Vat) as [Vat]"
        strnewrecord = strnewrecord & ",sum(q1.[Invoiced Amount]) as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",sum(q1.[Confirmed Payment]) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",sum(q1.[Float Payment]) as [Float Payment]"
        strnewrecord = strnewrecord & ",sum(q1.[Bounced Payment]) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        strnewrecord = strnewrecord & ",(select top 1 n.[sales_executive] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Sales Executive]"
        strnewrecord = strnewrecord & ",(select top 1 n.[type_of_customer] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Type of Customer]"
        strnewrecord = strnewrecord & " from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView3)
        'If GridView3.Rows.Count > 0 Then
        '    ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div4', 'ctl00_ContentPlaceHolder1_GridView3', 'Div3');</Script>")
        'End If
    End Sub


    Protected Sub GridView3_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(7).Text = total1
            e.Row.Cells(8).Text = total2
            e.Row.Cells(9).Text = total3
            e.Row.Cells(10).Text = total4
            e.Row.Cells(11).Text = total5
            e.Row.Cells(12).Text = total6
            e.Row.Cells(13).Text = total7


            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(8).Text = genf.roundup(Val(e.Row.Cells(8).Text))
            e.Row.Cells(9).Text = genf.roundup(Val(e.Row.Cells(9).Text))
            e.Row.Cells(10).Text = genf.roundup(Val(e.Row.Cells(10).Text))
            e.Row.Cells(11).Text = genf.roundup(Val(e.Row.Cells(11).Text))
            e.Row.Cells(12).Text = genf.roundup(Val(e.Row.Cells(12).Text))
            e.Row.Cells(13).Text = genf.roundup(Val(e.Row.Cells(13).Text))

            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(11).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(12).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(13).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).Text = "Total"
            e.Row.Cells(0).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(13).Text = Val(e.Row.Cells(9).Text) - Val(e.Row.Cells(10).Text)

            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(8).Text = genf.roundup(Val(e.Row.Cells(8).Text))
            e.Row.Cells(9).Text = genf.roundup(Val(e.Row.Cells(9).Text))
            e.Row.Cells(10).Text = genf.roundup(Val(e.Row.Cells(10).Text))
            e.Row.Cells(11).Text = genf.roundup(Val(e.Row.Cells(11).Text))
            e.Row.Cells(12).Text = genf.roundup(Val(e.Row.Cells(12).Text))
            e.Row.Cells(13).Text = genf.roundup(Val(e.Row.Cells(13).Text))

            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(11).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(12).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(13).HorizontalAlign = HorizontalAlign.Right



            total1 = total1 + Val(e.Row.Cells(7).Text)
            total2 = total2 + Val(e.Row.Cells(8).Text)
            total3 = total3 + Val(e.Row.Cells(9).Text)
            total4 = total4 + Val(e.Row.Cells(10).Text)
            total5 = total5 + Val(e.Row.Cells(11).Text)
            total6 = total6 + Val(e.Row.Cells(12).Text)
            total7 = total7 + Val(e.Row.Cells(13).Text)

            e.Row.Cells(0).Visible = False


        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
        End If
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView3.SelectedIndexChanged

    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""

        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and new_job_cart.job_id='" & Val(TextBox21.Text) & "'" '((datediff(day,'" & genf.getdate(TextBox4.Text) & "',[in_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[in_date])<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',[dlv_date])>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',[dlv_date])<=0) or [job_id] like '%" & TextBox12.Text & "%' or [customer_name] like '%" & TextBox12.Text & "%' or [address] like '%" & TextBox12.Text & "%' or [email] like '%" & TextBox12.Text & "%' or [tel] like '%" & TextBox12.Text & "%' or [mobile] like '%" & TextBox12.Text & "%' or [manual_ro] like '%" & TextBox12.Text & "%' or [vehicle] like '%" & TextBox12.Text & "%' or [reg_no] like '%" & TextBox12.Text & "%' or [model] like '%" & TextBox12.Text & "%' or [eng_no] like '%" & TextBox12.Text & "%' or [chesis_no] like '%" & TextBox12.Text & "%' or [km] like '%" & TextBox12.Text & "%' )" & whcls1
        ' whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (((datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0) ) and [customer_name] like '" & TextBox12.Text & "%' )" & whcls1









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

        Dim whcls11 = ""
        If DropDownList1.SelectedItem.Text = "-" Then
            whcls11 = ""
        Else
            whcls11 = " and type_of_customer='" & DropDownList1.SelectedItem.Text & "'"
        End If

        '  Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and new_job_cart.sales_executive like '" & Trim(TextBox2.Text) & "%' " & whcls11  '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
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
        strnewrecord = strnewrecord & ",job_bill.r_bill_no as [Bill No]"
        strnewrecord = strnewrecord & ",job_bill.bill_date as [Bill Date]"
        strnewrecord = strnewrecord & ",job_bill.gross as [Gross]"
        strnewrecord = strnewrecord & ",job_bill.vat as [Vat]"
        strnewrecord = strnewrecord & ",job_bill.payable+advance as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Confirmed' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Confirmed' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Float' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Float' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Float Payment]"
        strnewrecord = strnewrecord & ",(case when (select sum(p.amount) from payment p where p.status='Bounced' and p.bill_no=job_bill.r_bill_no and p.amount is not null) is null then '0' else (select sum(p.amount) from payment p where p.status='Bounced' and p.bill_no=job_bill.r_bill_no and p.amount is not null) end) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1) select q1.[Customer ID] as [Customer ID]"

        strnewrecord = strnewrecord & ",(select top 1 n.[customer_name] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Customer Name]"
        strnewrecord = strnewrecord & ",(select top 1 n.[address] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Address]"
        strnewrecord = strnewrecord & ",(select top 1 n.[email] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Email]"
        strnewrecord = strnewrecord & ",(select top 1 n.[tel] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Telephone No]"
        strnewrecord = strnewrecord & ",(select top 1 n.[mobile] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Mobile No]"

        strnewrecord = strnewrecord & ",sum(q1.Gross) as [Gross]"
        strnewrecord = strnewrecord & ",sum(q1.Vat) as [Vat]"
        strnewrecord = strnewrecord & ",sum(q1.[Invoiced Amount]) as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",sum(q1.[Confirmed Payment]) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",sum(q1.[Float Payment]) as [Float Payment]"
        strnewrecord = strnewrecord & ",sum(q1.[Bounced Payment]) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        strnewrecord = strnewrecord & ",(select top 1 n.[sales_executive] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Sales Executive]"
        strnewrecord = strnewrecord & ",(select top 1 n.[type_of_customer] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Type of Customer]"
        strnewrecord = strnewrecord & " from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView3)
        'If GridView3.Rows.Count > 0 Then
        '    ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('Div4', 'ctl00_ContentPlaceHolder1_GridView3', 'Div3');</Script>")
        'End If
    End Sub
End Class

