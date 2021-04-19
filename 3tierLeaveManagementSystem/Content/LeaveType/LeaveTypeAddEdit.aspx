<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="LeaveTypeAddEdit.aspx.cs" Inherits="Content_LeaveType_LeaveTypeAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    <asp:Label ID="lblHeadComponent" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Leave Type
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageContent" Runat="Server">
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
                    <asp:Label ID="lblErrorMesseage" runat="server" EnableViewState="false" />
                </div>
            </div>
        </asp:Panel>
        <div class="card pt-3">
        <div class="form-group row ml-1">
            <label class="col-md-2 col-form-label"><b>Add LeaveType</b><span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtLeaveType" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLeaveType" runat="server" 
                    ErrorMessage="Enter LeaveType" 
                    ControlToValidate="txtLeaveType" 
                    ValidationGroup="Save" Display="Dynamic" 
                    SetFocusOnError="True"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row ml-1">
            <div class="col-md-2 offset-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn bg-gradient-primary" OnClick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn bg-gradient-danger" OnClick="btnCancel_Click"/>
            </div>
        </div>
    </div></div>
</asp:Content>

