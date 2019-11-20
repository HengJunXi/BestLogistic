<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BestLogistic.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row dashboard-margin dashboard-out-border ">
            <div class="col-sm-4 text-center dashboard-margin">
                <img src="images/pic.png" class="img-thumbnail dashboard-pic">
                <div class="dashboard-name">
                    <asp:Label ID="Label1" runat="server" Text="Loh Shu Yi"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="lohshuyi@hotmail.com"></asp:Label>
                </div>
            </div>
            <div class="col-sm-8 row dashboard-margin ">
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_1" runat="server" Text="Nasionality"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="nation" runat="server" Text="Malaysian"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_3" runat="server" Text="Date of birth"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="dateBirth" runat="server" Text="30/03/1998"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_2" runat="server" Text="Identity Type"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="idType" runat="server" Text="I/C Number"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_4" runat="server" Text="Identity Number"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="idNum" runat="server" Text="980330-08-5972"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row dashboard-margin">
            <div class="col-lg-12 p-0 dashboard-border ">
                <div class="dashboard-upper text-white p-8">
                    <asp:Label ID="Label8" runat="server" Text="Primary Address" Font-Size="large" CssClass="profile-title-text"></asp:Label>
                </div>
                <div class="form-group px-3 pt-3">
                    <asp:Label ID="Label3" runat="server" Text="Address" Font-Bold="true"></asp:Label><br />
                    <asp:TextBox ID="Address" runat="server" Text="35, Jalan Pekaka, Taman Pekaka" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row p-3">
                    <div class=" col-md-3 col-sm-6 form-group">
                        <asp:Label ID="Label4" runat="server" Text="Post Code" Font-Bold="true"></asp:Label><br />
                        <asp:TextBox ID="postCode" runat="server" Text="14300" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class=" col-md-3 col-sm-6 form-group">
                        <asp:Label ID="Label5" runat="server" Text="City" Font-Bold="true"></asp:Label><br />
                        <asp:TextBox ID="location" runat="server" Text="Nibong Tebal" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-sm-6 form-group">
                        <asp:Label ID="Label6" runat="server" Text="State" Font-Bold="true"></asp:Label><br />
                        <asp:TextBox ID="city" runat="server" Text="Nibong Tebal" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-sm-6 form-group">
                        <asp:Label ID="Label7" runat="server" Text="Country" Font-Bold="true"></asp:Label><br />
                        <asp:TextBox ID="state" runat="server" Text="Penang" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="px-3 pb-3 d-flex justify-content-end">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Primary Address" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row dashboard-margin">
            <div class="col-lg-12 p-0 dashboard-border ">
                <div class="dashboard-upper text-white p-8">
                    <asp:Label ID="Label9" runat="server" Text="Contact Number" Font-Size="large" CssClass="profile-title-text"></asp:Label>
                </div>
                <div class="form-group px-3 pt-3">
                    <div class="row">
                        <div class="col-6">
                            <asp:Label ID="Label11" runat="server" Text="Mobile Number" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="TextBox2" runat="server" Text="012-4893823" CssClass="form-control"></asp:TextBox>
                            <div class="py-3 d-flex justify-content-end">
                                <asp:Button ID="Button1" runat="server" Text="Update Mobile Number" CssClass="btn btn-default" />
                            </div>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="Label10" runat="server" Text="Home Number" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="TextBox1" runat="server" Text="05-7171972" CssClass="form-control"></asp:TextBox>
                            <div class="py-3 d-flex justify-content-end">
                                <asp:Button ID="Button2" runat="server" Text="Update Home Number" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </div>              
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row dashboard-margin">
            <div class="col-lg-12 p-0 dashboard-border ">
                <div class="dashboard-upper text-white p-8">
                    <asp:Label ID="Label12" runat="server" Text="Change Password" Font-Size="large" CssClass="profile-title-text"></asp:Label>
                </div>
                <div class="form-group px-3 pt-3">
                    <div class="row">
                        <div class="col-6">
                            <asp:Label ID="Label13" runat="server" Text="Current Password" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="TextBox3" runat="server" Text=" " TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="Label14" runat="server" Text="New Password" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="TextBox4" runat="server" Text=" " TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div> 
                <div class="px-3 pb-3 d-flex justify-content-end">
                    <asp:Button ID="Button4" runat="server" Text="Change New Password" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
