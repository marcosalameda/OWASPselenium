function quidgestInitMap(elementId, places, actionArray) {
        
        var markers = [];
        var QuidgestLatLng = new google.maps.LatLng(38.7239975, -9.1528118);
        var myMapOptions = {
            zoom: 8,
            center: QuidgestLatLng
        }

        var map = new google.maps.Map(document.getElementById(elementId), myMapOptions);

        var geocoder = new google.maps.Geocoder;
        var largeInfowindow = new google.maps.InfoWindow();

        var defaultIcon = makeMarkerIcon('008DD2');
        var highlightedIcon = makeMarkerIcon('FFFF24');

        var elseInfo = "";

        for (var i = 0; i < places.location.length; i++) {
            //cordenates
            var loc = places.location[i];

            //properties
            for (var key in places.properties)
                elseInfo += "<tr><td><strong>" + key + "</strong></td><td>" + places.properties[key][i] + "</td></tr>";

            //add actions to the info
            if (!$.isEmptyObject(actionArray)) {
                var actionsString = "", j = 0;
                // check CRUD / action buttons
                while (j < actionArray.length - 1) {
                    actionsString += actionArray[j] + places.actions[i];
                    j++;
                }
                actionsString += actionArray[j];
                elseInfo += "</tbody><tfoot><tr><td>" + actionsString + "</td></tr></tfoot>";
            }

            var marker = new google.maps.Marker({
                position: loc,
                addressString: null,
                elseInfo: elseInfo,
                animation: google.maps.Animation.DROP,
                icon: defaultIcon,
                id: i
            });

            geocoder.geocode({ 'location': loc }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    this.addressString = results[0].formatted_address;
                } else {
                    // there is a limit (checked that is 5 places) --> OVER QUERY LIMIT
                    // some info about premium plan https://developers.google.com/maps/documentation/geocoding/usage-limits?hl=es-419
                    // some info for avoiding this limit http://stackoverflow.com/questions/11792916/over-query-limit-in-google-maps-api-v3-how-do-i-pause-delay-in-javascript-to-sl
                    // Still better showing lat lng than null
                    console.log("Geocode failed " + status);
                    this.addressString = this.position;
                }
            }.bind(marker));
            // clear elseInfo for the next marker
            elseInfo = "";

            markers.push(marker);
            marker.addListener('click', function () {
                populateInfoWindow(this, largeInfowindow);
            });
            marker.addListener('mouseover', function () {
                this.setIcon(highlightedIcon);
            });
            marker.addListener('mouseout', function () {
                this.setIcon(defaultIcon);
            });
        }

        function makeMarkerIcon(markerColor) {
            var markerImage = new google.maps.MarkerImage(
              'http://chart.googleapis.com/chart?chst=d_map_spin&chld=1.15|0|' + markerColor +
              '|40|_|%E2%80%A2',
              new google.maps.Size(21, 34),
              new google.maps.Point(0, 0),
              new google.maps.Point(10, 34),
              new google.maps.Size(21, 34));
            return markerImage;
        }

        function populateInfoWindow(marker, infowindow) {
            // Check to make sure the infowindow is not already opened on this marker.
            if (infowindow.marker != marker) {
                // Clear the infowindow content 
                infowindow.setContent('');
                infowindow.marker = marker;
                // Make sure the marker property is cleared if the infowindow is closed.
                infowindow.addListener('closeclick', function () {
                    infowindow.marker = null;
                });
                // Create a table inside infowindow. Some labels have been added before.
                infowindow.setContent('<table><thead><tr><td><strong>' + marker.addressString + '</strong></td></tr></thead><tbody>'  +  marker.elseInfo + '</table>');
                infowindow.open(map, marker);
            }
        }

        var bounds = new google.maps.LatLngBounds();
        // Extend the boundaries of the map for each marker and display the marker
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(map);
            bounds.extend(markers[i].position);
        }
        // If there is only one point, zoom out a bit
        // http://stackoverflow.com/questions/3334729/google-maps-v3-fitbounds-zoom-too-close-for-single-marker
        if (bounds.getNorthEast().equals(bounds.getSouthWest())) {
            var extendPoint1 = new google.maps.LatLng(bounds.getNorthEast().lat() + 0.01, bounds.getNorthEast().lng() + 0.01);
            var extendPoint2 = new google.maps.LatLng(bounds.getNorthEast().lat() - 0.01, bounds.getNorthEast().lng() - 0.01);
            bounds.extend(extendPoint1);
            bounds.extend(extendPoint2);
            map.fitBounds(bounds);
        }

        // If there is no marker, Map will be centered in Quidgest
        if(markers.length != 0)
            map.fitBounds(bounds);
}
