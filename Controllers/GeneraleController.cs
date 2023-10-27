using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class GeneraleController : Controller
    {
        private readonly IGeneralService Service;

        public GeneraleController(IGeneralService Service)
        {
            this.Service = Service;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Generale model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Succesfuly";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error on Server Side";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = Service.FindByID(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Generale model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Service.Update(model);
            if (result)
            {
                TempData["msg"] = "Update Succesfuly";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error on Server Side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {            
            var result = Service.Delete(id);
            return RedirectToAction("GetAll");            
        }

        public IActionResult GetAll()
        {
            var result = Service.GetAll();
            return View(result);
        }
    }
}
