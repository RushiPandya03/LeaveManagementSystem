<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DesignationList.aspx.cs" Inherits="Content_Designation_DesignationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    DesignationList
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Designation
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container mb-4">
        <div class="row">
            <div class="offset-md-1 col-md-11 text-right">
                <asp:Button ID="btnAddDesignation" runat="server" Text="Add Designation" CssClass="btn bg-gradient-primary" OnClick="btnAddDesignation_Click" />
            </div>
        </div>
        <asp:Panel ID="PanelErrorMesseage" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-12 alert alert-warning" role="alert" style="font-size: large">
                    <asp:Label ID="lblErrorMesseage" runat="server"></asp:Label></div>
            </div>
        </asp:Panel>
    </div>
    <div class="container">
        <div class="row card">
            <div class="col-md-12 card-body">
                <asp:GridView ID="gvDesignation" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvDesignation_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" ItemStyle-Width="250px" />
                        <asp:TemplateField HeaderText="Oprations" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm bg-gradient-danger rounded-pill" CommandName="DeleteRecord" CommandArgument='<%# Eval("DesignationID") %>' />
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm bg-gradient-info rounded-pill" CommandName="EditRecord" CommandArgument='<%# "~/Content/Designation/DesignationAddEdit.aspx?DesignationID=" + Eval("DesignationID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $('#<%= gvDesignation.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "autoWidth": false,
                columnDefs: [{ orderable: false, targets: [1] }],
            });
        });
    </script>
</asp:Content>

