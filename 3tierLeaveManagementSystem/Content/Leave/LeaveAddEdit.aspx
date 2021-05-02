<%@ Page Title="" Language="C#" MasterPageFile="~/Display.master" AutoEventWireup="true" CodeFile="LeaveAddEdit.aspx.cs" Inherits="Content_Leave_LeaveAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        label:not(.form-check-label):not(.custom-file-label) {
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphNavbar" runat="Server">
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Home/Employee_Home.aspx" class="nav-link" ID="HyperLink8" runat="server">
            <i class="nav-icon fas fa-home"></i>
            <p>Home</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Leave/LeaveList.aspx" class="nav-link" ID="HyperLink9" runat="server">
            <i class="nav-icon fas fa-edit"></i>
            <p>Leave</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Holiday/HolidayDetail.aspx" class="nav-link" ID="HyperLink1" runat="server">
            <i class="nav-icon fas fa-bahai"></i>
            <p>Holiday</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbLogOut_Click" class="nav-link bg-gradient-primary">
            <i class="nav-icon fas fa-sign-out-alt"></i>
            <p>Log Out</p>
        </asp:LinkButton>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDisplayName" runat="Server">
    <div class="image">
        <asp:Image ID="Image" runat="server" class="img-circle elevation-2" alt="User Image" />
    </div>
    <div class="info" style="color: white">
        Hii,
        <asp:Label ID="lblDisplayname" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" runat="Server">
    <asp:Label ID="lblHeadContent" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" runat="Server">
    Leave
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="container-fluid">
        <asp:Panel ID="PanelSuccess" runat="server" CssClass="ml-2 mr-2" Visible="False">
            <div class="row">
                <div class="col-md-12 alert alert-success" role="alert" style="font-size: large">
                    <asp:Label ID="lblSuccess" runat="server" EnableViewState="false" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelErrorMesseage" runat="server" CssClass="ml-2 mr-2" Visible="False">
            <div class="row">
                <div class="col-md-12 alert alert-danger" role="alert" style="font-size: large">
                    <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="false" />
                </div>
            </div>
        </asp:Panel>
        <div class="card pt-4">
            <div class="form-group row ml-1">

                <div class="col-md-2 col-form-label"><b>Leave Type</b><span class="text-danger">*</span></div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLeaveType" runat="server"
                        ErrorMessage="Enter LeaveType"
                        CssClass="text-danger"
                        ControlToValidate="ddlLeaveType"
                        SetFocusOnError="True"
                        Display="Dynamic" ValidationGroup="Save" InitialValue="-1" />
                </div>
            </div>
            <div class="form-group row ml-1">
                <div id="lblLeaveDuration" class="col-md-2 col-form-label"><b>Leave Duration</b><span class="text-danger">*</span></div>
                <div class="col-md-4 col-form-label">
                    <asp:RadioButton ID="rbFullLeave" runat="server" Text="FullLeave" GroupName="LeaveDuration" OnCheckedChanged="rbFullLeave_CheckedChanged" AutoPostBack="True" />
                    <asp:RadioButton ID="rbHalfLeave" runat="server" GroupName="LeaveDuration" Text="HalfLeave" OnCheckedChanged="rbHalfLeave_CheckedChanged" AutoPostBack="True" />
                </div>
            </div>
            <div class="form-group row ml-1">
                <div class="col-md-2 col-form-label">
                    <b>
                        <asp:Label runat="server" ID="lblLeaveStartDate">Leave StartDate<span class="text-danger">*</span></asp:Label></b>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtLeaveStartDate" runat="server" CssClass="form-control" TextMode="Date" />
                    <asp:RequiredFieldValidator ID="rfvLeaveStartDate" runat="server"
                        ErrorMessage="Enter LeaveStartDate"
                        CssClass="text-danger"
                        ControlToValidate="txtLeaveStartDate"
                        SetFocusOnError="True"
                        Display="Dynamic" ValidationGroup="Save" />
                </div>
            </div>
            <asp:Panel runat="server" ID="panelLeaveEndDate">
                <div class="form-group row ml-1">
                    <div class="col-md-2 col-form-label">
                        <asp:Label runat="server" ID="lblLeaveEndDate"><b>Leave EndDate</b><span class="text-danger">*</span></asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtLeaveEndDate" runat="server" CssClass="form-control" TextMode="Date" />
                        <asp:CompareValidator ID="cvLeaveEndDate" runat="server"
                            ErrorMessage="Enter leave end date properly"
                            ControlToCompare="txtLeaveStartDate"
                            ControlToValidate="txtLeaveEndDate"
                            Operator="GreaterThan"
                            SetFocusOnError="True"
                            Display="Dynamic" ValidationGroup="Save"
                            CssClass="text-danger"></asp:CompareValidator>
                    </div>
                </div>
            </asp:Panel>
            <div class="form-group row ml-1">
                <div class="col-md-2 col-form-label"><b>Leave Reason</b><span class="text-danger">*</span></div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtLeaveReason" runat="server" CssClass="form-control" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator ID="rfvLeaveReason" runat="server"
                        ErrorMessage="Enter LeaveReason"
                        CssClass="text-danger"
                        ControlToValidate="txtLeaveReason"
                        SetFocusOnError="True"
                        Display="Dynamic" ValidationGroup="Save" />
                </div>
            </div>
            <div class="form-group row ml-1">
                <div class="col-md-2 offset-md-2 ">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn bg-gradient-primary" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn bg-gradient-danger" OnClick="btnCancel_Click" />
                </div>
                <div class="col-md-3">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

