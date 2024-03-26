<%@ Page Title="Service Management" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="service_management.aspx.vb" Inherits="service_management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl" 
            Text="Service Management"></asp:Label>
    </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="1">
            <ProgressTemplate>
            <div align="center" style="width: 100% ; position: absolute; top: 0px; left: 0px; z-index:4"><asp:Image ID="Image4" runat="server" ImageUrl="~/image/loading.gif"  
                /></div>
                 </ProgressTemplate>
            </asp:UpdateProgress>
                 <br />
    <asp:Label ID="Label5" runat="server" Text="Search By Job ID :"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="58px"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Search" />
&nbsp;<asp:Label ID="Label6" runat="server" Text="Search By Manual RO :"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Width="58px"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="Search" />
    
    <hr />
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label8" runat="server" Text="Update Job Status :"></asp:Label>
        <asp:Button ID="Button8" runat="server" Text="Not Started" Width="100px" />
        <asp:Button ID="Button5" runat="server" Text="Start" Width="100px" />
        <asp:Button ID="Button6" runat="server" Text="Complete" Width="100px" />
        <asp:Button ID="Button9" runat="server" Text="Update" Visible="False" 
            Width="100px" />
        <asp:Label ID="Label7" runat="server" Text="Update Remarks :"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button7" runat="server" Text="Update Remarks" />
    </asp:Panel>
    <asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
    
    <asp:Button ID="Button4" runat="server" Text="Button" />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" 
        UpdateMode="Conditional">
        <ContentTemplate>
        <div align="left" 
                style="border: 0px solid #000000; width: 1246px; overflow: auto;">
                <asp:Label ID="Label32" runat="server" Text="List of Services :"></asp:Label>
                <br />
                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Text="All" />
                </div>

            <div align="left" 
                
                style="border: 1px solid #000000; width: 1246px; overflow: auto; height: 500px;">
                
                <asp:GridView ID="GridView1" runat="server">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div align="left" 
                style="border: 0px solid #000000; width: 1246px; overflow: auto;">
                <asp:Label ID="Label33" runat="server" Text="List of Dent and Paint :"></asp:Label>
                <br />
                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Text="All" />
            </div>
            <div align="left" 
                
                style="border: 1px solid #000000; width: 1246px; overflow: auto; height: 500px;">
                <asp:GridView ID="GridView2" runat="server">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="CheckBox2" EventName="CheckedChanged">
            </asp:AsyncPostBackTrigger>
             <asp:AsyncPostBackTrigger ControlID="CheckBox3" EventName="CheckedChanged">
            </asp:AsyncPostBackTrigger>
            <%--<asp:PostBackTrigger ControlID="CheckBox2" />--%>
            <asp:PostBackTrigger ControlID="Button2" />
             <asp:PostBackTrigger ControlID="Button3" />
              <asp:PostBackTrigger ControlID="Button5" />
               <asp:PostBackTrigger ControlID="Button6" />
                <asp:PostBackTrigger ControlID="Button7" />
                 <asp:PostBackTrigger ControlID="Button8" />
                  <asp:PostBackTrigger ControlID="Button9" />

        </Triggers>
    </asp:UpdatePanel>
    
    <br />
    </asp:Content>

