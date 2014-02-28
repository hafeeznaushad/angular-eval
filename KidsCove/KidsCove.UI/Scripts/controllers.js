var myControllers = angular.module('myControllers', ['ngGrid']);

myControllers.controller('ChildGroupController', ['$scope', '$http',
  function ($scope, $http) {

      $scope.myData = [];

      $scope.pagingOptions = { pageSizes: [2, 4, 6], pageSize: 2, currentPage: 1 };
      $scope.setPagingData = function (data, page, pageSize) {
          var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
          $scope.myData = pagedData;
          $scope.totalServerItems = data.length;
          if (!$scope.$$phase) {
              $scope.$apply();
          }
      };
      $scope.getPagedDataAsync = function (pageSize, page) {
          setTimeout(function () {
              var data;
              $http.get('ChildGroup/index').success(function (largeLoad) {
                  $scope.setPagingData(largeLoad, page, pageSize);
              });

          }, 100);
      };

      $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);

      $scope.$watch('pagingOptions', function (newVal, oldVal) {
          console.log(newVal);
          console.log(oldVal);
          if (newVal !== oldVal && (newVal.currentPage !== oldVal.currentPage || newVal.pageSize !== oldVal.pageSize)) {
              console.log("1");
              $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);
          }
      }, true);

      $scope.gridOptions = {
          data: 'myData',
          enablePaging: true,
          showFooter: true,
          pagingOptions: $scope.pagingOptions,
          columnDefs: [{ field: 'GroupName', displayName: 'Name', sortable: true, headerClass: 'foo', width: 'auto', enableCellEdit: true },
                     { field: 'Key', displayName: 'Id', sortable: true, width: 'auto'}]
      };

      //      $http.get('/ChildGroup/index').success(function (d) {
      //          $scope.myData = d;
      //          if (!$scope.$$phase) {
      //              $scope.$apply();
      //          }
      //      });
  } ]);
