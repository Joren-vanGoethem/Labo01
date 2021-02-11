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
    [Route("[controller]")]
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
    }
}
