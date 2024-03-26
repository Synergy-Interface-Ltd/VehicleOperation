<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vehicle Solution ERP - Operation Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/image/Logo.jpg" 
            Width="201px" />
            
             <table style="border-style: solid; border-width: 1px; ">
                 <tr>
                     <td align="center" colspan="2" 
                         style="color: #FFFFFF; font-weight: bold; font-size: medium; background-color: #003399;" 
                         valign="top">
                         <asp:Label ID="Label46" runat="server" EnableTheming="False" 
                             Text="Vehicle Solution"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top">
                         <asp:Label ID="Label44" runat="server" Text="Enter User ID :" Width="108px"></asp:Label>
                     </td>
                     <td align="left" valign="top">
                         <asp:TextBox ID="TextBox199" runat="server" BorderColor="#003399" 
                             BorderStyle="Solid" BorderWidth="1px" Width="76px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top">
                         <asp:Label ID="Label45" runat="server" Text="Enter Password :" Width="117px"></asp:Label>
                     </td>
                     <td align="left" valign="top">
                         <asp:TextBox ID="TextBox2" runat="server" BorderColor="#003399" 
                             BorderStyle="Solid" BorderWidth="1px" TextMode="Password" Width="76px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top">
                         &nbsp;</td>
                     <td align="left" valign="top">
                         <asp:Button ID="Button2" runat="server" BorderColor="Black" BorderStyle="Solid" 
                             BorderWidth="1px" Text="Login" />
                     </td>
                 </tr>
                 <tr>
                     <td align="center" colspan="2" valign="top">
                         <asp:Label ID="Label47" runat="server" EnableTheming="False" Font-Bold="True" 
                             Font-Size="Small" ForeColor="Red" Text="Login Failed..."></asp:Label>
                     </td>
                 </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TextBox199" Display="None" 
            ErrorMessage="Please Enter User ID..." SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox2" Display="None" 
            ErrorMessage="Please Enter Password..." SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" ShowSummary="False" />
    
    </div>
    </form>
</body>
</html>
