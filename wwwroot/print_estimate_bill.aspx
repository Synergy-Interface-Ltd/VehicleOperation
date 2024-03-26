<%@ Page Title="Estimate Bill" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="print_estimate_bill.aspx.vb" Inherits="print_estimate_bill"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css"> 
 @media print {
 thead { display: table-header-group; }
 tfoot { display: table-footer-group; }
 }
 @media screen {
 thead { display: block; }
 tfoot { display: block; }
 }
 thead { display: table-header-group; }
tfoot { display: table-footer-group; }


    .truncated
    {
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        width: 540px;
    }

 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" 
            UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0" border="0" 
                    style="width: 731px;">
                   <tr><td align="left" valign="top" width="731px;">
                   
                   <div id="footer" runat="server">
                   <div align="center">
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <asp:Label ID="Label61" runat="server" EnableTheming="False" 
                    Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" Text="Estimate Bill"></asp:Label></div>
                   <table cellpadding="2" 
                           cellspacing="0" border="0" 
                    style="border: 1.25px solid #000000; width: 100%;" > <tr>
                        <td align="left" colspan="4" valign="middle">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label47" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium" Text="Bill Date:"></asp:Label>
                                        &nbsp;<asp:Label ID="TextBox27" runat="server" EnableTheming="False" 
                                            Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="Label46" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium" Text="Invoice No :"></asp:Label>
                                        &nbsp;<asp:Label ID="TextBox25" runat="server" EnableTheming="False" 
                                            Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" Visible="False"></asp:Label>
                                        <asp:Label ID="TextBox42" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td align="center" valign="middle">
                                        <asp:Label ID="Label54" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium" Text="BIN No :"></asp:Label>
                                        &nbsp;<asp:Label ID="Label53" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium" Text="000492463-0101"></asp:Label>
                                    </td>
                                    <td align="right" valign="middle">
                                        <asp:Label ID="Label64" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium" Text="TIN :"></asp:Label>
                                        &nbsp;<asp:Label ID="Label63" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium" Text="465588260401"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" valign="top">
                            <hr />
                        </td>
                    </tr>
                     <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label62" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Customer ID :"></asp:Label>
                        </td>
                        <td align="left" colspan="1" valign="top" width="30%">
                            <asp:Label ID="TextBox45" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td width="20%" align="left" valign="top">
                            <asp:Label ID="Label20" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Manual RO No :" Visible="False"></asp:Label>
                            <asp:Label ID="Label445" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Receive Date :"></asp:Label>
                            <asp:Label ID="Label45" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Automatic Job ID :"></asp:Label>
                        </td>
                        <td width="30%" align="left" valign="top">
                            <asp:Label ID="TextBox14" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium" Visible="False"></asp:Label>
                            <asp:Label ID="TextBox244" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label> <br />
                            <asp:Label ID="TextBox24" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label5" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Customer's Name :"></asp:Label>
                        </td>
                        <td align="left" colspan="1" valign="top" width="30%">
                            <asp:Label ID="TextBox1" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label14" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Vehicle :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox8" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" rowspan="2" valign="top" width="20%">
                            <asp:Label ID="Label6" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Address :"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                        </td>
                        <td align="left" rowspan="2" valign="top" width="30%">
                            <asp:Label ID="TextBox2" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium" Height="31px" Width="211px"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label15" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Reg No :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox9" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label16" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Model :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox10" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label7" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Email :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox3" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label18" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Chassis No :"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="TextBox12" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label8" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Tel No. :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox4" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label17" runat="server" Text="Eng No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox11" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label9" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Mobile No. :"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox5" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label19" runat="server" Text="KM :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox13" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr></table></div></td></tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            <div id="inv1" runat="server">
                           <div id="inv" runat="server"> 
                               <asp:GridView ID="GridView6" runat="server"  style="table-layout:fixed;" 
                                Width="831px" 
                                                                                                            
                                Font-Names="Calibri" Font-Size="12pt" 
                                BorderWidth="1px" 
                                                                                                            
                                EnableTheming="False" BackColor="White" BorderColor="#999999" 
                                BorderStyle="Solid" CellPadding="0" GridLines="Vertical" ShowFooter="True">
                                <FooterStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" 
                                       Font-Bold="True" />
                                <HeaderStyle BorderColor="#333333" BorderStyle="Solid" 
                                    BorderWidth="1px" 
                                                                                                                
                                    Font-Bold="True" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle Wrap="True" ForeColor="Black" HorizontalAlign="Left" 
                                       VerticalAlign="Top" Font-Size="Medium" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                               
                            </asp:GridView></div>
                            <asp:GridView ID="GridView5" runat="server" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                EnableTheming="False" Font-Names="Calibri" Font-Size="Medium" 
                                GridLines="Vertical" Width="100%">
                                <FooterStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" />
                                <HeaderStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" 
                                    Font-Bold="True" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle ForeColor="Black" Wrap="False" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView></div>
                        </td>
                    </tr>
                    <tr><td align="left" width="100%"><table cellspacing="0" cellpadding="2" border="0" 
                            style="border: 1.25px solid #000000; width:100%;" >
                    <tr>
                        <td align="left" valign="bottom" width="70%" rowspan="13">
                            <div style="padding: 5px; margin: 5px">
                                <asp:Label ID="TextBox44" runat="server" EnableTheming="False" Font-Bold="True" 
                                    Font-Names="Calibri" Font-Size="Medium" Font-Underline="True">Note :</asp:Label>
                                <br />
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                <br />
                                <asp:Label ID="TextBox46" runat="server" EnableTheming="False" Font-Bold="True" 
                                    Font-Names="Calibri" Font-Size="Medium" Font-Underline="False">Reference :</asp:Label>
                                &nbsp;<asp:Label ID="TextBox47" runat="server" EnableTheming="False" 
                                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                            </div>
                            <br />
                            <asp:Label ID="TextBox32" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="70%">
                            <asp:Label ID="Label59" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Service Charge Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox39" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="70%">
                            <asp:Label ID="Label60" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Spare Parts Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox40" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="70%" style="display: none">
                            <asp:Label ID="Label49" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Sub Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%" style="display: none">
                            <asp:Label ID="TextBox28" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                      <tr >
                        <td align="right" valign="top" width="70%"  id="l34" runat="server">
                            <asp:Label ID="Label10" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Discount on Service :"></asp:Label>
                            <asp:Label ID="TextBox34" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                            <asp:Label ID="TextBox43" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium">%</asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%"  id="ll34" runat="server">
                            <asp:Label ID="TextBox41" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" valign="top" width="70%">
                            <asp:Label ID="Label57" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox38" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" valign="top" width="70%">
                            <asp:Label ID="Label56" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="VAT Amount (7.5%) :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox37" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                     
                  
                    <tr>
                        <td align="right" valign="top" width="70%" style="display: none">
                            <asp:Label ID="Label58" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Discount on Service :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%" style="display: none">
                            &nbsp;</td>
                    </tr>
                   
                  
                    <tr>
                        <td align="right" valign="top" width="70%" style="display: none">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Visible="false"
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" 
                                Text="Exclude" />
                            &nbsp;<asp:Label ID="Label50" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="VAT on Service (10%) :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%" style="display: none">
                            <asp:Label ID="TextBox29" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="70%" style="display: none">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Visible="false" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" 
                                Text="Exclude" />
                            &nbsp;<asp:Label ID="Label55" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="VAT on Spare Parts (7.5%) :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%" style="display: none">
                            <asp:Label ID="TextBox36" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="Label51" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Net Amount :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox30" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                     <tr   >
                        <td align="right" valign="top" width="70%" id="l35" runat="server">
                            <asp:Label ID="Label11" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Discount :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%" id="ll35" runat="server">
                            <asp:label ID="TextBox35" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium" ></asp:label>
                        </td>
                    </tr>
                  
                  
                    
                    <tr >
                        <td align="right" valign="top" id="l48" runat="server">
                            <asp:Label ID="Label48" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Received Amount :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%" id="ll48" runat="server">
                            <asp:Label ID="TextBox26" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" >
                            <asp:Label ID="Label52" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Medium" Text="Payable :"></asp:Label>
                        </td>
                        <td align="right" valign="top">
                            <asp:Label ID="TextBox31" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr></table></td></tr>
                    <tr>
                        <td align="left" width="100%">
                            <table border="0" cellpadding="2" cellspacing="0" 
                                style="border: 1.25px solid #000000; width:100%;" width="100%">
                                <tr>
                                    <td align="center" colspan="2" valign="top" width="35%">
                                        <br />
                                        <br />
                                        _______________<br />
                                        <asp:Label ID="TextBox33" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Medium">Prepared By</asp:Label>
                                    </td>
                                    <td align="center" valign="top" width="30%">
                                        <br />
                                        <br />
                                        ___________<br />
                                        <asp:Label ID="lTextBox34" runat="server" EnableTheming="False" 
                                            Font-Bold="True" Font-Names="Calibri" Font-Size="Medium">Customer</asp:Label>
                                    </td>
                                    <td align="center" valign="top" width="35%">
                                        <br />
                                        <br />
                                        ______________<br />
                                        <asp:Label ID="lTextBox35" runat="server" EnableTheming="False" 
                                            Font-Bold="True" Font-Names="Calibri" Font-Size="Medium">Accountant</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                   
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
               <%-- <asp:PostBackTrigger ControlID="Button2" />--%>
            </Triggers>
        </asp:UpdatePanel>
  
                            <asp:Button ID="Button2" runat="server" 
        Text="Generate Bill" Width="100px" Visible="False" />
                            <asp:Button ID="Button4" runat="server" 
        Text="Delete Bill" Width="100px" Visible="False" />
                            <asp:Button ID="Button3" runat="server" 
        Text="Print Bill" Width="100px" Visible="False" />
  
        <br />
                
         
</asp:Content>

