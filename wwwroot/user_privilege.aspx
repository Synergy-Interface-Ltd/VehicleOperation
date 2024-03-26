<%@ Page Title="Create User Privilege" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="user_privilege.aspx.vb" Inherits="user_privilege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label1" runat="server" SkinID="header_lbl" 
            Text="Create User Privilege"></asp:Label>
    </div><br />
    <table style="border: 1px solid #333333;">
        <tr>
            <td align="left" valign="top" rowspan="2">
        
                        <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" 
                            ImageSet="Inbox">
                            <HoverNodeStyle Font-Underline="True" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
                                VerticalPadding="0px" />
                        </asp:TreeView>
            </td>
            <td align="left" valign="top">
        
                        <asp:Label ID="Label24" runat="server" Text="Select Branch :" Visible="False"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="110px" 
                            Visible="False">
                        </asp:DropDownList>
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="All" Visible="False" />
                        &nbsp;<asp:Label ID="Label15" runat="server" Text="Search By Employee ID :"></asp:Label>
                        <asp:TextBox ID="TextBox15" runat="server" Width="89px"></asp:TextBox>
                        <asp:Button ID="Button6" runat="server" Text="Search" Width="70px" 
                    CausesValidation="False"  />
                        <asp:Button ID="Button8" runat="server" Text="Show All" Width="70px" 
                    CausesValidation="False" Visible="False"  />
                        <asp:Button ID="Button7" runat="server" Text="Button" />
                        <asp:Button ID="Button1" runat="server" Text="Give Permission" /><br /><br />
                <div id="HeaderDiv" align="left">
  </div>

 
                        <div id="DataDiv"  
                style="border: 1px solid #330099; width: 847px; height: 139px; overflow: auto;"  
                onscroll="Onscrollfnction();" align="left">
          
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            </div>
            </td>
        </tr>
               
       
    </table>
</asp:Content>





