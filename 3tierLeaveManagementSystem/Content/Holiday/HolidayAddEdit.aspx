<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="HolidayAddEdit.aspx.cs" Inherits="Content_Holiday_HolidayAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" runat="Server">
    <asp:Label ID="lblHeadContent" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" runat="Server">
    Holiday
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
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
                <label class="col-form-label col-md-2"><b>Holiday</b><span class="text-danger">*</span></label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtHoliday" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvHoliday" runat="server"
                        ErrorMessage="Enter Holiday Name"
                        CssClass="text-danger"
                        ControlToValidate="txtHoliday"
                        ValidationGroup="Save"
                        SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row ml-1">
                <label class="col-form-label col-md-2"><b>Date</b><span class="text-danger">*</span></label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDate" runat="server"
                        ErrorMessage="Enter Holiday Date"
                        CssClass="text-danger"
                        ControlToValidate="txtDate"
                        ValidationGroup="Save"
                        SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row ml-1">
                <label class="col-form-label col-md-2"><b>Day</b><span class="text-danger">*</span></label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtDay" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDay" runat="server"
                        ErrorMessage="Enter Day"
                        CssClass="text-danger"
                        ControlToValidate="txtDay"
                        ValidationGroup="Save"
                        SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row ml-1">
                <div class="col-md-2 offset-md-2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn bg-gradient-primary" ValidationGroup="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn bg-gradient-danger" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

