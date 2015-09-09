angular.module('starter.directives', [])

.directive("map", function() {
    return {
        restrict: "E",
        replace: true,
        template: "<div id='allMap'></div>",
        scope: {
            center: "=", // Center point on the map (e.g. <code>{ latitude: 10, longitude: 10 }</code>).  
            markers: "=", // Array of map markers (e.g. <code>[{ lat: 10, lon: 10, name: "hello" }]</code>).  
            width: "@", // Map width in pixels.  
            height: "@", // Map height in pixels.  
            zoom: "@", // Zoom level (one is totally zoomed out, 25 is very much zoomed in).  
            zoomControl: "@", // Whether to show a zoom control on the map.  
            scaleControl: "@", // Whether to show scale control on the map.  
            address: "@",
            onCreate: "&"

        },
        link: function($scope, $element, $attrs) {
            var map;
            // 百度地图API功能  
            var map = new BMap.Map("allMap");
            var point = new BMap.Point(116.404, 39.915);
            map.centerAndZoom(point, 15);
            map.enableScrollWheelZoom(true); 
            $scope.onCreate({
                map: map
            });
        }
    };
});
