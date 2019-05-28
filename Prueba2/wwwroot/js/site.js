var app = angular.module('Prueba2App', []);

app.controller('InsertItemController', function ($http, $scope, $window) {
    $scope.error = '';
    $scope.item = {};
    $scope.submit = function () {
        $scope.error = '';

        $http.post('/articulo/insertar', $scope.item).then(function () {
            $window.location.href = '/';
        }, function (response) {
            $scope.error = response.data;
        });
    };
});

app.controller('UpdateItemController', function ($http, $scope, $window) {
    $scope.error = '';
    $scope.item = {};
    $scope.submit = function () {
        $scope.error = '';

        $http.post('/articulo/modificar', $scope.item).then(function () {
            $window.location.href = '/';
        }, function (response) {
            $scope.error = response.data;
        });
    };
});

app.controller('DeleteItemController', function ($http, $scope, $window) {
    $scope.error = '';
    $scope.item = {};
    $scope.submit = function () {
        $scope.error = '';

        $http.post('/articulo/eliminar', $scope.item).then(function () {
            $window.location.href = '/';
        }, function (response) {
            $scope.error = response.data;
        });
    };
});