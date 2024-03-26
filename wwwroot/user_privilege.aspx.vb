Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class user_privilege
    Inherits System.Web.UI.Page
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim Myconnection, Myconnection1 As SqlConnection
    Dim Mycommand, Mycommand1, Mycommand2, Mycommand10 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1, Mydataadapter2, Mydataadapter10 As SqlDataAdapter
    Dim dv, dv1, dv2, dv10 As New DataView
    Dim mydataset, mydataset1, mydataset2, mydataset10 As New DataSet
    Dim genf As New genfunction
    Dim uc
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Button7.Visible = True Then
            Button7.Visible = False
            TextBox15.Text = ""
           
            CheckBox3.Checked = True
            'If Val(Request.Cookies("branch_code").Value) = 1 Then
            '    genf.populate_dropdownlist("select branch_id, branch_name from branch order by branch_name", DropDownList1, "branch_name", "branch_id")
            '    CheckBox3.Visible = True
            'Else
            '    genf.populate_dropdownlist("select branch_id, branch_name from branch where branch_id='" & Val(Request.Cookies("branch_code").Value) & "' order by branch_name", DropDownList1, "branch_name", "branch_id")
            '    CheckBox3.Visible = False
            'End If
            getparent()
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Myconnection1 = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection1.Open()

        Dim whcls
        whcls = ""
        'If CheckBox3.Checked = False Then
        '    whcls = " and (case when (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc) is null then [Appointment Branch] else (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc ) end)='" & DropDownList1.SelectedValue.ToString & "'"

        'Else
        '    Dim i
        '    Dim whcls1
        '    whcls1 = ""
        '    For i = 0 To DropDownList1.Items.Count - 1
        '        If whcls1 = "" Then
        '            whcls1 = " ((case when (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc) is null then [Appointment Branch] else (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc ) end)='" & DropDownList1.Items(i).Value.ToString & "')"
        '        Else
        '            whcls1 = whcls1 & " or ((case when (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc) is null then [Appointment Branch] else (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc ) end)='" & DropDownList1.Items(i).Value.ToString & "')"

        '        End If
        '    Next
        '    If whcls1 <> "" Then
        '        whcls = " and (" & whcls1 & ")"
        '    End If

        'End If


        genf.populate_grid("SELECT [Employee ID] as [Employee ID],[Employee Name] as [Employee Name],[Father Name] as [Father's Name],[DOB] as [DOB],[Gender] as [Gender],[Blood Group] as [Blood Group],[Marital Status] as [Marital Status],[Contact No] as [TIN No],[Mobile No] as [Mobile No],[Mail ID] as [Mail ID],[Address] as [Address],(select b.branch_name from branch b where b.branch_id=(case when (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc) is null then [Appointment Branch] else (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc ) end)) as [Posting Branch],(select o.child_gp from organization_chart o where o.id=(case when (select top 1 et.department from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc) is null then employee.[department] else (select top 1 et.department from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc ) end)) as [Department],(select d.designation from designation d where d.designation_id= (case when (select top 1 et.designation from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc) is null then employee.[designation] else (select top 1 et.designation from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc ) end)) as [Designation],[Date of Appointment] as [Date of Appointment], (case when (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc) is null then [Appointment Branch] else (select top 1 et.transfer_branch from employee_transfer et where et.Employee_id=employee.[Employee ID] and datediff(day,Transfer_date,GETDATE())>=0 order by Transfer_date desc ) end) as [Appointment Branch], (case when (select top 1 et.designation from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc) is null then employee.[designation] else (select top 1 et.designation from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc ) end) as [Designation], (case when (select top 1 et.department from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc) is null then employee.[department] else (select top 1 et.department from employee_promotion et where et.Employee_id=employee.[Employee ID] and datediff(day,promotion_date,GETDATE())>=0 order by promotion_date desc ) end) as [Department], '' as [Documents], (case when status is null then 'Inactive' else 'Active' end) as [Status], [Internal Mailid] as [Internal Mail ID],(case when [User ID] is null then '-' else [User ID] end) as [User ID], (case when [Password] is null then '-' else [Password] end) as [Password] FROM [employee] where [Employee ID]='" & Val(TextBox15.Text) & "' and status is not null  and [Reson Code] is null " & whcls & " order by [Employee ID]", GridView1)
        Myconnection1.Close()
        TreeView1.Nodes.Clear()
        If GridView1.Rows.Count > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateGridHeader", "<Script>CreateGridHeader('DataDiv', 'ctl00_ContentPlaceHolder1_GridView1', 'HeaderDiv');</Script>")



        End If
        getparent()
    End Sub

    Function getparent()
        Dim mnu As New Menu
        mnu = Me.Master.FindControl("Menu1")


        Dim mnuitm As New MenuItem
        For Each mnuitm In mnu.Items
            Dim tn As New TreeNode
            tn.Text = mnuitm.Text
            '  Response.Write(mnuitm.Text & "<br>")
            tn.NavigateUrl = mnuitm.NavigateUrl
            tn.ExpandAll()
            TreeView1.Nodes.Add(tn)
            If mnuitm.ChildItems.Count > 0 Then
                getchild(tn, mnuitm)
            End If


        Next


        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim mnp As TreeNode
        For Each mnp In TreeView1.Nodes
            ' Response.Write(mnp.Text & "<br>")
            countmenu1(mnp)
        Next
        Myconnection.Close()

       


    End Function
    Function getchild(ByVal tn As TreeNode, ByVal mi As MenuItem)
        Dim mnuitm1 As New MenuItem
        For Each mnuitm1 In mi.ChildItems
            Dim tn1 As New TreeNode
            tn1.Text = mnuitm1.Text
            '    Response.Write(mnuitm1.Text & "<br>")
            tn1.NavigateUrl = mnuitm1.NavigateUrl
            tn1.ExpandAll()
            tn.ChildNodes.Add(tn1)
            If mnuitm1.ChildItems.Count > 0 Then
                getchild(tn1, mnuitm1)
            End If


        Next
    End Function
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(4).Text = genf.getdatefromdb(e.Row.Cells(4).Text).ToString("dd/MM/yyyy")
            e.Row.Cells(15).Text = genf.getdatefromdb(e.Row.Cells(15).Text).ToString("dd/MM/yyyy")

            Dim i
            For i = 2 To e.Row.Cells.Count - 1
                e.Row.Cells(i).Text = Server.HtmlDecode(e.Row.Cells(i).Text)
            Next

            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False

            ' e.Row.Cells(0).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

           

           
           
            '   e.Row.Cells(19).Text = "" & genf.create_table("SELECT [application_file_id] as [Document ID],'<a href=""attach_file.aspx?url=' + convert(nvarchar(50),[application_file_id]) + '"" style=""text-decoration:none;"" target=""_blank"" >Show</a>' as [Show],'<a href=""#"" onclick=delfile1(""' + convert(nvarchar(50),[application_file_id]) + '"",""" & TextBox17.ClientID & """) style=""text-decoration:none;"">Delete</a>' as [Delete] FROM [employee_file] where [employee_id]='" & e.Row.Cells(1).Text & "'")
            If e.Row.Cells(20).Text = "Inactive" Then
                e.Row.Cells(20).ForeColor = Drawing.Color.Red

            Else
                e.Row.Cells(20).ForeColor = Drawing.Color.Green


            End If
            '   Response.Write(e.Row.Cells(22).Text)
           


            '  e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False

            e.Row.Cells(15).Visible = False

            Dim dept
            dept = e.Row.Cells(18).Text

            For i = Val(dept.ToString) To 1 Step -1
                If i <> 1 And dept <> 1 Then
                    Mycommand2 = New SqlCommand("select (select c.child_gp from organization_chart c where c.id=organization_chart.parent_gp), (select c.id from organization_chart c where c.id=organization_chart.parent_gp) from organization_chart where [id]='" & Val(dept.ToString) & "'", Myconnection1)
                    ' Response.Write("select (select c.child_gp from organization_chart c where c.id=organization_chart.parent_gp), (select c.id from organization_chart c where c.id=organization_chart.parent_gp) from organization_chart where [id]='" & Val(dept.ToString) & "'<br>")
                    Mydataadapter2 = New SqlDataAdapter(Mycommand2)
                    Mydataadapter2.Fill(mydataset2, "sector_master")
                    dv2.Table = mydataset2.Tables(0)
                    If dv2.Count > 0 Then
                        If Val(dv2(0)(1).ToString) <> 1 Then
                            e.Row.Cells(13).Text = dv2(0)(0).ToString & "|" & e.Row.Cells(13).Text

                        End If
                        dept = dv2(0)(1).ToString
                    End If
                    dv2.Table.Clear()
                    mydataset2.Tables.Clear()
                End If

            Next
            Dim img As New Image
            img.ImageUrl = "showphoto.ashx?url=" & e.Row.Cells(1).Text
            '  Response.Redirect(img.ImageUrl)
            e.Row.Cells(0).Text = "<img src=""" & img.ImageUrl & """ width=""75px""/>"
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
        End If
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            '  e.Row.Cells(0).Visible = False

            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

            ' e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            '   e.Row.Cells(0).Visible = False
            e.Row.Cells(15).Visible = False
            e.Row.Cells(0).Text = "Photo"
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(16).Visible = False
            ''  e.Row.Cells(0).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            '  e.Row.Cells(0).Visible = False

            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

            '   e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False

            e.Row.Cells(15).Visible = False
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Public Function countmenu(ByVal mnu As TreeNode)
        Dim mnc As TreeNode
        For Each mnc In mnu.ChildNodes
            If mnc.ChildNodes.Count > 0 Then
                countmenu(mnc)
            Else
                If mnc.Checked = True Then
                    strnewrecord = "INSERT INTO op_user_level ([user],child, parent, nurl) VALUES ('" & GridView1.Rows(0).Cells(22).Text & "','" & mnc.Text & "','" & mnc.Parent.Text & "','" & mnc.NavigateUrl & "')"
                    mynewrecord = New SqlCommand(strnewrecord, Myconnection)
                    mynewrecord.ExecuteNonQuery()
                    If Not IsNothing(mnc.Parent) Then
                        countprnt(mnc.Parent)
                    End If
                End If
            End If
        Next
    End Function
    Public Function countprnt(ByVal mnu As TreeNode)
        If Not IsNothing(mnu.Parent) Then
            Mycommand = New SqlCommand("select * from op_user_level where [user]='" & GridView1.Rows(0).Cells(22).Text & "' and child='" & mnu.Text & "' and parent='" & mnu.Parent.Text & "'", Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count = 0 Then
                strnewrecord = "INSERT INTO op_user_level ([user],child, parent, nurl) VALUES ('" & GridView1.Rows(0).Cells(22).Text & "','" & mnu.Text & "','" & mnu.Parent.Text & "','" & mnu.NavigateUrl & "')"
                mynewrecord = New SqlCommand(strnewrecord, Myconnection)
                mynewrecord.ExecuteNonQuery()
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()
            countprnt(mnu.Parent)
        Else
            Mycommand = New SqlCommand("select * from op_user_level where [user]='" & GridView1.Rows(0).Cells(22).Text & "' and child='" & mnu.Text & "' and parent='" & mnu.Text & "'", Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "admin")
            dv.Table = mydataset.Tables(0)
            If dv.Count = 0 Then
                strnewrecord = "INSERT INTO op_user_level ([user],child, parent, nurl) VALUES ('" & GridView1.Rows(0).Cells(22).Text & "','" & mnu.Text & "','" & mnu.Text & "','" & mnu.NavigateUrl & "')"
                mynewrecord = New SqlCommand(strnewrecord, Myconnection)
                mynewrecord.ExecuteNonQuery()
            End If
            dv.Table.Clear()
            mydataset.Tables.Clear()
            Exit Function
        End If

    End Function
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()



        strnewrecord = "delete from operation_user_master where [uid]='" & GridView1.Rows(0).Cells(22).Text & "'"
        mynewrecord = New SqlCommand(strnewrecord, Myconnection)
        mynewrecord.ExecuteNonQuery()

        strnewrecord = "insert into operation_user_master ([uid],pwd,user_type) values ('" & GridView1.Rows(0).Cells(22).Text & "','" & GridView1.Rows(0).Cells(23).Text & "','Operator')"
        mynewrecord = New SqlCommand(strnewrecord, Myconnection)
        mynewrecord.ExecuteNonQuery()



        strnewrecord = "delete from op_user_level where [user]='" & GridView1.Rows(0).Cells(22).Text & "'"
        mynewrecord = New SqlCommand(strnewrecord, Myconnection)
        mynewrecord.ExecuteNonQuery()
        Dim mnp As TreeNode
        For Each mnp In TreeView1.Nodes
            countmenu(mnp)
        Next




        Dim mnp1 As TreeNode
        For Each mnp1 In TreeView1.Nodes
            ' Response.Write(mnp.Text & "<br>")
            countmenu1(mnp1)
        Next
        Myconnection.Close()

        Button6_Click(sender, e)
    End Sub

    Public Function countmenu1(ByVal mnu As TreeNode)

        Dim mnc As TreeNode
        For Each mnc In mnu.ChildNodes
            'Response.Write(mnc.Text & "-" & mnc.Selected & "<br>")
            If mnc.ChildNodes.Count > 0 Then
                countmenu1(mnc)
            Else

                If GridView1.Rows.Count > 0 Then
                    Mycommand = New SqlCommand("select * from op_user_level where [user]='" & GridView1.Rows(0).Cells(22).Text & "' and child='" & mnc.Text & "' and parent='" & mnc.Parent.Text & "'", Myconnection)
                    Mydataadapter = New SqlDataAdapter(Mycommand)
                    Mydataadapter.Fill(mydataset, "admin")
                    dv.Table = mydataset.Tables(0)
                    If dv.Count > 0 Then
                        mnc.Checked = True
                    Else
                        mnc.Checked = False
                    End If
                    dv.Table.Clear()
                    mydataset.Tables.Clear()
                End If


            End If


        Next

    End Function
End Class
