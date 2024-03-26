<%@ Page Title="Add Terms" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="add_terms.aspx.vb" Inherits="add_terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label1" runat="server" SkinID="header_lbl" 
            Text="Add Terms &amp; Condition"></asp:Label>
    </div>
    <br />
    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label5" runat="server" Text="Technician Name :"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox1" runat="server" Height="105px" TextMode="MultiLine" 
                    Width="304px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="top">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="top">
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
        ErrorMessage="Please Enter Terms..." SetFocusOnError="True" 
        ValidationGroup="s"></asp:RequiredFieldValidator>
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


