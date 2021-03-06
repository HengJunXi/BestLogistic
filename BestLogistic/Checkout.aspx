﻿<%@ Page Title="Checkout Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BestLogistic.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="dashboard-margin dashboard-out-border ">
            <div class="px-4">
                <h2>Checkout</h2>
            </div>
             
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
            <div class="row">
                <div class="col-lg-7 col-md-6">
                </div>
                <div class="col-lg-5 col-md-6 ">
                    <div>
                        <h4><asp:Label ID="CheckOut" runat="server" Text="Your Order Summary" CssClass="font-bold"></asp:Label></h4>
                    </div>
                    <div class="row">
                        <div class="col-9">
                            <h5><asp:Label ID="DeliveryItemCharges" runat="server" Text="Delivery / Item Charges (RM) : "></asp:Label></h5>
                        </div>
                        <div class="col-3">
                            <h5><asp:Label ID="price" runat="server" Text="" ForeColor="Red"></asp:Label></h5>
                        </div>
                        <div class="col-9">
                            <h5><asp:Label ID="PUFee" runat="server" Text="Pickup Fee (RM): "></asp:Label></h5>
                        </div>
                        <div class="col-3">
                            <h5><asp:Label ID="pickUpPrice" runat="server" Text="" ForeColor="Red"></asp:Label></h5>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row dashboard-margin">
                    <div class="col-lg-12 p-0 dashboard-border btm-nor-rad">
                        <div class="dashboard-upper text-white p-8">
                            <div class="row">
                                <div class="col-lg-9 col-md-7 col-sm-6 vertical-center">
                                    <asp:Label ID="Label8" runat="server" Text="Your Order" Font-Size="large" CssClass="profile-title-text"></asp:Label>
                                </div>
                                <div class="row col-lg-3 col-md-5 col-sm-6">
                                    <div class="col-7">
                                        <asp:Label ID="PriceTitle" runat="server" Text="PRICE (RM) : "></asp:Label>
                                    </div>
                                    <div class="col-5">
                                        <asp:Label ID="priceOrder" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-7">
                                        <asp:Label ID="PickUpPriceTitle" runat="server" Text="PICK UP (RM) : "></asp:Label>
                                    </div>
                                    <div class="col-5">
                                        <asp:Label ID="pickUpPriceOrder" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-sm-11 py-3 ml-3">
                                <div><asp:Label ID="SenderInfo" runat="server" Text="Sender Information" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="NameTitle" runat="server" Text="Name: "></asp:Label>
                                    <asp:Label ID="SenderName" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="SPhoneno" runat="server" Text="Contact No: "></asp:Label>
                                    <asp:Label ID="SenderPhoneNo" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="SIDType" runat="server" Text="ID Type: "></asp:Label>
                                    <asp:Label ID="SenderIDType" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="SIDNumber" runat="server" Text="ID Number: "></asp:Label>
                                    <asp:Label ID="SenderIDNumber" runat="server" Text=""></asp:Label>
                                </div>
                                 <div><asp:Label ID="EmailTitle" runat="server" Text="Email:"></asp:Label>
                                      <asp:Label ID="SenderMail" runat="server" Text=""></asp:Label>
                                 </div>
                                <div><asp:Label ID="AddTitle" runat="server" Text="Address:"></asp:Label></div>
                                <div><asp:Label ID="addressCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="postcodeCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="locationCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="cityCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="stateCheckout" runat="server" Text=""></asp:Label></div>
                            </div>
                            <div class="col-md-5 col-sm-11 ml-3 pt-3">
                                <div><asp:Label ID="ServicesTitle" runat="server" Text="Services" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="ServicetypeTitle" runat="server" Text="Service Type: " ></asp:Label>
                                    <asp:Label ID="ServiceType" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="PickUpDateTitle" runat="server" Text="Pick Up Date: " ></asp:Label>
                                    <asp:Label ID="PickUpDate" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="PickUpTimeTitle" runat="server" Text="Pick Up Time: " ></asp:Label>
                                    <asp:Label ID="PickUpTime" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="RemarksTitle" runat="server" Text="Remark: " ></asp:Label>
                                    <asp:Label ID="Remarks" runat="server" Text="" Width="300px"></asp:Label>
                                </div>
                            </div>
                        </div>                
                    </div>
                    <div class="col-lg-12 p-0 collapse-border ">
                        <a href="#detail" data-toggle="collapse" class="text-decoration-none">
                            <div class="dashboard-upper text-white p-8">
                                <div class="vertical-center">
                                    <asp:Label ID="Label15" runat="server" Text="More Details" Font-Size="large" CssClass="profile-title-text text-white"></asp:Label>
                                </div>
                            </div>
                        </a>
                        <div id="detail" class="row collapse">
                            <div class="col-md-6 col-sm-11 py-3 ml-3">
                                <div><asp:Label ID="ReceiverInfo" runat="server" Text="Receiver Information" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="ReceiverNameTitle" runat="server" Text="Name: "></asp:Label>
                                    <asp:Label ID="ReceiverName" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="ReceiverPhoneNoTitle" runat="server" Text="Contact No: "></asp:Label>
                                    <asp:Label ID="ReceiverPhoneNo" runat="server" Text=""></asp:Label>
                                </div>
                                 <div><asp:Label ID="RmailTitle" runat="server" Text="Email:"></asp:Label>
                                      <asp:Label ID="ReceiverMail" runat="server" Text=""></asp:Label>
                                 </div>
                                <div><asp:Label ID="ReceiverAddTitle" runat="server" Text="Address"></asp:Label></div>
                                <div><asp:Label ID="ReceiverAddress" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverPostal" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverLocation" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverCity" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverState" runat="server" Text=""></asp:Label></div>
                            </div>
                            <div class="col-md-5 col-sm-11 ml-3 pt-3">
                                <div><asp:Label ID="ParcelDetails" runat="server" Text="Parcel Details" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="ParcelTypeTitle" runat="server" Text="Type: " ></asp:Label>
                                    <asp:Label ID="ParcelType" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="PieceTitle" runat="server" Text="Pieces: " ></asp:Label>
                                    <asp:Label ID="Piece" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="ContentTitle" runat="server" Text="Content: " ></asp:Label>
                                    <asp:Label ID="Content" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="ValueTitle" runat="server" Text="Value of Content(RM): " ></asp:Label>
                                    <asp:Label ID="Value" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="WeightTitle" runat="server" Text="Weight(kg): " ></asp:Label>
                                    <asp:Label ID="Weight" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>                
                    </div>
                </div>
            </div>
            <div class="m-3 d-flex justify-content-end">
                <asp:Button ID="btnUpdate" runat="server" Text="Pay" CssClass="btn btn-default" Width="128px" Font-Size="X-Large" OnClick="btnUpdate_Click" />
            </div>
        </div>
         </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="btnUpdate" />
            </Triggers>
    </asp:UpdatePanel>
       
    </div>
 </div>
</asp:Content>
