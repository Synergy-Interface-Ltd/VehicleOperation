Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class print_estimate
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
    Dim ami As New amtinwords
    Dim total1, total2, total3
    Dim lastrow, lasthead
    Dim rsl As Integer
    Dim bf, lastcat
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button1.Visible = True Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            Button1.Visible = False
            TextBox28.Text = ""
            TextBox26.Text = ""
            TextBox34.Text = ""
            TextBox35.Text = ""
            TextBox27.Text = DateTime.Now.ToString("dd/MM/yyyy")

            TextBox29.Text = ""
            
            TextBox30.Text = ""
            TextBox31.Text = ""
            TextBox32.Text = ""
            TextBox25.Text = ""
            If Not IsNothing(Request.QueryString("url")) Then
                TextBox24.Text = Request.QueryString("url")
                strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, bill_no, vat, bill_date, vat1, disc_per, cash_disc, (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), tnc FROM [estimate_new_job_cart] where job_id='" & Val(Request.QueryString("url").ToString) & "'"
                TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
                TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
                TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
                TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
                TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
                'Dim dt1 As New DateTime
                'dt1 = genf.returnvaluefromdv(strnewrecord, 5)
                '     TextBox6.Text = dt1.ToString("dd/MM/yyyy")
                Dim k

                '   Label34.Text = Val(dt1.ToString("HH"))


                ' Label35.Text = Val(dt1.ToString("mm"))

                'Dim dt2 As New DateTime
                'dt2 = genf.returnvaluefromdv(strnewrecord, 6)
                '  TextBox7.Text = dt2.ToString("dd/MM/yyyy")

                ' Label32.Text = Val(dt2.ToString("HH"))

                ' Label33.Text = Val(dt2.ToString("mm"))
                TextBox14.Text = genf.returnvaluefromdv(strnewrecord, 7)
                TextBox8.Text = genf.returnvaluefromdv(strnewrecord, 8)
                TextBox9.Text = genf.returnvaluefromdv(strnewrecord, 9)
                TextBox10.Text = genf.returnvaluefromdv(strnewrecord, 10)
                TextBox11.Text = genf.returnvaluefromdv(strnewrecord, 11)
                TextBox12.Text = genf.returnvaluefromdv(strnewrecord, 12)
                TextBox13.Text = genf.returnvaluefromdv(strnewrecord, 13)
                TextBox26.Text = genf.roundup(Val(genf.returnvaluefromdv(strnewrecord, 17)))
                If genf.returnvaluefromdv(strnewrecord, 25).ToString = "-" Then
                    TextBox44.Visible = False
                    Literal2.Text = "" 'Server.HtmlDecode(genf.returnvaluefromdv(strnewrecord, 25).ToString.Replace(Environment.NewLine, "<br>"))
                    tnc.Visible = False
                Else
                    TextBox44.Visible = True
                    Literal2.Text = Server.HtmlDecode(genf.returnvaluefromdv(strnewrecord, 25).ToString.Replace(Environment.NewLine, "<br>"))
                    tnc.Visible = True
                End If

                If Val(TextBox26.Text) > 0 Then
                    TextBox26.Visible = True
                    Label48.Visible = True
                    l48.Style("display") = "table-cell"
                    ll48.Style("display") = "table-cell"
                Else
                    TextBox26.Visible = False
                    Label48.Visible = False
                    l48.Style("display") = "none"
                    ll48.Style("display") = "none"
                End If

                TextBox25.Text = Val(genf.returnvaluefromdv(strnewrecord, 18))

                If genf.returnvaluefromdv(strnewrecord, 19) = "True" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                If genf.returnvaluefromdv(strnewrecord, 21) = "True" Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If
                TextBox34.Text = genf.roundup(Val(genf.returnvaluefromdv(strnewrecord, 22)))
                TextBox34.Text = Val(TextBox34.Text)
                If Val(TextBox34.Text) > 0 Then
                    TextBox34.Visible = True
                    Label10.Visible = True
                    l34.Style("display") = "table-cell"
                    ll34.Style("display") = "table-cell"
                Else
                    TextBox34.Visible = False
                    Label10.Visible = False
                    l34.Style("display") = "none"
                    ll34.Style("display") = "none"
                End If

                TextBox35.Text = genf.roundup(Val(genf.returnvaluefromdv(strnewrecord, 23)))
                If Val(TextBox35.Text) > 0 Then
                    TextBox35.Visible = True
                    Label11.Visible = True
                    l35.Style("display") = "table-cell"
                    ll35.Style("display") = "table-cell"
                Else
                    TextBox35.Visible = False
                    Label11.Visible = False
                    l35.Style("display") = "none"
                    ll35.Style("display") = "none"
                End If

                TextBox42.Text = (genf.returnvaluefromdv(strnewrecord, 24))

                Try
                    TextBox27.Text = genf.getdatefromdb(genf.returnvaluefromdv(strnewrecord, 20)).ToString("dd/MM/yyyy")

                Catch ex As Exception

                End Try
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    ' TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 7.5) / 100)
                    Label50.Text = "VAT on Service (7.5%) :"
                    Label56.Text = "VAT Amount (10%) :"
                Else
                    'TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 10) / 100)
                    Label50.Text = "VAT on Service (10%) :"
                    Label56.Text = "VAT Amount (10%) :"
                End If

                total1 = 0
                lastrow = ""
                rsl = 0
                ' strnewrecord = "select distinct '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master, technician_master where estimate_new_job_service.technician_id=technician_master.technician_id and estimate_new_job_service.service_id=service_master.service_id and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master, technician_master where estimate_new_job_service.technician_id=technician_master.technician_id and estimate_new_job_service.service_id=service_master.service_id and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'  union all  select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),estimate_new_job_parts.qty) + ' ' + vehicle_parts.unit as [Unit], estimate_new_job_parts.price as [Rate], estimate_new_job_parts.total as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id and estimate_new_job_parts.qty>'0'"
                ' strnewrecord = "with q2 as (select distinct '-' as [Serial&nbsp;No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where  estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'),   q1 AS ((select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id) union all (select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "')) select * from q2   union all select distinct * from q1 union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),estimate_new_job_parts.qty) + ' ' + vehicle_parts.unit as [Unit], estimate_new_job_parts.price as [Rate], estimate_new_job_parts.total as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id and estimate_new_job_parts.qty>'0'  union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (Qty)' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'  union all select distinct '-' as [Serial No],'Machine Shop Work:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (Qty)' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]   from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"

                strnewrecord = "with aq2 as (select distinct '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all select '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'),"
                strnewrecord = strnewrecord & " q2 as (select distinct * from aq2"
                strnewrecord = strnewrecord & " union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where  estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"
                strnewrecord = strnewrecord & "  union all  select '1' as [Serial No],description as [Particulars], '' as [Unit], '' as [Rate], '' as [Amount]   from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'"
                strnewrecord = strnewrecord & "  union all  select '' as [Serial No],'Dent and Paint#' + convert(nvarchar(50),tx_id) + '#' + description as [Particulars], '' as [Unit], Price as [Rate], Price as [Amount]   from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description<>'Dent and Paint'"
                strnewrecord = strnewrecord & "  union all  select '' as [Serial No],description + '#Total' as [Particulars], convert(nvarchar(50),qty) as [Unit], '' as [Rate], Price as [Amount]   from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'"
                strnewrecord = strnewrecord & " ),   q1 AS ((select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id) union all (select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "')) select * from q2   union all select distinct * from q1 union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),estimate_new_job_parts.qty) + ' ' + vehicle_parts.unit as [Unit], estimate_new_job_parts.price as [Rate], estimate_new_job_parts.total as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id and estimate_new_job_parts.qty>'0'  union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (' + estimate_new_job_service.unit + ')' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'  union all select distinct '-' as [Serial No],'Machine Shop Work:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (' + estimate_new_job_service.unit + ')' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]   from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"

                genf.populate_grid(strnewrecord, GridView5)
                If GridView5.Rows.Count > 0 Then
                    If GridView5.Rows(GridView5.Rows.Count - 1).Cells(1).Text = "Spares:" Then
                        GridView5.Rows(GridView5.Rows.Count - 1).Visible = False

                    End If
                    If GridView5.Rows(GridView5.Rows.Count - 1).Cells(1).Text = "Machine Shop Work:" Then
                        GridView5.Rows(GridView5.Rows.Count - 1).Visible = False

                    End If
                End If
                bf = 0
                lastcat = ""
                Dim dt = New DataTable("backupdata")
                Dim colcnt
                colcnt = -1
                For i = 0 To GridView5.HeaderRow.Cells.Count - 1
                    If GridView5.HeaderRow.Cells(i).Visible = True Then
                        dt.Columns.Add(Server.HtmlDecode(GridView5.HeaderRow.Cells(i).Text), GetType(String))
                        colcnt = colcnt + 1
                    End If
                Next
                Dim arr1(colcnt) As String
                Dim rcnt
                rcnt = 0
                Dim flag
                flag = 0
                inv1.Visible = True
                Literal1.Text = ""
                If flag = 2 Then

                End If
                For Each row As GridViewRow In GridView5.Rows
                    If row.Visible = True Then

                        rcnt = rcnt + 1
                        ' Response.Write(rcnt)
                        Dim rcolcnt
                        rcolcnt = 0
                        For i = 0 To row.Cells.Count - 1
                            If row.Cells(i).Visible = True Then
                                arr1(rcolcnt) = row.Cells(i).Text
                                rcolcnt = rcolcnt + 1
                            End If
                        Next
                        dt.Rows.Add(arr1)




                    End If



                    If rcnt = 29 Then
                        flag = 2
                        total1 = 0

                        GridView6.DataSource = dt
                        GridView6.DataBind()
                        If row.RowIndex < GridView5.Rows.Count - 1 Then
                            GridView6.FooterRow.Visible = True
                        Else
                            GridView6.FooterRow.Visible = False
                        End If




                        Dim sb2 As New StringBuilder()
                        inv.RenderControl(New HtmlTextWriter(New StringWriter(sb2)))

                        If row.RowIndex < GridView5.Rows.Count - 1 Then

                            If flag = 0 Then
                                'Literal1.Text = Literal1.Text & "<br>"
                            End If
                            Literal1.Text = Literal1.Text & sb2.ToString
                            Literal1.Text = Literal1.Text & "<table cellspacing='0' cellpadding='2' border='0' width='100%' style='margin-top: 4px; border: solid 1.25px black'><tr><td align='center' colspan='2' valign='top' width='35%'>"
                            Literal1.Text = Literal1.Text & "<br />"
                            Literal1.Text = Literal1.Text & "_______________<br />"
                            Literal1.Text = Literal1.Text & "<font face='Calibri'><b>Customer</b></font>"
                            Literal1.Text = Literal1.Text & "</td>"
                            Literal1.Text = Literal1.Text & "<td align='center' valign='top' width='30%'>"
                            Literal1.Text = Literal1.Text & "&nbsp;"
                            'Literal1.Text = Literal1.Text & "___________<br />"
                            'Literal1.Text = Literal1.Text & "<font face='Calibri'><b>Customer</b></font>"
                            Literal1.Text = Literal1.Text & "</td>"
                            Literal1.Text = Literal1.Text & "<td align='center' valign='top' width='35%'>"
                            Literal1.Text = Literal1.Text & "<br />"
                            Literal1.Text = Literal1.Text & "______________<br />"
                            Literal1.Text = Literal1.Text & "<font face='Calibri'><b>Engineer</b></font>"
                            Literal1.Text = Literal1.Text & "</td></tr></table>"
                            Literal1.Text = Literal1.Text & "<DIV style='page-break-after:always'></DIV>"

                            Dim sb31 As New StringBuilder()
                            footer.RenderControl(New HtmlTextWriter(New StringWriter(sb31)))
                            Literal1.Text = Literal1.Text & sb31.ToString



                            dt = New DataTable("backupdata")
                            colcnt = -1
                            For i = 0 To GridView5.HeaderRow.Cells.Count - 1
                                If GridView5.HeaderRow.Cells(i).Visible = True Then
                                    If i = 1 Then
                                        dt.Columns.Add(Server.HtmlDecode(GridView5.HeaderRow.Cells(i).Text & ""), GetType(String))

                                    Else
                                        dt.Columns.Add(Server.HtmlDecode(GridView5.HeaderRow.Cells(i).Text), GetType(String))

                                    End If
                                    colcnt = colcnt + 1
                                End If
                            Next
                            ReDim arr1(colcnt) 'As String

                            arr1(0) = ""
                            arr1(1) = lastcat
                            arr1(2) = "BF"
                            arr1(3) = ""
                            arr1(4) = genf.roundup(Val(bf.ToString))
                            dt.Rows.Add(arr1)
                            bf = 0
                            rcnt = 0
                        Else
                            '  GridView6.FooterRow.Visible = False

                            If row.RowIndex = GridView5.Rows.Count - 1 And (GridView5.Rows.Count Mod 29) = 0 Then
                                If flag = 0 Then
                                    'Literal1.Text = Literal1.Text & "<br>"
                                End If
                                Literal1.Text = Literal1.Text & sb2.ToString
                                Literal1.Text = Literal1.Text & "<table cellspacing='0' cellpadding='2' border='0' width='100%' style='margin-top: 4px; border: solid 1.25px black'><tr><td align='center' colspan='2' valign='top' width='35%'>"
                                Literal1.Text = Literal1.Text & "<br />"
                                Literal1.Text = Literal1.Text & "_______________<br />"
                                Literal1.Text = Literal1.Text & "<font face='Calibri'><b>Customer</b></font>"
                                Literal1.Text = Literal1.Text & "</td>"
                                Literal1.Text = Literal1.Text & "<td align='center' valign='top' width='30%'>"
                                Literal1.Text = Literal1.Text & "&nbsp;"
                                'Literal1.Text = Literal1.Text & "___________<br />"
                                'Literal1.Text = Literal1.Text & "<font face='Calibri'><b>Customer</b></font>"
                                Literal1.Text = Literal1.Text & "</td>"
                                Literal1.Text = Literal1.Text & "<td align='center' valign='top' width='35%'>"
                                Literal1.Text = Literal1.Text & "<br />"
                                Literal1.Text = Literal1.Text & "______________<br />"
                                Literal1.Text = Literal1.Text & "<font face='Calibri'><b>Engineer</b></font>"
                                Literal1.Text = Literal1.Text & "</td></tr></table>"
                                Literal1.Text = Literal1.Text & "<DIV style='page-break-after:always'></DIV>"

                                Dim sb31 As New StringBuilder()
                                footer.RenderControl(New HtmlTextWriter(New StringWriter(sb31)))
                                Literal1.Text = Literal1.Text & sb31.ToString



                                dt = New DataTable("backupdata")
                                colcnt = -1
                                For i = 0 To GridView5.HeaderRow.Cells.Count - 1
                                    If GridView5.HeaderRow.Cells(i).Visible = True Then
                                        If i = 1 Then
                                            dt.Columns.Add(Server.HtmlDecode(GridView5.HeaderRow.Cells(i).Text & ""), GetType(String))

                                        Else
                                            dt.Columns.Add(Server.HtmlDecode(GridView5.HeaderRow.Cells(i).Text), GetType(String))

                                        End If
                                        colcnt = colcnt + 1
                                    End If
                                Next
                                ReDim arr1(colcnt) 'As String

                                arr1(0) = ""
                                arr1(1) = ""
                                arr1(2) = "BF"
                                arr1(3) = ""
                                arr1(4) = genf.roundup(Val(bf.ToString))
                                dt.Rows.Add(arr1)
                                bf = 0
                                rcnt = 0
                                flag = 1
                            Else
                                GridView6.FooterRow.Visible = False
                            End If


                        End If

                    Else
                        flag = 1

                        If row.RowIndex = 0 Then
                            ' Response.Write("ppp")

                            Dim sb21 As New StringBuilder()
                            footer.RenderControl(New HtmlTextWriter(New StringWriter(sb21)))
                            Literal1.Text = Literal1.Text & sb21.ToString

                        End If
                    End If
                Next




                If flag = 1 Then

                    total1 = 0
                    GridView6.DataSource = dt
                    GridView6.DataBind()
                    GridView6.FooterRow.Visible = False
                    '  Response.Write(GridView6.Rows.Count - 1)

                    'Dim sb21 As New StringBuilder()
                    'footer.RenderControl(New HtmlTextWriter(New StringWriter(sb21)))
                    'Literal1.Text = Literal1.Text & sb21.ToString


                    Dim sb2 As New StringBuilder()
                    inv.RenderControl(New HtmlTextWriter(New StringWriter(sb2)))
                    Literal1.Text = Literal1.Text & sb2.ToString
                    ' Literal1.Text = Literal1.Text & "<br style='page-break-after:always'/>"
                    If rcnt > 29 Then
                        Literal1.Text = Literal1.Text & "<DIV style='page-break-after:always'></DIV>"

                    End If

                End If
                inv1.Visible = False
                footer.Visible = False

                TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text))
                TextBox30.Text = genf.roundup(Val(TextBox31.Text) + Val(TextBox26.Text) + Val(TextBox35.Text))

                'total1 = 0
                'total2 = 0
                'total3 = 0
                'strnewrecord = "select [new_estimate_new_job_partss].[part_id] as [Parts ID], [new_estimate_new_job_partss].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [new_estimate_new_job_partss].[qty] as [Requisit Quantity],(select sum(j.qty) from estimate_new_job_parts j, estimate_new_job_cart k where j.job_id=k.job_id and k.km=new_estimate_new_job_partss.job_id and j.part_id=new_estimate_new_job_partss.part_id) as [Issued Quantity],'' as [Required Quantity], vehicle_parts.unit as [Unit] from [new_estimate_new_job_partss], vehicle_parts where [new_estimate_new_job_partss].[part_id]=vehicle_parts.id and new_estimate_new_job_partss.job_id='" & Val(Request.QueryString("url")) & "'"
                'genf.populate_grid(strnewrecord, GridView7)
                'total1 = 0
                'total2 = 0

                'strnewrecord = "select estimate_new_job_parts.part_no ' : ' + vehicle_parts.description as [Particulars], estimate_new_job_parts.qty as [Unit], saling_price as [Rate], estimate_new_job_parts.amount as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id"
                'genf.populate_grid(strnewrecord, GridView8)



            End If

            If Val(TextBox25.Text) = 0 Then
                Button2.Visible = False
                Button4.Visible = False
                Button3.Visible = False
            Else
                Button2.Visible = False
                Button4.Visible = False
                Button3.Visible = False
            End If
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
    Protected Sub GridView5_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(1).Text = Server.HtmlDecode(e.Row.Cells(1).Text)
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = genf.roundup(Val(e.Row.Cells(3).Text))
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            total1 = total1 + Val(e.Row.Cells(4).Text)
            Dim i
            For i = 3 To e.Row.Cells.Count - 1
                If Val(e.Row.Cells(i).Text) = "0" Then
                    e.Row.Cells(i).Text = ""
                End If
                If Val(e.Row.Cells(i).Text) = "0.00" Then
                    e.Row.Cells(i).Text = ""
                End If
            Next
            '    e.Row.Cells(6).Text = genf.roundup(Val(e.Row.Cells(6).Text))
            '    e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            '    e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            '    e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            '    e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            '    total1 = total1 + Val(e.Row.Cells(7).Text)

            '    e.Row.Cells(0).Visible = False
            '    e.Row.Cells(1).Visible = False
            '    e.Row.Cells(2).Visible = False
            '    e.Row.Cells(4).Visible = False
            '    '  e.Row.Cells(5).Visible = False
            '    ' e.Row.Cells(6).Visible = False
            '    e.Row.Cells(8).Visible = False
            '    e.Row.Cells(9).Visible = False
            '    e.Row.Cells(10).Visible = False

            '    e.Row.Cells(5).Text = ""
            '    e.Row.Cells(6).Text = ""
            'Dim lab As New Label
            'lab = e.Row.FindControl("Label1")
            'lab.Text = e.Row.RowIndex
            If lastrow = "-" And e.Row.Cells(0).Text <> "-" Then
                If e.Row.Cells(1).Text.Contains("Dent and Paint#") Then
                    e.Row.Cells(0).Text = ""
                Else
                    rsl = rsl + 1
                    e.Row.Cells(0).Text = rsl
                End If

                If lasthead = "Service:" Then
                    TextBox39.Text = Val(TextBox39.Text) + Val(e.Row.Cells(4).Text)
                    e.Row.Cells(2).Text = ""
                End If
                If lasthead = "Spares:" Then
                    TextBox40.Text = Val(TextBox40.Text) + Val(e.Row.Cells(4).Text)
                End If
                If lasthead = "Machine Shop Work:" Then
                    TextBox40.Text = Val(TextBox40.Text) + Val(e.Row.Cells(4).Text)
                End If
            End If
            If e.Row.Cells(0).Text = "-" Then

                If e.Row.Cells(1).Text = "Spares:" Or e.Row.Cells(1).Text = "Service:" Or e.Row.Cells(1).Text = "Machine Shop Work:" Then



                    lastrow = e.Row.Cells(0).Text
                    e.Row.Cells(0).Text = ""
                    rsl = 0
                    lasthead = e.Row.Cells(1).Text
                    If lasthead = "Service:" Then
                        TextBox39.Text = "0"
                        e.Row.Cells(2).Text = ""
                        e.Row.Cells(1).Font.Bold = True
                    End If
                    If lasthead = "Spares:" Then
                        TextBox40.Text = "0"
                        e.Row.Cells(2).Text = ""
                        e.Row.Cells(1).Font.Bold = True
                    End If
                    If lasthead <> "Spares:" Then
                        If lasthead = "Machine Shop Work:" Then

                            e.Row.Cells(2).Text = ""
                            e.Row.Cells(1).Font.Bold = True
                        End If
                    Else
                        TextBox40.Text = "0"
                        e.Row.Cells(2).Text = ""
                        e.Row.Cells(1).Font.Bold = True
                    End If
                End If

            End If

            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center


            Dim trr()
            trr = Split(e.Row.Cells(1).Text, "#")
            If trr(0).ToString = "Dent and Paint" Then
                If trr.Length > 2 Then
                    e.Row.Cells(1).Text = genf.returnvaluefromdv("select convert(nvarchar(50),(select count(*) from new_ESTIMATE_dent_paint j where j.job_id=new_ESTIMATE_dent_paint.job_id and j.tx_id<=new_ESTIMATE_dent_paint.tx_id)) + ') ' + description from new_ESTIMATE_dent_paint where tx_id='" & Val(trr(1).ToString) & "'", 0)
                Else
                    If trr.Length = 2 Then
                        If trr(1).ToString = "Total" Then
                            e.Row.Cells(1).Text = "Total"
                        End If
                    End If

                End If
                'If trr(1).ToString Then

                'End If
                '  ptmp()
                '   e.Row.Cells(1).Text = "Dent and Paint"
                '    e.Row.Cells(1).Text = genf.create_table3("select description from new_job_dent_paint where job_id in (select j.job_id from new_job_dent_paint j where j.tx_id='" & Val(trr(0).ToString) & "') and description<>'Dent and Paint'")
            End If
            If e.Row.Cells(2).Text.Contains("-") Then
                e.Row.Cells(2).Text = "-"
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            '    e.Row.Cells(7).Text = total1
            '    e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            '    e.Row.Cells(6).Text = "Total"
            '    e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

            '    e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            '    e.Row.Cells(0).Visible = False
            '    e.Row.Cells(1).Visible = False
            '    e.Row.Cells(2).Visible = False

            '    e.Row.Cells(4).Visible = False
            '    ' e.Row.Cells(5).Visible = False
            '    ' e.Row.Cells(6).Visible = False
            '    e.Row.Cells(8).Visible = False
            '    e.Row.Cells(9).Visible = False
            '    e.Row.Cells(10).Visible = False
            TextBox39.Text = genf.roundup(Val(TextBox39.Text))
            TextBox40.Text = genf.roundup(Val(TextBox40.Text))

            e.Row.Cells(4).Text = total1
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            TextBox28.Text = e.Row.Cells(4).Text
            TextBox41.Text = genf.roundup((Val(TextBox39.Text) * Val(TextBox34.Text)) / 100)
            TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text) - Val(TextBox35.Text))
            If CheckBox1.Checked = False Then

                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                    Label50.Text = "VAT on Service (7.5%) :"
                    Label56.Text = "VAT Amount (10%) :"
                Else
                    TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                    Label50.Text = "VAT on Service (10%) :"
                    Label56.Text = "VAT Amount (10%) :"
                End If

                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
            Else
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    '  TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                    Label50.Text = "VAT on Service (7.5%) :"
                    Label56.Text = "VAT Amount (10%) :"
                Else
                    ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                    Label50.Text = "VAT on Service (10%) :"
                    Label56.Text = "VAT Amount (10%) :"
                End If

                TextBox29.Text = "0.00"
            End If
            If CheckBox2.Checked = False Then

                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                    Label55.Text = "VAT on Spare Parts (7.5%) :"
                    Label56.Text = "VAT Amount (10%) :"
                Else
                    TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                    Label55.Text = "VAT on Spare Parts (10%) :"
                    Label56.Text = "VAT Amount (10%) :"
                End If
                '  TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
            Else
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                    Label55.Text = "VAT on Spare Parts (7.5%) :"
                    Label56.Text = "VAT Amount (10%) :"
                Else
                    'TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                    Label55.Text = "VAT on Spare Parts (10%) :"
                    Label56.Text = "VAT Amount (10%) :"
                End If
                TextBox36.Text = "0.00"
            End If
            TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
            TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
            TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text))

            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."
        End If
    End Sub


    Protected Sub GridView5_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView5.SelectedIndexChanged

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 7.5) / 100)
                Label50.Text = "VAT on Service (7.5%) :"
                Label56.Text = "VAT Amount (10%) :"
            Else
                TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 10) / 100)
                Label50.Text = "VAT on Service (10%) :"
                Label56.Text = "VAT Amount (10%) :"
            End If

            'TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 7.5) / 100)
            TextBox30.Text = genf.roundup(Val(TextBox29.Text) + Val(TextBox28.Text))
            TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text))
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                ' TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 7.5) / 100)
                Label50.Text = "VAT on Service (7.5%) :"
                Label56.Text = "VAT Amount (10%) :"
            Else
                'TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 10) / 100)
                Label50.Text = "VAT on Service (10%) :"
                Label56.Text = "VAT Amount (10%) :"
            End If


            TextBox29.Text = genf.roundup((Val(TextBox28.Text) * 0) / 100)
            TextBox30.Text = genf.roundup(Val(TextBox29.Text) + Val(TextBox28.Text))
            TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text))
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        End If
    End Sub


    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click

    End Sub

    Protected Sub GridView6_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView6.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

            total1 = total1 + Val(e.Row.Cells(4).Text)

            If Val(e.Row.Cells(0).Text) = 0 Then
                ' If e.Row.Cells(1).Font.Bold = True Then
                If e.Row.Cells(1).Text = "Spares:" Or e.Row.Cells(1).Text = "Service:" Or e.Row.Cells(1).Text = "Machine Shop Work:" Then
                    e.Row.Cells(1).Font.Bold = True
                    e.Row.Cells(2).Font.Bold = True
                    e.Row.Cells(3).Font.Bold = True
                    e.Row.Cells(4).Font.Bold = True
                    lastcat = e.Row.Cells(1).Text
                End If


            End If
            e.Row.Cells(1).Text = Server.HtmlDecode("<div class='truncated' align='left'>&nbsp;" & e.Row.Cells(1).Text & "</div>")
            e.Row.Cells(0).Text = "&nbsp;" & e.Row.Cells(0).Text
            'e.Row.Cells(1).Text = "&nbsp;" & e.Row.Cells(1).Text
            e.Row.Cells(2).Text = e.Row.Cells(2).Text & "&nbsp;"
            e.Row.Cells(3).Text = e.Row.Cells(3).Text & "&nbsp;"
            e.Row.Cells(4).Text = e.Row.Cells(4).Text & "&nbsp;"
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Text = total1
            bf = e.Row.Cells(4).Text
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            e.Row.Cells(3).Text = "Sub&nbsp;Total&nbsp;"
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = "P.T.O."
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(4).Text = e.Row.Cells(4).Text & "&nbsp;"
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).ColumnSpan = 2

        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Width = New Unit("81px")
            e.Row.Cells(1).Width = New Unit("540px")
            e.Row.Cells(2).Width = New Unit("70px")
            e.Row.Cells(3).Width = New Unit("70px")
            e.Row.Cells(4).Width = New Unit("70px")
        End If
    End Sub

    Protected Sub GridView6_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView6.SelectedIndexChanged

    End Sub
End Class


