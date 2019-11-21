<%@ Page Title="Tracking Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="BestLogistic.Tracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row m-3">
            <div class="col-12 col-lg-6">
                <h3 class="font-weight-bolder">Track your parcel</h3>
                <div class="">
                    <div class="form-group form-group-default required">
                        <asp:Label runat="server" AssociatedControlID="TrackingNumber" Text="TRACKING NUMBER" />
                        <asp:TextBox runat="server" ID="TrackingNumber" TextMode="SingleLine" CssClass="form-control" />
                    </div>
                    <div class="d-flex justify-content-end">
                        <asp:Button runat="server" ID="TrackBtn" CssClass="track-btn" Text="Track" />
                    </div>
                </div>
                <asp:Repeater runat="server" ID="ParcelStatusRepeater">
                    <HeaderTemplate>
                        <table class="col-12 my-3 table">
                            <thead class="thead-light">
                                <tr>
                                    <th>Date</th>
                                    <th>Time</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                                <tr>
                                    <td><%# ((BestLogistic.Models.ParcelStatus)Container.DataItem).date.ToShortDateString() %></td>
                                    <td><%# ((BestLogistic.Models.ParcelStatus)Container.DataItem).time.ToShortTimeString() %></td>
                                    <td><%# ((BestLogistic.Models.ParcelStatus)Container.DataItem).status %></td>
                                </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="d-flex justify-content-center">
                    <asp:Button runat="server" ID="ShowMoreBtn" Text="Show more" 
                        CssClass="btn btn-default" OnClick="ShowMoreBtn_Click"/>
                </div>
            </div>
            <iframe src="https://www.google.com/maps/embed?pb=!1m28!1m12!1m3!1d63553.81349545988!2d100.37767636881259!3d5.399698149277485!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m13!3e0!4m5!1s0x304ac5069ac06373%3A0xfd24d9999c7bb46a!2sButterworth%2C%20Penang!3m2!1d5.438030899999999!2d100.38819199999999!4m5!1s0x304ac8e598b893bf%3A0x763116f720d28c2a!2sBukit%20Mertajam%2C%20Penang!3m2!1d5.365457999999999!2d100.45900909999999!5e0!3m2!1sen!2smy!4v1571562212847!5m2!1sen!2smy" 
                width="600" height="450" frameborder="0" 
                style="border:0;" class="col-lg-6" allowfullscreen=""></iframe>
        </div>
    </div>
    
</asp:Content>
