var app = angular.module('tescoApp', []);
//app.controller('TescoController', ['$http'], function($http){
app.controller('TescoController', function($http){
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
        method: "post",
                url: "http://tescohack.apphb.com/api/Game"

        }).success(function(data){
tesco.game = data;
console.log(tesco.game.Quest);
});
  

        var urlRoot = 'https://secure.techfortesco.com/groceryapi/restservice.aspx?';
        var jcb = '&JSONP=JSON_CALLBACK';
        /*
        $http.jsonp(urlRoot + 'command=LOGIN' + jcb + '&email=&password=&developerkey=0ujRTU8FlFnyfad11Ium&applicationkey=417361BD075D0FCFD502').success(function(data){
tesco.sessionKey = data.SessionKey;
});*/
        tesco.add = function(data){
            tesco.game.Quest.Missions.push(data);
        };
        
        tesco.addQuest = function(data){
            tesco.game.Quest.Missions.push(data);
			$('#autocomplete-input').val('');
			$('#autocomplete-input').change();

        };
        
        
        tesco.output = function(){

        console.log(tesco.game.Quest.Missions);
        };
        tesco.CheckIn = function(){
        $http({
        method: "post",
                url: "http://tescohack.apphb.com/api/CheckIn/" + tesco.currentUser

        }).success(function(data){
        tesco.game = data;
        });
        };
        tesco.CheckOut = function(){
        $http({
        method: "post",
                url: "http://tescohack.apphb.com/api/CheckOut/" + tesco.currentUser

        }).success(function(data){
        tesco.game = data;
        });
        };
        
 
        tesco.SubmitScan = function(){
        $http({
        method: "post",
                url: "http://tescohack.apphb.com/api/Scan/" + tesco.missionId + "/" + tesco.currentUser

        }).success(function(data){
        tesco.game = data;
        });
        };
        tesco.apiCall = function(){

            $http.jsonp(urlRoot + 'command=PRODUCTSEARCH' + jcb + '&searchtext=' + tesco.searchTerm + '&sessionkey=' + tesco.sessionKey + '&page=1&developerkey=0ujRTU8FlFnyfad11Ium&applicationkey=417361BD075D0FCFD502').success(function(data){
            console.log(data);
                    tesco.products = data.Products;
            });
        };
        
        tesco.InitList = function(){
            console.log(tesco.game);
            delete tesco.game.regex;
            $http({
                method: "post",
                url: "http://tescohack.apphb.com/api/Game",
                data: tesco.game

        }).success(function(data){
            console.log(data);                        
            tesco.game = data;
        
        });
        };
        
});        