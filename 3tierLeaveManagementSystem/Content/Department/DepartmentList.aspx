<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DepartmentList.aspx.cs" Inherits="Content_Department_DepartmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    DepartmentList
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Department
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container mb-5">
        <div class="row">
            <div class="offset-md-1 col-md-11 text-right" style="padding-bottom: 1.5em">
                <asp:Button ID="btnAddDepartment" CssClass="btn bg-gradient-primary" runat="server" Text="Add Department" OnClick="btnAddDepartment_Click" />
            </div>
        </div>
        <asp:Panel ID="PanelErrorMesseage" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-12 alert alert-warning" role="alert" style="font-size: large">
                    <asp:Label ID="lblErrorMesseage" runat="server"></asp:Label></div>
            </div>
        </asp:Panel>
        <div class="row card">
            <div class="col-md-12 card-body">
                <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvDepartment_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" ItemStyle-Width="250px">
                            <ItemStyle Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Functions" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" CssClass="btn btn-sm bg-gradient-danger rounded-pill" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("DepartmentID") %>' />
                                <asp:Button ID="btnEdit" CssClass="btn btn-sm bg-gradient-info rounded-pill" runat="server" Text="Edit" CommandName="EditRecord" CommandArgument='<%# "~/Content/Department/DepartmentAddEdit.aspx?DepartmentID=" + Eval("DepartmentID").ToString() %>' />
                            </ItemTemplate>

                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $('#<%= gvDepartment.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "autoWidth": false,
                columnDefs: [{ orderable: false, targets: [1] }],
            });
        });
    </script>
</asp:Content>

