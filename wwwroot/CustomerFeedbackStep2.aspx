<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerFeedbackStep2.aspx.cs" Inherits="CustomerFeedbackStep2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12 row">
            <h1 class="text-center">Feedback After One Day</h1>
        </div>
        <div class="col-12 p-5">
            <asp:GridView ID="gridFeedback" AutoGenerateSelectButton="true"  Width="100%" AutoGenerateColumns="true"
                runat="server"  OnSelectedIndexChanged="gridFeedback_SelectedIndexChanged">
            </asp:GridView>
        </div>
    </div>
    <asp:Button runat="server" ID="Button1"/>
</asp:Content>

