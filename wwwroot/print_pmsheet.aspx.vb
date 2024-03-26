Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Imports System.IO
Imports System.Drawing
Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Partial Class print_pmsheet
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

            Button1.Visible = False

            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()


            Dim Command As New SqlCommand("select PMDataId FROM [PmSheet_Data] where PMSheetId='" & Request.QueryString("id") & "'", Myconnection)
            Dim reader As SqlDataReader = Command.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(reader)
            Dim Lt As List(Of Integer) = New List(Of Integer)()
            Dim i
            For i = 0 To dt.Rows.Count - 1
                Lt.Add(dt.Rows(i)(0))
            Next

            Dim Command1 As New SqlCommand("SELECT [SA_Id] ,[Tech_Id],[regis_No] ,Format([Entry_Date],'dd/MM/yyyy') FROM [PMSheet] where PMID='" & Request.QueryString("id") & "'", Myconnection)
            Dim reader1 As SqlDataReader = Command1.ExecuteReader()
            Dim dt1 As New DataTable()
            dt1.Load(reader1)



            Dim Command2 As New SqlCommand("SELECT [TechA],[TechB] FROM [PMSheetSummary]where PMSheetId='" & Request.QueryString("id") & "'", Myconnection)
            Dim reader2 As SqlDataReader = Command2.ExecuteReader()
            Dim dt2 As New DataTable()
            dt2.Load(reader2)




            Dim Command3 As New SqlCommand("SELECT [ATireRight],[ATireLeft],[ABrakePadRight],[ABrakPadLeft],[BTireRight],[BTireLeft],[BBrakePadRight],[BBrakPadLeft],[PMSheetId]FROM [PMSheetTextInfo] where PMSheetId='" & Request.QueryString("id") & "'", Myconnection)
            Dim reader3 As SqlDataReader = Command3.ExecuteReader()
            Dim dt3 As New DataTable()
            dt3.Load(reader3)

            Dim Command4 As New SqlCommand("SELECT FirstAT ,FirstD ,SecAT ,SecD ,ThirdAT ,ThirdD ,FourAT ,FourD ,FifthAT ,FifthD ,FinalAT ,FinalD FROM [PMSheet_Table] where PMSheetId='" & Request.QueryString("id") & "'", Myconnection)
            Dim reader4 As SqlDataReader = Command4.ExecuteReader()
            Dim dt4 As New DataTable()
            dt4.Load(reader4)


            Literal1.Mode = LiteralMode.Encode
            Literal1.Mode = LiteralMode.PassThrough


            Literal1.Text = Literal1.Text & "<div style='padding: 0 10px; margin: 0px; width: 100%;display: flex;justify-content: space-between;'>"
            Literal1.Text = Literal1.Text & "<div><img src='image/logo.jpg' style='width:201px;border-width:0px;' /><h6 style='margin-left: -119px;margin-top: -10px;'>Vehicle Solution</h6><p style='font-size: 10px;margin-top: -24px;margin-left: 9px;'>SAT-42, Ferajitola, Solmaith, Vatara, Dhaka-1212.</p><p style='font-size: 10px;margin-top: -9px;margin-left: -18px;'>Nearby Evercare Hospital,Basundhara R/A</p><p style='font-size: 10px;margin-top: -9px;margin-left: -34px;'>Tel:58812690, www.vehiclesolution.net</p></div>"
            Literal1.Text = Literal1.Text & "<h3 style='margin-top: 60px;margin-left: -216px;'>Periodic Maintenance Sheet</h3>"
            Literal1.Text = Literal1.Text & "<h3></h3></div>"
            Literal1.Text = Literal1.Text & "<div style='width: 100%;margin-top: -25px;padding: 0 10px;'>"
            Literal1.Text = Literal1.Text & "<table style='width: 100%;'><tr><td><h5 >SA Name:<span style='text-decoration: underline;text-decoration-style: dotted;'>" & dt1.Rows(0)(0) & "</span></h5></td><td><h5>Technician  Name:<span style='text-decoration: underline;text-decoration-style: dotted;'>" & dt1.Rows(0)(1) & "</span></h5></td><td><h5>Registration  No:<span style='text-decoration: underline;text-decoration-style: dotted;'>" & dt1.Rows(0)(2) & "</span></h5></td> <td><h5>Entry  Name:<span style='text-decoration: underline;text-decoration-style: dotted;'>" & dt1.Rows(0)(3) & "</span></h5></td></tr></table>"
            Literal1.Text = Literal1.Text & "<div style ='display: flex;  border: 1px solid black;margin:3px;margin-right:15px'>"
            Literal1.Text = Literal1.Text & "<div style='width: 50%; border-right: 1px solid black'>"
            Literal1.Text = Literal1.Text & "<h5 style='margin-top: 0px; margin-bottom: 3px;'>Tech. A</h5>"
            Literal1.Text = Literal1.Text & "<section id='hiddenText' style='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "<table  style='width: 50%; border-right: 1px solid black;'><tr><td style='width: 100%; padding: 8px; '></td></tr>"
            Literal1.Text = Literal1.Text & "<tr><td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>1 Warning lamp</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(1) Then
                Literal1.Text = Literal1.Text & "<input type='checkbox' disabled checked/><label style='font-size: 12px;'>Operation</label>"
            Else
                Literal1.Text = Literal1.Text & "<input type='checkbox' disabled /><label style='font-size: 12px;'>Operation</label>"
            End If

            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/warning lamp.png' style='margin-top: -12px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>2 Wiper,Wahser</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(2) Then
                Literal1.Text = Literal1.Text & "<input type='checkbox' disabled checked/><label style='font-size: 12px;'>Wipe Condition</label>"
            Else
                Literal1.Text = Literal1.Text & "<input type='checkbox' disabled /><label style='font-size: 12px;'>Wipe Condition</label>"
            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/wiper.png' width='50px' style='margin-top: -10px;' height='30px'/>"
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & "  <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "   <div style='width: 75%'>"
            If Lt.Contains(3) Then
                Literal1.Text = Literal1.Text & " <input type='checkbox' disabled checked/><label style='font-size: 12px;'>Washer nozzle direction,and amount of spray</label>"
            Else
                Literal1.Text = Literal1.Text & " <input type='checkbox' disabled /><label style='font-size: 12px;'>Washer nozzle direction,and amount of spray</label>"
            End If
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & "  <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "     <img src='image/washer.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "  </td>"
            Literal1.Text = Literal1.Text & "  </tr>"
            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "   <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "   <h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Horn</h6>"
            Literal1.Text = Literal1.Text & "  <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "   <div style='width: 75%'>"
            If Lt.Contains(4) Then
                Literal1.Text = Literal1.Text & "  <input type='checkbox' disabled checked/><label style='font-size: 12px;'>Opearation and Sound</label>"
            Else
                Literal1.Text = Literal1.Text & "  <input type='checkbox' disabled /><label style='font-size: 12px;'>Opearation and Sound</label>"

            End If
            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & " <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "   <img src='image/horn.png' width='50px' style='margin-top: -10px;' height='30px'/>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "<tr><td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>4 Elec. System Operation</h6>"
            If Lt.Contains(5) Then
                Literal1.Text = Literal1.Text & " <div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Power Window</label></div>"
            Else
                Literal1.Text = Literal1.Text & " <div><input type='checkbox' disabled /><label style='font-size: 12px;'>Power Window</label></div>"

            End If
            If Lt.Contains(6) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Power Door Lock</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Power Door Lock</label></div>"
            End If
            If Lt.Contains(7) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Power Mirror</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Power Mirror</label></div>"

            End If
            If Lt.Contains(8) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>A/C</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>A/C</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</td></tr></table>"



            Literal1.Text = Literal1.Text & "<table style='width: 50%;'>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>5 Brake Booster</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(9) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Leak Check</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Leak Check</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/brake_booster.png' width='50px' style='margin-top: -10px;' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "< tr >"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>6 Steering Wheal</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(10) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Rotational Play  and Runout</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Rotational Play  and Runout</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/steering_wheel.png' style='margin-top: -10px; margin-bottom: 3px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>7 Parking Brake</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(11) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>The Number of Level clicks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>The Number of Level clicks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/parking_brake.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>8 Break Padel</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%; display: flex; flex-direction: column'>"
            If Lt.Contains(12) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Free Play</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Free Play</label></div>"

            End If
            If Lt.Contains(13) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Pedal Pad Wear</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Pedal Pad Wear</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/brake_pedal.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"

            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>9 Clutch Pedal</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%; display: flex; flex-direction: column'>"
            If Lt.Contains(14) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Free Play</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Free Play</label></div>"

            End If
            If Lt.Contains(15) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Pedal Pad Wear</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Pedal Pad Wear</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/clutch_pedal.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>10 Tire Air Pressure</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%; display: flex; flex-direction: column'>"
            If Lt.Contains(16) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Tire</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Tire</label></div>"

            End If
            If Lt.Contains(17) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Spare Tire</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Spare Tire</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/tire_air_pressure.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"

            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "</table>"
            Literal1.Text = Literal1.Text & "</section>"


            Literal1.Text = Literal1.Text & "<div style='width: 100%; border-top: 1px solid black; display: flex; flex-direction: column; align-items: flex-start;'>"
            If Lt.Contains(18) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>  <span>&#x26A0;</span> Is the vehicle in the center of the lift?</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>  <span>&#x26A0;</span> Is the vehicle in the center of the lift?</label></div>"

            End If
            If Lt.Contains(19) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>  <span>&#x26A0;</span> Are the lift blocks placed at the vehicle' s support points?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>  <span>&#x26A0;</span> Are the lift blocks placed at the vehicle' s support points?</label></div>"

            End If
            If Lt.Contains(20) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>  <span>&#x26A0;</span> Are the support points in the center of the lift blocks?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>  <span>&#x26A0;</span> Are the support points in the center of the lift blocks?</label></div>"

            End If
            If Lt.Contains(21) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>  <span>&#x26A0;</span> Dis you give verbal notice before raising the lift?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>  <span>&#x26A0;</span> Dis you give verbal notice before raising the lift?</label></div>"
            End If
            Literal1.Text = Literal1.Text & "</div>"



            Literal1.Text = Literal1.Text & "<div style='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "<table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='width: 100%; margin: auto; '>"
            Literal1.Text = Literal1.Text & "<p style='margin: auto;'>Around The Tire (Rear Side)</p>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>1 Tire</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex; flex-direction: column;'>"
            If Lt.Contains(22) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Wheel Bearing Check</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Wheel Bearing Check</label></div>"

            End If
            If Lt.Contains(23) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Break Drag</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Break Drag</label></div>"

            End If
            If Lt.Contains(24) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cuts,Creaks,Uneven Wear</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cuts,Creaks,Uneven Wear</label></div>"

            End If

            Literal1.Text = Literal1.Text & "</div>"

            Literal1.Text = Literal1.Text & "<div style='display: flex; align-items: center; justify-content: center;'>"
            Literal1.Text = Literal1.Text & "<img src='image/Tire.jpg' width='100px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;justify-content: space-between;'>"
            If Lt.Contains(25) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Tread Groove Depth </label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Tread Groove Depth </label></div>"

            End If
            If dt3.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right " & dt3.Rows(0)(0) & "mm Left " & dt3.Rows(0)(1) & "mm</label>"
            Else
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right 0mm Left 0mm</label>"

            End If

            Literal1.Text = Literal1.Text & "</div>"

            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>2 Brake pad</h6>"
            If Lt.Contains(26) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Aren' t the pad surfaces laid directly on the tray?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Aren' t the pad surfaces laid directly on the tray?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "<div style='display: flex;justify-content: space-between;'>"
            If Lt.Contains(27) Then
                Literal1.Text = Literal1.Text & "<div style='width: 40%;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Were the pads at several points measured?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div style='width: 40%;'><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Were the pads at several points measured?</label></div>"

            End If
            If dt3.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right " & dt3.Rows(0)(2) & "mm Left " & dt3.Rows(0)(3) & "mm</label>"
            Else
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right 0mm Left 0mm</label>"
            End If

            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            If Lt.Contains(28) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Did you check wheater callper pins moves smoothly?</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Did you check wheater callper pins moves smoothly?</label></div>"

            End If
            If Lt.Contains(29) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Ware the specified locations coated with pad grease?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Ware the specified locations coated with pad grease?</label></div>"

            End If
            If Lt.Contains(30) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Was the caliper tightened to the specified torque using a torque wrench?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Was the caliper tightened to the specified torque using a torque wrench?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "</table>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 50%'>"
            Literal1.Text = Literal1.Text & "<table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & " <tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Brake Disc</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(31) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Creaks,Uneven Wear</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Creaks,Uneven Wear</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/brake_disk.png' style='margin-top: -12px; margin-bottom:3px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>4 Brake Hose</h6>"
            If Lt.Contains(32) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cuts, Cracks</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cuts, Cracks</label></div>"

            End If

            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr >"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>5 Suspension Arm and Bush</h6>"
            If Lt.Contains(33) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cracks, damages</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cracks, damages</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "< tr >"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>6 Damper</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(34) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Oil leaks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Oil leaks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/damper.png' style='margin-top: -12px;margin-bottom:3px' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>7 Checks for play,crackand leaking grease</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%; display: flex; flex-direction: column'>"
            If Lt.Contains(35) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Knuckle Joint</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Knuckle Joint</label></div>"
            End If
            If Lt.Contains(36) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Stabilizar Joint</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Stabilizar Joint</label></div>"
            End If
            Literal1.Text = Literal1.Text & "<img style='margin-left: 50px;' src='image/Check_for_play.jpg' width='150px' height='40px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"

            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"

            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "</table>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & " </div>"

            Literal1.Text = Literal1.Text & " <div style='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "    <div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "       <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "          <tr>"
            Literal1.Text = Literal1.Text & "              <td style='width: 100%; margin: auto;'>"
            Literal1.Text = Literal1.Text & "      <p style='margin: auto;'>Under Car</p>"
            Literal1.Text = Literal1.Text & "  </td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & " < tr >"
            Literal1.Text = Literal1.Text & "   <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "       <h6 style='margin-top: 0px; margin-bottom: 0px;'>1 Stablizer</h6>"
            If Lt.Contains(37) Then
                Literal1.Text = Literal1.Text & " <div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Play, Damages</label></div>"
            Else
                Literal1.Text = Literal1.Text & " <div><input type='checkbox' disabled /><label style='font-size: 12px;'>Play, Damages</label></div>"

            End If

            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & "  </tr>"
            Literal1.Text = Literal1.Text & " < tr >"
            Literal1.Text = Literal1.Text & "      <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "        <h6 style='margin-top: 0px; margin-bottom: 0px;'>2 Suspension and Brake Bolts</h6>"
            If Lt.Contains(38) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Looseness</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Looseness</label></div>"

            End If
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & "  </tr>"
            Literal1.Text = Literal1.Text & " < tr >"
            Literal1.Text = Literal1.Text & "  <td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "      <h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Drive Shaft Boots</h6>"
            Literal1.Text = Literal1.Text & "     <div style='display:flex'>"
            Literal1.Text = Literal1.Text & "          <div style='display: flex; flex-direction: column; width: 70%'>"
            If Lt.Contains(39) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cracks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cracks</label></div>"

            End If
            If Lt.Contains(40) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you check entire circumference of the boots?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you check entire circumference of the boots?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "     </div>"

            Literal1.Text = Literal1.Text & "    <div style='display: flex; width: 30%; align-items: center; justify-content: center;'>"
            Literal1.Text = Literal1.Text & "       <img src='image/drive_shaft_boots.png' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & "  </div>"


            Literal1.Text = Literal1.Text & "     </td>"
            Literal1.Text = Literal1.Text & " </tr>"


            Literal1.Text = Literal1.Text & "</table>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 50%'>"
            Literal1.Text = Literal1.Text & "<table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>4 Steering G/Box Boots</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(41) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cracks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cracks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/steering_gbox_boots.png' style='margin-top: -12px; margin-bottom:3px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>5 Exhaust Pipe</h6>"
            Literal1.Text = Literal1.Text & "<div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 75%'>"
            If Lt.Contains(42) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Mount Rubber Cracks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Mount Rubber Cracks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "<img src='image/exhaust_pipe.png' style='margin-top: -12px; margin-bottom:3px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & " < tr >"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>6 Fuel, Brake Line</h6>"
            If Lt.Contains(43) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cuts, Cracks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cuts, Cracks</label></div>"

            End If


            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "< tr >"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "<h6 style='margin-top: 0px; margin-bottom: 0px;'>7 Replacement</h6>"
            If Lt.Contains(44) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Fuel Filter</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Fuel Filter</label></div>"

            End If
            If Lt.Contains(45) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you relieve the fuel pressure?</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you relieve the fuel pressure?</label></div>"

            End If

            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "</table>"
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "</div>"

            Literal1.Text = Literal1.Text & "<div style='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "<div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "<table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='width: 100%; margin: auto;'>"
            Literal1.Text = Literal1.Text & "<p style='margin: auto;'>On The Ground</p>"
            Literal1.Text = Literal1.Text & "</td>"
            Literal1.Text = Literal1.Text & "</tr>"
            Literal1.Text = Literal1.Text & "<tr>"
            Literal1.Text = Literal1.Text & "<td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "            <h6 style='margin-top: 0px; margin-bottom: 0px;'> 1 Wheel Nuts</h6>"
            If Lt.Contains(46) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Tighten the Specified Torque</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Tighten the Specified Torque</label></div>"

            End If
            If Lt.Contains(47) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Ware they tightened as opposing angles to specified torque with a torque wrench?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Ware they tightened as opposing angles to specified torque with a torque wrench?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "         </td>"
            Literal1.Text = Literal1.Text & "    </tr>"
            Literal1.Text = Literal1.Text & "    <tr>"
            Literal1.Text = Literal1.Text & "        <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "           <h6 style='margin-top: 0px; margin-bottom: 0px;'>2 Drain</h6>"
            If Lt.Contains(48) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Coolant (Reverse tank)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Coolant (Reverse tank)</label></div>"

            End If
            Literal1.Text = Literal1.Text & "     </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & " </table>"
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & "   <div style='width: 50%'>"
            Literal1.Text = Literal1.Text & "    <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "        <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "            <h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Refill</h6>"
            If Lt.Contains(49) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Coolant</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Coolant</label></div>"

            End If
            Literal1.Text = Literal1.Text & "       </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "      <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "         <h6 style='margin-top: 0px; margin-bottom: 0px;'> 4 Replacement</h6>"
            Literal1.Text = Literal1.Text & "         <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "            <div style='width: 75%'>"
            If Lt.Contains(50) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Brake Fluid</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Brake Fluid</label></div>"

            End If
            Literal1.Text = Literal1.Text & "        </div>"
            Literal1.Text = Literal1.Text & "        <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "          <img src='image/replacement.png' width='50px' height='40px'/>"
            Literal1.Text = Literal1.Text & "       </div>"
            Literal1.Text = Literal1.Text & "     </div>"
            Literal1.Text = Literal1.Text & " </td>"
            Literal1.Text = Literal1.Text & "  </tr>"

            Literal1.Text = Literal1.Text & "     </table>"
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & "  </div>"

            Literal1.Text = Literal1.Text & " </div>"



            Literal1.Text = Literal1.Text & " <div style ='width: 50%'>"
            Literal1.Text = Literal1.Text & "  <h5 style='margin-top: 0px;margin-bottom: 3px;'>Tech. B</h5>"

            Literal1.Text = Literal1.Text & " <div style ='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "   <div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "      <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "          <tr>"
            Literal1.Text = Literal1.Text & "            <td style='width: 100%; margin: auto; '>"
            Literal1.Text = Literal1.Text & "                <p style='margin: auto;'>Engine Room</p>"
            Literal1.Text = Literal1.Text & "            </td>"
            Literal1.Text = Literal1.Text & "       </tr>"

            Literal1.Text = Literal1.Text & " < tr >"
            Literal1.Text = Literal1.Text & "    <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "       <h6 style='margin-top: 0px; margin-bottom: 0px;'>1 All Lights</h6>"
            Literal1.Text = Literal1.Text & "      <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "         <div style='width: 40%'>"
            If Lt.Contains(51) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Opearation</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Opearation</label></div>"

            End If
            Literal1.Text = Literal1.Text & "       </div>"
            Literal1.Text = Literal1.Text & "      <div style='width: 60%'>"
            Literal1.Text = Literal1.Text & "        <img src='image/all_lights.png' style='margin-top: -10px;margin-bottom:3px' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "     </div>"
            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & "  </tr>"

            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "     <td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "        <h6 style='margin-top: 0px; margin-bottom: 0px;'>2 All Fluid levels and condition </h6>"

            Literal1.Text = Literal1.Text & "      <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "      <div style='width: 75%;display:flex;flex-direction:column'>"
            If Lt.Contains(52) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Power Steering Fluid</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Power Steering Fluid</label></div>"

            End If
            If Lt.Contains(53) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Brake Fluid</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Brake Fluid</label></div>"

            End If

            If Lt.Contains(54) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Coolant</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Coolant</label></div>"

            End If
            If Lt.Contains(55) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Washer</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Washer</label></div>"

            End If
            If Lt.Contains(56) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Engine Oil</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Engine Oil</label></div>"

            End If
            If Lt.Contains(57) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>ATF/label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>ATF/label></div>"

            End If
            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & "   <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "       <img src='image/all_fluid_levels_and_condition.png' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & "  </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "      <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "          <h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Drive Belt</h6>"
            Literal1.Text = Literal1.Text & "         <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "            <div style='width: 75%;display:flex;flex-direction:column'>"
            If Lt.Contains(58) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cracks, damages</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cracks, damages</label></div>"

            End If
            If Lt.Contains(59) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Tension</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Tension</label></div>"

            End If
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "         <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "            <img src='image/drive_belt.png' style='margin-top: -10px;margin-bottom:3px' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "        </div>"
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & "  </table>"
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & "    <div style ='width: 50%'>"
            Literal1.Text = Literal1.Text & "   <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "        <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "           <h6 style='margin-top: 0px; margin-bottom: 0px;'>4 Battery</h6>"
            Literal1.Text = Literal1.Text & "          <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "              <div style='width: 75%;display:flex;flex-direction:column'>"
            If Lt.Contains(60) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Terminal Corrosion and Looseness</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Terminal Corrosion and Looseness</label></div>"

            End If
            If Lt.Contains(61) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Indicator</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Indicator</label></div>"

            End If
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "           <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "              <img src='image/battery.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "          </div>"
            Literal1.Text = Literal1.Text & "     </div>"
            Literal1.Text = Literal1.Text & "    </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & "   <tr>"
            Literal1.Text = Literal1.Text & "    <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "       <h6 style='margin-top: 0px; margin-bottom: 0px;'>5 Check for Oil leak , Water leak</h6>"
            Literal1.Text = Literal1.Text & "       <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "          <div style='width: 55%;display:flex;flex-direction:column'>"
            If Lt.Contains(62) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cylinder Head Cover</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cylinder Head Cover</label></div>"

            End If
            If Lt.Contains(63) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Master Cylinder</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Master Cylinder</label></div>"

            End If
            If Lt.Contains(64) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Power steering Pump</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Power steering Pump</label></div>"

            End If
            If Lt.Contains(65) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Radiator</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Radiator</label></div>"

            End If
            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "<div style='width: 45%'>"
            Literal1.Text = Literal1.Text & "<img src='image/check_for_oil_leak_water_leak.png' style='margin-top: -10px;' width='70px' height='30px'/>"
            Literal1.Text = Literal1.Text & "        </div>"
            Literal1.Text = Literal1.Text & "     </div>"
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & "  </tr>"

            Literal1.Text = Literal1.Text & "    <tr>"
            Literal1.Text = Literal1.Text & "       <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "           <h6 style='margin-top: 0px; margin-bottom: 0px;'>6 Air Cleaner</h6>"
            Literal1.Text = Literal1.Text & "          <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "              <div style='width: 75%'>"
            If Lt.Contains(66) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>The Number of Level clicks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>The Number of Level clicks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "            </div>"
            Literal1.Text = Literal1.Text & "           <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "             <img src='image/air_cleaner.png' style='margin-top: -10px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "          </div>"
            Literal1.Text = Literal1.Text & "      </div>"
            Literal1.Text = Literal1.Text & "  </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "    <tr style='border-bottom:1px solid black'>"
            Literal1.Text = Literal1.Text & "       <td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "           <h6 style='margin-top: 0px; margin-bottom: 0px;'>7 Spark Plugs</h6>"
            Literal1.Text = Literal1.Text & "       <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "            <div style='width: 75%'>"
            If Lt.Contains(67) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>The Number of Level clicks</label></div>"

            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>The Number of Level clicks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "           <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "               <img src='image/spark_plugs.png' style='margin-top: -12px;' width='50px' height='40px'/>"
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "       </div>"
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & " </table>"
            Literal1.Text = Literal1.Text & "       </div>"
            Literal1.Text = Literal1.Text & "   </div>"

            Literal1.Text = Literal1.Text & "   <div style ='display: flex; width: 100%; '>"
            Literal1.Text = Literal1.Text & "   <div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "     <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "       <tr style='border-top: 1px solid black'>"
            Literal1.Text = Literal1.Text & "       <td style='width: 100%; margin: auto; '>"
            Literal1.Text = Literal1.Text & "          <p style='margin: auto;'>Around The Tire (Front Side)</p>"
            Literal1.Text = Literal1.Text & "      </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "   <tr>"
            Literal1.Text = Literal1.Text & "      <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "         <h6 style='margin-top: 0px; margin-bottom: 0px;'>1 Tire</h6>"
            Literal1.Text = Literal1.Text & "     <div style='display: flex; flex-direction: column;'>"
            If Lt.Contains(68) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Wheel Bearing Check</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Wheel Bearing Check</label></div>"

            End If
            If Lt.Contains(69) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Break Drag</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Break Drag</label></div>"

            End If
            If Lt.Contains(70) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cuts,Creaks,Uneven Wear</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cuts,Creaks,Uneven Wear</label></div>"

            End If
            Literal1.Text = Literal1.Text & "  </div>"

            Literal1.Text = Literal1.Text & "   <div style='display: flex; align-items: center; justify-content: center;'>"
            Literal1.Text = Literal1.Text & "        <img src='image/Tire.jpg' width='100px' height='40px'/>"

            Literal1.Text = Literal1.Text & "       </div> "
            Literal1.Text = Literal1.Text & "     <div style='display: flex; justify-content: space-between'>"

            If Lt.Contains(71) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Tread Groove Depth</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Tread Groove Depth</label></div>"

            End If
            If dt3.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right " & dt3.Rows(0)(4) & "mm Left " & dt3.Rows(0)(5) & "mm</label>"
            Else
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right 0mm Left 0mm</label>"

            End If


            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & "  </div>"

            Literal1.Text = Literal1.Text & " </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "  <td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "    <h6 style='margin-top: 0px; margin-bottom: 0px;'>2 Brake pad,Brake</h6>"
            If Lt.Contains(72) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Aren' t the pad surfaces laid directly on the tray?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Aren' t the pad surfaces laid directly on the tray?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "  <div style='display: flex;'>"

            If Lt.Contains(73) Then
                Literal1.Text = Literal1.Text & "<div style='width: 60%;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Were the pads at several points measured?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div style='width: 60%;'><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Were the pads at several points measured?</label></div>"

            End If
            If dt3.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right " & dt3.Rows(0)(6) & "mm Left " & dt3.Rows(0)(7) & "mm</label>"
            Else
                Literal1.Text = Literal1.Text & "<lable style='padding-top: 4px; font-size: 12px; padding-left: 5px;font-size:12px'>Right 0mm Left 0mm</label>"

            End If

            Literal1.Text = Literal1.Text & "</div>"
            Literal1.Text = Literal1.Text & " </div>"
            If Lt.Contains(74) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Did you check wheater callper pins moves smoothly?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Did you check wheater callper pins moves smoothly?</label></div>"

            End If
            If Lt.Contains(75) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Ware the specified locations coated with pad grease?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Ware the specified locations coated with pad grease?</label></div>"

            End If
            If Lt.Contains(76) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span>Was the caliper tightened to the specified torque using a torque wrench?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span>Was the caliper tightened to the specified torque using a torque wrench?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "  </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & "  </table>"
            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & "  <div style ='width: 50%'>"
            Literal1.Text = Literal1.Text & "     <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "        <tr>"
            Literal1.Text = Literal1.Text & "            <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "               <h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Brake Disc</h6>"
            Literal1.Text = Literal1.Text & "              <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "                  <div style='width: 75%'>"
            If Lt.Contains(77) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Creaks,Uneven Wear</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Creaks,Uneven Wear</label></div>"

            End If
            Literal1.Text = Literal1.Text & "                 </div>"
            Literal1.Text = Literal1.Text & "                 <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "                    <img src='image/brake_disk.png' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "                </div>"
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "      </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "    <tr>"
            Literal1.Text = Literal1.Text & "        <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "           <h6 style='margin-top: 0px; margin-bottom: 0px;'>4 Brake Hose</h6>"

            If Lt.Contains(78) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cuts, Cracks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cuts, Cracks</label></div>"

            End If

            Literal1.Text = Literal1.Text & "       </td>"
            Literal1.Text = Literal1.Text & "    </tr>"

            Literal1.Text = Literal1.Text & "      <tr>"
            Literal1.Text = Literal1.Text & "       <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "          <h6 style='margin-top: 0px; margin-bottom: 0px;'>5 Suspension Arm and Bush</h6>"
            Literal1.Text = Literal1.Text & "         <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "             <div style='width: 75%'>"
            If Lt.Contains(79) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Cracks, damages'</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Cracks, damages'</label></div>"

            End If
            Literal1.Text = Literal1.Text & "             </div>"
            Literal1.Text = Literal1.Text & "            <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "               <img src='image/suspension_arm_and_bush.png' width='50px' height='40px'/>"
            Literal1.Text = Literal1.Text & "            </div>"
            Literal1.Text = Literal1.Text & "        </div>"

            Literal1.Text = Literal1.Text & "    </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "    <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "      <h6 style='margin-top: 0px; margin-bottom: 0px;'>6 Damper</h6>"
            Literal1.Text = Literal1.Text & "     <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "         <div style='width: 75%'>"
            If Lt.Contains(80) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Oil leaks</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Oil leaks</label></div>"

            End If
            Literal1.Text = Literal1.Text & "        </div>"
            Literal1.Text = Literal1.Text & "         <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "             <img src='image/damper.png' style='margin-bottom:3px;' width='50px' height='30px'/>"
            Literal1.Text = Literal1.Text & "          </div>"
            Literal1.Text = Literal1.Text & "      </div>"
            Literal1.Text = Literal1.Text & "   </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & "   <tr>"
            Literal1.Text = Literal1.Text & "     <td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "        <h6 style='margin-top: 0px; margin-bottom: 0px;'>7 Checks for play,crackand leaking grease</h6>"
            Literal1.Text = Literal1.Text & "        <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "           <div style='width: 75%; display: flex; flex-direction: column'>"
            If Lt.Contains(81) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Knuckle Joint</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Knuckle Joint</label></div>"

            End If
            If Lt.Contains(82) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Stabilizar Joint</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Stabilizar Joint</label></div>"

            End If
            If Lt.Contains(83) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Tie-rod and Jointg</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Tie-rod and Jointg</label></div>"

            End If
            Literal1.Text = Literal1.Text & "         <img src='image/Check_for_play.jpg' style='margin-left:50px;' width='150px' height='40px'/>"
            Literal1.Text = Literal1.Text & "       </div>"
            Literal1.Text = Literal1.Text & "       <div style='width: 25%'>"

            Literal1.Text = Literal1.Text & "   </div>"
            Literal1.Text = Literal1.Text & "   </div>"

            Literal1.Text = Literal1.Text & " </td>"
            Literal1.Text = Literal1.Text & "  </tr>"

            Literal1.Text = Literal1.Text & "  </table>"
            Literal1.Text = Literal1.Text & "         </div>"
            Literal1.Text = Literal1.Text & "   </div>"

            Literal1.Text = Literal1.Text & "  <div style ='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "   <div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "       <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "          <tr>"
            Literal1.Text = Literal1.Text & "              <td style='width: 100%; margin: auto;'>"
            Literal1.Text = Literal1.Text & "                 <p style='margin: auto;'>Under Car</p>"
            Literal1.Text = Literal1.Text & "            </td>"
            Literal1.Text = Literal1.Text & "        </tr>"

            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "      <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "        <h6 style='margin-top: 0px; margin-bottom: 0px;'>1 Drain</h6>"
            Literal1.Text = Literal1.Text & "       <div style='display:flex'>"
            Literal1.Text = Literal1.Text & "         <div style='display: flex; flex-direction: column;width:75%'>"
            If Lt.Contains(84) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Engine Oil</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Engine Oil</label></div>"

            End If
            If Lt.Contains(85) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>ATF (Car with AT)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>ATF (Car with AT)</label></div>"

            End If
            If Lt.Contains(86) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>CVTF (Car with CVT)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>CVTF (Car with CVT)</label></div>"

            End If
            If Lt.Contains(87) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Coolant</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Coolant</label></div>"

            End If
            If Lt.Contains(88) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you replace the drain wahser?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you replace the drain wahser?</label></div>"

            End If
            If Lt.Contains(89) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you tighten the drain bolt to the specified torque?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you tighten the drain bolt to the specified torque?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "   </div>"

            Literal1.Text = Literal1.Text & "   <div style='display: flex; align-items: center; justify-content: center;width:25%'>"
            Literal1.Text = Literal1.Text & "        <img src='image/under_car_drain.png' width='50px' height='50px'/>"
            Literal1.Text = Literal1.Text & "     </div>"
            Literal1.Text = Literal1.Text & "  </div>"

            Literal1.Text = Literal1.Text & "    </td>"
            Literal1.Text = Literal1.Text & "    </tr>"

            Literal1.Text = Literal1.Text & "   </table>"
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & "  <div style ='width: 50%'>"
            Literal1.Text = Literal1.Text & "   <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "      <tr>"
            Literal1.Text = Literal1.Text & "          <td style='display: flex; flex-direction: column;'>"
            Literal1.Text = Literal1.Text & "            <h6 style='margin-top: 0px; margin-bottom: 0px;'>3 Check for Oil leak</h6>"
            Literal1.Text = Literal1.Text & "           <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "              <div style='width: 50%;display:flex;flex-direction:column'>"
            If Lt.Contains(90) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Engine</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Engine</label></div>"

            End If
            If Lt.Contains(91) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Transmission</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Transmission</label></div>"

            End If
            If Lt.Contains(92) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Steering G/Box</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Steering G/Box</label></div>"

            End If
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "          <div style='width:50%'>"
            Literal1.Text = Literal1.Text & "             <img src='image/check_for_oil_leak.png' width='100px' height='50px'/>"
            Literal1.Text = Literal1.Text & "         </div>"
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & "  </td>"
            Literal1.Text = Literal1.Text & " </tr>"

            Literal1.Text = Literal1.Text & "   </table>"
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & "  </div>"

            Literal1.Text = Literal1.Text & "  <div style ='width: 100%; border-top: 1px solid black; display: flex; flex-direction: column; align-items: flex-start;'>"
            Literal1.Text = Literal1.Text & "      <h6 style='margin-top:0;text-align:left'>2 Replacement</h6>"
            Literal1.Text = Literal1.Text & "     <h6 style ='margin-top:-23px;text-align:left;margin-bottom: 2px;'>  &nbsp &nbsp Oil Filter</h6>"
            If Lt.Contains(93) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you check whether a gasket was left behind in the filter?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you check whether a gasket was left behind in the filter?</label></div>"

            End If
            If Lt.Contains(94) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you clean the sheet?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you clean the sheet?</label></div>"

            End If
            If Lt.Contains(95) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you coat the gasket with engine oil before was installing it?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you coat the gasket with engine oil before was installing it?</label></div>"

            End If
            If Lt.Contains(96) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did ypu tighten to the specified torque/rotation angle?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did ypu tighten to the specified torque/rotation angle?</label></div>"

            End If
            If Lt.Contains(97) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>EnMTF (Car with MT)gine</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>EnMTF (Car with MT)gine</label></div>"

            End If
            Literal1.Text = Literal1.Text & " </div>"

            Literal1.Text = Literal1.Text & " <div style ='display: flex; width: 100%; border-top: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "    <div style='width: 50%; border-right: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "      <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "        <tr>"
            Literal1.Text = Literal1.Text & "         <td style='width: 100%; margin: auto; '>"
            Literal1.Text = Literal1.Text & "         <p style='margin: auto;'>On the Ground</p>"
            Literal1.Text = Literal1.Text & "      </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "    <tr>"
            Literal1.Text = Literal1.Text & "    <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "        <h6 style='margin-top: 0px; margin-bottom: 0px;'>1 Refill</h6>"
            Literal1.Text = Literal1.Text & "        <div style='display: flex; flex-direction: column;'>"
            If Lt.Contains(98) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Engine Oil</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Engine Oil</label></div>"

            End If
            If Lt.Contains(99) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>ATF (Car with AT)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>ATF (Car with AT)</label></div>"

            End If
            If Lt.Contains(100) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>CVTF (Car with CVT)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>CVTF (Car with CVT)</label></div>"

            End If
            If Lt.Contains(101) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'><span>&#x26A0;</span> Did you fill the oil to the specified level?</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'><span>&#x26A0;</span> Did you fill the oil to the specified level?</label></div>"

            End If
            Literal1.Text = Literal1.Text & "    </div>"
            Literal1.Text = Literal1.Text & " </td>"
            Literal1.Text = Literal1.Text & "  </tr>"

            Literal1.Text = Literal1.Text & "  </table>"
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & " <div style ='width: 50%'>"
            Literal1.Text = Literal1.Text & "     <table style='width: 100%;'>"
            Literal1.Text = Literal1.Text & "         <tr>"
            Literal1.Text = Literal1.Text & "             <td style='display: flex; flex-direction: column; '>"
            Literal1.Text = Literal1.Text & "               <h6 style='margin-top: 0px; margin-bottom: 0px;'>2 Fluid Level</h6>"
            Literal1.Text = Literal1.Text & "               <div style='display: flex;'>"
            Literal1.Text = Literal1.Text & "                   <div style='width: 75%;display:flex;flex-direction:column'>"
            If Lt.Contains(102) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>Engine Oil</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>Engine Oil</label></div>"

            End If
            If Lt.Contains(103) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>ATF (Car with AT)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>ATF (Car with AT)</label></div>"

            End If
            If Lt.Contains(104) Then
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled checked/><label style='font-size: 12px;'>CVTF (Car with CVT)</label></div>"
            Else
                Literal1.Text = Literal1.Text & "<div><input type='checkbox' disabled /><label style='font-size: 12px;'>CVTF (Car with CVT)</label></div>"

            End If
            Literal1.Text = Literal1.Text & "                 </div>"
            Literal1.Text = Literal1.Text & "                <div style='width: 25%'>"
            Literal1.Text = Literal1.Text & "                   <img src='image/fluid_level.png' width='50px' height='50px'/>"
            Literal1.Text = Literal1.Text & "               </div>"
            Literal1.Text = Literal1.Text & "           </div>"
            Literal1.Text = Literal1.Text & "      </td>"
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & " </table>"
            Literal1.Text = Literal1.Text & "         </div>"
            Literal1.Text = Literal1.Text & "  </div>"


            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & "   </div>"


            Literal1.Text = Literal1.Text & " <div style ='display:flex; margin-top:5px;margin-right:15px'>"
            Literal1.Text = Literal1.Text & "    <div style='width:50%'>"
            Literal1.Text = Literal1.Text & "      <div style='display: flex; flex-direction:column; width: 100%; border: 1px solid black;'>"
            Literal1.Text = Literal1.Text & "       <div style='border-bottom:1px solid black;padding-bottom:5px'>"
            Literal1.Text = Literal1.Text & "         <h5 style='margin:auto;text-align: left;'>Tech. A</h5>"
            If dt2.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<p style='text-align:left'>" & dt2.Rows(0)(0) & "</p>"
            Else
                Literal1.Text = Literal1.Text & "<p></p>"
            End If


            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & "  <div style='padding-bottom:5px'>"
            Literal1.Text = Literal1.Text & "     <h5 style='margin:auto;text-align: left;'>Tech. B</h5>"
            If dt2.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<p style='text-align:left'>" & dt2.Rows(0)(1) & "</p>"
            Else
                Literal1.Text = Literal1.Text & "<p></p>"
            End If
            Literal1.Text = Literal1.Text & "  </div>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & "  <div style ='width:50%;padding:3px;margin-left:5px'>"
            Literal1.Text = Literal1.Text & " <table style='width:100%; border: 1px solid black; border-collapse: collapse;'>"
            Literal1.Text = Literal1.Text & "    <tr>"
            Literal1.Text = Literal1.Text & "      <th style='border: 1px solid black;'></th>"
            Literal1.Text = Literal1.Text & "      <th style='border: 1px solid black;'>Target Time</th>"
            Literal1.Text = Literal1.Text & "    <th style='border: 1px solid black;'>Actual Time</th>"
            Literal1.Text = Literal1.Text & "   <th style='border: 1px solid black;'>Difference</th>"
            Literal1.Text = Literal1.Text & "  </tr>"
            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "    <td style='border: 1px solid black;'></td>"
            Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'>20,000 KM</td>"
            If dt4.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'>" & dt4.Rows(0)(0) & "</td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'>" & dt4.Rows(0)(1) & "</td>"
            Else
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
            End If

            Literal1.Text = Literal1.Text & "  </tr>"
            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "<td style='border: 1px solid black;'>Inspection of the Ground</td>"
            Literal1.Text = Literal1.Text & "<td style='border: 1px solid black;'>06:30</td>"
            If dt4.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "<td style='border: 1px solid black;'>" & dt4.Rows(0)(2) & "</td>"
                Literal1.Text = Literal1.Text & "<td style='border: 1px solid black;'>" & dt4.Rows(0)(3) & "</td>"
            Else
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
            End If

            Literal1.Text = Literal1.Text & "</tr>"

            Literal1.Text = Literal1.Text & " <tr>"
            Literal1.Text = Literal1.Text & "     <td style='border: 1px solid black;'>The Wheel and Suspension</td>"
            Literal1.Text = Literal1.Text & "     <td style='border: 1px solid black;'>15:50</td>"
            If dt4.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'>" & dt4.Rows(0)(4) & "</td>"
                Literal1.Text = Literal1.Text & "  <td style='border: 1px solid black;'>" & dt4.Rows(0)(5) & "</td>"
            Else

                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
            End If


            Literal1.Text = Literal1.Text & "   </tr>"


            Literal1.Text = Literal1.Text & "   <tr>"
            Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>Undercarriage Check</td>"
            Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>03:50</td>"
            If dt4.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>" & dt4.Rows(0)(6) & "</td>"
                Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>" & dt4.Rows(0)(7) & "</td>"
            Else

                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
            End If

            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>Final Processes</td>"
            Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>03:50</td>"
            If dt4.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "     <td style='border: 1px solid black;'>" & dt4.Rows(0)(8) & "</td>"
                Literal1.Text = Literal1.Text & "     <td style='border: 1px solid black;'>" & dt4.Rows(0)(9) & "</td>"
            Else

                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
            End If


            Literal1.Text = Literal1.Text & " </tr>"
            Literal1.Text = Literal1.Text & "  <tr>"
            Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>Total</td>"
            Literal1.Text = Literal1.Text & "      <td style='border: 1px solid black;'>30:00</td>"
            If dt4.Rows.Count > 0 Then
                Literal1.Text = Literal1.Text & "     <td style='border: 1px solid black;'>" & dt4.Rows(0)(10) & "</td>"
                Literal1.Text = Literal1.Text & "     <td style='border: 1px solid black;'>" & dt4.Rows(0)(11) & "</td>"
            Else
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
                Literal1.Text = Literal1.Text & "   <td style='border: 1px solid black;'></td>"
            End If


            Literal1.Text = Literal1.Text & " </tr>"
            Literal1.Text = Literal1.Text & "   </table>"


            Literal1.Text = Literal1.Text & "   <table style ='width:75%; border: 1px solid black; border-collapse: collapse;margin-top:5px'>"
            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'>OK</th>"
            If Lt.Contains(105) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If
            Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'>Replacement</th>"
            If Lt.Contains(106) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If

            Literal1.Text = Literal1.Text & "        <th style='border: 1px solid black;'>Disassembly</th>"
            If Lt.Contains(107) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If
            Literal1.Text = Literal1.Text & "   </tr>"


            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'>Repair</th>"
            If Lt.Contains(108) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If
            Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'>Adjustmnet</th>"
            If Lt.Contains(109) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If

            Literal1.Text = Literal1.Text & "        <th style='border: 1px solid black;'>Clean</th>"
            If Lt.Contains(110) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If
            Literal1.Text = Literal1.Text & "   </tr>"

            Literal1.Text = Literal1.Text & "     <tr>"
            Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'>Tighten</th>"
            If Lt.Contains(111) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If
            Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'>Lubrication</th>"
            If Lt.Contains(112) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If

            Literal1.Text = Literal1.Text & "        <th style='border: 1px solid black;'>Non-Applicable</th>"
            If Lt.Contains(113) Then
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled checked/><label style='font-size: 12px;'></label></th>"
            Else
                Literal1.Text = Literal1.Text & "         <th style='border: 1px solid black;'><input type='checkbox' disabled /><label style='font-size: 12px;'></label></th>"

            End If
            Literal1.Text = Literal1.Text & "   </tr>"


            Literal1.Text = Literal1.Text & "  </table>"
            Literal1.Text = Literal1.Text & " </div>"
            Literal1.Text = Literal1.Text & "  </div>"


        End If
    End Sub

    Private Sub print_pmsheet_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub
End Class


