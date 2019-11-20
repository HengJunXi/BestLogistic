<%@ Page Title="Send Package Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendPackage.aspx.cs" Inherits="BestLogistic.SendPackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="font-weight-bold text-center" style="padding:6px;font-weight:900;font-size:1.3em; margin-bottom:5px;">
            <h1 class="font-weight-bold">Send Package Form</h1>
           
        </div>
        <div  class="p-3 background-grey" >
            <div class="row m-0">
                <div class="col-6 p-3">
                    <div class="row">
                        <div class="col-6">
                            <h4 class="font-weight-bold text-left">Sender Details</h4>
                        </div>
                        <div class="col-6 text-right">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Use Default Address"/>
                        </div>
                    </div>
            
                    <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="SenderName" runat="server" Text="NAME"></asp:Label>
                        <asp:TextBox ID="SenderName" runat="server" TextMode="SingleLine" CssClass="form-control" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="SNameValid" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="SenderName" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SenderContactNo" Text="CONTACT NUMBER"/>
                            <asp:TextBox runat="server" ID="SenderContactNo" TextMode="Phone" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="SNoValid" runat="server" ErrorMessage="Contact Number cannot be empty" ControlToValidate="SenderContactNo" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SenderEmail" Text="EMAIL"/>
                            <asp:TextBox runat="server" ID="SenderEmail" TextMode="Email" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="SEmailValid" runat="server" ErrorMessage="Email cannot be empty" ControlToValidate="SenderEmail" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="SEmail" ControlToValidate="SenderEmail"
                                            ErrorMessage="Invalid email format" ValidationGroup="vgSendPackage" ForeColor="Red" 
                                            ValidationExpression="^\S+@\S+\.\S+$" Display="Dynamic" />
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SenderAdd" Text="ADDRESS"/>
                            <asp:TextBox runat="server" ID="SenderAdd" TextMode="SingleLine" CssClass="form-control" Height="25px" />
                            <asp:RequiredFieldValidator ID="SAddValid" runat="server" ErrorMessage="Address cannot be empty" ControlToValidate="SenderAdd" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SenderPostal" Text="POSTAL CODE"/>
                            <asp:TextBox runat="server" ID="SenderPostal" TextMode="SingleLine" CssClass="form-control" Height="25px"/>
                            <asp:RequiredFieldValidator ID="SPosValid" runat="server" ErrorMessage="Postal code cannot be empty" ControlToValidate="SenderPostal" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SenderLocation" Text="LOCATION"/>
                            <asp:DropDownList ID="SenderLocation" runat="server" AutoPostBack="True" CssClass="form-control" Height="25px">
                                <asp:ListItem Value="Sepang"></asp:ListItem>
                                <asp:ListItem Value="Taman Jasa"></asp:ListItem>
                                <asp:ListItem Value="Taman Pekaka"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="SLocationValid" runat="server" ErrorMessage="Location cannot be empty" ControlToValidate="SenderLocation" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SCity" Text="CITY"/>
                            <asp:DropDownList ID="SCity" runat="server" AutoPostBack="True" CssClass="form-control" Height="25px">
                                <asp:ListItem Value="Sepang"></asp:ListItem>
                                <asp:ListItem Value="Taman Jasa"></asp:ListItem>
                                <asp:ListItem Value="Taman Pekaka"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="SCityValid" runat="server" ErrorMessage="City cannot be empty" ControlToValidate="SCity" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="SState" Text="STATE"/>
                             <asp:DropDownList ID="SState" runat="server" AutoPostBack="True" CssClass="form-control" Height="25px">
                                 <asp:ListItem Value="Selangor"></asp:ListItem>
                                <asp:ListItem Value="Pulau Pinang"></asp:ListItem>
                                <asp:ListItem Value="Sabah"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="SStateValid" runat="server" ErrorMessage="State cannot be empty" ControlToValidate="SState" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="col-6 p-3">
                    <h4 class="font-weight-bold text-left">Receiver Details</h4>
                    <div class="form-group form-group-default required">
                           <asp:Label runat="server" AssociatedControlID="ReceiverName" Text="NAME"/>
                           <asp:TextBox runat="server" ID="ReceiverName" TextMode="SingleLine" CssClass="form-control" Height="25px"/>
                            <asp:RequiredFieldValidator ID="RNameValid" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="ReceiverName" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverContactNo" Text="CONTACT NUMBER"/>
                            <asp:TextBox runat="server" ID="ReceiverContactNo" TextMode="SingleLine" CssClass="form-control" Height="25px"/>
                            <asp:RequiredFieldValidator ID="RNoValid" runat="server" ErrorMessage="Contact Number cannot be empty" ControlToValidate="ReceiverContactNo" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverEmail" Text="EMAIL"/>
                            <asp:TextBox runat="server" ID="ReceiverEmail" TextMode="Email" CssClass="form-control" Height="25px"/>
                            <asp:RequiredFieldValidator ID="REmailValid" runat="server" ErrorMessage="Email cannot be empty" ControlToValidate="ReceiverEmail" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="REmail" ControlToValidate="ReceiverEmail"
                                            ErrorMessage="Invalid email format" ValidationGroup="vgSendPackage" ForeColor="Red" 
                                            ValidationExpression="^\S+@\S+\.\S+$" Display="Dynamic" />
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverAdd" Text="ADDRESS"/>
                            <asp:TextBox runat="server" ID="ReceiverAdd" TextMode="SingleLine" CssClass="form-control" Height="25px"/>
                            <asp:RequiredFieldValidator ID="RAddValid" runat="server" ErrorMessage="Address cannot be empty" ControlToValidate="ReceiverAdd" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverPostal" Text="POSTAL CODE"/>
                            <asp:TextBox runat="server" ID="ReceiverPostal" TextMode="SingleLine" CssClass="form-control" Height="25px"/>
                            <asp:RequiredFieldValidator ID="RPosValid" runat="server" ErrorMessage="Postal code cannot be empty" ControlToValidate="ReceiverPostal" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="ReceiverLocation" Text="LOCATION"/>
                            <asp:DropDownList ID="ReceiverLocation" runat="server" CssClass="form-control" Height="25px">
                                <asp:ListItem Value="Sepang"></asp:ListItem>
                                <asp:ListItem Value="Taman Jasa"></asp:ListItem>
                                <asp:ListItem Value="Taman Pekaka"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Location cannot be empty" ControlToValidate="ReceiverLocation" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="RCity" Text="CITY"/>
                            <asp:DropDownList ID="RCity" runat="server" AutoPostBack="True" CssClass="form-control" Height="25px">
                                <asp:ListItem Value="Sepang"></asp:ListItem>
                                <asp:ListItem Value="Taman Jasa"></asp:ListItem>
                                <asp:ListItem Value="Taman Pekaka"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RCityValid" runat="server" ErrorMessage="City cannot be empty" ControlToValidate="RCity" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group form-group-default required">
                            <asp:Label runat="server" AssociatedControlID="RState" Text="STATE"/>
                             <asp:DropDownList ID="RState" runat="server" AutoPostBack="True" CssClass="form-control" Height="25px">
                                 <asp:ListItem Value="Selangor"></asp:ListItem>
                                <asp:ListItem Value="Pulau Pinang"></asp:ListItem>
                                <asp:ListItem Value="Sabah"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RStateValid" runat="server" ErrorMessage="State cannot be empty" ControlToValidate="RState" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                 </div>
              
                </div>
            </div>
        <br />
   
        <div class="p-3 background-grey">
             <div class="text-center">
                <h3 class="font-weight-bold" >Services</h3>
            </div>
            <div class="row p-3 text-center">
                <div class="col-6">
                    <asp:RadioButton ID="LodgeUpBtn" runat="server"  Text="Lodge In" GroupName="ServiceGroup" />
                </div>
                <div class="col-6 ">
                     <asp:RadioButton ID="PickUpBtn" runat="server"  Text="Pick Up (RM5)" GroupName="ServiceGroup" />
                </div>

            </div>
        
            <div class="p-3">
                <h4 class="font-weight-bold">Pick Up Details</h4>
            </div>
            <div class="row p-3">
                <div class="col-6">
                     <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="PickupDate" runat="server" Text="PICK-UP DATE"></asp:Label>
                        <asp:TextBox ID="PickupDate" runat="server" TextMode="Date" CssClass="form-control" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PickUpDateValid" runat="server" ErrorMessage="Pick up date cannot be empty" ControlToValidate="PickupDate" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-6">
                    <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="ParcelRTime" runat="server" Text="PARCEL READY TIME"></asp:Label>
                        <asp:TextBox ID="ParcelRTime" runat="server" TextMode="DateTime" CssClass="form-control" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Parcel ready time cannot be empty" ControlToValidate="ParcelRTime" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-12">
                    <div class="form-group form-group-default">
                         <asp:Label AssociatedControlID="remarks" runat="server" Text="REMARKS"></asp:Label>
                            <br />
                        <textarea ID="remarks" runat="server" style="width: 100%; min-height: 150px; max-height:150px;" ></textarea>
                    </div>
                </div>
            </div>
        </div>

        <br />
         <div class="p-3 background-grey">
             <div class="text-center">
                <h3 class="font-weight-bold" >Parcel Details</h3>
            </div>
            <div class="row p-3 text-center ">
                <div class="col-5 text-center">
                    <asp:Label ID="Parcel" runat="server" Text="Parcel's Type"> </asp:Label>
                    <span style="color:red">*</span>
                </div>
                <div class="col-5  text-right">
                    <asp:RadioButtonList ID="TypeofParcel" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Text="Parcel" />
                        <asp:ListItem Text="Document" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="ParcelTypeValid" runat="server" ErrorMessage="Parcel type is required" ControlToValidate="TypeofParcel" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                
            </div>
        
        
            <div class="row p-3">
                <div class="col-6">
                     <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="Pieces" runat="server" Text="PIECES"></asp:Label>
                        <asp:TextBox ID="Pieces" runat="server" TextMode="Number" CssClass="form-control" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PiecesValid" runat="server" ErrorMessage="Pieces of parcel cannot be empty" ControlToValidate="Pieces" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-6">
                    <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="Content" runat="server" Text="CONTENT"></asp:Label>
                        <asp:TextBox ID="Content" runat="server" TextMode="SingleLine" CssClass="form-control" Height="25px" Placeholder="Eg:Electronics"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ContentValid" runat="server" ErrorMessage="Content of parcel cannot be empty" ControlToValidate="Content" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-6">
                    <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="ValueofContent" runat="server" Text="VALUE OF CONTENT (RM)"></asp:Label>
                        <asp:TextBox ID="ValueofContent" runat="server" TextMode="Number" CssClass="form-control" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValueofContentValid" runat="server" ErrorMessage="Value of content cannot be empty" ControlToValidate="ValueofContent" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                 <div class="col-6">
                    <div class="form-group form-group-default required">
                        <asp:Label AssociatedControlID="Weight" runat="server" Text="WEIGHT(KG)"></asp:Label>
                        <asp:TextBox ID="Weight" runat="server" TextMode="Number" CssClass="form-control" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="WeightValid" runat="server" ErrorMessage="Weight cannot be empty" ControlToValidate="Weight" 
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="col-12 d-flex justify-content-end">
                    <asp:Button runat="server" ID="QuoteBtn" Text="Quote" CssClass="quote-btn" />
        </div>
    </div>

</asp:Content>
