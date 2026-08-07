using Microsoft.AspNetCore.Mvc;
using FinishWorks.Models;

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

            // After sending, set TempData["SuccessMessage"] and redirect to Index.
            TempData["SuccessMessage"] = "Благодарим Ви! Вашето запитване беше изпратено успешно. Ще се свържем с Вас в най-кратък срок!";
            return RedirectToAction(nameof(Index));
        }
    }
}
