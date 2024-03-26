Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.IdentityModel.Protocols.WSTrust
Imports System.Runtime.Remoting
Imports CrystalDecisions.CrystalReports.Engine

Partial Class engineer_order
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
            Button1.Visible = False

            Dim str = " (SELECT ((case when (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no ) is null then '0' else"
            str &= " (SELECT sum(op.opening_qty) from vehicle_parts op where op.part_no=e.parts_no) end) + (case when (SELECT sum(pu.qty) from purchase_item pu "
            str &= " where pu.part_no=e.parts_no) is null then '0' else (SELECT sum(pu.qty) from purchase_item pu where pu.part_no=e.parts_no) end) "
            str &= " - (case when (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no) Is null then '0' else "
            str &= " (SELECT sum(issue.qty) from job_wise_item_issue issue where issue.part_no=e.parts_no ) end))) as [Available Quantity] "


            strnewrecord = "select e.parts_id as ""Parts ID"",e.parts_no as ""Parts No"",(select  top(1) parts_name from vehicle_parts where"
            strnewrecord &= " part_no=e.parts_no) as ""Parts Name"",e.order_request_qty as ""Requisit Quantity"","
            strnewrecord &= " (select top(1) unit from vehicle_parts where part_no=e.parts_no) as ""Unit"","
            strnewrecord &= " (select   unit_cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Price"","
            strnewrecord &= " (select cost from estimate_new_job_service where service_id=e.service_id and job_id=e.estimate_job_id ) as ""Total"","
            strnewrecord &= " (select Name from  orderstatus where id=e.order_status ) as Status,e.order_date as ""Order Date"","
            strnewrecord &= " e.app_delivery_date as ""App delivary date"", "
            strnewrecord &= " " & str & ","

            strnewrecord &= " (case when order_quantity is null then 0 else order_quantity end ) as OrderLimit, service_id from estimate_order_placement e where reference_by='" & Session("uid") & "' and e.parts_id!=0 order by ""Order Date"""
            genf.populate_grid(strnewrecord, GridView1)

            UpdatePanel122.Update()

        End If


        If Not IsNothing(Session("uid")) Then

            Dim genf As New genfunction

            Dim admin_type = genf.returnvaluefromdv("Select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)

        Else
            Response.Redirect("login.aspx")
        End If
    End Sub





End Class

