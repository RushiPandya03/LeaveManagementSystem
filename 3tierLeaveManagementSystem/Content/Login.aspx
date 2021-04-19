<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Content_Login" %>

<!DOCTYPE html>
<html lang="en">

<!-- Mirrored from colorlib.com/etc/lf/Login_v15/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 23 Feb 2021 12:25:46 GMT -->
<!-- Added by HTTrack -->
<!-- /Added by HTTrack -->
<head>
    <title></title>
    <link rel="icon" type="image/png" href="<%=ResolveClientUrl("~/Content/assets/images1/icons/favicon.ico") %>" />
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/vendor1/bootstrap/css/bootstrap.min.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/fonts1/font-awesome-4.7.0/css/font-awesome.min.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/fonts1/Linearicons-Free-v1.0.0/icon-font.min.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/vendor1/animate/animate.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/vendor1/css-hamburgers/hamburgers.min.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/vendor1/animsition/css/animsition.min.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/vendor1/select2/select2.min.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/vendor1/daterangepicker/daterangepicker.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/css1/util.css") %>">
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/assets/css1/main.css") %>">
    <%--<style>
        .form-control:focus{
            border-color:black;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <div class="login100-form-title" style="background-image: url(assets/images/bg-01.jpg)">
                        <span class="login100-form-title-1">Leave Management System
                        </span>
                        <span class="login100-form-title-1">Login
                        </span>
                    </div>
                    <div class="container log-form ">
                        <div class="shadow p-3 bg-white rounded">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblErrorMesseage" runat="server" EnableViewState="false" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="padding-left:4em">
                            <div class="col-md-3 col-form-label" >
                                Username<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                                    ControlToValidate="txtUserName"
                                    ErrorMessage="Enter Username"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Login" />
                            </div>
                        </div>
                        <br />
                        <div class="row" style="padding-left:4em">
                            <div class="col-md-3 col-form-label">
                                Password<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                    ControlToValidate="txtPassword"
                                    ErrorMessage="Enter Password"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Login" />
                            </div>
                        </div>
                        <br />
                        <div class="row mb-4">
                            <div class="col-md-12 text-center">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info" OnClick="btnLogin_Click" ValidationGroup="Login" />
                            </div>
                        </div>
                            <%--<div class="row">
                                <div class="col-md-12 text-right">
                                    <asp:LinkButton Style="font-size: 1.2em" ID="btnCreateNewUser" runat="server" OnClick="btnCreateNewUser_Click"><u>Create New User?</u></asp:LinkButton>
                                </div>
                            </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/jquery/jquery-3.2.1.min.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/animsition/js/animsition.min.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/bootstrap/js/popper.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/bootstrap/js/bootstrap.min.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/select2/select2.min.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/daterangepicker/moment.min.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/daterangepicker/daterangepicker.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/vendor1/countdowntime/countdowntime.js") %>"></script>
        <script src="<%=ResolveClientUrl("~/Content/assets/js1/main.js") %>"></script>
        <script>
            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', 'UA-23581568-13');
        </script>
    </form>
</body>

<!-- Mirrored from colorlib.com/etc/lf/Login_v15/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 23 Feb 2021 12:25:51 GMT -->
</html>
