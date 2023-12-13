(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];
    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
        };

        $scope.parentCategory = [];
        $scope.Updateproduct= Updateproduct;
        $scope.GetSeoTitle = GetSeoTitle;

        // đưa ra tiêu đề seo tự động
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        // lấy ra thông tin cụ thể của 1 đối tượng khi truyền id vào
        function loadProductDetails() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        // gọi api update để update đối tượng
        function Updateproduct() {
            apiService.put('api/product/update', $scope.product,
                function (result) {
                    // hiện ra thông báo
                    notificationService.displaySuccess(result.data.Name + ' Đã được cập nhật thành công ');
                    // quay về trang chủ
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Cập nhật  không thành công !!');
                });
        }
        $scope.moreImages = [];

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })

            }
            finder.popup();
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
        loadProductDetails()
    }
})(angular.module('ToanLeeShop.product'));