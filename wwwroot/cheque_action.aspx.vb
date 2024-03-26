Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class cheque_action
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim strconnection2 = ConfigurationSettings.AppSettings("ConnectionString2")
    Dim Myconnection, myconnection1, myconnection2 As SqlConnection

    '     Dim Myconnection, myconnection1 As SqlConnection
    Dim Mycommand, Mycommand1, Mycommand2, Mycommand10 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1, Mydataadapter2, Mydataadapter10 As SqlDataAdapter
    Dim dv, dv1, dv2, dv10 As New DataView
    Dim mydataset, mydataset1, mydataset2, mydataset10 As New DataSet
    Dim genf As New genfunction
    Dim amiw As New amtinwords
    Dim total1, total2, total3
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button2.Visible = True Then
            Button2.Visible = False
            TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy")
            DropDownList1.Items.Clear()
            DropDownList1.Items.Add("Float")
            DropDownList1.Items.Add("Deposited")
            DropDownList1.Items.Add("Confirmed")
            DropDownList1.Items.Add("Bounced")
            DropDownList1.SelectedIndex = 0

            Label22.Text = Request.Cookies("branch_code").Value
            Label23.Text = Request.Cookies("branch_name").Value

         


            myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
            myconnection2.Open()

         
            Dim pmyqry1
            pmyqry1 = "sELECT [Bank ID],[Bank Name] + '(' + [Account No] + ')' as bank FROM [bank] order by [bank]"
            Mycommand = New SqlCommand(pmyqry1, myconnection2)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            DropDownList2.DataSource = mydataset.Tables(0)
            DropDownList2.DataTextField = "Bank"
            DropDownList2.DataValueField = "Bank ID"
            DropDownList2.DataBind()
            mydataset.Tables.Clear()
            myconnection2.Close()

            If DropDownList2.Items.Count > 0 Then
                DropDownList2.SelectedIndex = 0
            End If


            'If IsNothing(Session("uid")) Then
            '    Response.Redirect("login.aspx")
            'End If
        End If

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim rad1, rad2, rad3, rad4, rad5, rad6 As New RadioButton
            rad1 = e.Row.FindControl("RadioButton1")
            rad2 = e.Row.FindControl("RadioButton2")
            rad3 = e.Row.FindControl("RadioButton3")
            rad4 = e.Row.FindControl("RadioButton4")
            rad5 = e.Row.FindControl("RadioButton5")
            rad6 = e.Row.FindControl("RadioButton6")

            Dim lab2 As New Label
            lab2 = e.Row.FindControl("Label2")

            lab2.Text = ""

            If e.Row.Cells(11).Text = "Deposited" Then

                lab2.Text = genf.returnvaluefromdv("select dep_bank from payment where [tx_no]='" & Val(e.Row.Cells(17).Text) & "'", 0)
                myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
                myconnection2.Open()
                Dim pmyqry1
                pmyqry1 = "sELECT [Bank ID],[Bank Name] + '(' + [Account No] + ')' as bank FROM [bank] where bank.[Bank ID]='" & Val(lab2.Text) & "' order by [bank]"
                Mycommand1 = New SqlCommand(pmyqry1, myconnection2)
                Mydataadapter1 = New SqlDataAdapter(Mycommand1)
                Mydataadapter1.Fill(mydataset1, "admin")
                dv1.Table = mydataset1.Tables(0)
                If dv1.Count > 0 Then
                    lab2.Text = dv1(0)(1).ToString
                End If
                dv1.Table.Clear()
                mydataset1.Tables.Clear()
                myconnection2.Close()


                rad1.Enabled = False
                rad2.Enabled = True
                rad3.Enabled = True
                rad4.Enabled = True
                rad5.Enabled = True
                '  rad2.Checked = True

                'If e.Row.Cells(9).Text = "Bounced" Then
                '    rad3.Checked = True
                'Else
                '    If e.Row.Cells(9).Text = "Confirmed" Then
                '        rad2.Checked = True
                '    Else
                '        rad5.Checked = True
                '    End If
                'End If
                'rad1.Enabled = False
                'rad2.Enabled = False
                'rad3.Enabled = False
                'rad4.Enabled = False
                'rad5.Enabled = False
                rad6.Checked = True
            Else
                rad1.Enabled = True
                rad2.Enabled = False
                rad3.Enabled = False
                rad4.Enabled = False
                rad5.Enabled = False
                rad6.Checked = True
            End If

            Try
                e.Row.Cells(8).Text = genf.getdatefromdb(e.Row.Cells(8).Text).ToString("dd/MM/yyyy")

            Catch ex As Exception

            End Try
            Try
                e.Row.Cells(10).Text = genf.getdatefromdb(e.Row.Cells(10).Text).ToString("dd/MM/yyyy")

            Catch ex As Exception

            End Try
            Try
                e.Row.Cells(12).Text = genf.getdatefromdb(e.Row.Cells(12).Text).ToString("dd/MM/yyyy")

            Catch ex As Exception

            End Try
            Try
                e.Row.Cells(15).Text = genf.getdatefromdb(e.Row.Cells(15).Text).ToString("dd/MM/yyyy")

            Catch ex As Exception

            End Try
            e.Row.Cells(6).Text = genf.roundup(Val(e.Row.Cells(6).Text))
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right


            e.Row.Cells(14).Visible = False
            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(14).Visible = False
            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(14).Visible = False
            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim i
        For i = 0 To GridView1.Rows.Count - 1
            Dim rad1, rad2, rad3, rad4, rad5 As New RadioButton
            rad1 = GridView1.Rows(i).FindControl("RadioButton1")
            rad2 = GridView1.Rows(i).FindControl("RadioButton2")
            rad3 = GridView1.Rows(i).FindControl("RadioButton3")
            rad4 = GridView1.Rows(i).FindControl("RadioButton4")
            rad5 = GridView1.Rows(i).FindControl("RadioButton5")

            If rad1.Checked = True And rad1.Enabled = True Then
                strnewrecord = "update payment set action='Deposited', dep_bank='" & Val(DropDownList2.SelectedValue.ToString) & "', action_date='" & genf.getdate(TextBox25.Text) & "' where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                'Dim vno1
                'vno1 = genf.returnvaluefromdv("select Id from voucher_entry where inv_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0).ToString

                'strnewrecord = "delete from voucher_entry where voucher_type='Credit' and [inv_no]='" & Val(GridView1.Rows(i).Cells(17).Text) & "' and id='" & Val(vno1.ToString) & "'"
                'Mycommand = New SqlCommand(strnewrecord, Myconnection)
                'Mycommand.ExecuteNonQuery()

                strnewrecord = "update payment set mr_no=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()





                myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
                myconnection2.Open()

                Dim ptx_no1
                ptx_no1 = Val(GridView1.Rows(i).Cells(17).Text)
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


                strnewrecord = "update payment set vtxno=NULL, vno=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                myconnection2.Close()



            End If
            If rad2.Checked = True And rad2.Enabled = True Then
                strnewrecord = "update payment set status='Confirmed', status_date='" & genf.getdate(TextBox25.Text) & "' where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()


                '*******************************************************
                Dim customer_id, bank
                bank = genf.returnvaluefromdv("select dep_bank from payment  where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0)









                customer_id = genf.returnvaluefromdv("select customer from payment  where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0)

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





                Else




                    Dim pvno, vtxno
                    pvno = 0
                    pvno = genf.returnvaluefromdv("select vno from payment where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0)

                    vtxno = 0
                    vtxno = genf.returnvaluefromdv("select vtxno from payment where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0)


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

                        strnewrecord = "insert into bank_receipt_voucher (prefix,suffix,date,amount,operator,entry_date, branch_code, purpose, in_favour, bank, cheque_no, cheque_date, type) values ('CRV','" & fin_yr & "','" & genf.getdate(TextBox25.Text) & "','" & Val(GridView1.Rows(i).Cells(6).Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & sln & "','" & Val(bank.ToString) & "','" & GridView1.Rows(i).Cells(5).Text & "','" & genf.getdate(TextBox25.Text) & "','Bank'); select scope_identity()"
                        Mycommand = New SqlCommand(strnewrecord, myconnection2)

                        vno = Mycommand.ExecuteScalar.ToString()


                        strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose, amount, in_favour, bank, cheque_no, cheque_date) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox25.Text) & "','2','2','Bank','0','-','-','0','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','" & Val(GridView1.Rows(i).Cells(6).Text) & "','" & sln & "','" & Val(bank.ToString) & "','" & GridView1.Rows(i).Cells(5).Text & "','" & genf.getdate(TextBox25.Text) & "')"
                        Mycommand = New SqlCommand(strnewrecord, myconnection2)
                        Mycommand.ExecuteNonQuery()

                    Else
                        strnewrecord = "update bank_receipt_voucher set type='Bank', in_favour='" & sln & "', bank='" & Val(bank.ToString) & "', cheque_no='" & GridView1.Rows(i).Cells(5).Text & "', cheque_date='" & genf.getdate(TextBox25.Text) & "', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',suffix='" & fin_yr & "',date='" & genf.getdate(TextBox25.Text) & "',amount='" & Val(GridView1.Rows(i).Cells(6).Text) & "' where vno='" & Val(pvno.ToString) & "'"
                        Mycommand = New SqlCommand(strnewrecord, myconnection2)

                        Mycommand.ExecuteNonQuery()

                        vno = Val(pvno.ToString)


                        strnewrecord = "update cash_voucher_det set amount='" & Val(GridView1.Rows(i).Cells(6).Text) & "', in_favour='" & sln & "', bank='" & Val(bank.ToString) & "', cheque_no='" & GridView1.Rows(i).Cells(5).Text & "', cheque_date='" & genf.getdate(TextBox25.Text) & "',  purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "', branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox25.Text) & "',sl='2', glc='2', gl='Bank', slc='0', sln='-', lf='-', credit='0' where voucher_no='" & Trim(pvno1.ToString) & "' and credit='0' and amount<>'0'"
                        Mycommand = New SqlCommand(strnewrecord, myconnection2)
                        Mycommand.ExecuteNonQuery()

                    End If

                    strnewrecord = "update payment set vno='" & Val(vno.ToString) & "' where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()


                    If Val(pvno.ToString) = 0 Then
                        strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, credit,operator,entry_date, branch_code, purpose,amount) values ('CRV','" & vno & "','" & fin_yr & "','CRV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox25.Text) & "','1','665311','Collection Against Job','" & Val(slc.ToString) & "','" & Trim(sln.ToString) & "','-','" & Val(GridView1.Rows(i).Cells(6).Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Collection Against Invoices From Customer # " & Trim(sln.ToString) & "','0');select scope_identity()"
                        Mycommand = New SqlCommand(strnewrecord, myconnection2)
                        ' Mycommand.ExecuteNonQuery()
                        vtxno = Mycommand.ExecuteScalar.ToString

                    Else

                        strnewrecord = "update cash_voucher_det set amount='0', purpose='Collection Against Invoices From Customer # " & Trim(sln.ToString) & "',  branch_code='2', prefix='CRV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='CRV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox25.Text) & "',sl='1', glc='665311', gl='Collection Against Job', slc='" & Val(slc.ToString) & "', sln='" & Trim(sln.ToString) & "', lf='-', credit='" & Val(GridView1.Rows(i).Cells(6).Text) & "' where tx_no='" & Val(vtxno.ToString) & "'"
                        Mycommand = New SqlCommand(strnewrecord, myconnection2)
                        Mycommand.ExecuteNonQuery()




                    End If

                    strnewrecord = "update payment set vtxno='" & Val(vtxno.ToString) & "' where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()


                    ' strnewrecord = "select tx_no from payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "


                    myconnection2.Close()



                End If

                '*******************************************************

            End If
            If rad3.Checked = True And rad3.Enabled = True Then
                strnewrecord = "update payment set status='Bounced', status_date='" & genf.getdate(TextBox25.Text) & "' where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                'Dim vno1
                'vno1 = genf.returnvaluefromdv("select Id from voucher_entry where inv_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0).ToString

                'strnewrecord = "delete from voucher_entry where voucher_type='Credit' and [inv_no]='" & Val(GridView1.Rows(i).Cells(17).Text) & "' and id='" & Val(vno1.ToString) & "'"
                'Mycommand = New SqlCommand(strnewrecord, Myconnection)
                'Mycommand.ExecuteNonQuery()

                strnewrecord = "update payment set mr_no=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()



                myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
                myconnection2.Open()

                Dim ptx_no1
                ptx_no1 = Val(GridView1.Rows(i).Cells(17).Text)
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


                strnewrecord = "update payment set vtxno=NULL, vno=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                myconnection2.Close()



            End If
            If rad5.Checked = True And rad5.Enabled = True Then
                strnewrecord = "update payment set status='Float', status_date=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                'Dim vno1
                'vno1 = genf.returnvaluefromdv("select Id from voucher_entry where inv_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0).ToString

                'strnewrecord = "delete from voucher_entry where voucher_type='Credit' and [inv_no]='" & Val(GridView1.Rows(i).Cells(17).Text) & "' and id='" & Val(vno1.ToString) & "'"
                'Mycommand = New SqlCommand(strnewrecord, Myconnection)
                'Mycommand.ExecuteNonQuery()

                strnewrecord = "update payment set mr_no=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()




                myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
                myconnection2.Open()

                Dim ptx_no1
                ptx_no1 = Val(GridView1.Rows(i).Cells(17).Text)
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


                strnewrecord = "update payment set vtxno=NULL, vno=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                myconnection2.Close()


            End If
            If rad4.Checked = True And rad4.Enabled = True Then
                strnewrecord = "update payment set status='Float', action_date=NULL, action=NULL, status_date=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                'Dim vno1
                'vno1 = genf.returnvaluefromdv("select Id from voucher_entry where inv_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'", 0).ToString

                'strnewrecord = "delete from voucher_entry where voucher_type='Credit' and [inv_no]='" & Val(GridView1.Rows(i).Cells(17).Text) & "' and id='" & Val(vno1.ToString) & "'"
                'Mycommand = New SqlCommand(strnewrecord, Myconnection)
                'Mycommand.ExecuteNonQuery()

                strnewrecord = "update payment set mr_no=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()





                myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
                myconnection2.Open()

                Dim ptx_no1
                ptx_no1 = Val(GridView1.Rows(i).Cells(17).Text)
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


                strnewrecord = "update payment set vtxno=NULL, vno=NULL where tx_no='" & Val(GridView1.Rows(i).Cells(17).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                myconnection2.Close()

            End If
        Next
       
        Myconnection.Close()
        Button4_Click(sender, e)
    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Dim whcls = ""
        If DropDownList1.SelectedItem.Text = "Float" Then
            If CheckBox3.Checked = False Then

                ' (datediff(day,'" & genf.getdate(TextBox4.Text) & "',job_bill.bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',job_bill.bill_date)<=0)
                whcls = "where status='Float' and action is null and ((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',chq_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',chq_date)<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',action_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',action_date)<=0))"

            Else
                whcls = "where status='Float' and action is null" ' and ((datediff(day,'" & genf.getdate(TextBox4.Text) & "',bill_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',bill_date)<=0) or (datediff(day,'" & genf.getdate(TextBox4.Text) & "',action_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',action_date)<=0))"

            End If
        End If
        If DropDownList1.SelectedItem.Text = "Deposited" Then
            If CheckBox3.Checked = False Then
                whcls = "where (action='Deposited' and status='Float' and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',action_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',action_date)<=0))"

            Else
                whcls = "where action='Deposited' and status='Float'" ' and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',action_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',action_date)<=0))"

            End If
        End If

        If DropDownList1.SelectedItem.Text = "Confirmed" Then
            If CheckBox3.Checked = False Then
                whcls = "where (action='Deposited' and status='Confirmed'  and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',status_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',status_date)<=0))"

            Else
                whcls = "where action='Deposited' and status='Confirmed'" '  and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',status_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',status_date)<=0))"

            End If
        End If

        If DropDownList1.SelectedItem.Text = "Bounced" Then
            If CheckBox3.Checked = False Then
                whcls = "where (action='Deposited' and status='Bounced'  and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',status_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',status_date)<=0))"

            Else
                whcls = "where action='Deposited' and status='Bounced'" '  and (datediff(day,'" & genf.getdate(TextBox4.Text) & "',status_date)>=0 and datediff(day,'" & genf.getdate(TextBox9.Text) & "',status_date)<=0))"

            End If
        End If

        strnewrecord = "SELECT [cheque_no] as [Cheque No],[amount] as [Amount],[bank] as [Bank],[chq_date] as [Cheque Date],[status] as [Cheque Status], status_date as [Cheque Status Date],[action] as [Cheque Action], action_date as [Action Date] ,[pmnt_mode] as [Payment Mode],[bill_no] as [Invoice No],[bill_date] as [Invoice Date],[job_no] as [Job No], tx_no as [Money Receipt No] FROM [payment] " & whcls
        '  Response.Write(strnewrecord)
        genf.populate_grid(strnewrecord, GridView1)

    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
       

        strnewrecord = "SELECT [cheque_no] as [Cheque No],[amount] as [Amount],[bank] as [Bank],[chq_date] as [Cheque Date],[status] as [Cheque Status], status_date as [Cheque Status Date],[action] as [Cheque Action], action_date as [Action Date] ,[pmnt_mode] as [Payment Mode],[bill_no] as [Invoice No],[bill_date] as [Invoice Date],[job_no] as [Job No], tx_no as [Money Receipt No] FROM [payment] where [cheque_no]='" & TextBox26.Text & "'"
        genf.populate_grid(strnewrecord, GridView1)
    End Sub
End Class
