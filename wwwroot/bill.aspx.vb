Imports System.Data
Imports System.Data.SqlClient
Imports System.Math
Imports System.Net

Partial Class bill
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
    Dim ami As New amtinwords
    Dim total1, total2, total3
    Dim lastrow, lasthead
    Dim rsl As Integer

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button1.Visible = True Then
            DropDownList11.Items.Clear()
            DropDownList11.Items.Add("Individual")
            DropDownList11.Items.Add("Corporate")
            TextBox44.Text = ""

            CheckBox1.Checked = False
            CheckBox2.Checked = False
            TextBox43.Text = ""
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
            TextBox27.Text = DateTime.Now.ToString("dd/MM/yyyy")
            If Not IsNothing(Request.QueryString("url")) Then

                Dim status = genf.returnvaluefromdv("select hstatus from new_job_cart where job_id='" + Request.QueryString("url") + "'", 0)

                If status = False Then
                    Dim a = GridView5.SelectedRow.RowIndex
                End If

                TextBox24.Text = Request.QueryString("url")

                'Dim status = genf.returnvaluefromdv("select hstatus from new_job_cart where job_id='" + TextBox24.Text + "'", 0)
                'If status.ToString <> "" Then
                '    If status = True Then

                strnewrecord = "SELECT sales_executive,type_of_customer FROM [new_job_cart] where job_id='" & Val(TextBox24.Text) & "'"
                '  Response.Write(strnewrecord)
                Dim ip4
                For ip4 = 0 To DropDownList11.Items.Count - 1
                    If DropDownList11.Items(ip4).Text = genf.returnvaluefromdv(strnewrecord, 1) Then
                        DropDownList11.SelectedIndex = ip4
                    End If
                Next

                strnewrecord = "SELECT sales_executive,type_of_customer FROM [new_job_cart] where job_id='" & Val(TextBox24.Text) & "'"
                '  Response.Write(strnewrecord)
                TextBox44.Text = genf.returnvaluefromdv(strnewrecord, 0)



                TextBox43.Text = genf.returnvaluefromdv("select note_det from job_bill where job_id='" & Val(Request.QueryString("url").ToString) & "' ", 0)

                strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, bill_no, vat, bill_date, vat1, disc_per, cash_disc, (select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no), customer_id FROM [new_job_cart] where job_id='" & Val(Request.QueryString("url").ToString) & "'"
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

                TextBox45.Text = genf.returnvaluefromdv(strnewrecord, 25)

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
                Try
                    TextBox27.Text = genf.getdatefromdb(genf.returnvaluefromdv(strnewrecord, 20)).ToString("dd/MM/yyyy")

                Catch ex As Exception

                End Try

                total1 = 0
                lastrow = ""
                rsl = 0
                strnewrecord = "with aq2 as (select distinct '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id  and service_master.spare='Service' and new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all select '-' as [Serial No],'Service:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from new_job_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'),"
                strnewrecord = strnewrecord & " q2 as (select distinct * from aq2"
                strnewrecord = strnewrecord & " union all  select '1'as [Serial No],service_master.service_name as [Particulars], '0' as [Unit], '0' as [Rate], new_job_service.cost as [Amount]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and service_master.spare='Service' and new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"
                strnewrecord = strnewrecord & "  union all  select '1' as [Serial No],description as [Particulars], '' as [Unit], '' as [Rate], '' as [Amount]   from new_job_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'"
                strnewrecord = strnewrecord & "  union all  select '' as [Serial No],'Dent and Paint#' + convert(nvarchar(50),tx_id) + '#' + description as [Particulars], '' as [Unit], Price as [Rate], Price as [Amount]   from new_job_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description<>'Dent and Paint'"
                strnewrecord = strnewrecord & "  union all  select '' as [Serial No],description + '#Total' as [Particulars], convert(nvarchar(50),qty) as [Unit], '' as [Rate], Price as [Amount]   from new_job_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' and description='Dent and Paint'"
                strnewrecord = strnewrecord & " ),   q1 AS ((select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=job_part.part_id) union all (select distinct '-' as [Serial No],'Spares:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id  and service_master.spare='Spare' and new_job_service.job_id='" & Val(Request.QueryString("url")) & "')) select * from q2   union all select distinct * from q1 union all  select '1'as [Serial No],vehicle_parts.parts_name as [Particulars], convert(nvarchar(50),sum(job_part.qty)) + ' ' + vehicle_parts.unit as [Unit], saling_price as [Rate], sum(job_part.amount) as [Amount] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=job_part.part_id and job_part.qty>'0' group by vehicle_parts.parts_name, vehicle_parts.unit, job_part.saling_price  union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty)  + ' ' + [unit] as [Unit], unit_cost as [Rate], new_job_service.cost as [Amount]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and service_master.spare='Spare' and new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all select distinct '-' as [Serial No],'Machine Shop Work:' as [Particulars], '0' as [Unit], '0' as [Rate], '0' as [Amount]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id  and service_master.spare='Machine Shop' and new_job_service.job_id='" & Val(Request.QueryString("url")) & "' union all  select '1'as [Serial No],service_master.service_name as [Particulars], convert(nvarchar(50),qty)  + ' ' + [unit] as [Unit], unit_cost as [Rate], new_job_service.cost as [Amount]   from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and service_master.spare='Machine Shop' and new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"

                genf.populate_grid(strnewrecord, GridView5)

                '  Response.Write(strnewrecord)
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

                'Else
                '    Dim a = GridView5.Rows(-1).Cells(-1).Text
            End If
            '    End If

            'End If

            If Val(TextBox25.Text) = 0 Then
                Button2.Visible = True
                Button4.Visible = False
                Button3.Visible = False
            Else
                Button2.Visible = True
                Button2.Text = "Modify Bill"
                Button4.Visible = True
                Button3.Visible = True


                If Not IsNothing(Request.QueryString("mode")) Then
                    If Request.QueryString("mode") = "Modification" Then
                        Button3.Visible = False

                        Button2.Visible = True
                    Else
                        Button3.Visible = True

                    End If
                Else
                    Button3.Visible = True
                End If
            End If
            Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)

            If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                '  e.Row.Cells(0).Visible = True
                '  e.Row.Cells(1).Visible = True
                Button4.Visible = True
            Else
                Button4.Visible = False
                '  e.Row.Cells(0).Visible = False
                ' e.Row.Cells(1).Visible = False
            End If

            'If Not IsNothing(Request.QueryString("url")) Then
            '    TextBox24.Text = ""
            '    Button2.Visible = False
            '    Button4.Visible = False

            '    'Dim status1 = genf.returnvaluefromdv("select hstatus from new_job_cart where job_id='" + TextBox24.Text + "'", 0)
            '    'If status1.ToString() = "" Then
            '    '    TextBox24.Text = ""
            '    '    Button2.Visible = False
            '    '    Button4.Visible = False
            '    'ElseIf status1 = False Then
            '    '    TextBox24.Text = ""
            '    '    Button2.Visible = False
            '    '    Button4.Visible = False
            '    'End If
            'End If
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
                    e.Row.Cells(1).Text = genf.returnvaluefromdv("select convert(nvarchar(50),(select count(*) from new_job_dent_paint j where j.job_id=new_job_dent_paint.job_id and j.tx_id<=new_job_dent_paint.tx_id)) + ') ' + description from new_job_dent_paint where tx_id='" & Val(trr(1).ToString) & "'", 0)
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




            Else
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    Label50.Text = "VAT on Service (7.5%) :"
                Else
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



            Else
                Dim vdt As New Date
                vdt = New Date(2016, 6, 1)
                If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                    Label55.Text = "VAT on Spare Parts (7.5%) :"
                Else
                    Label55.Text = "VAT on Spare Parts (10%) :"
                End If
                TextBox36.Text = "0.00"
            End If
            TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
            TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
            TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
            If Val(TextBox31.Text) > 0 Then
                TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."

            Else
                TextBox32.Text = "Refund In Words : " & ami.SpellNumber(Val(TextBox31.Text) * (-1)) & " Only."

            End If
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

        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label50.Text = "VAT on Service (7.5%) :"
            Else
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



        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))

        '  TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        If Val(TextBox31.Text) > 0 Then
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."

        Else
            TextBox32.Text = "Refund In Words : " & ami.SpellNumber(Val(TextBox31.Text) * (-1)) & " Only."

        End If
        CheckBox1.Focus()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim bill_no
        Dim prefix
        If CheckBox1.Checked = True And CheckBox2.Checked = True Then
            prefix = "V" 'X
        Else
            prefix = "V"
        End If
        If TextBox43.Text = "" Then
            TextBox43.Text = "-"

        End If

        If Val(TextBox25.Text) = 0 Then
            Dim gen_bill_no
            If prefix = "V" Then
                strnewrecord = "insert into job_bill_vat (job_id) values ('" & Val(TextBox24.Text) & "'); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                gen_bill_no = Val(Mycommand.ExecuteScalar.ToString)
            End If
            If prefix = "X" Then
                strnewrecord = "insert into job_bill_without_vat (job_id) values ('" & Val(TextBox24.Text) & "'); select scope_identity()"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                gen_bill_no = Val(Mycommand.ExecuteScalar.ToString)
            End If
            strnewrecord = "insert into job_bill (job_id, bill_date, gross, vat, payable, prefix, vbill_no, note_det) values ('" & Val(TextBox24.Text) & "','" & genf.getdate(TextBox27.Text) & "','" & Val(TextBox38.Text) & "','" & Val(TextBox37.Text) & "','" & Val(TextBox31.Text) & "','" & prefix & "','" & gen_bill_no & "','" & TextBox43.Text & "'); select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            bill_no = Val(Mycommand.ExecuteScalar.ToString)
        Else
            strnewrecord = "update job_bill set note_det='" & TextBox43.Text & "', prefix='" & prefix & "', gross='" & Val(TextBox38.Text) & "', vat='" & Val(TextBox37.Text) & "', payable='" & Val(TextBox31.Text) & "', job_id='" & Val(TextBox24.Text) & "', bill_date='" & genf.getdate(TextBox27.Text) & "' where bill_no='" & Val(TextBox25.Text) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
            bill_no = Val(TextBox25.Text)

        End If

        strnewrecord = "update new_job_cart set type_of_customer='" & DropDownList11.SelectedItem.Text & "',sales_executive='" & TextBox44.Text & "' where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        'Mycommand = New SqlCommand()
        'Mycommand.CommandType = CommandType.StoredProcedure
        'Mycommand.CommandText = "update_unit_master_sl"
        'Mycommand.Parameters.Add("@bc", SqlDbType.VarChar).Value = prefix
        'Mycommand.Parameters.Add("@id", SqlDbType.Int).Value = bill_no
        'Mycommand.Connection = Myconnection
        'Mycommand.CommandTimeout = 600
        'Mycommand.ExecuteNonQuery()


        strnewrecord = "update new_job_cart set bill_date='" & genf.getdate(TextBox27.Text) & "',  bill_no='" & Val(bill_no.ToString) & "',  disc_per='" & Val(TextBox34.Text) & "',cash_disc='" & Val(TextBox35.Text) & "', vat='" & CheckBox1.Checked.ToString & "', vat1='" & CheckBox2.Checked.ToString & "' where job_id='" & Val(TextBox24.Text) & "'"
        '  Response.Write(strnewrecord)
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()



        strnewrecord = "update new_job_service set service_status='Job Completed', service_rem='Job Completed', end_date='" & genf.getdate(TextBox27.Text) & "' where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "update new_job_dent_paint set service_status='Job Completed', service_rem='Job Completed', end_date='" & genf.getdate(TextBox27.Text) & "' where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "update new_job_cart set status='Job Completed' where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Dim nbll
        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, bill_no, vat, bill_date, vat1, disc_per, cash_disc, (select r.r_bill_no from job_bill r where r.bill_no=new_job_cart.bill_no), customer_id FROM [new_job_cart] where job_id='" & Val(Request.QueryString("url").ToString) & "'"
        nbll = genf.returnvaluefromdv(strnewrecord, 24)

        Dim customer_id
        customer_id = genf.returnvaluefromdv("select customer_id from new_job_cart where bill_no='" & Val(bill_no.ToString) & "'", 0)


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
            myqry = "select top 1 child_gp_id from ac_group  order by child_gp_id desc"
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







        '******************************************
        myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
        myconnection2.Open()

        Dim fin_yr
        If Val(genf.getdate(TextBox27.Text).ToString("MM")) >= 7 Then
            fin_yr = Val(genf.getdate(TextBox27.Text).ToString("yy")) & " - " & (Val(genf.getdate(TextBox27.Text).ToString("yy")) + 1)
        Else
            fin_yr = (Val(genf.getdate(TextBox27.Text).ToString("yy")) - 1) & " - " & (Val(genf.getdate(TextBox27.Text).ToString("yy")))

        End If

        Dim pvno, vtxno, vtxno1
        pvno = 0
        pvno = genf.returnvaluefromdv("select vno from new_job_cart where bill_no='" & Val(bill_no.ToString) & "'", 0)

        vtxno = 0
        vtxno1 = ""
        vtxno1 = genf.returnvaluefromdv("select vtxno from new_job_cart where bill_no='" & Val(bill_no.ToString) & "'", 0)



        Dim vno
        If Val(pvno.ToString) = 0 Then
            strnewrecord = "insert into journal_voucher (prefix,suffix,date,amount,operator,entry_date, branch_code, purpose,credit) values ('JV','" & fin_yr & "','" & genf.getdate(TextBox27.Text) & "','" & Val(TextBox31.Text) + Val(TextBox26.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Receivable Against Invoice No # " & Trim(nbll.ToString) & "','" & Val(TextBox31.Text) + Val(TextBox26.Text) & "'); select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)

            vno = Mycommand.ExecuteScalar.ToString()



        Else
            strnewrecord = "update journal_voucher set credit='" & Val(TextBox31.Text) + Val(TextBox26.Text) & "', purpose='Receivable Against Invoice No # " & Trim(nbll.ToString) & "', branch_code='2', prefix='JV',suffix='" & fin_yr & "',date='" & genf.getdate(TextBox27.Text) & "',amount='" & Val(TextBox31.Text) + Val(TextBox26.Text) & "' where vno='" & Val(pvno.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)

            Mycommand.ExecuteNonQuery()

            vno = Val(pvno.ToString)

        End If

        strnewrecord = "update new_job_cart set vno='" & Val(vno.ToString) & "' where bill_no='" & Val(bill_no.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        Dim slc, sln
        slc = 0
        sln = ""
        Dim myqry1
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

        'Dim vtxno1
        'vtxno1 = ""
        If Val(pvno.ToString) = 0 Then





            strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, amount,operator,entry_date, branch_code, purpose,credit) values ('JV','" & vno & "','" & fin_yr & "','JV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox27.Text) & "','1','516143','Receivable against Invoice','0','-','-','" & Val(TextBox31.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Receivable Against Invoice No # " & Trim(nbll.ToString) & "','0');select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            ' Mycommand.ExecuteNonQuery()
            vtxno = Mycommand.ExecuteScalar.ToString
            If vtxno1 = "" Then
                vtxno1 = vtxno
            Else
                vtxno1 = vtxno1 & "," & vtxno
            End If


            strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, glc, gl, slc, sln, lf, amount,operator,entry_date, branch_code, purpose,credit) values ('JV','" & vno & "','" & fin_yr & "','JV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox27.Text) & "','1','665315','Job Advance','0','-','-','" & Val(TextBox26.Text) & "','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Receivable Against Invoice No # " & Trim(nbll.ToString) & "','0');select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            ' Mycommand.ExecuteNonQuery()
            vtxno = Mycommand.ExecuteScalar.ToString
            If vtxno1 = "" Then
                vtxno1 = vtxno
            Else
                vtxno1 = vtxno1 & "," & vtxno
            End If


            strnewrecord = "insert into cash_voucher_det (prefix,vno,suffix,voucher_no,date,sl, slc, sln, glc, gl, lf, amount,operator,entry_date, branch_code, purpose,credit) values ('JV','" & vno & "','" & fin_yr & "','JV/" & vno & "/" & fin_yr & "','" & genf.getdate(TextBox27.Text) & "','2','0','-','" & Val(slc.ToString) & "','" & Trim(sln.ToString) & "','-','0','" & Session("uid").ToString & "','" & DateTime.Now & "','2','Receivable Against Invoice No # " & Trim(nbll.ToString) & "','" & Val(TextBox31.Text) + Val(TextBox26.Text) & "');select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            ' Mycommand.ExecuteNonQuery()
            vtxno = Mycommand.ExecuteScalar.ToString
            If vtxno1 = "" Then
                vtxno1 = vtxno
            Else
                vtxno1 = vtxno1 & "," & vtxno
            End If
        Else

            Dim vtxno2()
            vtxno2 = Split(vtxno1, ",")

            strnewrecord = "update cash_voucher_det set credit='0', purpose='Receivable Against Invoice No # " & Trim(nbll.ToString) & "',  branch_code='2', prefix='JV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='JV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox27.Text) & "',sl='1', glc='516143', gl='Receivable against Invoice', slc='0', sln='-', lf='-', amount='" & Val(TextBox31.Text) & "' where tx_no='" & Val(vtxno2(0).ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "update cash_voucher_det set credit='0', purpose='Receivable Against Invoice No # " & Trim(nbll.ToString) & "',  branch_code='2', prefix='JV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='JV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox27.Text) & "',sl='1', glc='665315', gl='Job Advance', slc='0', sln='-', lf='-', amount='" & Val(TextBox26.Text) & "' where tx_no='" & Val(vtxno2(1).ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()


            strnewrecord = "update cash_voucher_det set credit='" & Val(TextBox31.Text) + Val(TextBox26.Text) & "', purpose='Receivable Against Invoice No # " & Trim(nbll.ToString) & "',  branch_code='2', prefix='JV',vno='" & vno & "',suffix='" & fin_yr & "',voucher_no='JV/" & vno & "/" & fin_yr & "',date='" & genf.getdate(TextBox27.Text) & "',sl='2', Slc='0', SLN='-', Glc='" & Val(slc.ToString) & "', gl='" & Trim(sln.ToString) & "', lf='-', amount='0' where tx_no='" & Val(vtxno2(2).ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, myconnection2)
            Mycommand.ExecuteNonQuery()


        End If
        strnewrecord = "update new_job_cart set vtxno='" & Trim(vtxno1.ToString) & "' where bill_no='" & Val(bill_no.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        myconnection2.Close()
        '******************************************

        Myconnection.Close()
        'bill20.0For%20Job%20ID%20-%20Has%20Been%20Generate%20Successfully%20with%20Bill%20No%20-%20V-104025%20...%20and%20Bill%20Amount%3D%27%27

        ''New Added
        Dim meessageGenerate = "Bill For Job ID - " & TextBox24.Text & " Has Been Generate Succesfully with Bill No - " & genf.returnvaluefromdv("select r_bill_no from job_bill where bill_no='" & Val(bill_no.ToString) & "'", 0) & " ... and Bill Amount='" & TextBox31.Text & "'"
        Dim mobileNumber = TextBox5.Text
        mobileNumber = "01784932050"


        If mobileNumber <> "" Then
            Dim url As String = "https://api.infobuzzer.net/v3.1/TransmitSMS?username=nm@synergyinterface.com&password=info@Pass&to=" & mobileNumber & "&text=" & meessageGenerate


            Dim rsb2 As StringBuilder
            rsb2 = New StringBuilder()
            rsb2.Append("<script language=""JavaScript"">")
            rsb2.Append("window.open('" & url & "','test');")
            rsb2.Append("</scri")
            rsb2.Append("pt>")
            Page.RegisterStartupScript("rtest1", rsb2.ToString())

            'Dim webClient As WebClient = New WebClient()
            ''Return webClient.DownloadString(New Uri(accountInformationUrl))
            'Dim retString As String

            'Try
            '    retString = webClient.DownloadString(New Uri(url))

            'Catch ex As WebException
            '    If ex.Status = WebExceptionStatus.ProtocolError AndAlso ex.Response IsNot Nothing Then
            '        Dim resp = DirectCast(ex.Response, HttpWebResponse)
            '        If resp.StatusCode = HttpStatusCode.NotFound Then
            '            ' HTTP 404
            '            'other steps you want here
            '        End If
            '    End If
            '    'throw any other exception - this should not occur
            '    Throw
            'End Try
        End If



        Dim alertScript = "alert('Bill For Job ID - " & TextBox24.Text & " Has Been Generate Succesfully with Bill No - " & genf.returnvaluefromdv("select r_bill_no from job_bill where bill_no='" & Val(bill_no.ToString) & "'", 0) & " ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)



        Button1.Visible = True
        Page_Load(sender, e)
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('print_bill.aspx?url=" & Val(Request.QueryString("url")) & "','print_bill');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('print_bill.aspx?url=" & Request.QueryString("url") & "','print_bill');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub
    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        Dim rsb11 As StringBuilder
        rsb11 = New StringBuilder()
        rsb11.Append("<script language=""JavaScript"">")
        rsb11.Append("window.open('print_estimate_bill.aspx?url=" & Request.QueryString("url") & "','print_estimate_bill');")
        rsb11.Append("</scri")
        rsb11.Append("pt>")
        Page.RegisterStartupScript("rtest11", rsb11.ToString())
    End Sub


    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim bill_no

        If Val(TextBox25.Text) > 0 Then
            '    strnewrecord = "insert into job_bill (job_id, bill_date) values ('" & Val(TextBox24.Text) & "','" & genf.getdate(TextBox27.Text) & "'); select scope_identity()"
            '    Mycommand = New SqlCommand(strnewrecord, Myconnection)
            '    bill_no = Val(Mycommand.ExecuteScalar.ToString)
            'Else
            strnewrecord = "delete from job_bill where bill_no='" & Val(TextBox25.Text) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
            bill_no = Val(TextBox25.Text)

        End If

        Dim pvno = genf.returnvaluefromdv("select vno from new_job_cart where bill_no='" & Val(TextBox25.Text) & "'", 0)
        'Dim pvno1
        'pvno1 = genf.returnvaluefromdv("select voucher_no from journal_voucher where vno='" & Val(pvno.ToString) & "'", 0)


        myconnection2 = New System.Data.SqlClient.SqlConnection(strconnection2)
        myconnection2.Open()

        'Dim pvno
        Dim myqry1
        'myqry1 = "select vno from new_job_cart where bill_no='" & Val(TextBox25.Text) & "'"
        'Mycommand = New SqlCommand(myqry1, myconnection2)
        'Mydataadapter = New SqlDataAdapter(Mycommand)
        'Mydataadapter.Fill(mydataset, "admin")
        'dv.Table = mydataset.Tables(0)
        'If dv.Count > 0 Then
        '    pvno = Val(dv(0)(0).ToString)

        'End If
        'dv.Table.Clear()
        'mydataset.Tables.Clear()

        Dim pvno1
        myqry1 = "select voucher_no from journal_voucher where vno='" & Val(pvno.ToString) & "'"
        Mycommand = New SqlCommand(myqry1, myconnection2)
        Mydataadapter = New SqlDataAdapter(Mycommand)
        Mydataadapter.Fill(mydataset, "admin")
        dv.Table = mydataset.Tables(0)
        If dv.Count > 0 Then
            pvno1 = dv(0)(0).ToString

        End If
        dv.Table.Clear()
        mydataset.Tables.Clear()


        strnewrecord = "delete from journal_voucher where vno='" & Val(pvno.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, myconnection2)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from cash_voucher_det where voucher_no='" & Trim(pvno1.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, myconnection2)
        Mycommand.ExecuteNonQuery()
        myconnection2.Close()




        strnewrecord = "update new_job_cart set vno=NULL, vat1=NULL, disc_per=NULL, cash_disc=NULL, bill_date=NULL,  bill_no=NULL, vat=NULL where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        strnewrecord = "update new_job_service set service_status='Job Started', service_rem=NULL,  end_date=NULL where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "update new_job_dent_paint set service_status='Job Started', service_rem=NULL, end_date=NULL where job_id='" & Val(TextBox24.Text) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()



        Myconnection.Close()

        Dim alertScript = "alert('Bill For Job ID - " & TextBox24.Text & " Has Been Deleted Succesfully with Bill No - " & genf.returnvaluefromdv("select r_bill_no from job_bill where bill_no='" & Val(bill_no.ToString) & "'", 0) & " ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

        Button1.Visible = True
        Page_Load(sender, e)
    End Sub

    ''New Added
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



        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label50.Text = "VAT on Service (7.5%) :"
            Else
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



        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
        ' TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        If Val(TextBox31.Text) > 0 Then
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."

        Else
            TextBox32.Text = "Refund In Words : " & ami.SpellNumber(Val(TextBox31.Text) * (-1)) & " Only."

        End If
        TextBox34.Focus()
    End Sub

    ''New Added
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




        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label50.Text = "VAT on Service (7.5%) :"
            Else
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



        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
        ' TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        If Val(TextBox31.Text) > 0 Then
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."

        Else
            TextBox32.Text = "Refund In Words : " & ami.SpellNumber(Val(TextBox31.Text) * (-1)) & " Only."

        End If
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




        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label50.Text = "VAT on Service (7.5%) :"
            Else
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



        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))
        ' TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        If Val(TextBox31.Text) > 0 Then
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."

        Else
            TextBox32.Text = "Refund In Words : " & ami.SpellNumber(Val(TextBox31.Text) * (-1)) & " Only."

        End If
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




        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label50.Text = "VAT on Service (7.5%) :"
            Else
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




        Else
            Dim vdt As New Date
            vdt = New Date(2016, 6, 1)
            If DateDiff(DateInterval.Day, genf.getdate(TextBox27.Text), vdt) > 0 Then
                Label55.Text = "VAT on Spare Parts (7.5%) :"
            Else
                Label55.Text = "VAT on Spare Parts (10%) :"
            End If
            TextBox36.Text = "0.00"
        End If
        TextBox37.Text = genf.roundup(Round(Val(TextBox29.Text) + Val(TextBox36.Text), 0))
        TextBox30.Text = genf.roundup((Val(TextBox38.Text) + Val(TextBox37.Text)))
        TextBox31.Text = genf.roundup(Val(TextBox30.Text) - Val(TextBox26.Text) + Val(aitAmount.Text))

        ' TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Taka Only."
        If Val(TextBox31.Text) > 0 Then
            TextBox32.Text = "In Words : " & ami.SpellNumber(Val(TextBox31.Text)) & " Only."

        Else
            TextBox32.Text = "Refund In Words : " & ami.SpellNumber(Val(TextBox31.Text) * (-1)) & " Only."

        End If
        CheckBox2.Focus()
    End Sub
End Class
