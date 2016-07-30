define([
    'controlpanel-app'
], function (app) {
    app.controller('imagesListCtrl', [
        '$scope',
        'Images',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        '$document',
        'dexCMSControlPanelSettings',
        'ngToast',
        function ($scope, Images, DTOptionsBuilder, DTColumnBuilder, $compile, $window,
            $document, ttcmsSettings, ngToast) {
            $scope.title = "View Images";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return Images.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('imageID').withTitle('ID'),
                DTColumnBuilder.newColumn('alt').withTitle('Alt'),
                DTColumnBuilder.newColumn('thumbnail').withTitle('Image').renderWith(renderThumbnail),
                DTColumnBuilder.newColumn(null).withTitle('Copy Path').renderWith(renderCopyLink),
                DTColumnBuilder.newColumn('showOnGallery').withTitle('Gallery?').renderWith(renderGallery),
                DTColumnBuilder.newColumn('canBePageContentImage').withTitle('Background?').renderWith(renderBackground),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }
            function renderGallery(data, type, full, meta) {
                return data ? "Display" : "Not Displayed";
            }

            function renderCopyLink(data, type, full, meta) {
                return '<a class="btn btn-default btn-lg"><i class="fa fa-clipboard" ng-click="copyToClipboard(\'' + 
                    ttcmsSettings.baseUrl + full.original + '\')"></i></a>';
            }

            function renderBackground(data, type, full, meta) {
                return data ? "Available" : "Disabled";
            }
            function renderThumbnail(data, type, full, meta) {
                return '<img src="../' + data + '" />';
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="images/:id({id:' + data.imageID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (!data.inUse) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.imageID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.copyToClipboard = function (link) {
                console.log('clicked with ' + link);
                var range = document.createRange();
                var tempElem = $('#copyBoard').css({ position: 'absolute', left: '-1000px', top: '-1000px' });
                tempElem.text(link);
                range.selectNodeContents(tempElem.get(0));
                var selection = window.getSelection();
                selection.removeAllRanges();
                selection.addRange(range);
                document.execCommand("copy", false, null);
                ngToast.create({
                    className: 'success',
                    content: '<p>The image\'s url has been copied to your clipboard.</p>'
                })
            };

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    Images.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});