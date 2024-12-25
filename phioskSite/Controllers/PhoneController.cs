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
    }
}
