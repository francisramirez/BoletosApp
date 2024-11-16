using BoletosApp.Application.Contracts;
using BoletosApp.Application.Dtos.Configuration.Ruta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletosApp.Web.Controllers
{
    public class RutaController : Controller
    {
        private readonly IRutaService rutaService;

      
        public RutaController(IRutaService rutaService)
        {
            this.rutaService = rutaService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.rutaService.GetAll();

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            List<GetRutaDto> rutas = (List<GetRutaDto>)result.Model;
            return View(rutas);


        }

       
        public async Task<IActionResult> Details(int id)
        {
            var result = await this.rutaService.GetById(id);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            GetRutaDto ruta = (GetRutaDto)result.Model;
            return View(ruta);
        }

     
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RutaSaveDto rutaSaveDto)
        {
            try
            {
                rutaSaveDto.UsuarioCambio = 1;
                rutaSaveDto.FechaCambio = DateTime.Now;
                var result = await this.rutaService.SaveAsync(rutaSaveDto);

                if (!result.IsSuccess)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var result = await this.rutaService.GetById(id);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            GetRutaDto ruta = (GetRutaDto)result.Model;
            return View(ruta);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RutaUpdateDto rutaUpdateDto)
        {
            try
            {
                rutaUpdateDto.UsuarioCambio = 1;
                rutaUpdateDto.FechaCambio = DateTime.Now;
                var result = await this.rutaService.UpdateAsync(rutaUpdateDto);

                if (!result.IsSuccess) 
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
