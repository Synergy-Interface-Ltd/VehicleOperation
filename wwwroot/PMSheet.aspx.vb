Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.Runtime.Remoting
Imports System.CodeDom.Compiler
Imports System.Collections.ObjectModel
Imports System.Drawing

Partial Class PMSheet
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
    Dim total1
    Dim IDOFPmShhet As Integer
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Button6.Visible = True Then
            Button6.Visible = False
            Button11.Visible = False
        End If
    End Sub

    Protected Sub Button13_Click(sender As Object, e As System.EventArgs) Handles Button13.Click

        Dim PMSheetId = genf.returnvaluefromdv("Select PMID from [vs].[dbo].[PMSheet] where regis_No='" & RegNo.Text & "' and Entry_Date='" & genf.getdate(EnterDate.Text).ToString("yyyy/MM/dd") & "' ", 0)



        Dim rsb1 As StringBuilder
        rsb1 = New StringBuilder()
        rsb1.Append("<script language=""JavaScript"">")
        rsb1.Append("window.open('print_pmsheet.aspx?id=" & PMSheetId & "','print_estimate');")
        rsb1.Append("</scri")
        rsb1.Append("pt>")
        Page.RegisterStartupScript("rtest1", rsb1.ToString())
    End Sub

    Protected Sub Button100_Click(sender As Object, e As System.EventArgs) Handles Button100.Click
        Button11.Visible = True
        Button10.Visible = False
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        IDOFPmShhet = Val(PMSheetID.Text)

        Dim Command As New SqlCommand("select PMDataId FROM [vs].[dbo].[PmSheet_Data] where PMSheetId='" & PMSheetID.Text & "'", Myconnection)
        Dim reader As SqlDataReader = Command.ExecuteReader()
        Dim dt As New DataTable()
        dt.Load(reader)
        Dim Lt As List(Of Integer) = New List(Of Integer)()
        Dim i
        For i = 0 To dt.Rows.Count - 1
            Lt.Add(dt.Rows(i)(0))
        Next
        Dim allTxt As New List(Of Control)
        For Each checkBox As CheckBox In FindControlRecursive(allTxt, Me, GetType(CheckBox))
            If Lt.Contains(Val(checkBox.TabIndex)) Then
                checkBox.Checked = True
            End If
        Next
        dt.Clear()
        Dim Command1 As New SqlCommand("SELECT [SA_Id] ,[Tech_Id],[regis_No] ,Format([Entry_Date],'dd/MM/yyyy') FROM [vs].[dbo].[PMSheet] where PMID='" & PMSheetID.Text & "'", Myconnection)
        Dim reader1 As SqlDataReader = Command1.ExecuteReader()
        Dim dt1 As New DataTable()
        dt1.Load(reader1)
        If dt1.Rows.Count > 0 Then
            SAName.Text = dt1.Rows(0)(0)
            TechName.Text = dt1.Rows(0)(1)
            EnterDate.Text = dt1.Rows(0)(3)
            RegNo.Text = dt1.Rows(0)(2)
        End If

        dt1.Clear()

        Dim Command2 As New SqlCommand("SELECT [TechA],[TechB] FROM [vs].[dbo].[PMSheetSummary]where PMSheetId='" & PMSheetID.Text & "'", Myconnection)
        Dim reader2 As SqlDataReader = Command2.ExecuteReader()
        Dim dt2 As New DataTable()
        dt2.Load(reader2)
        If dt2.Rows.Count > 0 Then
            TechA.Text = dt2.Rows(0)(0)
            TechB.Text = dt2.Rows(0)(1)
        End If

        dt2.Clear()

        Dim Command3 As New SqlCommand("SELECT [ATireRight],[ATireLeft],[ABrakePadRight],[ABrakPadLeft],[BTireRight],[BTireLeft],[BBrakePadRight],[BBrakPadLeft],[PMSheetId]FROM [vs].[dbo].[PMSheetTextInfo] where PMSheetId='" & PMSheetID.Text & "'", Myconnection)
        Dim reader3 As SqlDataReader = Command3.ExecuteReader()
        Dim dt3 As New DataTable()
        dt3.Load(reader3)
        If dt3.Rows.Count > 0 Then
            ATireRight.Text = dt3.Rows(0)(0)
            ATireLeft.Text = dt3.Rows(0)(1)
            ABrakePadRight.Text = dt3.Rows(0)(2)
            ABrakPadLeft.Text = dt3.Rows(0)(3)
            BTireRight.Text = dt3.Rows(0)(4)
            BTireLeft.Text = dt3.Rows(0)(5)
            BBrakePadRight.Text = dt3.Rows(0)(6)
            BBrakPadLeft.Text = dt3.Rows(0)(7)
        End If
        dt3.Clear()

        Dim Command4 As New SqlCommand("SELECT FirstAT ,FirstD ,SecAT ,SecD ,ThirdAT ,ThirdD ,FourAT ,FourD ,FifthAT ,FifthD ,FinalAT ,FinalD FROM [vs].[dbo].[PMSheet_Table] where PMSheetId='" & PMSheetID.Text & "'", Myconnection)
        Dim reader4 As SqlDataReader = Command4.ExecuteReader()
        Dim dt4 As New DataTable()
        dt4.Load(reader4)
        If dt4.Rows.Count > 0 Then
            FirstAT.Text = dt4.Rows(0)(0)
            FirstD.Text = dt4.Rows(0)(1)
            SecAT.Text = dt4.Rows(0)(2)
            SecD.Text = dt4.Rows(0)(3)
            ThirdAT.Text = dt4.Rows(0)(4)
            ThirdD.Text = dt4.Rows(0)(5)
            FourAT.Text = dt4.Rows(0)(6)
            FourD.Text = dt4.Rows(0)(7)
            FifthAT.Text = dt4.Rows(0)(8)
            FifthD.Text = dt4.Rows(0)(9)
            FinalAT.Text = dt4.Rows(0)(10)
            FinalD.Text = dt4.Rows(0)(11)
        End If
        dt4.Clear()
    End Sub

    Protected Sub Button101_Click(sender As Object, e As System.EventArgs) Handles Button101.Click
        Button11.Visible = True
        Button10.Visible = False
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim PMSheetId = genf.returnvaluefromdv("Select PMID from [vs].[dbo].[PMSheet] where regis_No='" & TextBox1.Text & "' and Entry_Date='" & genf.getdate(TextBox2.Text).ToString("yyyy/MM/dd") & "' ", 0)
        IDOFPmShhet = Val(PMSheetId)
        Dim Command As New SqlCommand("select PMDataId FROM [vs].[dbo].[PmSheet_Data] where PMSheetId='" & PMSheetId & "'  ", Myconnection)
        Dim reader As SqlDataReader = Command.ExecuteReader()
        Dim dt As New DataTable()
        dt.Load(reader)
        Dim Lt As List(Of Integer) = New List(Of Integer)()
        Dim i
        For i = 0 To dt.Rows.Count - 1
            Lt.Add(dt.Rows(i)(0))
        Next
        Dim allTxt As New List(Of Control)
        For Each checkBox As CheckBox In FindControlRecursive(allTxt, Me, GetType(CheckBox))
            If Lt.Contains(Val(checkBox.TabIndex)) Then
                checkBox.Checked = True
            End If
        Next
        dt.Clear()
        Dim Command1 As New SqlCommand("SELECT [SA_Id] ,[Tech_Id],[regis_No] ,Format([Entry_Date],'dd/MM/yyyy') FROM [vs].[dbo].[PMSheet] where PMID='" & PMSheetId & "'", Myconnection)
        Dim reader1 As SqlDataReader = Command1.ExecuteReader()
        Dim dt1 As New DataTable()
        dt1.Load(reader1)
        If dt1.Rows.Count > 0 Then
            SAName.Text = dt1.Rows(0)(0)
            TechName.Text = dt1.Rows(0)(1)
            EnterDate.Text = dt1.Rows(0)(3)
            RegNo.Text = dt1.Rows(0)(2)
        End If

        dt1.Clear()

        Dim Command2 As New SqlCommand("SELECT [TechA],[TechB] FROM [vs].[dbo].[PMSheetSummary]where PMSheetId='" & PMSheetId & "'", Myconnection)
        Dim reader2 As SqlDataReader = Command2.ExecuteReader()
        Dim dt2 As New DataTable()
        dt2.Load(reader2)
        If dt2.Rows.Count > 0 Then
            TechA.Text = dt2.Rows(0)(0)
            TechB.Text = dt2.Rows(0)(1)
        End If

        dt2.Clear()

        Dim Command3 As New SqlCommand("SELECT [ATireRight],[ATireLeft],[ABrakePadRight],[ABrakPadLeft],[BTireRight],[BTireLeft],[BBrakePadRight],[BBrakPadLeft],[PMSheetId]FROM [vs].[dbo].[PMSheetTextInfo] where PMSheetId='" & PMSheetId & "'", Myconnection)
        Dim reader3 As SqlDataReader = Command3.ExecuteReader()
        Dim dt3 As New DataTable()
        dt3.Load(reader3)
        If dt3.Rows.Count > 0 Then
            ATireRight.Text = dt3.Rows(0)(0)
            ATireLeft.Text = dt3.Rows(0)(1)
            ABrakePadRight.Text = dt3.Rows(0)(2)
            ABrakPadLeft.Text = dt3.Rows(0)(3)
            BTireRight.Text = dt3.Rows(0)(4)
            BTireLeft.Text = dt3.Rows(0)(5)
            BBrakePadRight.Text = dt3.Rows(0)(6)
            BBrakPadLeft.Text = dt3.Rows(0)(7)
        End If
        dt3.Clear()

        Dim Command4 As New SqlCommand("SELECT FirstAT ,FirstD ,SecAT ,SecD ,ThirdAT ,ThirdD ,FourAT ,FourD ,FifthAT ,FifthD ,FinalAT ,FinalD FROM [vs].[dbo].[PMSheet_Table] where PMSheetId='" & PMSheetId & "'", Myconnection)
        Dim reader4 As SqlDataReader = Command4.ExecuteReader()
        Dim dt4 As New DataTable()
        dt4.Load(reader4)
        If dt4.Rows.Count > 0 Then
            FirstAT.Text = dt4.Rows(0)(0)
            FirstD.Text = dt4.Rows(0)(1)
            SecAT.Text = dt4.Rows(0)(2)
            SecD.Text = dt4.Rows(0)(3)
            ThirdAT.Text = dt4.Rows(0)(4)
            ThirdD.Text = dt4.Rows(0)(5)
            FourAT.Text = dt4.Rows(0)(6)
            FourD.Text = dt4.Rows(0)(7)
            FifthAT.Text = dt4.Rows(0)(8)
            FifthD.Text = dt4.Rows(0)(9)
            FinalAT.Text = dt4.Rows(0)(10)
            FinalD.Text = dt4.Rows(0)(11)
        End If
        dt4.Clear()
    End Sub
    Protected Sub Button10_Click(sender As Object, e As System.EventArgs) Handles Button10.Click

        If SAName.Text <> "" And TechName.Text <> "" And EnterDate.Text <> "" And RegNo.Text <> "" Then

            If Check1.Checked = False And Check201.Checked = False Then
                Check1.BackColor = System.Drawing.Color.Red
                Check201.BackColor = System.Drawing.Color.Red
                Return
            Else
                Check1.BackColor = System.Drawing.Color.White
                Check201.BackColor = System.Drawing.Color.White
            End If

            If Check2.Checked = False And Check202.Checked = False And Check3.Checked = False Then
                Check2.BackColor = System.Drawing.Color.Red
                Check202.BackColor = System.Drawing.Color.Red
                Check3.BackColor = System.Drawing.Color.Red
                Return
            Else
                Check2.BackColor = System.Drawing.Color.White
                Check202.BackColor = System.Drawing.Color.White
                Check3.BackColor = System.Drawing.Color.White
            End If

            If Check4.Checked = False And Check203.Checked = False Then
                Check4.BackColor = System.Drawing.Color.Red
                Check203.BackColor = System.Drawing.Color.Red
                Return
            Else
                Check4.BackColor = System.Drawing.Color.White
                Check203.BackColor = System.Drawing.Color.White
            End If
            If ESO1.Checked = False And ESO2.Checked = False And ESO3.Checked = False And ESO4.Checked = False And ESO5.Checked = False Then
                ESO1.BackColor = System.Drawing.Color.Red
                ESO2.BackColor = System.Drawing.Color.Red
                ESO3.BackColor = System.Drawing.Color.Red
                ESO4.BackColor = System.Drawing.Color.Red
                ESO5.BackColor = System.Drawing.Color.Red
                Return
            Else
                ESO1.BackColor = System.Drawing.Color.White
                ESO2.BackColor = System.Drawing.Color.White
                ESO3.BackColor = System.Drawing.Color.White
                ESO4.BackColor = System.Drawing.Color.White
                ESO5.BackColor = System.Drawing.Color.White
            End If
            If Brake1.Checked = False And Brake2.Checked = False Then
                Brake1.BackColor = System.Drawing.Color.Red
                Brake2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Brake1.BackColor = System.Drawing.Color.White
                Brake2.BackColor = System.Drawing.Color.White
            End If
            If Steering1.Checked = False And Steering2.Checked = False Then
                Steering1.BackColor = System.Drawing.Color.Red
                Steering2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Steering1.BackColor = System.Drawing.Color.White
                Steering2.BackColor = System.Drawing.Color.White
            End If
            If Parking1.Checked = False And Parking2.Checked = False Then
                Parking1.BackColor = System.Drawing.Color.Red
                Parking2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Parking1.BackColor = System.Drawing.Color.White
                Parking2.BackColor = System.Drawing.Color.White
            End If
            If BreakPadel1.Checked = False And BreakPadel2.Checked = False And BreakPadel3.Checked = False Then
                BreakPadel1.BackColor = System.Drawing.Color.Red
                BreakPadel2.BackColor = System.Drawing.Color.Red
                BreakPadel3.BackColor = System.Drawing.Color.Red
                Return
            Else
                BreakPadel1.BackColor = System.Drawing.Color.White
                BreakPadel2.BackColor = System.Drawing.Color.White
                BreakPadel3.BackColor = System.Drawing.Color.White
            End If
            If ClutchPedal1.Checked = False And ClutchPedal2.Checked = False And ClutchPedal3.Checked = False Then
                ClutchPedal1.BackColor = System.Drawing.Color.Red
                ClutchPedal2.BackColor = System.Drawing.Color.Red
                ClutchPedal3.BackColor = System.Drawing.Color.Red
                Return
            Else
                ClutchPedal1.BackColor = System.Drawing.Color.White
                ClutchPedal2.BackColor = System.Drawing.Color.White
                ClutchPedal3.BackColor = System.Drawing.Color.White
            End If
            If TireAirPressure1.Checked = False And TireAirPressure2.Checked = False And TireAirPressure3.Checked = False Then
                TireAirPressure1.BackColor = System.Drawing.Color.Red
                TireAirPressure2.BackColor = System.Drawing.Color.Red
                TireAirPressure3.BackColor = System.Drawing.Color.Red
                Return
            Else
                TireAirPressure1.BackColor = System.Drawing.Color.White
                TireAirPressure2.BackColor = System.Drawing.Color.White
                TireAirPressure3.BackColor = System.Drawing.Color.White
            End If
            If Lift1.Checked = False And Lift2.Checked = False And Lift3.Checked = False And Lift4.Checked = False And Lift5.Checked = False Then
                Lift1.BackColor = System.Drawing.Color.Red
                Lift2.BackColor = System.Drawing.Color.Red
                Lift3.BackColor = System.Drawing.Color.Red
                Lift4.BackColor = System.Drawing.Color.Red
                Lift5.BackColor = System.Drawing.Color.Red
                Return
            Else
                Lift1.BackColor = System.Drawing.Color.White
                Lift2.BackColor = System.Drawing.Color.White
                Lift3.BackColor = System.Drawing.Color.White
                Lift4.BackColor = System.Drawing.Color.White
                Lift5.BackColor = System.Drawing.Color.White
            End If
            If Stablizer1.Checked = False And Stablizer2.Checked = False Then
                Stablizer1.BackColor = System.Drawing.Color.Red
                Stablizer2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Stablizer1.BackColor = System.Drawing.Color.White
                Stablizer2.BackColor = System.Drawing.Color.White
            End If
            If Suspension1.Checked = False And Suspension2.Checked = False Then
                Suspension1.BackColor = System.Drawing.Color.Red
                Suspension2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Suspension1.BackColor = System.Drawing.Color.White
                Suspension2.BackColor = System.Drawing.Color.White
            End If
            If DriveShaft1.Checked = False And DriveShaft2.Checked = False And DriveShaft3.Checked = False Then
                DriveShaft1.BackColor = System.Drawing.Color.Red
                DriveShaft2.BackColor = System.Drawing.Color.Red
                DriveShaft3.BackColor = System.Drawing.Color.Red
                Return
            Else
                DriveShaft1.BackColor = System.Drawing.Color.White
                DriveShaft2.BackColor = System.Drawing.Color.White
                DriveShaft3.BackColor = System.Drawing.Color.White
            End If
            If SteeringBox1.Checked = False And SteeringBox2.Checked = False Then
                SteeringBox1.BackColor = System.Drawing.Color.Red
                SteeringBox2.BackColor = System.Drawing.Color.Red
                Return
            Else
                SteeringBox1.BackColor = System.Drawing.Color.White
                SteeringBox2.BackColor = System.Drawing.Color.White
            End If
            If ExhaustPipe1.Checked = False And ExhaustPipe2.Checked = False Then
                ExhaustPipe1.BackColor = System.Drawing.Color.Red
                ExhaustPipe2.BackColor = System.Drawing.Color.Red
                Return
            Else
                ExhaustPipe1.BackColor = System.Drawing.Color.White
                ExhaustPipe2.BackColor = System.Drawing.Color.White
            End If
            If FuelBrake1.Checked = False And FuelBrake2.Checked = False Then
                FuelBrake1.BackColor = System.Drawing.Color.Red
                FuelBrake2.BackColor = System.Drawing.Color.Red
                Return
            Else
                FuelBrake1.BackColor = System.Drawing.Color.White
                FuelBrake2.BackColor = System.Drawing.Color.White
            End If
            If Replacement1.Checked = False And Replacement2.Checked = False And Replacement3.Checked = False Then
                Replacement1.BackColor = System.Drawing.Color.Red
                Replacement2.BackColor = System.Drawing.Color.Red
                Replacement3.BackColor = System.Drawing.Color.Red
                Return
            Else
                Replacement1.BackColor = System.Drawing.Color.White
                Replacement2.BackColor = System.Drawing.Color.White
                Replacement3.BackColor = System.Drawing.Color.White
            End If
            If WheelNuts1.Checked = False And WheelNuts2.Checked = False And WheelNuts3.Checked = False Then
                WheelNuts1.BackColor = System.Drawing.Color.Red
                WheelNuts2.BackColor = System.Drawing.Color.Red
                WheelNuts3.BackColor = System.Drawing.Color.Red
                Return
            Else
                WheelNuts1.BackColor = System.Drawing.Color.White
                WheelNuts2.BackColor = System.Drawing.Color.White
                WheelNuts3.BackColor = System.Drawing.Color.White
            End If
            If Drain1.Checked = False And Drain2.Checked = False Then
                Drain1.BackColor = System.Drawing.Color.Red
                Drain2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Drain1.BackColor = System.Drawing.Color.White
                Drain2.BackColor = System.Drawing.Color.White
            End If
            If RefillCoolant1.Checked = False And RefillCoolant2.Checked = False Then
                RefillCoolant1.BackColor = System.Drawing.Color.Red
                RefillCoolant2.BackColor = System.Drawing.Color.Red
                Return
            Else
                RefillCoolant1.BackColor = System.Drawing.Color.White
                RefillCoolant2.BackColor = System.Drawing.Color.White
            End If
            If ReplacementBrake1.Checked = False And ReplacementBrake2.Checked = False Then
                ReplacementBrake1.BackColor = System.Drawing.Color.Red
                ReplacementBrake2.BackColor = System.Drawing.Color.Red
                Return
            Else
                ReplacementBrake1.BackColor = System.Drawing.Color.White
                ReplacementBrake2.BackColor = System.Drawing.Color.White
            End If
            If AllLights1.Checked = False And AllLights2.Checked = False Then
                AllLights1.BackColor = System.Drawing.Color.Red
                AllLights2.BackColor = System.Drawing.Color.Red
                Return
            Else
                AllLights1.BackColor = System.Drawing.Color.White
                AllLights2.BackColor = System.Drawing.Color.White
            End If
            If Fluidcondition1.Checked = False And Fluidcondition2.Checked = False And Fluidcondition3.Checked = False And Fluidcondition4.Checked = False And Fluidcondition5.Checked = False And Fluidcondition6.Checked = False And Fluidcondition7.Checked = False Then
                Fluidcondition1.BackColor = System.Drawing.Color.Red
                Fluidcondition2.BackColor = System.Drawing.Color.Red
                Fluidcondition3.BackColor = System.Drawing.Color.Red
                Fluidcondition4.BackColor = System.Drawing.Color.Red
                Fluidcondition5.BackColor = System.Drawing.Color.Red
                Fluidcondition6.BackColor = System.Drawing.Color.Red
                Fluidcondition7.BackColor = System.Drawing.Color.Red
                Return
            Else
                Fluidcondition1.BackColor = System.Drawing.Color.White
                Fluidcondition2.BackColor = System.Drawing.Color.White
                Fluidcondition3.BackColor = System.Drawing.Color.White
                Fluidcondition4.BackColor = System.Drawing.Color.White
                Fluidcondition5.BackColor = System.Drawing.Color.White
                Fluidcondition6.BackColor = System.Drawing.Color.White
                Fluidcondition7.BackColor = System.Drawing.Color.White
            End If
            If DriveBelt1.Checked = False And DriveBelt2.Checked = False And DriveBelt3.Checked = False Then
                DriveBelt1.BackColor = System.Drawing.Color.Red
                DriveBelt2.BackColor = System.Drawing.Color.Red
                DriveBelt3.BackColor = System.Drawing.Color.Red
                Return
            Else
                DriveBelt1.BackColor = System.Drawing.Color.White
                DriveBelt2.BackColor = System.Drawing.Color.White
                DriveBelt3.BackColor = System.Drawing.Color.White
            End If
            If Battery1.Checked = False And Battery2.Checked = False And Battery3.Checked = False Then
                Battery1.BackColor = System.Drawing.Color.Red
                Battery2.BackColor = System.Drawing.Color.Red
                Battery3.BackColor = System.Drawing.Color.Red
                Return
            Else
                Battery1.BackColor = System.Drawing.Color.White
                Battery2.BackColor = System.Drawing.Color.White
                Battery3.BackColor = System.Drawing.Color.White
            End If
            If OilWaterleak1.Checked = False And OilWaterleak2.Checked = False And OilWaterleak3.Checked = False And OilWaterleak4.Checked = False And OilWaterleak5.Checked = False Then
                OilWaterleak1.BackColor = System.Drawing.Color.Red
                OilWaterleak2.BackColor = System.Drawing.Color.Red
                OilWaterleak3.BackColor = System.Drawing.Color.Red
                OilWaterleak4.BackColor = System.Drawing.Color.Red
                OilWaterleak5.BackColor = System.Drawing.Color.Red
                Return
            Else
                OilWaterleak1.BackColor = System.Drawing.Color.White
                OilWaterleak2.BackColor = System.Drawing.Color.White
                OilWaterleak3.BackColor = System.Drawing.Color.White
                OilWaterleak4.BackColor = System.Drawing.Color.White
                OilWaterleak5.BackColor = System.Drawing.Color.White
            End If
            If AirCleaner1.Checked = False And AirCleaner2.Checked = False Then
                AirCleaner1.BackColor = System.Drawing.Color.Red
                AirCleaner2.BackColor = System.Drawing.Color.Red
                Return
            Else
                AirCleaner1.BackColor = System.Drawing.Color.White
                AirCleaner2.BackColor = System.Drawing.Color.White
            End If
            If SparkPlugs1.Checked = False And SparkPlugs2.Checked = False Then
                SparkPlugs1.BackColor = System.Drawing.Color.Red
                SparkPlugs2.BackColor = System.Drawing.Color.Red
                Return
            Else
                SparkPlugs1.BackColor = System.Drawing.Color.White
                SparkPlugs2.BackColor = System.Drawing.Color.White
            End If
            If AroundTire1.Checked = False And AroundTire2.Checked = False And AroundTire3.Checked = False And AroundTire4.Checked = False And AroundTire5.Checked = False And BTireLeft.Text = "" And BTireRight.Text = "" Then
                AroundTire1.BackColor = System.Drawing.Color.Red
                AroundTire2.BackColor = System.Drawing.Color.Red
                AroundTire3.BackColor = System.Drawing.Color.Red
                AroundTire4.BackColor = System.Drawing.Color.Red
                AroundTire5.BackColor = System.Drawing.Color.Red
                BTireRight.BackColor = System.Drawing.Color.Red
                BTireLeft.BackColor = System.Drawing.Color.Red
                Return
            Else
                AroundTire1.BackColor = System.Drawing.Color.White
                AroundTire2.BackColor = System.Drawing.Color.White
                AroundTire3.BackColor = System.Drawing.Color.White
                AroundTire4.BackColor = System.Drawing.Color.White
                AroundTire5.BackColor = System.Drawing.Color.White
                BTireRight.BackColor = System.Drawing.Color.White
                BTireLeft.BackColor = System.Drawing.Color.White
            End If
            If Brakepad1.Checked = False And Brakepad2.Checked = False And Brakepad3.Checked = False And Brakepad4.Checked = False And Brakepad5.Checked = False And Brakepad6.Checked = False And BBrakePadRight.Text = "" And BBrakPadLeft.Text = "" Then
                Brakepad1.BackColor = System.Drawing.Color.Red
                Brakepad2.BackColor = System.Drawing.Color.Red
                Brakepad3.BackColor = System.Drawing.Color.Red
                Brakepad4.BackColor = System.Drawing.Color.Red
                Brakepad5.BackColor = System.Drawing.Color.Red
                Brakepad6.BackColor = System.Drawing.Color.Red
                BBrakePadRight.BackColor = System.Drawing.Color.Red
                BBrakPadLeft.BackColor = System.Drawing.Color.Red
                Return
            Else
                Brakepad1.BackColor = System.Drawing.Color.White
                Brakepad2.BackColor = System.Drawing.Color.White
                Brakepad3.BackColor = System.Drawing.Color.White
                Brakepad4.BackColor = System.Drawing.Color.White
                Brakepad5.BackColor = System.Drawing.Color.White
                Brakepad6.BackColor = System.Drawing.Color.White
                BBrakePadRight.BackColor = System.Drawing.Color.White
                BBrakPadLeft.BackColor = System.Drawing.Color.White
            End If
            If BrakeDisc1.Checked = False And BrakeDisc2.Checked = False Then
                BrakeDisc1.BackColor = System.Drawing.Color.Red
                BrakeDisc2.BackColor = System.Drawing.Color.Red
                Return
            Else
                BrakeDisc1.BackColor = System.Drawing.Color.White
                BrakeDisc2.BackColor = System.Drawing.Color.White
            End If
            If BrakeHose1.Checked = False And BrakeHose2.Checked = False Then
                BrakeHose1.BackColor = System.Drawing.Color.Red
                BrakeHose2.BackColor = System.Drawing.Color.Red
                Return
            Else
                BrakeHose1.BackColor = System.Drawing.Color.White
                BrakeHose2.BackColor = System.Drawing.Color.White
            End If
            If SuspensionArm1.Checked = False And SuspensionArm2.Checked = False Then
                SuspensionArm1.BackColor = System.Drawing.Color.Red
                SuspensionArm2.BackColor = System.Drawing.Color.Red
                Return
            Else
                SuspensionArm1.BackColor = System.Drawing.Color.White
                SuspensionArm2.BackColor = System.Drawing.Color.White
            End If
            If Damper1.Checked = False And Damper2.Checked = False Then
                Damper1.BackColor = System.Drawing.Color.Red
                Damper2.BackColor = System.Drawing.Color.Red
                Return
            Else
                Damper1.BackColor = System.Drawing.Color.White
                Damper2.BackColor = System.Drawing.Color.White
            End If
            If crackandgrease1.Checked = False And crackandgrease2.Checked = False And crackandgrease3.Checked = False And crackandgrease4.Checked = False Then
                crackandgrease1.BackColor = System.Drawing.Color.Red
                crackandgrease2.BackColor = System.Drawing.Color.Red
                crackandgrease3.BackColor = System.Drawing.Color.Red
                crackandgrease4.BackColor = System.Drawing.Color.Red
                Return
            Else
                crackandgrease1.BackColor = System.Drawing.Color.White
                crackandgrease2.BackColor = System.Drawing.Color.White
                crackandgrease3.BackColor = System.Drawing.Color.White
                crackandgrease4.BackColor = System.Drawing.Color.White
            End If
            If DrainDderCar1.Checked = False And DrainDderCar2.Checked = False And DrainDderCar3.Checked = False And DrainDderCar4.Checked = False And DrainDderCar5.Checked = False And DrainDderCar6.Checked = False And DrainDderCar7.Checked = False Then
                DrainDderCar1.BackColor = System.Drawing.Color.Red
                DrainDderCar2.BackColor = System.Drawing.Color.Red
                DrainDderCar3.BackColor = System.Drawing.Color.Red
                DrainDderCar4.BackColor = System.Drawing.Color.Red
                DrainDderCar5.BackColor = System.Drawing.Color.Red
                DrainDderCar6.BackColor = System.Drawing.Color.Red
                DrainDderCar7.BackColor = System.Drawing.Color.Red
                Return
            Else
                DrainDderCar1.BackColor = System.Drawing.Color.White
                DrainDderCar2.BackColor = System.Drawing.Color.White
                DrainDderCar3.BackColor = System.Drawing.Color.White
                DrainDderCar4.BackColor = System.Drawing.Color.White
                DrainDderCar5.BackColor = System.Drawing.Color.White
                DrainDderCar6.BackColor = System.Drawing.Color.White
                DrainDderCar7.BackColor = System.Drawing.Color.White
            End If
            If Oilleak1.Checked = False And Oilleak2.Checked = False And Oilleak3.Checked = False And Oilleak4.Checked = False Then
                Oilleak1.BackColor = System.Drawing.Color.Red
                Oilleak2.BackColor = System.Drawing.Color.Red
                Oilleak3.BackColor = System.Drawing.Color.Red
                Oilleak4.BackColor = System.Drawing.Color.Red
                Return
            Else
                Oilleak1.BackColor = System.Drawing.Color.White
                Oilleak2.BackColor = System.Drawing.Color.White
                Oilleak3.BackColor = System.Drawing.Color.White
                Oilleak4.BackColor = System.Drawing.Color.White
            End If
            If ReplacementOilFilter1.Checked = False And ReplacementOilFilter2.Checked = False And ReplacementOilFilter3.Checked = False And ReplacementOilFilter4.Checked = False And ReplacementOilFilter5.Checked = False And ReplacementOilFilter6.Checked = False Then
                ReplacementOilFilter1.BackColor = System.Drawing.Color.Red
                ReplacementOilFilter2.BackColor = System.Drawing.Color.Red
                ReplacementOilFilter3.BackColor = System.Drawing.Color.Red
                ReplacementOilFilter4.BackColor = System.Drawing.Color.Red
                ReplacementOilFilter5.BackColor = System.Drawing.Color.Red
                ReplacementOilFilter6.BackColor = System.Drawing.Color.Red
                Return
            Else
                ReplacementOilFilter1.BackColor = System.Drawing.Color.White
                ReplacementOilFilter2.BackColor = System.Drawing.Color.White
                ReplacementOilFilter3.BackColor = System.Drawing.Color.White
                ReplacementOilFilter4.BackColor = System.Drawing.Color.White
                ReplacementOilFilter5.BackColor = System.Drawing.Color.White
                ReplacementOilFilter6.BackColor = System.Drawing.Color.White
            End If
            If Refill1.Checked = False And Refill2.Checked = False And Refill3.Checked = False And Refill4.Checked = False And Refill5.Checked = False Then
                Refill1.BackColor = System.Drawing.Color.Red
                Refill2.BackColor = System.Drawing.Color.Red
                Refill3.BackColor = System.Drawing.Color.Red
                Refill4.BackColor = System.Drawing.Color.Red
                Refill5.BackColor = System.Drawing.Color.Red
                Return
            Else
                Refill1.BackColor = System.Drawing.Color.White
                Refill2.BackColor = System.Drawing.Color.White
                Refill3.BackColor = System.Drawing.Color.White
                Refill4.BackColor = System.Drawing.Color.White
                Refill5.BackColor = System.Drawing.Color.White
            End If
            If FluidLevel1.Checked = False And FluidLevel2.Checked = False And FluidLevel3.Checked = False And FluidLevel4.Checked = False Then
                FluidLevel1.BackColor = System.Drawing.Color.Red
                FluidLevel2.BackColor = System.Drawing.Color.Red
                FluidLevel3.BackColor = System.Drawing.Color.Red
                FluidLevel4.BackColor = System.Drawing.Color.Red
                Return
            Else
                FluidLevel1.BackColor = System.Drawing.Color.White
                FluidLevel2.BackColor = System.Drawing.Color.White
                FluidLevel3.BackColor = System.Drawing.Color.White
                FluidLevel4.BackColor = System.Drawing.Color.White
            End If
            If RearSide1.Checked = False And RearSide2.Checked = False And RearSide3.Checked = False And RearSide4.Checked = False And RearSide5.Checked = False And ATireRight.Text = "" And ATireLeft.Text = "" Then
                RearSide1.BackColor = System.Drawing.Color.Red
                RearSide2.BackColor = System.Drawing.Color.Red
                RearSide3.BackColor = System.Drawing.Color.Red
                RearSide4.BackColor = System.Drawing.Color.Red
                RearSide5.BackColor = System.Drawing.Color.Red
                ATireRight.BackColor = System.Drawing.Color.Red
                ATireLeft.BackColor = System.Drawing.Color.Red
                Return
            Else
                RearSide1.BackColor = System.Drawing.Color.White
                RearSide2.BackColor = System.Drawing.Color.White
                RearSide3.BackColor = System.Drawing.Color.White
                RearSide4.BackColor = System.Drawing.Color.White
                RearSide5.BackColor = System.Drawing.Color.White
                ATireRight.BackColor = System.Drawing.Color.White
                ATireLeft.BackColor = System.Drawing.Color.White
            End If
            If TireBrakepad1.Checked = False And TireBrakepad2.Checked = False And TireBrakepad3.Checked = False And TireBrakepad4.Checked = False And TireBrakepad5.Checked = False And TireBrakepad6.Checked = False And ABrakePadRight.Text = "" And ABrakPadLeft.Text = "" Then
                TireBrakepad1.BackColor = System.Drawing.Color.Red
                TireBrakepad2.BackColor = System.Drawing.Color.Red
                TireBrakepad3.BackColor = System.Drawing.Color.Red
                TireBrakepad4.BackColor = System.Drawing.Color.Red
                TireBrakepad5.BackColor = System.Drawing.Color.Red
                TireBrakepad6.BackColor = System.Drawing.Color.Red
                ABrakePadRight.BackColor = System.Drawing.Color.Red
                ABrakPadLeft.BackColor = System.Drawing.Color.Red
                Return
            Else
                TireBrakepad1.BackColor = System.Drawing.Color.White
                TireBrakepad2.BackColor = System.Drawing.Color.White
                TireBrakepad3.BackColor = System.Drawing.Color.White
                TireBrakepad4.BackColor = System.Drawing.Color.White
                TireBrakepad5.BackColor = System.Drawing.Color.White
                TireBrakepad6.BackColor = System.Drawing.Color.White
                ABrakePadRight.BackColor = System.Drawing.Color.White
                ABrakPadLeft.BackColor = System.Drawing.Color.White
            End If
            If BrakeDiscc1.Checked = False And BrakeDiscc2.Checked = False Then
                BrakeDiscc1.BackColor = System.Drawing.Color.Red
                BrakeDiscc2.BackColor = System.Drawing.Color.Red
                Return
            Else
                BrakeDiscc1.BackColor = System.Drawing.Color.White
                BrakeDiscc2.BackColor = System.Drawing.Color.White
            End If
            If BrakeHosee1.Checked = False And BrakeHosee2.Checked = False Then
                BrakeHosee1.BackColor = System.Drawing.Color.Red
                BrakeHosee2.BackColor = System.Drawing.Color.Red
                Return
            Else
                BrakeHosee1.BackColor = System.Drawing.Color.White
                BrakeHosee2.BackColor = System.Drawing.Color.White
            End If
            If SuspensionBush1.Checked = False And SuspensionBush2.Checked = False Then
                SuspensionBush1.BackColor = System.Drawing.Color.Red
                SuspensionBush2.BackColor = System.Drawing.Color.Red
                Return
            Else
                SuspensionBush1.BackColor = System.Drawing.Color.White
                SuspensionBush2.BackColor = System.Drawing.Color.White
            End If
            If DamperOilleaks1.Checked = False And DamperOilleaks2.Checked = False Then
                DamperOilleaks1.BackColor = System.Drawing.Color.Red
                DamperOilleaks2.BackColor = System.Drawing.Color.Red
                Return
            Else
                DamperOilleaks1.BackColor = System.Drawing.Color.White
                DamperOilleaks2.BackColor = System.Drawing.Color.White
            End If
            If leakinggrease1.Checked = False And leakinggrease2.Checked = False And leakinggrease3.Checked = False Then
                leakinggrease1.BackColor = System.Drawing.Color.Red
                leakinggrease2.BackColor = System.Drawing.Color.Red
                leakinggrease3.BackColor = System.Drawing.Color.Red
                Return
            Else
                leakinggrease1.BackColor = System.Drawing.Color.White
                leakinggrease2.BackColor = System.Drawing.Color.White
                leakinggrease3.BackColor = System.Drawing.Color.White
            End If








            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
                Myconnection.Open()
                Dim maxId = genf.returnvaluefromdv("Select max(PMId) from PMSheet ", 0)
                strnewrecord = "Insert into  PMSheet(PMId ,SA_Id ,Tech_Id ,regis_No ,Entry_Date ,status ) values('" & Val(maxId) + 1 & "',"
                strnewrecord &= "'" & SAName.Text & "','" + TechName.Text + "','" + RegNo.Text + "','" & genf.getdate(EnterDate.Text).ToString("MM/dd/yyyy") & "',1) "
                maxId = Val(maxId) + 1

                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
                Dim MaxDataID = genf.returnvaluefromdv("Select max(ID) from PmSheet_Data ", 0)
                Dim allTxt As New List(Of Control)
                For Each checkBox As CheckBox In FindControlRecursive(allTxt, Me, GetType(CheckBox))
                    If checkBox.Checked Then
                        MaxDataID = Val(MaxDataID) + 1
                        strnewrecord = "insert into PmSheet_Data (ID,PMSheetId,PMDataId) values ('" & Val(MaxDataID) & "','" & maxId & "','" & Val(checkBox.TabIndex) & "')"
                        Mycommand = New SqlCommand(strnewrecord, Myconnection)
                        Mycommand.ExecuteNonQuery()
                    End If
                Next

                Dim MaxTextID = genf.returnvaluefromdv("Select max(ID) from PMSheetTextInfo ", 0)
                strnewrecord = "insert into PMSheetTextInfo (id,ATireRight,ATireLeft,ABrakePadRight,ABrakPadLeft ,BTireRight,BTireLeft,BBrakePadRight,"
                strnewrecord &= " BBrakPadLeft,PMSheetId ) values ('" & Val(MaxTextID) + 1 & "','" & ATireRight.Text & "','" & ATireLeft.Text & "',"
                strnewrecord &= " '" & ABrakePadRight.Text & "','" & ABrakPadLeft.Text & "','" & BTireRight.Text & "','" & BTireLeft.Text & "',"
                strnewrecord &= " '" & BBrakePadRight.Text & "','" & BBrakPadLeft.Text & "','" & maxId & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()

                Dim MaxSummaryID = genf.returnvaluefromdv("Select max(ID) from PMSheetSummary  ", 0)

                strnewrecord = "Insert into PMSheetSummary  (Id,TechA,TechB,PMSheetId) values('" & Val(MaxSummaryID) + 1 & "','" & TechA.Text & "','" & TechB.Text & "','" & maxId & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()


                Dim MaxTableID = genf.returnvaluefromdv("Select max(ID) from PMSheet_Table  ", 0)

                strnewrecord = "Insert into PMSheet_Table  (Id ,FirstAT ,FirstD ,SecAT ,SecD ,ThirdAT ,ThirdD ,FourAT ,FourD ,FifthAT ,FifthD ,FinalAT ,FinalD ,PMsheetID ) "
                strnewrecord &= " values('" & Val(MaxTableID) + 1 & "','" & FirstAT.Text & "','" & FirstD.Text & "','" & SecAT.Text & "','" & SecD.Text & "','" & ThirdAT.Text & "'"
                strnewrecord &= ",'" & ThirdD.Text & "','" & FourAT.Text & "','" & FourD.Text & "','" & FifthAT.Text & "','" & FifthD.Text & "','" & FinalAT.Text & "','" & FinalD.Text & "','" & maxId & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
                Myconnection.Close()


                Dim alertScript = "alert('This Data Has Been Inserted Succesfully ...');"
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)


                'For Each checkBox As CheckBox In FindControlRecursive(allTxt, Me, GetType(CheckBox))
                '    If Val(checkBox.TabIndex) > 5 Then
                '        checkBox.Checked = True
                '    End If
                'Next
                Page_Load(sender, e)
            Else

            If SAName.Text = "" Then
                saValid.Text = "Please Enter the SA Name"
                saValid.ForeColor = Color.Red
            Else
                saValid.ForeColor = Color.White

            End If
            If TechName.Text = "" Then
                techValid.Text = "Please Enter the Tech Name"
                techValid.ForeColor = Color.Red
            Else
                techValid.ForeColor = Color.White
            End If
            If EnterDate.Text = "" Then
                dateValid.Text = "Please Enter the Date"
                dateValid.ForeColor = Color.Red
            Else
                dateValid.ForeColor = Color.White
            End If
            If RegNo.Text = "" Then
                regValid.Text = "Please Enter the Registration Number"
                regValid.ForeColor = Color.Red
            Else
                regValid.ForeColor = Color.White
            End If
        End If
        Page_Load(sender, e)

    End Sub


    Protected Sub Button11_Click(sender As Object, e As System.EventArgs) Handles Button11.Click
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim PMSheetId = genf.returnvaluefromdv("Select PMID from [vs].[dbo].[PMSheet] where regis_No='" & RegNo.Text & "' and Entry_Date='" & genf.getdate(EnterDate.Text).ToString("yyyy/MM/dd") & "' ", 0)


        strnewrecord = ("delete from PMSheet where PMId='" & PMSheetId & "'")
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = ("delete from PmSheet_Data where PMSheetId='" & PMSheetId & "'")
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()



        strnewrecord = ("delete from PMSheetTextInfo where PMSheetId='" & PMSheetId & "'")
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        strnewrecord = ("delete from PMSheetSummary where PMSheetId='" & PMSheetId & "'")
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        strnewrecord = ("delete from PMSheet_Table where PMSheetId='" & PMSheetId & "'")
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()


        Dim maxId = genf.returnvaluefromdv("Select max(PMId) from PMSheet ", 0)
        strnewrecord = "Insert into  PMSheet(PMId ,SA_Id ,Tech_Id ,regis_No ,Entry_Date ,status ) values('" & Val(maxId) + 1 & "',"
        strnewrecord &= "'" & SAName.Text & "','" + TechName.Text + "','" + RegNo.Text + "','" & genf.getdate(EnterDate.Text).ToString("MM/dd/yyyy") & "',1) "
        maxId = Val(maxId) + 1

        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Dim MaxDataID = genf.returnvaluefromdv("Select max(ID) from PmSheet_Data ", 0)
        Dim allTxt As New List(Of Control)
        For Each checkBox As CheckBox In FindControlRecursive(allTxt, Me, GetType(CheckBox))
            If checkBox.Checked Then
                MaxDataID = Val(MaxDataID) + 1
                strnewrecord = "insert into PmSheet_Data (ID,PMSheetId,PMDataId) values ('" & Val(MaxDataID) & "','" & maxId & "','" & Val(checkBox.TabIndex) & "')"
                Mycommand = New SqlCommand(strnewrecord, Myconnection)
                Mycommand.ExecuteNonQuery()
            End If
        Next

        Dim MaxTextID = genf.returnvaluefromdv("Select max(ID) from PMSheetTextInfo ", 0)
        strnewrecord = "insert into PMSheetTextInfo (id,ATireRight,ATireLeft,ABrakePadRight,ABrakPadLeft ,BTireRight,BTireLeft,BBrakePadRight,"
        strnewrecord &= " BBrakPadLeft,PMSheetId ) values ('" & Val(MaxTextID) + 1 & "','" & ATireRight.Text & "','" & ATireLeft.Text & "',"
        strnewrecord &= " '" & ABrakePadRight.Text & "','" & ABrakPadLeft.Text & "','" & BTireRight.Text & "','" & BTireLeft.Text & "',"
        strnewrecord &= " '" & BBrakePadRight.Text & "','" & BBrakPadLeft.Text & "','" & maxId & "')"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Dim MaxSummaryID = genf.returnvaluefromdv("Select max(ID) from PMSheetSummary  ", 0)

        strnewrecord = "Insert into PMSheetSummary  (Id,TechA,TechB,PMSheetId) values('" & Val(MaxSummaryID) + 1 & "','" & TechA.Text & "','" & TechB.Text & "','" & maxId & "')"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()

        Dim MaxTableID = genf.returnvaluefromdv("Select max(ID) from PMSheet_Table  ", 0)

        strnewrecord = "Insert into PMSheet_Table  (Id ,FirstAT ,FirstD ,SecAT ,SecD ,ThirdAT ,ThirdD ,FourAT ,FourD ,FifthAT ,FifthD ,FinalAT ,FinalD ,PMsheetID ) "
        strnewrecord &= " values('" & Val(MaxTableID) + 1 & "','" & FirstAT.Text & "','" & FirstD.Text & "','" & SecAT.Text & "','" & SecD.Text & "','" & ThirdAT.Text & "'"
        strnewrecord &= ",'" & ThirdD.Text & "','" & FourAT.Text & "','" & FourD.Text & "','" & FifthAT.Text & "','" & FifthD.Text & "','" & FinalAT.Text & "','" & FinalD.Text & "','" & maxId & "')"
        Mycommand = New SqlCommand(strnewrecord, Myconnection)
        Mycommand.ExecuteNonQuery()
        Myconnection.Close()
        Dim alertScript = "alert('This Data Has Been Inserted Succesfully ...');"
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Key", alertScript, True)


        'For Each checkBox As CheckBox In FindControlRecursive(allTxt, Me, GetType(CheckBox))
        '    If Val(checkBox.TabIndex) > 5 Then
        '        checkBox.Checked = True
        '    End If
        'Next
        Page_Load(sender, e)
    End Sub

    Public Shared Function FindControlRecursive(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)
        If parent Is Nothing Then Return list
        If parent.GetType Is ctrlType Then
            list.Add(parent)
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child, ctrlType)
        Next
        Return list
    End Function

End Class

