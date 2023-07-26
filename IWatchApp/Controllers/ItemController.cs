using IWatchApp.Data;
using IWatchApp.Models;
using IWatchApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var items = await iwatchDbContext.Items.ToListAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel addItemRequest)
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

           await iwatchDbContext.Items.AddAsync(item);
           await iwatchDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }


    }
}
