<%@ Page Title="Print Job Sheet" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="job_sheet.aspx.vb" Inherits="job_sheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
    @media print {
    footer {page-break-after: always;}
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399; display: none;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl" 
            Text="Job Sheet"></asp:Label>
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
                    Font-Names="Calibri" Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td align="center" valign="top" style="border: 0px solid #333333">
                <table cellpadding="2" cellspacing="0" 
                    style="border: 1px solid #000000; height: 266px; width: 100%;">
                    <tr>
                        <td align="left" valign="top" colspan="4">
                            <table style="width:100%;">
                                <tr>
                                    <td width="222">
                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/image/Logo.jpg" 
                                            Width="222px" />
                                    </td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="Label38" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Large" Text="Repair Order" Width="300px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label39" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="XX-Large" Text="Vehicle Solution" 
                                            Width="300px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label40" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" 
                                            Text="541-42, Ferajitola, Solmaith, Vatara, Dhaka-1212." Width="358px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label41" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" 
                                            Text="(Nearby Evercare Hospital), Basundhara R/A" Width="300px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label55" runat="server" EnableTheming="False" Font-Bold="True" 
                                            Font-Names="Calibri" Font-Size="Small" 
                                            Text="Tel : 58812690, www.vehiclesolution.net" Width="300px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                           
                            <hr />
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="Customer's Name :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" colspan="3" valign="top">
                            <asp:Label ID="TextBox1" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label2" runat="server" Text="Address :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" colspan="3" valign="top">
                            <asp:Label ID="TextBox2" runat="server" EnableTheming="False" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label3" runat="server" Text="Email :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                        </td>
                        <td align="left" colspan="3" valign="top">
                            <asp:Label ID="TextBox3" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label4" runat="server" Text="Tel No. :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="TextBox4" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="Mobile No. :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="TextBox5" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label6" runat="server" Text="Date (In) :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="TextBox6" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>&nbsp;</td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Time In. :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label34" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                            </asp:DropDownList>
                            <asp:Label ID="Label8" runat="server" Text="Hr." EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            <asp:Label ID="Label35" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                            </asp:DropDownList>
                            <asp:Label ID="Label9" runat="server" Text="Min." EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label10" runat="server" Text="Delivery Date :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="TextBox7" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>&nbsp;</td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label11" runat="server" Text="Delivery Time :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label32" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                            <asp:DropDownList ID="DropDownList3" runat="server" Visible="False">
                            </asp:DropDownList>
                            <asp:Label ID="Label12" runat="server" Text="Hr." EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                            <asp:Label ID="Label33" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                            <asp:DropDownList ID="DropDownList4" runat="server" Visible="False">
                            </asp:DropDownList>
                            <asp:Label ID="Label13" runat="server" Text="Min." EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="bottom" style="border: 0px solid #000000">
                <table style="border: 1px solid #000000; width: 100%; height: 266px;" cellpadding="2" 
                    cellspacing="0">
                    <tr>
                        <td colspan="2" align="right">
                         <div align="right" style="height: 33px; overflow: hidden">
                           <asp:Image ID="Image3" runat="server"  /></div></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label45" runat="server" Text="Automatic Job ID :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox24" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Manual RO No :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small" Visible="False"></asp:Label>
                            <asp:Label ID="Label56" runat="server" Text="Customer's ID :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox26" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                            <asp:Label ID="TextBox14" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label46" runat="server" Text="Bill No :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox25" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Vehicle :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox8" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Reg No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox9" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="Model :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox10" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Eng. No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox11" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Chassis No :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox12" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="KM :" EnableTheming="False" 
                                Font-Bold="True" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TextBox13" runat="server" EnableTheming="False" 
                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <table style="width:100%;" border="0" cellpadding="1" cellspacing="2">
                    <tr>
                        <td align="left" valign="top" colspan="2" style="display: none;">
                            <asp:Label ID="Label36" runat="server" Text="Service Required :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2" style="display: none;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" cellpadding="2" cellspacing="0" style="display: none">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label27" runat="server" Text="Search By Service ID :" 
                                                    Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TextBox20" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text="Search By Service Category :" 
                                                    Width="200px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TextBox17" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" Text="Search By Service Type :" 
                                                    Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TextBox18" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" Text="Search By Car Type :" 
                                                    Width="200px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TextBox19" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button2" runat="server" Text="Search" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                                        <tr>
                                            <td align="left" valign="top" style="display: none">
                                                <div style="border: 0px solid #000000; width: 793px; overflow: auto;">
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
                                                                    <asp:Label ID="TextBox1" runat="server" 
                                                                        Text='<%# Bind("[Unit Service Charge]") %>' Width="100px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty of Service" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="TextBox2" runat="server" Text="1" Width="50px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                             <asp:TemplateField HeaderText="Technician" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList5" runat="server" Width="100px">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:CommandField SelectText="Apply" ShowSelectButton="True" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                            

                                                <div style="border: 0px solid #000000; width: 793px; overflow: auto;">
                                                                                                        <asp:GridView ID="GridView5" runat="server" ShowFooter="True" Width="100%" 
                                                                                                            Font-Names="Calibri" Font-Size="Small" BorderWidth="0px" 
                                                                                                            EnableTheming="False">
                                                        <Columns>
                                                            <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                                                            <asp:CommandField ShowDeleteButton="True" />
                                                        </Columns>
                                                                                                            <RowStyle Wrap="False" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView4" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView5" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="GridView5" EventName="RowDeleting" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                    
                    <td align="center" valign="top" style="display: none;">
                            <table cellpadding="1" cellspacing="2" style="width:100%;">
                                <tr>
                                    <td align="left" valign="top">
                            <asp:Label ID="Label23" runat="server" Text="Walk Around Check :" EnableTheming="False" 
                                            Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="No Valuables Left" EnableTheming="False" 
                                            Font-Names="Calibri" Font-Size="Small" Enabled="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="Attached Sheet" EnableTheming="False" 
                                            Font-Names="Calibri" Font-Size="Small" Enabled="False" />
                                    </td>
                                </tr>
                            </table>
                            <div style="border-top: 1px solid #000000; border-bottom: 1px solid #000000;" 
                                align="center">
                                
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                    Width="396px" EnableTheming="False" Font-Names="Calibri" Font-Size="Small" 
                                    BorderWidth="0px">
                                <Columns>
                                    <asp:BoundField DataField="sl" HeaderText="Sl" />
                                    <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                             <asp:Label ID="TextBox16" runat="server" Text='<%# Bind("Description") %>' 
                                                 Width="275px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                            </asp:GridView>
                                
                               
                                
                            </div>
                            <br />
                           <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                    Font-Size="Medium" Text="Inspected By :" EnableTheming="False"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="display: none;">
                            <asp:Label ID="Label21" runat="server" Text="Customer Complain :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                           
                          <div style="border-top: 1px solid #000000; border-bottom: 1px solid #000000;">
                         
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                  Width="396px" EnableTheming="False" Font-Names="Calibri" Font-Size="Small" 
                                  BorderWidth="0px">
                                <Columns>
                                    <asp:BoundField DataField="sl" HeaderText="Sl" />
                                    <asp:TemplateField HeaderText="Complain">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                             <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("Description") %>' Width="350px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                            </asp:GridView></div>
                           
                            <asp:Label ID="Label22" runat="server" Text="Technician Report :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                            
                        <div style="border-top: 1px solid #000000; border-bottom: 1px solid #000000;">
                         
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                Width="396px" BorderColor="#333333" BorderStyle="Solid" BorderWidth="0px" 
                                EnableTheming="False" Font-Names="Calibri" Font-Size="Small">
                                <Columns>
                                    <asp:BoundField DataField="sl" HeaderText="Sl" />
                                    <asp:TemplateField HeaderText="Report">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                             <asp:Label ID="TextBox15" runat="server" Text='<%# Bind("Description") %>'  Width="350px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                            </asp:GridView></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" style="display: none;">
                            <br />
                            ______________________________<br />
                            <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Medium" Text="Car Owner/Driver's Signature" 
                                EnableTheming="False"></asp:Label>
                           
                        </td>
                        <td align="center" valign="top" style="display: none;">
                            <br />
                            ____________________<br />
                            <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Medium" Text="Checked By" EnableTheming="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" colspan="2" style="display: none;" 
                            width="396px">

                                     <br><DIV style='page-break-after:always'></DIV>

                                     <asp:Label ID="Label48" runat="server" Text="Spare Parts Supply" 
                                         EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                         Font-Size="Medium"></asp:Label>

                        </td>
                    </tr>
                   
                        
                    <tr>
                        <td align="left" valign="top" colspan="1" style="display: none;" 
                            width="396px">

                                     <asp:Label ID="Label47" runat="server" Text="Spare Parts Issue From Store :" 
                                         EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                         Font-Size="Medium"></asp:Label>

                        </td>
                        <td align="left" style="display: none;" valign="top" width="396px">
                                     <asp:Label ID="Label37" runat="server" Text="Spare Parts Demand From Workshop :" 
                                         EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Medium"></asp:Label>

                        </td>
                    </tr>
                   
                        
                    <tr>
                        <td align="left" valign="top" colspan="1" style="display: none;" 
                            width="396px">

                                     <div style="border-top: 1px solid #000000; border-bottom: 1px solid #000000;">
                                                    <asp:GridView ID="GridView8" runat="server" ShowFooter="True" Width="396px" 
                                                        EnableTheming="False" Font-Names="Calibri" Font-Size="Small" 
                                                        BorderWidth="0px">
                                                        <RowStyle Wrap="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    </asp:GridView>
                                                </div>
                                              
                        </td>
                        <td align="left" style="display: none;" valign="top" width="396px">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table cellpadding="2" cellspacing="0" style="display: none">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label29" runat="server" Text="Search By Part ID :" Width="167px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TextBox23" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label28" runat="server" Text="Search By Part No :" Width="200px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="TextBox21" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button3" runat="server" Text="Search" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="border: 0px solid #000000; width: 793px; overflow: auto; display: none;">
                                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                                            Width="100%" EnableTheming="False">
                                            <Columns>
                                                <asp:BoundField DataField="Parts ID" HeaderText="Parts ID" />
                                                <asp:BoundField DataField="Parts No" HeaderText="Parts No" />
                                                <asp:BoundField DataField="Parts Name" HeaderText="Parts Name" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                               <asp:TemplateField ShowHeader="False" HeaderText="Requisit Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="TextBox1" runat="server" Text="1" Width="50px"></asp:Label>
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

                                      <div style="border-top: 1px solid #000000; border-bottom: 1px solid #000000;">
                                                    <asp:GridView ID="GridView7" runat="server" ShowFooter="True" Width="396px" 
                                                        EnableTheming="False" Font-Names="Calibri" Font-Size="Small" 
                                                        BorderWidth="0px">
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
                                                        <RowStyle Wrap="True" HorizontalAlign="Left" VerticalAlign="Top" />
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
                                </Triggers>
                            </asp:UpdatePanel>
                                              
                        </td>
                    </tr>
                   
                        
                    
                    <tr>
                        <td align="center" valign="top" style="display: none;">
                            <table border="0" cellpadding="2" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td align="left" valign="top" width="40%">
                            <asp:Label ID="Label49" runat="server" Text="Accountant :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="left" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000" 
                                        valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                            <asp:Label ID="Label50" runat="server" Text="Total Taka :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="left" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000" 
                                        valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                            <asp:Label ID="Label51" runat="server" Text="Finally Checked By :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="left" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000" 
                                        valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="40%">
                            <asp:Label ID="Label52" runat="server" Text="Signature of Engineer :" 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                                    </td>
                                    <td align="left" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000" 
                                        valign="top">
                                        &nbsp;</td>
                                </tr>
                            </table>
                           
                        </td>
                        <td align="left" valign="top" style="display: none;">
                            <table border="0" cellpadding="2" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td align="left" valign="top" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                            <asp:Label ID="Label53" runat="server" Text="Received the old parts along with satisfactory work of the vehicle." 
                                EnableTheming="False" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000" 
                                        valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" 
                                        style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000" 
                                        valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        &nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top">
                                        _____________________<br />
                            <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                Font-Size="Small" Text="Car Owner/Driver's Signature" 
                                EnableTheming="False"></asp:Label>
                           
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
                <asp:Button ID="Button4" runat="server" Text="Submit" ValidationGroup="s" 
                    Visible="False" />
                <asp:Button ID="Button5" runat="server" Text="Delete" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Content>

