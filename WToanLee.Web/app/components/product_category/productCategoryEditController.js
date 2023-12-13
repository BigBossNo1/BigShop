(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];
    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.producCategory = {
            CreatedDate: new Date(),
        };

        $scope.parentCategory = [];
        $scope.UpdateproductCategory = UpdateproductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        // đưa ra tiêu đề seo tự động
        function GetSeoTitle() {
            $scope.producCategory.Alias = commonService.getSeoTitle($scope.producCategory.Name);
        }
        // lấy ra thông tin cụ thể của 1 đối tượng khi truyền id vào
        function loadProductCategoryDetails() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.producCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        // gọi api update để update đối tượng
        function UpdateproductCategory() {
            apiService.put('api/productcategory/update', $scope.producCategory,
                function (result) {
                    // hiện ra thông báo
                    notificationService.displaySuccess(result.data.Name + ' Đã được cập nhật thành công ');
                    // quay về trang chủ
                    $state.go('product_category');
                }, function (error) {
                    notificationService.displayError('Cập nhật  không thành công !!');
                });
        }
        // load id của lớp cha để truy vấn trong phần danh mục cha
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparentId', null, function (result) {
                $scope.parentCategory = result.data;
            }, function () {
                console.log('Không thể load ParentID !!');
            });
        }
        loadParentCategory();
        // gọi details bởi vì chưa đc khai báo bên trên
        loadProductCategoryDetails()
    }
})(angular.module('ToanLeeShop.product_category'));