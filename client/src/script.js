 mapboxgl.accessToken = 'pk.eyJ1IjoidGF5aXB6dHJrIiwiYSI6ImNrdjJlaHZ1ZzFxdXYybnFxbWthNHJmZnYifQ.h8KAY1p6wzNMr6hI1TH8Hg';

var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [32.866287, 39.925533],
    zoom: 4
});

const geocoder = new MapboxGeocoder({
    accessToken: mapboxgl.accessToken,
    marker: {
    color: '#3FB1CE',
    },
    mapboxgl: mapboxgl
    });
     
    map.addControl(geocoder);

    setInterval(() => {
        // console.log(geocoder.mapMarker._lngLat);

    if(geocoder.mapMarker._lngLat != null ){
    const marker = new mapboxgl.Marker({
        draggable: true
    })
    .setLngLat(geocoder.mapMarker._lngLat)
    .addTo(map);
}

}, 10000);

map.on('click', (e) => {
    const marker = new mapboxgl.Marker({
        draggable: true
    })
    .setLngLat(e.lngLat)
    .addTo(map);
    
    });


// const mapLeaflet = L.mapbox.map('map-leaflet')
//   .setView([38.9637, 35.2433], 4)
//   .addLayer(L.mapbox.styleLayer('mapbox://styles/mapbox/light-v10'));

// L.marker([38.913184, -77.031952]).addTo(map);
// L.marker([37.775408, -122.413682]).addTo(map);

// mapLeaflet.scrollWheelZoom.disable();


// let map;

// function initMap() {
//   map = new google.maps.Map(document.getElementById("map"), {
//     center: { lat: 38.9637, lng: 35.2433 },
//     zoom: 5,
//   });
// }

// const nav = new mapboxgl.NavigationControl();
// map.addControl(nav);

// var directions = new MapboxDirections({
//     accessToken: mapboxgl.accessToken,
//     });
    
// map.addControl(directions);

// const response = map.addControl(
//     new MapboxGeocoder({
//     accessToken: mapboxgl.accessToken,
//     mapboxgl: mapboxgl
//     })
//     );
// console.log(response);