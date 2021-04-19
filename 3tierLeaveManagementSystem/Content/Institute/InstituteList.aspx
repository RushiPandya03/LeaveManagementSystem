<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="InstituteList.aspx.cs" Inherits="Content_Institute_InstituteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    InstituteList
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Institute
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container mb-5">
        <div class="row">
            <div class="offset-md-1 col-md-11 text-right" style="padding-bottom:1.5em">
                <asp:Button ID="btnAddInstitute" runat="server" CssClass="btn bg-gradient-primary" Text="Add Institute" OnClick="btnAddInstitute_Click" />
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
                <asp:GridView ID="gvInstitute" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvInstitute_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" ItemStyle-Width="350px"/>
                        <asp:TemplateField HeaderText="Function" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-sm bg-gradient-danger rounded-pill" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("InstituteID") %>'/>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-sm bg-gradient-info rounded-pill" Text="Edit" CommandName="EditRecord" CommandArgument='<%# "~/Content/Institute/InstituteAddEdit.aspx?InstituteID=" + Eval("InstituteID").ToString() %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $('#<%= gvInstitute.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "autoWidth": false,
                columnDefs: [{ orderable: false, targets: [1] }],
            });
        });
    </script>
</asp:Content>

