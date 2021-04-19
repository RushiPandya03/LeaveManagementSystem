<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="HolidayList.aspx.cs" Inherits="Content_Holiday_HolidayList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    HolidayList
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Holiday
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container mb-5">
        <div class="row">
            <div class="offset-md-1 col-md-11 text-right" style="padding-bottom: 1.5em">
                <asp:Button ID="btnAddHoliday" CssClass="btn bg-gradient-primary" runat="server" Text="Add Holiday" OnClick="btnAddHoliday_Click" />
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
                <asp:GridView ID="gvHoliday" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvHoliday_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Holiday"/>
                        <asp:BoundField DataField="Date" HeaderText="Date"/>
                        <asp:BoundField DataField="Day" HeaderText="Day"/>
                        
                        <asp:TemplateField HeaderText="Functions">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" CssClass="btn btn-sm bg-gradient-danger rounded-pill" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("HolidayID") %>' />
                                <asp:Button ID="btnEdit" CssClass="btn btn-sm bg-gradient-info rounded-pill" runat="server" Text="Edit" CommandName="EditRecord" CommandArgument='<%# "~/Content/Holiday/HolidayAddEdit.aspx?HolidayID=" + Eval("HolidayID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $('#<%= gvHoliday.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "autoWidth": false,
                columnDefs: [{ orderable: false, targets: [3] }],
            });
        });
    </script>
</asp:Content>

