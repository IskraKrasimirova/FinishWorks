using Microsoft.AspNetCore.Mvc;
using FinishWorks.Models;
using FinishWorks.Services;

namespace FinishWorks.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContactController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var html = $@"
            <h2>Ново запитване от контакт формата</h2>
            <p><strong>Име:</strong> {model.Name}</p>
            <p><strong>Телефон:</strong> {model.Phone}</p>
            <p><strong>Email:</strong> {model.Email}</p>
            <p><strong>Съобщение:</strong> {model.Message}</p>
            ";

            // Send email via MailtrapEmailSender
            await _emailSender.SendEmailAsync(
                "iskra@test.mailtrap.io",
                "Ново запитване от FinishWorks",
                html
            );

            // After sending, set TempData["SuccessMessage"] and redirect to Index.
            TempData["SuccessMessage"] = "Благодарим Ви! Вашето запитване беше изпратено успешно. Ще се свържем с Вас в най-кратък срок!";
            return RedirectToAction(nameof(Index));
        }
    }
}
