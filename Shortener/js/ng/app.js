var app = angular.module('shrtApp', ['ngRoute']);

app.controller('shrtCtrl', function ($scope, $http, $route) {
    $scope.$route = $route;
    $scope.formData = {
        userUrl: "",
        shortUrl: "",
        errorMessage: "",
    };

    $scope.getUrls = function () {
        $scope.formData.errorMessage = "";
        $http({
            method: 'GET',
            url: '/api/ShortLink'
        }).then(function successCallback(response) {
            $scope.urls = response.data;
            $scope.formData.errorMessage = "";
        }, function errorCallback(response) {
            $scope.formData.errorMessage = response.statusText;
        });
    };

    $scope.submitUrl = function () {
        $scope.formData.shortUrl = "";
        $http({
            method: 'PUT',
            data: JSON.stringify($scope.formData.userUrl),
            url: '/api/ShortLink'
        }).then(function successCallback(response) {
            $scope.formData.shortUrl = "/" + response.data.Short;
            $scope.formData.userUrl = "";
            $scope.formData.errorMessage = "";
            $scope.getUrls();
        }, function errorCallback(response) {
            $scope.formData.errorMessage = response.statusText;
        });
    };
});


app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/AddUrl', {
            templateUrl: '/js/ng/templates/add_url.html',
            activetab: 'AddUrl'
        }).
        when('/ShowUrls', {
            templateUrl: '/js/ng/templates/show_urls.html',
            activetab: 'ShowUrls'
        }).
        otherwise({
            redirectTo: '/AddUrl'
        });
  }]);

