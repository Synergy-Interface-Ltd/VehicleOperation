<%@ Page Title="Money Receipt" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="money_receipt.aspx.vb" Inherits="money_receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="inv" runat="server">
    <table cellpadding="0" cellspacing="5" 
        style="border: 1px solid #000000; width: 709px">
        <tr>
            <td align="left" valign="top" width="30%">
                <br />
                <asp:Label ID="Label19" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Font-Bold="True">No. :</asp:Label>
&nbsp;<asp:Label ID="Label9" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td align="center" valign="top" width="40%">
                <asp:Label ID="Label22" runat="server" EnableTheming="False" Font-Bold="True" 
                    Font-Names="Calibri" Font-Size="Medium">Money Receipt</asp:Label>
            </td>
            <td align="right" valign="top" width="30%">
                <br />
                <asp:Label ID="Label20" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Font-Bold="True">Date :</asp:Label>
&nbsp;<asp:Label ID="Label21" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" valign="top">
                <hr />
                            <asp:Image ID="Image5" runat="server" Height="84px" ImageUrl="~/image/whitespace.jpg" 
                                Width="222px" />
                        <br />
                            <br />
                            <br />
                            <hr />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" valign="top" width="100%">
                <asp:Label ID="Label2" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="Received with thanks from" 
                    Font-Bold="True"></asp:Label>
&nbsp;
                <asp:Label ID="Label3" runat="server" CssClass="style1" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Font-Underline="False" style=""></asp:Label>
                <hr />
                <asp:Label ID="Label4" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" 
                    Text="For the Job of The Vehicle Registration No" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="Label5" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
                &nbsp;
                <asp:Label ID="Label42" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" 
                    Text="Under Job No :" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="Label43" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
                &nbsp;
                <asp:Label ID="Label44" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="as" 
                    Font-Bold="True"></asp:Label>
&nbsp;
                <asp:Label ID="Label11" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
                <hr />
                <asp:Label ID="Label6" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="BDT in Words" 
                    Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="Label7" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
                &nbsp;<hr />
                <asp:Label ID="Label8" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="on Account of Invoice No" 
                    Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="Label18" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
                <hr />
                <asp:Label ID="Label12" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="by Cash/Cheque No" 
                    Font-Bold="True"></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
&nbsp;
                <asp:Label ID="Label14" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="Date " Font-Bold="True"></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
&nbsp;
&nbsp;<asp:Label ID="Label16" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Text="Bank" Font-Bold="True"></asp:Label>
&nbsp;
&nbsp;<asp:Label ID="Label17" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium" Font-Underline="False"></asp:Label>
                <hr />
                <br />
            </td>
        </tr>
        <tr>
            <td style="border: 1px solid #000000" align="center" valign="middle">
                <asp:Label ID="Label23" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium" Text="BDT" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="Label24" runat="server" EnableTheming="False" Font-Names="Calibri" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td align="center" valign="top">
                ____________________<br />
                <asp:Label ID="Label25" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium">Client&#39;s Signature</asp:Label>
            </td>
            <td align="center" valign="top">
                _____________________<br />
                <asp:Label ID="Label26" runat="server" EnableTheming="False" 
                    Font-Names="Calibri" Font-Size="Medium">For Vehicle Solution</asp:Label>
            </td>
        </tr>
    </table></div>
    <asp:Literal ID="Literal1" runat="server" Visible="False"></asp:Literal>
                            <asp:Label ID="Label40" runat="server" 
        EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" 
                                Text="541-42, Ferajitola, Solmaith, Vatara, Dhaka-1212." 
                    ForeColor="White" Visible="False"></asp:Label>
                            <asp:Label ID="Label41" runat="server" 
        EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" 
                                Text="(Nearby Apollo Hospital), Basundhara R/A" 
                    ForeColor="White" Visible="False"></asp:Label>
                            </asp:Content>

