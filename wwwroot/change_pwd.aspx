<%@ Page Title="Change Password" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="change_pwd.aspx.vb" Inherits="change_pwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
    <table style="border-style: solid; border-width: 1px; ">
        <tr>
            <td align="center" colspan="2" 
                style="color: #FFFFFF; font-weight: bold; font-size: medium; background-color: #003399;" 
                valign="top">
                <asp:Label ID="Label46" runat="server" EnableTheming="False" 
                    Text="Change Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label44" runat="server" Text="Enter User ID :" Width="108px"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox199" runat="server" BorderColor="#003399" 
                    BorderStyle="Solid" BorderWidth="1px" Width="154px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label49" runat="server" Text="Enter Old Password :" 
                    Width="154px"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox201" runat="server" BorderColor="#003399" 
                    BorderStyle="Solid" BorderWidth="1px" Width="154px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label45" runat="server" Text="Enter Password :" Width="117px"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox2" runat="server" BorderColor="#003399" 
                    BorderStyle="Solid" BorderWidth="1px" TextMode="Password" Width="154px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="Label48" runat="server" Text="Confirm Password :" Width="129px"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox200" runat="server" BorderColor="#003399" 
                    BorderStyle="Solid" BorderWidth="1px" TextMode="Password" Width="154px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                &nbsp;</td>
            <td align="left" valign="top">
                <asp:Button ID="Button2" runat="server" BorderColor="Black" BorderStyle="Solid" 
                    BorderWidth="1px" Text="Change Password" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" valign="top">
                <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red" Text="Login Failed..." EnableTheming="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox2" Display="None" 
        ErrorMessage="Please Enter New Password..." SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox200" Display="None" 
        ErrorMessage="Please Confirm Password..." SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="TextBox199" Display="None" 
        ErrorMessage="Please Enter User ID..." SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox2" ControlToValidate="TextBox200" Display="None" 
        ErrorMessage="Paswword is not Confirmed.." SetFocusOnError="True"></asp:CompareValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="TextBox201" Display="None" 
        ErrorMessage="Please Enter Old Password..." SetFocusOnError="True"></asp:RequiredFieldValidator>
</div>
</asp:Content>

