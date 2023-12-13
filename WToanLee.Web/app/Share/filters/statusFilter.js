
(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true) {
                return 'Hoạt Động'
            } else {
                return 'Bị Khóa'
            }
        }
    });
})(angular.module('shop.common'));