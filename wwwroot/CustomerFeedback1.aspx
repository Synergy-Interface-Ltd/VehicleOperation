<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerFeedback1.aspx.cs" Inherits="CustomerFeedback1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <style type="text/css">
        .horizontalRadioButtonList label {
            display: inline-block;
            margin-right: 10px; /* Adjust the margin as needed */
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server" ID="lblJobId"></asp:Label>
    <div class="row p-5 m-3">
        <h1>Vehicle Solution</h1>
        <h2>1st DAY PSF Feedback</h2>
        <h2>Questionnaire for the valued customer</h2>
        <p style="text-align: left; margin-top: 15px">
            আমাদের সেবার মান সম্পর্কে সম্মানিত সার্ভিস গ্রহীতাদের মনোভাব জানা আমাদের একান্ত প্রয়োজন, যা আমাদেরকে আরও
           উন্নত ও কার্যকরী সেবা প্রদানে সহায়তা করবে এ প্রেক্ষিতে আপনাদের জন্য একটি প্রশ্নমালা তৈরি করা হয়েছে, যা
           পূরণ করতে আপনার 2 মিনিট সময় প্রয়োজন হবে আপনার সহোযোগিতা একান্তভাবে কাম্য |
        </p>
        <div class="col-12 row mt-3">
            <div class="col-3">
                <asp:Label runat="server" Text="সার্ভিস গ্রহীতার নাম : "></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtCustomerName"></asp:TextBox>
            </div>
        </div>
        <div class="col-12 row mt-3">
            <div class="col-3">
                <asp:Label runat="server" Text="গাড়ির নাম ও মডেল  : "></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtCarName"></asp:TextBox>
            </div>
        </div>
        <div class="col-12 row mt-3">
            <div class="col-3">
                <asp:Label runat="server" Text="গাড়ির রেজিঃ নাম্বার : "></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtCarRegistration"></asp:TextBox>
            </div>
        </div>
        <div class="col-12 row mt-3">
            <div class="col-3">
                <asp:Label runat="server" Text="প্রশ্নমালা পূরণের তারিখ : "></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtSubmitDate"></asp:TextBox>
            </div>
        </div>
        <div class="col-12 row mt-3">
            <div class="col-3">
                <asp:Label runat="server" Text="মোবাইল নাম্বার : "></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtMobile"></asp:TextBox>
            </div>
        </div>
        <p style="text-align: left; margin-top: 15px">
            এখানে কোন উত্তরেই ভুল নয় ।উত্তর প্রদানে সম্মত হওয়ায় আপনাকে জানাই অগ্রিম ধন্যবাদ ।
            আপনার অনুমতি সাপাক্ষে নিম্নে প্রশ্নগূলো দেওয়া হল ।
        </p>
        <p style="text-align: left; margin-top: 15px">
            (এখানে প্রয়োজনে টিক ( ✓ ) দিয়ে নির্দিষ্ট করুন)
        </p>
        
        <p style="text-align: left; margin-top: 15px">
            Vehicle Solution এর সাপেক্ষে নিম্নোক্ত ৭ টি ক্ষেত্রে আপনার সন্তুষ্টির মান টিক দিন (খুব বেশি সন্তুষ্টি =৫,
            মোটামুটি =৪, অসন্তুষ্টি=৩,খুব অসন্তুষ্টি=২ , ভীষণ অসন্তুষ্টি=১)
        </p>
        <div class="col-2"></div>
        <div class="col-8 row">
            <table class="table table-bordered" style="border: 1px solid black">
                <thead>
                    <tr>
                        <th scope="col"></th>
                        <th scope="col"></th>
                        <th scope="col">For Official Use</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <p>Rating</p>
                        </td>
                        <td>
                            <asp:RadioButtonList RepeatDirection="Horizontal" CssClass="horizontalRadioButtonList"
                                ID="rdoProblem" runat="server"
                                DataValueField="ans">
                                <asp:ListItem Value="1"> 1</asp:ListItem>
                                <asp:ListItem Value="2"> 2</asp:ListItem>
                                <asp:ListItem Value="3"> 3</asp:ListItem>
                                <asp:ListItem Value="4"> 4</asp:ListItem>
                                <asp:ListItem Value="5"> 5</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtProblem" class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="col-2">
    </div>

    <p style="text-align: left; margin-top: 15px; margin-left: 50px">
        আপনাদের সার্ভিসের মান আরও উন্নত করার জন্য যদি কোন পরামর্শ থাকে নিম্নের ঘরে লিখুন 
    </p>

    <div class="col-12 row mt-3">
        <div class="col-3">
            <asp:Label runat="server" Text="পরামর্শ : "></asp:Label>
        </div>
        <div class="col-6">
            <asp:TextBox CssClass="form-control" runat="server" ID="txtRemarks"></asp:TextBox>
        </div>
    </div>

    <div class="col-12 row mt-3">
        <div class="col-3">
            <asp:Label runat="server" Text="Feeback Type : "></asp:Label>
        </div>
        <div class="col-6">
            <asp:DropDownList runat="server" ID="dtfeedbackType" CssClass="form-control">
                <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                <asp:ListItem Value="Satisfied">Satisfied</asp:ListItem>
                <asp:ListItem Value="Non-Satisfied">Non-Satisfied</asp:ListItem>
                <asp:ListItem Value="Not-Received">Not-Received</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="col-12 mt-4 mb-4" >
        <asp:Button runat="server" OnClick="SubmitBtn_Click" ID="submitBtn" Width="200px" class="btn btn-primary" Text="Submit" />
        <asp:Button runat="server" OnClick="PrintBtn_Click" ID="printBtn" Width="200px" class="btn btn-info" Text="Print (Instant)" />
    </div>
    <asp:Button runat="server" ID="Button1" />
</asp:Content>

