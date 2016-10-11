'use strict';

angular.module('myApp.myPayroll', ['ngRoute', 'myApp.authInterceptor',
        'LocalStorageModule'
])

.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/myPayroll', {
     templateUrl: 'MyPayroll/myPayroll.html',
    controller: 'MyPayrollCtrl'
  });
}]).controller('MyPayrollCtrl', ['$scope', '$rootScope', '$location', 'payrollService', function ($scope,$rootScope, $location, payrollService) {
    $rootScope.showHeader = true;

    $scope.getMyPayroll = function () {

            payrollService.GetMyPayroll().then(function (response) {
                debugger;
                    $scope.data = response.data;
                },
             function (err) {
             });
        };
        $scope.getMyPayroll();

    }]).factory('payrollService', ['$http', '$location', '$q', 'ngAuthSettings', function ($http, $location, $q, ngAuthSettings) {
        var payrollFactory = {};
        var serviceBase = ngAuthSettings.apiServiceBaseUri;

     var getMyPayroll = function () {
        return $http.get(serviceBase + 'api/Employees/GetPayroll');


    };
    var getEmployeesPayroll = function () {
        return $http.get(serviceBase + 'api/Employees/GetEmployeesPayroll');


    };
    payrollFactory.GetMyPayroll = getMyPayroll;
    payrollFactory.GetEmployeesPayroll = getEmployeesPayroll;

    return payrollFactory;
}]);