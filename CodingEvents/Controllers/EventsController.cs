using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type,
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            }
           return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds) 
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        public IActionResult Edit(int eventId)
        {
            Event eventToEdit = EventData.GetById(eventId);
            ViewBag.eventToEdit = eventToEdit;
            ViewBag.title = "Edit Event" + eventToEdit.Name + "(id = " + eventToEdit.Id + ")";

            return View();

        }

        [HttpPost]
        [Route("/Events/Edit{eventId}")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event eventToEdit = EventData.GetById(eventId);
            eventToEdit.Name = name;
            eventToEdit.Description = description;

           return Redirect("/Events");
        }
    }
}
