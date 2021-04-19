<%@ Page Title="" Language="C#" MasterPageFile="~/Display.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="Content_User_EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavbar" runat="Server">
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphDisplayName" runat="Server">
    <div class="image">
        <asp:Image ID="Image" runat="server" class="img-circle elevation-2" alt="User Image" />
    </div>
    <div class="info" style="color: white">
        Hii,
        <asp:Label ID="lblDisplayname" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitle" runat="Server">
    Employee Details
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" runat="Server">
    Leave / Employee Details
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-sm-6 col-12">
                <asp:HyperLink ID="hlLeaveStatus" runat="server" NavigateUrl='~/Content/Leave/LeaveStatus.aspx'>
                    <div class="info-box">
                        <span class="info-box-icon bg-info"><i class="far fa-envelope"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Pending Leave Request</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblPendingLeave" runat="server" EnableViewState="False"></asp:Label>
                            </span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </asp:HyperLink>
            </div>

            <!-- /.col -->

            <div class="col-md-6 col-sm-6 col-12">
                <asp:HyperLink ID="hlEmployeeDetails" runat="server" NavigateUrl='~/Content/User/EmployeeDetails.aspx'>
                    <div class="info-box">
                        <span class="info-box-icon bg-info"><i class="far fa-user"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Total Employee</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblTotalEmployee" runat="server" EnableViewState="False"></asp:Label>
                            </span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->

                </asp:HyperLink>
            </div>

            <!-- /.col -->
        </div>
    </div>
    <div class="container mt-4 mb-5">
        <asp:Panel ID="PanelErrorMesseage" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-12 alert alert-warning" role="alert" style="font-size: large">
                    <asp:Label ID="lblErrorMesseage" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelGV" runat="server">
            <div class="row card">
                <div class="col-md-12 card-body">
                    <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="Username" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="DOB" HeaderText="DOB" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                            <asp:BoundField DataField="Experience" HeaderText="Experience" />
                            <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                            <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" />
                            <asp:BoundField DataField="InstituteName" HeaderText="InstituteName" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
    <script>
        $(function () {
            $('#<%= gvEmployeeDetails.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "autoWidth": false,
            });
        });
    </script>
</asp:Content>
