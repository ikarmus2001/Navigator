using FluentAssertions;
using LeafletAPI.Models;

namespace LeafletAPI_Tests;

public class MapBuilder_tests
{
    private readonly string leafletHtmlResult = """
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset="utf-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0">

            <link rel="stylesheet" href="https://unpkg.com/leaflet@1.7.1/dist/leaflet.css" integrity="sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A==" crossorigin="" />
            <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js" integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==" crossorigin=""></script>

            <!--<link href='https://api.mapbox.com/mapbox.js/plugins/leaflet-fullscreen/v1.0.1/leaflet.fullscreen.css' rel='stylesheet' />
            <script src='https://api.mapbox.com/mapbox.js/plugins/leaflet-fullscreen/v1.0.1/Leaflet.fullscreen.min.js'></script>-->

            <!--<link rel="stylesheet" href="./src/L.Control.Sidebar.css" />
            <script src="./src/L.Control.Sidebar.js"></script>-->

            <style>
                html, body {
                    height: 100%;
                    margin: 0;
                }

                #map {
                    width: 100%;
                    height: 100%;
                }

                .tooltipclass {
                    background: transparent;
                    border: transparent;
                    box-shadow: 0 0px 0px rgba(0,0,0,0);
                }

                .imgclass {
                    display: block;
                    max-width: 400px;
                    max-height: 400px;
                    width: auto;
                    height: auto;
                }
            </style>

        </head>

        <body>

            <div id='map'></div>

            <div id="sidebar"></div>

            <script>

                // LAYER STYLES

                var footprintStyle = {
                    color: 'black',
                    fillColor: 'white',
                    fillOpacity: 1
                };

                var fixtureStyle = {
                    color: 'black',
                    weight: .5,
                    opacity: 0.25,
                };

                var roomStyle = {
                    color: 'black',
                    opacity: 0,
                    fillColor: 'white',
                    fillOpacity: 1
                };

                var wallStyle = {
                    color: 'black',
                    fillColor: 'none',
                    weight: 3,
                    fillOpacity: 1
                };

                var highlight = {
                    color: 'red',
                    opacity: 0,
                    fillColor: 'red',
                    fillOpacity: .5,
                    weight: 2,
                };

                // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX FIRST FLOOR FEATURES

                var L1fixtures = L.polyline(
                    [
                        [[14, 0], //counter
                        [14, 9],
                        [17, 9],
                        [17, 2],
                        [23, 2],
                        [23, 0],
                        [14, 0]],
                        [[15, 5], //sink
                        [15, 8],
                        [16.75, 8],
                        [16.75, 5],
                        [15, 5]],
                        [[18, 0], //oven
                        [18, 2],
                        [20, 2],
                        [20, 0],
                        [18, 0]],
                        [[18.25, 0.25], //oven Units
                        [18.25, 0.5],
                        [18.5, 0.5],
                        [18.5, 0.25],
                        [18.25, 0.25]],
                        [[18.25, 1.25], //oven Units
                        [18.25, 1.5],
                        [18.5, 1.5],
                        [18.5, 1.25],
                        [18.25, 1.25]],
                        [[19.75, 1.25], //oven Units
                        [19.75, 1.5],
                        [19.5, 1.5],
                        [19.5, 1.25],
                        [19.75, 1.25]],
                        [[19.75, 0.25], //oven Units
                        [19.75, 0.5],
                        [19.5, 0.5],
                        [19.5, 0.25],
                        [19.75, 0.25]],
                        [[28, 3], //counter
                        [28, 6],
                        [25, 6],
                        [25, 3],
                        [28, 3]],
                        [[28, 6], //fridge
                        [28, 10],
                        [25, 10],
                        [25, 6],
                        [28, 6]],
                        [[30.75, 13.25], //sink
                        [30.75, 15.25],
                        [29.75, 15.25],
                        [29.75, 13.25],
                        [30.75, 13.25]],
                        [[30.5, 13.5], //sink
                        [30.5, 15],
                        [30, 15],
                        [30, 13.5],
                        [30.5, 13.5]],
                        [[30.75, 16.75], //Toilet
                        [30.75, 18.75],
                        [29.75, 18.75],
                        [29.75, 16.75],
                        [30.75, 16.75]],
                        [[29.75, 17.25], //Toilet
                        [28, 17.25],
                        [28, 18.25],
                        [29.75, 18.25],
                        [29.75, 17.25]],
                        [[31, 3], //Stairs
                        [28, 3]],
                        [[31, 4],
                        [28, 4]],
                        [[31, 5],
                        [28, 5]],
                        [[31, 6],
                        [28, 6]],
                        [[31, 7],
                        [28, 7]],
                        [[31, 8],
                        [28, 8]],
                        [[31, 9],
                        [28, 9]],
                        [[31, 10],
                        [28, 10]],
                    ], fixtureStyle
                );

                //Walls

                var L1walls = L.polyline([
                    [[0, 0],   //perimeter
                    [50.5, 0],
                    [50.5, 17],
                    [31, 17],
                    [31, 19],
                    [12, 19],
                    [12, 17],
                    [8, 17],
                    [4, 17],
                    [4, 13],
                    [0, 13],
                    [0, 0]],
                    [[14, 0], //kitchen
                    [14, 6]],
                    [[23, 0],  //pantry
                    [23, 2],
                    [23.5, 2.25]],
                    [[28, 0],
                    [28, 3],
                    [25, 3],
                    [24.5, 2.75]],
                    [[28, 3],
                    [28, 10]],
                    [[31, 0], //garage
                    [31, 10]],
                    [[31, 13], //walls
                    [31, 19]],
                    [[31, 13], //bathroom
                    [27, 13]],
                    [[25, 13],
                    [25, 19]],
                    [[12, 17], //closet
                    [12, 13],
                    [9, 13],
                    [9, 14]],
                    [[9, 16.0],
                    [9, 17]],
                    [[12, 13],
                    [13, 13]],
                ], wallStyle
                ).bindPopup("First Floor");;

                var L1footprint = L.polygon([
                    [0, 0],
                    [50.5, 0],
                    [50.5, 17],
                    [31, 17],
                    [31, 19],
                    [12, 19],
                    [12, 17],
                    [8, 17],
                    [4, 17],
                    [4, 13],
                    [0, 13],
                ], footprintStyle
                ).bindPopup("First Floor");;

                var L1livingroom = L.polygon([
                    [0, 0],
                    [14, 0],
                    [14, 13],
                    [0, 13]
                ], roomStyle
                ).bindTooltip("Living Room", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/foyer_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/livingroom_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/livingroom_2019.jpg" + " class=imgclass " />');;
                });

                var L1foyer = L.polygon([
                    [4, 13],
                    [4, 17],
                    [9, 17],
                    [9, 13]
                ], roomStyle
                ).bindTooltip("Foyer", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/foyer_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/foyer_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/foyer_2019.jpg" + " class=imgclass " />');;
                });

                var L1closet = L.polygon([
                    [9, 13],
                    [9, 17],
                    [12, 17],
                    [12, 13]
                ], roomStyle
                ).bindTooltip("Closet", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip();;

                var L1kitchen = L.polygon([
                    [14, 0],
                    [14, 13],
                    [28, 13],
                    [28, 0]
                ], roomStyle
                ).bindTooltip("Kitchen", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/kitchen_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/kitchen_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/kitchen_2019.jpg" + " class=imgclass " />');;
                });

                var L1pantry = L.polygon([
                    [28, 0],
                    [28, 3],
                    [25, 3],
                    [23, 2],
                    [23, 0]
                ], roomStyle
                ).bindTooltip("Pantry", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2017</h1>' + '<img src="./img/pantry_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/pantry_2019.jpg" + " class=imgclass " />');;
                });

                var L1diningroom = L.polygon([
                    [12, 13],
                    [25, 13],
                    [25, 19],
                    [12, 19]
                ], roomStyle
                ).bindTooltip("Dining Room", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/dining_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/dining_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/dining_2019.jpg" + " class=imgclass " />');;
                });

                var L1bathroom = L.polygon([
                    [25, 13],
                    [25, 19],
                    [31, 19],
                    [31, 13]
                ], roomStyle
                ).bindTooltip("Bathroom", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2017</h1>' + '<img src="./img/lowerbathroom_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/lowerbathroom_2019.jpg" + " class=imgclass " />');;
                });

                var L1garage = L.polygon([
                    [31, 0],
                    [50.5, 0],
                    [50.5, 17],
                    [31, 17]
                ], roomStyle
                ).bindTooltip("Garage", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip();;

                // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX SECOND FLOOR FEATURES

                var L2fixtures = L.polyline([
                    [[31, 3], //Stairs
                    [28, 3]],
                    [[31, 4],
                    [28, 4]],
                    [[31, 5],
                    [28, 5]],
                    [[31, 6],
                    [28, 6]],
                    [[31, 7],
                    [28, 7]],
                    [[31, 8],
                    [28, 8]],
                    [[31, 9],
                    [28, 9]],
                    [[28, 0],
                    [28, 3]],
                    [[27, 0],
                    [27, 3]],
                    [[26, 0],
                    [26, 3]],
                    [[25, 0],
                    [25, 3]],
                    [[24, 0],
                    [24, 3]],
                    [[50, 0], //masterbath
                    [50, 5]],
                    [[46.25, 0.25], //toilet
                    [48.25, 0.25],
                    [48.25, 1.25],
                    [46.25, 1.25],
                    [46.25, 0.25]],
                    [[47.75, 1.25],
                    [47.75, 2.5],
                    [46.75, 2.5],
                    [46.75, 1.25],
                    [47.75, 1.25]],
                    [[46, 2], //vanity
                    [39, 2]],
                    [[45.75, 0.5],
                    [45.75, 1.5],
                    [43.75, 1.5],
                    [43.75, 0.5],
                    [45.75, 0.5]],
                    [[41.25, 0.5],
                    [41.25, 1.5],
                    [39.25, 1.5],
                    [39.25, 0.5],
                    [41.25, 0.5]],
                    [[18, 6], //bathroom
                    [15.5, 6],
                    [15.5, 8]],
                    [[13, 3],
                    [13, 8]],
                    [[12.5, 3.5],
                    [12.5, 7.5],
                    [10.5, 7.5],
                    [10.5, 3.5],
                    [12.5, 3.5]],
                    [[17.75, 6.5],
                    [17.75, 7.5],
                    [15.75, 7.5],
                    [15.75, 6.5],
                    [17.75, 6.5]],
                    [[15.25, 6.5],
                    [15.25, 7.5],
                    [13.25, 7.5],
                    [13.25, 6.5],
                    [15.25, 6.5]],
                    [[14.75, 6.5],
                    [14.75, 5],
                    [13.75, 5],
                    [13.75, 6.5],
                    [14.75, 6.5]],
                ], fixtureStyle
                );

                var L2walls = L.polyline([
                    [[0, 0], //perimeter
                    [52, 0],
                    [52, 17],
                    [31, 17],
                    [31, 19],
                    [12, 19],
                    [12, 17],
                    [8, 17],
                    [3, 17],
                    [3, 13],
                    [0, 13],
                    [0, 0]],
                    [[3, 13], //greencloset
                    [3, 12],
                    [3.25, 12]],
                    [[10, 17],
                    [10, 12],
                    [5.25, 12]],
                    [[10, 12], //greenroom
                    [10, 3],
                    [13, 3],
                    [13, 2.75]],
                    [[31, 0],
                    [31, 13]],
                    [[31, 9], //stairs
                    [28, 9],
                    [28, 3],
                    [24, 3]],
                    [[13, 3], //bathroom
                    [14.75, 3]],
                    [[16.75, 3],
                    [18, 3],
                    [18, 8],
                    [10, 8]],
                    [[12, 17], //bluecloset
                    [12, 15]],
                    [[12, 10],
                    [12, 8]],
                    [[18, 3], //hallcloset
                    [20, 3],
                    [20, 4]],
                    [[20, 7],
                    [20, 8],
                    [18, 8]],
                    [[20, 8],
                    [21, 9.25]], //blueroom
                    [[23, 11.75],
                    [24, 13],
                    [24, 19]],
                    [[31, 13],
                    [31.5, 13]],
                    [[33.5, 13],
                    [36, 13],
                    [36, 14]],
                    [[36, 16.5],
                    [36, 17]],
                    [[36, 13], //master
                    [36, 5],
                    [40, 5]],
                    [[39, 0], //mastercloset
                    [39, 2.5]],
                    [[39, 4.5],
                    [39, 5]],
                    [[36, 5],
                    [31, 5]],
                    [[36, 7],
                    [31, 7]],
                    [[46, 0], //masterbath
                    [46, 2.5]],
                    [[46, 4.5],
                    [46, 5]],
                    [[52, 5],
                    [45, 5]],
                ], wallStyle
                ).bindPopup("2nd Floor");;

                var L2footprint = L.polygon([
                    [0, 0],
                    [52, 0],
                    [52, 17],
                    [31, 17],
                    [31, 19],
                    [12, 19],
                    [12, 17],
                    [8, 17],
                    [3, 17],
                    [3, 13],
                    [0, 13]
                ], footprintStyle
                ).bindPopup("2nd Floor");;

                var L2greenroom = L.polygon([
                    [0, 0],
                    [13, 0],
                    [13, 3],
                    [10, 3],
                    [10, 12],
                    [3, 12],
                    [3, 13],
                    [0, 13],
                ], roomStyle
                ).bindTooltip("Green Room", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/greenroom_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/greenroom_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/greenroom_2019.jpg" + " class=imgclass " />');;
                });

                var L2greencloset = L.polygon([
                    [3, 12],
                    [10, 12],
                    [10, 17],
                    [3, 17]
                ], roomStyle
                ).bindTooltip("Closet", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip();;

                var L2bathroom = L.polygon([
                    [10, 3],
                    [18, 3],
                    [18, 8],
                    [10, 8]
                ], roomStyle
                ).bindTooltip("Bathroom", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/upperbathroom_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/upperbathroom_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/upperbathroom_2019.jpg" + " class=imgclass " />');;
                });
                var L2bluecloset = L.polygon([
                    [10, 8],
                    [12, 8],
                    [12, 17],
                    [10, 17]
                ], roomStyle
                ).bindTooltip("Closet", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip();;

                var L2blueroom = L.polygon([
                    [12, 8],
                    [20, 8],
                    [24, 13],
                    [24, 19],
                    [12, 19]
                ], roomStyle
                ).bindTooltip("Blue Room", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/blueroom_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/blueroom_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/blueroom_2019.jpg" + " class=imgclass " />');;
                });

                var L2hallcloset = L.polygon([
                    [18, 3],
                    [20, 3],
                    [20, 8],
                    [18, 8]
                ], roomStyle
                ).bindTooltip("Closet", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip();;

                var L2hall = L.polygon([
                    [13, 0],
                    [24, 0],
                    [24, 3],
                    [28, 3],
                    [28, 9],
                    [31, 9],
                    [31, 13],
                    [36, 13],
                    [36, 17],
                    [31, 17],
                    [31, 19],
                    [24, 19],
                    [24, 13],
                    [20, 8],
                    [20, 3],
                    [13, 3]
                ], roomStyle
                ).bindTooltip("Hall", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/hall_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/hall_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/hall_2019.jpg" + " class=imgclass " />');;
                });


                var L2laundry = L.polygon([
                    [31, 7],
                    [31, 13],
                    [36, 13],
                    [36, 7]
                ], roomStyle
                ).bindTooltip("Laundry Room", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/laundry_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/laundry_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/laundry_2019.jpg" + " class=imgclass " />');;
                });

                var L2master = L.polygon([
                    [36, 5],
                    [52, 5],
                    [52, 17],
                    [36, 17]
                ], roomStyle
                ).bindTooltip("Master Bedroom", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/masterbedroom_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/masterbedroom_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/masterbedroom_2019.jpg" + " class=imgclass " />');;
                });

                var L2mastercloset = L.polygon([
                    [31, 0],
                    [39, 0],
                    [39, 5],
                    [31, 5]
                ], roomStyle
                ).bindTooltip("Closet", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/mastercloset_2013.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/mastercloset_2019.jpg" + " class=imgclass " />');;
                });

                var L2masterbath = L.polygon([
                    [46, 0],
                    [52, 0],
                    [52, 5],
                    [46, 5]
                ], roomStyle
                ).bindTooltip("Bathroom", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2019</h1>' + '<img src="./img/vanity_2019.jpg" + " class=imgclass " />');;
                });

                var L2mastervanity = L.polygon([
                    [39, 0],
                    [46, 0],
                    [46, 5],
                    [39, 5]
                ], roomStyle
                ).bindTooltip("Vanity", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip().on('click', function () {
                    sidebar.show()
                    sidebar.setContent('<h1>2013</h1>' + '<img src="./img/vanity_2013.jpg" + " class=imgclass " />' + '<h1>2017</h1>' + '<img src="./img/vanity_2017.jpg" + " class=imgclass " />' + '<h1>2019</h1>' + '<img src="./img/vanity_2019.jpg" + " class=imgclass " />');;
                });

                var L1 = L.layerGroup([L1footprint, L1livingroom, L1foyer, L1closet, L1kitchen, L1diningroom, L1bathroom, L1garage, L1pantry, L1fixtures, L1walls]);
                var L2 = L.layerGroup([L2footprint, L2greenroom, L2greencloset, L2bathroom, L2blueroom, L2hallcloset, L2hall, L2bluecloset, L2laundry, L2master, L2mastercloset, L2mastervanity, L2masterbath, L2fixtures, L2walls]);

                var map = L.map('map', {
                    crs: L.CRS.Simple,
                    minZoom: 0,
                    //		cursor: true,
                    layers: [L1],
                });

                map.setView([25.25, 9], 4);
                map.addControl(new L.Control.Fullscreen());

                var baseMaps = {
                    "Level 1": L1,
                    "Level 2": L2
                };

                L1.eachLayer(function (layer) {
                    if (layer instanceof L.Polygon) {
                        layer.on('mouseover', function (e) {
                            layer.setStyle(highlight);
                            //			layer.bringToFront();
                        });
                        layer.on('mouseout', function (e) {
                            layer.setStyle(roomStyle);
                            //			layer.bringToBack();
                        });
                    }
                });

                L2.eachLayer(function (layer) {
                    if (layer instanceof L.Polygon) {
                        layer.on('mouseover', function (e) {
                            layer.setStyle(highlight);
                            //			layer.bringToFront();
                        });
                        layer.on('mouseout', function (e) {
                            layer.setStyle(roomStyle);
                            //			layer.bringToBack();
                        });
                    }
                });

                //hide sidebar when floor level is changed
                map.on('baselayerchange', function (e) {
                    sidebar.hide();
                    console.log(e);
                });

                var sidebar = L.control.sidebar('sidebar', {
                    closeButton: true,
                    position: 'right'
                });
                map.addControl(sidebar);

                //		var marker = L.marker([0, 0]).addTo(map).on('click', function () {
                //			sidebar.toggle();
                //			sidebar.setContent('<h1>2017</h1>' + '<br>' + '<img src="https://static.pexels.com/photos/189349/pexels-photo-189349.jpeg" + " class=imgclass " />' + '<h1>2018</h1>' +  '<br>' + '<img src="https://static.pexels.com/photos/189349/pexels-photo-189349.jpeg" + " class=imgclass " />' + '<h1>2019</h1>' + '<br>' + '<img src="https://static.pexels.com/photos/189349/pexels-photo-189349.jpeg" + " class=imgclass " />');
                //		});

                //		map.on('click', function () {
                //			sidebar.hide();
                //		})

                sidebar.on('show', function () {
                    console.log('Sidebar will be visible.');
                });

                sidebar.on('shown', function () {
                    console.log('Sidebar is visible.');
                });

                sidebar.on('hide', function () {
                    console.log('Sidebar will be hidden.');
                });

                sidebar.on('hidden', function () {
                    console.log('Sidebar is hidden.');
                });

                L.DomEvent.on(sidebar.getCloseButton(), 'click', function () {
                    console.log('Close button clicked.');
                });

                L.control.layers(baseMaps, null, { collapsed: false }).addTo(map);


            </script>

        </body>
        </html>
        """.IgnoreIrrelevantChars();
    internal MapBuilder mapBuilder;

