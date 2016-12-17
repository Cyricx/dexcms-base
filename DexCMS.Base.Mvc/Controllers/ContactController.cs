using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Base.Mvc.Models;
using DexCMS.Core.Infrastructure;
using System.Web.Configuration;

namespace DexCMS.Base.Mvc.Controllers
{
    public class ContactController : Controller
    {
    	private IContactRepository repository;

		public ContactController(IContactRepository repo)
		{
			repository = repo;
		}

        // GET: /Contact/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Contact contact)
        {
            if (!ReCaptcha.IsValid(Request))
            {
                ModelState.AddModelError("captcha", "Captcha Error");
            }
            if (ModelState.IsValid)
            {
                contact.ContactTypeID = 1;//hardcoding contact type to other
                contact.SubmitDate = DateTime.Now;
                List<string> pages = (List<string>)Session["pages"];
                contact.VisitedUrlsToAdd = pages;
                Session["pages"] = null;
				var result = repository.AddAsync(contact).Result;

                //create message
                string message = string.Format("<table>" +
                "<tr style='background-color:#c0c0c0'><td>Name</td><td>{0}</td></tr>" +
                "<tr><td>Email</td><td>{1}</td></tr>" +
                "<tr style='background-color:#c0c0c0'><td>Phone</td><td>{2}</td></tr>" +
                "<tr><td>Message</td><td>{3}</td></tr>" +
                "<tr style='background-color:#c0c0c0'><td>Referrer</td><td>{4}</td></tr>" +
                "<tr><td>Pages visited</td><td>{5}</td></tr>" +
                "</table>",
                contact.Name, contact.Email, contact.Phone, contact.Message, contact.Referrer,
                string.Join(", ", contact.VisitedUrlsToAdd)
                );
                if (WebConfigurationManager.AppSettings["DisableEmails"] != "true")
                {
                    EmailResult emailResult = EmailProcessor.SendEmail(
                    message, contact.Email,
                    "Contact submitted from " + contact.Name,
                    true
                    );

                    if (!emailResult.IsSuccess)
                    {
                        ModelState.AddModelError("emailfailed", emailResult.Message);
                    }
                }
                return RedirectToAction("Success");
            }
            return View(contact);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
