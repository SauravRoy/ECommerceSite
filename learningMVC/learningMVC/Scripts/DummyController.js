var app = angular.module('myApp', []);
app.controller('Ctrl', function ($scope,$http) {

    $http.get("/home/getData/")
    .success(function (response) { alert(response);  $scope.names = response; });

    
    $scope.FirstName = 'Saurav';
    $scope.LastName = 'Roy';
    $scope.Reset = function () {
        alert('test click');
    }
    $scope.Reset();

});