let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 42.712398, lng: 25.332230 },
        zoom: 15,
    });
}