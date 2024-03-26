<%@ Page Title="Generate Bill" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="bill.aspx.vb" Inherits="bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl" 
            Text="Generate Bill"></asp:Label>
    </div>
                <br />
  
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" 
            UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0" border="0" 
                    style="border: 1px solid #000000; width: 731px;">
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label62" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Customer ID :"></asp:Label>
                        </td>
                        <td align="left" colspan="1" valign="top" width="30%">
                            <asp:Label ID="TextBox45" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td width="20%" align="left" valign="top">
                            <asp:Label ID="Label20" runat="server" Text="Manual RO No :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small" Visible="False"></asp:Label>
                            <asp:Label ID="Label45" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Automatic Job ID :"></asp:Label>
                        </td>
                        <td width="30%" align="left" valign="top">
                            <asp:Label ID="TextBox14" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                            <asp:Label ID="TextBox24" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label46" runat="server" Text="Bill No :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" colspan="1" valign="top" width="30%">
                            <asp:Label ID="TextBox25" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                            <asp:Label ID="TextBox42" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td width="20%" align="left" valign="top">
                            <asp:Label ID="Label47" runat="server" Text="Bill Date :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td width="30%" align="left" valign="top">
                            <asp:TextBox ID="TextBox27" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:TextBox>  <a ID="A1" name="anchor1" 
                                        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox27,'img2','dd/MM/yyyy'); return false;">
                <img id="img2" src="calendar.gif" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label1" runat="server" Text="Customer's Name :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" colspan="3" valign="top" width="80%">
                            <asp:Label ID="TextBox1" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label2" runat="server" Text="Address :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" colspan="3" valign="top" width="80%">
                            <asp:Label ID="TextBox2" runat="server" EnableTheming="False" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label3" runat="server" Text="Email :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                        </td>
                        <td align="left" colspan="3" valign="top" width="80%">
                            <asp:Label ID="TextBox3" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label4" runat="server" Text="Tel No. :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox4" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label5" runat="server" Text="Mobile No. :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox5" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label14" runat="server" Text="Vehicle :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox8" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label15" runat="server" Text="Reg No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox9" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label16" runat="server" Text="Model :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox10" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label17" runat="server" Text="Eng No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox11" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label18" runat="server" Text="Chassis No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox12" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="20%">
                            <asp:Label ID="Label19" runat="server" Text="KM :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top" width="30%">
                            <asp:Label ID="TextBox13" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="4">
                            <asp:GridView ID="GridView5" runat="server" 
                                Width="100%" 
                                                                                                            
                                Font-Names="Calibri" Font-Size="Small" 
                                BorderWidth="1px" 
                                                                                                            
                                EnableTheming="False" BackColor="White" BorderColor="#999999" 
                                BorderStyle="Solid" CellPadding="3" GridLines="Vertical">
                                <FooterStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" />
                                <HeaderStyle BorderColor="#333333" BorderStyle="Solid" 
                                    BorderWidth="1px" 
                                                                                                                
                                    Font-Bold="True" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle Wrap="False" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" colspan="3" width="70%">
                            <asp:Label ID="Label59" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Service Charge Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox39" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label60" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Spare Parts Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox40" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label49" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Sub Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox28" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label53" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Discount (%age) on Service :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:TextBox ID="TextBox34" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label58" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Discount on Service :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox41" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label54" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Discount :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:TextBox ID="TextBox35" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label6" runat="server" EnableTheming="False" Font-Bold="True"
                                Font-Names="Calibri" Font-Size="Small" Text="AIT(%) :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label7" runat="server" EnableTheming="False" Font-Bold="True"
                                Font-Names="Calibri" Font-Size="Small" Text="AIT Amount:"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:TextBox ID="aitAmount" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label57" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="Total :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox38" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Small" 
                                Text="Exclude" />
                            &nbsp;<asp:Label ID="Label50" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="VAT on Service (10%) :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox29" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Small" 
                                Text="Exclude" />
                            &nbsp;<asp:Label ID="Label55" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="VAT on Spare Parts (10%) :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox36" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3" valign="top" width="70%">
                            <asp:Label ID="Label56" runat="server" EnableTheming="False" Font-Bold="True" 
                                Font-Names="Calibri" Font-Size="Small" Text="VAT Amount :"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox37" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right" valign="top" width="20%">
                            <asp:Label ID="Label51" runat="server" Text="Net Amount :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox30" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right" valign="top" width="20%">
                            <asp:Label ID="Label48" runat="server" Text="Received Amount :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox26" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2" width="50%">
                            <asp:Label ID="TextBox32" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Font-Bold="True"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="20%">
                            <asp:Label ID="Label52" runat="server" Text="Payable :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="30%">
                            <asp:Label ID="TextBox31" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" valign="top">
                            <asp:Label ID="Label63" runat="server" EnableTheming="False" Font-Bold="True" 
                                Text="Note :" Width="232px"></asp:Label>
                            <asp:TextBox ID="TextBox43" runat="server" EnableTheming="False" Height="77px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" valign="top">
                            <hr />
                            <asp:Label ID="Label68" runat="server" Text="Sales Executive :"></asp:Label>
                            <asp:TextBox ID="TextBox44" runat="server" Width="189px"></asp:TextBox>
                            <asp:Label ID="Label69" runat="server" Text="Type of Customer :"></asp:Label>
                            <asp:DropDownList ID="DropDownList11" runat="server" Width="189px">
                            </asp:DropDownList>
                            <hr />
                            <asp:Button ID="Button2" runat="server" Text="Generate Bill" Width="100px" />
                            <asp:Button ID="Button4" runat="server" Text="Delete Bill" Width="100px" />
                            <asp:Button ID="Button5" runat="server" Text="Print Estimate Bill" Width="120px" />
                            <asp:Button ID="Button3" runat="server" Text="Print Bill" Width="100px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="CheckBox2" EventName="CheckedChanged" />
                <asp:PostBackTrigger ControlID="Button2" />
                <asp:PostBackTrigger ControlID="Button4" />
                  <asp:PostBackTrigger ControlID="Button5" />
                  <asp:PostBackTrigger ControlID="Button3" />
                 <asp:AsyncPostBackTrigger ControlID="TextBox34" EventName="TextChanged" />
                 <asp:AsyncPostBackTrigger ControlID="TextBox35" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
  
        <br />
                
         
      
                            
                        
         
</asp:Content>

