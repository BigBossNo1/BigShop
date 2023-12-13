/// <reference path="../../../bower_components/angular/angular.js" />

(function () {
    angular.module('ToanLeeShop.post', ['shop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider) {
        $stateProvider

            .state('post', {
                url: "/post",
                parent: 'base',
                templateUrl: "app/components/posts/postListView.html",
                controller: "postListController"
            })
            .state('post_add', {
                url: "/post_add",
                parent: 'base',
                templateUrl: "app/components/posts/postAddView.html",
                controller: "postAddController"
            });
    }
})();