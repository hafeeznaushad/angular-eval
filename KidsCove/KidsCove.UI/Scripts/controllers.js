var myControllers = angular.module('myControllers', []);

myControllers.controller('ChildGroupController', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('/ChildGroup/index').success(function (data) {
          $scope.groups = data;
      });

      //$scope.name = 'age';
  } ]);
