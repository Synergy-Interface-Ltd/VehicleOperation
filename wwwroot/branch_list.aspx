<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="branch_list.aspx.vb" Inherits="masters_branch_list" title="Select Branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="0" style="width: 100%">
        <tr>
            <td align="center">
                <asp:Panel ID="Panel2" runat="server" GroupingText="Search MSP For Admin" 
                    Width="100%" Visible="False">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Member ID :"></asp:Label></td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <asp:Button ID="Button3" runat="server" Text="Search" /></td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Account no :"></asp:Label></td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:Button ID="Button4" runat="server" Text="Search" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Font-Underline="False"
                    ForeColor="DarkBlue" Text="Select Branch :"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="300px">
                </asp:DropDownList>
                                &nbsp;<asp:Button ID="Button6" runat="server" Text="Enter" />
                <br />
                <br />
                <br />
            </td>
        </tr>
        </table>
                <asp:Button ID="Button5" runat="server" Text="Button" /><asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
</asp:Content>

