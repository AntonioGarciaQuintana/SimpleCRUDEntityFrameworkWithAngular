var myApp = angular.module('myApp', []);

myApp.controller('productController', function ($scope, $http) {

    $scope.pruductsList = [];
    $scope.product = {};
    $scope.btnValue = 'Guardar Producto'
    function init() {
        $scope.initVariable();
        $scope.searchProducts();
        $scope.btnValue = 'Guardar Producto'
    }

    $scope.initVariable = function () {
        $scope.product = {
            id: 0,
            name: '',
            code: '',
            decription: '',
            stock: 0
        }
    }
    $scope.searchProducts = function () {
        $http({
            method: 'GET',
            url: '/Product/getProducts'
        })
            .then(function (response) {
                $scope.pruductsList = response.data;
            }, function (error) {
                console.log('Error ' + error);
            });
    }

    $scope.saveProduct = function (product) {

        var action = $scope.product.id == 0 ? 'saveProduct' : 'updateProduct';

        $http({
            method: 'POST',
            url: '/Product/'+action,
            data: JSON.stringify(product)
        })
         .then(function (response) {

             $scope.pruductsList = response.data;
             $scope.initVariable();
         }, function (error) {
             console.log('Error ' + error);
         });
    }

    $scope.editProduct = function (idProduct) {
        $http({
            method: 'POST',
            url: '/Product/getProduct',
            data: JSON.stringify({ idProduct:idProduct })
        })
         .then(function (response) {
             $scope.btnValue = "Actualizar Producto";
             $scope.product = response.data;
             
         }, function (error) {
             console.log('Error ' + error);
         });
    }

    $scope.deleteProduct = function (idProduct) {
        $http({
            method: 'POST',
            url: '/Product/deleteProduct',
            data: JSON.stringify({ idProduct: idProduct })
        })
        .then(function (response) {
            $scope.pruductsList = response.data;
        }, function (error) {
            console.log('Error ' + error);
        });
    }

    $scope.cancel = function () {
        $scope.initVariable();
    }

    init();
});