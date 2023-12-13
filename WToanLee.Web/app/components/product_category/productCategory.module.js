/// <reference path="../../../bower_components/angular/angular.js" />

(function () {
    angular.module('ToanLeeShop.product_category', ['shop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider) {
        $stateProvider

            .state('product_category', {
                url: "/product_category",
                parent: 'base',
                templateUrl: "app/components/product_category/productCategoryListView.html",
                controller: "productCategoryListController"
            })
            .state('add_product_category', {
                url: "/add_product_category",
                parent: 'base',
                templateUrl: "app/components/product_category/productCategoryAddView.html",
                controller: "productCategoryAddController"
            }).state('edit_product_category', {
                url: "/edit_product_category/:id",
                parent: 'base',
                templateUrl: "app/components/product_category/productCategoryEditView.html",
                controller: "productCategoryEditController"
            });
    }
})();