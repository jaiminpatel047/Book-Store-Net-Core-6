using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService BService;
        private readonly IGeneralService GService;
        private readonly IAuthorServices AServices; 
        private readonly IPublisherService PService;

        public BookController(IGeneralService GService, IBookService BService, IAuthorServices AServices, IPublisherService PService)
        {
            this.BService = BService;
            this.GService = GService;
            this.AServices = AServices;
            this.PService = PService;
        }
        public IActionResult Add()
        {
            var model = new Book();
            model.AuthoreList = AServices.GetAll().Select(a =>  new SelectListItem { Text = a.AuthorName,Value = a.ID.ToString()}).ToList();
            model.PublisherList = PService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString() }).ToList();
            model.GeneralList = GService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString() }).ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthoreList = AServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.ID.ToString(), Selected=a.ID==model.AuthoreId }).ToList();
            model.PublisherList = PService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString(), Selected = p.ID == model.PublisherId }).ToList();
            model.GeneralList = GService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString(), Selected = g.ID == model.GenreId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = BService.Add(model);
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
            var model = BService.FindByID(id);
            model.AuthoreList = AServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.ID.ToString(), Selected = a.ID == model.AuthoreId }).ToList();
            model.PublisherList = PService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString(), Selected = p.ID == model.PublisherId }).ToList();
            model.GeneralList = GService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString(), Selected = g.ID == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthoreList = AServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.ID.ToString(), Selected = a.ID == model.AuthoreId }).ToList();
            model.PublisherList = PService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString(), Selected = p.ID == model.PublisherId }).ToList();
            model.GeneralList = GService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString(), Selected = g.ID == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = BService.Update(model);
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
            var result = BService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var result = BService.GetAll();
            return View(result);
        }
    }
}
