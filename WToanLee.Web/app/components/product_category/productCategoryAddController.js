(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.producCategory = {
            CreatedDate: new Date()
        };

        $scope.parentCategory = [];
        $scope.AddproductCategory = AddproductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        // đưa ra tiêu đề seo tự động
        function GetSeoTitle() {
            $scope.producCategory.Alias = commonService.getSeoTitle($scope.producCategory.Name);
        }

        // gọi api create để thêm mới sản phẩm
        function AddproductCategory() {
            apiService.post('api/productcategory/create', $scope.producCategory,
                function (result) {
                    // hiện ra thông báo
                    notificationService.displaySuccess(result.data.Name + ' Đã được thêm mới thành công ');
                    // quay về trang chủ
                    $state.go('product_category');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công !!');
                });
        }

        // truy vấn danh mục lớp cha để phục vụ truy vấn
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparentId', null, function (result) {
                $scope.parentCategory = result.data;
            }, function () {
                console.log('Không thể load ParentID !!');
            });
        }
        loadParentCategory();
    }
})(angular.module('ToanLeeShop.product_category'));