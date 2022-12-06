using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DataAccess;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    // TODO
    // 1 - Add Check Box for Is Done
    // 2 - Add logic to save Is Done
    // 3 - Add logic to update/Edit Is Done
    // 4 - Add logic to update Completed/DateTime if Is Done is True
    public class TodoController : Controller
    {
        private readonly IItemRepository itemRepository;
        public TodoController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }


        // GET: TodoController
        public ActionResult Index()
        {   
            return View(this.itemRepository.GetAllItems());
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoController1/Create
        [Route("/item/create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [Route("/item/create")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var description = collection["Description"];
                if (String.IsNullOrEmpty(description))
                    return BadRequest("Description is not valid");

                var item = Item.Create(description);
                this.itemRepository.AddItem(item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController1/Edit/5
        [Route("/item/edit")]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var item = this.itemRepository.GetById(id);
            return View(item);
        }

        // POST: TodoController1/Edit/5
        [HttpPost]
        [Route("/item/edit")]
        // [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var item = this.itemRepository.GetById(id);
                var description = collection["Description"];

                item.Description = description;
                this.itemRepository.UpdateItem(item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
