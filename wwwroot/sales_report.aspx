﻿<%@ Page Title="Sales Report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="sales_report.aspx.vb" Inherits="sales_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
            <asp:Label ID="Label1" runat="server" SkinID="header_lbl" Text="Sales Report"></asp:Label>
        </div>
        <br />
        <br />
    
        <asp:Label ID="Label10" runat="server" Text="From Date :"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Width="79px"></asp:TextBox>
        <a id="A1" name="anchor1" 
            onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox4,'img2','dd/MM/yyyy'); return false;">
        <img id="img2" src="calendar.gif" /></a>
        <asp:Label ID="Label18" runat="server" Text="To Date :"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server" Width="79px"></asp:TextBox>
        <a id="A2" name="anchor1" 
            onclick="cal.select(document.forms['aspnetForm'].ctl00$ContentPlaceHolder1$TextBox9,'img1','dd/MM/yyyy'); return false;">
        <img id="img1" src="calendar.gif" /></a> &nbsp; 
        &nbsp;&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Exclude Date" />
&nbsp;<asp:Label ID="Label21" runat="server" 
            Text="Search By Customer Name :"></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server" Width="79px"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="Show" />
        &nbsp;<asp:Label ID="Label22" runat="server" Text="Search By Job ID :"></asp:Label>
        <asp:TextBox ID="TextBox21" runat="server" Width="79px"></asp:TextBox>
        &nbsp;<asp:Button ID="Button6" runat="server" Text="Show" 
             /> &nbsp;<asp:Label ID="Label2" runat="server" Text="Search By Invoice No :"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="79px"></asp:TextBox>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Show" 
             /> &nbsp;<hr />
        <asp:Label ID="Label3" runat="server" Text="Search By Sales Executive :"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="79px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label4" runat="server" Text="Type of Customer :"></asp:Label><asp:DropDownList
            ID="DropDownList1" runat="server">
        </asp:DropDownList>
    <asp:Button ID="Button3" runat="server" Text="Show" 
             />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:TextBox ID="TextBox20" runat="server" Visible="False"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="TextBox4" Display="None" 
            ErrorMessage="Please Enter Valid From Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="PM"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="TextBox9" Display="None" 
            ErrorMessage="Please Enter Valid To Date..." SetFocusOnError="True" 
            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
            ValidationGroup="PM"></asp:RegularExpressionValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="PM" />
        <br /><br /> <div id="HeaderDiv" align="left">
  </div>
<div id="DataDiv"  align="left" 
        
           style="border: 1px solid #333333; width: 1185px; overflow: auto; height: 504px;"  
           onscroll="Onscrollfnction();">
    <asp:GridView ID="GridView1" runat="server" ShowFooter="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView></div>
       <br /><br /> <div id="Div1" align="left">
  </div>
<div id="Div2"  align="left" 
        
           style="border: 1px solid #333333; width: 1185px; overflow: auto; height: 504px;"  
           onscroll="Onscrollfnction();">
    <asp:GridView ID="GridView2" runat="server" ShowFooter="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView></div>
   
</asp:Content>



