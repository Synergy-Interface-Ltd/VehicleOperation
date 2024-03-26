<%@ Page Title="Periodic Maintenance Sheet" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PMSheet.aspx.vb" Inherits="PMSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label1" runat="server" SkinID="header_lbl"
            Text="Periodic Maintenance Sheet"></asp:Label>
    </div>
    <br />

    <div>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="PH Sheet Id"></asp:Label>
                    <asp:TextBox ID="PMSheetID" Width="150px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button100" runat="server" Text="Search" />
                </td>
                <td>
                    <asp:Label runat="server" Text="Regis. No"></asp:Label>
                    <asp:TextBox ID="TextBox1" Width="150px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label runat="server" Text="Date"></asp:Label>
                    <asp:TextBox ID="TextBox2" Width="150px" runat="server"></asp:TextBox>
                    <a id="A2" name="anchor1"
                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox2,'img1','dd/MM/yyyy'); return false;">
                        <img id="img1" src="calendar.gif" />
                    </a>
                </td>
                <td>
                    <asp:Button ID="Button101" runat="server" Text="Search" />
                </td>
            </tr>
        </table>
    </div>

    <br />



    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="SALabel" runat="server" Text="SA Name:"></asp:Label>
                    <asp:TextBox runat="server" Width="200px" ID="SAName"></asp:TextBox>
                    <br />
                    <asp:Label ID="saValid" runat="server" ForeColor="Red" Font-Size="15px"></asp:Label>
                   
                   
                </td>
                <td>
                    <asp:Label Text="Technician Name:" runat="server" ID="TechLabel"></asp:Label>
                    <asp:TextBox runat="server" Width="200px" ID="TechName"></asp:TextBox>
                    <br />
                    <asp:Label ID="techValid" runat="server" ForeColor="Red" Font-Size="15px"></asp:Label>
                   
                </td>
                <td>
                    <asp:Label Text="Date" runat="server"></asp:Label>
                    <asp:TextBox Width="200px" ID="EnterDate" runat="server"></asp:TextBox>
                    <a id="A2" name="anchor1"
                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$EnterDate,'img1','dd/MM/yyyy'); return false;">
                        <img id="img1" src="calendar.gif" />
                    </a>
                    <br />
                     <asp:Label ID="dateValid" runat="server" ForeColor="Red" Font-Size="15px"></asp:Label>
                   
                </td>
                <td>
                    <asp:Label runat="server" ID="RegLabel" Text="Reg No:"></asp:Label>
                    <asp:TextBox runat="server" Width="200px" ID="RegNo"></asp:TextBox>
                    <br />
                     <asp:Label ID="regValid" runat="server" ForeColor="Red" Font-Size="15px"></asp:Label>
                   
                </td>
                <td></td>
            </tr>
        </table>
    </div>

    <div style="display: flex; font-weight: 100; border: 1px solid black;">
        <div style="width: 50%; border-right: 1px solid black">
            <h5 style="margin-top: 0px; margin-bottom: 3px;">Tech. A</h5>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; padding: 8px; border-bottom: 1px solid black;"></td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Warning lamp</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox  runat="server" ID="Check1" TabIndex="1" Text="Opearation"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="Check201" TabIndex="201" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/warning lamp.png"  style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                    
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 Wiper,Wahser</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="Check2" TabIndex="2" Text="Wipe Condition"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="Check202" TabIndex="202" Text="N/A"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/wiper.png" width="50px" style="margin-top: -15px;" height="40px" />
                                    </div>
                                </div>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox runat="server" ID="Check3"  TabIndex="3" Text="Washer nozzle direction,and amount of spray"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/washer.png" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Horn</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="Check4" TabIndex="4" Text="Opearation and Sound"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="Check203" TabIndex="203" Text="N/A"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/horn.png" width="50px" style="margin-top: -15px;" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">4 Elec. System Operation</h6>
                                <asp:CheckBox ID="ESO1" TabIndex="5" runat="server" Text="Power Window"></asp:CheckBox>
                                <asp:CheckBox ID="ESO2" TabIndex="6" runat="server" Text="Power Door Lock"></asp:CheckBox>
                                <asp:CheckBox ID="ESO3" TabIndex="7" runat="server" Text="Power Mirror"></asp:CheckBox>
                                <asp:CheckBox ID="ESO4" TabIndex="8" runat="server" Text="A/C"></asp:CheckBox>
                                <asp:CheckBox ID="ESO5" TabIndex="204" runat="server" Text="N/A"></asp:CheckBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">5 Brake Booster</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox ID="Brake1" runat="server" TabIndex="9" Text="Leak Check"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="Brake2" TabIndex="205" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/brake_booster.png" width="50px" style="margin-top: -15px;" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">6 Steering Wheal</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="Steering1" TabIndex="10" Text="Rotational Play  and Runout"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <asp:CheckBox runat="server" ID="Steering2" TabIndex="206" Text="N/A"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/steering_wheel.png" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">7 Parking Brake</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox runat="server" ID="Parking1" TabIndex="11" Text="The Number of Level clicks"></asp:CheckBox>
                                    </div>
                                     <div style="width: 75%">
                                        <asp:CheckBox runat="server" id="Parking2" TabIndex="207" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/parking_brake.png" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">8 Break Padel</h6>
                                <div style="display: flex;">
                                    <%--<div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox runat="server"  ID="Break1"  TabIndex="12" Text="Free Play"></asp:CheckBox>
                                        <asp:CheckBox runat="server" ID="Break2"  TabIndex="13" Text="Pedal Pad Wear"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/brake_pedal.png" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>--%>
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server"  ID="BreakPadel1"  TabIndex="12" Text="Free Play"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="BreakPadel2" TabIndex="208" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/brake_pedal.png" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                </div>
                                <div style="display:flex">
                                    <asp:CheckBox runat="server" ID="BreakPadel3"  TabIndex="13" Text="Pedal Pad Wear"></asp:CheckBox>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">9 Clutch Pedal</h6>
                                <div style="display: flex;">
                                    <div style="width:50%">
                                        <asp:CheckBox runat="server" ID="ClutchPedal1" TabIndex="14" Text="Free Play"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="ClutchPedal2" TabIndex="209" Text="N/A"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/clutch_pedal.png" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                </div>
                                <div style="display:flex">
                                        <asp:CheckBox runat="server" ID="ClutchPedal3" TabIndex="15" Text="Pedal Pad Wear"></asp:CheckBox>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">10 Tire Air Pressure</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%";>
                                        <asp:CheckBox runat="server" ID="TireAirPressure1" TabIndex="16" Text="Tire"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server" ID="TireAirPressure2" TabIndex="209" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/tire_air_pressure.PNG" style="margin-top: -15px;" width="50px" height="40px" />
                                    </div>
                                </div>
                                <div style="display:flex">
                                    <asp:CheckBox runat="server" ID="TireAirPressure3" TabIndex="17" Text="Spare Tire"></asp:CheckBox>
                                </div>

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div style="width: 100%; border-top: 1px solid black; display: flex; flex-direction: column; align-items: flex-start;">
                <div style="display:flex">
                    <div>
                        <asp:CheckBox TabIndex="18" runat="server" ID="Lift1" Text="Is the vehicle in the center of the lift?"></asp:CheckBox>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="Lift2" TabIndex="210" Text="N/A"></asp:CheckBox>
                    </div>
                </div>
                <asp:CheckBox TabIndex="19" runat="server" ID="Lift3" Text="Are the lift blocks placed at the vehicle's support points?"></asp:CheckBox>
                <asp:CheckBox TabIndex="20" runat="server" ID="Lift4" Text="Are the support points in the center of the lift blocks?"></asp:CheckBox>
                <asp:CheckBox TabIndex="21" runat="server" ID="Lift5" Text="Dis you give verbal notice before raising the lift?"></asp:CheckBox>

            </div>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">Around The Tire (Rear Side)</p>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Tire</h6>
                                <div style="display: flex; flex-direction: column;">
                                    <asp:CheckBox TabIndex="22" runat="server" ID="RearSide1" Text="Wheel Bearing Check"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="23" runat="server" ID="RearSide2" Text="Break Drag"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="24" runat="server" ID="RearSide3" Text="Cuts,Creaks,Uneven Wear"></asp:CheckBox>
                                    <asp:CheckBox runat="server"  ID="RearSide4" TabIndex="242" Text="N/A"></asp:CheckBox>
                                </div>

                                 <div style="display: flex; align-items: center; justify-content: center;">
                                    <img src="image/Tire.jpg" width="100px" height="40px" />
                                </div>
                                <div style="display: flex; /*margin-top: -10px*/">
                                    <asp:CheckBox TabIndex="25" runat="server" ID="RearSide5" Text="Tread Groove Depth"></asp:CheckBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="Right"></asp:Label>
                                    <asp:TextBox ID="ATireRight" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm Left"></asp:Label>
                                    <asp:TextBox ID="ATireLeft" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm"></asp:Label>

                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 Brake pad</h6>
                                <asp:CheckBox TabIndex="26" runat="server" ID="TireBrakepad1" Text="Aren't the pad surfaces laid directly on the tray?"></asp:CheckBox>
                                <div style="display: flex;">
                                    <asp:CheckBox runat="server" ID="TireBrakepad2" TabIndex="26" Text="Were the pads at several points measured?"></asp:CheckBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="Right"></asp:Label>
                                    <asp:TextBox ID="ABrakePadRight" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm Left"></asp:Label>
                                    <asp:TextBox ID="ABrakPadLeft" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm"></asp:Label>
                                </div>
                                <asp:CheckBox TabIndex="27" runat="server" ID="TireBrakepad3" Text="Did you check wheater callper pins moves smoothly?"></asp:CheckBox>
                                <asp:CheckBox TabIndex="28" runat="server" ID="TireBrakepad4" Text="Ware the specified locations coated with pad grease?"></asp:CheckBox>
                                <asp:CheckBox TabIndex="29" runat="server" ID="TireBrakepad5" Text="Was the caliper tightened to the specified torque using a torque wrench?"></asp:CheckBox>
                                <asp:CheckBox runat="server"  ID="TireBrakepad6" TabIndex="243" Text="N/A"></asp:CheckBox>
                            </td>
                        </tr>

                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Brake Disc</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox TabIndex="30" runat="server" ID="BrakeDiscc1" Text="Creaks,Uneven Wear"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="BrakeDiscc2" TabIndex="244" Text="N/A"></asp:CheckBox>
                                    </div>
                                     <div style="width: 25%">
                                        <img src="image/brake_disk.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">4 Brake Hose</h6>
                                <div style="display:flex">
                                    <div style="width:75%">
                                    <asp:CheckBox runat="server" ID="BrakeHosee1" TabIndex="31" Text="Cuts, Cracks"></asp:CheckBox>
                                </div>
                                <div style="width:25%">
                                    <asp:CheckBox runat="server"  ID="BrakeHosee2" TabIndex="245" Text="N/A"></asp:CheckBox>
                                </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">5 Suspension Arm and Bush</h6>
                                 <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox runat="server" ID="SuspensionBush1" TabIndex="32" Text="Cracks, damages"></asp:CheckBox>
                                    </div>
                                     <div style="width:25%">
                                         <asp:CheckBox runat="server"  ID="SuspensionBush2" TabIndex="246" Text="N/A"></asp:CheckBox>
                                     </div>
                                      <div style="width: 25%">
                                        <img src="image/suspension_arm_and_bush.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>

                                
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">6 Damper</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox runat="server" ID="DamperOilleaks1" TabIndex="33" Text="Oil leaks"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                         <asp:CheckBox runat="server"  ID="DamperOilleaks2" TabIndex="247" Text="N/A"></asp:CheckBox>
                                     </div>
                                      <div style="width: 25%">
                                        <img src="image/damper.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">7 Checks for play,crackand leaking grease</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox runat="server" ID="leakinggrease1" TabIndex="34" Text="Knuckle Joint"></asp:CheckBox>
                                        <asp:CheckBox runat="server" ID="leakinggrease2" TabIndex="35" Text="Stabilizar Joint"></asp:CheckBox>
                                        <asp:CheckBox runat="server"  ID="leakinggrease3" TabIndex="248" Text="N/A"></asp:CheckBox>
                                        <img src="image/Check_for_play.jpg" width="100px" height="40px" />
                                    </div>
                                  
                                </div>

                            </td>
                        </tr>

                    </table>
                </div>
            </div>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">Under Car</p>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Stablizer</h6>
                                <div style="display:flex">
                                    <div style="width:50%">
                                        <asp:CheckBox TabIndex="37" runat="server" ID="Stablizer1" Text="Play, Damages"></asp:CheckBox>
                                    </div>
                                    <div style="width:50%">
                                        <asp:CheckBox runat="server"  ID="Stablizer2" TabIndex="213" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 Suspension and Brake Bolts</h6>
                                <div style="display:flex">
                                    <div style="width:50%">
                                        <asp:CheckBox TabIndex="38" runat="server" ID="Suspension1" Text="Looseness"></asp:CheckBox>
                                    </div>
                                    <div style="width:50%">
                                        <asp:CheckBox runat="server"  ID="Suspension2" TabIndex="214" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Drive Shaft Boots</h6>
                                <div style="display: flex">
                                    <div style="width:50%">
                                        <asp:CheckBox TabIndex="39" runat="server" ID="DriveShaft1" Text="Cracks"></asp:CheckBox>
                                    </div>
                                    <div style="width:50%">
                                        <asp:CheckBox runat="server"  ID="DriveShaft2" TabIndex="215" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                                <div style="display: flex">
                                    <div style="width:50%">
                                        <asp:CheckBox TabIndex="40" runat="server" ID="DriveShaft3" Text="Did you check entire circumference of the boots?"></asp:CheckBox>
                                    </div>
                                    <div style="width:50%">
                                        <img src="image/drive_shaft_boots.png" width="50px" height="50px" />
                                    </div>
                                </div>


                            </td>
                        </tr>


                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">4 Steering G/Box Boots</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="SteeringBox1" TabIndex="41" Text="Cracks"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="SteeringBox2" TabIndex="216" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/steering_gbox_boots.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">5 Exhaust Pipe</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="ExhaustPipe1" TabIndex="42" Text="Mount Rubber Cracks"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="ExhaustPipe2" TabIndex="217" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/exhaust_pipe.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">6 Fuel, Brake Line</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="FuelBrake1" TabIndex="43" Text="Cuts, Cracks"></asp:CheckBox>
                                    </div>
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server"  ID="FuelBrake2" TabIndex="218" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">7 Replacement</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox TabIndex="44" runat="server" ID="Replacement1" Text="Fuel Filter"></asp:CheckBox>
                                    </div>
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server"  ID="Replacement2" TabIndex="219" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                                <asp:CheckBox TabIndex="45" runat="server" ID="Replacement3" Text="Did you relieve the fuel pressure?"></asp:CheckBox>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">On The Ground</p>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Wheel Nuts</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox TabIndex="46" runat="server" ID="WheelNuts1" Text="Tighten the Specified Torque"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="WheelNuts2" TabIndex="220" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                                <asp:CheckBox TabIndex="47" runat="server" ID="WheelNuts3" Text="Ware they tightened as opposing angles to specified torque with a torque wrench?"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 Drain</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox TabIndex="48" runat="server" ID="Drain1" Text="Coolant (Reverse tank)"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="Drain2" TabIndex="221" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Refill</h6>
                                <div style="display:flex">
                                    <div style="width:75%">
                                        <asp:CheckBox runat="server" ID="RefillCoolant1" TabIndex="49" Text="Coolant"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="RefillCoolant2" TabIndex="249" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                                
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">4 Replacement</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox runat="server" ID="ReplacementBrake1" TabIndex="50" Text="Brake Fluid"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="ReplacementBrake2" TabIndex="222" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/replacement.png" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>


        <div style="width: 50%">
            <h5 style="margin-top: 0px; margin-bottom: 3px;">Tech. B</h5>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">Engine Room</p>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 All Lights</h6>
                                <div style="display: flex;">
                                    <div style="width: 30%">
                                        <asp:CheckBox TabIndex="51" runat="server" ID="AllLights1" Text="Opearation"></asp:CheckBox>
                                    </div>
                                    <div style="width: 20%">
                                        <asp:CheckBox runat="server"  ID="AllLights2" TabIndex="223" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 50%">
                                        <img src="image/all_lights.png" style="margin-top: -15px" width="100px" height="50px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 All Fluid levels and condition </h6>

                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <div style="display: flex;">
                                    <div style="width: 80%">
                                        <asp:CheckBox TabIndex="52" runat="server" ID="Fluidcondition1" Text="Power Steering Fluid"></asp:CheckBox>
                                    </div>
                                    <div style="width: 20%">
                                        <asp:CheckBox runat="server"  ID="Fluidcondition2" TabIndex="224" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                                        <asp:CheckBox TabIndex="53" runat="server" ID="Fluidcondition3" Text="Brake Fluid"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="54" runat="server" ID="Fluidcondition4" Text="Coolant"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="55" runat="server" ID="Fluidcondition5" Text="Washer"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="56" runat="server" ID="Fluidcondition6" Text="Engine Oil"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="57" runat="server" ID="Fluidcondition7" Text="ATF"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/all_fluid_levels_and_condition.png" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Drive Belt</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox TabIndex="58" runat="server" ID="DriveBelt1" Text="Cracks, damages"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="59" runat="server" ID="DriveBelt2" Text="Tension"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="DriveBelt3" TabIndex="225" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/drive_belt.png" style="margin-top: -15px" width="50px" height="50px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">4 Battery</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox TabIndex="60" runat="server" ID="Battery1" Text="Terminal Corrosion and Looseness"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="61" runat="server" ID="Battery2" Text="Indicator"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                       <asp:CheckBox runat="server"  ID="Battery3" TabIndex="226" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/battery.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">5 Check for Oil leak , Water leak</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox TabIndex="62" runat="server" ID="OilWaterleak1" Text="Cylinder Head Cover"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="63" runat="server" ID="OilWaterleak2" Text="Master Cylinder"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="64" runat="server" ID="OilWaterleak3" Text="Power steering Pump"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="65" runat="server" ID="OilWaterleak4" Text="Radiator"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="OilWaterleak5" TabIndex="227" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/check_for_oil_leak_water_leak.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">6 Air Cleaner</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox TabIndex="66" runat="server" ID="AirCleaner1" Text="The Number of Level clicks"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="AirCleaner2" TabIndex="228" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/air_cleaner.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">7 Spark Plugs</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%">
                                        <asp:CheckBox runat="server" ID="SparkPlugs1" TabIndex="67" Text="The Number of Level clicks"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="SparkPlugs2" TabIndex="229" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/spark_plugs.png" style="margin-top: -15px" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">Around The Tire (Front Side)</p>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Tire</h6>
                                <div style="display:flex">
                                    <div style="width:75% ;display: flex; flex-direction: column;">
                                    <asp:CheckBox TabIndex="68" runat="server" ID="AroundTire1" Text="Wheel Bearing Check"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="69" runat="server" ID="AroundTire2" Text="Break Drag"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="70" runat="server" ID="AroundTire3" Text="Cuts,Creaks,Uneven Wear"></asp:CheckBox>
                                </div>
                                <div style="width:25%;display: flex;">
                                    <asp:CheckBox runat="server"  ID="AroundTire4" TabIndex="230" Text="N/A"></asp:CheckBox>
                                </div>
                                </div>
                                
                                <div style="display: flex; align-items: center; justify-content: center;">
                                    <img src="image/Tire.jpg" width="100px" height="40px" />
         
                                </div>
                                <div style="display: flex; /*margin-top: -10px*/">
                                    <asp:CheckBox TabIndex="71" runat="server" ID="AroundTire5" Text="Tread Groove Depth"></asp:CheckBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="Right"></asp:Label>
                                    <asp:TextBox ID="BTireRight" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm Left"></asp:Label>
                                    <asp:TextBox ID="BTireLeft" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm"></asp:Label>
                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 Brake pad,Brake</h6>
                                <asp:CheckBox TabIndex="72" runat="server" ID="Brakepad6" Text="Aren't the pad surfaces laid directly on the tray?"></asp:CheckBox>
                                <div style="display: flex;">
                                    <asp:CheckBox TabIndex="73" runat="server" ID="Brakepad1" Text="Were the pads at several points measured?"></asp:CheckBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="Right"></asp:Label>
                                    <asp:TextBox ID="BBrakePadRight" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm Left"></asp:Label>
                                    <asp:TextBox ID="BBrakPadLeft" Style="padding-top: 4px; padding-left: 5px;" runat="server" Height="10px" Width="30px"></asp:TextBox>
                                    <asp:Label Style="padding-top: 4px; padding-left: 5px;" runat="server" Text="mm"></asp:Label>
                                </div>
                                <asp:CheckBox TabIndex="74" runat="server" ID="Brakepad2" Text="Did you check wheater callper pins moves smoothly?"></asp:CheckBox>
                                <asp:CheckBox TabIndex="75" runat="server" ID="Brakepad3" Text="Ware the specified locations coated with pad grease?"></asp:CheckBox>
                                <asp:CheckBox TabIndex="76" runat="server" ID="Brakepad4" Text="Was the caliper tightened to the specified torque using a torque wrench?"></asp:CheckBox>
                                <asp:CheckBox runat="server"  ID="Brakepad5" TabIndex="231" Text="N/A"></asp:CheckBox>
                            </td>
                        </tr>

                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Brake Disc</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox TabIndex="77" runat="server" ID="BrakeDisc1" Text="Creaks,Uneven Wear"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="BrakeDisc2" TabIndex="232" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/brake_disk.png" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">4 Brake Hose</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox TabIndex="78" runat="server" ID="BrakeHose1" Text="Cuts, Cracks"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="BrakeHose2" TabIndex="233" Text="N/A"></asp:CheckBox>
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">5 Suspension Arm and Bush</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox TabIndex="79" runat="server" ID="SuspensionArm1" Text="Cracks, damages"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="SuspensionArm2" TabIndex="234" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/suspension_arm_and_bush.png" width="50px" height="40px" />
                                    </div>
                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column; border-bottom: 1px solid black;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">6 Damper</h6>
                                <div style="display: flex;">
                                    <div style="width: 50%">
                                        <asp:CheckBox TabIndex="80" runat="server" ID="Damper1" Text="Oil leaks"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <asp:CheckBox runat="server"  ID="Damper2" TabIndex="235" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/damper.png" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">7 Checks for play,crackand leaking grease</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox TabIndex="81" runat="server" ID="crackandgrease1" Text="Knuckle Joint"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="82" runat="server" ID="crackandgrease2" Text="Stabilizar Joint"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="83" runat="server" ID="crackandgrease3" Text="Tie-rod and Joint"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="crackandgrease4" TabIndex="236" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/Check_for_play.jpg" width="50px" height="40px" />
                                    </div>
                                </div>

                            </td>
                        </tr>

                    </table>
                </div>
            </div>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">Under Car</p>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Drain</h6>
                                <div style="display: flex">
                                    <div style="display: flex; flex-direction: column; width: 75%">
                                        <asp:CheckBox TabIndex="84" runat="server" ID="DrainDderCar1" Text="Engine Oil"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="85" runat="server" ID="DrainDderCar2" Text="ATF (Car with AT)"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="86" runat="server" ID="DrainDderCar3" Text="CVTF (Car with CVT)"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="87" runat="server" ID="DrainDderCar4" Text="Coolant"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="88" runat="server" ID="DrainDderCar5" Text="Did you replace the drain wahser?"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="89" runat="server" ID="DrainDderCar6" Text="Did you tighten the drain bolt to the specified torque?"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="DrainDderCar7" TabIndex="237" Text="N/A"></asp:CheckBox>
                                    </div>

                                    <div style="display: flex; align-items: center; justify-content: center; width: 25%">
                                        <img src="image/Drain.jpg" width="50px" height="50px" />
                                    </div>
                                </div>

                            </td>
                        </tr>

                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">3 Check for Oil leak</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox TabIndex="90" runat="server" ID="Oilleak1" Text="Engine"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="91" runat="server" ID="Oilleak2" Text="Transmission"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="92" runat="server" ID="Oilleak3" Text="Steering G/Box"></asp:CheckBox>
                                    </div>
                                    <div style="width:25%">
                                        <asp:CheckBox runat="server"  ID="Oilleak4" TabIndex="238" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/check_for_oil_leak.png" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

            <div style="width: 100%; border-top: 1px solid black; display: flex; flex-direction: column; align-items: flex-start;">
                <h6 style="margin-top: 0; text-align: left">2 Replacement</h6>
                <h6 style="margin-top: -23px; text-align: left; margin-bottom: 2px;">&nbsp &nbsp Oil Filter</h6>
                <asp:CheckBox TabIndex="93" runat="server" ID="ReplacementOilFilter1" Text="Did you check whether a gasket was left behind in the filter?"></asp:CheckBox>
                <asp:CheckBox TabIndex="94" runat="server" ID="ReplacementOilFilter2" Text="Did you clean the sheet?"></asp:CheckBox>
                <asp:CheckBox TabIndex="95" runat="server" ID="ReplacementOilFilter3" Text="Did you coat the gasket with engine oil before was installing it?"></asp:CheckBox>
                <asp:CheckBox TabIndex="96" runat="server" ID="ReplacementOilFilter4" Text="Did ypu tighten to the specified torque/rotation angle?"></asp:CheckBox>
                <asp:CheckBox TabIndex="97" runat="server" ID="ReplacementOilFilter5" Text="MTF (Car with MT)"></asp:CheckBox>
                <asp:CheckBox runat="server"  ID="ReplacementOilFilter6" TabIndex="239" Text="N/A"></asp:CheckBox>
            </div>

            <div style="display: flex; width: 100%; border-top: 1px solid black;">
                <div style="width: 50%; border-right: 1px solid black;">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; margin: auto; border-bottom: 1px solid black;">
                                <p style="margin: auto;">On the Ground</p>
                            </td>
                        </tr>

                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">1 Refill</h6>
                                <div style="display: flex; flex-direction: column;">
                                    <asp:CheckBox TabIndex="98" runat="server" ID="Refill1" Text="Engine Oil"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="99" runat="server" ID="Refill2" Text="ATF (Car with AT)"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="100" runat="server" ID="Refill3" Text="CVTF (Car with CVT)"></asp:CheckBox>
                                    <asp:CheckBox TabIndex="101" runat="server" ID="Refill4" Text="Did you fill the oil to the specified level?"></asp:CheckBox>
                                    <asp:CheckBox runat="server"  ID="Refill5" TabIndex="240" Text="N/A"></asp:CheckBox>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
                <div style="width: 50%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="display: flex; flex-direction: column;">
                                <h6 style="margin-top: 0px; margin-bottom: 0px;">2 Fluid Level</h6>
                                <div style="display: flex;">
                                    <div style="width: 75%; display: flex; flex-direction: column">
                                        <asp:CheckBox TabIndex="102" runat="server" ID="FluidLevel1" Text="Engine Oil"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="103" runat="server" ID="FluidLevel2" Text="ATF (Car with AT)"></asp:CheckBox>
                                        <asp:CheckBox TabIndex="104" runat="server" ID="FluidLevel3" Text="CVTF (Car with CVT)"></asp:CheckBox>
                                        <asp:CheckBox runat="server"  ID="FluidLevel4" TabIndex="241" Text="N/A"></asp:CheckBox>
                                    </div>
                                    <div style="width: 25%">
                                        <img src="image/fluid_level.png" width="50px" height="40px" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>


        </div>
    </div>


    <div style="display: flex; margin-top: 5px;">
        <div style="width: 50%">
            <div style="display: flex; flex-direction: column; width: 100%; border: 1px solid black;">
                <div style="border-bottom: 1px solid black; padding-bottom: 5px">
                    <h5 style="margin: auto; text-align: left;">Tech. A</h5>
                    <asp:TextBox ID="TechA" runat="server" TextMode="MultiLine"
                        Columns="50"
                        Rows="5" Style="width: 98%; height: 40px;">

                    </asp:TextBox>
                </div>
                <div style="padding-bottom: 5px">
                    <h5 style="margin: auto; text-align: left;">Tech. B</h5>
                    <asp:TextBox ID="TechB" TextMode="MultiLine"
                        Columns="50"
                        Rows="5" runat="server" Style="width: 98%; height: 40px;">

                    </asp:TextBox>
                </div>
            </div>
        </div>
        <div style="width: 50%; padding: 3px; margin-left: 5px">
            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                <tr>
                    <th style="border: 1px solid black;"></th>
                    <th style="border: 1px solid black;">Target Time</th>
                    <th style="border: 1px solid black;">Actual Time</th>
                    <th style="border: 1px solid black;">Difference</th>
                </tr>
                <tr>
                    <td style="border: 1px solid black;"></td>
                    <td style="border: 1px solid black;">20,000 KM</td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FirstAT" runat="server"></asp:TextBox>
                    </td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FirstD" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px solid black;">Inspection of the Ground</td>
                    <td style="border: 1px solid black;">06:30</td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="SecAT" runat="server"></asp:TextBox>
                    </td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="SecD" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="border: 1px solid black;">The Wheel and Suspension</td>
                    <td style="border: 1px solid black;">15:50</td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="ThirdAT" runat="server"></asp:TextBox>
                    </td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="ThirdD" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px solid black;">Undercarriage Check</td>
                    <td style="border: 1px solid black;">03:50</td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FourAT" runat="server"></asp:TextBox>
                    </td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FourD" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="border: 1px solid black;">Final Processes</td>
                    <td style="border: 1px solid black;">03:50</td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FifthAT" runat="server"></asp:TextBox>
                    </td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FifthD" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="border: 1px solid black;">Total</td>
                    <td style="border: 1px solid black;">30:00</td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FinalAT" runat="server"></asp:TextBox>
                    </td>
                    <td style="border: 1px solid black;">
                        <asp:TextBox ID="FinalD" runat="server"></asp:TextBox>
                    </td>
                </tr>

            </table>


            <table style="width: 75%; border: 1px solid black; border-collapse: collapse; margin-top: 5px">
                <tr>
                    <th style="border: 1px solid black;">OK </th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox TabIndex="105" ID="OK" runat="server"></asp:CheckBox></th>
                    <th style="border: 1px solid black;">Replacement</th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox TabIndex="106" ID="Replacement" runat="server"></asp:CheckBox></th>
                    <th style="border: 1px solid black;">Disassembly</th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox TabIndex="107" ID="Disassembly" runat="server"></asp:CheckBox></th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">Repair </th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox ID="Repair" TabIndex="108" runat="server"></asp:CheckBox></th>
                    <th style="border: 1px solid black;">Adjustmnet</th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox ID="Adjustmnet" TabIndex="109" runat="server"></asp:CheckBox></th>
                    <th style="border: 1px solid black;">Clean</th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox ID="Clean" TabIndex="110" runat="server"></asp:CheckBox></th>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">Tighten </th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox ID="Tighten" TabIndex="111" runat="server"></asp:CheckBox></th>
                    <th style="border: 1px solid black;">Lubrication</th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox ID="Lubrication" TabIndex="112" runat="server"></asp:CheckBox></th>
                    <th style="border: 1px solid black;">Non-Applicable</th>
                    <th style="border: 1px solid black;">
                        <asp:CheckBox ID="Applicable" TabIndex="113" runat="server"></asp:CheckBox></th>
                </tr>



            </table>
        </div>
    </div>

    <asp:Button runat="server" AutoPostBack="True" ID="Button10" Text="Submit" />
    <asp:Button runat="server" AutoPostBack="True" ID="Button11" Text="Edit" />
    <asp:Button runat="server" AutoPostBack="True" ID="Button13" Text="Print" />

    <asp:Button ID="Button6" runat="server" Text="Button" />




</asp:Content>

