using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Base.Initializers.Helpers;
using DexCMS.Base.Enums;

namespace DexCMS.Base.Initializers
{
    class PageContentInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        private AreasReference Areas;
        private CategoriesReference Categories;
        private PageTypesReference Types;
        private LayoutTypesReference LayoutTypes;
        private DateTime Today;

        public PageContentInitializer(IDexCMSBaseContext context) : base(context)
        {
            Areas = new AreasReference(context);
            Categories = new CategoriesReference(context);
            Types = new PageTypesReference(context);
            LayoutTypes = new LayoutTypesReference(context);
            Today = DateTime.Now;
        }

        public override void Run(bool addDemoContent = true)
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    PageTitle = "Manage Account",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Manage Account",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.ManageAccount,
                    UrlSegment = "manage",
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = true
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = true
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = true
                },
                new PageContent
                {
                    Body = "<p>Please use the form below to contact us.</p>",
                    PageTitle = "Contact Us",
                    ChangeFrequency = SEOChangeFrequency.Monthly,
                    LastModified = Today,
                    AddToSitemap = true,
                    Heading = "Contact Us",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Contact,
                    UrlSegment = "contact",
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    Body = "<p>Please register to create a new account.</p>",
                    PageTitle = "Login",
                    ChangeFrequency = SEOChangeFrequency.Monthly,
                    LastModified = Today,
                    AddToSitemap = true,
                    Heading = "Login",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "login",
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    Body = @"<p>Please feel free to create a new account.</p> ",
                    PageTitle = "Register Account",
                    ChangeFrequency = SEOChangeFrequency.Monthly,
                    LastModified = Today,
                    AddToSitemap = true,
                    Heading = "Register Account",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "register",
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    Body = @"<p>Please confirm your email address and enter a new password.</p> ",
                    PageTitle = "Reset Password",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Reset Password",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "resetpassword",
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    Body = @"<p>Your password has been reset, please click below to login.</p>",
                    PageTitle = "Reset Password Confirmation",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Reset Password Confirmation",
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = Categories.Account,
                    UrlSegment = "resetpasswordconfirmation",
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
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
                    PageTypeID = Types.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    PageTitle = "Home",
                    ChangeFrequency = SEOChangeFrequency.Weekly,
                    LastModified = Today,
                    AddToSitemap = true,
                    Heading = "Home",
                    ContentAreaID = Areas.Public,
                    UrlSegment = "index",
                    PageTypeID = Types.SiteContent,
                    Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    PageTitle = "Control Panel",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Control Panel",
                    ContentAreaID = Areas.ControlPanel,
                    UrlSegment = "index",
                    PageTypeID = Types.SiteContent,
                    IsDisabled = false,
                    RequiresLogin = true
                },
                new PageContent
                {
                    PageTitle = "Error",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Error Occured",
                    ContentAreaID = Areas.Public,
                    UrlSegment = "error",
                    PageTypeID = Types.SiteContent,
                    Body = @"<p>We apologize, an error has occured. We are looking into the issue and will work on a resolution.</p>",
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                },
                new PageContent
                {
                    PageTitle = "Page Not Found",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Page NotFound",
                    ContentAreaID = Areas.Public,
                    UrlSegment = "notfound",
                    PageTypeID = Types.SiteContent,
                    Body = @"<p>The page you are looking for does not exist. Please use the menu to navigate the website.</p>",
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                }
            );
            Context.SaveChanges();

            if (addDemoContent)
            {
                Context.PageContents.AddIfNotExists(x => x.PageTitle,
                    new PageContent
                    {
                        PageTitle = "One Column",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "One Column",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "onecolumn",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.OneColumn,
                        IsDisabled = false,
                        RequiresLogin = false
                    },
                    new PageContent
                    {
                        PageTitle = "Two Column",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "Two Column",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "twocolumn",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.TwoColumn,
                        IsDisabled = false,
                        RequiresLogin = false
                    },
                    new PageContent
                    {
                        PageTitle = "Three Column",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "Three Column",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "threecolumn",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.ThreeColumn,
                        IsDisabled = false,
                        RequiresLogin = false
                    },
                    new PageContent
                    {
                        PageTitle = "Right Sidebar",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "Right Sidebar w/ Content",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "rightsidebar",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.RightSidebar,
                        IsDisabled = false,
                        RequiresLogin = false
                    },
                    new PageContent
                    {
                        PageTitle = "Left Sidebar",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "Left Sidebar w/ Content",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "leftsidebar",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.LeftSidebar,
                        IsDisabled = false,
                        RequiresLogin = false
                    },
                    new PageContent
                    {
                        PageTitle = "Right Sidebar Only",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "Right Sidebar Only",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "rightsidebaronly",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.RightSidebarOnly,
                        IsDisabled = false,
                        RequiresLogin = false
                    },
                    new PageContent
                    {
                        PageTitle = "Left Sidebar Only",
                        ChangeFrequency = 0,
                        LastModified = Today,
                        AddToSitemap = false,
                        Heading = "Left Sidebar Only",
                        ContentAreaID = Areas.Public,
                        UrlSegment = "leftsidebaronly",
                        PageTypeID = Types.SiteContent,
                        Body = @"<p>Please stop looking at your phone and pet me scratch at the door then walk away give attitude, but cats making all the muffins sun bathe. Mrow. Cough furball licks your face rub whiskers on bare skin act innocent lounge in doorway or cough furball but run outside as soon as door open but fall asleep on the washing machine. Meow to be let in. Pee in the shoe hiss at vacuum cleaner and lounge in doorway yet please stop looking at your phone and pet me and chase dog then run away. Purrr purr littel cat, little cat purr purr chirp at birds. </p>
<p>Eat owner's food have secret plans. Steal the warm chair right after you get up pushes butt to face. Damn that dog my left donut is missing, as is my right so hiss at vacuum cleaner gnaw the corn cob wake up wander around the house making large amounts of noise jump on top of your human's bed and fall asleep again when in doubt, wash. Kitty loves pigs leave dead animals as gifts claws in your leg so kitty loves pigs yet put butt in owner's face soft kitty warm kitty little ball of furr cat snacks. Attack dog, run away and pretend to be victim cats go for world domination. Eat prawns daintily with a claw then lick paws clean wash down prawns with a lap of carnation milk then retire to the warmest spot on the couch to claw at the fabric before taking a catnap chase dog then run away and plan steps for world domination russian blue yet my slave human didn't give me any food so i pooped on the floor. Lies down chew foot, but plan steps for world domination and scratch leg; meow for can opener to feed me but meow meow, i tell my human. Catch mouse and gave it as a present flop over rub whiskers on bare skin act innocent for purr while eating yet climb a tree, wait for a fireman jump to fireman then scratch his face, and damn that dog or sit in box. </p>
<p>Human give me attention meow. Chase the pig around the house mrow chew on cable, but ignore the squirrels, you'll never catch them anyway where is my slave? I'm getting hungry, but get video posted to internet for chasing red dot. Destroy couch meow all night having their mate disturbing sleeping humans. Intrigued by the shower pee in human's bed until he cleans the litter box. Soft kitty warm kitty little ball of furr sleep on dog bed, force dog to sleep on floor human is washing you why halp oh the horror flee scratch hiss bite and hiss at vacuum cleaner, so cats making all the muffins. Gnaw the corn cob. Meow run in circles kitty scratches couch bad kitty sleep nap. Spread kitty litter all over house put butt in owner's face. Climb a tree, wait for a fireman jump to fireman then scratch his face pee in the shoe chase imaginary bugs kitty loves pigs. Curl up and sleep on the freshly laundered towels curl up and sleep on the freshly laundered towels yet sleep on keyboard hide head under blanket so no one can see and lounge in doorway love to play with owner's hair tie. </p>",
                        LayoutTypeID = LayoutTypes.LeftSidebarOnly,
                        IsDisabled = false,
                        RequiresLogin = false
                    }
                );
                Context.SaveChanges();
            }
        }
    }
}