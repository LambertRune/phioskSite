using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Services.Interfaces;
using PhioskSite.ViewModels;

namespace PhioskSite.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IMapper _mapper;       
        private readonly IDBService<Phone> _phoneDBService;

        public PhoneController(IDBService<Phone> phoneDBService,IMapper mapper)
        {
            _phoneDBService = phoneDBService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var lstPhones = await _phoneDBService.GetAllAsync();
                List<PhoneVM> phoneVMs = null;

                if (lstPhones != null)
                {
                    phoneVMs = _mapper.Map<List<PhoneVM>>(lstPhones);
                    return View(phoneVMs);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "er is een fout opgetreden");
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var phone = await _phoneDBService.FindByIdAsync(id);

                if (phone == null)
                {
                    return NotFound();
                }

                // Map the Phone entity to PhoneVM
                var phoneVM = _mapper.Map<PhoneVM>(phone);

                return View(phoneVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de gegevens.");
                return RedirectToAction("Index"); // Redirect to Index if there's an error
            }
        }

    }
}
