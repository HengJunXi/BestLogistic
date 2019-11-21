<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BestLogistic._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-12 col-lg-5 quote p-0">
            <h3 class="font-weight-bolder my-3">Quote Your Parcel Here!</h3>
            <div class="quote-content px-sm-3">
                <div class="row m-0">
                    <div class="col-6">
                        <h5 class="font-weight-bold">From:</h5>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="FromPostCode" Text="POSTCODE"/>
                            <asp:TextBox runat="server" ID="FromPostCode" TextMode="SingleLine" CssClass="form-control" />
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="FromLocation" Text="LOCATION"/>
                            <asp:TextBox runat="server" ID="FromLocation" TextMode="SingleLine" CssClass="form-control" />
                        </div>
                        <h5 class="font-weight-bold">City:</h5>
                        <h5 class="font-weight-bold">State:</h5>
                    </div>
                    <div class="col-6">
                        <h5 class="font-weight-bold">To:</h5>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ToPostCode" Text="POSTCODE"/>
                            <asp:TextBox runat="server" ID="ToPostCode" TextMode="SingleLine" CssClass="form-control" />
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ToLocation" Text="LOCATION"/>
                            <asp:TextBox runat="server" ID="ToLocation" TextMode="SingleLine" CssClass="form-control" />
                        </div>
                        <h5 class="font-weight-bold">City:</h5>
                        <h5 class="font-weight-bold">State:</h5>
                    </div>
                </div>
                <div class="row m-0">
                    <div class="col-6">
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="Weight" Text="WEIGHT(KG)" />
                            <asp:TextBox runat="server" ID="Weight" TextMode="SingleLine" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="row m-0">
                    <label for="" class="col-md-4">Parcel's Type</label>
                    <div class="col-md-8">
                        <asp:RadioButtonList ID="rbtPackageType" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="h-flow-radio-btn-list">
                            <asp:ListItem Text="Parcel" Selected="True" Value="0"/>
                            <asp:ListItem Text="Document" Value="1"/>
                        </asp:RadioButtonList>
                        <%--<fieldset id="packageType">    
                            <input type="radio" value="0" id="parcelType" name="packageType" checked>
                            <label class="mr-3" for="parcelType">Parcel</label>
                            <input type="radio" value="1" id="documentType" name="packageType">
                            <label for="documentType">Document</label>
                        </fieldset>--%>
                    </div>
                </div>
                <div class="col-12 d-flex justify-content-end">
                    <asp:Button runat="server" ID="QuoteBtn" Text="Quote" CssClass="quote-btn" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