    internal MapBuilder_tests()
    {
        this.mapBuilder = new MapBuilder();
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ShouldThrowErrorWhenLevelNameIsNullOrEmpty(string invalidLevelName)
    {
        mapBuilder.Invoking(x => x.AddLevel(invalidLevelName)).Should().ThrowExactly<ArgumentException>().WithMessage("*null or empty*");
    }



    [Fact]
    public void ShouldProduceCompleteHTML()
    {
        BorderSetup();
        AddLevel("level1");
        AddSingleRoom();

        var resultView = mapBuilder.Build();
        
        var viewHtml = resultView.IgnoreIrrelevantChars();
        viewHtml.Should().
            Contain("<head>").And.
            Contain("</head>").And.
            Contain("<body>").And.
            Contain("</body>");
    }

    private void BorderSetup()
    {
        var borders = new Dictionary<string, float[,]>
        {
            { "BuildingC", new float[,] { { 5, 5 }, { 100, 5 }, { 100, 100 }, { 50, 100 }, { 5, 50 } } }
        };
        var borderStyle = new MapObjectStyle("borderStyle", "black")
        {
            fillColor = "none",
            weight = 3,
            fillOpacity = 1
        };
        mapBuilder.SetBuildingShape(borders, borderStyle);
    }

    private void AddLevel(string levelName)
    {
        mapBuilder.AddLevel(levelName);
    }

    private void AddSingleRoom()
    {
        var roomStyle = new MapObjectStyle("singleRoomStyle", "red");
        mapBuilder.AddRoom("SingleRoom", new float[,] {{5, 5}, {10, 5}, {10, 10}, {5, 10}}, roomStyle);
    }
}