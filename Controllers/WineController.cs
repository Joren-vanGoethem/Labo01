using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labo01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Labo01.Controllers
{
    [ApiController]
    [Route("wines")]
    public class WineController : ControllerBase
    {
        private readonly ILogger<WineController> Logger;
        private readonly static List<Wine> Wines = new List<Wine>();

        public WineController(ILogger<WineController> logger)
        {
            Logger = logger;
            if(Wines == null || Wines.Count() == 0){
                Wines.Add(new Wine(){
                    WineId = 1,
                    Name = "Sangrato Barolo",
                    Country = "Italie",
                    Price = 35,
                    Color = "red",
                    Year = 2005,
                    Grapes = "Nebiollo"

                });
            }
            Logger.LogInformation("ctor");
        }

        [HttpGet]
        public List<Wine> GetWines(){
            return Wines;
        }

        [HttpPost]
        public Wine AddWine(Wine wine){
            wine.WineId = Wines.Count + 1;
            Wines.Add(wine);
            return wine;
        }

        [HttpDelete]
        public ActionResult RemoveWine(Wine wine){
            Wine Wine = Wines.Find(delegate(Wine w){
                return w.WineId == wine.WineId;
            });
            if(Wine != null){
                Wines.Remove(Wine);
                return new OkObjectResult(wine);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpDelete]
        [Route("{wineId}")]
        public ActionResult RemoveWine(int wineId){
            Wine Wine = Wines.Find(delegate(Wine w){
                return w.WineId == wineId;
            });
            if(Wine != null){
                Wines.Remove(Wine);
                return new OkObjectResult(Wine);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpPut]
        public ActionResult UpdateWine(Wine wine){
            Wine Wine = Wines.Find(delegate(Wine w){
                return w.WineId == wine.WineId;
            });
            if(Wine != null){
                Wine.Name = wine.Name;
                return new OkObjectResult(wine);
            }else{
                return new StatusCodeResult(404);
            }
        }
    }
}
