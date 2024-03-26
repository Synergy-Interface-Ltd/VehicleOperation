Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class sales_report_payment
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString3")
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
            'TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
            'TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy")
            CheckBox4.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If

        If CheckBox4.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            Else
                whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and (select n.customer_name from new_job_customer n where n.[Customer_ID]=new_job_cart.[Customer_ID]) like '" & TextBox12.Text & "%'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
        strnewrecord = strnewrecord & ",(select n.customer_name from new_job_customer n where n.[Customer_ID]=new_job_cart.[Customer_ID])  as [Customer Name]"
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
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1) select q1.[Customer ID] as [Customer ID]"
        '  Response.Write(strnewrecord)
        strnewrecord = strnewrecord & ",(select top 1 n.[customer_name] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Customer Name]"
        strnewrecord = strnewrecord & ",(select top 1 n.[address] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Address]"
        strnewrecord = strnewrecord & ",(select top 1 n.[email] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Email]"
        strnewrecord = strnewrecord & ",(select top 1 n.[tel] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Telephone No]"
        strnewrecord = strnewrecord & ",(select top 1 n.[mobile] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Mobile No]"

        strnewrecord = strnewrecord & ",sum(q1.Gross) as [Gross]"
        strnewrecord = strnewrecord & ",sum(q1.Vat) as [Vat]"
        strnewrecord = strnewrecord & ",sum(q1.[Invoiced Amount]) as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=q1.[customer id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=q1.[customer id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=q1.[customer id] and p.amount is not null) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment] from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub


    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
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

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('receive_payment.aspx?url=" & GridView1.SelectedRow.Cells(1).Text & "','receieve_payment');")
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
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If

        If CheckBox4.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            Else
                whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and [customer_id]='" & TextBox21.Text & "'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
        strnewrecord = strnewrecord & ",(select n.customer_name from new_job_customer n where n.[Customer_ID]=new_job_cart.[Customer_ID])  as [Customer Name]"
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
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment]"
        total1 = 0
        total2 = 0
        total3 = 0
        total4 = 0
        total5 = 0
        total6 = 0
        total7 = 0
        strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & " and [new_job_cart].hstatus=1) select q1.[Customer ID] as [Customer ID]"
        '  Response.Write(strnewrecord)
        strnewrecord = strnewrecord & ",(select top 1 n.[customer_name] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Customer Name]"
        strnewrecord = strnewrecord & ",(select top 1 n.[address] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Address]"
        strnewrecord = strnewrecord & ",(select top 1 n.[email] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Email]"
        strnewrecord = strnewrecord & ",(select top 1 n.[tel] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Telephone No]"
        strnewrecord = strnewrecord & ",(select top 1 n.[mobile] from new_job_cart n where n.customer_id=q1.[Customer ID]) as [Mobile No]"

        strnewrecord = strnewrecord & ",sum(q1.Gross) as [Gross]"
        strnewrecord = strnewrecord & ",sum(q1.Vat) as [Vat]"
        strnewrecord = strnewrecord & ",sum(q1.[Invoiced Amount]) as [Invoiced Amount]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=q1.[customer id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=q1.[customer id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=q1.[customer id] and p.amount is not null) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment] from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button7_Click(sender As Object, e As System.EventArgs) Handles Button7.Click



        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If

        If CheckBox5.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            Else
                whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no  and [Customer_id] in (select n.[Customer_id] from new_job_cart n where n.[Job_id]='" & Val(TextBox22.Text) & "')" 'and job_bill.r_bill_no is not null and [customer_id]='" & TextBox21.Text & "'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
        strnewrecord = strnewrecord & ",(select n.customer_name from new_job_customer n where n.[Customer_ID]=new_job_cart.[Customer_ID])  as [Customer Name]"
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
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Bounced Payment]"
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
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=q1.[customer id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=q1.[customer id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=q1.[customer id] and p.amount is not null) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment] from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button8_Click(sender As Object, e As System.EventArgs) Handles Button8.Click


        strnewrecord = ""

        Dim whcls1
        whcls1 = ""
        'If CheckBox2.Checked = True Then
        '    whcls1 = " (status is not null and status='Job Completed')"
        'End If

        If CheckBox6.Checked = True Then
            If whcls1 <> "" Then
                whcls1 = whcls1 & " and  (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            Else
                whcls1 = " (sum(q1.[Invoiced Amount])>(sum(q1.[Confirmed Payment]) + sum(q1.[Float Payment])))"
            End If

        End If

        If whcls1 <> "" Then
            whcls1 = " having (" & whcls1 & ")"
        End If

        Dim whcls
        whcls = "where [new_job_cart].bill_no=job_bill.bill_no  and new_job_cart.[customer_id] in (select n.[Customer_id] from new_job_cart n,job_bill m where n.bill_no=m.bill_no and m.r_bill_no='" & Trim(TextBox23.Text) & "')" 'and job_bill.r_bill_no is not null and [customer_id]='" & TextBox21.Text & "'" '& whcls1
        'If CheckBox4.Checked = True Then
        '    whcls = whcls & " and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)"
        'End If
        strnewrecord = "with q1 as (SELECT new_job_cart.[customer_id] as [Customer ID]"
        strnewrecord = strnewrecord & ",(select n.customer_name from new_job_customer n where n.[Customer_ID]=new_job_cart.[Customer_ID])  as [Customer Name]"
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
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=new_job_cart.[customer_id] and p.amount is not null) as [Bounced Payment]"
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
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Confirmed' and p.customer=q1.[customer id] and p.amount is not null) as [Confirmed Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Float' and p.customer=q1.[customer id] and p.amount is not null) as [Float Payment]"
        strnewrecord = strnewrecord & ",(select sum(p.amount) from payment p where p.status='Bounced' and p.customer=q1.[customer id] and p.amount is not null) as [Bounced Payment]"
        strnewrecord = strnewrecord & ",'0' as [Due Payment] from q1  group by q1.[Customer ID] " & whcls1 & " order by q1.[Customer ID]"



        genf.populate_grid(strnewrecord, GridView1)

        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub
End Class
