<%@ Page Title="Search For Payment" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="sales_report_payment.aspx.vb" Inherits="sales_report_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
            <asp:Label ID="Label1" runat="server" SkinID="header_lbl" 
                Text="Customer Due Report"></asp:Label>
        </div>
        <br />
        <br />
    
        <asp:Label ID="Label21" runat="server" 
            Text="Customer Name :"></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server" Width="79px"></asp:TextBox>
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Due" />
        <asp:Button ID="Button5" runat="server" Text="Show" />
        &nbsp;<asp:Label ID="Label22" runat="server" Text="Customer ID :"></asp:Label>
        <asp:TextBox ID="TextBox21" runat="server" Width="79px"></asp:TextBox>
        &nbsp;<asp:CheckBox ID="CheckBox4" runat="server" Text="Due" />
        <asp:Button ID="Button6" runat="server" Text="Show" 
             />
        <asp:Label ID="Label23" runat="server" Text="Job ID :"></asp:Label>
        <asp:TextBox ID="TextBox22" runat="server" Width="79px"></asp:TextBox>
        <asp:CheckBox ID="CheckBox5" runat="server" Text="Due" />
        <asp:Button ID="Button7" runat="server" Text="Show" 
             />
        <asp:Label ID="Label24" runat="server" Text="Invoice No :"></asp:Label>
        <asp:TextBox ID="TextBox23" runat="server" Width="79px"></asp:TextBox>
        <asp:CheckBox ID="CheckBox6" runat="server" Text="Due" />
        <asp:Button ID="Button8" runat="server" Text="Show" 
             />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:TextBox ID="TextBox20" runat="server" Visible="False"></asp:TextBox>
        <br /><br /> <div id="HeaderDiv" align="left">
  </div>
<div id="DataDiv"  align="left" 
        
           style="border: 1px solid #333333; width: 1185px; overflow: auto; height: 504px;"  
           onscroll="Onscrollfnction();">
    <asp:GridView ID="GridView1" runat="server" ShowFooter="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Receive Payment" />
        </Columns>
    </asp:GridView></div>
       
</asp:Content>





