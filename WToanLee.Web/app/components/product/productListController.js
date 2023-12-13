(function (app) {
    app.controller('productListController', productListController);
    productListController.$inject = ['$scope', 'apiService']
    function productListController($scope, apiService) {
        $scope.getProduct = [];
        $scope.getProduct = getProduct;
        $scope.keyWord = '';
        $scope.search = search;

        function search() {
            getProduct();
        }

        // lấy ra toàn bộ danh sách của keyword truyền vào để phục vụ tìm kiếm
        function getProduct() {
            var config = {
                params: {
                    keyWord: $scope.keyWord
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                $scope.allProduct = result.data;
            }, function () {
                console.log('Không thể Load danh mục bai dang!!');
            });
        }
        $scope.getProduct();
    }
})(angular.module('ToanLeeShop.product'));