(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService']
    function productCategoryListController($scope, apiService, $ngBootbox, notificationService) {
        $scope.getProductCategory = [];
        $scope.getProductCategory = getProductCategory;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;

        // xác nhận và có hai sự lựa chọn là click về yes hoặc hủy bỏ không xóa nữa
        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/productcategory/delete', config, function () {
                        notificationService.displaySuccess('Xóa thành công');
                        search();
                    }, function () {
                        notificationService.displayError('Xóa không thành công');
                    })
                });
        }

        function search() {
            getProductCategory();
        }

        // lấy ra toàn bộ danh sách của keyword truyền vào để phục vụ tìm kiếm
        function getProductCategory() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategory = result.data;
            }, function () {
                console.log('Không thể Load danh mục sản phẩm !!');
            });
        }
        $scope.getProductCategory();
    }
})(angular.module('ToanLeeShop.product_category'));