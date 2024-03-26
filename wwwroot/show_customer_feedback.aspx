<%@ Page Title="Details Customer FeedBack" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="show_customer_feedback.aspx.vb" Inherits="show_customer_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_GridView1 tr{
            white-space: pre-wrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
            <asp:Label ID="Label1" runat="server" SkinID="header_lbl" Text="Details of Customer Report"></asp:Label>
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
        &nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" Text="Show" />
        &nbsp;<asp:Label ID="Label22" runat="server" Text="Search By Job ID :"></asp:Label>
        <asp:TextBox ID="TextBox21" runat="server" Width="79px"></asp:TextBox>
        &nbsp;<asp:Button ID="Button6" runat="server" Text="Show" />

        <asp:Button ID="Button2" runat="server" Text="Button" />

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
    
    <div style="width:100%;overflow: auto;">

        <asp:GridView ID="GridView1" autogeneratecolumns="false" runat="server" HeaderStyle-CssClass="HeaderStyle">
            <columns>
                <asp:boundfield datafield="Job Id" headertext="Job ID" />
                <asp:boundfield datafield="Status" headertext="Status" />
             
                
                <asp:TemplateField HeaderText="Address">
                    <itemtemplate> 
                        <div style="width: 250px;white-space: initial; ">
                            <%# Eval("Details") %>
                        </div>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:boundfield datafield="Opi. Date" headertext="Opinion Date" />
                <asp:boundfield datafield="Issue Date" headertext="Issue Date" />
                <asp:boundfield datafield="Enter_by" headertext="Enter_by" />
                <asp:boundfield datafield="customer_name" headertext="Customer Name" />
             
                 <asp:TemplateField HeaderText="Address">
                    <itemtemplate> 
                        <div style="width: 150px;white-space: initial; ">
                            <%# Eval("address") %>
                        </div>
                    </itemtemplate>
                </asp:TemplateField>

              
                <asp:boundfield datafield="email" headertext="Email" />
                <asp:boundfield datafield="mobile" headertext="Mobile" />
                <asp:boundfield datafield="In Date" headertext="In Date" />
                <asp:boundfield datafield="Del. Date" headertext="Del. Date" />
                <asp:boundfield datafield="vehicle" headertext="Vehicle" />
                <asp:boundfield datafield="reg_no" headertext="Regis. No" />
                <asp:boundfield datafield="model" headertext="Modal" />
                <asp:boundfield datafield="eng_no" headertext="Eng. No" />
                <asp:boundfield datafield="chesis_no" headertext="Chesis. No" />
                <asp:boundfield datafield="bill_no" headertext="Bill No" />
                <asp:boundfield datafield="engineer" headertext="Engineer" />
                <asp:boundfield datafield="customer_id" headertext="Customer Id" />
            </columns>
        </asp:GridView>
    </div>
   
</asp:Content>



