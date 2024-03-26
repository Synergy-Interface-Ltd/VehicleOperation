<%@ Page Title="Cheque Management" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cheque_action.aspx.vb" Inherits="cheque_action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
            <asp:Label ID="Label1" runat="server" SkinID="header_lbl" Text="Cheque Management"></asp:Label>
        </div>
        <br />
                <asp:Label ID="Label24" runat="server" Text="Branch Code :"></asp:Label>
                &nbsp;<asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
            &nbsp;<asp:Label ID="Label25" runat="server" Text="Branch Name :"></asp:Label>
                &nbsp;<asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
            <hr />
<br />
    <asp:Button ID="Button2" runat="server" Text="Button" />
    <asp:Label ID="Label10" runat="server" Text="From Date :"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="79px"></asp:TextBox>
    <a id="A1" name="anchor1" 
        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox4,'img2','dd/MM/yyyy'); return false;">
    <img id="img2" src="calendar.gif" /></a>
    <asp:Label ID="Label18" runat="server" Text="To Date :"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox9" runat="server" Width="79px"></asp:TextBox>
    <a id="A2" name="anchor1" 
        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox9,'img1','dd/MM/yyyy'); return false;">
    <img id="img1" src="calendar.gif" /></a> &nbsp; 
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Exclude Date" />
        &nbsp;&nbsp;<asp:Label ID="Label21" 
        runat="server" Text="Search By :"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
&nbsp;<asp:Button ID="Button4" runat="server" Text="Show" />
&nbsp; <asp:Label ID="Label26" 
        runat="server" Text="Search By Cheque No :"></asp:Label>
    <asp:TextBox ID="TextBox26" runat="server" Width="67px"></asp:TextBox>
    <asp:Button ID="Button5" runat="server" Text="Show" />
&nbsp;<hr />
    <asp:Label ID="Label5" runat="server" Text="Cheque Action Date :"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox25" runat="server" Width="88px"></asp:TextBox>
    <a id="A3" name="anchor2" 
        onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox25,'img3','dd/MM/yyyy'); return false;">
    <img id="img3" src="calendar.gif" /></a>
    <asp:Label ID="Label27" 
        runat="server" Text="Bank :"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Width="128px">
    </asp:DropDownList>
    <asp:Button ID="Button3" runat="server" Text="Update" />
    <br />
    <hr />
     <div style="border: 0px solid #000000; width: 993px; overflow: auto;" 
        align="left">
<asp:GridView ID="GridView1" runat="server">
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate><table cellpadding="0" cellspacing="0" border="0"><tr><td align="left" valign="top">
            <asp:RadioButton ID="RadioButton6" runat="server" GroupName="Action" Text="No Action" /></td>
                <td align="left" valign="top"><asp:RadioButton ID="RadioButton1" runat="server" GroupName="Action" Text="Deposite" /></td>
                
                <td align="left" valign="top">
                    &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
                </tr></table>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Undeposite" ShowHeader="False">
            <ItemTemplate>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Action" />
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Pending" ShowHeader="False">
            <ItemTemplate>
                <asp:RadioButton ID="RadioButton5" runat="server"  GroupName="Action"/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Confirmed" ShowHeader="False">
            <ItemTemplate>
                <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="Action"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bounce" ShowHeader="False">
            <ItemTemplate>
                <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="Action"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView></div>
</asp:Content>

