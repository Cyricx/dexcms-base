using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;
using System;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;

namespace DexCMS.Base.Initializers
{
    class PageContentInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        private Areas Areas;
        private Categories Categories;
        private Types Types;
        private DateTime Today;

        public PageContentInitializer(IDexCMSBaseContext context) : base(context)
        {
            Areas = new Areas(context);
            Categories = new Categories(context);
            Types = new Types(context);
            Today = DateTime.Now;
        }

        public override void Run()
        {
            Context.PageContents.AddIfNotExists(x => x.PageTitle,
                new PageContent
                {
                    Body = "<p>Thank you for confirming your email.</p>",
                    PageTitle = "Confirm Email",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Confirm Email",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "confirmemail",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    Body = "",
                    PageTitle = "Forgot Password Confirmation",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Forgot Password Confirmation",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "forgotpasswordconfirmation",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    PageTitle = "Change Information",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Change Personal Info",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.ManageAccount,
                    UrlSegment = "changeinfo",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    PageTitle = "Change Password",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Change Password",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.ManageAccount,
                    UrlSegment = "changepassword",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    Body = "<p>We will follow up with you in the next 48 hours.</p>",
                    PageTitle = "Thank you",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Thank you for contacting us!",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Contact,
                    UrlSegment = "success",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    Body = "<p>Please register to create a new account.</p>",
                    PageTitle = "Login",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Login",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "login",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    Body = @"<p>Please check your email to reset your password.</p>
                <p>Be sure to also check your spam folder as password reset emails are commonly marked as spam.</p>
                <p>If you entered an unrecognized email address,
    no email will be sent.</p>",
                    PageTitle = "Forgot Password",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Forgot Password",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "forgotpassword",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    Body = @"<p>&nbsp;</p>
                <p>Please feel free to create a new account so you will be ready when the new ticket system is&nbsp; released.</ p > ",
                    PageTitle = "Register Account",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Register Account",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "register",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    PageTitle = "Resend Confirmation",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Resend Confirmation",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "resendconfirmation",
                    PageTypeID = Types.SiteContent
                },
                new PageContent
                {
                    PageTitle = "Home",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Home",
                    ContentAreaID = Areas.Public,
                    UrlSegment = "index",
                    PageTypeID = Types.SiteContent
                }
            );
            Context.SaveChanges();
        }

        public void RunSubModules(string module)
        {
            switch (module)
            {
                case "Calendars":
                    CreateCalendarsContent();
                    break;
            }
        }

        void CreateCalendarsContent()
        {
            Context.PageContents.AddIfNotExists(x => x.PageTitle,
                new PageContent
                {
                    Body = "",
                    PageTitle = "Calendar",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Calendar",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = null,
                    UrlSegment = "calendar",
                    PageTypeID = Types.SiteContent
                }
            );
            Context.SaveChanges();
        }
    }

    class Areas
    {
        public int Public { get; set; }
        public int ControlPanel { get; set; }

        public Areas(IDexCMSBaseContext Context)
        {
            Public = Context.ContentAreas.Where(x => x.Name == "Public").Select(x => x.ContentAreaID).Single();
            ControlPanel = Context.ContentAreas.Where(x => x.Name == "Control Panel").Select(x => x.ContentAreaID).Single();
        }
    }
    class Categories
    {
        public int Account { get; set; }
        public int Contact { get; set; }
        public int ManageAccount { get; set; }

        public Categories(IDexCMSBaseContext Context)
        {
            Account = Context.ContentCategories.Where(x => x.Name == "Account").Select(x => x.ContentCategoryID).Single();
            Contact = Context.ContentCategories.Where(x => x.Name == "Contact").Select(x => x.ContentCategoryID).Single();
            ManageAccount = Context.ContentCategories.Where(x => x.Name == "Manage Account").Select(x => x.ContentCategoryID).Single();
        }
    }
    class Types
    {
        public int SiteContent { get; set; }

        public Types(IDexCMSBaseContext Context)
        {
            SiteContent = Context.PageTypes.Where(x => x.Name == "Site Content").Select(x => x.PageTypeID).Single();
        }
    }
}