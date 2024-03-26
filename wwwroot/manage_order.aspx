<%@ Page Title="Manage Order" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="manage_order.aspx.vb" Inherits="manage_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl" 
            Text="Manage Order"></asp:Label>
    </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager><asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="1">
            <ProgressTemplate>
            <div align="center" style="width: 100% ; position: absolute; top: 0px; left: 0px; z-index:4"><asp:Image ID="Image4" runat="server" ImageUrl="~/image/loading.gif"  
                /></div>
                 </ProgressTemplate>
            </asp:UpdateProgress>
                 <br />
    <table border="0" cellpadding="1" cellspacing="2">
       
        <tr>
            <td align="left" valign="top" colspan="2">
                <asp:Label ID="Label30" runat="server" EnableTheming="False" Font-Bold="True" 
                    Font-Names="Calibri" Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
    runat="server" ControlToValidate="TextBox3" Display="None" 
    ErrorMessage="Please Enter Valid Mail ID..." SetFocusOnError="True" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
    ValidationGroup="s"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="TextBox6" Display="None" 
            ErrorMessage="Please Enter Valid In Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="s"></asp:RegularExpressionValidator>
        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
            ControlToValidate="TextBox25" Display="None" 
            ErrorMessage="Please Enter Valid Advance Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="s"></asp:RegularExpressionValidator>--%>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="TextBox7" Display="None" 
            ErrorMessage="Please Enter Valid Delivery Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="s"></asp:RegularExpressionValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="TextBox25" Display="None" 
                    ErrorMessage="Please Enter Advance Date..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox6" Display="None" 
                    ErrorMessage="Please Enter In Date..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox7" Display="None" 
                    ErrorMessage="Please Enter Delivery Date..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox1" Display="None" 
                    ErrorMessage="Please Enter Customer Name..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBox5" Display="None" 
                    ErrorMessage="Please Enter Mobile No..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="TextBox9" Display="None" 
                    ErrorMessage="Please Enter Reg No..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="TextBox11" Display="None" 
                    ErrorMessage="Please Enter Eng. No..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="TextBox12" Display="None" 
                    ErrorMessage="Please Enter Chesis No..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="TextBox13" Display="None" ErrorMessage="Please Enter KM..." 
                    SetFocusOnError="True" ValidationGroup="s"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="TextBox10" Display="None" 
                    ErrorMessage="Please Enter Model No..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <tr>
            <td align="center" valign="top" style="border: 1px solid #333333">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="0">
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label1" runat="server" Text="Customer's Name :"></asp:Label>
                                </td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="418px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label2" runat="server" Text="Address :"></asp:Label>
                                </td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:TextBox ID="TextBox2" runat="server" Height="115px" TextMode="MultiLine" 
                                        Width="416px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label3" runat="server" Text="Email :"></asp:Label>
                                    <asp:Button ID="Button1" runat="server" Text="Button" />
                                </td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:TextBox ID="TextBox3" runat="server" Width="418px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Tel No. :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label5" runat="server" Text="Mobile No. :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TextBox5" runat="server" Width="176px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="display: none">
                                    <asp:Label ID="Label6" runat="server" Text="Date (In) :"></asp:Label>
                                </td>
                                <td align="left" valign="top" style="display: none">
                                    <asp:TextBox ID="TextBox6" runat="server" Width="103px"></asp:TextBox>
                                    <a ID="A1" name="anchor1" 
                                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox6,'img2','dd/MM/yyyy'); return false;">
                <img id="img2" src="calendar.gif" /></a>
                                </td>
                                <td align="left" valign="top" style="display: none">
                                    <asp:Label ID="Label7" runat="server" Text="Time In. :"></asp:Label>
                                </td>
                                <td align="left" valign="top" style="display: none">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label8" runat="server" Text="Hr."></asp:Label>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label9" runat="server" Text="Min."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="display: none">
                                    <asp:Label ID="Label10" runat="server" Text="Delivery Date :"></asp:Label>
                                </td>
                                <td align="left" valign="top" style="display: none">
                                    <asp:TextBox ID="TextBox7" runat="server" Width="103px"></asp:TextBox>
                                    <a ID="A2" name="anchor1" 
                                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox7,'img1','dd/MM/yyyy'); return false;">
                <img id="img1" src="calendar.gif" /></a>
                                </td>
                                <td align="left" valign="top" style="display: none">
                                    <asp:Label ID="Label11" runat="server" Text="Delivery Time :"></asp:Label>
                                </td>
                                <td align="left" valign="top" style="display: none">
                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label12" runat="server" Text="Hr."></asp:Label>
                                    <asp:DropDownList ID="DropDownList4" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label13" runat="server" Text="Min."></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button20" EventName="Click" />
                     <asp:AsyncPostBackTrigger ControlID="DropDownList10" EventName="SelectedIndexChanged" />
                       <asp:AsyncPostBackTrigger ControlID="Button21" EventName="Click" />
                       <%--<asp:PostBackTrigger ControlID="Button21" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td align="left" valign="top" style="border: 1px solid #000000">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="0" style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label69" runat="server" Text="Job ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox45" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button21" runat="server" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Text="Estimated Job ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox27" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button10" runat="server" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="Estimated Job ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label33" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="Manual RO No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox14" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button9" runat="server" Text="Search" />
                                </td>
                            </tr>
                            <tr >
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="Estimate No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label35" runat="server"></asp:Label>
                                    <asp:Label ID="Label48" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Vehicle :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox8" runat="server" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label15" runat="server" Text="Reg No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox9" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button8" runat="server" Text="Search" />
                                    <br />
                                    <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" 
                                        Width="189px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="Model :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox10" runat="server" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="Eng No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox11" runat="server" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="Chesis No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox12" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button20" runat="server" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="KM :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox13" runat="server" Width="195px"></asp:TextBox>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="Order Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="StatusDropdown" runat="server" Width="140px"></asp:DropDownList>
                                     <asp:Button ID="StatusButton" AutoPostBack="True" runat="server" Text="Search" />
                                </td>
                            </tr>
                              <tr>
                                <td>
                                    <asp:Label ID="Label37" runat="server" Text="Order Id:"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="TextBox16" runat="server" Width="135px"></asp:TextBox>
                                     <asp:Button ID="OrderSearchButton" CausesValidation="False"  runat="server" Text="Search" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="Button21" EventName="Click" />
                      <%--<asp:PostBackTrigger ControlID="Button21" />--%>
                        <asp:AsyncPostBackTrigger ControlID="Button20" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="DropDownList10" EventName="SelectedIndexChanged" />
                    
                    
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            
        </tr>    
    </table>
    <asp:UpdatePanel ID="UpdatePanel122" runat="server" RenderMode="Inline"
        UpdateMode="Conditional">
        <contenttemplate>
            <table>

                <tr>
                    <th style="display: flex" align="left" valign="top" colspan="2">

                        <div style="width: 110px">
                            <asp:Label ID="Label22" runat="server" Text="Order Id :"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:TextBox ID="OrderId" runat="server" Width="170px"></asp:TextBox>
                        </div>

                        <div style="width: 100px">
                            <asp:Label ID="Label23" runat="server" Text="Job Id:"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:TextBox ID="JobId" runat="server" Width="170px"></asp:TextBox>
                        </div>

                        <divc style="width: 90px">
                            <asp:Label ID="Label24" runat="server" Text="Part Id :"></asp:Label>
                        </divc>

                        <div style="width: 180px">
                            <asp:TextBox ID="PartId" runat="server" Width="170px"></asp:TextBox>
                        </div>

                        <div style="width: 70px">
                            <asp:Label ID="Label25" runat="server" Text="Part No :"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:TextBox ID="PartNo" runat="server" Width="170px"></asp:TextBox>
                        </div>

                        <div style="width: 70px">
                            <asp:Label ID="Label26" runat="server" Text="Part Name :"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:TextBox ID="PartName" runat="server" Width="170px"></asp:TextBox>
                        </div>

                    </th>
                </tr>

                <tr>
                    <th style="display: flex; margin-top: 20px" align="left" valign="top" colspan="2">


                        <div style="width: 110px">
                            <asp:Label ID="Label27" Width="120px" runat="server" Text="Apx. Delivary Date :"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:TextBox ID="TextBox15" runat="server" Width="150px"></asp:TextBox>
                            <a id="A2" name="anchor1"
                                onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox15,'img1','dd/MM/yyyy'); return false;">
                                <img id="img1" src="calendar.gif" />
                            </a>
                        </div>
                        <div style="width: 100px">
                            <asp:Label ID="Label28" runat="server" Text="Supplier Type:"></asp:Label>
                        </div>
                        <div style="width: 180px">
                            <asp:DropDownList ID="Dropdownlist5" AutoPostBack="True" runat="server" Width="170px"></asp:DropDownList>

                        </div>
                        <div style="width: 90px">
                            <asp:Label ID="Label29" runat="server" Text="Supplier Name:"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:DropDownList ID="Dropdownlist6" runat="server" Width="170px"></asp:DropDownList>
                        </div>

                        <div style="width: 70px">
                            <asp:Label ID="Label36" runat="server" Text="Status:"></asp:Label>
                        </div>

                        <div style="width: 180px">
                            <asp:DropDownList ID="Dropdownlist7" runat="server" Width="170px"></asp:DropDownList>
                        </div>
                        <div style="width: 180px">
                            <asp:Button runat="server" AutoPostBack="True" ID="Button2" Text="Submit" />
                        </div>
                    </th>
                </tr>


                <tr>

                    <td align="left" valign="top" colspan="2" style="border: 1px solid #333333">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="id" HeaderText="Order Id" />
                                <asp:BoundField DataField="estimate_job_id" HeaderText="Estimate ID" />
                                <asp:BoundField DataField="parts_id" HeaderText="Parts ID" />
                                <asp:BoundField DataField="parts_no" HeaderText="Parts No" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="order_quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="Available Quantity" HeaderText="Available Quantity" />
                                <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                                <asp:BoundField DataField="app_delivery_date" HeaderText="Apx.Delivary Date" />

                                <asp:BoundField DataField="Supplier Type" HeaderText="Supplier Type" />
                                <asp:BoundField DataField="supplier_id" HeaderText="Supplier Id" />
                                <asp:BoundField DataField="Supplier Name" HeaderText="Supplier Name" />
                                <asp:BoundField DataField="reference_by" HeaderText="Reference" />
                                <asp:BoundField DataField="placed_by" HeaderText="Placed By" />
                                <asp:BoundField DataField="StatusId" HeaderText="Order Status" />
                                <asp:BoundField DataField="order_status" HeaderText="OrderStatusId" />
                                <asp:BoundField DataField="store_order_date" HeaderText="Store Order Date" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <%-- <asp:TemplateField  HeaderText="Order Quantity">
                             <ItemTemplate>
                                 <asp:TextBox Text='<%#Eval("OrderLimit") %>'  ID="TextBox15" runat="server" ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>--%>
                            </columns>
                        </asp:GridView>
                    </td>
                </tr>
                <%-- <tr>
            <td colspan="5" align="center">
                <asp:Button runat="server" ID="SubmitButton" Text="Submit" />
                <asp:Button runat="server" ID="EditButton" Text="Edit" />
                <asp:Button runat="server" ID="DeleteButton" Text="Delete" />
            </td>
        </tr>--%>
            </table>

        </contenttemplate>

    </asp:UpdatePanel>
</asp:Content>



