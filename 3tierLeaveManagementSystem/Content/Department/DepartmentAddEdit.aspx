<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DepartmentAddEdit.aspx.cs" Inherits="Content_Department_DepartmentAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    <asp:Label ID="lblHeadContent" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Department
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
                    <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="false" />
                </div>
            </div>
        </asp:Panel>
        <div class="card pt-3">
        <div class="form-group row ml-1">
            <label class="col-form-label col-md-2" ><b>Department Name</b><span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtDepartmentName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" 
                    ErrorMessage="Enter Department Name"
                    CssClass="text-danger"
                    ControltoValidate="txtDepartmentName" 
                    ValidationGroup="Save" 
                    SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row ml-1">
            <div class="col-md-2 offset-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn bg-gradient-primary" ValidationGroup="Save" OnClick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn bg-gradient-danger" OnClick="btnCancel_Click"/>
            </div>
        </div>
    </div>
        </div>
</asp:Content>

