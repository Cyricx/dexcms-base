module.exports = function (appPath) {
    return {
        name: 'ApplicationsControlPanelRoutes',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.routes.json',
        options: [
            {
                "name": "contacts",
                "module": "base",
                "routes": [
                    {
                        "viewType": "list",
                        "path": ""
                    },
                    {
                        "viewType": "details",
                        "path": "/details/:id"
                    }
                ]
            },
            {
                "name": "contactTypes",
                "module": "base"
            },
            {
                "name": "contentBlocks",
                "module": "base",
                "routes": [
                    {
                        "viewType": "editor",
                        "path": "/:id"
                    },
                    {
                        "viewType": "editor",
                        "path": "/:id?fromadmin"
                    },
                    {
                        "viewType": "editor",
                        "path": "/new/:parentId"
                    },
                    {
                        "viewType": "editor",
                        "path": "/new/:parentId?fromadmin"
                    }
                ]
            },
            {
                "name": "contentAreas",
                "module": "base"
            },
            {
                "name": "contentCategories",
                "module": "base"
            },
            {
                "name": "contentSubCategories",
                "module": "base"
            },
            {
                "name": "pageTypes",
                "module": "base"
            },
            {
                "name": "layoutTypes",
                "module": "base"
            },
            {
                "name": "countries",
                "module": "base"
            },
            {
                "name": "states",
                "module": "base"
            },
            {
                "name": "images",
                "module": "base"
            },
            {
                "name": "pageContents",
                "module": "base"
            },
            {
                "name": "pageContentImages",
                "module": "base",
                "routes": [
                    {
                        "viewType": "list",
                        "path": "/:id"
                    },
                    {
                        "viewType": "list",
                        "path": "/:id?fromadmin"
                    }
                ]
            },
            {
                "name": "settingDataTypes",
                "module": "base"
            },
            {
                "name": "settingGroups",
                "module": "base"
            },
            {
                "name": "settings",
                "module": "base"
            },
        ]  
    };
};