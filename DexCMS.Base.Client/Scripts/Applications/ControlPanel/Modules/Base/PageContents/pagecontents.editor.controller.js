define([
    'controlpanel-app',
    '../contentareas/contentareas.service',
    '../contentcategories/contentcategories.service',
    '../contentsubcategories/contentsubcategories.service',
    '../seochangefrequency/seochangefrequency.service',
    '../contentblockorder/contentblockorder.service',
    '../contentblocks/contentblocks.service',
    '../pagecontentimages/pagecontentimages.service',
    '../pagetypes/pagetypes.service',
    '../layouttypes/layouttypes.service',
    '../../core/roles/roles.service'
], function (app) {
    app.controller('pageContentsEditorCtrl', [
        '$scope',
        'PageContents',
        '$stateParams',
        '$location',
        'SeoChangeFrequency',
        '$window',
        'ContentBlockOrders',
        'ContentBlocks',
        'PageContentImages',
        '$state',
        'LayoutTypes',
        'ContentAreas',
        'ContentCategories',
        'ContentSubCategories',
        'Roles',
        function (
            $scope,
            PageContents,
            $stateParams,
            $location,
            SeoChangeFrequency,
            $window,
            ContentBlockOrders,
            ContentBlocks,
            PageContentImages,
            $state,
            LayoutTypes,
            ContentAreas,
            ContentCategories,
            ContentSubCategories,
            Roles) {

            $scope.processing = false;

            var id = $stateParams.id || null;
            $scope.title = (id == null ? "Add " : "Edit ") + "Page Content";

            $scope.showAdvanced = false;

            ContentAreas.getList().then(function (response) {
                $scope.contentAreas = response;
                if ($location.search().fromarea) {
                    angular.forEach($scope.contentAreas, function (area) {
                        if (area.urlSegment === $location.search().fromarea) {
                            $scope.currentItem.contentAreaID = area.contentAreaID;
                        }
                    });
                }
            });

            ContentCategories.getList().then(function (response) {
                $scope.contentCategories = response;
                if ($location.search().fromcategory) {
                    angular.forEach($scope.contentCategories, function (category) {
                        if (category.urlSegment === $location.search().fromcategory) {
                            $scope.currentItem.contentCategoryID = category.contentCategoryID;
                        }
                    });
                }
            });

            ContentSubCategories.getList().then(function (response) {
                $scope.contentSubCategories = response;
                if ($location.search().fromcategory) {
                    angular.forEach($scope.contentSubCategories, function (subcategory) {
                        if (subcategory.urlSegment === $location.search().fromsubcategory) {
                            $scope.currentItem.contentSubCategoryID = subcategory.contentSubCategoryID;
                        }
                    });
                }
            });

            LayoutTypes.getList().then(function (response) {
                $scope.layoutTypes = response;
            });
            
            Roles.getList().then(function (data) {
                $scope.roles = data;
            });

            $scope.hasDragged = false;
            $scope.dragTime = function (event) {
                $scope.hasDragged = true;
            }
            $scope.dragTimeImage = function (event) {
                $scope.hasDraggedImage = true;
            }
            
            $scope.seoChangeFrequencies = SeoChangeFrequency.getList();

            $scope.currentItem = {};

            if (id != null) {
                PageContents.getItem(id).then(function (response) {
                    if (response.data.pageTypeID == 1) {
                        $scope.currentItem = response.data;

                        angular.forEach($scope.roles, function (role) {
                            role.isSelected = false;
                            angular.forEach($scope.currentItem.pageContentPermissions, function (userRole) {
                                if (userRole.id === role.id) {
                                    role.isSelected = true;
                                }
                            });
                        });
                    } else {
                        //! Toast error - invalid page number
                        $state.go('pagecontents');
                    }
                });
            } else {
                $scope.currentItem.urlSegment = $location.search().fromurlsegment;
                $scope.currentItem.pageTypeID = 1;
                $scope.showAdvanced = true;
                $scope.isDisabled = false;
                $scope.requiresLogin = false;
            }

            $scope.saveAndStay = function (item) {
                $scope.processing = true;
                PageContents.createItem(item).then(function (response) {
                    $scope.currentItem.pageContentID = response.data.pageContentID;
                    $scope.processing = false;
                });
            };

            $scope.changeRole = function (item, role) {
                if (role.isSelected) {
                    for (var i = 0; i < item.pageContentPermissions.length; i++) {
                        if (item.pageContentPermissions[i].id === role.id) {
                            item.pageContentPermissions.splice(i, 1);
                            role.isSelected = false;
                            return;
                        }
                    }
                } else {
                    role.isSelected = true;
                    item.pageContentPermissions.push({id: role.id, pageContentID: item.pageContentID});
                }
            };

            $scope.save = function (item) {
                $scope.processing = true;
                $scope.modelError = null;
                
                if (item.pageContentID) {
                    PageContents.updateItem(item.pageContentID, item).then(function (response) {
                        redirect(item);
                    }, function (err) {
                        console.warn('ERROR');
                        console.log(err);
                        $scope.modelError = {
                            message: err.message,
                            errors: err.modelState.errors
                        }
                        $scope.processing = false;
                    });
                } else {
                    PageContents.createItem(item).then(function (response) {
                        redirect(item);
                    }, function (err) {
                        console.warn('ERROR');
                        console.log(err);
                        $scope.modelError = {
                            message: err.message,
                            errors: err.modelState.errors
                        }
                        $scope.processing = false;
                    });
                }
            };

            $scope.savePageContentImageOrder = function (item) {
                $scope.processing = true;
                var data = {
                    pageContentID: item.pageContentID,
                    pageContentImages: []
                };
                var displayOrder = 0;
                angular.forEach(item.pageContentImages, function (img) {
                    data.pageContentImages.push({
                        imageID: img.imageID,
                        displayOrder: displayOrder
                    });
                    displayOrder++;
                });
                PageContentImages.updateItems(data).then(function (response) {
                    $scope.hasDraggedImage = false;
                    $scope.processing = false;
                });
            };

            $scope.deletePageContentImage = function ($event, item) {
                $scope.processing = true;
                $event.preventDefault();
                if (confirm('Are you sure?')) {
                    PageContentImages.deleteItem(item.imageID, $scope.currentItem.pageContentID).then(function (response) {
                        $window.location.reload();
                    });
                }
            };

            $scope.saveContentBlockOrder = function (item) {
                $scope.processing = true;
                var cbOrder = [];
                angular.forEach(item.contentBlocks, function (cb) {
                    cbOrder.push({
                        contentBlockID: cb.contentBlockID,
                        displayOrder: cb.displayOrder
                    });
                });
                ContentBlockOrders.updateItems(cbOrder).then(function (response) {
                    $scope.hasDragged = false
                    $scope.processing = false;
                });
            };
            $scope.deleteContentBlock = function ($event, item) {
                $scope.processing = true;
                $event.preventDefault();
                if (confirm('Are you sure?')) {
                    ContentBlocks.deleteItem(item.contentBlockID).then(function (response) {
                        $window.location.reload();
                    });
                }
            };

            $scope.buildSubUrl = function (item) {
                var areaSegment = getAreaSegment(item.contentAreaID),
                    catSegment = getCategorySegment(item.contentCategoryID),
                    subSegment = getSubCategorySegment(item.contentSubCategoryID);
                var subUrl = '';
                if (areaSegment != '') {
                    subUrl += areaSegment + '/';
                }
                if (catSegment != '') {
                    subUrl += catSegment + '/';
                }
                if (subSegment != '') {
                    subUrl += subSegment + '/';
                }
                return subUrl;
            };

            var getAreaSegment = function (areaID) {
                angular.forEach($scope.contentAreas, function (area) {
                    if (area.contentAreaID == areaID) {
                        if (area.contentAreaID != 1) {
                            return area.urlSegment;
                        }
                    }
                });
                return '';
            };
            var getCategorySegment = function (categoryID) {
                angular.forEach($scope.contentCategories, function (category) {
                    if (category.contentCategoryID == categoryID) {
                        return category.urlSegment;
                    }
                });
                return '';
            };
            var getSubCategorySegment = function (subCategoryID) {
                angular.forEach($scope.contentSubCategories, function (subCategory) {
                    if (subCategory.contentSubCategoryID == subCategoryID) {
                        return subCategory.urlSegment;
                    }
                });
                return '';
            };

            var redirect = function (item) {
                if ($location.search().frompage === "true") {

                    var url = '';

                    if (item.contentAreaID != 1) {
                        var areaSegment = getAreaSegment(item.contentAreaID);
                        if (areaSegment != '') {
                            url += areaSegment + '/';
                        }
                    }

                    if (item.contentCategoryID) {
                        var catSegment = getCategorySegment(item.contentCategoryID);
                        if (catSegment != '') {
                            url += catSegment + '/';
                        }
                    }

                    if (item.contentSubCategoryID) {
                        var subSegment = getSubCategorySegment(item.contentSubCategoryID);
                        if (subSegment != '') {
                            url += subSegment + '/';
                        }
                    }

                    url += item.urlSegment;

                    $window.location.href = url;
                } else {
                    $state.go('pagecontents');
                }

            }
        }
    ]);
});