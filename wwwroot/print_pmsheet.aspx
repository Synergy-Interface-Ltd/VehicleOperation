<%@ Page Title="Print PM Sheet" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="print_pmsheet.aspx.vb" Inherits="print_pmsheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        @media print {
            thead {
                display: table-header-group;
            }

            #text {
                visibility: hidden
            }

            tfoot {
                display: table-footer-group;
            }
        }

        @media screen {
            thead {
                display: block;
            }

            tfoot {
                display: block;
            }
        }

        table {
            border-collapse: collapse;
        }

        tr {
            border: solid;
            border-width: 1px 0;
        }

            tr:first-child {
                border-top: none;
            }

            tr:last-child {
                border-bottom: none;
            }

        thead {
            display: table-header-group;
        }

        tfoot {
            display: table-footer-group;
        }

        .truncated {
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            width: 590px;
        }
    </style>
    <style type="text/css">
        input[type="checkbox"]:checked + label::after {
            content: '';
            position: absolute;
            width: 1.2ex;
            height: 0.4ex;
            background: rgba(0, 0, 0, 0);
            top: 0.9ex;
            left: 0.4ex;
            border: 3px solid black;
            border-top: none;
            border-right: none;
            -webkit-transform: rotate(-45deg);
            -moz-transform: rotate(-45deg);
            -o-transform: rotate(-45deg);
            -ms-transform: rotate(-45deg);
            transform: rotate(-45deg);
        }

        input[type="checkbox"] {
            line-height: 2.1ex;
        }

        input[type="radio"],
        input[type="checkbox"] {
            position: absolute;
            left: -999em;
        }

            input[type="checkbox"] + label {
                position: relative;
                overflow: hidden;
                cursor: pointer;
            }

                input[type="checkbox"] + label::before {
                    content: "";
                    display: inline-block;
                    vertical-align: -25%;
                    height: 2ex;
                    width: 2ex;
                    background-color: white;
                    border: 1px solid rgb(166, 166, 166);
                    border-radius: 4px;
                    box-shadow: inset 0 2px 5px rgba(0,0,0,0.25);
                    margin-right: 0.5em;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <asp:Button runat="server" ID="Button1" Text="Button" />


    <script type="text/javascript"> 
        window.onload = clear();
        function clear() {
            document.body.innerHTML = document.body.innerHTML.replace(/&lt; tr &gt;/g, '');
        };


    </script>

</asp:Content>


