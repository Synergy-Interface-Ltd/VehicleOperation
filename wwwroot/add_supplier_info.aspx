<%@ Page Title="Add Order Status" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="add_supplier_info.aspx.vb" Inherits="add_order_status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 0px; margin: 0px; width: 100%; background-color: #003399;">
        <asp:Label ID="Label1" runat="server" SkinID="header_lbl"
            Text="Add Order Status"></asp:Label>
    </div>
    <br />
    <div style="display: flex; width: 100%; justify-content: center;" align="center">
        <div>

            <div style="display: flex;">
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Supplier Name :"></asp:Label>
                </div>
                <div style="margin-left: 5px">
                    <asp:TextBox Width="250px" ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </div>

            <div style="display: flex; margin-top: 10px;">
                <div style="margin-right: 40px">
                    <asp:Label ID="Label6" runat="server" Text="Address:"></asp:Label>
                </div>
                <div style="margin-left: 5px">
                    <asp:TextBox Width="250px" TextMode="MultiLine" ID="TextBox2" runat="server"></asp:TextBox>
                </div>
            </div>

            <div style="display: flex; margin-top: 10px;">
                <div style="margin-right: 45px">
                    <asp:Label ID="Label61" runat="server" Text="Mobile:"></asp:Label>
                </div>
                <div style="margin-left: 5px">
                    <asp:TextBox Width="250px" ID="TextBox3" runat="server"></asp:TextBox>
                </div>
            </div>

            <div style="display: flex;margin-top:10px">
                <div style="margin-right: 10px">
                    <asp:Label ID="Label62" runat="server" Text="Supplier Type:"></asp:Label>
                </div>
                <div style="margin-left: 5px">
                    <asp:DropDownList Width="257px" ID="Dropdownlist1" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div style="display: flex;margin-top: 10px;">
                <div style="margin-right: 45px"> 
                    <asp:Label ID="Label2" runat="server" Text="Action:"></asp:Label>
                </div>
                <div style="margin-left: 5px">
                    <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                </div>
            </div>

            <div style="padding-left: 70px;margin-top:10px" align="center">
                <asp:Button ID="Button2" runat="server" Text="Submit" ValidationGroup="s"
                    Width="100px" />
                <asp:Button ID="Button3" runat="server" Text="Edit" ValidationGroup="s"
                    Width="100px" />
                <asp:Button ID="Button4" runat="server" Text="Delete" Width="100px" />
                <asp:Button ID="Button5" runat="server" Text="Refresh" Width="100px" />
                <asp:Button ID="Button6" runat="server" Text="Button" />
            </div>





            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="TextBox1" Display="None"
                ErrorMessage="Please Enter Status Name..." SetFocusOnError="True"
                ValidationGroup="s"></asp:RequiredFieldValidator>


            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
            <br />
        </div>
        <div style="margin-left: 50px">
            <div style="max-height: 200px; overflow: auto;">
                <asp:GridView Width="250px" ID="Gridview1" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                    CommandName="Select" Text="Select">
                                </asp:LinkButton>
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

