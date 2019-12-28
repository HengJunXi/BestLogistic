<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BestLogistic.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row dashboard-margin dashboard-out-border ">
            <div class="col-sm-4 text-center dashboard-margin">
                <img src="images/pic.png" class="img-thumbnail dashboard-pic">
                <div class="dashboard-name">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="col-sm-8 row dashboard-margin ">
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_1" runat="server" Text="Email"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="email" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_3" runat="server" Text="Date of Birth"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="dateBirth" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_2" runat="server" Text="Identity Type"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="idType" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 vertical-center">
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            <asp:Label ID="label_4" runat="server" Text="Identity Number"></asp:Label>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="idNum" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row dashboard-margin">
            <div class="col-lg-12 p-0 dashboard-border ">
                <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                        <div class="dashboard-upper text-white p-8">
                            <asp:Label ID="Label8" runat="server" Text="Primary Address" Font-Size="large" CssClass="profile-title-text"></asp:Label>
                        </div>
                        <div class="form-group px-3 pt-3">
                            <asp:Label ID="Label3" runat="server" Text="Address" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="address" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="row p-3">
                            <div class=" col-md-3 col-sm-6 form-group">
                                <asp:Label ID="Label4" runat="server" Text="Post Code" Font-Bold="true"></asp:Label><br />
                                <asp:TextBox ID="postCode" runat="server" Text="" CssClass="form-control" AutoPostBack="true" OnTextChanged="postCode_TextChanged"></asp:TextBox>
                            </div>
                            <div class=" col-md-3 col-sm-6 form-group">
                                <asp:Label ID="Label5" runat="server" Text="Location" Font-Bold="true"></asp:Label><br />
                                <asp:DropDownList ID="userLocation" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="userLocation_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-6 form-group">
                                <asp:Label ID="Label6" runat="server" Text="City" Font-Bold="true"></asp:Label><br />
                                <asp:TextBox ID="city" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-6 form-group">
                                <asp:Label ID="Label7" runat="server" Text="State" Font-Bold="true"></asp:Label><br />
                                <asp:TextBox ID="state" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="px-3 pb-3 d-flex justify-content-end">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update primary address" CssClass="btn btn-default" OnClick="btnUpdate_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                            <asp:TextBox ID="mobileNumber" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="mobileNumber" Display="Static" ForeColor="Red" runat="server" ErrorMessage="Home number cannot be empty"></asp:RequiredFieldValidator>                            
                            <div class="py-3 d-flex justify-content-end">
                                <asp:Button ID="updateMobile" runat="server" Text="Update mobile number" CssClass="btn btn-default" OnClick="updateMobile_Click"/>
                            </div>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="Label10" runat="server" Text="Home Number" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="homeNumber" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="homeNumber" Display="Static" ForeColor="Red" runat="server" ErrorMessage="Home number cannot be empty"></asp:RequiredFieldValidator>
                            <div class="py-3 d-flex justify-content-end">
                                <asp:Button ID="updateHomeNumber" runat="server" Text="Update home number" CssClass="btn btn-default" OnClick="updateHomeNumber_Click" />
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
                            <asp:TextBox ID="currentPassword" runat="server" Text=" " TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="Label14" runat="server" Text="New Password" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="newPassword" runat="server" Text=" " TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div> 
                <div class="px-3 pb-3 d-flex justify-content-end">
                    <asp:Button ID="updatePassword" runat="server" Text="Change new password" CssClass="btn btn-default" OnClick="updatePassword_Click" />
                </div>
            </div>
        </div>
    </div>
    <script>

        function initialiseSelect2() {
            $('#MainContent_userLocation').select2({
                placeholder: {
                    id: '',
                    text: 'Postcode is required'
                }
            });
        }
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(initialiseSelect2);
            initialiseSelect2();
        });
    </script>
</asp:Content>
