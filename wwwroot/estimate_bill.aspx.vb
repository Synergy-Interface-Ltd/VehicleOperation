Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class estimate_bill
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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button1.Visible = True Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            TextBox27.Text = DateTime.Now.ToString("dd/MM/yyyy")

            Button1.Visible = False
            TextBox28.Text = ""
            TextBox26.Text = ""
            TextBox29.Text = ""

            TextBox30.Text = ""
            TextBox31.Text = ""
            TextBox32.Text = ""

            TextBox34.Text = ""
            TextBox35.Text = ""

            TextBox25.Text = ""
            If Not IsNothing(Request.QueryString("url")) Then
                TextBox24.Text = Request.QueryString("url")
                strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, bill_no, vat, bill_date, vat1, disc_per, cash_disc, (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), tnc FROM [estimate_new_job_cart] where job_id='" & Val(Request.QueryString("url").ToString) & "'"
                TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
                TextBox2.Text = genf.returnvaluefromdv(strnewrecord, 1)
                TextBox3.Text = genf.returnvaluefromdv(strnewrecord, 2)
                TextBox4.Text = genf.returnvaluefromdv(strnewrecord, 3)
                TextBox5.Text = genf.returnvaluefromdv(strnewrecord, 4)
                Dim dt1 As New DateTime
                dt1 = genf.returnvaluefromdv(strnewrecord, 5)
                '     TextBox6.Text = dt1.ToString("dd/MM/yyyy")
                Dim k

                '   Label34.Text = Val(dt1.ToString("HH"))


                ' Label35.Text = Val(dt1.ToString("mm"))

                Dim dt2 As New DateTime
                dt2 = genf.returnvaluefromdv(strnewrecord, 6)
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
                TextBox25.Text = Val(genf.returnvaluefromdv(strnewrecord, 18))

                If genf.returnvaluefromdv(strnewrecord, 19) = "True" Then
                    CheckBox1.Checked = True
                Else
                    If genf.returnvaluefromdv(strnewrecord, 19) = "False" Then

                        CheckBox1.Checked = False
                    Else
                        CheckBox1.Checked = True
                    End If
                End If


                If genf.returnvaluefromdv(strnewrecord, 21) = "True" Then
                    CheckBox2.Checked = True
                Else
                    If genf.returnvaluefromdv(strnewrecord, 21) = "False" Then

                        CheckBox2.Checked = False
                    Else
                        CheckBox2.Checked = True
                    End If
                End If
                TextBox34.Text = genf.roundup(Val(genf.returnvaluefromdv(strnewrecord, 22)))
                TextBox35.Text = genf.roundup(Val(genf.returnvaluefromdv(strnewrecord, 23)))
                TextBox42.Text = ((genf.returnvaluefromdv(strnewrecord, 24)))
                If genf.returnvaluefromdv(strnewrecord, 25).ToString = "-" Then
                    TextBox43.Visible = False
                    Literal1.Text = "" 'Server.HtmlDecode(genf.returnvaluefromdv(strnewrecord, 25).ToString.Replace(Environment.NewLine, "<br>"))
                    tnc.Visible = False
                Else
                    TextBox43.Visible = True
                    Literal1.Text = Server.HtmlDecode(genf.returnvaluefromdv(strnewrecord, 25).ToString.Replace(Environment.NewLine, "<br>"))
                    tnc.Visible = True
                End If

                Try
                    TextBox27.Text = genf.getdatefromdb(genf.returnvaluefromdv(strnewrecord, 20)).ToString("dd/MM/yyyy")

                Catch ex As Exception

                End Try
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                    Label50.Text = "VAT on Service (7.5%) :"
                Else
                    ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                    Label50.Text = "VAT on Service (10%) :"
                End If

                total1 = 0
                lastrow = ""
                rsl = 0
                '   strnewrecord = "select distinct '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master, technician_master where estimate_new_job_service.technician_id=technician_master.technician_id and estimate_new_job_service.service_id=service_master.service_id and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master, technician_master where estimate_new_job_service.technician_id=technician_master.technician_id and estimate_new_job_service.service_id=service_master.service_id and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'  union all  select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),estimate_new_job_parts.qty) + ' ' + vehicle_parts.unit as [Unit], estimate_new_job_parts.price as [Rate], estimate_new_job_parts.total as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id and estimate_new_job_parts.qty>'0'"
                '  strnewrecord = "with q2 as (select distinct '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where  estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'),   q1 AS ((select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id) union all (select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "')) select * from q2   union all select distinct * from q1 union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),estimate_new_job_parts.qty) + ' ' + vehicle_parts.unit as [Unit], estimate_new_job_parts.price as [Rate], estimate_new_job_parts.total as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id and estimate_new_job_parts.qty>'0'  union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (' + estimate_new_job_service.unit + ')' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'  union all select distinct '-' as [Serial No],'Machine Shop Work:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (' + estimate_new_job_service.unit + ')' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]   from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"


                strnewrecord = "with aq2 as (select distinct '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all select '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'),"
                strnewrecord = strnewrecord & " q2 as (select distinct * from aq2"
                strnewrecord = strnewrecord & " union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where  estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Service' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"
                strnewrecord = strnewrecord & "  union all  select '1' as [Serial No],description as [Particulars], '' as [Unit], '' as [Rate], '' as [Amount]   from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'"
                strnewrecord = strnewrecord & "  union all  select '' as [Serial No],'Dent and Paint#' + convert(nvarchar(50),tx_id) + '#' + description as [Particulars], '' as [Unit], Price as [Rate], Price as [Amount]   from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description<>'Dent and Paint'"
                strnewrecord = strnewrecord & "  union all  select '' as [Serial No],description + '#Total' as [Particulars], convert(nvarchar(50),qty) as [Unit], '' as [Rate], Price as [Amount]   from new_ESTIMATE_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'"
                strnewrecord = strnewrecord & " ),   q1 AS ((select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id) union all (select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "')) select * from q2   union all select distinct * from q1 union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),estimate_new_job_parts.qty) + ' ' + vehicle_parts.unit as [Unit], estimate_new_job_parts.price as [Rate], estimate_new_job_parts.total as [Amount] from estimate_new_job_parts, estimate_new_job_cart, vehicle_parts where estimate_new_job_parts.job_id=estimate_new_job_cart.job_id and estimate_new_job_cart.job_id='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_new_job_parts.part_id and estimate_new_job_parts.qty>'0'  union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (' + estimate_new_job_service.unit + ')' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Spare' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'  union all select distinct '-' as [Serial No],'Machine Shop Work:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id  and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty) + ' (' + estimate_new_job_service.unit + ')' as [Unit], unit_cost as [Rate], estimate_new_job_service.cost as [Amount]   from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and service_master.spare='Machine Shop' and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"




                genf.populate_grid(strnewrecord, GridView5)
                ' Response.Write(strnewrecord)


                If GridView5.Rows.Count > 0 Then
                    If GridView5.Rows(GridView5.Rows.Count - 1).Cells(1).Text = "Spares:" Then
                        GridView5.Rows(GridView5.Rows.Count - 1).Visible = False

                    End If
                    If GridView5.Rows(GridView5.Rows.Count - 1).Cells(1).Text = "Machine Shop Work:" Then
                        GridView5.Rows(GridView5.Rows.Count - 1).Visible = False

                    End If
                End If
                'total1 = 0
                'total2 = 0
                'total3 = 0
                'strnewrecord = "select [new_job_parts].[part_id] as [Parts ID], [new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [new_job_parts].[qty] as [Requisit Quantity],(select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity],'' as [Required Quantity], vehicle_parts.unit as [Unit] from [new_job_parts], vehicle_parts where [new_job_parts].[part_id]=vehicle_parts.id and new_job_parts.job_id='" & Val(Request.QueryString("url")) & "'"
                'genf.populate_grid(strnewrecord, GridView7)
                'total1 = 0
                'total2 = 0

                'strnewrecord = "select job_part.part_no ' : ' + vehicle_parts.description as [Particulars], job_part.qty as [Unit], saling_price as [Rate], job_part.amount as [Amount] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=job_part.part_id"
                'genf.populate_grid(strnewrecord, GridView8)



            End If

            If Val(TextBox25.Text) = 0 Then
                Button2.Visible = True
                Button4.Visible = False
                Button40.Visible = False
                Button3.Visible = False
                Button2.Text = "Generate Estimate"
            Else
                Button2.Visible = True
                Button2.Text = "Modify Estimate"
                Button4.Visible = True
                Button40.Visible = True
                Button3.Visible = True
            End If
        End If
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
                Else
                    TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                    Label50.Text = "VAT on Service (10%) :"
                End If

                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
            Else
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                    Label50.Text = "VAT on Service (7.5%) :"
                Else
                    ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                    Label50.Text = "VAT on Service (10%) :"
                End If
                TextBox29.Text = "0.00"
            End If
            If CheckBox2.Checked = False Then

                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                    Label55.Text = "VAT on Spare Parts (7.5%) :"
                Else
                    TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                    Label55.Text = "VAT on Spare Parts (10%) :"
                End If

                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
            Else

                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    'TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                    Label55.Text = "VAT on Spare Parts (7.5%) :"
                Else
                    'TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                    Label55.Text = "VAT on Spare Parts (10%) :"
                End If

                TextBox36.Text = "0.00"
            End If
            TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
            TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
            TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))

            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."
        End If
        'If e.Row.RowType = DataControlRowType.Header Then
        '    e.Row.Cells(0).Visible = False
        '    e.Row.Cells(1).Visible = False
        '    e.Row.Cells(2).Visible = False

        '    e.Row.Cells(4).Visible = False
        '    ' e.Row.Cells(5).Visible = False
        '    ' e.Row.Cells(6).Visible = False
        '    e.Row.Cells(8).Visible = False
        '    e.Row.Cells(9).Visible = False
        '    e.Row.Cells(10).Visible = False
        'End If
    End Sub


    Protected Sub GridView5_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView5.SelectedIndexChanged

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged

        TextBox41.Text = genf.roundup((Val(TextBox39.Text) * Val(TextBox34.Text)) / 100)
        TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text) - Val(TextBox35.Text))
        If CheckBox1.Checked = False Then
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            TextBox29.Text = "0.00"
        End If
        If CheckBox2.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            '  TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))

        TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        CheckBox1.Focus()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim bill_no
        Dim prefix
        If CheckBox1.Checked = True And CheckBox2.Checked = True Then
            prefix = "X"
        Else
            prefix = "V"
        End If
        If Val(TextBox25.Text) = 0 Then
            Dim gen_bill_no
            If prefix = "V" Then
                strnewrecord = "insert into estimate_job_bill_vat (job_id) values ('" & Val(TextBox24.Text) & "'); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                gen_bill_no = Val(Mycommand.ExecuteScalar.ToString)
            End If
            If prefix = "X" Then
                strnewrecord = "insert into estimate_job_bill_without_vat (job_id) values ('" & Val(TextBox24.Text) & "'); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                gen_bill_no = Val(Mycommand.ExecuteScalar.ToString)
            End If
            strnewrecord = "insert into estimate_job_bill (job_id, bill_date, gross, vat, payable, prefix, vbill_no) values ('" & Val(TextBox24.Text) & "','" & genf.getdate(TextBox27.Text) & "','" & Val(TextBox38.Text) & "','" & Val(TextBox37.Text) & "','" & Val(TextBox31.Text) & "','" & prefix & "','" & gen_bill_no & "'); select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            bill_no = Val(Mycommand.ExecuteScalar.ToString)
        Else
            strnewrecord = "update estimate_job_bill set prefix='" & prefix & "', gross='" & Val(TextBox38.Text) & "', vat='" & Val(TextBox37.Text) & "', payable='" & Val(TextBox31.Text) & "', job_id='" & Val(TextBox24.Text) & "', bill_date='" & genf.getdate(TextBox27.Text) & "' where bill_no='" & Val(TextBox25.Text) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
            bill_no = Val(TextBox25.Text)

        End If

        'Mycommand = New SqlCommand()
        'Mycommand.CommandType = CommandType.StoredProcedure
        'Mycommand.CommandText = "update_unit_master_sl"
        'Mycommand.Parameters.Add("@bc", SqlDbType.VarChar).Value = prefix
        'Mycommand.Parameters.Add("@id", SqlDbType.Int).Value = bill_no
        'Mycommand.Connection = Myconnection
        'Mycommand.CommandTimeout = 600
        'Mycommand.ExecuteNonQuery()


        strnewrecord = "update estimate_new_job_cart set bill_date='" & genf.getdate(TextBox27.Text) & "',  bill_no='" & Val(bill_no.ToString) & "',  disc_per='" & Val(TextBox34.Text) & "',cash_disc='" & Val(TextBox35.Text) & "', vat='" & CheckBox1.Checked.ToString & "', vat1='" & CheckBox2.Checked.ToString & "' where job_id='" & Val(TextBox24.Text) & "'"
        ' Response.Write(strnewrecord)
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Myconnection.Close()

        Dim alertScript = "alert('Bill For Estimated Job ID - " & TextBox24.Text & " Has Been Generate Succesfully with Estimate No - " & genf.returnvaluefromdv("select r_bill_no from estimate_job_bill where bill_no='" & Val(bill_no.ToString) & "'", 0) & " ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

        Button1.Visible = True
        Page_Load(sender, e)
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('print_estimate.aspx?url=" & Val(Request.QueryString("url")) & "','print_estimate');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('print_estimate.aspx?url=" & Request.QueryString("url") & "','print_estimate');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub
    Protected Sub Button40_Click(sender As Object, e As System.EventArgs) Handles Button40.Click

        Dim ParamX As String = "example"
        Dim script As String = "window.open('print_estimate_part.aspx?url=" & Request.QueryString("url") & "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "OpenWindow", script, True)


        'Dim rsb2 As StringBuilder
        'rsb2 = New StringBuilder()
        'rsb2.Append("<script language=""JavaScript"">")
        'rsb2.Append("window.open('print_estimate_part.aspx?url=" & Request.QueryString("url") & "','print_estimate_part');")
        'rsb2.Append("</scri")
        'rsb2.Append("pt>")
        'Page.RegisterStartupScript("rtest1", rsb2.ToString())
    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim bill_no

        If Val(TextBox25.Text) > 0 Then
            '    strnewrecord = "insert into estimate_job_bill (job_id, bill_date) values ('" & Val(TextBox24.Text) & "','" & genf.getdate(TextBox27.Text) & "'); select scope_identity()"
            '    Mycommand = New SqlCommand(strnewrecord, Myconnection)
            '    bill_no = Val(Mycommand.ExecuteScalar.ToString)
            'Else
            strnewrecord = "delete from estimate_job_bill where bill_no='" & Val(TextBox25.Text) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
            bill_no = Val(TextBox25.Text)

        End If
        strnewrecord = "update estimate_new_job_cart set vat1=NULL, disc_per=NULL, cash_disc=NULL, bill_date=NULL,  bill_no=NULL, vat=NULL where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Myconnection.Close()

        Dim alertScript = "alert('Estimate For Estimate ID - " & TextBox24.Text & " Has Been Deleted Succesfully with Estimate No - " & genf.returnvaluefromdv("select r_bill_no from estimate_job_bill where bill_no='" & Val(bill_no.ToString) & "'", 0) & " ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

        Button1.Visible = True
        Page_Load(sender, e)
    End Sub

    Protected Sub TextBox34_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox34.TextChanged
        TextBox41.Text = genf.roundup((Val(TextBox39.Text) * Val(TextBox34.Text)) / 100)
        TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text) - Val(TextBox35.Text))
        If CheckBox1.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                'TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            TextBox29.Text = "0.00"
        End If
        If CheckBox2.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                'TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
        TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        TextBox34.Focus()
    End Sub

    Protected Sub TextBox35_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox35.TextChanged
        TextBox41.Text = genf.roundup((Val(TextBox39.Text) * Val(TextBox34.Text)) / 100)

        TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text) - Val(TextBox35.Text))
        If CheckBox1.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                'TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                'TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            TextBox29.Text = "0.00"
        End If
        If CheckBox2.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            '  TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                '  TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
        TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        TextBox35.Focus()
    End Sub

    ''New Added
    Protected Sub TextBox6_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox6.TextChanged

        If TextBox6.Text <> "" Then
            Dim subTotal = Val(TextBox28.Text)

            Dim aitPercentage = Val(TextBox6.Text)

            Dim aitValue = (subTotal * aitPercentage) / 100
            aitAmount.Text = aitValue.ToString()

        End If

        TextBox41.Text = genf.roundup((Val(TextBox39.Text) * Val(TextBox34.Text)) / 100)

        TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text) - Val(TextBox35.Text))
        If CheckBox1.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                'TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                'TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If

            TextBox29.Text = "0.00"
        End If
        If CheckBox2.Checked = False Then

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            '  TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
        Else

            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                '  TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If

            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
        TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        TextBox35.Focus()

    End Sub


    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged

        TextBox41.Text = genf.roundup((Val(TextBox39.Text) * Val(TextBox34.Text)) / 100)
        TextBox38.Text = genf.roundup(Val(TextBox28.Text) - Val(TextBox41.Text) - Val(TextBox35.Text))
        If CheckBox1.Checked = False Then
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If
            ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 7.5) / 100))
                Label50.Text = "VAT on Service (7.5%) :"
            Else
                ' TextBox29.Text = genf.roundup((((Val(TextBox39.Text) - Val(TextBox41.Text)) * 10) / 100))
                Label50.Text = "VAT on Service (10%) :"
            End If
            TextBox29.Text = "0.00"
        End If
        If CheckBox2.Checked = False Then
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                ' TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 7.5) / 100)
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                'TextBox36.Text = genf.roundup(((Val(TextBox40.Text)) * 10) / 100)
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))

        TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        CheckBox2.Focus()
    End Sub
End Class
