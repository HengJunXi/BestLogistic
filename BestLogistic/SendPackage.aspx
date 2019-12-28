<%@ Page Title="Send Package Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendPackage.aspx.cs" Inherits="BestLogistic.SendPackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <div class="font-weight-bold text-center" style="padding: 6px; font-weight: 900; font-size: 1.3em; margin-bottom: 5px;">
                <h1 class="font-weight-bold">Send Package Form</h1>

            </div>
            <div class="p-3 background-grey">
                <div class="row m-0">
                    <div class="col-lg-6 p-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-6">
                                        <h4 class="font-weight-bold text-left">Sender Details</h4>
                                    </div>
                                    <div class="col-6 text-right">
                                        <asp:CheckBox ID="cbDefaultAddress" runat="server" Text="Use Default Address" CssClass="checkbox-default" AutoPostBack="True" OnCheckedChanged="cbDefaultAddress_CheckedChanged" />
                                    </div>
                                </div>

                        
                                <div class="form-group form-group-default required">
                                    <asp:Label AssociatedControlID="SenderName" runat="server" Text="NAME"></asp:Label>
                                    <asp:TextBox ID="SenderName" runat="server" TextMode="SingleLine" CssClass="form-control" Height="25px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="SNameValid" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="SenderName"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="SenderContactNo" Text="CONTACT NUMBER" />
                                    <asp:TextBox runat="server" ID="SenderContactNo" TextMode="Phone" CssClass="form-control" Height="25px" />
                                    <asp:RequiredFieldValidator ID="SNoValid" runat="server" ErrorMessage="Contact Number cannot be empty" ControlToValidate="SenderContactNo"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="IDType" Text="ID TYPE" />
                                    <asp:DropDownList ID="IDType" runat="server" CssClass="form-control" Height="25px"
                                        AutoPostBack="True">
                                        <asp:ListItem>IC Number</asp:ListItem>
                                        <asp:ListItem>Old IC Number</asp:ListItem>
                                        <asp:ListItem>Passport</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="IDTypeValid" runat="server" ErrorMessage="ID Type cannot be empty" ControlToValidate="IDType"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="SenderIDNo" Text="ID NUMBER" />
                                    <asp:TextBox runat="server" ID="SenderIDNo" TextMode="Phone" CssClass="form-control" Height="25px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="ID Number cannot be empty" ControlToValidate="SenderIDNo"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="SenderEmail" Text="EMAIL" />
                                    <asp:TextBox runat="server" ID="SenderEmail" TextMode="Email" CssClass="form-control" Height="25px" />
                                    <asp:RequiredFieldValidator ID="SEmailValid" runat="server" ErrorMessage="Email cannot be empty" ControlToValidate="SenderEmail"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="SEmail" ControlToValidate="SenderEmail"
                                        ErrorMessage="Invalid email format" ValidationGroup="vgSendPackage" ForeColor="Red"
                                        ValidationExpression="^\S+@\S+\.\S+$" Display="Dynamic" />
                                </div>
                                <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="SenderAdd" Text="ADDRESS" />
                                    <asp:TextBox runat="server" ID="SenderAdd" TextMode="SingleLine" CssClass="form-control" Height="25px" />
                                    <asp:RequiredFieldValidator ID="SAddValid" runat="server" ErrorMessage="Address cannot be empty" ControlToValidate="SenderAdd"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>

                        
                                 <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="SenderPostal" Text="POSTAL CODE" />
                                    <asp:TextBox runat="server" ID="SenderPostal" TextMode="SingleLine" CssClass="form-control" Height="25px"
                                        AutoPostBack="true" OnTextChanged="SenderPostal_TextChanged" />
                                    <asp:RequiredFieldValidator ID="SPosValid" runat="server" ErrorMessage="Postal code cannot be empty" ControlToValidate="SenderPostal"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group form-group-default required">
                                    <asp:Label runat="server" AssociatedControlID="SenderLocation" Text="LOCATION" />
                                    <asp:DropDownList ID="SenderLocation" runat="server" CssClass="form-control" Height="25px"
                                        AutoPostBack="True" OnSelectedIndexChanged="SenderLocation_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="SLocationValid" runat="server" ErrorMessage="Location cannot be empty" ControlToValidate="SenderLocation"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group form-group-default required">
                                    <label>CITY</label>
                                    <asp:TextBox runat="server" ID="SenderCity" Height="25px" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="SenderCityValid" runat="server" ErrorMessage="City cannot be empty" ControlToValidate="SenderCity"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group form-group-default required">
                                    <label>STATE</label>
                                    <asp:TextBox runat="server" ID="SenderState" Height="25px" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="SenderStateValid" runat="server" ErrorMessage="State cannot be empty" ControlToValidate="SenderState"
                                        Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       

                    </div>
                    <div class="col-lg-6 p-3">
                        <h4 class="font-weight-bold text-left">Receiver Details</h4>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverName" Text="NAME" />
                            <asp:TextBox runat="server" ID="ReceiverName" TextMode="SingleLine" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="RNameValid" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="ReceiverName"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverContactNo" Text="CONTACT NUMBER" />
                            <asp:TextBox runat="server" ID="ReceiverContactNo" TextMode="SingleLine" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="RNoValid" runat="server" ErrorMessage="Contact Number cannot be empty" ControlToValidate="ReceiverContactNo"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverEmail" Text="EMAIL" />
                            <asp:TextBox runat="server" ID="ReceiverEmail" TextMode="Email" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="REmailValid" runat="server" ErrorMessage="Email cannot be empty" ControlToValidate="ReceiverEmail"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="REmail" ControlToValidate="ReceiverEmail"
                                ErrorMessage="Invalid email format" ValidationGroup="vgSendPackage" ForeColor="Red"
                                ValidationExpression="^\S+@\S+\.\S+$" Display="Dynamic" />
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverAdd" Text="ADDRESS" />
                            <asp:TextBox runat="server" ID="ReceiverAdd" TextMode="SingleLine" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="RAddValid" runat="server" ErrorMessage="Address cannot be empty" ControlToValidate="ReceiverAdd"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverPostal" Text="POSTAL CODE" />
                            <asp:TextBox runat="server" ID="ReceiverPostal" TextMode="SingleLine" CssClass="form-control" Height="25px"
                                AutoPostBack="true" OnTextChanged="ReceiverPostal_TextChanged" />
                            <asp:RequiredFieldValidator ID="RPosValid" runat="server" ErrorMessage="Postal code cannot be empty" ControlToValidate="ReceiverPostal"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverLocation" Text="LOCATION" />
                            <asp:DropDownList ID="ReceiverLocation" runat="server" CssClass="form-control" Height="25px"
                                AutoPostBack="true" OnSelectedIndexChanged="ReceiverLocation_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Location cannot be empty" ControlToValidate="ReceiverLocation"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-group-default required">
                            <label>CITY</label>
                            <asp:TextBox runat="server" ID="ReceiverCity" Height="25px" CssClass="form-control" Enabled="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReceiverCityValid" runat="server" ErrorMessage="City cannot be empty" ControlToValidate="ReceiverCity"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-group-default required">
                            <label>STATE</label>
                            <asp:TextBox runat="server" ID="ReceiverState" Height="25px" CssClass="form-control" Enabled="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReceiverStateValid" runat="server" ErrorMessage="State cannot be empty" ControlToValidate="ReceiverState"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </div>

                </div>
            </div>
            <br />

            <div class="p-3 background-grey">
                <div class="text-center">
                    <h3 class="font-weight-bold">Services</h3>
                </div>
                <div class="row px-3 pt-3 text-center">
                    <div class="col-6">
                        <asp:RadioButton ID="LodgeUpBtn" runat="server" Text="Lodge In" GroupName="ServiceGroup" />
                    </div>
                    <div class="col-6 ">
                        <asp:RadioButton ID="PickUpBtn" runat="server" Text="Pick Up (RM5)" GroupName="ServiceGroup" Checked="true" />
                    </div>

                </div>

                <div class="p-3" id="pickUpTitle">
                    <asp:Label ID="PickUpDetails" runat="server" Text="Pick Up Details" Font-Size="Medium" Font-Bold="True"></asp:Label>
                </div>
                <div class="row px-3" id="parcelPickUpdetails">
                    <div class="col-sm-6">
                        <div class="form-group form-group-default required">
                            <asp:Label AssociatedControlID="dbPickUpDate" runat="server" Text="PICK-UP DATE"></asp:Label>
                            <asp:DropDownList ID="dbPickUpDate" runat="server" CssClass="form-control" Height="25px" OnInit="dbPickUpDate_Init"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="PickUpDateValid" runat="server" ErrorMessage="Pick up date cannot be empty" ControlToValidate="dbPickUpDate"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group form-group-default required">
                            <asp:Label AssociatedControlID="ParcelRTime" runat="server" Text="PARCEL READY TIME"></asp:Label>

                            <asp:TextBox ID="ParcelRTime" runat="server" TextMode="DateTime" CssClass="form-control" Height="25px" OnLoad="ParcelRTime_Load" placeholder="HH:mm:ss" OnInit="ParcelRTime_Init"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PickUpTimeValid" runat="server" ErrorMessage="Parcel ready time cannot be empty" ControlToValidate="ParcelRTime"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="form-group form-group-default">
                            <asp:Label AssociatedControlID="remarksNote" runat="server" Text="REMARKS"></asp:Label>
                            <br />
                            <asp:TextBox ID="remarksNote" runat="server" Style="width: 100%; min-height: 150px; max-height: 150px;" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <div class="p-3 background-grey">
                <div class="text-center">
                    <h3 class="font-weight-bold">Parcel Details</h3>
                </div>
                <div class="row px-3 pt-3 text-center ">
                    <div class="col-sm-6 col-md-3 col-lg-2 text-left">
                        <asp:Label ID="Parcel" runat="server" Text="Parcel's Type"> </asp:Label>
                        <span style="color: red">*</span>
                    </div>
                    <div class="col-sm-6 col-md-5 col-lg-4 text-left">
                        <asp:RadioButtonList ID="TypeofParcel" runat="server"
                            RepeatDirection="Horizontal" RepeatLayout="Flow"
                            CssClass="h-flow-radio-btn-list">
                            <asp:ListItem Text="Parcel" Selected="True" />
                            <asp:ListItem Text="Document" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="ParcelTypeValid" runat="server"
                            ErrorMessage="Parcel type is required" ControlToValidate="TypeofParcel"
                            ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                    </div>

                </div>


                <div class="row px-3">
                    <div class="col-sm-6">
                        <div class="form-group form-group-default required">
                            <asp:Label AssociatedControlID="Pieces" runat="server" Text="PIECES"></asp:Label>
                            <asp:TextBox ID="Pieces" runat="server" TextMode="Number" CssClass="form-control" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PiecesValid" runat="server" ErrorMessage="Pieces of parcel cannot be empty" ControlToValidate="Pieces"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="MinPieces" runat="server" ErrorMessage="Min pieces should be more than 0." ControlToValidate="Pieces"
                                ValueToCompare="1" Operator="GreaterThanEqual" Display="Dynamic" ForeColor="Red" Type="Integer"></asp:CompareValidator>
                            <asp:CompareValidator ID="MaxPieces" runat="server" ErrorMessage="Max pieces should be less than 6." ControlToValidate="Pieces"
                                ForeColor="Red" Operator="LessThanEqual" ValueToCompare="5" Display="Dynamic" Type="Integer"></asp:CompareValidator>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group form-group-default required">
                            <asp:Label AssociatedControlID="Content" runat="server" Text="CONTENT"></asp:Label>
                            <asp:TextBox ID="Content" runat="server" TextMode="SingleLine" CssClass="form-control" Height="25px" Placeholder="Eg. Electronics"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ContentValid" runat="server" ErrorMessage="Content of parcel cannot be empty" ControlToValidate="Content"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group form-group-default required">
                            <asp:Label AssociatedControlID="ValueofContent" runat="server" Text="VALUE OF CONTENT (RM)"></asp:Label>
                            <asp:TextBox ID="ValueofContent" runat="server" CssClass="form-control" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValueofContentValid" runat="server" ErrorMessage="Value of content cannot be empty" ControlToValidate="ValueofContent"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="ValueContentRegex" runat="server" ControlToValidate="ValueofContent" ErrorMessage="Enter a valid number"
                                ValidationExpression="^[1-9]\d*(\.\d+)?$" Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group form-group-default required">
                            <asp:Label AssociatedControlID="Weight" runat="server" Text="WEIGHT(KG)"></asp:Label>
                            <asp:TextBox ID="Weight" runat="server" CssClass="form-control" Height="25px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="WeightValid" runat="server" ErrorMessage="Weight cannot be empty" ControlToValidate="Weight"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgSendPackage"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="WeightRegex" runat="server" ControlToValidate="Weight" ErrorMessage="Enter a valid number"
                                ValidationExpression="^[0-9]\d*(\.\d+)?$" Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-12 d-flex justify-content-end">
                <asp:Button runat="server" ID="QuoteBtn" Text="Quote" CssClass="quote-btn" OnClick="QuoteBtn_Click" OnClientClick="return validate();" 
                 />
            </div>
    </div>
    <script>
        function initializeSelect2() {
            $('#MainContent_SenderLocation').select2({
                placeholder: {
                    id: '',
                    text: 'Postal code is required'
                }
            });
            $('#MainContent_ReceiverLocation').select2({
                placeholder: {
                    id: '',
                    text: 'Postal code is required'
                }
            });
        }
        function validate() {
            console.log($('#MainContent_LodgeUpBtn')[0].checked);
            if ($('#MainContent_LodgeUpBtn')[0].checked) {
                var value = $('#MainContent_ParcelRTime').val();
                if (value == '') {
                    $('#MainContent_ParcelRTime').val('00:00:00');
                }
            }
            if (Page_ClientValidate("vgSendPackage"))
                    return confirm('Are you sure want to confirm?');
            else
                return false;
        }
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(initializeSelect2);
            initializeSelect2();
            $('#MainContent_LodgeUpBtn').click(function (){
                if ($("#MainContent_LodgeUpBtn").is(":checked")) {
                    $("#parcelPickUpdetails").hide();
                    $("#pickUpTitle").hide();
                }
            });
            $('#MainContent_PickUpBtn').click(function () {
                if ($("#MainContent_PickUpBtn").is(":checked")) {
                    $("#parcelPickUpdetails").show();
                    $("#pickUpTitle").show();
                }
            });
        });
    </script>
</asp:Content>
