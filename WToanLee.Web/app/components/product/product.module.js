/// <reference path="../../../bower_components/angular/angular.js" />

(function () {
    angular.module('ToanLeeShop.product', ['shop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider) {
        $stateProvider

            .state('product', {
                url: "/product",
                parent: 'base',
                templateUrl: "app/components/product/productListView.html",
                controller: "productListController"
            })
            .state('product_add', {
                url: "/product_add",
                parent: 'base',
                templateUrl: "app/components/product/productAddView.html",
                controller: "productAddController"
            }).state('product_edit', {
                url: "/product_edit/:id",
                parent: 'base',
                templateUrl: "app/components/product/productEditView.html",
                controller: "productEditController"
            });
    }
})();