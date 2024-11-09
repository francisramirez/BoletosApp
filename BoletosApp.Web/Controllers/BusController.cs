using BoletosApp.Application.Contracts;
using BoletosApp.Application.Dtos.Configuration.Bus;
using BoletosApp.Persistance.Models.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletosApp.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _busService.GetAll();
            
            if (result.IsSuccess)
            {
                List<BusModel> busModel = (List<BusModel>)result.Data;

                return View(busModel);
            }
            return View();
           
        }

      
        public async Task<IActionResult> Details(int id)
        {
            var result = await _busService.GetById(id);

            if (result.IsSuccess)
            {
                 BusModel busModel = (BusModel)result.Data;

                return View(busModel);
            }
            return View();
        }

      
        public ActionResult Create()
        {
            return View();
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusSaveDto busSave)
        {
            try
            {
                busSave.FechaCambio = DateTime.Now;
                busSave.UsuarioCambio = 1;
                var result = await _busService.SaveAsync(busSave);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
 
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _busService.GetById(id);

            if (result.IsSuccess)
            {
                BusModel busModel = (BusModel)result.Data;

                return View(busModel);
            }

            return View();
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusUpdateDto busUpdate)
        {
            try
            {
                busUpdate.FechaCambio = DateTime.Now;
                busUpdate.UsuarioCambio = 1;
                var result = await _busService.UpdateAsync(busUpdate);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else 
                { 
                    ViewBag.Message = result.Message;
                    return View();
                }
               
            }
            catch
            {
                return View();
            }
        }
 
    }
}
