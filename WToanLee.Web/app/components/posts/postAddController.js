(function (app) {
    app.controller('postAddController', postAddController);
    postAddController.$inject = ['$scope', 'apiService' , '$state']
    function postAddController($scope, apiService , $state) {
        $scope.addPost = addPost;
        $scope.post = {
            CreatedDate: new Date()
        };

        function addPost() {
            apiService.post('/api/post/create', $scope.post, function (result) {
                $state.go('post');
            }, function () {
                console.log('Không thể Thêm mới danh mục bai dang!!');
            });
        }
    }
})(angular.module('ToanLeeShop.post'));
