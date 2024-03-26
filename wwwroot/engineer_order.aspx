<%@ Page Title="Order Placement" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="engineer_order.aspx.vb" Inherits="engineer_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label31" runat="server" SkinID="header_lbl"
            Text="Notifications"></asp:Label>
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
    <table border="0" cellpadding="1" cellspacing="2">

        <tr>

            <td align="left" valign="top" colspan="2" style="border: 1px solid #333333">
                <asp:UpdatePanel ID="UpdatePanel122" runat="server" RenderMode="Inline"
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Parts ID" HeaderText="Parts ID" />
                                <asp:BoundField DataField="Parts No" HeaderText="Parts No" />
                                <asp:BoundField DataField="Parts Name" HeaderText="Parts Name" />
                                <%--<asp:BoundField DataField="Description" HeaderText="Description" />--%>
                                <asp:BoundField DataField="Requisit Quantity" HeaderText="Requisit Quantity" />
                                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="Order Date" HeaderText="Order Date" />
                                <asp:BoundField DataField="App delivary date" HeaderText="App Delivary Date" />
                                <asp:BoundField DataField="Available Quantity" HeaderText="Available Quantity" />
                                <asp:BoundField DataField="Requisit Quantity" HeaderText="Order Quantity" />
                              
                                  <asp:BoundField DataField="service_id" HeaderText="Service Id" />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>

                </asp:UpdatePanel>
            </td>
        </tr>

    </table>
     <asp:Button runat="server"  ID="Button1" Text="Delete" />
</asp:Content>



