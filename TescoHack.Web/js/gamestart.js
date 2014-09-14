var app = angular.module('myApp',[]);

app.controller('GameStartCtrl', function($scope) {
  $scope.spices = [{"name":"pasilla", "spiciness":"mild"},
                   {"name":"jalapeno", "spiciness":"hot hot hot!"},
                   {"name":"habanero", "spiciness":"LAVA HOT!!"}];
  $scope.spice = "habanero";
});


var tesco = (function () {
	
	var tesco = this;
	tesco.info = "yeah";
	tesco.game = [];
	tesco.currentUser = "";
	tesco.missionId = 0;
	tesco.products = [];
	tesco.questlist = [];
	tesco.sessionKey = "";
	tesco.searchTerm = "";
	/*Initialise Game*/
	
	tesco.products = products;
	
	$http({
	method: "get",
			url: "http://tescohack.apphb.com/api/Game"
	
	}).success(function(data){
	tesco.game = data;
	console.log(tesco.game.Quest);
	return {
			tesco
		};
})();