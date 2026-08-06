using Microsoft.AspNetCore.Mvc;
using FinishWorks.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace FinishWorks.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var username = Environment.GetEnvironmentVariable("SMTP_USERNAME");
            var password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(username, password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(username),
                    Subject = "Клиентско запитване – FinishWorks",
                    Body = $"Име: {model.Name}\nТелефон: {model.Phone}\nИмейл: {model.Email}\n\nСъобщение:\n{model.Message}",
                    IsBodyHtml = false
                };
                mailMessage.To.Add("momchil404@gmail.com");

                client.Send(mailMessage);
            }

            // After sending, set TempData["SuccessMessage"] and redirect to Index.
            TempData["SuccessMessage"] = "Благодарим Ви! Вашето запитване беше изпратено успешно. Ще се свържем с Вас в най-кратък срок!";
            return RedirectToAction(nameof(Index));
        }
    }
}
