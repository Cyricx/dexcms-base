using System;
using System.Collections.Generic;
using System.Linq;
using DexCMS.Base.Contexts;
using DexCMS.Base.Models;

namespace DexCMS.Base.Globals.Initializers
{
    class PageContentInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            //areas
            int Public = context.ContentAreas.Where(x => x.Name == "Public").Select(x => x.ContentAreaID).Single();
            int ControlPanel = context.ContentAreas.Where(x => x.Name == "Control Panel").Select(x => x.ContentAreaID).Single();
            int Account = context.ContentCategories.Where(x => x.Name == "Account").Select(x => x.ContentCategoryID).Single();
            int Contact = context.ContentCategories.Where(x => x.Name == "Contact").Select(x => x.ContentCategoryID).Single();
            int ManageAccount = context.ContentCategories.Where(x => x.Name == "Manage Account").Select(x => x.ContentCategoryID).Single();
            int SiteContent = context.PageTypes.Where(x => x.Name == "Site Content").Select(x => x.PageTypeID).Single();
            DateTime today = DateTime.Now;

            var pageContents = new List<PageContent>
            {
                new PageContent {
                    Body = "<p>Thank you for confirming your email.</p>",
                    PageTitle = "Confirm Email",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Confirm Email",
                    ContentAreaID = Public,
                    ContentCategoryID = Account,
                    UrlSegment = "confirmemail",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    Body = "",
                    PageTitle = "Forgot Password Confirmation",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Forgot Password Confirmation",
                    ContentAreaID = Public,
                    ContentCategoryID = Account,
                    UrlSegment = "forgotpasswordconfirmation",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    PageTitle = "Change Information",
                     ChangeFrequency = 0,
                     LastModified = today,
                     AddToSitemap = false,
                     Heading = "Change Personal Info",
                     ContentAreaID = Public,
                     ContentCategoryID = ManageAccount,
                     UrlSegment = "changeinfo",
                     PageTypeID = SiteContent
                },
                new PageContent {
                    PageTitle = "Change Password",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Change Password",
                    ContentAreaID = Public,
                    ContentCategoryID = ManageAccount,
                    UrlSegment = "changepassword",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    Body = "<p>We will follow up with you in the next 48 hours.</p>",
                    PageTitle = "Thank you",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Thank you for contacting us!",
                    ContentAreaID = Public,
                    ContentCategoryID = Contact,
                    UrlSegment = "success",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    Body = "<p>Please register to create a new account.</p>",
                    PageTitle = "Login",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Login",
                    ContentAreaID = Public,
                    ContentCategoryID = Account,
                    UrlSegment = "login",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    Body = @"<p>Please check your email to reset your password.</p>
                <p>Be sure to also check your spam folder as password reset emails are commonly marked as spam.</p>
                <p>If you entered an unrecognized email address,
 no email will be sent.</p>",
                    PageTitle = "Forgot Password",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Forgot Password",
                    ContentAreaID = Public,
                    ContentCategoryID = Account,
                    UrlSegment = "forgotpassword",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    Body = @"<p>&nbsp;</p>
                <p>Please feel free to create a new account so you will be ready when the new ticket system is&nbsp; released.</ p > ",
                    PageTitle = "Register Account",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Register Account",
                    ContentAreaID = Public,
                    ContentCategoryID = Account,
                    UrlSegment = "register",
                    PageTypeID = SiteContent
                },
                new PageContent {
                    PageTitle = "Resend Confirmation",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Resend Confirmation",
                    ContentAreaID = Public,
                    ContentCategoryID = Account,
                    UrlSegment = "resendconfirmation",
                    PageTypeID = SiteContent
                },
                new PageContent
                {
                    PageTitle = "Home",
                    ChangeFrequency = 0,
                    LastModified = today,
                    AddToSitemap = false,
                    Heading = "Home",
                    ContentAreaID = Public,
                    UrlSegment = "index",
                    PageTypeID = SiteContent
                }
            };
            pageContents.ForEach(x => context.PageContents.Add(x));
            context.SaveChanges();
        }
    }
}
