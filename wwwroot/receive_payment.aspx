<%@ Page Title="Receive Payment" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="receive_payment.aspx.vb" Inherits="receive_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
            <asp:Label ID="Label1" runat="server" SkinID="header_lbl" Text="Receive Payment"></asp:Label>
        </div>
                <asp:Button ID="Button2" runat="server" Text="Button" />
        <br />
        <br />
    <table width="914px">
        <tr>
            <td align="left" valign="top" colspan="2" width="25%">
                <asp:Label ID="Label24" runat="server" Text="Branch Code :"></asp:Label>
                &nbsp;<asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
            </td>
            <td align="center" valign="top" colspan="2" width="25%">
                <asp:Label ID="Label25" runat="server" Text="Branch Name :"></asp:Label>
                &nbsp;<asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
            </td>
            <td align="center" valign="top" colspan="2" width="25%">
                <asp:Label ID="Label5" runat="server" Text="Customer ID :"></asp:Label>
                &nbsp;<asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td align="right" valign="top" colspan="2" width="25%">
                <asp:Label ID="Label7" runat="server" Text="Invoice Amount :"></asp:Label>
                &nbsp;<asp:Label ID="Label8" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="8" 
                style="border-top-style: solid; border-top-width: 1px; border-top-color: #000000">
                <asp:Label ID="Label28" runat="server" Text="Customer Details :"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="8">
                <div style="border: 1px solid #000000; width: 997px; ">
    <asp:GridView ID="GridView3" runat="server" ShowFooter="True" Width="100%">
    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="8">
                <asp:Label ID="Label26" runat="server" Text="Invoiced History :"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="8" valign="top">
                <div style="border: 1px solid #000000; width: 997px; height: 186px; overflow: auto;">
    <asp:GridView ID="GridView2" runat="server" ShowFooter="True" Width="100%">
    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="8" valign="top">
                <asp:Label ID="Label27" runat="server" Text="Payment History :"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="8" valign="top">
                <div style="border: 1px solid #000000; width: 997px; height: 186px; overflow: auto;">
                <asp:GridView ID="GridView1" runat="server" ShowFooter="True" Width="100%">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label9" runat="server" Text="Due Amount :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="Label10" runat="server" ReadOnly="True" Width="128px"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label13" runat="server" Text="Receive Amount :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="Label14" runat="server" Width="128px"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label21" runat="server" Text="Payment Date :"></asp:Label>
            </td>
            <td align="left" valign="top">
                 <asp:TextBox ID="TextBox26" runat="server" Width="101px"></asp:TextBox>
                <a id="A4" name="anchor3" 
                    onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox26,'img4','dd/MM/yyyy'); return false;">
                <img id="img4" src="calendar.gif" /></a></td>
            <td align="left" valign="top">
                <asp:Label ID="Label15" runat="server" Text="Payment Mode :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="128px">
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label17" runat="server" Text="Bank :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="Label19" runat="server" Width="128px"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label16" runat="server" Text="Cheque Date :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox25" runat="server" Width="103px"></asp:TextBox>
                <a id="A3" name="anchor2" 
                    onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox25,'img3','dd/MM/yyyy'); return false;">
                <img id="img3" src="calendar.gif" /></a></td>
            <td align="left" valign="top">
                <asp:Label ID="Label18" runat="server" Text="Cheque No :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="Label20" runat="server" Width="128px"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                &nbsp;</td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox27" runat="server" Visible="False" Width="128px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="8">
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="Label10" ControlToValidate="Label14" Display="None" 
                    ErrorMessage="Received Amount Should Be Less Than Equal To Due Amount..." 
                    Operator="LessThanEqual" SetFocusOnError="True" Type="Currency" 
                    ValidationGroup="s"></asp:CompareValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Label14" Display="None" 
                    ErrorMessage="Please Enter Received Amount..." SetFocusOnError="True" 
                    ValidationGroup="s"></asp:RequiredFieldValidator>
                <hr />
                <asp:Button ID="Button3" runat="server" Text="Submit" ValidationGroup="s" />
                <asp:Button ID="Button4" runat="server" Text="Edit" Width="63px" />
                <asp:Button ID="Button6" runat="server" Text="Delete" Width="63px" />
                <asp:Button ID="Button5" runat="server" Text="Refresh" />
                <asp:Button ID="Button7" runat="server" Text="Print Money Receipt" />
            </td>
        </tr>
    </table>
</asp:Content>

