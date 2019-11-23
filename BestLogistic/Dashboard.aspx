<%@ Page Title="Dashboard Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BestLogistic.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row dashboard-margin dashboard-out-border ">
            <div class="col-sm-3 text-center dashboard-margin">
                <img src="images/pic.png" class="img-thumbnail dashboard-pic">
                <div class="dashboard-name">
                    <asp:Label ID="Username" runat="server"/>
                </div>
            </div>
            <div class="col-sm-9 row dashboard-margin ">
                <div class="col-sm-4 col-md-4 col-lg-2-4 vertical-center" >
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            Pending
                        </div>
                        <div class="text-center">
                            0
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 col-md-4 col-lg-2-4 vertical-center" >
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            Pick-Up
                        </div>
                        <div class="text-center">
                            0
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 col-md-4 col-lg-2-4 vertical-center" >
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            In transit
                        </div>
                        <div class="text-center">
                            0
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 col-md-4 col-lg-2-4 vertical-center" >
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            Out of delivery
                        </div>
                        <div class="text-center">
                            0
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 col-md-4 col-lg-2-4 vertical-center" >
                    <div class="dashboard-border">
                        <div class="text-center dashboard-upper text-white p-8">
                            Delivered
                        </div>
                        <div class="text-center">
                            0
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row dashboard-margin">
            <div class="col-lg-12 p-0 dashboard-border ">
                <div class="text-center dashboard-upper text-white p-8">
                    Shipment history
                </div>
                <div class="row">
                    <div class="col-3 text-center" >
                        <asp:Label ID="Label1" runat="server" Text="Tracking Number"></asp:Label>
                    </div>
                    <div class="col-3 text-center" >
                        <asp:Label ID="Label2" runat="server" Text="Sender Infomation"></asp:Label>
                    </div>
                    <div class="col-3 text-center" >
                        <asp:Label ID="Label3" runat="server" Text="Receiver Infomation"></asp:Label>
                    </div>
                    <div class="col-3 text-center" >
                        <asp:Label ID="Label4" runat="server" Text="Delivered Date"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
