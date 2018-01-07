using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using szamoranoBlog.Models;
using PagedList.Mvc;

namespace szamoranoBlog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(db.Posts.OrderByDescending(p => p.Created).ToPagedList(pageNumber, pageSize));
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message:</p><p>{2}</p>";
                    var from = "MyPortfolio<Example@email.com>";
                    //model.Body = "This is a message from your portfolio site. The name and the email of the contacting person is above.";
                    //var assignedUser = db.Users.Find(ticket.AssignedUserId);
                    //var emailTo = assignedUser.Email;

                    var email = new MailMessage(from,
                            ConfigurationManager.AppSettings["emailto"])
                   
                {
                    Subject = "Portfolio Contact Email",
                    Body = string.Format(body, model.FromName, model.FromEmail,
                                model.Body),
                    IsBodyHtml = true
                };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);
                    return RedirectToAction("Sent");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}