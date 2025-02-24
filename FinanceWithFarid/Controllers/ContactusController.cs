using Logger.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinanceWithFarid.Controllers
{
    public class ContactusController : Controller
    {
        private FinanceWithFaridDataEntities db;/* = new FinanceWithFaridDataEntities();*/

        [HttpPost]
        public ActionResult AddContactus(contactus contactuss)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new FinanceWithFaridDataEntities())
                    {
                        if (contactuss != null)
                        {
                            //email

                            //MailMessage mm = new MailMessage("zeeshanasgar07@gmail.com", contactuss.Email);
                            MailMessage mm = new MailMessage("zeeshanasgar07@gmail.com", "zeeshanasgar07@gmail.com");
                            mm.Subject = "This is your Data";
                            string body = $"Name: {contactuss.Name} \n";
                            body += $"Email: {contactuss.Email} \n";
                            body += $"Subject: {contactuss.Subject} \n";
                            body += $"Message: {contactuss.Message}  \n";

                            // for sending image
                            //string fileName = Path.GetFileName(contactuss.file.FileName);
                            //mm.Attachments.Add(new Attachment(contactuss.file.InputStream, fileName));


                            mm.Body = body;
                            mm.IsBodyHtml = false;

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.EnableSsl = true;

                            NetworkCredential nc = new NetworkCredential("zeeshanasgar07@gmail.com", "desydnsxnecdafeu");
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = nc;
                            smtp.Send(mm);


                            //email

                            db.contactus.Add(contactuss);
                            db.SaveChanges();
                            return Json(new { success = true }); // Return a success response
                        }
                    }
                }
                // Handle any validation errors or null data
                return Json(new { success = false, error = "Invalid data" });
            }
            catch (Exception ex)
            {
                // Log the exception
                return Json(new { success = false, error = "An error occurred" });
            }
        }

    }
}