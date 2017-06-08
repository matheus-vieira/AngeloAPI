using AngeloAPI.Models;
using System.Net.Http;
using System.Net;
using System.Web.Mvc;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngeloAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var result = new Manutencao();
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("http://angeloportifolio.pe.hu/");

                var ret = await client.GetAsync("JSON3.json");

                if (ret.IsSuccessStatusCode)
                {
                    var str = ret.Content
                        .ReadAsStringAsync()
                        .Result;

                    result = JsonConvert
                    .DeserializeObject<Manutencao>(str);
                }
            }
            return View(result);
        }
    }
}