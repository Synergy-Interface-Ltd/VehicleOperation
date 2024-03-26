<%@ Page Title="Add Technicians" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="add_technician.aspx.vb" Inherits="add_technician" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label1" runat="server" SkinID="header_lbl" 
            Text="Add Technicians"></asp:Label>
    </div>
    <br />
    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label5" runat="server" Text="Technician Name :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label6" runat="server" Text="Contact No :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label7" runat="server" Text="Mail ID :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label8" runat="server" Text="Expertise On :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center" valign="top">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center" valign="top">
                <asp:TextBox ID="TextBox5" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Submit" ValidationGroup="s" 
                    Width="100px" />
                <asp:Button ID="Button3" runat="server" Text="Edit" ValidationGroup="s" 
                    Width="100px" />
                <asp:Button ID="Button4" runat="server" Text="Delete" Width="100px" />
                <asp:Button ID="Button5" runat="server" Text="Refresh" Width="100px" />
                <asp:Button ID="Button6" runat="server" Text="Button" />
            </td>
        </tr>
    </table>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" Display="None" 
        ErrorMessage="Please Enter Technician Name..." SetFocusOnError="True" 
        ValidationGroup="s"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox2" Display="None" 
        ErrorMessage="Please Enter Contact No..." SetFocusOnError="True" 
        ValidationGroup="s"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="TextBox4" Display="None" 
        ErrorMessage="Please Enter Expertise On..." SetFocusOnError="True" 
        ValidationGroup="s"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
    runat="server" ControlToValidate="TextBox3" Display="None" 
    ErrorMessage="Please Enter Valid Mail ID..." SetFocusOnError="True" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
    ValidationGroup="s"></asp:RegularExpressionValidator>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
    <div align="left" 
    
        
        style="border: 1px solid #000000; padding: 2px; margin: 0px; width: 1147px; overflow: auto; height: 500px;">
        <asp:GridView ID="GridView1" runat="server" Width="100%">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
       
    <br />
</asp:Content>

