angular.module('app', []);







angular.module('app').controller('bookingctrl', function ($scope, $http, $filter) {



    $scope.enterbooking = function () {
        
        var sdate = $filter('date')($scope.sdate, 'yyyy-MM-dd');
        var edate = $filter('date')($scope.edate, 'yyyy-MM-dd');
        $http.get('../api/BookingAPI/enterbooking?room=' + parseInt($scope.roomId, 10) + "&sdate=" + sdate + "&edate=" + edate + "&numguests=" + $scope.numguests).success(function (data) {
            $scope.data = data;
            
            alert("Radi");
        });

    };

});


angular.module('app').controller('getEverythingCtrl', function ($scope, $http) {



//daje sve podatke o sobama

    $http.get('../api/BookingAPI/getRooms').success(function (data) {
      
        $scope.sdate = new Date(2014, 11, 10);
        $scope.edate = new Date(2014, 11, 10);
        $scope.numguests = "1";
        $scope.rooms = data;

    });

    $http.get('../api/BookingAPI/getNews').success(function (data) {

        $scope.news = data;

    });




});