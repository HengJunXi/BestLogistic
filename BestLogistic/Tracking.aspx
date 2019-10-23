<%@ Page Title="Tracking Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="BestLogistic.Tracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 col-lg-5 mx-auto px-3 px-sm-0 track">
        <h3 class="font-weight-bolder">Track Your Parcel</h3>
        <div class="">
            <form class="" action="#" method="post">
                <div class="">
                    <div class="form-group form-group-default required">
                        <label for="trackingNumber">TRACKING NUMBER</label>
                        <input type="text" class="form-control" id="trackingNumber" name="" value="" required>
                    </div>
                </div>
                <div class="d-flex justify-content-end">
                    <button type="button" name="button" class="track-btn">Track</button>
                </div>
            </form>
        </div>
    </div>
    <iframe src="https://www.google.com/maps/embed?pb=!1m28!1m12!1m3!1d63553.81349545988!2d100.37767636881259!3d5.399698149277485!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m13!3e0!4m5!1s0x304ac5069ac06373%3A0xfd24d9999c7bb46a!2sButterworth%2C%20Penang!3m2!1d5.438030899999999!2d100.38819199999999!4m5!1s0x304ac8e598b893bf%3A0x763116f720d28c2a!2sBukit%20Mertajam%2C%20Penang!3m2!1d5.365457999999999!2d100.45900909999999!5e0!3m2!1sen!2smy!4v1571562212847!5m2!1sen!2smy" width="600" height="450" frameborder="0" style="border:0;" allowfullscreen=""></iframe>
</asp:Content>
