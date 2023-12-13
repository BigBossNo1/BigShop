(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date()
        };

        $scope.parent = [];
        $scope.AddProduct = AddProduct;

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        $scope.GetSeoTitle = GetSeoTitle;

        // đưa ra tiêu đề seo tự động
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        // gọi api create để thêm mới sản phẩm
        function AddProduct() {
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    // hiện ra thông báo
                    notificationService.displaySuccess(result.data.Name + ' Đã được thêm mới thành công ');
                    // quay về trang chủ
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công !!');
                });
        }

        // truy vấn danh mục lớp cha để phục vụ truy vấn
        function loadParentCategory() {
            apiService.get('api/productcategory/getallparentId', null, function (result) {
                $scope.parent = result.data;
            }, function () {
                console.log('Không thể load ParentID !!');
            });
        }


        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
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
        loadParentCategory();
    }
})(angular.module('ToanLeeShop.product'));