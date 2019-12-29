<%@ Page Title="Tracking Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="BestLogistic.Tracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="Departure" Visible="false" Enabled="false" CssClass="form-control" />
    <asp:TextBox runat="server" ID="Arrival" Visible="false" Enabled="false" CssClass="form-control" />
    <div class="container">
        <div class="row mt-3">
            <div class="col-12 col-lg-6">
                <h3 class="font-weight-bolder">Track your parcel</h3>
                <div class="">
                    <div class="form-group form-group-default required">
                        <asp:Label runat="server" AssociatedControlID="TrackingNumber" Text="TRACKING NUMBER" />
                        <asp:TextBox runat="server" ID="TrackingNumber" TextMode="SingleLine" CssClass="form-control" />
                    </div>
                    <div class="d-flex justify-content-end">
                        <asp:Label runat="server" ID="ErrorMessage" CssClass="mr-3 font-weight-bolder h5" ForeColor="Green" Visible="false"/>
                        <asp:Button runat="server" ID="TrackBtn" CssClass="track-btn" Text="Track" OnClick="TrackBtn_Click" />
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
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
                                            <td><%# ((BestLogistic.Models.ParcelStatus)Container.DataItem).date %></td>
                                            <td><%# ((BestLogistic.Models.ParcelStatus)Container.DataItem).time %></td>
                                            <td><%# ((BestLogistic.Models.ParcelStatus)Container.DataItem).status %></td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <div class="d-flex justify-content-center mb-3">
                            <asp:Button runat="server" ID="ShowMoreBtn" Text="Show more" 
                                CssClass="btn btn-default" OnClick="ShowMoreBtn_Click" Visible="false"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
            
            <asp:TextBox runat="server" ID="DepBranch" hidden/>
            <asp:TextBox runat="server" ID="DepBranchName" hidden/>
            <asp:TextBox runat="server" ID="ArrBranch" hidden/>
            <asp:TextBox runat="server" ID="ArrBranchName" hidden/>
            <asp:TextBox runat="server" ID="ParcelStatus" hidden/>

            <div id="map" class="col-lg-6" style="height: 450px;"></div>
        </div>
    </div>

    <asp:Panel ID="MapPanel" runat="server" Visible="false">
        <script>
            var map;
            var markerDisplay;

            function initMap() {
                var depBranch = document.getElementById('MainContent_DepBranch').value;
                var depBranchName = document.getElementById('MainContent_DepBranchName').value;
                var arrBranch = document.getElementById('MainContent_ArrBranch').value;
                var arrBranchName = document.getElementById('MainContent_ArrBranchName').value;
                if (arrBranch === '')
                    arrBranch = depBranch;
                var parcelStatus = document.getElementById('MainContent_ParcelStatus').value;


                var mapElement = document.getElementById('map');
                mapElement.style.display = "none";

                map = new google.maps.Map(mapElement, {
                    center: new google.maps.LatLng(3.0864667, 101.5642664),
                    zoom: 12,
                });
                markerDisplay = new google.maps.InfoWindow();

                // TODO:
                if (parcelStatus == 2 || parcelStatus == 5 || parcelStatus == 6) {
                    // if show only one point
                    var placesService = new google.maps.places.PlacesService(map);

                    placesService.getDetails(
                        {
                            placeId: depBranch
                        },
                        function (place, status) {
                            if (status == google.maps.places.PlacesServiceStatus.OK) {
                                var marker = new google.maps.Marker({
                                    map: map,
                                    position: place.geometry.location,
                                    title: depBranchName,
                                    icon: {
                                        url: (parcelStatus == 6 ? 'Icons\\truck-solid.svg' : 'Icons\\warehouse-solid.svg'),
                                        scaledSize: new google.maps.Size(25, 25)
                                    },
                                    animation: google.maps.Animation.DROP
                                });
                                google.maps.event.addListener(marker, 'click', function () {
                                    markerDisplay.setContent(depBranchName + ', ' + place.formatted_address);
                                    markerDisplay.open(map, this);
                                });
                                map.fitBounds(place.geometry.viewport);
                                map.setZoom(15);
                                mapElement.style.display = "block";
                            }
                        }
                    );
                } else {
                    // if show two points
                    var directionsService = new google.maps.DirectionsService();
                    var directionsRenderer = new google.maps.DirectionsRenderer({
                        polylineOptions: (parcelStatus == 4)
                            ? {
                                strokeColor: "blue",
                                strokeWeight: 5,
                                strokeOpacity: 0.75
                            }
                            : {
                                strokeColor: '#0eb7f6',
                                strokeOpacity: 0,
                                fillOpacity: 0,
                                icons: [{
                                    icon: {
                                        path: google.maps.SymbolPath.CIRCLE,
                                        fillOpacity: 1,
                                        scale: 3
                                    },
                                    offset: '0',
                                    repeat: '10px'
                                }],
                            },
                        suppressMarkers: true,
                    });
                    directionsRenderer.setMap(map);
                    directionsService.route({
                        origin: {
                            placeId: depBranch// 'ChIJleOtcJZLzDERT8y4frIc0wk'
                        },
                        destination: {
                            placeId: arrBranch// 'ChIJ7ZqvbEzKzTER-r67V-ufxtg'
                        },
                        travelMode: google.maps.TravelMode.DRIVING,
                        provideRouteAlternatives: false,
                    }, function (response, status) {
                        if (status == google.maps.DirectionsStatus.OK) {
                            directionsRenderer.setDirections(response);
                            mapElement.style.display = "block";
                            addMarkers(response, parcelStatus, depBranchName, arrBranchName);
                        }
                    });
                }
            }

            function addMarkers(directionResult, status, depBranchName, arrBranchName) {
                var startUrl = '';
                var endUrl = '';

                if (status == 2 || status == 5) {
                    startUrl = 'Icons\\warehouse-solid.svg';
                } else if (status == 3 || status == 4) {
                    startUrl = 'Icons\\truck-solid.svg';
                    endUrl = 'Icons\\warehouse-solid.svg';
                } else if (status == 6) {
                    startUrl = 'Icons\\truck-solid.svg';
                } else {
                    return;
                }
                var myRoute = directionResult.routes[0].legs[0];
                var size = new google.maps.Size(25, 25);
                var startMarker = new google.maps.Marker({
                    position: myRoute.start_location,
                    map: map,
                    title: 'Origin',
                    icon: {
                        url: startUrl,
                        scaledSize: size
                    },
                    animation: google.maps.Animation.DROP
                });
                google.maps.event.addListener(startMarker, 'click', function () {
                    markerDisplay.setContent(depBranchName + ', ' + myRoute.start_address);
                    markerDisplay.open(map, startMarker);
                });
                if (endUrl !== '') {
                    var endMarker = new google.maps.Marker({
                        position: myRoute.end_location,
                        map: map,
                        title: 'Destination',
                        icon: {
                            url: endUrl,
                            scaledSize: size
                        },
                        animation: google.maps.Animation.DROP
                    });
                    google.maps.event.addListener(endMarker, 'click', function () {
                        markerDisplay.setContent(arrBranchName + ', ' + myRoute.end_address);
                        markerDisplay.open(map, endMarker);
                    });
                }
            }
        </script>
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAEtyK6nyFUnMLqFoi72ZWxBc5-QImhFnM&libraries=places&callback=initMap" async defer></script>
    </asp:Panel>
</asp:Content>
