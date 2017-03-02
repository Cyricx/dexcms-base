module.exports = function (appPath, overrides) {
    return {
        name: 'ApplicationsControlPanelNavigation',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.navigation.json',
        options: [
            {
                "title": "Contact",
                "icon": "fa-envelope",
                "subLinks": [
                    {
                        "title": "Messages",
                        href: overrides.contacts || "contacts"
                    },
                    {
                        "title": "Contact Types",
                        href: overrides.contacttypes || "contacttypes"
                    }
                ]
            },
            {
                "title": "Pages",
                "icon": "fa-newspaper-o",
                "subLinks": [
                    {
                        "title": "Page Contents",
                        href: overrides.pagecontents || "pagecontents"
                    },
                    {
                        "title": "Layout Types",
                        href: overrides.layouttypes || "layouttypes"
                    },
                    {
                        "title": "Page Types",
                        href: overrides.pagetypes || "pagetypes"
                    },
                    {
                        "title": "Areas",
                        href: overrides.contentareas || "contentareas"
                    },
                    {
                        "title": "Categories",
                        href: overrides.contentcategories || "contentcategories"
                    },
                    {
                        "title": "Sub Categories",
                        href: overrides.contentsubcategories || "contentsubcategories"
                    },
                    {
                        title: "Redirects",
                        href: overrides.pagecontentredirects || "pagecontentredirects"
                    }
                ]
            }
        ]
    };
};