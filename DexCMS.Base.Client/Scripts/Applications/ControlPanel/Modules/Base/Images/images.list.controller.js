define([
    'controlpanel-app'
], function (app) {
    app.controller('imagesListCtrl', [
        '$scope',
        'Images',
        '$window',
        '$document',
        'dexCMSControlPanelSettings',
        'ngToast',
        function ($scope, Images, $window,
            $document, dexcmsSettings, ngToast) {
            $scope.title = "View Images";

            $scope.table = {
                columns: [
                    { property: 'imageID', title: 'ID' },
                    { property: 'alt', title: 'Alt' },
                    {
                        property: 'thumbnail', title: 'Image',
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/images/_images.list.thumbnail.html'
                    },
                    {
                        property: '', title: 'Copy Path', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/images/_images.list.copypath.html'
                    },
                    {
                        property: 'showOnGallery', title: 'Gallery?', disableSorting: true,
                        dataFunction: function (value, item) {
                            return value ? "Display" : "Not Displayed";
                        }
                    },
                    {
                        property: 'canBePageContentImage', title: 'Background?', disableSorting: true,
                        dataFunction: function (value, item) {
                            return value ? "Available" : "Disabled";
                        }
                    },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/images/_images.list.buttons.html'
                    },
                ],
                defaultSort: 'imageID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Images.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    },
                    copyToClipboard: function (path) {
                        var link = dexcmsSettings.baseUrl + path;
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
                    }
                },
                filePrefix: 'Images'
            };

            Images.getList().then(function (data) {
                $scope.table.promiseData = data;
            });

        }
    ]);
});