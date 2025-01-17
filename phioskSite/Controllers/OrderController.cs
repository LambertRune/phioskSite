using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Services.Interfaces;
using PhioskSite.ViewModels;

namespace PhioskSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderDBService _orderDBService;
        private readonly IDBService<User> _userService;

        public OrderController(IOrderDBService orderDBService, IMapper mapper, IDBService<User> userService)
        {
            _orderDBService = orderDBService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                var userOrdersVM = new UserOrdersVM
                {
                    Orders = new SelectList(users, "Brouwernr", "Naam")
                };
                return View(userOrdersVM);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Er is een fout opgetreden bij het ophalen van de lijst: {ex.Message}";
                return View("error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserOrdersVM entity)
        {
            try
            {
                

                var userId = entity.Id;
                    // Retourneer een foutmelding als de ID niet geldig is
                    ModelState.AddModelError("", "Ongeldige gebruikers-ID.");
                    return View(entity);
                

                // Haal orders op voor de opgegeven gebruiker
                var orderList = await _orderDBService.GetOrdersByUser(userId);

                // Map de orders naar de ViewModel
                var orderVMList = _mapper.Map<List<OrderVM>>(orderList);

                // Retourneer de partial view met de resultaten
                return PartialView("_SearchOrdersPartial", orderVMList);
            }
            catch (Exception ex)
            {
                // Log de fout en toon een foutpagina
                ViewBag.ErrorMessage = $"Er is een fout opgetreden: {ex.Message}";
                return View("error");
            }
        }

    }
}
