<%@ Page Title="Create Job Sheet" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="job_card.aspx.vb" Inherits="job_card" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script>
        document.addEventListener("DOMContentLoaded", function () {
            document.addEventListener("keydown", function (e) {
                if (e.keyCode === 13 && e.target.tagName === "INPUT" && e.target.type === "text") {
                    e.preventDefault();
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl" 
            Text="Create Job Sheet"></asp:Label>
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
                    Font-Names="Calibri" Font-Size="Small" ForeColor="Red"></asp:Label>
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
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
            ControlToValidate="TextBox25" Display="None" 
            ErrorMessage="Please Enter Valid Advance Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="s"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="TextBox7" Display="None" 
            ErrorMessage="Please Enter Valid Delivery Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="s"></asp:RegularExpressionValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="TextBox25" Display="None" 
                    ErrorMessage="Please Enter Advance Date..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
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
                                    <asp:Label ID="Label62" runat="server" Text="Customer's ID :"></asp:Label>
                                </td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:Label ID="Label63" runat="server"></asp:Label>
                                </td>
                            </tr>
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
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="right" valign="top">
                                    <asp:Button ID="Button21" runat="server" Text="Update" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" valign="top">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label70" runat="server" Text="Change Customer By ID :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TextBox45" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Button ID="Button19" runat="server" Text="Change" />
                                </td>
                                <td align="left" valign="top">
                                    <asp:Button ID="Button18" runat="server" Text="Add as New Customer" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" valign="top">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="2" cellspacing="0">
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label6" runat="server" Text="Date (In) :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TextBox6" runat="server" Width="103px"></asp:TextBox>
                                    <a ID="A1" name="anchor1" 
                                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox6,'img2','dd/MM/yyyy'); return false;">
                                    <img id="img2" src="calendar.gif" />
                                    </a>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="Label7" runat="server" Text="Time In. :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label8" runat="server" Text="Hr."></asp:Label>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label9" runat="server" Text="Min."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="display: none" valign="top">
                                    <asp:Label ID="Label10" runat="server" Text="Delivery Date :"></asp:Label>
                                </td>
                                <td align="left" style="display: none" valign="top">
                                    <asp:TextBox ID="TextBox7" runat="server" Width="103px"></asp:TextBox>
                                    <a ID="A2" name="anchor1" 
                                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox7,'img1','dd/MM/yyyy'); return false;">
                                    <img id="img1" src="calendar.gif" />
                                    </a>
                                </td>
                                <td align="left" style="display: none" valign="top">
                                    <asp:Label ID="Label11" runat="server" Text="Delivery Time :"></asp:Label>
                                </td>
                                <td align="left" style="display: none" valign="top">
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
                        <asp:AsyncPostBackTrigger ControlID="Button15" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="Button20" EventName="Click" />
                
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
                                    <asp:Label ID="Label64" runat="server" Text="Customer ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox39" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button15" runat="server" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Text="Automatic Job ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox27" runat="server" Width="123px"></asp:TextBox>
                                    <asp:Button ID="Button10" runat="server" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="Automatic Job ID :"></asp:Label>
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
                            <tr>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="Bill No :"></asp:Label>
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
                                <td align="left" valign="top">
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
                                    <asp:TextBox ID="TextBox13" runat="server" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label68" runat="server" Text="Sales Executive :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox44" runat="server" Width="189px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label69" runat="server" Text="Type of Customer :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList11" runat="server" Width="189px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button15" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <table style="width:100%;" border="0" cellpadding="1" cellspacing="2">
                    <tr>
                        <td align="left" valign="top" colspan="2" style="border: 1px solid #000000">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label50" runat="server" Text="Technician :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList7" runat="server" Width="128px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td align="right" valign="top">
                                                <asp:Label ID="Label61" runat="server" Text="Engineer :" Width="150px"></asp:Label>
                                                &nbsp;<asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                                <asp:Label ID="Label60" runat="server" Font-Bold="True" Text="Search / Manually Add Services :" 
                                                    Width="232px"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text="Service Category :" 
                                                    Width="200px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" Text="Car Type :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" Text="Service Type :" Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                    ControlToValidate="TextBox18" Display="None" 
                                                    ErrorMessage="Please Enter Service Type..." SetFocusOnError="True" 
                                                    ValidationGroup="service"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                    ControlToValidate="TextBox30" Display="None" 
                                                    ErrorMessage="Please Enter Service Charge..." SetFocusOnError="True" 
                                                    ValidationGroup="service"></asp:RequiredFieldValidator>
                                                <asp:Button ID="Button2" runat="server" Text="Search" Width="80px" />
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="service" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label51" runat="server" Text="Qty of Service :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label49" runat="server" Text="Service Charge :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                                                <asp:Button ID="Button12" runat="server" Text="Add" ValidationGroup="service" 
                                                    Width="80px" />
                                                <asp:Label ID="Label27" runat="server" Text="Search By Service ID :" 
                                                    Visible="False" Width="167px"></asp:Label>
                                                <asp:TextBox ID="TextBox20" runat="server" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="border: 0px solid #000000; width: 1051px; overflow: auto;">
                                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Service ID" HeaderText="Service ID" />
                                                            <asp:BoundField DataField="Service Category" HeaderText="Service Category" />
                                                            <asp:BoundField DataField="Service Type" HeaderText="Service Type" />
                                                            <asp:BoundField DataField="Service Vehicle Type" HeaderText="Vehicle Type" />
                                                            <asp:BoundField DataField="Unit Service Charge" 
                                                                HeaderText="Unit Service Charge" />
                                                            <asp:TemplateField HeaderText="Service Charge">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" 
                                                                        Text='<%# Bind("[Unit Service Charge]") %>' Width="100px"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty of Service" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text="1" Width="50px"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Unit" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                             <asp:TemplateField HeaderText="Technician" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList5" runat="server" Width="100px">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:BoundField DataField="Spare" 
                                                                HeaderText="Type" />
                                                          
                                                            <asp:CommandField SelectText="Apply" ShowSelectButton="True" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="Label58" runat="server" Font-Bold="True" 
                                                    Text="Manual Parts Entry :" Width="167px"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label52" runat="server" Text="Parts Name :" Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label53" runat="server" Text="Qty of Parts :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox33" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                    ControlToValidate="TextBox32" Display="None" 
                                                    ErrorMessage="Please Enter Parts Name..." SetFocusOnError="True" 
                                                    ValidationGroup="service1"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                    ControlToValidate="TextBox34" Display="None" 
                                                    ErrorMessage="Please Enter Rate..." SetFocusOnError="True" 
                                                    ValidationGroup="service1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label66" runat="server" Text="Unit :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList8" runat="server" Width="128px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label54" runat="server" Text="Rate of Parts :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
                                                <asp:Button ID="Button13" runat="server" Text="Add" ValidationGroup="service1" 
                                                    Width="80px" />
                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="service1" />
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                    ControlToValidate="TextBox33" Display="None" 
                                                    ErrorMessage="Quantity of Parts should be 1..." Operator="GreaterThanEqual" 
                                                    SetFocusOnError="True" Type="Integer" ValidationGroup="Service1" 
                                                    ValueToCompare="1"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                                <asp:Label ID="Label59" runat="server" Font-Bold="True" 
                                                    Text="Machine Shop Works Entry :" Width="232px"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label55" runat="server" Text="Description :" Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label56" runat="server" Text="Qty :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                    ControlToValidate="TextBox35" Display="None" 
                                                    ErrorMessage="Please Enter Parts Name..." SetFocusOnError="True" 
                                                    ValidationGroup="service2"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                    ControlToValidate="TextBox37" Display="None" 
                                                    ErrorMessage="Please Enter Rate..." SetFocusOnError="True" 
                                                    ValidationGroup="service2"></asp:RequiredFieldValidator>
                                                <asp:ValidationSummary ID="ValidationSummary4" runat="server" 
                                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="service2" />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                    ControlToValidate="TextBox38" Display="None" 
                                                    ErrorMessage="Quantity of Machine Shop Works should be 1..." 
                                                    Operator="GreaterThanEqual" SetFocusOnError="True" Type="Integer" 
                                                    ValidationGroup="Service2" ValueToCompare="1"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label67" runat="server" Text="Unit :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList9" runat="server" Width="128px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label57" runat="server" Text="Rate  :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
                                                <asp:Button ID="Button14" runat="server" Text="Add" ValidationGroup="service2" 
                                                    Width="80px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                                        <tr>
                                            <td align="left" valign="top">
                                                <div style="border: 0px solid #000000; width: 1051px; height:600px; overflow: auto;">
                                                    <asp:GridView ID="GridView5" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                                                        CommandName="Select" Text="Edit"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                                                        CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Service ID" HeaderText="Service ID" />
                                                            <asp:BoundField DataField="Service Type" HeaderText="Service Type" />
                                                            <asp:BoundField DataField="Vehicle Type" HeaderText="Vehicle Type" />
                                                            <asp:BoundField DataField="Service Charge" HeaderText="Service Charge" />
                                                            <asp:BoundField DataField="Qty of Service" HeaderText="Qty of Service" />
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                                            <asp:BoundField DataField="Total Value" HeaderText="Total Value" />

                                                            <asp:BoundField DataField="Technician ID" HeaderText="Technician ID" />
                                                            <asp:BoundField DataField="Technician Name" HeaderText="Technician Name" />
                                                            <asp:BoundField DataField="Service Status" HeaderText="Service Status" />
                                                            <asp:BoundField DataField="Type" HeaderText="Type" />   
                                                            <asp:TemplateField HeaderText="Supplier Name">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="supplier_name" runat="server"
                                                                        Text='<%# Bind("[supplier_name]") %>' Width="100px"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Payment Date">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="payment_date" runat="server"
                                                                        Text='<%# Bind("[payment_date]") %>' Width="100px"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bill Number">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="payment_amount" runat="server"
                                                                        Text='<%# Bind("[payment_amount]") %>' Width="100px"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <%--<asp:Button ID="btnONOFF" runat="server" OnCommand="grid_supplier_info_add_Command" CommandArgument ='<%# Eval("supplier_name").ToString() + "," + Eval("payment_date").ToString() + "," + Eval("payment_amount").ToString() + "," + Eval("[Service ID]").ToString() %>' CommandName='<%# Eval("[Service ID]") %>' Text="Add" />--%>
                                                                    <asp:Button ID="btnAddZahid" runat="server" OnClick="btnAddZahid_Click" Text="Add" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>

                                    </table>
                                    
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="Button12" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="Button13" EventName="Click" />
                                  <%--  <asp:PostBackTrigger ControlID="Button12" />--%>
                                    <asp:AsyncPostBackTrigger ControlID="Button14" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView4" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView5" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView5" EventName="RowDeleting" />
                                </Triggers>
                            </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline" 
                                                        UpdateMode="Conditional">
                                                        <ContentTemplate>
                            <table border="0" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                                <asp:Label ID="Label43" runat="server" Font-Bold="True" 
                                                    Text="Dent & Paint Works Entry :" Width="232px"></asp:Label>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label45" runat="server" Text="Qty :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox43" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label46" runat="server" Text="Rate  :" Width="150px"></asp:Label>
                                            </td>
                                            <td>
                                               
                                                <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label44" runat="server" Text="Description :" Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                                                <asp:Button ID="Button17" runat="server" Text="Add" ValidationGroup="service3" 
                                                    Width="80px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="border: 0px solid #000000; width: 1051px; overflow: auto;">
                                                
                                                            <asp:GridView ID="GridView9" runat="server" ShowFooter="True" Width="100%" 
                                                                AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                                                CommandName="Select" Text="Edit"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                                                CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                                                </Columns>
                                                            </asp:GridView>
                                                       
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                     </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="Button17" EventName="Click">
                                                            </asp:AsyncPostBackTrigger>
                                                            <asp:PostBackTrigger ControlID="GridView9" />
                                                            <%--<asp:PostBackTrigger ControlID="Button17" />--%>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2" 
                            style="border: 1px solid #000000; display: none;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label29" runat="server" Text="Search By Part ID :" Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label28" runat="server" Text="Search By Part No :" Width="200px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button3" runat="server" Text="Search" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="border: 0px solid #000000; width: 793px; overflow: auto;">
                                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                                            Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="Parts ID" HeaderText="Parts ID" />
                                                <asp:BoundField DataField="Parts No" HeaderText="Parts No" />
                                                <asp:BoundField DataField="Parts Name" HeaderText="Parts Name" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                               <asp:TemplateField ShowHeader="False" HeaderText="Requisit Quantity">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text="1" Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                  <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                               
                                                <asp:CommandField SelectText="Add" ShowSelectButton="True" >
                                               
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                </asp:CommandField>
                                               
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                      <div style="border: 0px solid #000000; width: 793px; overflow: auto;">
                                                    <asp:GridView ID="GridView7" runat="server" ShowFooter="True" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                                        CommandName="Select" Text="Edit"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                        CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click">
                                    </asp:AsyncPostBackTrigger>

                                     <asp:AsyncPostBackTrigger ControlID="GridView6" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView7" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView7" EventName="RowDeleting" />
                                    <%--<asp:PostBackTrigger ControlID="GridView7" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2" style="border: 1px solid #000000">

                                     <asp:Label ID="Label47" runat="server" Text="Spare Parts Issue From Store :" 
                                         EnableTheming="True" Font-Bold="True" Font-Names="Calibri" 
                                         Font-Size="Medium"></asp:Label>
                            <div style="border: 0px solid #000000; width: 1051px; height:600px; overflow: auto;">
                            <asp:GridView ID="GridView8" runat="server"
                                ShowFooter="True" Width="100%" AutoGenerateColumns="false"
                                EnableTheming="True" Font-Names="Calibri" Font-Size="Small"
                                BorderWidth="0px">
                                <Columns>
                                    <asp:BoundField DataField="Issue ID" HeaderText="Issue ID" />
                                    <asp:BoundField DataField="Parts Name" HeaderText="Parts Name" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:BoundField DataField="job_part_id" HeaderText="job_part_id" />
                                    <asp:TemplateField HeaderText="Supplier Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="supplier_name1" runat="server"
                                                Text='<%# Bind("[supplier_name]") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Payment Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="payment_date1" runat="server"
                                                Text='<%# Bind("[payment_date]") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="payment_amount1" runat="server"
                                                Text='<%# Bind("[payment_amount]") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <%--<asp:Button ID="btnONOFF" runat="server" OnCommand="grid_supplier_info_add_Command" CommandArgument ='<%# Eval("supplier_name").ToString() + "," + Eval("payment_date").ToString() + "," + Eval("payment_amount").ToString() + "," + Eval("[Service ID]").ToString() %>' CommandName='<%# Eval("[Service ID]") %>' Text="Add" />--%>
                                            <asp:Button ID="btnAddZahid1" runat="server" OnClick="btnAddZahid1_Click" Text="Add" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle Wrap="True" HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:GridView>
                                      </div>        
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" style="border: 1px solid #000000">
                            <table cellpadding="1" cellspacing="2" style="width:100%;">
                                <tr>
                                    <td align="left" valign="top">
                            <asp:Label ID="Label23" runat="server" Text="Walk Around Check :"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="No Valuables Left" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="Attached Sheet" />
                                    </td>
                                </tr>
                            </table>
                            <div style="border: 0px solid #000000; width: 355px; height: 350px; overflow: auto;">
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                    Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="sl" HeaderText="Sl" />
                                    <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                             <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Description") %>' 
                                                 Width="275px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                           
                        </td>
                        <td align="left" valign="top" style="border: 1px solid #000000">
                            <asp:Label ID="Label21" runat="server" Text="Customer Complain :"></asp:Label>
                          <div style="border: 0px solid #000000; width: 427px; height: 183px; overflow: auto;">
                         
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                  Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="sl" HeaderText="Sl" />
                                    <asp:TemplateField HeaderText="Complain">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>' Width="350px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView></div>
                            <asp:Label ID="Label22" runat="server" Text="Technician Report :"></asp:Label>
                        <div style="border: 0px solid #000000; width: 427px; height: 183px; overflow: auto;">
                         
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="sl" HeaderText="Sl" />
                                    <asp:TemplateField HeaderText="Report">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                             <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Description") %>'  Width="350px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView></div>
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="center" valign="top" style="border: 1px solid #000000" colspan="2">
                            <table>
                                <tr>
                                    <td align="left" valign="top">
                                                <asp:Label ID="Label37" runat="server" Text="Payment Date :"></asp:Label>
                                            </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="TextBox25" runat="server" Width="88px"></asp:TextBox>
                                        <a id="A3" name="anchor2" 
                                            onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox25,'img3','dd/MM/yyyy'); return false;">
                                        <img id="img3" src="calendar.gif" /></a></td>
                                    <td align="left" valign="top">
                                                <asp:Label ID="Label36" runat="server" Text="Pay Advance :"></asp:Label>
                                            </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="TextBox24" runat="server" Width="60px"></asp:TextBox>
                                        </td>
                                    <td align="left" valign="top">
                                                <asp:Label ID="Label40" runat="server" 
                                Text="Payment Mode :"></asp:Label>
                                                </td>
                                    <td align="left" valign="top">
                                                <asp:DropDownList ID="DropDownList6" runat="server">
                                                </asp:DropDownList>
                                        <asp:Label ID="Label71" runat="server" Text="Opinion Date"></asp:Label>
                                                </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="TextBox41" runat="server" Width="88px"></asp:TextBox>
                                        <a id="A10" name="anchor2" 
                                            onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox41,'img3','dd/MM/yyyy'); return false;">
                                        <img id="img11" src="calendar.gif" /></a></td>
                                    <td align="left" valign="top">
                                               
                                            </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                                <asp:Label ID="Label42" runat="server" Text="Cheque Date :"></asp:Label>
                                                </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="TextBox29" runat="server" Width="88px"></asp:TextBox>
                                        <a id="A4" name="anchor3" 
                                            onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox29,'img4','dd/MM/yyyy'); return false;">
                                        <img id="img4" src="calendar.gif" /></a></td>
                                    <td align="left" valign="top">
                                                <asp:Label ID="Label41" runat="server" 
                                Text="Bank :"></asp:Label>
                                                </td>
                                    <td align="left" valign="top">
                                                <asp:TextBox ID="TextBox28" runat="server" Width="60px"></asp:TextBox>
                                                </td>
                                    <td align="left" valign="top">
                                                <asp:Label ID="Label38" runat="server" 
                                Text="Cheque No :"></asp:Label>
                                            </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="TextBox26" runat="server" Width="60px"></asp:TextBox>
                                                </td>
                                </tr>
                                </table>
                           
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                <asp:Label ID="Label65" runat="server" Text="Enter Password :"></asp:Label>
                <asp:TextBox ID="TextBox40" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Button ID="Button16" runat="server" Text="Enable Modification" />
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                   <asp:Button ID="Button4" runat="server" Text="Submit" ValidationGroup="s" 
                    Width="100px" />
             
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button9"  EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button15"  EventName="Click"/>
                 <asp:AsyncPostBackTrigger ControlID="Button20"  EventName="Click"/>
               
                <asp:AsyncPostBackTrigger ControlID="DropDownList10"  EventName="SelectedIndexChanged"/>
                <asp:PostBackTrigger ControlID="Button16" />
                <asp:PostBackTrigger ControlID="Button4" />
                </Triggers>
                </asp:UpdatePanel>



                <asp:Button ID="Button11" runat="server" Text="Print Advance Money Receipt" 
                    Width="187px" />
                <asp:Button ID="Button6" runat="server" Text="Print Job Sheet" Width="120px" />
                <asp:Button ID="Button7" runat="server" Text="Generate Bill" Width="100px" />

                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                  <asp:Button ID="Button5" runat="server" Text="Delete" Width="100px" />
             
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button9"  EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Button15"  EventName="Click"/>
                 <asp:AsyncPostBackTrigger ControlID="Button20"  EventName="Click"/>
               
                <asp:AsyncPostBackTrigger ControlID="DropDownList10"  EventName="SelectedIndexChanged"/>
                <asp:PostBackTrigger ControlID="Button16" />
                <asp:PostBackTrigger ControlID="Button4" />
                </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
    </table>
</asp:Content>

