using IWatchApp.Data;
using IWatchApp.Models;
using IWatchApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IWatchApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IWatchDbContext iwatchDbContext;

        public ItemController(IWatchDbContext iwatchDbContext)
        {
            this.iwatchDbContext = iwatchDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddItemViewModel addItemRequest)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Type = addItemRequest.Type,
                URL = addItemRequest.URL,
                Price = addItemRequest.Price,
                DateofStart = addItemRequest.DateofStart,
                DateofEnd = addItemRequest.DateofEnd
            };

            iwatchDbContext.Items.Add(item);
            iwatchDbContext.SaveChanges();
            return RedirectToAction("Add");

        }


    }
}
