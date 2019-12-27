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
                        <asp:Button runat="server" ID="TrackBtn" CssClass="track-btn" Text="Track" OnClick="TrackBtn_Click" />
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
            </div>
            
            <asp:TextBox runat="server" ID="DepBranch" hidden/>
            <asp:TextBox runat="server" ID="ArrBranch" hidden/>
            <asp:TextBox runat="server" ID="ParcelStatus" hidden/>

            <div id="map" class="col-lg-6" style="height: 450px;"></div>
            

            <asp:Panel ID="MapPanel" runat="server" Visible="false">
                <script>
                    var markerDisplay;
                    var map;

                    function initMap() {
                        var depBranch = document.getElementById('MainContent_DepBranch').value;
                        var arrBranch = document.getElementById('MainContent_ArrBranch').value;
                        if (arrBranch === '')
                            arrBranch = depBranch;
                        var parcelStatus = document.getElementById('MainContent_ParcelStatus').value;

                        // TODO:
                        //if (parcelStatus == 2 || parcelStatus == 5 || parcelStatus == 6) {
                        //    var service = new google.maps.places.PlacesService(map);

                        //    service.getDetails(request, function (place, status) {
                        //        if (status == google.maps.places.PlacesServiceStatus.OK) {
                        //            var marker = new google.maps.Marker({
                        //                map: map,
                        //                position: place.geometry.location
                        //            });
                        //            google.maps.event.addListener(marker, 'click', function () {
                        //                infowindow.setContent(place.name);
                        //                infowindow.open(map, this);
                        //            });
                        //            map.fitBounds(place.geometry.viewport);
                        //        }
                        //    });
                        //}

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
                        markerDisplay = new google.maps.InfoWindow();

                        var mapElement = document.getElementById('map');
                        mapElement.style.display = "none";
                        map = new google.maps.Map(mapElement, {
                            center: new google.maps.LatLng(3.0864667, 101.5642664),
                            zoom: 15,
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
                            console.log(status);
                            console.log(response);
                            if (status == google.maps.DirectionsStatus.OK) {
                                directionsRenderer.setDirections(response);
                                mapElement.style.display = "block";
                                addMarkers(response, parcelStatus);
                            }
                        });
                    }

                    function addMarkers(directionResult, status) {
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
                        console.log(startUrl);
                        console.log(endUrl);
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
                            markerDisplay.setContent('GD Express Sdn Bhd, ' + myRoute.start_address);
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
                                markerDisplay.setContent('Gdex Bangi, ' + myRoute.end_address);
                                markerDisplay.open(map, endMarker);
                            });
                        }
                    }
                </script>
                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAEtyK6nyFUnMLqFoi72ZWxBc5-QImhFnM&callback=initMap" async defer></script>
            </asp:Panel>


            <%--<img class="col-lg-6" src="https://maps.googleapis.com/maps/api/staticmap?center=GD+Express+Sdn.+Bhd.,19,+Jalan+Tandang+204a,+Pjs+51,+46050+Petaling+Jaya,+Selangor&zoom=15&size=600x300&maptype=roadmap
                &markers=color:red%7CGD+Express+Sdn.+Bhd.,19,+Jalan+Tandang+204a,+Pjs+51,+46050+Petaling+Jaya,+Selangor
                &key=AIzaSyAEtyK6nyFUnMLqFoi72ZWxBc5-QImhFnM"/>--%>
            <%--<iframe class="col-lg-6" width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/view?zoom=17&center=3.0865%2C101.6343&key=AIzaSyAEtyK6nyFUnMLqFoi72ZWxBc5-QImhFnM" allowfullscreen></iframe>--%>
            <%--<iframe class="col-lg-6" width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/place?q=GD+Express+Sdn.+Bhd.,19,+Jalan+Tandang+204a,+Pjs+51,+46050+Petaling+Jaya,+Selangor&key=AIzaSyAEtyK6nyFUnMLqFoi72ZWxBc5-QImhFnM" allowfullscreen></iframe>--%>
            <%--<iframe class="col-lg-6" width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/directions?origin=place_id:ChIJleOtcJZLzDERT8y4frIc0wk&destination=No%2022%2CJalan%20P%2F20%2C%20Taman%20Industri%20Selaman%2CSeksyen%2010%2C%2043650%20Bandar%20Baru%20Bangi%2C%20Selangor&key=AIzaSyAEtyK6nyFUnMLqFoi72ZWxBc5-QImhFnM" allowfullscreen></iframe>--%>
            <%--<iframe src="https://www.google.com/maps/embed?pb=!1m28!1m12!1m3!1d63553.81349545988!2d100.37767636881259!3d5.399698149277485!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m13!3e0!4m5!1s0x304ac5069ac06373%3A0xfd24d9999c7bb46a!2sButterworth%2C%20Penang!3m2!1d5.438030899999999!2d100.38819199999999!4m5!1s0x304ac8e598b893bf%3A0x763116f720d28c2a!2sBukit%20Mertajam%2C%20Penang!3m2!1d5.365457999999999!2d100.45900909999999!5e0!3m2!1sen!2smy!4v1571562212847!5m2!1sen!2smy" 
                width="600" height="450" frameborder="0"
                style="border:0;" class="" allowfullscreen=""></iframe>--%>
        </div>
    </div>
    
</asp:Content>
