using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Services.Interfaces;
using PhioskSite.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

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
                UserOrdersVM userOrdersVM = new UserOrdersVM();
                userOrdersVM.Users = new SelectList(
                    await _userService.GetAllAsync(),
                    "Id",
                    "Mail"
                );
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
            if (entity.Id == null)
            {
                return NotFound();
            }
            try
            {
                var orderLst = await _orderDBService.GetOrdersByUser
                    (Convert.ToInt16(entity.Id));
                List<OrderVM> listVM = _mapper.Map<List<OrderVM>>(orderLst);

                Thread.Sleep(2000);
                return PartialView("PartialViews/_SearchOrdersPartial", listVM);
            }
            catch
            {

            }
            return View(entity);
        }
        public async Task<IActionResult> _SearchOrdersPartial()
        {
            try
            {

                var lstOrders = await _orderDBService.GetAllAsync();
                List<OrderVM> orderVMs = null;

                if (lstOrders != null)
                {
                    orderVMs = _mapper.Map<List<OrderVM>>(lstOrders);
                    return View(orderVMs);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden");
            }
            return View();
        }
        


       

    }
}
