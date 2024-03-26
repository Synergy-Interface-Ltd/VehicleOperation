<%@ Page Title="Customer FeedBack" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="collect_opinion.aspx.vb" Inherits="collect_opinion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
            <asp:Label ID="Label1" runat="server" SkinID="header_lbl" Text="Customer FeedBack"></asp:Label>
        </div>
        <br />
        <br />

     <div style="width:100%;overflow: auto;">
        
        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView>
    </div>
    <div style="width:100%">
        <table>
            <tr>
                <td>
                     <asp:Label runat="server" Text="Customer Feedback In Details:"></asp:Label> 
                </td>
           
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="FeedBack" runat="server" TextMode="MultiLine"
                        Columns="50"
                        Rows="10"></asp:TextBox>
                </td>
           
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Status Type:"></asp:Label> 
                    <asp:DropDownList ID="DropdownList1" Width="200px" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;">
                    <asp:Button runat="server" Width="100px" ID="Button10" Text="Submit" />
                    <asp:Button runat="server" Width="100px"  ID="Button11" Text="Edit" />
                </td>
            </tr>
        </table>
    </div>


      <asp:Button ID="Button2" runat="server" Text="Button" />
        
   
</asp:Content>



