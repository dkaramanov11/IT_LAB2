using IT_LAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace IT_LAB2.Controllers
{
    public class EventController : Controller
    { 
       
        private static List<Event> events = new List<Event>()
       
        {
            new Event(){Id = 1, Ime = "Питијада", Lokacija="Велес"},
            new Event(){Id = 2, Ime = "Питијада", Lokacija="Штип"},
            new Event(){Id = 3, Ime = "Спортски игри", Lokacija="Велес"}
        };

        int index = 4;
        // GET: Event
        public ActionResult Index()
        {
            return View(events);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event model)
        {
            if (ModelState.IsValid) {
                model.Id = index++;
                events.Add(model);
                return RedirectToAction("Details", new {id = model.Id});
            }   
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var eventObj = events.FirstOrDefault(e => e.Id == id);
            return View(eventObj);
        }


        public ActionResult Edit(int id) {
            var eventObj = events.FirstOrDefault(e => e.Id == id);
            return View(eventObj);
        }

        [HttpPost]
        public ActionResult Edit(Event model)
        {
            if (ModelState.IsValid) {

                var eventObj = events.FirstOrDefault(e => e.Id == model.Id);

                if (eventObj != null)
                {
                    eventObj.Ime = model.Ime;
                    eventObj.Lokacija = model.Lokacija;
                }
                return RedirectToAction("Index");

            }
            return View(model);

        }


        public ActionResult Delete(int id) {
            var eventObj = events.FirstOrDefault(e => e.Id == id);
            events.Remove(eventObj);
            return RedirectToAction("Index");
        }
    }
}