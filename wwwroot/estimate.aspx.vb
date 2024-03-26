Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class estimate
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
            Button6.Visible = False
            Button5.Visible = False
            Button7.Visible = False

            DropDownList8.Items.Clear()
            DropDownList8.Items.Add("-")
            DropDownList8.Items.Add("Point")
            DropDownList8.Items.Add("Unit")
            DropDownList8.Items.Add("CC")
            DropDownList8.Items.Add("Ft")
            DropDownList8.Items.Add("gm")
            DropDownList8.Items.Add("Kg")
            DropDownList8.Items.Add("Lb")
            DropDownList8.Items.Add("Litre")
            DropDownList8.Items.Add("ml")
            DropDownList8.Items.Add("mm")
            DropDownList8.Items.Add("Pc")
            DropDownList8.Items.Add("Set")





            DropDownList8.SelectedIndex = 0

            DropDownList9.Items.Clear()
            DropDownList9.Items.Add("-")
            DropDownList9.Items.Add("Point")
            DropDownList9.Items.Add("Unit")
            DropDownList9.Items.Add("CC")
            DropDownList9.Items.Add("Ft")
            DropDownList9.Items.Add("gm")
            DropDownList9.Items.Add("Kg")
            DropDownList9.Items.Add("Lb")
            DropDownList9.Items.Add("Litre")
            DropDownList9.Items.Add("ml")
            DropDownList9.Items.Add("mm")
            DropDownList9.Items.Add("Pc")
            DropDownList9.Items.Add("Set")





            DropDownList9.SelectedIndex = 0




            DropDownList6.Items.Clear()
            DropDownList6.Items.Add("Cash")
            DropDownList6.Items.Add("Cheque")
            DropDownList6.SelectedIndex = 0

            Label31.Text = "Create Estimate"
            Me.Title = "Create Estimate"
            Button1.Visible = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            genf.populate_grid("select sl, description from temp_table order by sl", GridView1)
            genf.populate_grid("select sl, description from temp_table order by sl", GridView2)
            genf.populate_grid("select sl, description from temp_table order by sl", GridView3)

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
            TextBox17.Text = ""
            TextBox18.Text = ""

            TextBox32.Text = "1"
            TextBox33.Text = ""
            '  CheckBox3.Checked = False
            TextBox34.Text = ""
            TextBox35.Text = ""
            TextBox36.Text = ""
            TextBox37.Text = ""
            TextBox38.Text = ""
            TextBox39.Text = ""
            TextBox40.Text = ""
            TextBox40.Text = genf.returnvaluefromdv("select [Terms] from Terms", 0)
            '  TextBox40.Text = TextBox40.Text

            TextBox19.Text = ""
            TextBox20.Text = ""
            TextBox21.Text = ""
            TextBox30.Text = ""
            TextBox31.Text = ""

            TextBox23.Text = ""
            TextBox24.Text = ""

            GridView4.DataSource = Nothing
            GridView4.DataBind()
            GridView5.DataSource = Nothing
            GridView5.DataBind()
            GridView6.DataSource = Nothing
            GridView6.DataBind()
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

            TextBox6.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox7.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox25.Text = DateTime.Now.ToString("dd/MM/yyyy")
            TextBox29.Text = DateTime.Now.ToString("dd/MM/yyyy")

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
            TextBox26.Text = ""
            If Not IsNothing(Request.QueryString("url")) Then
                Label33.Text = Request.QueryString("url")

                total1 = 0
                total2 = 0

                'strnewrecord = "select estimate_job_part.job_id as [Issue ID], estimate_job_part.part_no as [Parts Name], vehicle_parts.description as [Description], estimate_job_part.qty as [Quantity], estimate_job_part.amount as [Price] from estimate_job_part, job_sheet, vehicle_parts where estimate_job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=estimate_job_part.part_id"
                'genf.populate_grid(strnewrecord, GridView8)

                Button6.Visible = True
                Button7.Visible = True
                Button22.Visible = True
                Button4.Text = "Modify"
                Label31.Text = "Modify Estimate"
                Me.Title = "Modify Estimate"

                Button5.Visible = True
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
                If genf.returnvaluefromdv(strnewrecord, 14) = "True" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                If genf.returnvaluefromdv(strnewrecord, 15) = "True" Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If
                Label30.Text = genf.returnvaluefromdv(strnewrecord, 16)

                'TextBox24.Text = Val(genf.returnvaluefromdv(strnewrecord1, 1).ToString)

                If Val(TextBox24.Text) > 0 Then
                    Button11.Visible = True
                Else
                    Button11.Visible = False
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

                Label35.Text = genf.returnvaluefromdv(strnewrecord, 20).ToString
                Label48.Text = genf.returnvaluefromdv(strnewrecord, 21).ToString
                TextBox40.Text = genf.returnvaluefromdv(strnewrecord, 22).ToString

                total1 = 0
                strnewrecord = "select estimate_new_job_service.service_id as [Service ID], service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], estimate_new_job_service.unit_cost as [Service Charge], estimate_new_job_service.qty as [Qty of Service], unit as [Unit], estimate_new_job_service.cost as [Total Value],spare as [Type]  from estimate_new_job_service, service_master where estimate_new_job_service.service_id=service_master.service_id and estimate_new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"
                genf.populate_grid(strnewrecord, GridView5)
                total1 = 0
                total2 = 0
                total3 = 0
                strnewrecord = "select [estimate_new_job_parts].[part_id] as [Parts ID], [estimate_new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [estimate_new_job_parts].[qty] as [Requisit Quantity],'0' as [Issued Quantity],'' as [Required Quantity], vehicle_parts.unit as [Unit],price as [Price], total as [Total] from [estimate_new_job_parts], vehicle_parts where [estimate_new_job_parts].[part_id]=vehicle_parts.id and estimate_new_job_parts.job_id='" & Val(Request.QueryString("url")) & "'"
                genf.populate_grid(strnewrecord, GridView7)




                strnewrecord = "select Description as [Description], qty as [Quantity], price as [Rate], Tx_id from new_estimate_dent_paint where job_id='" & Val(Request.QueryString("url")) & "' order by [Tx_id]"
                genf.populate_grid(strnewrecord, GridView9)
            Else
                Button11.Visible = False
                Button22.Visible = False
                Label33.Text = ""
                Button4.Text = "Submit"
                Button5.Visible = False
                Label31.Text = "Create Estimate"
                Me.Title = "Create Estimate"
                Button6.Visible = False
                GridView9.DataSource = Nothing
                GridView9.DataBind()

            End If
            If Val(Label48.Text) > 0 Then

                Label65.Visible = True
                TextBox44.Visible = True
                Button19.Visible = True

                Button4.Visible = False
                Button5.Visible = False
                Button7.Text = "Print Estimate"
            Else
                Label65.Visible = False
                TextBox44.Visible = False
                Button19.Visible = False

                Button4.Visible = True
                Button5.Visible = True
                Button7.Text = "Print Estimate"
            End If
            Button6.Visible = False


            If Not IsNothing(Session("uid")) Then

                Dim genf As New genfunction

                Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
                'Response.Write(Trim(admin_type.ToString.ToUpper))

                If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                    Button5.Visible = True
                Else
                    Button5.Visible = False

                End If
            Else
                Response.Redirect("login.aspx")
            End If


            TextBox1.Focus()

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        GridView5.SelectedIndex = -1

        If TextBox17.Text = "" And TextBox18.Text = "" And TextBox19.Text = "" And TextBox20.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Services...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox18.Focus()
        Else
            If Val(TextBox20.Text) = 0 Then
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge], spare FROM [service_master] where ( service_category like '%" & TextBox17.Text & "%' and service_name like '%" & TextBox18.Text & "%' and car_type like '%" & TextBox19.Text & "%')", GridView4)

            Else
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge], spare FROM [service_master] where service_id='" & Val(TextBox20.Text) & "'", GridView4)

            End If
        End If
        If GridView5.Rows.Count = 0 Then
            GridView5.DataSource = Nothing
            GridView5.DataBind()

        End If

    End Sub

    Protected Sub GridView4_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(2).Text = Server.HtmlDecode(e.Row.Cells(2).Text)
            e.Row.Cells(8).Visible = False
            Dim txt1, txt2 As New TextBox
            txt1 = e.Row.FindControl("TextBox1")
            txt2 = e.Row.FindControl("TextBox2")

            If GridView5.SelectedIndex >= 0 Then
                txt1.Text = GridView5.SelectedRow.Cells(5).Text
                txt2.Text = GridView5.SelectedRow.Cells(6).Text
            Else
                'If Val(TextBox31.Text) > 0 Then
                '    txt2.Text = Val(TextBox32.Text)
                'End If

                If e.Row.Cells(8).Text = "Service" Then
                    If Val(TextBox32.Text) > 0 Then
                        txt2.Text = Val(TextBox32.Text)
                    End If
                End If
                If e.Row.Cells(8).Text = "Spare" Then
                    If Val(TextBox35.Text) > 0 Then
                        txt2.Text = Val(TextBox35.Text)
                    End If
                End If

                If e.Row.Cells(8).Text = "Machine Shop" Then
                    If Val(TextBox38.Text) > 0 Then
                        txt2.Text = Val(TextBox38.Text)
                    End If
                End If
            End If

            txt1.Text = genf.roundup(txt1.Text)
            If e.Row.RowIndex = 0 Then
                txt1.Focus()
            End If

            'Dim drop As New DropDownList
            'drop = e.Row.FindControl("DropDownList5")
            'genf.populate_dropdownlist1("select technician_id, technician_name from technician_master order by technician_name", drop, "technician_name", "technician_id")

            'If GridView5.SelectedIndex >= 0 Then
            '    Dim i
            '    For i = 0 To drop.Items.Count - 1
            '        If drop.Items(i).Value = GridView5.SelectedRow.Cells(8).Text Then
            '            drop.SelectedIndex = i
            '        End If
            '    Next

            'End If

            'If e.Row.Cells(8).Text = "True" Then
            '    e.Row.Cells(8).Text = "Yes"
            'Else
            '    e.Row.Cells(8).Text = ""
            'End If

            Dim drop1 As New DropDownList
            drop1 = e.Row.FindControl("DropDownList1")
            drop1.Items.Clear()
            drop1.Items.Add("-")
            drop1.Items.Add("Point")
            drop1.Items.Add("Unit")
            drop1.Items.Add("CC")
            drop1.Items.Add("Ft")
            drop1.Items.Add("gm")
            drop1.Items.Add("Kg")
            drop1.Items.Add("Lb")
            drop1.Items.Add("Litre")
            drop1.Items.Add("ml")
            drop1.Items.Add("mm")
            drop1.Items.Add("Pc")
            drop1.Items.Add("Set")

            e.Row.Cells(9).Text = Server.HtmlDecode(e.Row.Cells(9).Text)

        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(8).Visible = False
        End If

    End Sub

    Protected Sub GridView4_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView4.SelectedIndexChanged


        Dim dt = New DataTable("backupdata")
        Dim arcnt
        arcnt = 0
        For i = 0 To GridView4.HeaderRow.Cells.Count - 3
            If i = 0 Then
                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))

                If i < GridView4.HeaderRow.Cells.Count - 3 Then
                    arcnt = arcnt + 1
                End If
            Else
                If GridView4.HeaderRow.Cells(i).Visible = True Then

                    If i <> 7 Then
                        'If i = 8 Then
                        '    'dt.Columns.Add("Technician ID", GetType(String))
                        '    'dt.Columns.Add("Technician Name", GetType(String))
                        '    'Service Status
                        '    dt.Columns.Add("Service Status", GetType(String))
                        '    ' dt.Columns.Add("Type", GetType(String))

                        'Else
                        dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                        '  End If


                    Else
                        dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                        dt.Columns.Add("Total Value", GetType(String))
                        dt.Columns.Add("Service Status", GetType(String))
                    End If

                    'If GridView4.HeaderRow.Cells(i).Visible = True Then
                    If i < GridView4.HeaderRow.Cells.Count - 3 Then
                        arcnt = arcnt + 1
                    End If
                    'End If

                End If
            End If


        Next


        Dim flag, flag2, flag3
        flag = 0
        arcnt = arcnt + 1
        Dim arr1(arcnt) As String

        If GridView5.Rows.Count > 0 Then
            For Each row As GridViewRow In GridView5.Rows
                If row.RowIndex <> GridView5.SelectedIndex Then
                    Dim cnt1
                    cnt1 = 0
                    flag2 = 0

                    For i = 2 To row.Cells.Count - 1
                        If row.Cells(i).Visible = True Then

                            arr1(cnt1) = row.Cells(i).Text


                            flag = 1
                            flag2 = 1
                            If i < row.Cells.Count - 1 Then
                                cnt1 = cnt1 + 1
                            End If
                        End If
                    Next
                    If flag2 = 1 Then
                        dt.Rows.Add(arr1)
                    End If
                End If


            Next

            ' Response.Write("ppp<br>")
        End If


        '  Dim arr(arcnt) As String
        ' For Each row As GridViewRow In GridView4.Rows
        flag3 = 0
        Dim txt1, txt2 As New TextBox
        Dim drop, drop1 As New DropDownList
        txt1 = GridView4.SelectedRow.FindControl("TextBox1")
        txt2 = GridView4.SelectedRow.FindControl("TextBox2")
        drop = GridView4.SelectedRow.FindControl("DropDownList5")
        drop1 = GridView4.SelectedRow.FindControl("DropDownList1")



        Dim cnt
        cnt = 0
        For i = 0 To GridView4.SelectedRow.Cells.Count - 3
            If i = 0 Then
                '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                If i <> 5 And i <> 6 And i <> 8 And i <> 7 Then
                    arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                    'cnt = cnt + 1
                    flag = 1
                    flag3 = 1
                Else
                    flag = 1
                    flag3 = 1
                    If i = 5 Then
                        arr1(cnt) = Val(txt1.Text)
                        ' cnt = cnt + 1
                    End If
                    If i = 6 Then
                        arr1(cnt) = Val(txt2.Text)
                        'cnt = cnt + 1
                        'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                        'cnt = cnt + 1
                        'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                    End If
                    If i = 7 Then
                        arr1(cnt) = drop1.SelectedItem.Text
                        cnt = cnt + 1
                        arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                        ' cnt = cnt + 1
                        cnt = cnt + 1
                        arr1(cnt) = "-"
                        'cnt = cnt + 1
                        'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text
                        'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                    End If
                    'If i = 8 Then
                    '    'arr1(cnt) = drop.SelectedValue.ToString
                    '    'cnt = cnt + 1
                    '    'arr1(cnt) = drop.SelectedItem.Text
                    '    'cnt = cnt + 1
                    '    arr1(cnt) = "-"
                    '    'cnt = cnt + 1
                    '    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text
                    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                    'End If
                End If

                ' If GridView4.SelectedRow.Cells(i).Visible = True Then
                If i < GridView4.SelectedRow.Cells.Count - 3 Then
                    cnt = cnt + 1
                End If
                'End If
                'End If
            Else

                If GridView4.SelectedRow.Cells(i).Visible = True Then
                    If i <> 5 And i <> 6 And i <> 7 And i <> 8 Then
                        arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                        'cnt = cnt + 1
                        flag = 1
                        flag3 = 1
                    Else
                        flag = 1
                        flag3 = 1
                        If i = 5 Then
                            arr1(cnt) = Val(txt1.Text)
                            ' cnt = cnt + 1
                        End If
                        If i = 6 Then
                            arr1(cnt) = Val(txt2.Text)
                            'cnt = cnt + 1
                            'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                        End If
                        If i = 7 Then
                            arr1(cnt) = drop1.SelectedItem.Text

                            cnt = cnt + 1
                            arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            cnt = cnt + 1
                            arr1(cnt) = "-"
                            ' cnt = cnt + 1

                            'cnt = cnt + 1
                            'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text
                            'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                        End If
                        'If i = 8 Then
                        '    'arr1(cnt) = drop.SelectedValue.ToString
                        '    'cnt = cnt + 1
                        '    'arr1(cnt) = drop.SelectedItem.Text
                        '    'cnt = cnt + 1
                        '    arr1(cnt) = "-"
                        '    'cnt = cnt + 1
                        '    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                        '    'cnt = cnt + 1
                        '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                        'End If
                    End If

                    'If GridView4.SelectedRow.Cells(i).Visible = True Then
                    If i < GridView4.SelectedRow.Cells.Count - 3 Then
                        cnt = cnt + 1
                    End If
                End If
                'End If
                End If

        Next



        If flag3 = 1 Then
            dt.Rows.Add(arr1)
        End If
        ' dt.Rows.Add(arr)
        ' Next
        If flag = 1 Then
            total1 = 0

            GridView5.DataSource = dt
            GridView5.DataBind()

        Else
            total1 = 0

            GridView5.DataSource = Nothing
            GridView5.DataBind()
        End If

        GridView5.SelectedIndex = -1
        GridView4.SelectedIndex = -1
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox32.Text = "1"
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox20.Text = ""
        GridView4.DataSource = Nothing
        GridView4.DataBind()
        TextBox18.Focus()

    End Sub

    Protected Sub GridView5_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(5).Text = genf.roundup(Val(e.Row.Cells(5).Text))
            e.Row.Cells(8).Text = genf.roundup(Val(e.Row.Cells(8).Text))
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            total1 = total1 + Val(e.Row.Cells(8).Text)

            e.Row.Cells(3).Text = Server.HtmlDecode(e.Row.Cells(3).Text)
            Dim lnk1, lnk2 As New LinkButton
            lnk1 = e.Row.FindControl("LinkButton1")
            lnk2 = e.Row.FindControl("LinkButton2")

            'If e.Row.Cells(10).Text = "-" Then
            '    e.Row.Enabled = True
            '    lnk1.Visible = True
            '    lnk2.Visible = True
            'Else
            '    e.Row.Enabled = False
            '    lnk1.Visible = False
            '    lnk2.Visible = False

            'End If

            e.Row.Cells(2).Text = Server.HtmlDecode(e.Row.Cells(2).Text)
            e.Row.Cells(3).Text = Server.HtmlDecode(e.Row.Cells(3).Text)
            e.Row.Cells(4).Text = Server.HtmlDecode(e.Row.Cells(4).Text)
            e.Row.Cells(5).Text = Server.HtmlDecode(e.Row.Cells(5).Text)
            'If e.Row.Cells(8).Text = "True" Then
            '    e.Row.Cells(8).Text = "Yes"
            'Else
            '    e.Row.Cells(8).Text = ""
            '  End If
            e.Row.Cells(9).Text = Server.HtmlDecode(e.Row.Cells(9).Text)

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(8).Text = total1
            e.Row.Cells(8).Text = genf.roundup(Val(e.Row.Cells(8).Text))
            e.Row.Cells(6).Text = "Total"
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right

        End If
    End Sub

    Protected Sub GridView5_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView5.RowDeleting
        Dim dt = New DataTable("backupdata")
        Dim arcnt
        arcnt = 0
        For i = 2 To GridView5.HeaderRow.Cells.Count - 1
            dt.Columns.Add(GridView5.HeaderRow.Cells(i).Text, GetType(String))
            If i < GridView5.HeaderRow.Cells.Count - 1 Then
                arcnt = arcnt + 1
            End If
        Next
        Dim flag, flag2
        flag = 0

        Dim arr(arcnt) As String

        If GridView5.Rows.Count > 0 Then
            For Each row As GridViewRow In GridView5.Rows
                flag2 = 0
                If row.RowIndex <> e.RowIndex Then


                    Dim cnt
                    cnt = 0
                    For i = 2 To row.Cells.Count - 1
                        If row.Cells(i).Visible = True Then
                            arr(cnt) = row.Cells(i).Text

                            flag = 1
                            flag2 = 1
                            If i < row.Cells.Count - 1 Then
                                cnt = cnt + 1
                            End If
                        End If
                    Next
                    If flag2 = 1 Then
                        dt.Rows.Add(arr)
                    End If
                End If


            Next


        End If
        GridView4.DataSource = Nothing
        GridView4.DataBind()

        If flag = 1 Then
            'dt.Rows.Add(arr)
            total1 = 0

            GridView5.DataSource = dt
            GridView5.DataBind()

            TextBox17.Text = ""
            TextBox18.Text = ""
            TextBox19.Text = ""
            TextBox20.Text = ""
            TextBox32.Text = "1"
            TextBox33.Text = ""
            TextBox34.Text = ""
            TextBox35.Text = ""
            TextBox36.Text = ""
            TextBox37.Text = ""
            TextBox38.Text = ""
            TextBox39.Text = ""
        Else
            total1 = 0

            GridView5.DataSource = Nothing
            GridView5.DataBind()

            TextBox17.Text = ""
            TextBox18.Text = ""
            TextBox19.Text = ""
            TextBox20.Text = ""
            TextBox32.Text = "1"
            TextBox33.Text = ""
            TextBox34.Text = ""
            TextBox35.Text = ""
            TextBox36.Text = ""
            TextBox37.Text = ""
            TextBox38.Text = ""
            TextBox39.Text = ""
        End If
        TextBox18.Focus()
    End Sub

    Protected Sub GridView5_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView5.SelectedIndexChanged
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox32.Text = "1"
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox20.Text = GridView5.SelectedRow.Cells(2).Text

        If TextBox17.Text = "" And TextBox18.Text = "" And TextBox19.Text = "" And TextBox20.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Services...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox18.Focus()
        Else
            If Val(TextBox20.Text) = 0 Then
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge], spare FROM [service_master] where ( service_category like '%" & TextBox17.Text & "%' and service_name like '%" & TextBox18.Text & "%' and car_type like '%" & TextBox19.Text & "%')", GridView4)
                If GridView4.Rows.Count = 1 Then
                    Dim drop1 As New DropDownList
                    drop1 = GridView4.Rows(0).FindControl("DropDownList1")
                    Dim p
                    For p = 0 To drop1.Items.Count - 1
                        If drop1.Items(p).Text = GridView5.SelectedRow.Cells(7).Text Then
                            drop1.SelectedIndex = p
                        End If
                    Next
                End If
            Else
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge], spare,'" & GridView5.SelectedRow.Cells(6).Text & "' as [Qty] FROM [service_master] where service_id='" & Val(TextBox20.Text) & "'", GridView4)
                If GridView4.Rows.Count = 1 Then
                    Dim drop1 As New DropDownList
                    drop1 = GridView4.Rows(0).FindControl("DropDownList1")
                    Dim p
                    For p = 0 To drop1.Items.Count - 1
                        If drop1.Items(p).Text = GridView5.SelectedRow.Cells(7).Text Then
                            drop1.SelectedIndex = p
                        End If
                    Next
                End If
            End If
        End If
        If GridView5.Rows.Count = 0 Then
            GridView5.DataSource = Nothing
            GridView5.DataBind()

        End If
        TextBox20.Text = ""
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        GridView7.SelectedIndex = -1
        If TextBox31.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox31.Focus()
        Else
            ' If Val(TextBox23.Text) = 0 Then
            strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit], (select distinct saling_price from purchase_item p where p.part_id=vehicle_parts.id) as [Price] from [vehicle_parts] where description like '" & TextBox31.Text & "%'"
            genf.populate_grid(strnewrecord, GridView6)

            'Else
            '    strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
            '    genf.populate_grid(strnewrecord, GridView6)

            'End If


        End If

        If GridView7.Rows.Count = 0 Then
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

        End If
    End Sub

    Protected Sub GridView6_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView6.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            'e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(0).Visible = False
            'e.Row.Cells(1).Visible = False
            'e.Row.Cells(4).Visible = False

            Dim txt1, txt2 As New TextBox
            txt1 = e.Row.FindControl("TextBox1")
            txt2 = e.Row.FindControl("TextBox2")
            txt2.Text = genf.roundup(Val(txt2.Text))
            If GridView7.SelectedIndex >= 0 Then
                txt1.Text = GridView7.SelectedRow.Cells(6).Text
            End If
            ' txt1.Text = genf.roundup(txt1.Text)
            If e.Row.RowIndex = 0 Then
                txt1.Focus()
            End If
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            'e.Row.Cells(0).Visible = False
            'e.Row.Cells(1).Visible = False
            'e.Row.Cells(4).Visible = False
        End If
    End Sub

    Protected Sub GridView6_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView6.SelectedIndexChanged


        Dim dt = New DataTable("backupdata")
        Dim arcnt
        arcnt = 0
        For i = 0 To GridView6.HeaderRow.Cells.Count - 2
            If i = 0 Then
                dt.Columns.Add(GridView6.HeaderRow.Cells(i).Text, GetType(String))

                If i < GridView6.HeaderRow.Cells.Count - 2 Then
                    arcnt = arcnt + 1
                End If
            Else
                If i = GridView6.HeaderRow.Cells.Count - 4 Then
                    If GridView6.HeaderRow.Cells(i).Visible = True Then
                        dt.Columns.Add(GridView6.HeaderRow.Cells(i).Text, GetType(String))
                        dt.Columns.Add("Issued Quantity", GetType(String))
                        dt.Columns.Add("Required Quantity", GetType(String))
                        If i < GridView6.HeaderRow.Cells.Count - 2 Then
                            arcnt = arcnt + 1
                        End If

                    End If
                Else
                    If GridView6.HeaderRow.Cells(i).Visible = True Then
                        dt.Columns.Add(GridView6.HeaderRow.Cells(i).Text, GetType(String))

                        If i < GridView6.HeaderRow.Cells.Count - 2 Then
                            arcnt = arcnt + 1
                        End If

                    End If
                End If

            End If


        Next

        Dim flag, flag2, flag3
        flag = 0
        dt.Columns.Add("Total", GetType(String))
        arcnt = arcnt + 3
        Dim arr1(arcnt) As String

        If GridView7.Rows.Count > 0 Then
            For Each row As GridViewRow In GridView7.Rows
                If row.RowIndex <> GridView7.SelectedIndex Then
                    Dim cnt1
                    cnt1 = 0
                    flag2 = 0

                    For i = 2 To row.Cells.Count - 1
                        ' If i <> 6 And i <> 7 Then '' row.Cells(i).Visible = True
                        arr1(cnt1) = row.Cells(i).Text


                        flag = 1
                        flag2 = 1
                        If i < row.Cells.Count - 1 Then
                            cnt1 = cnt1 + 1
                        End If
                        ' End If
                    Next
                    If flag2 = 1 Then
                        dt.Rows.Add(arr1)
                    End If
                End If


            Next

            ' Response.Write("ppp<br>")
        End If


        '  Dim arr(arcnt) As String
        ' For Each row As GridViewRow In GridView4.Rows
        flag3 = 0
        Dim txt1, txt2 As New TextBox

        txt1 = GridView6.SelectedRow.FindControl("TextBox1")

        txt2 = GridView6.SelectedRow.FindControl("TextBox2")
        Dim cnt
        cnt = 0
        For i = 0 To GridView6.SelectedRow.Cells.Count - 2
            If i = 0 Then
                '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                If i <> 4 Then
                    If i = 6 Then
                        arr1(cnt) = Val(txt2.Text)
                        arr1(cnt + 1) = Val(txt2.Text) * Val(txt1.Text)
                        cnt = cnt + 1
                    Else
                        arr1(cnt) = GridView6.SelectedRow.Cells(i).Text

                    End If
                    'cnt = cnt + 1
                    flag = 1
                    flag3 = 1
                Else
                    flag = 1
                    flag3 = 1
                    If i = 4 Then
                        arr1(cnt) = Val(txt1.Text)
                        cnt = cnt + 1
                        arr1(cnt) = "0"
                        cnt = cnt + 1
                        arr1(cnt) = Val(txt1.Text)
                    End If

                End If

                If i < GridView6.SelectedRow.Cells.Count - 2 Then
                    cnt = cnt + 1
                End If
                'End If
            Else

                If GridView6.SelectedRow.Cells(i).Visible = True Then
                    If i <> 4 Then
                        If i = 6 Then
                            arr1(cnt) = Val(txt2.Text)
                            arr1(cnt + 1) = Val(txt2.Text) * Val(txt1.Text)
                            cnt = cnt + 1
                            ' cnt = cnt + 1
                        Else
                            arr1(cnt) = GridView6.SelectedRow.Cells(i).Text

                        End If
                        'cnt = cnt + 1
                        flag = 1
                        flag3 = 1

                    Else
                        flag = 1
                        flag3 = 1
                        If i = 4 Then
                            arr1(cnt) = Val(txt1.Text)
                            cnt = cnt + 1
                            arr1(cnt) = "0"
                            cnt = cnt + 1
                            arr1(cnt) = Val(txt1.Text)
                            ' cnt = cnt + 1
                        End If

                    End If

                    If i < GridView6.SelectedRow.Cells.Count - 2 Then
                        cnt = cnt + 1
                    End If
                End If
            End If

        Next



        If flag3 = 1 Then
            dt.Rows.Add(arr1)
        End If
        ' dt.Rows.Add(arr)
        ' Next
        If flag = 1 Then
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = dt
            GridView7.DataBind()

        Else
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()
        End If

        GridView7.SelectedIndex = -1
        GridView6.SelectedIndex = -1
        TextBox21.Text = ""
        TextBox23.Text = ""
        TextBox30.Text = ""
        TextBox31.Text = ""

        GridView6.DataSource = Nothing
        GridView6.DataBind()
        TextBox21.Focus()

    End Sub

    Protected Sub GridView7_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView7.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(11).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(10).Text = genf.roundup(Val(e.Row.Cells(10).Text))
            e.Row.Cells(8).Text = Val(e.Row.Cells(6).Text) - Val(e.Row.Cells(7).Text)
            total1 = total1 + Val(e.Row.Cells(6).Text)
            e.Row.Cells(11).Text = genf.roundup(Val(e.Row.Cells(11).Text))
            total2 = total2 + Val(e.Row.Cells(11).Text)
            total3 = total3 + Val(e.Row.Cells(8).Text)

            Dim lnk1, lnk2 As New LinkButton
            lnk1 = e.Row.FindControl("LinkButton1")
            lnk2 = e.Row.FindControl("LinkButton2")

            If Val(e.Row.Cells(7).Text) = 0 Then
                e.Row.Enabled = True
                lnk1.Visible = True
                lnk2.Visible = True
            Else
                e.Row.Enabled = False
                lnk1.Visible = False
                lnk2.Visible = False

            End If
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(6).Text = total1
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(11).Text = total2
            e.Row.Cells(11).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(11).Text = genf.roundup(Val(e.Row.Cells(11).Text))

            e.Row.Cells(8).Text = total3
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Text = "Total"
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

        End If
    End Sub

    Protected Sub GridView7_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView7.RowDeleting
        Dim dt = New DataTable("backupdata")
        Dim arcnt
        arcnt = 0
        For i = 2 To GridView7.HeaderRow.Cells.Count - 1
            dt.Columns.Add(GridView7.HeaderRow.Cells(i).Text, GetType(String))
            If i < GridView7.HeaderRow.Cells.Count - 1 Then
                arcnt = arcnt + 1
            End If
        Next
        Dim flag, flag2
        flag = 0

        Dim arr(arcnt) As String

        If GridView7.Rows.Count > 0 Then
            For Each row As GridViewRow In GridView7.Rows
                flag2 = 0
                If row.RowIndex <> e.RowIndex Then


                    Dim cnt
                    cnt = 0
                    For i = 2 To row.Cells.Count - 1
                        If row.Cells(i).Visible = True Then
                            arr(cnt) = row.Cells(i).Text

                            flag = 1
                            flag2 = 1
                            If i < row.Cells.Count - 1 Then
                                cnt = cnt + 1
                            End If
                        End If
                    Next
                    If flag2 = 1 Then
                        dt.Rows.Add(arr)
                    End If
                End If


            Next


        End If
        GridView6.DataSource = Nothing
        GridView6.DataBind()

        If flag = 1 Then
            'dt.Rows.Add(arr)
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = dt
            GridView7.DataBind()

            TextBox21.Text = ""
            TextBox23.Text = ""
            TextBox30.Text = ""
            TextBox31.Text = ""

        Else
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

            TextBox21.Text = ""
            TextBox23.Text = ""
            TextBox30.Text = ""
            TextBox31.Text = ""

        End If
        TextBox21.Focus()
    End Sub

    Protected Sub GridView7_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView7.SelectedIndexChanged
        TextBox21.Text = ""
        TextBox30.Text = ""
        TextBox31.Text = ""

        TextBox23.Text = GridView7.SelectedRow.Cells(2).Text
        'Dim txt2 As New TextBox
        'txt2 = GridView7.SelectedRow.FindControl("TextBox2")
        If TextBox21.Text = "" And TextBox23.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox21.Focus()
        Else
            If Val(TextBox23.Text) = 0 Then
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit],'" & GridView7.SelectedRow.Cells(10).Text & "' as [Price] from [vehicle_parts] where part_no like '%" & TextBox21.Text & "%'"
                genf.populate_grid(strnewrecord, GridView6)

            Else
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit],'" & GridView7.SelectedRow.Cells(10).Text & "' as [Price]  from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
                genf.populate_grid(strnewrecord, GridView6)

            End If


        End If

        If GridView7.Rows.Count = 0 Then
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

        End If
        TextBox23.Text = ""

    End Sub

    Protected Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        If TextBox40.Text = "" Then
            TextBox40.Text = "-"

        End If
        Dim job_id
        If IsNothing(Request.QueryString("url")) Then





            strnewrecord = "INSERT INTO [estimate_new_job_cart]"
            strnewrecord = strnewrecord & "([customer_name]"
            strnewrecord = strnewrecord & ",[address]"
            strnewrecord = strnewrecord & ",[email]"
            strnewrecord = strnewrecord & ",[tel]"
            strnewrecord = strnewrecord & ",[mobile]"
            strnewrecord = strnewrecord & ",[in_date]"
            strnewrecord = strnewrecord & ",[dlv_date]"
            strnewrecord = strnewrecord & ",[manual_ro]"
            strnewrecord = strnewrecord & ",[vehicle]"
            strnewrecord = strnewrecord & ",[reg_no]"
            strnewrecord = strnewrecord & ",[model]"
            strnewrecord = strnewrecord & ",[eng_no]"
            strnewrecord = strnewrecord & ",[chesis_no]"
            strnewrecord = strnewrecord & ",[km]"
            strnewrecord = strnewrecord & ",[no_valuable]"
            strnewrecord = strnewrecord & ",[attached_sheet],advance,advance_date,tnc)"

            strnewrecord = strnewrecord & " values "

            strnewrecord = strnewrecord & "('" & TextBox1.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox2.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox3.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox4.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox5.Text & "'"

            Dim arr1()
            arr1 = Split(TextBox6.Text, "/")
            Dim dt As New Date
            dt = New Date(Val(arr1(2).ToString), Val(arr1(1).ToString), Val(arr1(0).ToString), Val(DropDownList1.SelectedItem.Text), Val(DropDownList2.SelectedItem.Text), 0)


            Dim arr11()
            arr11 = Split(TextBox7.Text, "/")
            Dim dt1 As New Date
            dt1 = New Date(Val(arr11(2).ToString), Val(arr11(1).ToString), Val(arr11(0).ToString), Val(DropDownList3.SelectedItem.Text), Val(DropDownList4.SelectedItem.Text), 0)



            strnewrecord = strnewrecord & ",'" & dt & "'"
            strnewrecord = strnewrecord & ",'" & dt1 & "'"
            strnewrecord = strnewrecord & ",'" & TextBox14.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox8.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox9.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox10.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox11.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox12.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox13.Text & "'"
            strnewrecord = strnewrecord & ",'" & CheckBox1.Checked.ToString & "'"
            strnewrecord = strnewrecord & ",'" & CheckBox2.Checked.ToString & "','" & Val(TextBox24.Text) & "','" & genf.getdate(TextBox25.Text) & "','" & TextBox40.Text.Replace("'", "''") & "'); select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            job_id = Val(Mycommand.ExecuteScalar.ToString)



            'strnewrecord = "INSERT INTO [payment]"
            'strnewrecord = strnewrecord & "([job_no]"
            'strnewrecord = strnewrecord & ",[amount]"
            'strnewrecord = strnewrecord & ",[bill_date], mr_no, b_type, status)"
            'strnewrecord = strnewrecord & " values "
            'strnewrecord = strnewrecord & "('" & job_id & "'"
            'strnewrecord = strnewrecord & ",'" & Val(TextBox24.Text) & "'"
            'strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox25.Text) & "','" & TextBox26.Text & "','Advance','Confirmed')"
            'Mycommand = New SqlCommand(strnewrecord, Myconnection)
            'Mycommand.ExecuteNonQuery()

            If Val(TextBox24.Text) > 0 Then

                strnewrecord = "INSERT INTO [estimate_payment]"
                strnewrecord = strnewrecord & "([job_no]"
                strnewrecord = strnewrecord & ",[amount]"
                If DropDownList6.SelectedItem.Text = "Cash" Then
                    strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode, status)"

                Else
                    strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode,chq_date,bank,cheque_no,status)"

                End If
                strnewrecord = strnewrecord & " values "
                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(TextBox24.Text) & "'"
                If DropDownList6.SelectedItem.Text = "Cash" Then
                    strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox25.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','Confirmed'); select scope_identity()"

                Else
                    strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox26.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','" & genf.getdate(TextBox29.Text) & "','" & TextBox28.Text & "','" & TextBox26.Text & "','Float'); select scope_identity()"

                End If
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Dim inv_no
                inv_no = Mycommand.ExecuteScalar.ToString()
                strnewrecord = "update estimate_new_job_cart set mr_no='" & Val(inv_no.ToString) & "' where job_id='" & Val(job_id.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If

        Else
            job_id = Val(Request.QueryString("url").ToString)

            If genf.checkexistancefromdv("select * from estimate_payment  where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance'") = True Then
                'strnewrecord = "update [payment] "
                'strnewrecord = strnewrecord & " set [job_no]='" & job_id & "'"
                'strnewrecord = strnewrecord & ",[amount]='" & Val(TextBox24.Text) & "'"
                'strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox25.Text) & "', mr_no='" & TextBox26.Text & "', status='Confirmed' where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance'"
                'Mycommand = New SqlCommand(strnewrecord, Myconnection)
                'Mycommand.ExecuteNonQuery()

                If Val(TextBox24.Text) > 0 Then


                    strnewrecord = "update [estimate_payment] set "
                    strnewrecord = strnewrecord & " [job_no]='" & Val(job_id.ToString) & "'"
                    strnewrecord = strnewrecord & ",[amount]='" & Val(TextBox24.Text) & "'"
                    If DropDownList6.SelectedItem.Text = "Cash" Then
                        strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox25.Text) & "', b_type='Advance',pmnt_mode='" & DropDownList6.SelectedItem.Text & "', status='Confirmed'"
                    Else
                        strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox25.Text) & "', b_type='Advance',pmnt_mode='" & DropDownList6.SelectedItem.Text & "',chq_date='" & genf.getdate(TextBox29.Text) & "',bank='" & TextBox28.Text & "',cheque_no='" & TextBox26.Text & "',status='Float'"
                    End If
                    strnewrecord = strnewrecord & "  where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()

                    strnewrecord = "select tx_no from estimate_payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
                    Dim tx_no1
                    tx_no1 = genf.returnvaluefromdv(strnewrecord, 0)

                    strnewrecord = "update estimate_new_job_cart set mr_no='" & Val(tx_no1.ToString) & "' where job_id='" & Val(job_id.ToString) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                Else

                    strnewrecord = "delete from estimate_payment where job_no='" & Val(job_id.ToString) & "' and b_type='Advance'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()

                    strnewrecord = "update estimate_new_job_cart set mr_no=NULL where job_id='" & Val(job_id.ToString) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                End If

            Else
                If Val(TextBox24.Text) > 0 Then

                    strnewrecord = "INSERT INTO [estimate_payment]"
                    strnewrecord = strnewrecord & "([job_no]"
                    strnewrecord = strnewrecord & ",[amount]"
                    If DropDownList6.SelectedItem.Text = "Cash" Then
                        strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode, status)"

                    Else
                        strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode,chq_date,bank,cheque_no,status)"

                    End If
                    strnewrecord = strnewrecord & " values "
                    strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                    strnewrecord = strnewrecord & ",'" & Val(TextBox24.Text) & "'"
                    If DropDownList6.SelectedItem.Text = "Cash" Then
                        strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox25.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','Confirmed'); select scope_identity()"

                    Else
                        strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox26.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','" & genf.getdate(TextBox29.Text) & "','" & TextBox28.Text & "','" & TextBox26.Text & "','Float'); select scope_identity()"

                    End If
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Dim inv_no
                    inv_no = Mycommand.ExecuteScalar.ToString()
                    strnewrecord = "update estimate_new_job_cart set mr_no='" & Val(inv_no.ToString) & "' where job_id='" & Val(job_id.ToString) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                End If

            End If






            strnewrecord = "update [estimate_new_job_cart]"
            strnewrecord = strnewrecord & " set [customer_name]='" & TextBox1.Text & "', tnc='" & TextBox40.Text.Replace("'", "''") & "'"
            strnewrecord = strnewrecord & ",[address]='" & TextBox2.Text & "'"
            strnewrecord = strnewrecord & ",[email]='" & TextBox3.Text & "'"
            strnewrecord = strnewrecord & ",[tel]='" & TextBox4.Text & "'"
            strnewrecord = strnewrecord & ",[mobile]='" & TextBox5.Text & "'"

            Dim arr1()
            arr1 = Split(TextBox6.Text, "/")
            Dim dt As New Date
            dt = New Date(Val(arr1(2).ToString), Val(arr1(1).ToString), Val(arr1(0).ToString), Val(DropDownList1.SelectedItem.Text), Val(DropDownList2.SelectedItem.Text), 0)

            strnewrecord = strnewrecord & ",[in_date]='" & dt & "'"
            Dim arr11()
            arr11 = Split(TextBox7.Text, "/")
            Dim dt1 As New Date
            dt1 = New Date(Val(arr11(2).ToString), Val(arr11(1).ToString), Val(arr11(0).ToString), Val(DropDownList3.SelectedItem.Text), Val(DropDownList4.SelectedItem.Text), 0)

            strnewrecord = strnewrecord & ",[dlv_date]='" & dt1 & "'"
            strnewrecord = strnewrecord & ",[manual_ro]='" & TextBox14.Text & "'"
            strnewrecord = strnewrecord & ",[vehicle]='" & TextBox8.Text & "'"
            strnewrecord = strnewrecord & ",[reg_no]='" & TextBox9.Text & "'"
            strnewrecord = strnewrecord & ",[model]='" & TextBox10.Text & "'"
            strnewrecord = strnewrecord & ",[eng_no]='" & TextBox11.Text & "'"
            strnewrecord = strnewrecord & ",[chesis_no]='" & TextBox12.Text & "'"
            strnewrecord = strnewrecord & ",[km]='" & TextBox13.Text & "'"
            strnewrecord = strnewrecord & ",[no_valuable]='" & CheckBox1.Checked.ToString & "'"
            strnewrecord = strnewrecord & ",[attached_sheet]='" & CheckBox2.Checked.ToString & "', advance='" & Val(TextBox24.Text) & "', advance_date='" & genf.getdate(TextBox25.Text) & "' where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_complain where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_technical_report where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_valuable where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_service where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_parts where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            strnewrecord = "delete from new_estimate_dent_paint where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
        End If




        Dim i
        For i = 0 To GridView1.Rows.Count - 1
            Dim txt1 As New TextBox
            txt1 = GridView1.Rows(i).FindControl("TextBox1")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [estimate_new_job_complain]"
                strnewrecord = strnewrecord & "([job_id]"
                strnewrecord = strnewrecord & ",[sl]"
                strnewrecord = strnewrecord & ",[complain])"

                strnewrecord = strnewrecord & " values "

                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(GridView1.Rows(i).Cells(0).Text) & "'"
                strnewrecord = strnewrecord & ",'" & txt1.Text & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If


        Next


        For i = 0 To GridView2.Rows.Count - 1
            Dim txt1 As New TextBox
            txt1 = GridView2.Rows(i).FindControl("TextBox15")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [estimate_new_job_technical_report]"
                strnewrecord = strnewrecord & "([job_id]"
                strnewrecord = strnewrecord & ",[sl]"
                strnewrecord = strnewrecord & ",[technical_report])"

                strnewrecord = strnewrecord & " values "

                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(GridView2.Rows(i).Cells(0).Text) & "'"
                strnewrecord = strnewrecord & ",'" & txt1.Text & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If


        Next


        For i = 0 To GridView3.Rows.Count - 1
            Dim txt1 As New TextBox
            txt1 = GridView3.Rows(i).FindControl("TextBox16")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [estimate_new_job_valuable]"
                strnewrecord = strnewrecord & "([job_id]"
                strnewrecord = strnewrecord & ",[sl]"
                strnewrecord = strnewrecord & ",[description])"

                strnewrecord = strnewrecord & " values "

                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(GridView3.Rows(i).Cells(0).Text) & "'"
                strnewrecord = strnewrecord & ",'" & txt1.Text & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If


        Next

        For i = 0 To GridView5.Rows.Count - 1

            strnewrecord = "INSERT INTO [estimate_new_job_service]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[service_id]"
            strnewrecord = strnewrecord & ",[unit_cost]"
            strnewrecord = strnewrecord & ",[qty]"
            strnewrecord = strnewrecord & ",[unit]"
            strnewrecord = strnewrecord & ",[cost]"
            strnewrecord = strnewrecord & ",[technician_id])"

            strnewrecord = strnewrecord & " values "


            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"

            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(2).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(5).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(6).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Trim(GridView5.Rows(i).Cells(7).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(8).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(9).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()



        Next

        For i = 0 To GridView7.Rows.Count - 1

            strnewrecord = "INSERT INTO [estimate_new_job_parts]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[part_id]"
            strnewrecord = strnewrecord & ",[part_no]"
            strnewrecord = strnewrecord & ",[qty],[price], total)"

            strnewrecord = strnewrecord & " values "


            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"

            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(2).Text) & "'"
            strnewrecord = strnewrecord & ",'" & GridView7.Rows(i).Cells(3).Text.Replace("'", "''") & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(8).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(10).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(11).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()



        Next



        For i = 0 To GridView9.Rows.Count - 1

            strnewrecord = "INSERT INTO [new_estimate_dent_paint]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[description]"
            strnewrecord = strnewrecord & ",[qty]"
            strnewrecord = strnewrecord & ",[Price])"
            strnewrecord = strnewrecord & " values "

            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
            strnewrecord = strnewrecord & ",'" & Trim(GridView9.Rows(i).Cells(2).Text.Replace("'", "''")) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView9.Rows(i).Cells(3).Text.Replace("'", "''")) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView9.Rows(i).Cells(4).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()

        Next

        Myconnection.Close()
        Button1.Visible = True
        Page_Load(sender, e)
        If IsNothing(Request.QueryString("url")) Then
            Dim alertScript = "alert('Estimate Has Been Submited Succesfully With Estimate ID - " & job_id & " ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        Else
            Dim alertScript = "alert('Estimate With Estimate ID - " & job_id & " Has Been Modified Succesfully ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        End If


        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('estimate_bill.aspx?url=" & job_id & "','estimate_gen_bill');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())


        'Dim rsb1 As StringBuilder
        'rsb1 = New StringBuilder()
        'rsb1.Append("<script language=""JavaScript"">")
        'rsb1.Append("window.open('Estimate_job_sheet.aspx?url=" & Val(job_id.ToString) & "','print_job');")
        'rsb1.Append("</scri")
        'rsb1.Append("pt>")
        'Page.RegisterStartupScript("rtest1", rsb1.ToString())


        If Val(TextBox24.Text) > 0 Then


            strnewrecord = "select tx_no from estimate_payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
            Dim tx_no
            tx_no = genf.returnvaluefromdv(strnewrecord, 0)

            Dim rsb12 As StringBuilder
            rsb12 = New StringBuilder()
            rsb12.Append("<script language=""JavaScript"">")
            rsb12.Append("window.open('money_receipt.aspx?url=" & Val(tx_no.ToString) & "','money_rcpt');")
            rsb12.Append("</scri")
            rsb12.Append("pt>")
            Page.RegisterStartupScript("rtest12", rsb12.ToString())
        End If

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsNothing(Request.QueryString("url")) Then
                Dim txt As New TextBox
                txt = e.Row.FindControl("TextBox1")
                strnewrecord = "SELECT [complain] fROM [estimate_new_job_complain] where job_id='" & Val(Request.QueryString("url").ToString) & "' and sl='" & Val(e.Row.Cells(0).Text) & "'"
                txt.Text = genf.returnvaluefromdv(strnewrecord, 0)
            End If

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then


            If Not IsNothing(Request.QueryString("url")) Then
                Dim txt As New TextBox
                txt = e.Row.FindControl("TextBox15")
                strnewrecord = "SELECT [technical_report] fROM [estimate_new_job_technical_report] where job_id='" & Val(Request.QueryString("url").ToString) & "' and sl='" & Val(e.Row.Cells(0).Text) & "'"
                txt.Text = genf.returnvaluefromdv(strnewrecord, 0)
            End If
        End If

    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub GridView3_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then


            If Not IsNothing(Request.QueryString("url")) Then
                Dim txt As New TextBox
                txt = e.Row.FindControl("TextBox16")
                strnewrecord = "SELECT [description] fROM [estimate_new_job_valuable] where job_id='" & Val(Request.QueryString("url").ToString) & "' and sl='" & Val(e.Row.Cells(0).Text) & "'"
                txt.Text = genf.returnvaluefromdv(strnewrecord, 0)
            End If
        End If
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView3.SelectedIndexChanged

    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim job_id
        job_id = Val(Request.QueryString("url").ToString)
        strnewrecord = "delete from [estimate_new_job_cart] "
        strnewrecord = strnewrecord & " where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from estimate_new_job_complain where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from estimate_new_job_technical_report where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from estimate_new_job_valuable where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from estimate_new_job_service where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from estimate_new_job_parts where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from [estimate_payment] where [job_no]='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        strnewrecord = "delete from new_estimate_dent_paint where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Dim i


        Myconnection.Close()
        'Button1.Visible = True
        'Page_Load(sender, e)
        Dim alertScript = "alert('Estimate With Estimate ID - " & job_id & " Has Been Deleted Succesfully ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)


        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('job_card.aspx','_self');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub

    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('job_sheet.aspx?url=" & Request.QueryString("url") & "','print_estimate');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())

    End Sub

    Protected Sub Button7_Click(sender As Object, e As System.EventArgs) Handles Button7.Click
        'If Button7.Text = "Print Bill" Then

        'Else
        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('estimate_bill.aspx?url=" & Request.QueryString("url") & "','estimate_gen_bill');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
        '  End If


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

    Protected Sub Button9_Click(sender As Object, e As System.EventArgs) Handles Button9.Click
        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no) FROM [estimate_new_job_cart] where manual_ro='" & Trim(TextBox14.Text) & "'"
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

    Protected Sub Button10_Click(sender As Object, e As System.EventArgs) Handles Button10.Click
        strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), customer_id FROM [estimate_new_job_cart] where job_id='" & Val(TextBox27.Text) & "'"
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

    Protected Sub Button11_Click(sender As Object, e As System.EventArgs) Handles Button11.Click

        strnewrecord = "select tx_no from estimate_payment where [job_no]='" & Val(Request.QueryString("url").ToString) & "' and b_type='Advance' "
        Dim tx_no
        tx_no = genf.returnvaluefromdv(strnewrecord, 0)

        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('money_receipt.aspx?url=" & Val(tx_no.ToString) & "','money_rcpt');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub

    Protected Sub GridView8_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView8.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            total1 = total1 + Val(e.Row.Cells(3).Text)
            total2 = total2 + Val(e.Row.Cells(4).Text)

        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(3).Text = total1
            e.Row.Cells(4).Text = total2
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(2).Text = "Total"
        End If
    End Sub

    Protected Sub GridView8_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView8.SelectedIndexChanged

    End Sub

    Protected Sub Button12_Click(sender As Object, e As System.EventArgs) Handles Button12.Click
        GridView7.SelectedIndex = -1
        If TextBox21.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox21.Focus()
        Else
            ' If Val(TextBox23.Text) = 0 Then
            strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit], (select distinct saling_price from purchase_item p where p.part_id=vehicle_parts.id) as [Price] from [vehicle_parts] where part_no like '" & TextBox21.Text & "%'"
            genf.populate_grid(strnewrecord, GridView6)

            'Else
            '    strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
            '    genf.populate_grid(strnewrecord, GridView6)

            'End If


        End If

        If GridView7.Rows.Count = 0 Then
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

        End If
    End Sub

    Protected Sub Button14_Click(sender As Object, e As System.EventArgs) Handles Button14.Click
        GridView7.SelectedIndex = -1
        If TextBox30.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox30.Focus()
        Else
            ' If Val(TextBox23.Text) = 0 Then
            strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit], (select distinct saling_price from purchase_item p where p.part_id=vehicle_parts.id) as [Price] from [vehicle_parts] where parts_name like '" & TextBox30.Text & "%'"
            ' Response.Write(strnewrecord)
            genf.populate_grid(strnewrecord, GridView6)

            'Else
            '    strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
            '    genf.populate_grid(strnewrecord, GridView6)

            'End If


        End If

        If GridView7.Rows.Count = 0 Then
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

        End If
    End Sub

    Protected Sub Button13_Click(sender As Object, e As System.EventArgs) Handles Button13.Click
        GridView7.SelectedIndex = -1
        If TextBox23.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox23.Focus()
        Else
            If Val(TextBox23.Text) <> 0 Then
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit], (select distinct saling_price from purchase_item p where p.part_id=vehicle_parts.id) as [Price] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
                genf.populate_grid(strnewrecord, GridView6)

                'Else
                '    strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
                '    genf.populate_grid(strnewrecord, GridView6)

            End If


        End If

        If GridView7.Rows.Count = 0 Then
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

        End If
    End Sub

    Protected Sub Button15_Click(sender As Object, e As System.EventArgs) Handles Button15.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim service_id
        strnewrecord = "INSERT INTO [service_master] ([service_category],[service_name],[car_type],[service_charge],spare) values ('" & TextBox17.Text.Replace("'", "''") & "','" & TextBox18.Text.Replace("'", "''") & "','" & TextBox19.Text.Replace("'", "''") & "','" & Val(TextBox33.Text) & "','Service'); select scope_identity()"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        service_id = Mycommand.ExecuteScalar.ToString
        'Mycommand.ExecuteNonQuery()


        GridView5.SelectedIndex = -1



        genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],'" & Val(TextBox32.Text) & "'  as [Qty],'" & Val(TextBox33.Text) & "'  as [Unit Service Charge], '' as [Unit], spare FROM [service_master] where service_id='" & Val(service_id.ToString) & "'", GridView4)
        Myconnection.Close()
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox17.Text = ""
        TextBox32.Text = "1"
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        If GridView5.Rows.Count = 0 Then
            GridView5.DataSource = Nothing
            GridView5.DataBind()
        End If


        If GridView4.Rows.Count = 0 Then
            'GridView5.DataSource = Nothing
            'GridView5.DataBind()

        Else
            If GridView4.Rows.Count = 1 Then
                GridView4.SelectedIndex = 0


                Dim dt = New DataTable("backupdata")
                Dim arcnt
                arcnt = 0
                For i = 0 To GridView4.HeaderRow.Cells.Count - 3
                    If i = 0 Then
                        dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))

                        If i < GridView4.HeaderRow.Cells.Count - 3 Then
                            arcnt = arcnt + 1
                        End If
                    Else
                        If GridView4.HeaderRow.Cells(i).Visible = True Then

                            If i <> 7 Then
                                'If i = 8 Then
                                '    'dt.Columns.Add("Technician ID", GetType(String))
                                '    'dt.Columns.Add("Technician Name", GetType(String))
                                '    'Service Status
                                '    dt.Columns.Add("Service Status", GetType(String))
                                '    ' dt.Columns.Add("Type", GetType(String))

                                'Else
                                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                                '  End If


                            Else
                                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                                dt.Columns.Add("Total Value", GetType(String))
                                dt.Columns.Add("Service Status", GetType(String))
                            End If

                            'If GridView4.HeaderRow.Cells(i).Visible = True Then
                            If i < GridView4.HeaderRow.Cells.Count - 3 Then
                                arcnt = arcnt + 1
                            End If
                            'End If

                        End If
                    End If


                Next



                Dim flag, flag2, flag3
                flag = 0
                arcnt = arcnt + 1 ' + 3
                Dim arr1(arcnt) As String

                If GridView5.Rows.Count > 0 Then
                    For Each row As GridViewRow In GridView5.Rows
                        If row.RowIndex <> GridView5.SelectedIndex Then
                            Dim cnt1
                            cnt1 = 0
                            flag2 = 0

                            For i = 2 To row.Cells.Count - 1
                                If row.Cells(i).Visible = True Then

                                    arr1(cnt1) = row.Cells(i).Text


                                    flag = 1
                                    flag2 = 1
                                    If i < row.Cells.Count - 1 Then
                                        cnt1 = cnt1 + 1
                                    End If
                                End If
                            Next
                            If flag2 = 1 Then
                                dt.Rows.Add(arr1)
                            End If
                        End If


                    Next

                    ' Response.Write("ppp<br>")
                End If


                '  Dim arr(arcnt) As String
                ' For Each row As GridViewRow In GridView4.Rows
                flag3 = 0
                Dim txt1, txt2 As New TextBox
                Dim drop, DROP1 As New DropDownList
                txt1 = GridView4.SelectedRow.FindControl("TextBox1")
                txt2 = GridView4.SelectedRow.FindControl("TextBox2")
                drop = GridView4.SelectedRow.FindControl("DropDownList5")
                drop1 = GridView4.SelectedRow.FindControl("DropDownList1")
                Dim p
                For p = 0 To drop1.Items.Count - 1
                    If drop1.Items(p).Text = "" Then
                        drop1.SelectedIndex = p
                    End If
                Next


                Dim cnt
                cnt = 0
                For i = 0 To GridView4.SelectedRow.Cells.Count - 3
                    If i = 0 Then
                        '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                        If i <> 5 And i <> 6 And i <> 7 And i <> 8 Then
                            arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                            'cnt = cnt + 1
                            flag = 1
                            flag3 = 1
                        Else
                            flag = 1
                            flag3 = 1
                            If i = 5 Then
                                arr1(cnt) = Val(txt1.Text)
                                ' cnt = cnt + 1
                            End If
                            If i = 6 Then
                                arr1(cnt) = Val(txt2.Text)
                                'cnt = cnt + 1
                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                'cnt = cnt + 1
                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                            End If
                            If i = 7 Then
                                arr1(cnt) = DROP1.SelectedItem.Text

                                cnt = cnt + 1
                                arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                cnt = cnt + 1
                                arr1(cnt) = "-"
                                'cnt = cnt + 1
                                'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            End If
                            'If i = 8 Then
                            '    '    arr1(cnt) = drop.SelectedValue.ToString
                            '    '    cnt = cnt + 1
                            '    '    arr1(cnt) = drop.SelectedItem.Text
                            '    '    cnt = cnt + 1
                            '    arr1(cnt) = "-"
                            '    '    'cnt = cnt + 1
                            '    '    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                            '    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            'End If
                        End If
                        'If GridView4.SelectedRow.Cells(i).Visible = True Then
                        If i < GridView4.SelectedRow.Cells.Count - 3 Then
                            cnt = cnt + 1
                        End If
                        'End If

                        'End If
                    Else

                        If GridView4.SelectedRow.Cells(i).Visible = True Then
                            If i <> 5 And i <> 6 And i <> 7 And i <> 8 Then
                                arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                                'cnt = cnt + 1
                                flag = 1
                                flag3 = 1
                            Else
                                flag = 1
                                flag3 = 1
                                If i = 5 Then
                                    arr1(cnt) = Val(txt1.Text)
                                    ' cnt = cnt + 1
                                End If
                                If i = 6 Then
                                    arr1(cnt) = Val(txt2.Text)
                                    'cnt = cnt + 1
                                    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                                End If
                                If i = 7 Then
                                    arr1(cnt) = DROP1.SelectedItem.Text

                                    cnt = cnt + 1
                                    arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                    '  cnt = cnt + 1
                                    cnt = cnt + 1
                                    arr1(cnt) = "-"
                                    'cnt = cnt + 1
                                    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                                    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                End If
                                'If i = 8 Then
                                '    '    arr1(cnt) = drop.SelectedValue.ToString
                                '    '    cnt = cnt + 1
                                '    '    arr1(cnt) = drop.SelectedItem.Text
                                '    '    cnt = cnt + 1
                                '    arr1(cnt) = "-"
                                '    '    'cnt = cnt + 1
                                '    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                'End If
                            End If

                            'If GridView4.SelectedRow.Cells(i).Visible = True Then
                            If i < GridView4.SelectedRow.Cells.Count - 3 Then
                                cnt = cnt + 1
                            End If
                        End If
                        'End If
                    End If

                Next

                ' Response.Write(cnt & "-" & arcnt)

                If flag3 = 1 Then
                    dt.Rows.Add(arr1)
                End If
                ' dt.Rows.Add(arr)
                ' Next
                If flag = 1 Then
                    total1 = 0

                    GridView5.DataSource = dt
                    GridView5.DataBind()

                Else
                    total1 = 0

                    GridView5.DataSource = Nothing
                    GridView5.DataBind()
                End If

                GridView5.SelectedIndex = -1
                GridView4.SelectedIndex = -1
                TextBox17.Text = ""
                TextBox18.Text = ""
                TextBox19.Text = ""
                TextBox32.Text = "1"
                TextBox33.Text = ""
                TextBox34.Text = ""
                TextBox35.Text = ""
                TextBox36.Text = ""
                TextBox37.Text = ""
                TextBox38.Text = ""
                TextBox39.Text = ""
                TextBox20.Text = ""
                GridView4.DataSource = Nothing
                GridView4.DataBind()
                TextBox18.Focus()

            End If
        End If


    End Sub

    Protected Sub Button16_Click(sender As Object, e As System.EventArgs) Handles Button16.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim service_id
        strnewrecord = "INSERT INTO [service_master] ([service_category],[service_name],[car_type],[service_charge],spare) values ('" & TextBox34.Text.Replace("'", "''") & "','" & TextBox34.Text.Replace("'", "''") & "','" & TextBox34.Text.Replace("'", "''") & "','" & Val(TextBox36.Text) & "','Spare'); select scope_identity()"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        service_id = Mycommand.ExecuteScalar.ToString
        'Mycommand.ExecuteNonQuery()


        GridView5.SelectedIndex = -1



        genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],'" & Val(TextBox36.Text) & "'  as [Unit Service Charge],'" & Val(DropDownList8.SelectedItem.Text) & "'  as [Unit], spare,'" & Val(TextBox35.Text) & "' as [Qty] FROM [service_master] where service_id='" & Val(service_id.ToString) & "'", GridView4)
        Myconnection.Close()
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox17.Text = ""
        TextBox32.Text = "1"
        TextBox33.Text = ""
        TextBox34.Text = ""

        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        If GridView5.Rows.Count = 0 Then
            GridView5.DataSource = Nothing
            GridView5.DataBind()
        End If


        If GridView4.Rows.Count = 0 Then
            'GridView5.DataSource = Nothing
            'GridView5.DataBind()
            TextBox35.Text = ""
        Else
            If GridView4.Rows.Count = 1 Then
                GridView4.SelectedIndex = 0
                Dim qtxt As New TextBox
                qtxt = GridView4.Rows(0).FindControl("TextBox2")
                qtxt.Text = TextBox35.Text
                TextBox35.Text = ""
                Dim dt = New DataTable("backupdata")
                Dim arcnt
                arcnt = 0
                For i = 0 To GridView4.HeaderRow.Cells.Count - 3
                    If i = 0 Then
                        dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))

                        If i < GridView4.HeaderRow.Cells.Count - 3 Then
                            arcnt = arcnt + 1
                        End If
                    Else
                        If GridView4.HeaderRow.Cells(i).Visible = True Then

                            If i <> 7 Then
                                'If i = 8 Then
                                '    'dt.Columns.Add("Technician ID", GetType(String))
                                '    'dt.Columns.Add("Technician Name", GetType(String))
                                '    'Service Status
                                '    dt.Columns.Add("Service Status", GetType(String))
                                '    ' dt.Columns.Add("Type", GetType(String))

                                'Else
                                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                                '  End If


                            Else
                                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                                dt.Columns.Add("Total Value", GetType(String))
                                dt.Columns.Add("Service Status", GetType(String))
                            End If

                            'If GridView4.HeaderRow.Cells(i).Visible = True Then
                            If i < GridView4.HeaderRow.Cells.Count - 3 Then
                                arcnt = arcnt + 1
                            End If
                            'End If

                        End If
                    End If


                Next



                Dim flag, flag2, flag3
                flag = 0
                arcnt = arcnt + 1 ' + 3
                Dim arr1(arcnt) As String

                If GridView5.Rows.Count > 0 Then
                    For Each row As GridViewRow In GridView5.Rows
                        If row.RowIndex <> GridView5.SelectedIndex Then
                            Dim cnt1
                            cnt1 = 0
                            flag2 = 0

                            For i = 2 To row.Cells.Count - 1
                                If row.Cells(i).Visible = True Then

                                    arr1(cnt1) = row.Cells(i).Text


                                    flag = 1
                                    flag2 = 1
                                    If i < row.Cells.Count - 1 Then
                                        cnt1 = cnt1 + 1
                                    End If
                                End If
                            Next
                            If flag2 = 1 Then
                                dt.Rows.Add(arr1)
                            End If
                        End If


                    Next

                    ' Response.Write("ppp<br>")
                End If


                '  Dim arr(arcnt) As String
                ' For Each row As GridViewRow In GridView4.Rows
                flag3 = 0
                Dim txt1, txt2 As New TextBox
                Dim drop, drop1 As New DropDownList
                txt1 = GridView4.SelectedRow.FindControl("TextBox1")
                txt2 = GridView4.SelectedRow.FindControl("TextBox2")
                drop = GridView4.SelectedRow.FindControl("DropDownList5")


                drop1 = GridView4.SelectedRow.FindControl("DropDownList1")
                Dim p
                For p = 0 To drop1.Items.Count - 1
                    If drop1.Items(p).Text = DropDownList8.SelectedItem.Text Then
                        drop1.SelectedIndex = p
                    End If
                Next

                Dim cnt
                cnt = 0
                For i = 0 To GridView4.SelectedRow.Cells.Count - 3
                    If i = 0 Then
                        '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                        If i <> 5 And i <> 6 And i <> 7 And i <> 8 Then
                            arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                            'cnt = cnt + 1
                            flag = 1
                            flag3 = 1
                        Else
                            flag = 1
                            flag3 = 1
                            If i = 5 Then
                                arr1(cnt) = Val(txt1.Text)
                                ' cnt = cnt + 1
                            End If
                            If i = 6 Then
                                arr1(cnt) = Val(txt2.Text)
                                'cnt = cnt + 1
                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                'cnt = cnt + 1
                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                            End If
                            If i = 7 Then
                                arr1(cnt) = drop1.SelectedItem.Text
                                cnt = cnt + 1
                                arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                cnt = cnt + 1
                                arr1(cnt) = "-"
                                '  cnt = cnt + 1
                                'arr1(cnt) = drop.SelectedItem.Text
                                'cnt = cnt + 1
                                'arr1(cnt) = "-"
                                'cnt = cnt + 1
                                'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            End If
                            'If i = 8 Then
                            '    '    arr1(cnt) = drop.SelectedValue.ToString
                            '    '    cnt = cnt + 1
                            '    '    arr1(cnt) = drop.SelectedItem.Text
                            '    '    cnt = cnt + 1
                            '    arr1(cnt) = "-"
                            '    '    'cnt = cnt + 1
                            '    '    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                            '    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            'End If
                        End If

                        ' If GridView4.SelectedRow.Cells(i).Visible = True Then
                        If i < GridView4.SelectedRow.Cells.Count - 3 Then
                            cnt = cnt + 1
                        End If
                        'End If
                        'End If
                    Else

                        If GridView4.SelectedRow.Cells(i).Visible = True Then
                            If i <> 5 And i <> 6 And i <> 7 And i <> 8 Then
                                arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                                'cnt = cnt + 1
                                flag = 1
                                flag3 = 1
                            Else
                                flag = 1
                                flag3 = 1
                                If i = 5 Then
                                    arr1(cnt) = Val(txt1.Text)
                                    ' cnt = cnt + 1
                                End If
                                If i = 6 Then
                                    arr1(cnt) = Val(txt2.Text)
                                    'cnt = cnt + 1
                                    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                                End If
                                If i = 7 Then
                                    arr1(cnt) = drop1.SelectedItem.Text
                                    cnt = cnt + 1
                                    arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                    cnt = cnt + 1
                                    arr1(cnt) = "-"
                                    '  cnt = cnt + 1
                                    'arr1(cnt) = drop.SelectedItem.Text
                                    'cnt = cnt + 1
                                    'arr1(cnt) = "-"
                                    'cnt = cnt + 1
                                    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                                    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                End If
                                'If i = 8 Then
                                '    '    arr1(cnt) = drop.SelectedValue.ToString
                                '    '    cnt = cnt + 1
                                '    '    arr1(cnt) = drop.SelectedItem.Text
                                '    '    cnt = cnt + 1
                                '    arr1(cnt) = "-"
                                '    '    'cnt = cnt + 1
                                '    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                'End If
                            End If

                            ' If GridView4.SelectedRow.Cells(i).Visible = True Then
                            If i < GridView4.SelectedRow.Cells.Count - 3 Then
                                cnt = cnt + 1
                            End If
                        End If
                        'End If
                        End If

                Next



                If flag3 = 1 Then
                    dt.Rows.Add(arr1)
                End If
                ' dt.Rows.Add(arr)
                ' Next
                If flag = 1 Then
                    total1 = 0

                    GridView5.DataSource = dt
                    GridView5.DataBind()

                Else
                    total1 = 0

                    GridView5.DataSource = Nothing
                    GridView5.DataBind()
                End If

                GridView5.SelectedIndex = -1
                GridView4.SelectedIndex = -1
                TextBox17.Text = ""
                TextBox18.Text = ""
                TextBox19.Text = ""
                TextBox32.Text = "1"
                TextBox33.Text = ""
                TextBox34.Text = ""
                TextBox35.Text = ""
                TextBox36.Text = ""
                TextBox37.Text = ""
                TextBox38.Text = ""
                TextBox39.Text = ""
                TextBox20.Text = ""
                GridView4.DataSource = Nothing
                GridView4.DataBind()
                TextBox34.Focus()

            End If
        End If


    End Sub

    Protected Sub Button17_Click(sender As Object, e As System.EventArgs) Handles Button17.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim service_id
        strnewrecord = "INSERT INTO [service_master] ([service_category],[service_name],[car_type],[service_charge],spare) values ('" & TextBox37.Text.Replace("'", "''") & "','" & TextBox37.Text.Replace("'", "''") & "','" & TextBox37.Text.Replace("'", "''") & "','" & Val(TextBox39.Text) & "','Machine Shop'); select scope_identity()"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        service_id = Mycommand.ExecuteScalar.ToString
        'Mycommand.ExecuteNonQuery()Type


        GridView5.SelectedIndex = -1



        genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],'" & Val(TextBox38.Text) & "'  as [Qty],'" & Val(TextBox39.Text) & "'  as [Unit Service Charge],'" & DropDownList9.SelectedItem.Text & "' as [Unit], spare FROM [service_master] where service_id='" & Val(service_id.ToString) & "'", GridView4)
        Myconnection.Close()
        'Dim qtxt As New TextBox
        'qtxt = GridView4.Rows(0).FindControl("TextBox2")
        'qtxt.Text = TextBox38.Text
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox17.Text = ""
        TextBox32.Text = "1"
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        If GridView5.Rows.Count = 0 Then
            GridView5.DataSource = Nothing
            GridView5.DataBind()
        End If


        If GridView4.Rows.Count = 0 Then
            'GridView5.DataSource = Nothing
            'GridView5.DataBind()

        Else
            If GridView4.Rows.Count = 1 Then
                GridView4.SelectedIndex = 0


                Dim dt = New DataTable("backupdata")
                Dim arcnt
                arcnt = 0
                For i = 0 To GridView4.HeaderRow.Cells.Count - 3
                    If i = 0 Then
                        dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))

                        If i < GridView4.HeaderRow.Cells.Count - 3 Then
                            arcnt = arcnt + 1
                        End If
                    Else
                        If GridView4.HeaderRow.Cells(i).Visible = True Then

                            If i <> 7 Then
                                'If i = 8 Then
                                '    'dt.Columns.Add("Technician ID", GetType(String))
                                '    'dt.Columns.Add("Technician Name", GetType(String))
                                '    'Service Status
                                '    dt.Columns.Add("Service Status", GetType(String))
                                '    ' dt.Columns.Add("Type", GetType(String))

                                'Else
                                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                                '  End If


                            Else
                                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                                dt.Columns.Add("Total Value", GetType(String))
                                dt.Columns.Add("Service Status", GetType(String))
                            End If

                            'If GridView4.HeaderRow.Cells(i).Visible = True Then
                            If i < GridView4.HeaderRow.Cells.Count - 3 Then
                                arcnt = arcnt + 1
                            End If
                            'End If

                        End If
                    End If


                Next



                Dim flag, flag2, flag3
                flag = 0
                arcnt = arcnt + 1 ' + 3
                ' Response.Write(arcnt)
                Dim arr1(arcnt) As String

                If GridView5.Rows.Count > 0 Then
                    For Each row As GridViewRow In GridView5.Rows
                        If row.RowIndex <> GridView5.SelectedIndex Then
                            Dim cnt1
                            cnt1 = 0
                            flag2 = 0

                            For i = 2 To row.Cells.Count - 1
                                If row.Cells(i).Visible = True Then

                                    arr1(cnt1) = row.Cells(i).Text


                                    flag = 1
                                    flag2 = 1
                                    If i < row.Cells.Count - 1 Then
                                        cnt1 = cnt1 + 1
                                    End If
                                End If
                            Next
                            If flag2 = 1 Then
                                dt.Rows.Add(arr1)
                            End If
                        End If


                    Next

                    ' Response.Write("ppp<br>")
                End If


                '  Dim arr(arcnt) As String
                ' For Each row As GridViewRow In GridView4.Rows
                flag3 = 0
                Dim txt1, txt2 As New TextBox
                Dim drop, drop1 As New DropDownList
                txt1 = GridView4.SelectedRow.FindControl("TextBox1")
                txt2 = GridView4.SelectedRow.FindControl("TextBox2")
                drop = GridView4.SelectedRow.FindControl("DropDownList5")

                drop1 = GridView4.SelectedRow.FindControl("DropDownList1")

                Dim p
                For p = 0 To drop1.Items.Count - 1
                    If drop1.Items(p).Text = DropDownList9.SelectedItem.Text Then
                        drop1.SelectedIndex = p
                    End If
                Next
                Dim cnt
                cnt = 0
                For i = 0 To GridView4.SelectedRow.Cells.Count - 3
                    If i = 0 Then
                        '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                        If i <> 8 And i <> 6 And i <> 5 And i <> 7 Then
                            arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                            'cnt = cnt + 1
                            flag = 1
                            flag3 = 1
                        Else
                            flag = 1
                            flag3 = 1
                            If i = 5 Then
                                arr1(cnt) = Val(txt1.Text)
                                ' cnt = cnt + 1
                            End If
                            If i = 6 Then
                                arr1(cnt) = Val(txt2.Text)
                                'cnt = cnt + 1
                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                'cnt = cnt + 1
                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                            End If
                            If i = 7 Then
                                arr1(cnt) = drop1.SelectedItem.Text
                                cnt = cnt + 1
                                arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                cnt = cnt + 1
                                arr1(cnt) = "-"
                                'cnt = cnt + 1
                                'arr1(cnt) = drop.SelectedItem.Text
                                'cnt = cnt + 1
                                'arr1(cnt) = "-"
                                'cnt = cnt + 1
                                'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                                'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            End If
                            'If i = 8 Then
                            '    '    arr1(cnt) = drop.SelectedValue.ToString
                            '    '    cnt = cnt + 1
                            '    '    arr1(cnt) = drop.SelectedItem.Text
                            '    '    cnt = cnt + 1
                            '    arr1(cnt) = "-"
                            '    '    'cnt = cnt + 1
                            '    '    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                            '    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                            'End If
                        End If

                        ' If GridView4.SelectedRow.Cells(i).Visible = True Then
                        If i < GridView4.SelectedRow.Cells.Count - 3 Then
                            cnt = cnt + 1
                        End If
                        'End If
                        'End If
                    Else

                        If GridView4.SelectedRow.Cells(i).Visible = True Then
                            If i <> 5 And i <> 6 And i <> 7 And i <> 8 Then
                                arr1(cnt) = GridView4.SelectedRow.Cells(i).Text
                                'cnt = cnt + 1
                                flag = 1
                                flag3 = 1
                            Else
                                flag = 1
                                flag3 = 1
                                If i = 5 Then
                                    arr1(cnt) = Val(txt1.Text)
                                    ' cnt = cnt + 1
                                End If
                                If i = 6 Then
                                    arr1(cnt) = Val(txt2.Text)
                                    'cnt = cnt + 1
                                    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                                End If
                                If i = 7 Then
                                    arr1(cnt) = drop1.SelectedItem.Text
                                    cnt = cnt + 1
                                    arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                    cnt = cnt + 1
                                    arr1(cnt) = "-"
                                    'cnt = cnt + 1
                                    'arr1(cnt) = drop.SelectedItem.Text
                                    'cnt = cnt + 1
                                    'arr1(cnt) = "-"
                                    'cnt = cnt + 1
                                    'arr1(cnt) = GridView4.SelectedRow.Cells(8).Text

                                    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                End If
                                'If i = 8 Then
                                '    '    arr1(cnt) = drop.SelectedValue.ToString
                                '    '    cnt = cnt + 1
                                '    '    arr1(cnt) = drop.SelectedItem.Text
                                '    '    cnt = cnt + 1
                                '    arr1(cnt) = "-"
                                '    '    'cnt = cnt + 1
                                '    '    'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                                'End If
                            End If

                            '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                            If i < GridView4.SelectedRow.Cells.Count - 3 Then
                                cnt = cnt + 1
                            End If
                        End If
                        ' If
                        End If
                        '   Response.Write("<br>" & i & "-" & cnt)
                Next

                'Response.Write("<br>" & cnt)

                If flag3 = 1 Then
                    dt.Rows.Add(arr1)
                End If
                ' dt.Rows.Add(arr)
                ' Next
                If flag = 1 Then
                    total1 = 0

                    GridView5.DataSource = dt
                    GridView5.DataBind()

                Else
                    total1 = 0

                    GridView5.DataSource = Nothing
                    GridView5.DataBind()
                End If

                GridView5.SelectedIndex = -1
                GridView4.SelectedIndex = -1
                TextBox17.Text = ""
                TextBox18.Text = ""
                TextBox19.Text = ""
                TextBox32.Text = "1"
                TextBox33.Text = ""
                TextBox34.Text = ""
                TextBox35.Text = ""
                TextBox36.Text = ""
                TextBox37.Text = ""
                TextBox38.Text = ""
                TextBox39.Text = ""
                TextBox20.Text = ""
                GridView4.DataSource = Nothing
                GridView4.DataBind()
                TextBox37.Focus()

            End If
        End If

    End Sub

    Protected Sub Button18_Click(sender As Object, e As System.EventArgs) Handles Button18.Click
        Dim dt = New DataTable("backupdata")

        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Quantity", GetType(String))
        dt.Columns.Add("Rate", GetType(String))
        Dim arr1(2) As String
        Dim i, j
        For i = 0 To GridView9.Rows.Count - 2

            For j = 2 To GridView9.Rows(i).Cells.Count - 1
                arr1(j - 2) = GridView9.Rows(i).Cells(j).Text
            Next
            dt.Rows.Add(arr1)
        Next

        If Trim(TextBox22.Text) <> "" Then
            arr1(0) = Trim(TextBox22.Text)
            arr1(1) = ""
            arr1(2) = ""
            dt.Rows.Add(arr1)
        End If

        If Val(TextBox42.Text) > 0 Then

            arr1(0) = "Dent and Paint"
            arr1(1) = Trim(TextBox43.Text)
            arr1(2) = Trim(TextBox42.Text)
            dt.Rows.Add(arr1)
        Else
            If GridView9.Rows.Count > 0 Then
                For j = 2 To GridView9.Rows(GridView9.Rows.Count - 1).Cells.Count - 1
                    arr1(j - 2) = GridView9.Rows(GridView9.Rows.Count - 1).Cells(j).Text
                Next
                dt.Rows.Add(arr1)
            End If


        End If


        total1 = 0
        GridView9.DataSource = dt
        GridView9.DataBind()

        TextBox22.Text = ""
        TextBox43.Text = ""
        TextBox42.Text = ""
        TextBox22.Focus()
    End Sub

    Protected Sub GridView9_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView9.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim i
            For i = 2 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Text = Server.HtmlDecode(e.Row.Cells(i).Text)
            Next

            If Val(e.Row.Cells(4).Text) > 0 Then
                e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                total1 = total1 + Val(e.Row.Cells(4).Text)
            Else
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            End If

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = total1
            e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub

    Protected Sub GridView9_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView9.RowDeleting

        'If GridView9.SelectedIndex = GridView9.Rows.Count - 1 Then
        '    TextBox22.Text = "" 'GridView9.SelectedRow.Cells(2).Text
        '    TextBox43.Text = GridView9.SelectedRow.Cells(3).Text
        '    TextBox42.Text = GridView9.SelectedRow.Cells(4).Text
        'Else
        '    TextBox22.Text = GridView9.SelectedRow.Cells(2).Text
        '    TextBox42.Text = ""
        '    TextBox43.Text = ""
        'End If



        Dim dt = New DataTable("backupdata")

        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Quantity", GetType(String))
        dt.Columns.Add("Rate", GetType(String))
        Dim arr1(2) As String
        Dim i, j
        For i = 0 To GridView9.Rows.Count - 1
            'If e.RowIndex = GridView9.Rows.Count - 1 Then
            '    '   If i <> GridView9.SelectedIndex Then
            '    For j = 2 To GridView9.Rows(i).Cells.Count - 1
            '        arr1(j - 2) = GridView9.Rows(i).Cells(j).Text
            '    Next
            '    dt.Rows.Add(arr1)
            '    '  End If
            'Else
            If i <> e.RowIndex Then
                For j = 2 To GridView9.Rows(i).Cells.Count - 1
                    arr1(j - 2) = GridView9.Rows(i).Cells(j).Text
                Next
                dt.Rows.Add(arr1)
            End If
            'End If


        Next




        total1 = 0
        GridView9.DataSource = dt
        GridView9.DataBind()
    End Sub

    Protected Sub GridView9_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView9.SelectedIndexChanged

        If GridView9.SelectedIndex = GridView9.Rows.Count - 1 Then
            TextBox22.Text = "" 'GridView9.SelectedRow.Cells(2).Text
            TextBox43.Text = GridView9.SelectedRow.Cells(3).Text
            TextBox42.Text = GridView9.SelectedRow.Cells(4).Text
        Else
            TextBox22.Text = GridView9.SelectedRow.Cells(2).Text
            TextBox42.Text = ""
            TextBox43.Text = ""
        End If



        Dim dt = New DataTable("backupdata")

        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Quantity", GetType(String))
        dt.Columns.Add("Rate", GetType(String))
        Dim arr1(2) As String
        Dim i, j
        For i = 0 To GridView9.Rows.Count - 1
            If GridView9.SelectedIndex = GridView9.Rows.Count - 1 Then
                '   If i <> GridView9.SelectedIndex Then
                For j = 2 To GridView9.Rows(i).Cells.Count - 1
                    arr1(j - 2) = GridView9.Rows(i).Cells(j).Text
                Next
                dt.Rows.Add(arr1)
                '  End If
            Else
                If i <> GridView9.SelectedIndex Then
                    For j = 2 To GridView9.Rows(i).Cells.Count - 1
                        arr1(j - 2) = GridView9.Rows(i).Cells(j).Text
                    Next
                    dt.Rows.Add(arr1)
                End If
            End If


        Next




        total1 = 0
        GridView9.DataSource = dt
        GridView9.DataBind()
    End Sub

    Protected Sub DropDownList10_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList10.SelectedIndexChanged
        TextBox9.Text = DropDownList10.SelectedItem.Text

        strnewrecord = "SELECT top 1 [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), advance, advance_date, mr_no,  (select r.r_bill_no from estimate_job_bill r where r.bill_no=estimate_new_job_cart.bill_no), job_id FROM [estimate_new_job_cart] where reg_no='" & Trim(TextBox9.Text) & "' order by job_id desc"
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

    Protected Sub Button19_Click(sender As Object, e As System.EventArgs) Handles Button19.Click
        If genf.checkexistancefromdv("select mod_pwd from mod_pwd where mod_pwd='" & TextBox44.Text & "'") Then

            If Val(Label48.Text) > 0 Then
                Label65.Visible = False
                TextBox44.Visible = False
                Button19.Visible = False

                Button4.Visible = True
                Button7.Visible = False
            Else

                Label65.Visible = True
                TextBox44.Visible = True
                Button19.Visible = True

                Button4.Visible = False
                Button7.Visible = True
            End If
        Else

            Dim alertScript = "alert('Wrong Password...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)

            Label65.Visible = True
            TextBox44.Visible = True
            Button19.Visible = True
            Button4.Visible = False
            Button7.Visible = True
        End If
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



        total1 = 0
        total2 = 0

        'strnewrecord = "select job_part.job_id as [Issue ID], vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], job_part.qty as [Quantity], job_part.amount as [Price] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(TextBox45.Text) & "' and vehicle_parts.id=job_part.part_id"
        '' Response.Write(strnewrecord)
        'genf.populate_grid(strnewrecord, GridView8)


        strnewrecord = "select Description as [Description], qty as [Quantity], price as [Rate], Tx_id from new_job_dent_paint where job_id='" & Val(TextBox45.Text) & "' order by [Tx_id]"
        genf.populate_grid(strnewrecord, GridView9)


        total1 = 0
        strnewrecord = "select new_job_service.service_id as [Service ID], service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service],unit as [Unit], new_job_service.cost as [Total Value],(case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and new_job_service.job_id='" & Val(TextBox45.Text) & "'"
        genf.populate_grid(strnewrecord, GridView5)
        total1 = 0
        total2 = 0
        total3 = 0
        strnewrecord = "select [new_job_parts].[part_id] as [Parts ID], [new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [new_job_parts].[qty] as [Requisit Quantity],(select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity],'' as [Required Quantity], vehicle_parts.unit as [Unit], '0' as [Price], '0' as [Total] from [new_job_parts], vehicle_parts where [new_job_parts].[part_id]=vehicle_parts.id and new_job_parts.job_id='" & Val(TextBox45.Text) & "'"
        strnewrecord = strnewrecord & " union all select [job_part].[part_id] as [Parts ID], [job_part].[part_no] as [Parts No], vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], job_part.qty as [Requisit Quantity], '0' as [Issued Quantity], job_part.qty as [Required Quantity],vehicle_parts.unit  as [Unit], job_part.amount as [Price], job_part.amount * job_part.qty  as [Total] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(TextBox45.Text) & "' and vehicle_parts.id=job_part.part_id"

        genf.populate_grid(strnewrecord, GridView7)

    End Sub

    Protected Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        If TextBox40.Text = "" Then
            TextBox40.Text = "-"

        End If
        Dim job_id
        If Request.QueryString("url") <> "" Then





            strnewrecord = "INSERT INTO [estimate_new_job_cart]"
            strnewrecord = strnewrecord & "([customer_name]"
            strnewrecord = strnewrecord & ",[address]"
            strnewrecord = strnewrecord & ",[email]"
            strnewrecord = strnewrecord & ",[tel]"
            strnewrecord = strnewrecord & ",[mobile]"
            strnewrecord = strnewrecord & ",[in_date]"
            strnewrecord = strnewrecord & ",[dlv_date]"
            strnewrecord = strnewrecord & ",[manual_ro]"
            strnewrecord = strnewrecord & ",[vehicle]"
            strnewrecord = strnewrecord & ",[reg_no]"
            strnewrecord = strnewrecord & ",[model]"
            strnewrecord = strnewrecord & ",[eng_no]"
            strnewrecord = strnewrecord & ",[chesis_no]"
            strnewrecord = strnewrecord & ",[km]"
            strnewrecord = strnewrecord & ",[no_valuable]"
            strnewrecord = strnewrecord & ",[attached_sheet],advance,advance_date,tnc)"

            strnewrecord = strnewrecord & " values "

            strnewrecord = strnewrecord & "('" & TextBox1.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox2.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox3.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox4.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox5.Text & "'"

            Dim arr1()
            arr1 = Split(TextBox6.Text, "/")
            Dim dt As New Date
            dt = New Date(Val(arr1(2).ToString), Val(arr1(1).ToString), Val(arr1(0).ToString), Val(DropDownList1.SelectedItem.Text), Val(DropDownList2.SelectedItem.Text), 0)


            Dim arr11()
            arr11 = Split(TextBox7.Text, "/")
            Dim dt1 As New Date
            dt1 = New Date(Val(arr11(2).ToString), Val(arr11(1).ToString), Val(arr11(0).ToString), Val(DropDownList3.SelectedItem.Text), Val(DropDownList4.SelectedItem.Text), 0)



            strnewrecord = strnewrecord & ",'" & dt & "'"
            strnewrecord = strnewrecord & ",'" & dt1 & "'"
            strnewrecord = strnewrecord & ",'" & TextBox14.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox8.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox9.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox10.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox11.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox12.Text & "'"
            strnewrecord = strnewrecord & ",'" & TextBox13.Text & "'"
            strnewrecord = strnewrecord & ",'" & CheckBox1.Checked.ToString & "'"
            strnewrecord = strnewrecord & ",'" & CheckBox2.Checked.ToString & "','" & Val(TextBox24.Text) & "','" & genf.getdate(TextBox25.Text) & "','" & TextBox40.Text.Replace("'", "''") & "'); select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            job_id = Val(Mycommand.ExecuteScalar.ToString)



            'strnewrecord = "INSERT INTO [payment]"
            'strnewrecord = strnewrecord & "([job_no]"
            'strnewrecord = strnewrecord & ",[amount]"
            'strnewrecord = strnewrecord & ",[bill_date], mr_no, b_type, status)"
            'strnewrecord = strnewrecord & " values "
            'strnewrecord = strnewrecord & "('" & job_id & "'"
            'strnewrecord = strnewrecord & ",'" & Val(TextBox24.Text) & "'"
            'strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox25.Text) & "','" & TextBox26.Text & "','Advance','Confirmed')"
            'Mycommand = New SqlCommand(strnewrecord, Myconnection)
            'Mycommand.ExecuteNonQuery()

            If Val(TextBox24.Text) > 0 Then

                strnewrecord = "INSERT INTO [estimate_payment]"
                strnewrecord = strnewrecord & "([job_no]"
                strnewrecord = strnewrecord & ",[amount]"
                If DropDownList6.SelectedItem.Text = "Cash" Then
                    strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode, status)"

                Else
                    strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode,chq_date,bank,cheque_no,status)"

                End If
                strnewrecord = strnewrecord & " values "
                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(TextBox24.Text) & "'"
                If DropDownList6.SelectedItem.Text = "Cash" Then
                    strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox25.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','Confirmed'); select scope_identity()"

                Else
                    strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox26.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','" & genf.getdate(TextBox29.Text) & "','" & TextBox28.Text & "','" & TextBox26.Text & "','Float'); select scope_identity()"

                End If
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Dim inv_no
                inv_no = Mycommand.ExecuteScalar.ToString()
                strnewrecord = "update estimate_new_job_cart set mr_no='" & Val(inv_no.ToString) & "' where job_id='" & Val(job_id.ToString) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If

        Else
            job_id = Val(Request.QueryString("url").ToString)

            If genf.checkexistancefromdv("select * from estimate_payment  where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance'") = True Then
                'strnewrecord = "update [payment] "
                'strnewrecord = strnewrecord & " set [job_no]='" & job_id & "'"
                'strnewrecord = strnewrecord & ",[amount]='" & Val(TextBox24.Text) & "'"
                'strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox25.Text) & "', mr_no='" & TextBox26.Text & "', status='Confirmed' where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance'"
                'Mycommand = New SqlCommand(strnewrecord, Myconnection)
                'Mycommand.ExecuteNonQuery()

                If Val(TextBox24.Text) > 0 Then


                    strnewrecord = "update [estimate_payment] set "
                    strnewrecord = strnewrecord & " [job_no]='" & Val(job_id.ToString) & "'"
                    strnewrecord = strnewrecord & ",[amount]='" & Val(TextBox24.Text) & "'"
                    If DropDownList6.SelectedItem.Text = "Cash" Then
                        strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox25.Text) & "', b_type='Advance',pmnt_mode='" & DropDownList6.SelectedItem.Text & "', status='Confirmed'"
                    Else
                        strnewrecord = strnewrecord & ",[bill_date]='" & genf.getdate(TextBox25.Text) & "', b_type='Advance',pmnt_mode='" & DropDownList6.SelectedItem.Text & "',chq_date='" & genf.getdate(TextBox29.Text) & "',bank='" & TextBox28.Text & "',cheque_no='" & TextBox26.Text & "',status='Float'"
                    End If
                    strnewrecord = strnewrecord & "  where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()

                    strnewrecord = "select tx_no from estimate_payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
                    Dim tx_no1
                    tx_no1 = genf.returnvaluefromdv(strnewrecord, 0)

                    strnewrecord = "update estimate_new_job_cart set mr_no='" & Val(tx_no1.ToString) & "' where job_id='" & Val(job_id.ToString) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                Else

                    strnewrecord = "delete from estimate_payment where job_no='" & Val(job_id.ToString) & "' and b_type='Advance'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()

                    strnewrecord = "update estimate_new_job_cart set mr_no=NULL where job_id='" & Val(job_id.ToString) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                End If

            Else
                If Val(TextBox24.Text) > 0 Then

                    strnewrecord = "INSERT INTO [estimate_payment]"
                    strnewrecord = strnewrecord & "([job_no]"
                    strnewrecord = strnewrecord & ",[amount]"
                    If DropDownList6.SelectedItem.Text = "Cash" Then
                        strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode, status)"

                    Else
                        strnewrecord = strnewrecord & ",[bill_date], b_type,pmnt_mode,chq_date,bank,cheque_no,status)"

                    End If
                    strnewrecord = strnewrecord & " values "
                    strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                    strnewrecord = strnewrecord & ",'" & Val(TextBox24.Text) & "'"
                    If DropDownList6.SelectedItem.Text = "Cash" Then
                        strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox25.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','Confirmed'); select scope_identity()"

                    Else
                        strnewrecord = strnewrecord & ",'" & genf.getdate(TextBox26.Text) & "','Advance','" & DropDownList6.SelectedItem.Text & "','" & genf.getdate(TextBox29.Text) & "','" & TextBox28.Text & "','" & TextBox26.Text & "','Float'); select scope_identity()"

                    End If
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Dim inv_no
                    inv_no = Mycommand.ExecuteScalar.ToString()
                    strnewrecord = "update estimate_new_job_cart set mr_no='" & Val(inv_no.ToString) & "' where job_id='" & Val(job_id.ToString) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                End If

            End If






            strnewrecord = "update [estimate_new_job_cart]"
            strnewrecord = strnewrecord & " set [customer_name]='" & TextBox1.Text & "', tnc='" & TextBox40.Text.Replace("'", "''") & "'"
            strnewrecord = strnewrecord & ",[address]='" & TextBox2.Text & "'"
            strnewrecord = strnewrecord & ",[email]='" & TextBox3.Text & "'"
            strnewrecord = strnewrecord & ",[tel]='" & TextBox4.Text & "'"
            strnewrecord = strnewrecord & ",[mobile]='" & TextBox5.Text & "'"

            Dim arr1()
            arr1 = Split(TextBox6.Text, "/")
            Dim dt As New Date
            dt = New Date(Val(arr1(2).ToString), Val(arr1(1).ToString), Val(arr1(0).ToString), Val(DropDownList1.SelectedItem.Text), Val(DropDownList2.SelectedItem.Text), 0)

            strnewrecord = strnewrecord & ",[in_date]='" & dt & "'"
            Dim arr11()
            arr11 = Split(TextBox7.Text, "/")
            Dim dt1 As New Date
            dt1 = New Date(Val(arr11(2).ToString), Val(arr11(1).ToString), Val(arr11(0).ToString), Val(DropDownList3.SelectedItem.Text), Val(DropDownList4.SelectedItem.Text), 0)

            strnewrecord = strnewrecord & ",[dlv_date]='" & dt1 & "'"
            strnewrecord = strnewrecord & ",[manual_ro]='" & TextBox14.Text & "'"
            strnewrecord = strnewrecord & ",[vehicle]='" & TextBox8.Text & "'"
            strnewrecord = strnewrecord & ",[reg_no]='" & TextBox9.Text & "'"
            strnewrecord = strnewrecord & ",[model]='" & TextBox10.Text & "'"
            strnewrecord = strnewrecord & ",[eng_no]='" & TextBox11.Text & "'"
            strnewrecord = strnewrecord & ",[chesis_no]='" & TextBox12.Text & "'"
            strnewrecord = strnewrecord & ",[km]='" & TextBox13.Text & "'"
            strnewrecord = strnewrecord & ",[no_valuable]='" & CheckBox1.Checked.ToString & "'"
            strnewrecord = strnewrecord & ",[attached_sheet]='" & CheckBox2.Checked.ToString & "', advance='" & Val(TextBox24.Text) & "', advance_date='" & genf.getdate(TextBox25.Text) & "' where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_complain where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_technical_report where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_valuable where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_service where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from estimate_new_job_parts where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()


            strnewrecord = "delete from new_estimate_dent_paint where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
        End If




        Dim i
        For i = 0 To GridView1.Rows.Count - 1
            Dim txt1 As New TextBox
            txt1 = GridView1.Rows(i).FindControl("TextBox1")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [estimate_new_job_complain]"
                strnewrecord = strnewrecord & "([job_id]"
                strnewrecord = strnewrecord & ",[sl]"
                strnewrecord = strnewrecord & ",[complain])"

                strnewrecord = strnewrecord & " values "

                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(GridView1.Rows(i).Cells(0).Text) & "'"
                strnewrecord = strnewrecord & ",'" & txt1.Text & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If


        Next


        For i = 0 To GridView2.Rows.Count - 1
            Dim txt1 As New TextBox
            txt1 = GridView2.Rows(i).FindControl("TextBox15")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [estimate_new_job_technical_report]"
                strnewrecord = strnewrecord & "([job_id]"
                strnewrecord = strnewrecord & ",[sl]"
                strnewrecord = strnewrecord & ",[technical_report])"

                strnewrecord = strnewrecord & " values "

                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(GridView2.Rows(i).Cells(0).Text) & "'"
                strnewrecord = strnewrecord & ",'" & txt1.Text & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If


        Next


        For i = 0 To GridView3.Rows.Count - 1
            Dim txt1 As New TextBox
            txt1 = GridView3.Rows(i).FindControl("TextBox16")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [estimate_new_job_valuable]"
                strnewrecord = strnewrecord & "([job_id]"
                strnewrecord = strnewrecord & ",[sl]"
                strnewrecord = strnewrecord & ",[description])"

                strnewrecord = strnewrecord & " values "

                strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
                strnewrecord = strnewrecord & ",'" & Val(GridView3.Rows(i).Cells(0).Text) & "'"
                strnewrecord = strnewrecord & ",'" & txt1.Text & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If


        Next

        For i = 0 To GridView5.Rows.Count - 1

            strnewrecord = "INSERT INTO [estimate_new_job_service]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[service_id]"
            strnewrecord = strnewrecord & ",[unit_cost]"
            strnewrecord = strnewrecord & ",[qty]"
            strnewrecord = strnewrecord & ",[unit]"
            strnewrecord = strnewrecord & ",[cost]"
            strnewrecord = strnewrecord & ",[technician_id])"

            strnewrecord = strnewrecord & " values "


            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"

            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(2).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(5).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(6).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Trim(GridView5.Rows(i).Cells(7).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(8).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(9).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()



        Next

        For i = 0 To GridView7.Rows.Count - 1

            strnewrecord = "INSERT INTO [estimate_new_job_parts]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[part_id]"
            strnewrecord = strnewrecord & ",[part_no]"
            strnewrecord = strnewrecord & ",[qty],[price], total)"

            strnewrecord = strnewrecord & " values "


            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"

            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(2).Text) & "'"
            strnewrecord = strnewrecord & ",'" & GridView7.Rows(i).Cells(3).Text.Replace("'", "''") & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(8).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(10).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(11).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()



        Next



        For i = 0 To GridView9.Rows.Count - 1

            strnewrecord = "INSERT INTO [new_estimate_dent_paint]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[description]"
            strnewrecord = strnewrecord & ",[qty]"
            strnewrecord = strnewrecord & ",[Price])"
            strnewrecord = strnewrecord & " values "

            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"
            strnewrecord = strnewrecord & ",'" & Trim(GridView9.Rows(i).Cells(2).Text.Replace("'", "''")) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView9.Rows(i).Cells(3).Text.Replace("'", "''")) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView9.Rows(i).Cells(4).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()

        Next

        Myconnection.Close()
        Button1.Visible = True
        Page_Load(sender, e)
        If Request.QueryString("url") <> "" Then
            Dim alertScript = "alert('Estimate Has Been Submited Succesfully With Estimate ID - " & job_id & " ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        Else
            Dim alertScript = "alert('Estimate With Estimate ID - " & job_id & " Has Been Modified Succesfully ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        End If


        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('estimate_bill.aspx?url=" & job_id & "','estimate_gen_bill');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())


        'Dim rsb1 As StringBuilder
        'rsb1 = New StringBuilder()
        'rsb1.Append("<script language=""JavaScript"">")
        'rsb1.Append("window.open('Estimate_job_sheet.aspx?url=" & Val(job_id.ToString) & "','print_job');")
        'rsb1.Append("</scri")
        'rsb1.Append("pt>")
        'Page.RegisterStartupScript("rtest1", rsb1.ToString())


        If Val(TextBox24.Text) > 0 Then


            strnewrecord = "select tx_no from estimate_payment where [job_no]='" & Val(job_id.ToString) & "' and b_type='Advance' "
            Dim tx_no
            tx_no = genf.returnvaluefromdv(strnewrecord, 0)

            Dim rsb12 As StringBuilder
            rsb12 = New StringBuilder()
            rsb12.Append("<script language=""JavaScript"">")
            rsb12.Append("window.open('money_receipt.aspx?url=" & Val(tx_no.ToString) & "','money_rcpt');")
            rsb12.Append("</scri")
            rsb12.Append("pt>")
            Page.RegisterStartupScript("rtest12", rsb12.ToString())
        End If
    End Sub
End Class

