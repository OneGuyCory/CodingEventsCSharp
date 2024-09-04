using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {

            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();

            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if(ModelState.IsValid)
            {
                EventCategory category = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name,
                };

                context.Categories.Add(category);
                context.SaveChanges();

                return Redirect("/EventCategory");

            }

            return View("create", addEventCategoryViewModel);
        }

    }
}
