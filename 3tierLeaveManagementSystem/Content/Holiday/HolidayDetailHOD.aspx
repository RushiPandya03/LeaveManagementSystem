<%@ Page Title="" Language="C#" MasterPageFile="~/Display.master" AutoEventWireup="true" CodeFile="HolidayDetailHOD.aspx.cs" Inherits="Content_Holiday_HolidayDetailHOD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDisplayName" Runat="Server">
    <div class="image">
        <asp:Image ID="Image" runat="server" class="img-circle elevation-2" alt="User Image" />
    </div>
    <div class="info">
        <a href="#" class="d-block">Hii,
        <asp:Label ID="lblDisplayname" runat="server"></asp:Label></a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphNavbar" Runat="Server">
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Home/HOD_Home.aspx" class="nav-link" ID="HyperLink8" runat="server">
            <i class="nav-icon fas fa-home"></i>
            <p>Home</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Leave/LeaveStatus.aspx" class="nav-link" ID="HyperLink9" runat="server">
            <i class="nav-icon fas fa-edit"></i>
            <p>Leave</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Holiday/HolidayDetailHOD.aspx" class="nav-link" ID="HyperLink1" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrumbsTitle" Runat="Server">
    Holiday 2021
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" Runat="Server">
    Holiday
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container mb-5">
        <asp:Panel ID="PanelErrorMesseage" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-12 alert alert-warning" role="alert" style="font-size: large">
                    <asp:Label ID="lblErrorMesseage" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="col-12">
                    <div class="info-box">
                        <span class="info-box-icon bg-info"><i class="far fa-envelope"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Upcoming Holiday</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblUpcomingHoliday" runat="server" EnableViewState="False"></asp:Label>
                            </span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
            </div>
            <!-- /.col -->
        </div>
        <asp:Panel ID="PanelGV" runat="server">
            <div class="row card">
                <div class="col-md-12 card-body">
                    <asp:GridView ID="gvHoliday" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Holiday" />
                            <asp:BoundField DataField="Date" HeaderText="Date" />
                            <asp:BoundField DataField="Day" HeaderText="Day" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
    <script>
        $(document).ready(function () {
            $('#<%= gvHoliday.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "autoWidth": false,
                });
        });
    </script>
</asp:Content>

