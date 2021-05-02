<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="LeaveTypeList.aspx.cs" Inherits="Content_LeaveType_LeaveTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    LeaveType List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Leave Type
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container mb-5">
        <div class="row">
            <div class="offset-md-1 col-md-11 text-right" style="padding-bottom:1.5em">
                <asp:Button ID="btnAddLeaveType" runat="server" CssClass="btn bg-gradient-primary" Text="Add LeaveType" OnClick="btnAddLeaveType_Click" />
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
                
                <asp:GridView ID="gvLeaveType" CssClass="table table-bordered table-striped"  runat="server" AutoGenerateColumns="False" OnRowCommand="gvLeaveType_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Leave Type" DataField="LeaveType" ItemStyle-Width="250px"/>
                        <asp:BoundField HeaderText="Total Days" DataField="TotalDays" ItemStyle-Width="250px"/>
                        <asp:BoundField HeaderText="Username" DataField="Username" ItemStyle-Width="250px"/>
                        <asp:TemplateField HeaderText="Functions" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm bg-gradient-danger rounded-pill" CommandName="DeleteRecord" CommandArgument=' <%# Eval("LeaveTypeID") %> '/>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm bg-gradient-info rounded-pill" CommandName="EditRecord" CommandArgument=' <%# "~/Content/LeaveType/LeaveTypeAddEdit.aspx?LeaveTypeID="  + Eval("LeaveTypeID").ToString() %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#<%= gvLeaveType.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable(
                {
                    columnDefs: [{ orderable: false, targets: [3] }],
                });
        });
    </script>
</asp:Content>

