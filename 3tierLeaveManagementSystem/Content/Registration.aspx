<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Content_Registration" %>

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
    <style>
        label {
            display: inline-block !important;
        }

        /*#PanelEmployee {
            display: inline-block !important;
        }

        #PanelHOD {
            display: inline-block !important;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <div class="login100-form-title" style="background-image: url(assets/images/bg-01.jpg)">
                        <span class="login100-form-title-1">
                            <asp:Label ID="lblHeadeing" runat="server"></asp:Label>
                        </span>
                    </div>
                    <div class="container log-form">
                        <div class="shadow p-3 bg-white rounded">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label><br />
                                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-2 col-sm-2 col-form-label">
                                Username<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                                    ControlToValidate="txtUserName"
                                    ErrorMessage="Enter Username"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                            <div class="col-md-2 col-sm-2 col-form-label">
                                Password<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                    ControlToValidate="txtPassword"
                                    ErrorMessage="Enter Password"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-2 col-form-label">
                                Display name<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDisplayName" runat="server"
                                    ControlToValidate="txtDisplayName"
                                    ErrorMessage="Enter Displayname"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                            <div class="col-md-2 col-form-label">
                                MobileNo<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server"
                                    ControlToValidate="txtMobileNo"
                                    ErrorMessage="Enter MobileNo"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 col-form-label">
                                DOB<span class="text-danger">*</span>
                            </label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDOB" runat="server"
                                    ControlToValidate="txtDOB"
                                    ErrorMessage="Enter DOB"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                            <label class="col-md-2">
                                Gender<span class="text-danger">*</span>
                            </label>
                            <div class="col-md-4 col-form-label">
                                <asp:RadioButton ID="rbMale" runat="server" Checked="True" GroupName="Gender" Text="Male" />
                                <asp:RadioButton ID="rbFemale" runat="server" Text="Female" GroupName="Gender" />
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-2 col-form-label">
                                Email<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                    ControlToValidate="txtEmail"
                                    ErrorMessage="Enter Email"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                            <div class="col-md-2 col-form-label">
                                Experience<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvExperience" runat="server"
                                    ControlToValidate="txtExperience"
                                    ErrorMessage="Enter Experience"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-2 col-form-label">
                                Qualification<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQualification" runat="server"
                                    ControlToValidate="txtQualification"
                                    ErrorMessage="Enter Qualification"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                            <div class="col-md-2 col-form-label">
                                City<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                    ControlToValidate="txtCity"
                                    ErrorMessage="Enter City"
                                    Display="Dynamic"
                                    CssClass="text-danger" ValidationGroup="Save" />
                            </div>
                        </div>

                        <div class="row form-group">
                            <div class="col-md-2 col-form-label">
                                Department<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server"
                                    ErrorMessage="Enter Department"
                                    CssClass="text-danger"
                                    ControlToValidate="ddlDepartment"
                                    SetFocusOnError="True"
                                    Display="Dynamic" ValidationGroup="Save" InitialValue="-1" />
                            </div>


                           <div class="col-md-2 col-form-label" >
                                Designation<span class="text-danger">*</span>
                            </div>

                            <asp:Panel ID="PanelEmployee" class="col-md-4" runat="server">
                                <div>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvDesignation" runat="server"
                                        ErrorMessage="Enter Designation"
                                        CssClass="text-danger"
                                        ControlToValidate="ddlDesignation"
                                        SetFocusOnError="True"
                                        Display="Dynamic" ValidationGroup="Save" InitialValue="-1" />
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="PanelHOD" runat="server" >
                                <div class="col-md-4 col-form-label" >
                                    <asp:Label ID="lblHOD" runat="server" Text="HOD" ></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>

                        <div class="row form-group">
                            <div class="col-md-2 col-form-label">
                                Institute<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlInstitute" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvInstitute" runat="server"
                                    ErrorMessage="Enter Institute"
                                    CssClass="text-danger"
                                    ControlToValidate="ddlInstitute"
                                    SetFocusOnError="True"
                                    Display="Dynamic" ValidationGroup="Save" InitialValue="-1" />
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-3 col-form-label">
                                Select Photo<span class="text-danger">*</span>
                            </div>
                            <div class="col-md-5 col-form-label">
                                <asp:FileUpload ID="fuStaffPhoto" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvStaffPhoto" runat="server"
                                    ErrorMessage="Please select a file to upload"
                                    CssClass="text-danger"
                                    ControlToValidate="fuStaffPhoto"
                                    SetFocusOnError="True"
                                    Display="Dynamic" ValidationGroup="Save" />
                            </div>
                        </div>
                        <div class="row mb-4" style="padding-left: 190px">
                            <div class="col-md-12">
                                <asp:Button runat="server" ID="btnSave" ValidationGroup="Save" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger ml-2" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
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
        </div>
    </form>
</body>

<!-- Mirrored from colorlib.com/etc/lf/Login_v15/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 23 Feb 2021 12:25:51 GMT -->
</html>

