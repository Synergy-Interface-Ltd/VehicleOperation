Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class receive_payment
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim strconnection2 = ConfigurationSettings.AppSettings("ConnectionString2")
    Dim Myconnection, myconnection1, myconnection2 As SqlConnection

    Dim Mycommand, Mycommand1, Mycommand2, Mycommand10 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1, Mydataadapter2, Mydataadapter10 As SqlDataAdapter
    Dim dv, dv1, dv2, dv10 As New DataView
    Dim mydataset, mydataset1, mydataset2, mydataset10 As New DataSet
    Dim genf As New genfunction
    Dim total1, total2, total3
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button2.Visible = True Then
            Button2.Visible = False
            Button3.Visible = True
            Button4.Visible = False
            Button6.Visible = False
            Label22.Text = Request.Cookies("branch_code").Value
            Label23.Text = Request.Cookies("branch_name").Value

            Label6.Text = Request.QueryString("url").ToString


            strnewrecord = strnewrecord & "select [customer_name] as [Customer Name]"
            strnewrecord = strnewrecord & ",[address] as [Address]"
            strnewrecord = strnewrecord & ",[email] as [Email]"
            strnewrecord = strnewrecord & ",[tel] as [TNT No.]"
            strnewrecord = strnewrecord & ",[mobile] as [Mobile No] from new_job_customer where customer_id='" & Val(Label6.Text) & "'"
            genf.populate_grid(strnewrecord, GridView3)


            '  Label12.Text = Request.QueryString("url1").ToString
            TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox26.Text = DateTime.Now.ToString("dd/MM/yyyy")
            Label19.Text = ""
            Label20.Text = ""
            Label14.Text = ""
            TextBox27.Text = ""

            DropDownList1.Items.Clear()
            DropDownList1.Items.Add("Cash")
            DropDownList1.Items.Add("Cheque")
            DropDownList1.SelectedIndex = 0
            Dim whcls
                     ' genf.populate_grid(strnewrecord, GridView1)


            Label8.Text = ""
            whcls = "where [new_job_cart].bill_no=job_bill.bill_no and job_bill.r_bill_no is not null and [new_job_cart].customer_id='" & Val(Label6.Text) & "'"
            strnewrecord = "SELECT new_job_cart.[customer_id] as [Customer ID]"
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
            total1 = 0
            total2 = 0
            total3 = 0
           
            strnewrecord = strnewrecord & " FROM [new_job_cart], job_bill " & whcls & ""
            genf.populate_grid(strnewrecord, GridView2)
            Label8.Text = genf.roundup(Val(Label8.Text))




            Label10.Text = ""


            total1 = 0
            genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
            If GridView1.Rows.Count > 0 Then
                Label10.Text = Val(Label8.Text) - Val(GridView1.FooterRow.Cells(7).Text)
            Else
                Label10.Text = Val(Label8.Text)
            End If
            Label10.Text = genf.roundup(Val(Label10.Text))

        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
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

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(7).Text = total1
            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            Label10.Text = Val(Label8.Text) - Val(e.Row.Cells(7).Text)
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).Text = "Received Amount"
            '   e.Row.Cells(4).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            ' e.Row.Cells(4).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        TextBox26.Text = GridView1.SelectedRow.Cells(6).Text
        If GridView1.Rows.Count > 0 Then
            Label10.Text = Val(Label8.Text) - Val(GridView1.FooterRow.Cells(7).Text)
        Else
            Label10.Text = Val(Label8.Text)
        End If

        Label10.Text = (Val(Label10.Text)) + Val(GridView1.SelectedRow.Cells(7).Text)
        Label10.Text = genf.roundup(Val(Label10.Text))
        Label14.Text = GridView1.SelectedRow.Cells(7).Text
        Dim i
        For i = 0 To DropDownList1.Items.Count - 1
            If DropDownList1.Items(i).Text = GridView1.SelectedRow.Cells(8).Text Then
                DropDownList1.SelectedIndex = i
            End If
        Next
        If DropDownList1.SelectedItem.Text = "Cash" Then
            TextBox25.Text = "" 'GridView1.SelectedRow.Cells(9).Text
            Label19.Text = "" ' GridView1.SelectedRow.Cells(10).Text
            Label20.Text = "" 'GridView1.SelectedRow.Cells(11).Text
        Else
            TextBox25.Text = GridView1.SelectedRow.Cells(9).Text
            Label19.Text = GridView1.SelectedRow.Cells(10).Text
            Label20.Text = GridView1.SelectedRow.Cells(11).Text
        End If
        TextBox27.Text = GridView1.SelectedRow.Cells(1).Text
        Button4.Visible = True
        Button6.Visible = True
        Button3.Visible = False
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        If DropDownList1.SelectedItem.Text = "Cash" Then
            Label19.Text = ""
            Label20.Text = ""

        End If

        Dim status
        status = ""
        If Val(Label14.Text) < Val(Label10.Text) Then
            status = "Part Payment"
        Else
            If Val(Label14.Text) = Val(Label10.Text) Then
                status = "Full Payment"
            End If

        End If





        strnewrecord = "INSERT INTO [payment]"
        strnewrecord = strnewrecord & "([customer]"
        strnewrecord = strnewrecord & ",[amount]"
        If DropDownList1.SelectedItem.Text = "Cash" Then
            strnewrecord = strnewrecord & ",[bill_date], mr_no, b_type,bill_no,pmnt_mode, status)"

        Else
            strnewrecord = strnewrecord & ",[bill_date], mr_no, b_type,bill_no,pmnt_mode,chq_date,bank,cheque_no,status)"

        End If
        strnewrecord = strnewrecord & " values "
        strnewrecord = strnewrecord & "('" & Val(Label6.Text) & "'"
        strnewrecord = strnewrecord & ",'" & Val(Label14.Text) & "'"
        If DropDownList1.SelectedItem.Text = "Cash" Then
            strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox26.Text) & "','','" & status & "','" & Label6.Text & "','" & DropDownList1.SelectedItem.Text & "','Confirmed'); select scope_identity()"

        Else
            strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox26.Text) & "','','" & status & "','" & Label6.Text & "','" & DropDownList1.SelectedItem.Text & "','" & genf.getdate(TextBox25.Text) & "','" & Label19.Text & "','" & Label20.Text & "','Float'); select scope_identity()"

        End If
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Dim inv_no
        inv_no = Mycommand.ExecuteScalar.ToString()


        '*******************************************************
        Dim customer_id
        customer_id = Val(Label6.Text)


        Dim customer_name
        customer_name = genf.returnvaluefromdv("select customer_name from new_job_customer  where customer_id='" & Val(customer_id.ToString) & "'", 0)



        myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
        myconnection2.Open()



        Dim prnt_id
        prnt_id = "665301"
        Dim myqry


        Dim gpflg, gpid
        gpflg = 0
        gpid = 0
        myqry = "select child_gp_id from ac_group where child_gp like 'C#" & customer_id.ToString & "#%'"
        Mycommand = New SqlCommand(myqry, myconnection2)
        Mydataadapter = New SqlDataAdapter(Mycommand)
        Mydataadapter.Fill(mydataset, "admin")
        dv.Table = mydataset.Tables(0)
        If dv.Count > 0 Then
            gpflg = 1
            gpid = Val(dv(0)(0).ToString)
        End If
        dv.Table.Clear()
        mydataset.Tables.Clear()



        If gpflg = 0 Then
            myqry = "select top 1 child_gp_id from ac_group order by child_gp_id desc"
            Mycommand = New SqlCommand(myqry, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                prnt_id = Val(dv(0)(0).ToString) + 1
                '  Response.Write(prnt_id)
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            myqry = "insert into ac_group (parent_gp, child_gp, parent_gp_id, child_gp_id,level_id,during_period,income,expense) values ('C#" & customer_id.ToString & "#" & customer_name.ToString & "','C#" & customer_id.ToString & "#" & customer_name.ToString & "','" & Val(prnt_id.ToString) & "','" & Val(prnt_id.ToString) & "','0','False','True','False')"
            Mycommand = New SqlCommand(myqry, myconnection2)
            Mycommand.ExecuteNonQuery()
        Else
            '  Dim myqry
            myqry = "update ac_group set child_gp='C#" & customer_id.ToString & "#" & customer_name.ToString & "',parent_gp='C#" & customer_id.ToString & "#" & customer_name.ToString & "' where child_gp_id='" & Val(gpid.ToString) & "'"
            ' Response.Write(myqry)
            Mycommand = New SqlCommand(myqry, Myconnection)
            Mycommand.ExecuteNonQuery()
        End If
        myconnection2.Close()


        If DropDownList1.SelectedItem.Text = "Cash" Then

            Dim pvno, vtxno
            pvno = 0
            pvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & inv_no & "'", 0)

            vtxno = 0
            vtxno = genf.returnvaluefromdv("select vtxno from payment where tx_no='" & inv_no & "'", 0)


            myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
            myconnection2.Open()

            Dim pvno1, myqry1
            pvno1 = ""
            myqry1 = "select voucher_no from bank_receipt_voucher where vno='" & Val(pvno.ToString) & "'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                pvno1 = dv(0)(0).ToString
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            Dim slc, sln
            slc = 0
            sln = ""

            myqry1 = "select child_gp_id, child_gp from ac_group where child_gp like 'C#" & Val(customer_id.ToString) & "#%'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                slc = Val(dv(0)(0).ToString)
                sln = Trim(dv(0)(1).ToString)
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()

            'TextBox10.Text = TextBox10.Text.Replace("'", "''")
            'TextBox10.Text = genf.returnvaluefromdv("select child_gp from ac_group where child_gp_id='" & Val(TextBox11.Text) & "'", 0)




            Dim fin_yr
            If Val(genf.getdate(TextBox25.Text).ToString("MM")) >= 7 Then
                fin_yr = Val(genf.getdate(TextBox25.Text).ToString("yy")) & " - " & (Val(genf.getdate(TextBox26.Text).ToString("yy")) + 1)
            Else
                fin_yr = (Val(genf.getdate(TextBox25.Text).ToString("yy")) - 1) & " - " & (Val(genf.getdate(TextBox26.Text).ToString("yy")))

            End If
            Dim vno
            If Val(pvno.ToString) = 0 Then
                strnewrecord = "insert into bank_receipt_voucher (prefix,suffix,date,amount,operator,entry_date, branch_code, purpose, type, in_favour, bank, cheque_no, cheque_date) values ('CRV','" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','Cash',NULL,NULL,NULL,NULL); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                vno = Mycommand.ExecuteScalar.ToString()


                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose, amount, in_favour, bank, cheque_no, cheque_date) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','2','1','Cash','0','-','-','0','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & Val(Label14.Text) & "',NULL,NULL,NULL,NULL)"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            Else
                strnewrecord = "update bank_receipt_voucher set type='Cash', in_favour=NULL, bank=NULL, cheque_no=NULL, cheque_date=NULL, purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',suffix='" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',amount='" & Val(Label14.Text) & "' where vno='" & Val(pvno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                Mycommand.ExecuteNonQuery()

                vno = Val(pvno.ToString)


                strnewrecord = "update cash_voucher_det set amount='" & Val(Label14.Text) & "', in_favour=NULL, bank=NULL, cheque_no=NULL, cheque_date=NULL,  purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='2', glc='1', gl='Cash', slc='0', sln='-', lf='-', credit='0' where voucher_no='" & Trim(pvno1.ToString) & "' and credit='0' and amount<>'0'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            End If

            strnewrecord = "update payment set vno='" & Val(vno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            If Val(pvno.ToString) = 0 Then
                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose,amount) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','1','665311','Collection Against Job','" & Val(slc.ToString) & "','" & Trim(sln.ToString) & "','-','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','0');select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                ' Mycommand.ExecuteNonQuery()
                vtxno = Mycommand.ExecuteScalar.ToString

            Else

                strnewrecord = "update cash_voucher_det set amount='0', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "',  branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='1', glc='665311', gl='Collection Against Job', slc='" & Val(slc.ToString) & "', sln='" & Trim(sln.ToString) & "', lf='-', credit='" & Val(Label14.Text) & "' where tx_no='" & Val(vtxno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()




            End If

            strnewrecord = "update payment set vtxno='" & Val(vtxno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            myconnection2.Close()



        Else




            Dim pvno, vtxno
            pvno = 0
            pvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & inv_no & "'", 0)

            vtxno = 0
            vtxno = genf.returnvaluefromdv("select vtxno from payment where tx_no='" & inv_no & "'", 0)


            myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
            myconnection2.Open()

            Dim pvno1, myqry1
            pvno1 = ""
            myqry1 = "select voucher_no from bank_receipt_voucher where vno='" & Val(pvno.ToString) & "'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                pvno1 = dv(0)(0).ToString
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            Dim slc, sln
            slc = 0
            sln = ""

            myqry1 = "select child_gp_id, child_gp from ac_group where child_gp like 'C#" & Val(customer_id.ToString) & "#%'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                slc = Val(dv(0)(0).ToString)
                sln = Trim(dv(0)(1).ToString)
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()

            'TextBox10.Text = TextBox10.Text.Replace("'", "''")
            'TextBox10.Text = genf.returnvaluefromdv("select child_gp from ac_group where child_gp_id='" & Val(TextBox11.Text) & "'", 0)




            Dim fin_yr
            If Val(genf.getdate(TextBox25.Text).ToString("MM")) >= 7 Then
                fin_yr = Val(genf.getdate(TextBox25.Text).ToString("yy")) & " - " & (Val(genf.getdate(TextBox25.Text).ToString("yy")) + 1)
            Else
                fin_yr = (Val(genf.getdate(TextBox25.Text).ToString("yy")) - 1) & " - " & (Val(genf.getdate(TextBox25.Text).ToString("yy")))

            End If
            Dim vno
            If Val(pvno.ToString) = 0 Then

                strnewrecord = "insert into bank_receipt_voucher (prefix,suffix,date,amount,operator,entry_date, branch_code, purpose, in_favour, bank1, cheque_no, cheque_date, type) values ('CRV','" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & sln & "','" & Label19.Text & "','" & Label20.Text & "','" & genf.getdate(TextBox25.Text) & "','Bank'); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                vno = Mycommand.ExecuteScalar.ToString()


                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose, amount, in_favour, bank1, cheque_no, cheque_date) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','2','2','Bank','0','-','-','0','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & Val(Label14.Text) & "','" & sln & "','" & Label19.Text & "','" & Label20.Text & "','" & genf.getdate(TextBox25.Text) & "')"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            Else
                strnewrecord = "update bank_receipt_voucher set type='Bank', in_favour='" & sln & "', bank1='" & Label19.Text & "', cheque_no='" & Label20.Text & "', cheque_date='" & genf.getdate(TextBox25.Text) & "', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',suffix='" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',amount='" & Val(Label14.Text) & "' where vno='" & Val(pvno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                Mycommand.ExecuteNonQuery()

                vno = Val(pvno.ToString)


                strnewrecord = "update cash_voucher_det set amount='" & Val(Label14.Text) & "', in_favour='" & sln & "', bank1='" & Label19.Text & "', cheque_no='" & Label20.Text & "', cheque_date='" & genf.getdate(TextBox25.Text) & "',  purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='2', glc='2', gl='Bank', slc='0', sln='-', lf='-', credit='0' where voucher_no='" & Trim(pvno1.ToString) & "' and credit='0' and amount<>'0'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            End If

            strnewrecord = "update payment set vno='" & Val(vno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            If Val(pvno.ToString) = 0 Then
                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose,amount) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','1','665311','Collection Against Job','" & Val(slc.ToString) & "','" & Trim(sln.ToString) & "','-','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','0');select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                ' Mycommand.ExecuteNonQuery()
                vtxno = Mycommand.ExecuteScalar.ToString

            Else

                strnewrecord = "update cash_voucher_det set amount='0', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "',  branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='1', glc='665311', gl='Collection Against Job', slc='" & Val(slc.ToString) & "', sln='" & Trim(sln.ToString) & "', lf='-', credit='" & Val(Label14.Text) & "' where tx_no='" & Val(vtxno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()




            End If

            strnewrecord = "update payment set vtxno='" & Val(vtxno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            ' strnewrecord = "select tx_no from payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
            Dim ptx_no1
            ptx_no1 = Val(inv_no.ToString)
            Dim ppvno, pvtxno

            ppvno = 0
            ppvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & ptx_no1 & "'", 0)



            Dim ppvno1, pmyqry1
            ppvno1 = ""
            pmyqry1 = "select voucher_no from bank_receipt_voucher where vno='" & Val(ppvno.ToString) & "'"
            Mycommand = New SqlCommand(pmyqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                ppvno1 = dv(0)(0).ToString
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            strnewrecord = "delete from bank_receipt_voucher where vno='" & Val(ppvno.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from cash_voucher_det where voucher_no='" & Trim(ppvno1.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()


            strnewrecord = "update payment set vtxno=NULL, vno=NULL where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            myconnection2.Close()



        End If

        '*******************************************************




        Myconnection.Close()

        Label10.Text = ""


        'total1 = 0
        'genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox26.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Label19.Text = ""
        Label20.Text = ""
        Label14.Text = ""
        TextBox27.Text = ""

        Label10.Text = ""


        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        If GridView1.Rows.Count > 0 Then
            Label10.Text = Val(Label8.Text) - Val(GridView1.FooterRow.Cells(7).Text)
        Else
            Label10.Text = Val(Label8.Text)
        End If
        Label10.Text = genf.roundup(Val(Label10.Text))
        Button3.Visible = True
        Button4.Visible = False
        Button6.Visible = False


        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('money_receipt1.aspx?url=" & inv_no & "','money_rcpt');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        If DropDownList1.SelectedItem.Text = "Cash" Then
            Label19.Text = ""
            Label20.Text = ""

        End If

        Dim last_tx


        Dim status, flag
        status = ""
        flag = 0
        If Val(Label14.Text) < Val(Label10.Text) Then
            status = "Part Payment"
        Else
            status = "Part Payment"
            If Val(Label14.Text) = Val(Label10.Text) Then
                flag = 1


            End If

        End If



        strnewrecord = "update [payment]"
        strnewrecord = strnewrecord & " set [customer]='" & Val(Label6.Text) & "'"
        strnewrecord = strnewrecord & ",[amount]='" & Val(Label14.Text) & "'"
        If DropDownList1.SelectedItem.Text = "Cash" Then
            strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox26.Text) & "', mr_no='', b_type='" & status & "', bill_no='" & Label6.Text & "',pmnt_mode='" & DropDownList1.SelectedItem.Text & "', status='Confirmed',chq_date=NULL,bank=NULL,cheque_no=NULL"

        Else
            strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox26.Text) & "', mr_no='', b_type='" & status & "',bill_no='" & Label6.Text & "',pmnt_mode='" & DropDownList1.SelectedItem.Text & "',chq_date='" & genf.getdate(TextBox25.Text) & "',bank='" & Label19.Text & "',cheque_no='" & Label20.Text & "', status='Float'"

        End If
        strnewrecord = strnewrecord & " where tx_no='" & Val(TextBox27.Text) & "'"
        ' Response.Write(strnewrecord)

        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        If flag = 1 Then
            last_tx = genf.returnvaluefromdv("select top 1 tx_no from payment where customer='" & Val(Label6.Text) & "' order by tx_no desc", 0)

            strnewrecord = "update [payment] set b_type='Full Payment' where tx_no='" & Val(last_tx.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

        End If
        Dim inv_no
        inv_no = Val(TextBox27.Text)


        '*******************************************************
        Dim customer_id
        customer_id = Val(Label6.Text)

        Dim customer_name
        customer_name = genf.returnvaluefromdv("select customer_name from new_job_customer  where customer_id='" & Val(customer_id.ToString) & "'", 0)



        myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
        myconnection2.Open()



        Dim prnt_id
        prnt_id = "665301"
        Dim myqry


        Dim gpflg, gpid
        gpflg = 0
        gpid = 0
        myqry = "select child_gp_id from ac_group where child_gp like 'C#" & customer_id.ToString & "#%'"
        Mycommand = New SqlCommand(myqry, myconnection2)
        Mydataadapter = New SqlDataAdapter(Mycommand)
        Mydataadapter.Fill(mydataset, "admin")
        dv.Table = mydataset.Tables(0)
        If dv.Count > 0 Then
            gpflg = 1
            gpid = Val(dv(0)(0).ToString)
        End If
        dv.Table.Clear()
        mydataset.Tables.Clear()



        If gpflg = 0 Then
            myqry = "select top 1 child_gp_id from ac_group order by child_gp_id desc"
            Mycommand = New SqlCommand(myqry, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                prnt_id = Val(dv(0)(0).ToString) + 1
                '  Response.Write(prnt_id)
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            myqry = "insert into ac_group (parent_gp, child_gp, parent_gp_id, child_gp_id,level_id,during_period,income,expense) values ('C#" & customer_id.ToString & "#" & customer_name.ToString & "','C#" & customer_id.ToString & "#" & customer_name.ToString & "','" & Val(prnt_id.ToString) & "','" & Val(prnt_id.ToString) & "','0','False','True','False')"
            Mycommand = New SqlCommand(myqry, myconnection2)
            Mycommand.ExecuteNonQuery()
        Else
            '  Dim myqry
            myqry = "update ac_group set child_gp='C#" & customer_id.ToString & "#" & customer_name.ToString & "',parent_gp='C#" & customer_id.ToString & "#" & customer_name.ToString & "' where child_gp_id='" & Val(gpid.ToString) & "'"
            ' Response.Write(myqry)
            Mycommand = New SqlCommand(myqry, Myconnection)
            Mycommand.ExecuteNonQuery()
        End If
        myconnection2.Close()


        If DropDownList1.SelectedItem.Text = "Cash" Then

            Dim pvno, vtxno
            pvno = 0
            pvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & inv_no & "'", 0)

            vtxno = 0
            vtxno = genf.returnvaluefromdv("select vtxno from payment where tx_no='" & inv_no & "'", 0)


            myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
            myconnection2.Open()

            Dim pvno1, myqry1
            pvno1 = ""
            myqry1 = "select voucher_no from bank_receipt_voucher where vno='" & Val(pvno.ToString) & "'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                pvno1 = dv(0)(0).ToString
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            Dim slc, sln
            slc = 0
            sln = ""

            myqry1 = "select child_gp_id, child_gp from ac_group where child_gp like 'C#" & Val(customer_id.ToString) & "#%'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                slc = Val(dv(0)(0).ToString)
                sln = Trim(dv(0)(1).ToString)
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()

            'TextBox10.Text = TextBox10.Text.Replace("'", "''")
            'TextBox10.Text = genf.returnvaluefromdv("select child_gp from ac_group where child_gp_id='" & Val(TextBox11.Text) & "'", 0)




            Dim fin_yr
            If Val(genf.getdate(TextBox25.Text).ToString("MM")) >= 7 Then
                fin_yr = Val(genf.getdate(TextBox25.Text).ToString("yy")) & " - " & (Val(genf.getdate(TextBox26.Text).ToString("yy")) + 1)
            Else
                fin_yr = (Val(genf.getdate(TextBox25.Text).ToString("yy")) - 1) & " - " & (Val(genf.getdate(TextBox26.Text).ToString("yy")))

            End If
            Dim vno
            If Val(pvno.ToString) = 0 Then
                strnewrecord = "insert into bank_receipt_voucher (prefix,suffix,date,amount,operator,entry_date, branch_code, purpose, type, in_favour, bank, cheque_no, cheque_date) values ('CRV','" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','Cash',NULL,NULL,NULL,NULL); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                vno = Mycommand.ExecuteScalar.ToString()


                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose, amount, in_favour, bank, cheque_no, cheque_date) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','2','1','Cash','0','-','-','0','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & Val(Label14.Text) & "',NULL,NULL,NULL,NULL)"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            Else
                strnewrecord = "update bank_receipt_voucher set type='Cash', in_favour=NULL, bank=NULL, cheque_no=NULL, cheque_date=NULL, purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',suffix='" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',amount='" & Val(Label14.Text) & "' where vno='" & Val(pvno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                Mycommand.ExecuteNonQuery()

                vno = Val(pvno.ToString)


                strnewrecord = "update cash_voucher_det set amount='" & Val(Label14.Text) & "', in_favour=NULL, bank=NULL, cheque_no=NULL, cheque_date=NULL,  purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='2', glc='1', gl='Cash', slc='0', sln='-', lf='-', credit='0' where voucher_no='" & Trim(pvno1.ToString) & "' and credit='0' and amount<>'0'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            End If

            strnewrecord = "update payment set vno='" & Val(vno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            If Val(pvno.ToString) = 0 Then
                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose,amount) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','1','665311','Collection Against Job','" & Val(slc.ToString) & "','" & Trim(sln.ToString) & "','-','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','0');select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                ' Mycommand.ExecuteNonQuery()
                vtxno = Mycommand.ExecuteScalar.ToString

            Else

                strnewrecord = "update cash_voucher_det set amount='0', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "',  branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='1', glc='665311', gl='Collection Against Job', slc='" & Val(slc.ToString) & "', sln='" & Trim(sln.ToString) & "', lf='-', credit='" & Val(Label14.Text) & "' where tx_no='" & Val(vtxno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()




            End If

            strnewrecord = "update payment set vtxno='" & Val(vtxno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            myconnection2.Close()



        Else




            Dim pvno, vtxno
            pvno = 0
            pvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & inv_no & "'", 0)

            vtxno = 0
            vtxno = genf.returnvaluefromdv("select vtxno from payment where tx_no='" & inv_no & "'", 0)


            myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
            myconnection2.Open()

            Dim pvno1, myqry1
            pvno1 = ""
            myqry1 = "select voucher_no from bank_receipt_voucher where vno='" & Val(pvno.ToString) & "'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                pvno1 = dv(0)(0).ToString
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            Dim slc, sln
            slc = 0
            sln = ""

            myqry1 = "select child_gp_id, child_gp from ac_group where child_gp like 'C#" & Val(customer_id.ToString) & "#%'"
            Mycommand = New SqlCommand(myqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                slc = Val(dv(0)(0).ToString)
                sln = Trim(dv(0)(1).ToString)
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()

            'TextBox10.Text = TextBox10.Text.Replace("'", "''")
            'TextBox10.Text = genf.returnvaluefromdv("select child_gp from ac_group where child_gp_id='" & Val(TextBox11.Text) & "'", 0)




            Dim fin_yr
            If Val(genf.getdate(TextBox25.Text).ToString("MM")) >= 7 Then
                fin_yr = Val(genf.getdate(TextBox25.Text).ToString("yy")) & " - " & (Val(genf.getdate(TextBox25.Text).ToString("yy")) + 1)
            Else
                fin_yr = (Val(genf.getdate(TextBox25.Text).ToString("yy")) - 1) & " - " & (Val(genf.getdate(TextBox25.Text).ToString("yy")))

            End If
            Dim vno
            If Val(pvno.ToString) = 0 Then

                strnewrecord = "insert into bank_receipt_voucher (prefix,suffix,date,amount,operator,entry_date, branch_code, purpose, in_favour, bank1, cheque_no, cheque_date, type) values ('CRV','" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & sln & "','" & Label19.Text & "','" & Label20.Text & "','" & genf.getdate(TextBox25.Text) & "','Bank'); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                vno = Mycommand.ExecuteScalar.ToString()


                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose, amount, in_favour, bank1, cheque_no, cheque_date) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','2','2','Bank','0','-','-','0','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & Val(Label14.Text) & "','" & sln & "','" & Label19.Text & "','" & Label20.Text & "','" & genf.getdate(TextBox25.Text) & "')"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            Else
                strnewrecord = "update bank_receipt_voucher set type='Bank', in_favour='" & sln & "', bank1='" & Label19.Text & "', cheque_no='" & Label20.Text & "', cheque_date='" & genf.getdate(TextBox25.Text) & "', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',suffix='" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',amount='" & Val(Label14.Text) & "' where vno='" & Val(pvno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)

                Mycommand.ExecuteNonQuery()

                vno = Val(pvno.ToString)


                strnewrecord = "update cash_voucher_det set amount='" & Val(Label14.Text) & "', in_favour='" & sln & "', bank1='" & Label19.Text & "', cheque_no='" & Label20.Text & "', cheque_date='" & genf.getdate(TextBox25.Text) & "',  purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='2', glc='2', gl='Bank', slc='0', sln='-', lf='-', credit='0' where voucher_no='" & Trim(pvno1.ToString) & "' and credit='0' and amount<>'0'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()

            End If

            strnewrecord = "update payment set vno='" & Val(vno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            If Val(pvno.ToString) = 0 Then
                strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose,amount) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox26.Text) & "','1','665311','Collection Against Job','" & Val(slc.ToString) & "','" & Trim(sln.ToString) & "','-','" & Val(Label14.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','0');select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                ' Mycommand.ExecuteNonQuery()
                vtxno = Mycommand.ExecuteScalar.ToString

            Else

                strnewrecord = "update cash_voucher_det set amount='0', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "',  branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox26.Text) & "',sl='1', glc='665311', gl='Collection Against Job', slc='" & Val(slc.ToString) & "', sln='" & Trim(sln.ToString) & "', lf='-', credit='" & Val(Label14.Text) & "' where tx_no='" & Val(vtxno.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, myconnection2)
                Mycommand.ExecuteNonQuery()




            End If

            strnewrecord = "update payment set vtxno='" & Val(vtxno.ToString) & "' where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            ' strnewrecord = "select tx_no from payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
            Dim ptx_no1
            ptx_no1 = Val(inv_no.ToString)
            Dim ppvno, pvtxno

            ppvno = 0
            ppvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & ptx_no1 & "'", 0)



            Dim ppvno1, pmyqry1
            ppvno1 = ""
            pmyqry1 = "select voucher_no from bank_receipt_voucher where vno='" & Val(ppvno.ToString) & "'"
            Mycommand = New SqlCommand(pmyqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count > 0 Then
                ppvno1 = dv(0)(0).ToString
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()


            strnewrecord = "delete from bank_receipt_voucher where vno='" & Val(ppvno.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from cash_voucher_det where voucher_no='" & Trim(ppvno1.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()


            strnewrecord = "update payment set vtxno=NULL, vno=NULL where tx_no='" & Val(inv_no.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            myconnection2.Close()



        End If
        '*******************************************************


        Myconnection.Close()

        Label10.Text = ""


        'total1 = 0
        'genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox26.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Label19.Text = ""
        Label20.Text = ""
        Label14.Text = ""
        TextBox27.Text = ""
        Label10.Text = ""


        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        If GridView1.Rows.Count > 0 Then
            Label10.Text = Val(Label8.Text) - Val(GridView1.FooterRow.Cells(7).Text)
        Else
            Label10.Text = Val(Label8.Text)
        End If
        Label10.Text = genf.roundup(Val(Label10.Text))
        Button3.Visible = True
        Button4.Visible = False
        Button6.Visible = False

        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('money_receipt1.aspx?url=" & inv_no & "','money_rcpt');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        Label10.Text = ""


        'total1 = 0
        'genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox26.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Label19.Text = ""
        Label20.Text = ""
        Label14.Text = ""
        TextBox27.Text = ""

        Label10.Text = ""


        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        If GridView1.Rows.Count > 0 Then
            Label10.Text = Val(Label8.Text) - Val(GridView1.FooterRow.Cells(7).Text)
        Else
            Label10.Text = Val(Label8.Text)
        End If
        Label10.Text = genf.roundup(Val(Label10.Text))
        Button3.Visible = True
        Button4.Visible = False
        Button6.Visible = False
    End Sub

    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        If DropDownList1.SelectedItem.Text = "Cash" Then
            Label19.Text = ""
            Label20.Text = ""

        End If

        strnewrecord = "delete from [voucher_entry]"

        strnewrecord = strnewrecord & " where inv_no='" & Val(TextBox27.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        strnewrecord = "delete from [payment]"

        strnewrecord = strnewrecord & " where tx_no='" & Val(TextBox27.Text) & "'"


        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        Myconnection.Close()

        Label10.Text = ""


        'total1 = 0
        'genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
        TextBox26.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Label19.Text = ""
        Label20.Text = ""
        Label14.Text = ""
        TextBox27.Text = ""
        Label10.Text = ""


        total1 = 0
        genf.populate_grid("select tx_no as [Tx. No], bill_no as [Invoice No], job_no as [Job ID], mr_no as [Voucher No], b_type as [Purpose], bill_date as [Date], amount as [Amount],pmnt_mode as [Payment Mode],chq_date as [Cheque Date],bank as [Bank],cheque_no as [Cheque No],status as [Status] from payment where customer='" & Val(Label6.Text) & "' ", GridView1)
        If GridView1.Rows.Count > 0 Then
            Label10.Text = Val(Label8.Text) - Val(GridView1.FooterRow.Cells(7).Text)
        Else
            Label10.Text = Val(Label8.Text)
        End If
        Label10.Text = genf.roundup(Val(Label10.Text))
        Button3.Visible = True
        Button4.Visible = False
        Button6.Visible = False
    End Sub

    Protected Sub Button7_Click(sender As Object, e As System.EventArgs) Handles Button7.Click
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('money_receipt1.aspx?url=" & TextBox27.Text & "','money_rcpt');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")
        End If
    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(6).Text = genf.getdatefromdb(e.Row.Cells(6).Text).ToString("dd/MM/yyyy")
            e.Row.Cells(7).Text = genf.getdatefromdb(e.Row.Cells(7).Text).ToString("dd/MM/yyyy")
            e.Row.Cells(17).Text = genf.getdatefromdb(e.Row.Cells(17).Text).ToString("dd/MM/yyyy")

            e.Row.Cells(18).Text = genf.roundup(Val(e.Row.Cells(18).Text))
            e.Row.Cells(19).Text = genf.roundup(Val(e.Row.Cells(19).Text))
            e.Row.Cells(20).Text = genf.roundup(Val(e.Row.Cells(20).Text))


            total1 = total1 + Val(e.Row.Cells(18).Text)
            total2 = total2 + Val(e.Row.Cells(19).Text)
            total3 = total3 + Val(e.Row.Cells(20).Text)


            e.Row.Cells(18).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(19).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(20).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False

            e.Row.Cells(8).Visible = False
            e.Row.Cells(14).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then

            e.Row.Cells(18).Text = total1
            e.Row.Cells(19).Text = total2
            e.Row.Cells(20).Text = total3
            e.Row.Cells(17).Text = "Total"
            Label8.Text = e.Row.Cells(20).Text
            e.Row.Cells(18).Text = genf.roundup(Val(e.Row.Cells(18).Text))
            e.Row.Cells(19).Text = genf.roundup(Val(e.Row.Cells(19).Text))
            e.Row.Cells(20).Text = genf.roundup(Val(e.Row.Cells(20).Text))


            e.Row.Cells(17).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(18).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(19).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(20).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False

            e.Row.Cells(8).Visible = False
            e.Row.Cells(14).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False

            e.Row.Cells(8).Visible = False
            e.Row.Cells(14).Visible = False
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub
End Class
