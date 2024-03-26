Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class service_management
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
        If Button4.Visible = True Then
            Button4.Visible = False
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            Panel1.Visible = False
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        total1 = 0
        strnewrecord = "select service_tx as [Tx No],new_job_service.job_id as [Job ID],new_job_cart.manual_ro AS [Manual RO], new_job_service.service_id as [Service ID], service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service], new_job_service.cost as [Total Value],new_job_service.technician_id as [Technician ID], technician_master.technician_name as [Technician Name], (case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks]  from new_job_service, service_master, technician_master, new_job_cart where new_job_service.job_id=new_job_cart.job_id and new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and new_job_service.job_id='" & Val(TextBox1.Text) & "'"
        genf.populate_grid(strnewrecord, GridView1)


        strnewrecord = "select tx_id as [Tx No],new_job_dent_paint.job_id as [Job ID],new_job_cart.manual_ro AS [Manual RO], new_job_dent_paint.description as [Description], new_job_dent_paint.qty as [Qty of Service], new_job_dent_paint.price as [Service Charge], (case when new_job_dent_paint.service_status is null then '-' else new_job_dent_paint.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks]  from new_job_dent_paint, new_job_cart where new_job_dent_paint.job_id=new_job_cart.job_id and new_job_dent_paint.job_id='" & Val(TextBox1.Text) & "' and description<>'Dent and Paint'"
        genf.populate_grid(strnewrecord, GridView2)


        TextBox4.Text = "1"

        If GridView1.Rows.Count > 0 Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        total1 = 0
        strnewrecord = "select service_tx as [Tx No],new_job_service.job_id as [Job ID],new_job_cart.manual_ro AS [Manual RO], new_job_service.service_id as [Service ID], service_master.service_name as [Service Type], service_master.car_type as [Vehicle Type], new_job_service.unit_cost as [Service Charge], new_job_service.qty as [Qty of Service], new_job_service.cost as [Total Value],new_job_service.technician_id as [Technician ID], technician_master.technician_name as [Technician Name], (case when new_job_service.service_status is null then '-' else new_job_service.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks]  from new_job_service, service_master, technician_master, new_job_cart where new_job_service.job_id=new_job_cart.job_id and new_job_service.technician_id=technician_master.technician_id and new_job_service.service_id=service_master.service_id and new_job_cart.manual_ro='" & Trim(TextBox2.Text) & "'"
        genf.populate_grid(strnewrecord, GridView1)

        strnewrecord = "select tx_id as [Tx No],new_job_dent_paint.job_id as [Job ID],new_job_cart.manual_ro AS [Manual RO], new_job_dent_paint.description as [Description], new_job_dent_paint.qty as [Qty of Service], new_job_dent_paint.price as [Service Charge], (case when new_job_dent_paint.service_status is null then '-' else new_job_dent_paint.service_status end) as [Service Status], start_date as [Starting Date], end_date as [Ending Date],service_rem as [Remarks]  from new_job_dent_paint, new_job_cart where new_job_dent_paint.job_id=new_job_cart.job_id and new_job_cart.manual_ro='" & Trim(TextBox2.Text) & "' and description<>'Dent and Paint'"
        genf.populate_grid(strnewrecord, GridView2)


        TextBox4.Text = "2"
        If GridView1.Rows.Count > 0 Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(7).Text = genf.roundup(Val(e.Row.Cells(7).Text))
            e.Row.Cells(9).Text = genf.roundup(Val(e.Row.Cells(9).Text))
            total1 = total1 + Val(e.Row.Cells(9).Text)
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Text = total1
            e.Row.Cells(9).Text = genf.roundup(Val(e.Row.Cells(9).Text))
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).Text = "Total"
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        Dim i
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        For i = 0 To GridView1.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView1.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_service set service_status='Job Started', service_rem=NULL, start_date='" & DateTime.Now & "', end_date=NULL where service_tx='" & Val(GridView1.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next

        For i = 0 To GridView2.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView2.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_dent_paint set service_status='Job Started', service_rem=NULL, start_date='" & DateTime.Now & "', end_date=NULL where tx_id='" & Val(GridView2.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next
        Myconnection.Close()


        If TextBox4.Text = "1" Then
            Button2_Click(sender, e)
        End If
        If TextBox4.Text = "2" Then
            Button3_Click(sender, e)
        End If
        Button9_Click(sender, e)
    End Sub

    Protected Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click
        Dim i
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        For i = 0 To GridView1.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView1.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_service set service_status='Job Completed', service_rem='Job Completed', end_date='" & DateTime.Now & "' where service_tx='" & Val(GridView1.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next

        For i = 0 To GridView2.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView2.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_dent_paint set service_status='Job Completed', service_rem='Job Completed', end_date='" & DateTime.Now & "' where tx_id='" & Val(GridView2.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next
        Myconnection.Close()


        If TextBox4.Text = "1" Then
            Button2_Click(sender, e)
        End If
        If TextBox4.Text = "2" Then
            Button3_Click(sender, e)
        End If
        Button9_Click(sender, e)
    End Sub

    Protected Sub Button7_Click(sender As Object, e As System.EventArgs) Handles Button7.Click
        Dim i
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        For i = 0 To GridView1.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView1.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_service set service_status='Technical Issue', service_rem='" & TextBox3.Text & "',  end_date=NULL where service_tx='" & Val(GridView1.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next


        For i = 0 To GridView2.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView2.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_dent_paint set service_status='Technical Issue', service_rem='" & TextBox3.Text & "',  end_date=NULL where service_tx='" & Val(GridView2.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next

        Myconnection.Close()


        If TextBox4.Text = "1" Then
            Button2_Click(sender, e)
        End If
        If TextBox4.Text = "2" Then
            Button3_Click(sender, e)
        End If
        Button9_Click(sender, e)
    End Sub

    Protected Sub Button8_Click(sender As Object, e As System.EventArgs) Handles Button8.Click
        Dim i
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        For i = 0 To GridView1.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView1.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_service set service_status=NULL, service_rem=NULL, start_date=NULL, end_date=NULL where service_tx='" & Val(GridView1.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next

        For i = 0 To GridView2.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView2.Rows(i).FindControl("CheckBox1")
            If chk.Checked = True Then
                strnewrecord = "update new_job_dent_paint set service_status=NULL, service_rem=NULL, start_date=NULL, end_date=NULL where tx_id='" & Val(GridView2.Rows(i).Cells(1).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next

        Myconnection.Close()


        If TextBox4.Text = "1" Then
            Button2_Click(sender, e)
        End If
        If TextBox4.Text = "2" Then
            Button3_Click(sender, e)
        End If
        Button9_Click(sender, e)
    End Sub

    Protected Sub Button9_Click(sender As Object, e As System.EventArgs) Handles Button9.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim i
        Dim status_count, job_completed, service_count
        status_count = 0
        job_completed = 0
        service_count = 0
        For i = 0 To GridView1.Rows.Count - 1
            service_count = service_count + 1
            If GridView1.Rows(i).Cells(12).Text = "-" Then
                status_count = status_count + 1
            End If
            If GridView1.Rows(i).Cells(12).Text = "Job Completed" Then
                job_completed = job_completed + 1
            End If
        Next

        For i = 0 To GridView2.Rows.Count - 1
            service_count = service_count + 1
            If GridView2.Rows(i).Cells(7).Text = "-" Then
                status_count = status_count + 1
            End If
            If GridView2.Rows(i).Cells(7).Text = "Job Completed" Then
                job_completed = job_completed + 1
            End If
        Next


        ' Response.Write(status_count)
        If GridView1.Rows.Count > 0 Then
            If status_count = service_count Then
                strnewrecord = "update new_job_cart set status=NULL where job_id='" & Val(GridView1.Rows(0).Cells(2).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            Else
                If job_completed = service_count Then
                    strnewrecord = "update new_job_cart set status='Job Completed' where job_id='" & Val(GridView1.Rows(0).Cells(2).Text) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                Else
                    strnewrecord = "update new_job_cart set status='Going On' where job_id='" & Val(GridView1.Rows(0).Cells(2).Text) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                End If
            End If
        End If
       
        If GridView2.Rows.Count > 0 Then
            If status_count = service_count Then
                strnewrecord = "update new_job_cart set status=NULL where job_id='" & Val(GridView2.Rows(0).Cells(2).Text) & "'"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            Else
                If job_completed = service_count Then
                    strnewrecord = "update new_job_cart set status='Job Completed' where job_id='" & Val(GridView2.Rows(0).Cells(2).Text) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                Else
                    strnewrecord = "update new_job_cart set status='Going On' where job_id='" & Val(GridView2.Rows(0).Cells(2).Text) & "'"
                    Mycommand = New SqlCommand(strnewrecord, Myconnection)
                    Mycommand.ExecuteNonQuery()
                End If
            End If
        End If

        Myconnection.Close()
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim i
        For i = 0 To GridView1.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView1.Rows(i).FindControl("CheckBox1")
            If CheckBox2.Checked = True Then
                chk.Checked = True
            Else
                chk.Checked = False
            End If
        Next
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Dim i
        For i = 0 To GridView2.Rows.Count - 1
            Dim chk As New CheckBox
            chk = GridView2.Rows(i).FindControl("CheckBox1")
            If CheckBox3.Checked = True Then
                chk.Checked = True
            Else
                chk.Checked = False
            End If
        Next
    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub
End Class
