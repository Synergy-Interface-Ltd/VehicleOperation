Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim Myconnection As SqlConnection
    Dim Mycommand, Mycommand1, Mycommand2, Mycommand10 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1, Mydataadapter2, Mydataadapter10 As SqlDataAdapter
    Dim dv, dv1, dv2, dv10 As New DataView
    Dim mydataset, mydataset1, mydataset2, mydataset10 As New DataSet
    Dim modi, modiamt, oldamt, rcount
    Dim genf As New genfunction
    Dim total12, total13, total14, total11, total10, total9, total8, total7, total6, total5
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If IsNothing(Session("uid")) Then
            If Label2.Text <> "" Then
                Session("uid") = Label2.Text
            End If

        End If


        If Button1.Visible = True Then
            Button1.Visible = False
            If Not IsNothing(Session("uid")) Then
                Label2.Text = Session("uid").ToString

                Dim genf As New genfunction

                Dim admin_type = genf.returnvaluefromdv("select user_type from operation_user_master where uid='" & Session("uid") & "'", 0)
                'Response.Write(Trim(admin_type.ToString.ToUpper))

                If Trim(admin_type.ToString.ToUpper) = "ADMIN" Then
                    Menu1.Visible = True
                    Menu2.Visible = False
                Else
                    Menu1.Visible = False
                    Menu2.Visible = True
                    Load_tree()
                End If
            Else
                Response.Redirect("login.aspx")
            End If
        End If
        Dim aa = "select count(*) from estimate_order_placement where reference_by='" & Label2.Text & "' and app_delivery_date!='' and app_delivery_date<=GETDATE() and((DATEDIFF(DAY,store_order_date,app_delivery_date)/2)=DATEDIFF(DAY,GETDATE(),app_delivery_date) or (DATEDIFF(DAY,store_order_date,app_delivery_date)/4)=DATEDIFF(DAY,GETDATE(),app_delivery_date) or (DATEDIFF(DAY,store_order_date,app_delivery_date))=DATEDIFF(DAY,GETDATE(),app_delivery_date))"
        Dim numberOfNotification = genf.returnvaluefromdv(aa, 0)
        numberNotify.Text = numberOfNotification
    End Sub
    Protected Function PDataset(ByVal select_statement As String) As DataSet
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Mydataadapter = New SqlDataAdapter(select_statement, Myconnection)
        Dim mydatasetmenu As New DataSet
        Mydataadapter.Fill(mydatasetmenu)
        Myconnection.Close()
        Return mydatasetmenu
    End Function
    Protected Sub ImageButton3_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("engineer_order.aspx?url=0")
    End Sub

    Public Function Load_tree()
        '  Response.Write("ppp")
        Dim PrSet As New DataSet
        PrSet = PDataset("select distinct parent, nurl from op_user_level where [user]='" & Label2.Text & "' and child=parent order by parent asc")

        'menu1.Nodes.Clear()
        Dim dr As DataRow
        For Each dr In PrSet.Tables(0).Rows



            Dim mnParent As New MenuItem
            mnParent.Text = dr("parent").ToString()

            Dim mnvalue As String
            mnvalue = dr("parent").ToString()
            'tnParent.Collapse()
            mnParent.Value = mnvalue
            mnParent.NavigateUrl = dr("nurl").ToString()
            ' mnParent.ImageUrl = "~/images/arrow2.png"

            Dim i
            For i = 0 To Menu1.Items.Count - 1
                If Menu1.Items(i).Value = mnParent.Value Then
                    mnParent.ImageUrl = Menu1.Items(i).ImageUrl
                End If
            Next

            Menu2.Items.Add(mnParent)
            mnFillChild(mnParent, mnvalue)


            'FillChild(tnParent, value)



        Next


    End Function
    Public Function mnFillChild(ByVal parent As MenuItem, ByVal IID As String) As Integer
        Dim ds As New DataSet
        ds = PDataset("select distinct child, [nurl] from op_user_level where parent='" & IID & "'  and [user]='" & Label2.Text & "' and child<>parent order by child asc")


        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow

            For Each dr In ds.Tables(0).Rows
                Dim CHILD As New MenuItem
                CHILD.Text = " " & dr("child").ToString().Trim()
                Dim mnvalue As String
                mnvalue = dr("child").ToString().Trim()
                CHILD.Value = mnvalue
                CHILD.NavigateUrl = dr("nurl").ToString().Trim()
                '  CHILD.ImageUrl = "~/images/arrow2.png"
                ' Response.Write(mnvalue)
                mnFillChild(CHILD, mnvalue)
                'CHILD.Collapse()
                parent.ChildItems.Add(CHILD)


            Next

            Return 0
        Else
            Return 0
        End If

    End Function
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("change_pwd.aspx")
    End Sub
End Class

