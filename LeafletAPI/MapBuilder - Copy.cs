namespace LeafletAPI
{
    public partial class MapBuilder
    {
        private string tmp_bodybuilder()
        {
            var body = """
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
                        ).bindTooltip("Living Room", { permanent: true, direction: "center", className: 'tooltipclass' });

                        var L1foyer = L.polygon([
                            [4, 13],
                            [4, 17],
                            [9, 17],
                            [9, 13]
                        ], roomStyle
                        ).bindTooltip("Foyer", { permanent: true, direction: "center", className: 'tooltipclass' });

                        var L1closet = L.polygon([
                            [9, 13],
                            [9, 17],
                            [12, 17],
                            [12, 13]
                        ], roomStyle);

                        var L1kitchen = L.polygon([
                            [14, 0],
                            [14, 13],
                            [28, 13],
                            [28, 0]
                        ], roomStyle
                        ).bindTooltip("Kitchen", { permanent: true, direction: "center", className: 'tooltipclass' });

                        var L1pantry = L.polygon([
                            [28, 0],
                            [28, 3],
                            [25, 3],
                            [23, 2],
                            [23, 0]
                        ], roomStyle
                        ).bindTooltip("Pantry", { permanent: true, direction: "center", className: 'tooltipclass' });

                        var L1diningroom = L.polygon([
                            [12, 13],
                            [25, 13],
                            [25, 19],
                            [12, 19]
                        ], roomStyle
                        ).bindTooltip("Dining Room", { permanent: true, direction: "center", className: 'tooltipclass' });

                        var L1bathroom = L.polygon([
                            [25, 13],
                            [25, 19],
                            [31, 19],
                            [31, 13]
                        ], roomStyle
                        ).bindTooltip("Bathroom", { permanent: true, direction: "center", className: 'tooltipclass' });

                        var L1garage = L.polygon([
                            [31, 0],
                            [50.5, 0],
                            [50.5, 17],
                            [31, 17]
                        ], roomStyle
                        ).bindTooltip("Garage", { permanent: true, direction: "center", className: 'tooltipclass' }).openTooltip();

                       

                        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX LAYER GROUP HANDLING

                        var L1 = L.layerGroup([L1footprint, L1livingroom, L1foyer, L1closet, L1kitchen, L1diningroom, L1bathroom, L1garage, L1pantry, L1fixtures, L1walls]);
                        
                        var map = L.map('map', {
                            crs: L.CRS.Simple,
                            minZoom: 0,
                            //		cursor: true,
                            layers: [L1],
                        });

                        map.setView([25.25, 9], 4);

                        var baseMaps = {
                            "Level 1": L1
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
                
                """;
            return body;
        }
    }
}