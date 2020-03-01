using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using MyFYP.Core.Contracts;


namespace MyFYP.WebUI.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }

        //Adapated from https://www.youtube.com/watch?v=hlZexx2gbNs
        [HttpPost]
        public ActionResult Index(MyFYP.Core.Models.gmail model)
        {
            

            MailMessage mm = new MailMessage("mcnamaraenya@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;


            SmtpClient smpt = new SmtpClient();
            smpt.UseDefaultCredentials = false;
            smpt.Host = "smtp.gmail.com";
            smpt.Port = 587;
            smpt.EnableSsl = true;
            if (model.Attachment.ContentLength > 0)
            {
                string fileName = Path.GetFileName(model.Attachment.FileName);
                mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
            }

            NetworkCredential nc = new NetworkCredential("mcnamaraenya@gmail.com", "Toppy01glitzandbits");
            
            smpt.Credentials = nc;
            smpt.Send(mm);
            ViewBag.Message = "Application sent successfully";

            return View();
        }
    }
}