using BoletosApp.Application.Dtos.Configuration.Bus;
using BoletosApp.Web.Models;
using BoletosApp.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BoletosApp.Web.Controllers
{
    public class BusAdmController : Controller
    {
        private readonly IBusApiClientService _busApiClientService;
        private readonly ISecurityApiService _securityApiService;

        public BusAdmController(IBusApiClientService busApiClientService, ISecurityApiService securityApiService)
        {
            _busApiClientService = busApiClientService;
            _securityApiService = securityApiService;
        }

        // GET: BusAdmController
        public async Task<IActionResult> Index()
        {
            var datos = await _securityApiService.GetToken(new Models.Security.LoginModel()
            {
                Password = "Jperez@2024",
                UserName = "jperez"
            });

            BusGetAllResultModel busGetAllResultModel = await _busApiClientService.GetBuses(datos.token);

            return View(busGetAllResultModel.data);
        }

        // GET: BusAdmController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5000/api/";

            BusGetByIdModel busGetByIdModel = new BusGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"Bus/GetBusById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    busGetByIdModel = JsonConvert.DeserializeObject<BusGetByIdModel>(response);

                }
            }


            return View(busGetByIdModel.Data);
        }

        // GET: BusAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusSaveDto busSave)
        {
            BaseApiResponseModel model = new BaseApiResponseModel();

            try
            {
                string url = "http://localhost:5000/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);


                    var responseTask = await client.PostAsJsonAsync<BusSaveDto>("Bus/SaveBus", busSave);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        model = JsonConvert.DeserializeObject<BaseApiResponseModel>(response);


                        if (!model.isSuccess)
                        {
                            ViewBag.Message = model.message;
                            return View();

                        }
                        else
                        {

                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<BaseApiResponseModel>(response);

                        ViewBag.Message = model.message;
                        return View();
                    }


                }

            }
            catch
            {
                return View();
            }
        }

        // GET: BusAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string url = "http://localhost:5000/api/";

            BusGetByIdModel busGetByIdModel = new BusGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"Bus/GetBusById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    busGetByIdModel = JsonConvert.DeserializeObject<BusGetByIdModel>(response);

                }
            }


            return View(busGetByIdModel.Data);
        }

        // POST: BusAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusUpdateDto busUpdateDto)
        {
            BaseApiResponseModel model = new BaseApiResponseModel();

            try
            {
                string url = "http://localhost:5000/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);


                    var responseTask = await client.PutAsJsonAsync<BusUpdateDto>("Bus/UpdateBus", busUpdateDto);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        model = JsonConvert.DeserializeObject<BaseApiResponseModel>(response);


                        if (!model.isSuccess)
                        {
                            ViewBag.Message = model.message;
                            return View();

                        }
                        else
                        {

                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<BaseApiResponseModel>(response);

                        ViewBag.Message = model.message;
                        return View();
                    }


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
