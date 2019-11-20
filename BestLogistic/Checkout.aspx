<%@ Page Title="Checkout Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BestLogistic.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="dashboard-margin dashboard-out-border ">
            <div class="px-4">
                <h2>Checkout</h2>
            </div>
            <div class="row">
                <div class="col-lg-7 col-md-6">
                </div>
                <div class="col-lg-5 col-md-6 ">
                    <div>
                        <h4><asp:Label ID="Label1" runat="server" Text="Your Order Summary" CssClass="font-bold"></asp:Label></h4>
                    </div>
                    <div class="row">
                        <div class="col-9">
                            <h5><asp:Label ID="Label2" runat="server" Text="Delivery / Item Charges (RM) : "></asp:Label></h5>
                        </div>
                        <div class="col-3">
                            <h5><asp:Label ID="price" runat="server" Text="13.00"></asp:Label></h5>
                        </div>
                        <div class="col-9">
                            <h5><asp:Label ID="Label4" runat="server" Text="Pickup Fee (RM): "></asp:Label></h5>
                        </div>
                        <div class="col-3">
                            <h5><asp:Label ID="pickUpPrice" runat="server" Text="5.00"></asp:Label></h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
