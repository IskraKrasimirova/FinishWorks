using Microsoft.AspNetCore.Mvc;
using FinishWorks.Models;
using System.Collections.Generic;

namespace FinishWorks.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            var services = new List<ServiceItem>
            {
                new ServiceItem
                {
                    Id = 1,
                    Name = "Сухо строителство",
                    Description = "Окачени тавани, преградни стени от гипсокартон, предстенни обшивки, нестандартни декоративни фигури и скрито осветление.",
                    Price = "€13–20 / м²",
                    IconPath = "bi-layout-sidebar-inset"
                },
                new ServiceItem
                {
                    Id = 2,
                    Name = "Шпакловка и гипсови мазилки",
                    Description = "Фино и грубо шпакловане, полагане на мрежа срещу пукнатини, машинно и ръчно шлайфане за перфектно гладки стени.",
                    Price = "€6–9 / м²",
                    IconPath = "bi-tools"
                },
                new ServiceItem
                {
                    Id = 3,
                    Name = "Боядисване и декорации",
                    Description = "Професионално боядисване с латекс, акрилни бои, полагане на венециански, пясъчни и други видове луксозни декоративни мазилки.",
                    Price = "€3–5 / м²",
                    IconPath = "bi-paint-bucket"
                },
                new ServiceItem
                {
                    Id = 4,
                    Name = "Ремонт на бани и облицовки",
                    Description = "Лепене на фаянс, теракота, гранитогрес, монтаж на санитария, душ кабини, вградени структури и хидроизолация на мокри помещения.",
                    Price = "€18–28 / м²",
                    IconPath = "bi-droplet-half"
                },
                new ServiceItem
                {
                    Id = 5,
                    Name = "Подови настилки",
                    Description = "Монтаж на ламиниран паркет, трислоен паркет, первази, преходни лайсни и полагане на саморазливни подови замазки.",
                    Price = "€4–7 / м²",
                    IconPath = "bi-grid-3x3-gap-fill"
                },
                new ServiceItem
                {
                    Id = 6,
                    Name = "Електро и ВиК услуги",
                    Description = "Изграждане на нови и ремонт на стари инсталации, монтаж на ключове, контакти, осветителни тела, водомери и смесители.",
                    Price = "по договаряне",
                    IconPath = "bi-lightning-charge"
                }
            };

            return View(services);
        }
    }
}