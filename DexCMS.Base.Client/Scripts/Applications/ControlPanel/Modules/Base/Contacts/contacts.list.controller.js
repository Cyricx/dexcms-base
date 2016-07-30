define([
    'controlpanel-app'
], function (app) {
    app.controller('contactsListCtrl', [
        '$scope',
        'Contacts',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, Contacts, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Contacts";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return Contacts.getList();
            }).withBootstrap().withOption('createdRow', createdRow).withOption('order', [4, 'desc']);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('contactID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('phone').withTitle('Phone'),
                DTColumnBuilder.newColumn('email').withTitle('Email'),
                DTColumnBuilder.newColumn('submitDate').withTitle('Date').renderWith(dateHtml),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function dateHtml(data, type, full, meta) {
                return new Date(data).toLocaleString();
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-success" ui-sref="contacts/details/:id({id: +' + data.contactID + '})">' +
                   '   <i class="fa fa-search"></i>' +
                   '</a>';
                buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.contactID + ')">' +
                '   <i class="fa fa-trash-o"></i>' +
                '</button>';
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    Contacts.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});