var myControllers = angular.module('myControllers', ['ngGrid']);

myControllers.controller('ChildGroupController', ['$scope', '$http',
  function ($scope, $http) {

//      var headerTemplate = '<div class="ngHeaderSortColumn " ng-style="{\'cursor\': col.cursor}" ng-class="{ \'ngSorted\': !noSortVisible }">' +
//    '<div ng-click="col.sort($event)"ng-class="\'colt\' + col.index" class="ngHeaderText">{{col.displayName}}</div>' +
//    '<div class="ngSortButtonDown" ng-show="col.showSortButtonDown()"></div>' +
//    '<div class="ngSortButtonUp" ng-show="col.showSortButtonUp()"></div>' +
//    '<div class="ngSortPriority">{{col.sortPriority}}</div>' +
//    '<div ng-class="{ ngPinnedIcon: col.pinned, ngUnPinnedIcon: !col.pinned }" ng-click="togglePin(col)" ng-show="col.pinnable"></div>' +
//'</div>' +
//'<input type="text" ng-click="stopClickProp($event)" placeholder="Filter..." ng-model="col.filterText2" ng-style="{ \'width\' : col.width - 14 + \'px\' }" style="position: absolute; top: 30px; bottom: 30px; left: 0; bottom:0;"/><br><br><br>' +
//'<select name="sample" ng-model="col.sample"><option ng-repeat="status in statuses">{{status}}</option></select>' +

//'<div ng-show="col.resizable" class="ngHeaderGrip" ng-click="col.gripClick($event)" ng-mousedown="col.gripOnMouseDown($event)"></div>';

      var filterBarPlugin = {
        init: function(scope, grid) {
            filterBarPlugin.scope = scope;
            console.log(filterBarPlugin.scope);
            filterBarPlugin.grid = grid;

//            $scope.$watch(filterBarPlugin.scope.columns, function(col1, col2) 
//                {
//                console.log(11);
////                    console.log(col.filterText2 + '' + col.sample);
////                    return col.filterText2 + col.sample;
//                 }, 
//                 function() {
//                    //console.log("here");
//                });

                $scope.$watch(function() 
                {
                    var searchQuery = "";
                    angular.forEach(filterBarPlugin.scope.columns, function(col) {
                        searchQuery += '{ Column: ' + col.displayName + ', Text: ' + col.filterText2 + ', Operator: ' + col.sample +' }';
                    });
                    console.log(searchQuery);
                    return searchQuery;
                 }, 
                 function() {
                    //console.log("here");
                });
           //});
//                    if (col.visible && col.filterText) {
//                        var filterText = (col.filterText.indexOf('*') == 0 ? col.filterText.replace('*', '') : "^" + col.filterText) + ";";
//                        searchQuery += col.displayName + ": " + filterText;
//                    }
//                });


//            $scope.$watch(function() {
//                var searchQuery = "";
//                angular.forEach(filterBarPlugin.scope.columns, function(col) {
//                    if (col.visible && col.filterText) {
//                        var filterText = (col.filterText.indexOf('*') == 0 ? col.filterText.replace('*', '') : "^" + col.filterText) + ";";
//                        searchQuery += col.displayName + ": " + filterText;
//                    }
//                });
//                return searchQuery;
//            }, function(searchQuery) {
//                //console.log(searchQuery);
//                filterBarPlugin.scope.$parent.filterText = searchQuery;
//                filterBarPlugin.grid.searchProvider.evalFilter();
//            });
        },
        scope: undefined,
        grid: undefined,
    };
                     
      $scope.myData = [];
      $scope.statuses = ['>','<'];
      $scope.filterOptions = {
        filterText: "",
        useExternalFilter: true
    };
    $scope.customFilter = function()
    {
        console.log(args);
    };

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
          if (newVal !== oldVal && (newVal.currentPage !== oldVal.currentPage || newVal.pageSize !== oldVal.pageSize)) {
              $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);
          }
      }, true);

      $scope.$watch('filterOptions', function () {
          //Call an async function to fetch data here.
          
        }, true); 

      $scope.groupNameFilter
      $scope.gridOptions = {
          data: 'myData',
          enablePaging: true,
          showFooter: true,
          pagingOptions: $scope.pagingOptions,
          filterOptions: $scope.filterOptions,
          plugins: [filterBarPlugin],
          headerRowHeight: 60,
          columnDefs: [
            { field: 'GroupName', displayName: 'Name', sortable: true, headerClass: 'string', width: 'auto', enableCellEdit: true, customVar:'true', dataType: 'string', allowFiltering : true, headerCellTemplate: '/AngularViews/Childgroup/headertemplate.html?v=5'},
            { field: 'Key', displayName: 'Id', sortable: true, headerClass: 'int', width: 'auto', customVar:'true', dataType: 'int', allowFiltering : true, headerCellTemplate: '/AngularViews/Childgroup/headertemplate.html?v=5'}]
      };

      //      $http.get('/ChildGroup/index').success(function (d) {
      //          $scope.myData = d;
      //          if (!$scope.$$phase) {
      //              $scope.$apply();
      //          }
      //      });
  } ]);
