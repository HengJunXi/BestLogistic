<%@ Page Title="Order Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSummary.aspx.cs" Inherits="BestLogistic.OrderSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="dashboard-margin dashboard-out-border ">
            <div class="m-3 text-center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/done.png" Width="56px" Height="56px" />
                <h2>Payment Successful!</h2>
            </div>
            <div class="mb-3 text-center">
                <h2>Thank you for using us!</h2>
            </div>
            <div class="container">
                <div class="row dashboard-margin">
                    <div class="col-lg-12 p-0 dashboard-border btm-nor-rad">
                        <div class="dashboard-upper text-white p-8">
                            <div class="row">
                                <div class="col-lg-7 col-md-6 vertical-center">
                                    <asp:Label ID="Label1" runat="server" Text="Order Summary:" Font-Size="XX-Large" CssClass="profile-title-text"></asp:Label><br />
                                    <asp:Label ID="tNo" runat="server" Text="" Font-Size="X-large" CssClass="profile-title-text"></asp:Label>
                                </div>
                                <div class="row col-lg-5 col-md-6 vertical-center">
                                    <div class="col-7">
                                        <asp:Label ID="Label10" runat="server" Text="PRICE :"></asp:Label>
                                    </div>
                                    <div class="col-5">
                                        <asp:Label ID="priceOrder" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-7 border-bottom">
                                        <asp:Label ID="Label11" runat="server" Text="PICK UP :"></asp:Label>
                                    </div>
                                    <div class="col-5 border-bottom">
                                        <asp:Label ID="pickUpPriceOrder" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-7 border-bottom">
                                        <asp:Label ID="Label2" runat="server" Text="TOTAL PAYMENT :" Font-Size="Larger" Font-Bold="true"></asp:Label>
                                    </div>
                                    <div class="col-5 border-bottom">
                                        <asp:Label ID="totalPayment" runat="server" Text="" Font-Size="Larger" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>               
                    </div>
                    <div class="col-lg-12 p-0 collapse-border thick-border ">
                        <a href="#detail" data-toggle="collapse" class="text-decoration-none">
                            <div class="dashboard-upper text-white p-8">
                                <div class="vertical-center">
                                    <asp:Label ID="Label15" runat="server" Text="Click for more detail" Font-Size="large" CssClass="profile-title-text text-white"></asp:Label>
                                </div>
                            </div>
                        </a>
                        <div id="detail" class="row collapse">
                            <div class="col-md-6 col-sm-11 py-3 ml-3">
                                <div><asp:Label ID="Label3" runat="server" Text="Sender Information" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="SenderNameTitle" runat="server" Text="Name: "></asp:Label>
                                    <asp:Label ID="SenderName" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="SenderPNoTitle" runat="server" Text="Contact No: "></asp:Label>
                                    <asp:Label ID="SenderPhoneNo" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="SIDType" runat="server" Text="ID Type: "></asp:Label>
                                    <asp:Label ID="IDType" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="SIDNumber" runat="server" Text="ID Number: "></asp:Label>
                                    <asp:Label ID="IDNo" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="Label7" runat="server" Text="Address"></asp:Label></div>
                                <div><asp:Label ID="addressCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="postcodeCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="locationCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="cityCheckout" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="stateCheckout" runat="server" Text=""></asp:Label></div>
                            </div>
                            <div class="col-md-5 col-sm-11 ml-3 pt-3">
                                <div><asp:Label ID="Label9" runat="server" Text="Services" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="Label12" runat="server" Text="Service Type: " ></asp:Label>
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
                            <div class="col-md-6 col-sm-11 py-3 ml-3">
                                <div><asp:Label ID="Label20" runat="server" Text="Receiver Information" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="ReceiverNameTitle" runat="server" Text="Name: "></asp:Label>
                                    <asp:Label ID="ReceiverName" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="ReceiverPhoneNoTitle" runat="server" Text="Contact No: "></asp:Label>
                                    <asp:Label ID="ReceiverPhoneNo" runat="server" Text=""></asp:Label>
                                </div>
                                <div><asp:Label ID="ReceiverAddTitle" runat="server" Text="Address"></asp:Label></div>
                                <div><asp:Label ID="ReceiverAddress" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverPostal" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverLocation" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverCity" runat="server" Text=""></asp:Label></div>
                                <div><asp:Label ID="ReceiverState" runat="server" Text=""></asp:Label></div>
                            </div>
                            <div class="col-md-5 col-sm-11 ml-3 pt-3">
                                <div><asp:Label ID="Label29" runat="server" Text="Parcel Details" Font-Bold="true"></asp:Label></div>
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
                <asp:Button ID="btnNextSend" runat="server" Text="Send Another Package" CssClass="btn btn-default" Font-Size="Large" OnClick="btnNextSend_Click" />
            </div>
        </div>
    </div>
</asp:Content>
