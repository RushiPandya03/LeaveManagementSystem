<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DesignationAddEdit.aspx.cs" Inherits="Content_Designation_DesignationAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" runat="Server">
    <asp:Label ID="lblPageHeader" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" runat="Server">
    Designation
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
        <div class="card pt-3">
        
        <div class="form-group row ml-1">
            <label class="col-md-2 col-form-label"><b>Designation Name</b><span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtDesignationName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDesignationName" runat="server"
                    ErrorMessage="Enter Designation Name"
                    CssClass="text-danger"
                    ControlToValidate="txtDesignationName"
                    SetFocusOnError="True"
                    Display="Dynamic" ValidationGroup="Save" />
            </div>
        </div>
        <div class="form-group row ml-1">
            <div class="col-md-2 offset-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn bg-gradient-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn bg-gradient-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div></div>
</asp:Content>

