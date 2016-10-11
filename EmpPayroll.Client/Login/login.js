'use strict';

angular.module('myApp.login', ['ngRoute', 'myApp.config', 'myApp.authInterceptor',
        'LocalStorageModule'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/login', {
        templateUrl: 'Login/login.html',
        controller: 'LoginCtrl'
    });
}])

.controller('LoginCtrl', ['$scope', '$rootScope', '$location', 'authService', function ($scope, $rootScope, $location, authService) {
    $scope.loginData = {
        UserName: "",
        Password: ""
    };
    $scope.message = "";
   $rootScope.showHeader = false;
    $scope.login = function () {

        authService.Login($scope.loginData).then(function (response) {
            $rootScope.showHeader = true;

            $location.path("/myPayroll");

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}])

.factory('authService', ['$http', '$location', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $location, $q, localStorageService, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};
    var authentication = {
        isAuth: false,
        UserName: "",
        UserId: ""
    };
    var getUserInfo = function (registerExternalData) {

        return $http({
            method: 'GET',
            url: serviceBase + '/api/Account/UserInfo',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded', 'Authorization': 'Bearer ' + registerExternalData.AccessToken }
        });


    };

    var login = function (loginData) {
        debugger;
        var data = "grant_type=password&UserName=" + loginData.UserName + "&password=" + loginData.Password;

        var deferred = $q.defer();
        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
            localStorageService.set('authorizationData', { token: response.access_token, UserName: loginData.UserName, UserID: response.UserId });
            authentication.isAuth = true;
            authentication.UserName = loginData.UserName;
            authentication.UserId = response.UserId;
            deferred.resolve(response);
            debugger
        }).error(function (err, status) {
            debugger
            deferred.reject(err);
        });

        return deferred.promise;

    };

    authServiceFactory.Login = login;
    authServiceFactory.GetUserInfo = getUserInfo;

    return authServiceFactory;
}]);