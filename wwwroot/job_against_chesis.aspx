<%@ Page Title="Order Placement" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="job_against_chesis.aspx.vb" Inherits="job_against_chesis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl"
            Text="Job Against Chesis Number"></asp:Label>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="1">
        <ProgressTemplate>
            <div align="center" style="width: 100%; position: absolute; top: 0px; left: 0px; z-index: 4">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/image/loading.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
    <div style="width:100%;overflow:auto">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True"></asp:GridView>
    </div>
</asp:Content>



