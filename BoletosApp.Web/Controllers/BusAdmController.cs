using BoletosApp.Application.Dtos.Configuration.Bus;
using BoletosApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BoletosApp.Web.Controllers
{
    public class BusAdmController : Controller
    {
        // GET: BusAdmController
        public async Task<IActionResult> Index()
        {

            string url = "http://localhost:5000/api/";

            BusGetAllResultModel busGetAllResultModel = new BusGetAllResultModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync("Bus/GetBuses");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    busGetAllResultModel = JsonConvert.DeserializeObject<BusGetAllResultModel>(response);

                }
                else
                {
                    ViewBag.Message = "";
                }
            }



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


                    var responseTask = await client<BusSaveDto>("Bus/SaveBus", busSave);

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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
