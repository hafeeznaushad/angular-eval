
var myApp = angular.module('myApp', [
  'ngRoute',
  'myControllers',
]);

myApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
      when('/childgroud', {
          templateUrl: 'AngularViews/Childgroup/index.html',
          controller: 'ChildGroupController'
      }).
      otherwise({
          redirectTo: '/childgroud'
      });
  } ]);