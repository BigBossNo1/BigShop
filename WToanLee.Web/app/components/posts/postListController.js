(function (app) {
    app.controller('postListController', postListController);
    postListController.$inject = ['$scope', 'apiService']
    function postListController($scope, apiService) {
        $scope.getPost = [];
        $scope.getPost = getPost;
        $scope.keyWord = '';
        $scope.search = search;

        function search() {
            getPost();
        }

        // lấy ra toàn bộ danh sách của keyword truyền vào để phục vụ tìm kiếm
        function getPost() {
            var config = {
                params: {
                    keyWord: $scope.keyWord
                }
            }
            apiService.get('/api/post/getall', config, function (result) {
                $scope.allPost = result.data;
            }, function () {
                console.log('Không thể Load danh mục bai dang!!');
            });
        }
        $scope.getPost();
    }
})(angular.module('ToanLeeShop.post'));