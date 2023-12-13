/// <reference path="../../../bower_components/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http', 'notificationService', 'authenticationService'];
    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }

        //DELETE
        function del(url, data, success, fail) {
            $http.delete(url, data)
                .then(function (result) {
                    success(result);
                }, function (error) {
                    if (error.status = '401') {
                        notificationService.displayError('Bạn phải đăng nhập');
                    }
                    fail(error);
                });
        }
        //POST
        function post(url, data, success, fail) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status = '401') {
                    notificationService.displayError('Bạn phải đăng nhập');
                }
                fail(error);
            });
        }
        //PUT
        function put(url, data, success, fail) {
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status = '401') {
                    notificationService.displayError('Bạn phải đăng nhập');
                }
                fail(error);
            });
        }
        //GET
        function get(url, params, success, fail) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                fail(error);
            });
        }
    }
})(angular.module('shop.common'));