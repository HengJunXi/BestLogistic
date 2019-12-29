<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BestLogistic._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container px-1 px-sm-3">
                <div class="row">
        <div class="col-md-12 col-lg-5 quote p-0">
            <h3 class="font-weight-bolder my-3">Quote Your Parcel Here!</h3>
            <div class="quote-content px-sm-3">
                <div class="row m-0">
                    <div class="col-6">
                        <h5 class="font-weight-bold">From:</h5>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="FromPostCode" Text="POSTCODE"/>
                            <asp:TextBox runat="server" ID="FromPostCode" TextMode="SingleLine" CssClass="form-control" 
                                AutoPostBack="true" OnTextChanged="FromPostCode_TextChanged" />
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="FromLocation" Text="LOCATION"/>
                            <asp:DropDownList ID="FromLocation" runat="server" CssClass="form-control" 
                                AutoPostBack="true" OnSelectedIndexChanged="FromLocation_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="d-flex">
                            <h5 class="font-weight-bold pr-2">City:</h5>
                            <asp:Label runat="server" ID="FromCity" CssClass="h5" />
                        </div>
                        <div class="d-flex">
                            <h5 class="font-weight-bold pr-2">State:</h5>
                            <asp:Label runat="server" ID="FromState" CssClass="h5" />
                        </div>
                    </div>
                    <div class="col-6">
                        <h5 class="font-weight-bold">To:</h5>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ToPostCode" Text="POSTCODE"/>
                            <asp:TextBox runat="server" ID="ToPostCode" TextMode="SingleLine" CssClass="form-control" 
                                AutoPostBack="true" OnTextChanged="ToPostCode_TextChanged" />
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ToLocation" Text="LOCATION"/>
                            <asp:DropDownList ID="ToLocation" runat="server" CssClass="form-control" 
                                AutoPostBack="true" OnSelectedIndexChanged="ToLocation_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="d-flex">
                            <h5 class="font-weight-bold pr-2">City:</h5>
                            <asp:Label runat="server" ID="ToCity" CssClass="h5" />
                        </div>
                        <div class="d-flex">
                            <h5 class="font-weight-bold pr-2">State:</h5>
                            <asp:Label runat="server" ID="ToState" CssClass="h5" />
                        </div>
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
                    <asp:Label runat="server" ID="QuotedPrice" CssClass="mr-5 font-weight-bolder h4" Visible="false"/>
                    <asp:Button runat="server" ID="QuoteBtn" Text="Quote" CssClass="quote-btn" OnClick="QuoteBtn_Click" />
                </div>
            </div>
        </div>
                <asp:Image ID="Background" runat="server" ImageUrl="~/Images/background.png" CssClass="col-12 col-lg-7 mt-lg-5 p-0 pt-3 default-background"/>
                    </div>
    </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        function initialiseSelect2() {
            $('#MainContent_FromLocation').select2({
                placeholder: {
                    id: '',
                    text: 'Postcode is required'
                }
            });
            $('#MainContent_ToLocation').select2({
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