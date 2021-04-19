<%@ Page Title="" Language="C#" MasterPageFile="~/Display.master" AutoEventWireup="true" CodeFile="HOD_Home.aspx.cs" Inherits="Content_Home_Home_After_Login" %>

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
<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrumbsTitle" runat="Server">
    Profile
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphBreadcrumbsTitleSmall" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="container-fluid">
        <asp:Panel ID="PanelErrorMesseage" runat="server" CssClass="ml-2 mr-2" Visible="False">
            <div class="row">
                <div class="col-md-12 alert alert-danger" role="alert" style="font-size: large">
                    <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="false" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="container" style="margin-top: 1em; margin-bottom: 1em">
        <div class="row">
            <div class="offset-md-1 col-md-4">
                <div class="card" style="width: 18rem;">
                    <asp:Image ID="img" runat="server" />
                    <div class="card-body">
                        <h4 class="text-center">
                            <asp:Label ID="lblUsername" runat="server"></asp:Label></h4>
                        <p class="card-text text-center">
                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                        </p>
                    </div>
                    <ul class="list-group list-group-flush text-center">
                        <li class="list-group-item">
                            <asp:Button ID="btnEditProfile" CssClass="btn bg-gradient-primary" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" />
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-md-6 table-responsive card pt-3">
                <table class="table table-bordered table-striped card-body">
                    <tr>
                        <td><b>Mobileno</b></td>
                        <td>
                            <asp:Label ID="lblMobileno" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>DOB</b></td>
                        <td>
                            <asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Gender</b></td>
                        <td>
                            <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Email</b></td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Experience</b></td>
                        <td>
                            <asp:Label ID="lblExperience" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Qualification</b></td>
                        <td>
                            <asp:Label ID="lblQualification" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>City</b></td>
                        <td>
                            <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Designation</b></td>
                        <td>
                            <asp:Label ID="lblDesignation" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Institute</b></td>
                        <td>
                            <asp:Label ID="lblInstitute" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
                <div class="text-right">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

