'use strict';

angular.module('myApp.empsPayroll', ['ngRoute', 'myApp.authInterceptor',
        'LocalStorageModule', 'myApp.myPayroll'])

.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/empsPayroll', {
        templateUrl: 'EmployeesPayroll/empsPayroll.html',
        controller: 'EmpsPayrollCtrl'
  });
}])
  .controller('EmpsPayrollCtrl', ['$scope', '$rootScope','$location', 'payrollService', 'ngAuthSettings', function ($scope,$rootScope, $location, payrollService, ngAuthSettings) {
      $rootScope.showHeader = true;

      $scope.getEmployeesPayroll = function () {

          payrollService.GetEmployeesPayroll().then(function (response) {
              debugger;
                  $scope.employees = response.data;
              },
           function (err) {
           });
      };
      $scope.getEmployeesPayroll();

}]);