'use strict';
var serviceBase = 'http://localhost:22976/';

// Declare app level module which depends on views, and components
angular.module('myApp', [
        'ngRoute',
        'myApp.empsPayroll',
        'myApp.myPayroll',
        'myApp.login',
        'myApp.config',
        'myApp.authInterceptor',
        'myApp.version',
        'LocalStorageModule'
    ]).
    config([
        '$locationProvider', '$routeProvider', '$httpProvider', function($locationProvider, $routeProvider, $httpProvider) {
            $locationProvider.hashPrefix('!');
            $httpProvider.interceptors.push('authInterceptorService');
            $routeProvider.otherwise({ redirectTo: '/login' });
        }
    ]).controller('myAppCtrl', ['$scope', '$rootScope', '$location', 'authService', function ($scope, $rootScope, $location, authService) {

    }]);



angular.module('myApp.config', []).constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase
});


angular.module('myApp.authInterceptor', [])
    .factory('authInterceptorService', ['$q', '$injector', '$location', 'localStorageService', function ($q, $injector, $location, localStorageService) {
        debugger 
    var authInterceptorServiceFactory = {};

    var request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var responseError = function (rejection) {
        debugger
        $location.path("/login");

        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = request;
    authInterceptorServiceFactory.responseError = responseError;

    return authInterceptorServiceFactory;
}])
    .config([
    '$httpProvider', function($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    }
]);