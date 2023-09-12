using IWatchApp.Data;
using IWatchApp.Models;
using IWatchApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Linq;
using System.Threading.Tasks;


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
        public async Task<IActionResult> Index(string SearchString)
        {
            //var items = await iwatchDbContext.Items.ToListAsync();
            ViewData["CurrentFilter"] = SearchString;
            var items = from item in iwatchDbContext.Items select item;
            if (!String.IsNullOrEmpty(SearchString))
            {
                items=items.Where(item=> item.Type.Contains(SearchString));
            }
           
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

        [HttpGet]

        public async Task<IActionResult> View(Guid id)
        {
           var item = await iwatchDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
        
            if(item != null)
            {
                var viewModel = new UpdateItemViewModel()
                {
                    Id = item.Id,
                    Type = item.Type,
                    URL = item.URL,
                    Price = item.Price,
                    DateofStart = item.DateofStart,
                    DateofEnd = item.DateofEnd

                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateItemViewModel model)
        {
            var item = await iwatchDbContext.Items.FindAsync(model.Id);

            if (item != null)
            {
                item.Type= model.Type;
                item.URL = model.URL; 
                item.Price= model.Price;
                item.DateofStart= model.DateofStart;
                item.DateofEnd= model.DateofEnd;

                await iwatchDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
                  return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateItemViewModel model)
        {
            var item = await iwatchDbContext.Items.FindAsync(model.Id);

            if(item != null)
            {
                iwatchDbContext.Items.Remove(item);
                await iwatchDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> AddURLlink(AddURL addURlrequest)
        {
            var videotypes = new VideoTypes()
            {
                Id = Guid.NewGuid(),
                TypeId=addURlrequest.TypeId,
                TypeURLs = addURlrequest.TypeURLs


            };
            await iwatchDbContext.Videos.AddAsync(videotypes);
            await iwatchDbContext.SaveChangesAsync();
            return RedirectToAction("URLList");
        }
            
           
    }
}
