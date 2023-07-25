using IWatchApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IWatchApp.Controllers
{
    public class ItemController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddItemViewModel addItemRequest)
        {

        }


    }
}
