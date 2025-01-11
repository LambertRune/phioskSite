using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Services;
using PhioskSite.Services.Interfaces;
using PhioskSite.ViewModels;

namespace PhioskSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly OrderDBService _orderDBService;
        private readonly IDBService<Order> _OrderService;

        public OrderController(OrderDBService orderDBService, IMapper mapper, IDBService<Order> orderService)
        {
            _orderDBService = orderDBService;
            _mapper = mapper;
            _OrderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                UserOrdersVM userOrdesrVM = new UserOrdersVM();

                userOrdesrVM.Orders = new SelectList(
                    await ,
                    //"Browernr" komt van domain>entities>Brewery
                    "Brouwernr",
                    "Naam"
                );
                return View(userOrdesrVM);
            }
            catch
            {
                ViewBag.ErrorMessage = "Er is een fout opgetreden bij het ophalen va de lijst ";
                return View("error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetOrders(UserOrdersVM entity)
        {
            if (entity.Id == null)
            {
                return NotFound();
            }
            try
            {
                var beerLst = await _OrderService.get
                    (Convert.ToInt16(entity.BreweryNumber));
                List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(beerLst);

                Thread.Sleep(2000); //wacht 2 sec maar moet niet.
                return PartialView("_SearchBierenPartial", listVM);
            }
            catch
            {

            }
            return View(entity);
        }
    }
}
