<%@ Page Title="" Language="C#" MasterPageFile="~/Display.master" AutoEventWireup="true" CodeFile="LeaveList.aspx.cs" Inherits="Content_Leave_LeaveList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphNavbar" runat="Server">
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Home/Employee_Home.aspx" class="nav-link" ID="HyperLink8" runat="server">
            <i class="nav-icon fas fa-home"></i>
            <p>Home</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Leave/LeaveList.aspx" class="nav-link" ID="HyperLink9" runat="server">
            <i class="nav-icon fas fa-edit"></i>
            <p>Leave</p>
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink NavigateUrl="~/Content/Holiday/HolidayDetail.aspx" class="nav-link" ID="HyperLink1" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="cphDisplayName" runat="Server">
    <div class="image">
        <asp:Image ID="Image" runat="server" class="img-circle elevation-2" alt="User Image" />
    </div>
    <div class="info" style="color: white">
        Hii,
        <asp:Label ID="lblDisplayname" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumbsTitle" runat="Server">
    Leave List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbsTitlesmall" runat="Server">
    Leave
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="container">
        <div class="row mt-3">

            <div class="col-md-3">
                <div class="info-box">
                    <span class="info-box-icon bg-info"><i class="far fa-address-book"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Casual Leave</span>
                        <span class="info-box-number">
                            <asp:Label ID="lblCasualLeave" runat="server" EnableViewState="False"></asp:Label>
                        </span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>

            <!-- /.col -->
            <div class="col-md-3">
                <div class="info-box">
                    <span class="info-box-icon bg-info"><i class="fas fa-notes-medical"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Medical Leave</span>
                        <span class="info-box-number">
                            <asp:Label ID="lblMedicalLeave" runat="server" EnableViewState="False"></asp:Label>
                        </span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->

            <div class="col-md-3">
                <div class="info-box">
                    <span class="info-box-icon bg-info"><i class="far fa-thumbs-down"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">LOP</span>
                        <span class="info-box-number">
                            <asp:Label ID="lblLOP" runat="server" EnableViewState="False"></asp:Label>
                        </span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>

            <!-- /.col -->
            <div class="col-md-3">
                <div class="info-box">
                    <span class="info-box-icon bg-info"><i class="fas fa-info-circle"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Other Leave</span>
                        <span class="info-box-number">
                            <asp:Label ID="lblOtherLeave" runat="server" EnableViewState="False"></asp:Label>
                        </span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
        </div>
    </div>
    <div class="container mb-5 mt-4">
        <div class="row">
            <div class="col-md-12 text-right" style="padding-bottom: 1.5em">
                <asp:Button ID="btnAddLeave" CssClass="btn btn-lg bg-gradient-primary" runat="server" Text="Add Leave" OnClick="btnAddLeave_Click" />
            </div>
        </div>
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
                    <asp:GridView ID="gvLeave" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvLeave_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                            <asp:BoundField DataField="LeaveReason" HeaderText="Leave Reason" />
                            <asp:BoundField DataField="LeaveStartDate" HeaderText="Leave From" />
                            <asp:BoundField DataField="LeaveEndDate" HeaderText="Leave To" />
                            <asp:BoundField DataField="LeaveDuration" HeaderText="Leave Duration" />
                            <asp:BoundField DataField="LeaveResponseBy" HeaderText="Response By" />
                            <asp:BoundField DataField="LeaveStatus" HeaderText="Leave Status" />
                            <asp:TemplateField HeaderText="Functions">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" CssClass="btn btn-sm bg-gradient-info" runat="server" Text="Edit" CommandName="EditRecord" CommandArgument='<%# Eval("LeaveID") %>' />
                                    <asp:Button ID="btnDelete" CssClass="btn btn-sm bg-gradient-danger" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("LeaveID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
    <script>
        $(document).ready(function () {
            $('#<%= gvLeave.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "autoWidth": false,
                    columnDefs: [{ orderable: false, targets: [7] }],
                });
        });
    </script>
</asp:Content>

