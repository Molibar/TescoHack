var app = angular.module('tescoApp',[]);

app.controller('GameStartCtrl', function($http, $scope) {
	$scope.index = null;
	$scope.setSelectedIndex = function (index) {
		this.index = index;
		common.setCharacterIndex(index);
	};
	$http({
	    method: "get",
	    //url: "http://localhost:23248/api/Game"
		url: "http://tescohack.apphb.com/api/Game"
	}).success(function(data){
		$scope.game = data[0];
		console.log($scope.game);
	});
});