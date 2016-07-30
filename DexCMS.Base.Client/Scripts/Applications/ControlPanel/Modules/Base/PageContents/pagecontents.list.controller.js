define([
    'controlpanel-app'
], function (app) {
    app.controller('pageContentsListCtrl', [
        '$scope',
        'PageContents',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, PageContents, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Page Contents";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return PageContents.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
DTColumnBuilder.newColumn('pageContentID').withTitle('ID'),
DTColumnBuilder.newColumn('heading').withTitle('Title'),
DTColumnBuilder.newColumn('pageTitle').withTitle('Page Title'),
DTColumnBuilder.newColumn('contentAreaName').withTitle('Area'),
DTColumnBuilder.newColumn('contentCategoryName').withTitle('Category'),
DTColumnBuilder.newColumn('contentSubCategoryName').withTitle('SubCategory'),
DTColumnBuilder.newColumn('urlSegment').withTitle('Url'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="pagecontents/:id({id:' + data.pageContentID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.pageContentID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    PageContents.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});