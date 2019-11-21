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
                                    <asp:Label ID="Label8" runat="server" Text="Order #123" Font-Size="X-large" CssClass="profile-title-text"></asp:Label>
                                </div>
                                <div class="row col-lg-5 col-md-6 vertical-center">
                                    <div class="col-7">
                                        <asp:Label ID="Label10" runat="server" Text="PRICE :"></asp:Label>
                                    </div>
                                    <div class="col-5">
                                        <asp:Label ID="priceOrder" runat="server" Text="RM 13.00"></asp:Label>
                                    </div>
                                    <div class="col-7 border-bottom">
                                        <asp:Label ID="Label11" runat="server" Text="PICK UP :"></asp:Label>
                                    </div>
                                    <div class="col-5 border-bottom">
                                        <asp:Label ID="pickUpPriceOrder" runat="server" Text="RM 5.00"></asp:Label>
                                    </div>
                                    <div class="col-7 border-bottom">
                                        <asp:Label ID="Label2" runat="server" Text="TOTAL PAYMENT :" Font-Size="Larger" Font-Bold="true"></asp:Label>
                                    </div>
                                    <div class="col-5 border-bottom">
                                        <asp:Label ID="Label4" runat="server" Text="RM 18.00" Font-Size="Larger" Font-Bold="true"></asp:Label>
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
                                <div><asp:Label ID="Label5" runat="server" Text="Name: Loh Shu Yi"></asp:Label></div>
                                <div><asp:Label ID="Label6" runat="server" Text="Contact No: +0124893823"></asp:Label></div>
                                <div><asp:Label ID="Label7" runat="server" Text="Address"></asp:Label></div>
                                <div><asp:Label ID="addressCheckout" runat="server" Text="35, Jalan Pekaka, Taman Pekaka"></asp:Label></div>
                                <div><asp:Label ID="postcodeCheckout" runat="server" Text="14300"></asp:Label></div>
                                <div><asp:Label ID="locationCheckout" runat="server" Text="Taman Pekaka"></asp:Label></div>
                                <div><asp:Label ID="cityCheckout" runat="server" Text="Nibong Tebal"></asp:Label></div>
                                <div><asp:Label ID="stateCheckout" runat="server" Text="Penang"></asp:Label></div>
                            </div>
                            <div class="col-md-5 col-sm-11 ml-3 pt-3">
                                <div><asp:Label ID="Label9" runat="server" Text="Services" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="Label12" runat="server" Text="Service Type: Pick Up" ></asp:Label></div>
                                <div><asp:Label ID="Label13" runat="server" Text="Pick Up Date: 30/03/2020" ></asp:Label></div>
                                <div><asp:Label ID="Label14" runat="server" Text="Remark: Please come in morning" ></asp:Label></div>
                            </div>
                            <div class="col-md-6 col-sm-11 py-3 ml-3">
                                <div><asp:Label ID="Label20" runat="server" Text="Receiver Information" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="Label21" runat="server" Text="Name: Lim Carol"></asp:Label></div>
                                <div><asp:Label ID="Label22" runat="server" Text="Contact No: +0124893823"></asp:Label></div>
                                <div><asp:Label ID="Label23" runat="server" Text="Address"></asp:Label></div>
                                <div><asp:Label ID="Label24" runat="server" Text="35, Jalan Pekaka, Taman Pekaka"></asp:Label></div>
                                <div><asp:Label ID="Label25" runat="server" Text="14300"></asp:Label></div>
                                <div><asp:Label ID="Label26" runat="server" Text="Taman Pekaka"></asp:Label></div>
                                <div><asp:Label ID="Label27" runat="server" Text="Nibong Tebal"></asp:Label></div>
                                <div><asp:Label ID="Label28" runat="server" Text="Penang"></asp:Label></div>
                            </div>
                            <div class="col-md-5 col-sm-11 ml-3 pt-3">
                                <div><asp:Label ID="Label29" runat="server" Text="Parcel Details" Font-Bold="true"></asp:Label></div>
                                <div><asp:Label ID="Label30" runat="server" Text="Type: Parcel" ></asp:Label></div>
                                <div><asp:Label ID="Label31" runat="server" Text="Pieces: 3" ></asp:Label></div>
                                <div><asp:Label ID="Label32" runat="server" Text="Content: Electronic" ></asp:Label></div>
                                <div><asp:Label ID="Label16" runat="server" Text="Value of Content: RM250.00" ></asp:Label></div>
                                <div><asp:Label ID="Label17" runat="server" Text="Weight: 3.00KG" ></asp:Label></div>
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
