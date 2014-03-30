<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrewerMap.aspx.cs" Inherits="LayeredBusinessModel.WebUI.BrewerMap" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <style type="text/css">
        html {
            height: 100%;
        }

        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #map-canvas {
            height: 50%;
            width: 50%;
        }
    </style>
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCphMZAsMAguxc9IKDIDrDCzVdCRsamO_Q&sensor=true">
    </script>
    <script type="text/javascript">
        var map;
        var marker = new google.maps.Marker();
        var markersArray = [];

        function initialize() {
            var mapOptions = {
                center: new google.maps.LatLng(50.806206, 3.283986),
                zoom: 8
            };
            map = new google.maps.Map(document.getElementById("map-canvas"),
                mapOptions);

            // add a click event handler to the map object
            google.maps.event.addListener(map, "click", function (event) {

                // display the lat/lng in your form's lat/lng fields
                if (markersArray.length < 1) {
                    document.getElementById("latFld").value = event.latLng.lat();
                    document.getElementById("lngFld").value = event.latLng.lng();
                    // place a marker
                    placeMarker(event.latLng);
                } else {
                    alert('U heeft al een marker geplaatst');
                }


            });
            
        }
        google.maps.event.addDomListener(window, 'load', initialize);



        function placeMarker(location) {
            // first remove all markers if there are any
            //deleteOverlays();


            marker = new google.maps.Marker({
                position: location,
                map: map
            });


            
            marker.setDraggable(true);

            //delete marker on right click
            google.maps.event.addListener(marker, 'rightclick', function (point, source, overlay) {
                marker.setMap(null);
                markersArray = [];
            });
            google.maps.event.addListener(marker, 'dragend', function (event) {
                document.getElementById("latFld").value = event.latLng.lat();
                document.getElementById("lngFld").value = event.latLng.lng();
            });

            // add marker in markers array
            markersArray.push(marker);

            //map.setCenter(location);

        }

        function handleRightClick() {
            alert('rightclicked');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="gvBrewers" runat="server" OnRowCommand="gvBrewers_RowCommand" AllowPaging="True" OnPageIndexChanging="gvBrewers_PageIndexChanging">
                <Columns>
                    <asp:ButtonField CommandName="Select" HeaderText="Select" Text="Select" />
                    <asp:ButtonField CommandName="Clear" HeaderText="Clear" Text="Clear" />
                </Columns>
            </asp:GridView>
            
            <input name="latFld" id="latFld" type="text" runat="server"/>
            <input name="lngFld" id="lngFld" type="text" runat="server"/>
            
        </div>


    </form>
    <div id="map-canvas" />
</body>
</html>
