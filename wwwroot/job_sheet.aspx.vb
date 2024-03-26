Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class job_sheet
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

            If Not IsNothing(Session("uid")) Then
                If Session("uid") = "VehicleSolution" Then

                Else
                    If Val(genf.returnvaluefromdv("select print_flag from new_job_cart where job_id='" & Val(Request.QueryString("url").ToString) & "'", 0).ToString) = 1 Then
                        Response.Redirect("job_card.aspx?url=" & Val(Request.QueryString("url").ToString))
                    End If
                End If
            Else
                Response.Redirect("login.aspx")
            End If
          
           


            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()
           


            strnewrecord = "update new_job_cart set [print_flag]='1' where job_id='" & Val(Request.QueryString("url").ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
            Myconnection.Close()

            Label30.Text = ""
            Button5.Visible = False
            Label31.Text = "Create Job Sheet"
            ' Me.Title = "Create Job Sheet"
            Button1.Visible = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            genf.populate_grid("select sl, description from temp_table order by sl", GridView1)
            genf.populate_grid("select sl, description from temp_table order by sl", GridView2)
            genf.populate_grid("select sl, description from temp_table order by sl", GridView3)

            TextBox1.Text = ""
            TextBox26.Text = ""

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
            TextBox19.Text = ""
            TextBox20.Text = ""
            TextBox21.Text = ""

            TextBox23.Text = ""
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

            TextBox24.Text = ""
            TextBox25.Text = ""
            If Not IsNothing(Request.QueryString("url")) Then

                Dim status = genf.returnvaluefromdv("select hstatus from new_job_cart where job_id='" + Request.QueryString("url") + "'", 0)

                If status = False Then
                    Dim a = GridView5.SelectedRow.RowIndex
                End If

                TextBox24.Text = Request.QueryString("url")
                Image3.ImageUrl = "IDAutomationStreamingLinear.aspx?barcode=" & TextBox24.Text & "&CODE_TYPE=" & 50

                Button4.Text = "Modify"
                Label31.Text = "Modify Job Sheet"
                '  Me.Title = "Modify Job Sheet"

                Button5.Visible = False
                strnewrecord = "SELECT [customer_name],[address],[email],[tel],[mobile],[in_date],[dlv_date],[manual_ro],[vehicle],[reg_no],[model],[eng_no],[chesis_no],[km],[no_valuable],[attached_sheet],(case when [status] is null then 'Job Has Not Been Started Yet' else [status] end), customer_id FROM [new_job_cart] where job_id='" & Val(Request.QueryString("url").ToString) & "'"
                TextBox1.Text = genf.returnvaluefromdv(strnewrecord, 0)
                TextBox26.Text = genf.returnvaluefromdv(strnewrecord, 17)
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
                Label34.Text = Val(dt1.ToString("HH"))

                For k = 0 To DropDownList2.Items.Count - 1
                    If Val(DropDownList2.Items(k).Text) = Val(dt1.ToString("mm")) Then
                        DropDownList2.SelectedIndex = k
                    End If
                Next
                Label35.Text = Val(dt1.ToString("mm"))

                Dim dt2 As New DateTime
                dt2 = genf.returnvaluefromdv(strnewrecord, 6)
                TextBox7.Text = dt2.ToString("dd/MM/yyyy")
                For k = 0 To DropDownList3.Items.Count - 1
                    If Val(DropDownList3.Items(k).Text) = Val(dt2.ToString("HH")) Then
                        DropDownList3.SelectedIndex = k
                    End If
                Next
                Label32.Text = Val(dt2.ToString("HH"))
                For k = 0 To DropDownList4.Items.Count - 1
                    If Val(DropDownList4.Items(k).Text) = Val(dt2.ToString("mm")) Then
                        DropDownList4.SelectedIndex = k
                    End If
                Next
                Label33.Text = Val(dt2.ToString("mm"))
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
                total1 = 0
                strnewrecord = "select new_job_service.service_id as [Service ID], service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service], new_job_service.cost as [Total Value],new_job_service.technician_id as [Technician ID], technician_master.technician_name as [Technician Name],(case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status]  from new_job_service, service_master, technician_master where new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and new_job_service.job_id='" & Val(Request.QueryString("url")) & "'"
                genf.populate_grid(strnewrecord, GridView5)
                total1 = 0
                total2 = 0
                total3 = 0
                strnewrecord = "select [new_job_parts].[part_id] as [Parts ID], [new_job_parts].[part_no] as [Parts No],vehicle_parts.parts_name as [Parts Name], vehicle_parts.description as [Description], [new_job_parts].[qty] as [Requisit Quantity],(select sum(j.qty) from job_part j, job_sheet k where j.job_id=k.job_no and k.km=new_job_parts.job_id and j.part_id=new_job_parts.part_id) as [Issued Quantity],'' as [Required Quantity], vehicle_parts.unit as [Unit] from [new_job_parts], vehicle_parts where [new_job_parts].[part_id]=vehicle_parts.id and new_job_parts.job_id='" & Val(Request.QueryString("url")) & "'"
                genf.populate_grid(strnewrecord, GridView7)
                total1 = 0
                total2 = 0

                strnewrecord = "select job_part.job_id as [Issue ID], job_part.part_no as [Parts Name], vehicle_parts.description as [Description], job_part.qty as [Quantity], job_part.amount as [Price] from job_part, job_sheet, vehicle_parts where job_part.job_id=job_sheet.job_no and job_sheet.km='" & Val(Request.QueryString("url")) & "' and vehicle_parts.id=job_part.part_id"
                genf.populate_grid(strnewrecord, GridView8)

            Else
                Button4.Text = "Submit"
                Button5.Visible = False
                Label31.Text = "Create Job Sheet"
                ' Me.Title = "Create Job Sheet"

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
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge] FROM [service_master] where ( service_category like '%" & TextBox17.Text & "%' and service_name like '%" & TextBox18.Text & "%' and car_type like '%" & TextBox19.Text & "%')", GridView4)

            Else
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge] FROM [service_master] where service_id='" & Val(TextBox20.Text) & "'", GridView4)

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

            Dim txt1, txt2 As New Label
            txt1 = e.Row.FindControl("TextBox1")
            txt2 = e.Row.FindControl("TextBox2")

            If GridView5.SelectedIndex >= 0 Then
                txt1.Text = GridView5.SelectedRow.Cells(5).Text
                txt2.Text = GridView5.SelectedRow.Cells(6).Text
            End If

            txt1.Text = genf.roundup(txt1.Text)
            If e.Row.RowIndex = 0 Then
                txt1.Focus()
            End If

            Dim drop As New DropDownList
            drop = e.Row.FindControl("DropDownList5")
            genf.populate_dropdownlist1("select technician_id, technician_name from technician_master order by technician_name", drop, "technician_name", "technician_id")

            If GridView5.SelectedIndex >= 0 Then
                Dim i
                For i = 0 To drop.Items.Count - 1
                    If drop.Items(i).Value = GridView5.SelectedRow.Cells(8).Text Then
                        drop.SelectedIndex = i
                    End If
                Next

            End If
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(4).Visible = False
        End If

    End Sub

    Protected Sub GridView4_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView4.SelectedIndexChanged


        Dim dt = New DataTable("backupdata")
        Dim arcnt
        arcnt = 0
        For i = 0 To GridView4.HeaderRow.Cells.Count - 2
            If i = 0 Then
                dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))

                If i < GridView4.HeaderRow.Cells.Count - 2 Then
                    arcnt = arcnt + 1
                End If
            Else
                If GridView4.HeaderRow.Cells(i).Visible = True Then

                    If i <> 6 Then
                        If i = 7 Then
                            dt.Columns.Add("Technician ID", GetType(String))
                            dt.Columns.Add("Technician Name", GetType(String))
                            'Service Status
                            dt.Columns.Add("Service Status", GetType(String))
                        Else
                            dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                        End If


                    Else
                        dt.Columns.Add(GridView4.HeaderRow.Cells(i).Text, GetType(String))
                        dt.Columns.Add("Total Value", GetType(String))
                    End If

                    If i < GridView4.HeaderRow.Cells.Count - 2 Then
                        arcnt = arcnt + 1
                    End If

                End If
            End If


        Next



        Dim flag, flag2, flag3
        flag = 0
        arcnt = arcnt + 3
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
        Dim txt1, txt2 As New Label
        Dim drop As New DropDownList
        txt1 = GridView4.SelectedRow.FindControl("TextBox1")
        txt2 = GridView4.SelectedRow.FindControl("TextBox2")
        drop = GridView4.SelectedRow.FindControl("DropDownList5")



        Dim cnt
        cnt = 0
        For i = 0 To GridView4.SelectedRow.Cells.Count - 2
            If i = 0 Then
                '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                If i <> 5 And i <> 6 And i <> 7 Then
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
                        cnt = cnt + 1
                        arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                    End If
                    If i = 7 Then
                        arr1(cnt) = drop.SelectedValue.ToString
                        cnt = cnt + 1
                        arr1(cnt) = drop.SelectedItem.Text
                        cnt = cnt + 1
                        arr1(cnt) = "-"
                        'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                    End If
                End If

                If i < GridView4.SelectedRow.Cells.Count - 2 Then
                    cnt = cnt + 1
                End If
                'End If
            Else

                If GridView4.SelectedRow.Cells(i).Visible = True Then
                    If i <> 5 And i <> 6 And i <> 7 Then
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
                            cnt = cnt + 1
                            arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)

                        End If
                        If i = 7 Then
                            arr1(cnt) = drop.SelectedValue.ToString
                            cnt = cnt + 1
                            arr1(cnt) = drop.SelectedItem.Text
                            cnt = cnt + 1
                            arr1(cnt) = "-"
                            'cnt = cnt + 1
                            'arr1(cnt) = Val(txt2.Text) * Val(txt1.Text)
                        End If
                    End If

                    If i < GridView4.SelectedRow.Cells.Count - 2 Then
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
        TextBox20.Text = ""
        GridView4.DataSource = Nothing
        GridView4.DataBind()
        TextBox18.Focus()

    End Sub

    Protected Sub GridView5_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(5).Text = genf.roundup(Val(e.Row.Cells(5).Text))
            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            total1 = total1 + Val(e.Row.Cells(7).Text)

            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(7).Text = total1
            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(6).Text = "Total"
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
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
        Else
            total1 = 0

            GridView5.DataSource = Nothing
            GridView5.DataBind()

            TextBox17.Text = ""
            TextBox18.Text = ""
            TextBox19.Text = ""
            TextBox20.Text = ""
        End If
        TextBox18.Focus()
    End Sub

    Protected Sub GridView5_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView5.SelectedIndexChanged
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""

        TextBox20.Text = GridView5.SelectedRow.Cells(2).Text

        If TextBox17.Text = "" And TextBox18.Text = "" And TextBox19.Text = "" And TextBox20.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Services...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox18.Focus()
        Else
            If Val(TextBox20.Text) = 0 Then
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge] FROM [service_master] where ( service_category like '%" & TextBox17.Text & "%' and service_name like '%" & TextBox18.Text & "%' and car_type like '%" & TextBox19.Text & "%')", GridView4)

            Else
                genf.populate_grid("SELECT [service_id] as [Service ID],[service_category] as [Service Category],[service_name] as [Service Type],[car_type] as [Service Vehicle Type],[service_charge] as [Unit Service Charge] FROM [service_master] where service_id='" & Val(TextBox20.Text) & "'", GridView4)

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
        If TextBox21.Text = "" And TextBox23.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox21.Focus()
        Else
            If Val(TextBox23.Text) = 0 Then
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where part_no like '%" & TextBox21.Text & "%'"
                genf.populate_grid(strnewrecord, GridView6)

            Else
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
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
    End Sub

    Protected Sub GridView6_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView6.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells(4).Text = genf.roundup(Val(e.Row.Cells(4).Text))
            'e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(0).Visible = False
            'e.Row.Cells(1).Visible = False
            'e.Row.Cells(4).Visible = False

            Dim txt1 As New Label
            txt1 = e.Row.FindControl("TextBox1")
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
                If i = GridView6.HeaderRow.Cells.Count - 3 Then
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
        arcnt = arcnt + 2
        Dim arr1(arcnt) As String

        If GridView7.Rows.Count > 0 Then
            For Each row As GridViewRow In GridView7.Rows
                If row.RowIndex <> GridView7.SelectedIndex Then
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
        Dim txt1, txt2 As New Label

        txt1 = GridView6.SelectedRow.FindControl("TextBox1")


        Dim cnt
        cnt = 0
        For i = 0 To GridView6.SelectedRow.Cells.Count - 2
            If i = 0 Then
                '  If GridView4.SelectedRow.Cells(i).Visible = True Then
                If i <> 4 Then
                    arr1(cnt) = GridView6.SelectedRow.Cells(i).Text
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
                        arr1(cnt) = GridView6.SelectedRow.Cells(i).Text
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

        GridView6.DataSource = Nothing
        GridView6.DataBind()
        TextBox21.Focus()

    End Sub

    Protected Sub GridView7_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView7.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).Text = Val(e.Row.Cells(6).Text) - Val(e.Row.Cells(7).Text)
            total1 = total1 + Val(e.Row.Cells(6).Text)
            total2 = total2 + Val(e.Row.Cells(7).Text)
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
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(4).Visible = False

            e.Row.Cells(5).Text = e.Row.Cells(4).Text & " - " & e.Row.Cells(5).Text
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(6).Text = total1
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(7).Text = total2
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(8).Text = total3
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Text = "Total"
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Visible = False
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(4).Visible = False

            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(4).Visible = False

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

        Else
            total1 = 0
            total2 = 0
            total3 = 0
            GridView7.DataSource = Nothing
            GridView7.DataBind()

            TextBox21.Text = ""
            TextBox23.Text = ""

        End If
        TextBox21.Focus()
    End Sub

    Protected Sub GridView7_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView7.SelectedIndexChanged
        TextBox21.Text = ""

        TextBox23.Text = GridView7.SelectedRow.Cells(2).Text

        If TextBox21.Text = "" And TextBox23.Text = "" Then
            Dim alertScript = "alert('Please Enter Search String For Parts...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
            TextBox21.Focus()
        Else
            If Val(TextBox23.Text) = 0 Then
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where part_no like '%" & TextBox21.Text & "%'"
                genf.populate_grid(strnewrecord, GridView6)

            Else
                strnewrecord = "select id as [Parts ID],part_no as [Parts No],[parts_name] as [Parts Name],[description] as [Description], [Unit] from [vehicle_parts] where id='" & Val(TextBox23.Text) & "'"
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
        Dim job_id
        If IsNothing(Request.QueryString("url")) Then
            strnewrecord = "INSERT INTO [new_job_cart]"
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
            strnewrecord = strnewrecord & ",[attached_sheet])"

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
            strnewrecord = strnewrecord & ",'" & CheckBox2.Checked.ToString & "'); select scope_identity()"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            job_id = Val(Mycommand.ExecuteScalar.ToString)

        Else
            job_id = Val(Request.QueryString("url").ToString)
            strnewrecord = "update [new_job_cart]"
            strnewrecord = strnewrecord & " set [customer_name]='" & TextBox1.Text & "'"
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
            strnewrecord = strnewrecord & ",[attached_sheet]='" & CheckBox2.Checked.ToString & "' where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from new_job_complain where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from new_job_technical_report where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from new_job_valuable where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from new_job_service where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()

            strnewrecord = "delete from new_job_parts where job_id='" & Val(job_id.ToString) & "'"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mycommand.ExecuteNonQuery()
        End If




        Dim i
        For i = 0 To GridView1.Rows.Count - 1
            Dim txt1 As New Label
            txt1 = GridView1.Rows(i).FindControl("TextBox1")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [new_job_complain]"
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
            Dim txt1 As New Label
            txt1 = GridView2.Rows(i).FindControl("TextBox15")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [new_job_technical_report]"
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
            Dim txt1 As New Label
            txt1 = GridView3.Rows(i).FindControl("TextBox16")
            If txt1.Text <> "" Then
                strnewrecord = "INSERT INTO [new_job_valuable]"
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

            strnewrecord = "INSERT INTO [new_job_service]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[service_id]"
            strnewrecord = strnewrecord & ",[unit_cost]"
            strnewrecord = strnewrecord & ",[qty]"
            strnewrecord = strnewrecord & ",[cost]"
            strnewrecord = strnewrecord & ",[technician_id])"

            strnewrecord = strnewrecord & " values "


            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"

            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(2).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(5).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(6).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(7).Text) & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView5.Rows(i).Cells(8).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()



        Next

        For i = 0 To GridView7.Rows.Count - 1

            strnewrecord = "INSERT INTO [new_job_parts]"
            strnewrecord = strnewrecord & "([job_id]"
            strnewrecord = strnewrecord & ",[part_id]"
            strnewrecord = strnewrecord & ",[part_no]"
            strnewrecord = strnewrecord & ",[qty])"

            strnewrecord = strnewrecord & " values "


            strnewrecord = strnewrecord & "('" & Val(job_id.ToString) & "'"

            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(2).Text) & "'"
            strnewrecord = strnewrecord & ",'" & GridView7.Rows(i).Cells(3).Text.Replace("'", "''") & "'"
            strnewrecord = strnewrecord & ",'" & Val(GridView7.Rows(i).Cells(6).Text) & "')"
            Mycommand = New SqlCommand(strnewrecord, Myconnection)

            Mycommand.ExecuteNonQuery()



        Next

        Myconnection.Close()
        Button1.Visible = True
        Page_Load(sender, e)
        If IsNothing(Request.QueryString("url")) Then
            Dim alertScript = "alert('Job Has Been Submited Succesfully With Job ID - " & job_id & " ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        Else
            Dim alertScript = "alert('Job With Job ID - " & job_id & " Has Been Modified Succesfully ...');"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)
        End If


    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsNothing(Request.QueryString("url")) Then
                Dim txt As New Label
                txt = e.Row.FindControl("TextBox1")
                strnewrecord = "SELECT [complain] fROM [new_job_complain] where job_id='" & Val(Request.QueryString("url").ToString) & "' and sl='" & Val(e.Row.Cells(0).Text) & "'"
                txt.Text = genf.returnvaluefromdv(strnewrecord, 0)

                If genf.checkexistancefromdv(strnewrecord) = False Then
                    e.Row.Visible = False
                End If

            End If

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then


            If Not IsNothing(Request.QueryString("url")) Then
                Dim txt As New Label
                txt = e.Row.FindControl("TextBox15")
                strnewrecord = "SELECT [technical_report] fROM [new_job_technical_report] where job_id='" & Val(Request.QueryString("url").ToString) & "' and sl='" & Val(e.Row.Cells(0).Text) & "'"
                txt.Text = genf.returnvaluefromdv(strnewrecord, 0)
                If genf.checkexistancefromdv(strnewrecord) = False Then
                    e.Row.Visible = False
                End If
            End If
        End If

    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub GridView3_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then


            If Not IsNothing(Request.QueryString("url")) Then
                Dim txt As New Label
                txt = e.Row.FindControl("TextBox16")
                strnewrecord = "SELECT [description] fROM [new_job_valuable] where job_id='" & Val(Request.QueryString("url").ToString) & "' and sl='" & Val(e.Row.Cells(0).Text) & "'"
                txt.Text = genf.returnvaluefromdv(strnewrecord, 0)
                If genf.checkexistancefromdv(strnewrecord) = False Then
                    e.Row.Visible = False
                End If
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
        strnewrecord = "delete from [new_job_cart] "
        strnewrecord = strnewrecord & " where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from new_job_complain where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from new_job_technical_report where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from new_job_valuable where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from new_job_service where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = "delete from new_job_parts where job_id='" & Val(job_id.ToString) & "'"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()




        Dim i


        Myconnection.Close()
        'Button1.Visible = True
        'Page_Load(sender, e)
        Dim alertScript = "alert('Job With Job ID - " & job_id & " Has Been Deleted Succesfully ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)


        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('job_card.aspx','_self');")
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
End Class

