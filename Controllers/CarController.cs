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
    [Route("cars")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> Logger;
        private readonly static List<CarModel> Cars = new List<CarModel>();
        private readonly static List<Brand> Brands = new List<Brand>();

        public CarController(ILogger<CarController> logger)
        {
            Logger = logger;
            Logger.LogInformation("ctor");
        }

        [HttpGet] // brands ophalen
        [Route("brands")]
        public List<Brand> Getbrands(){
            return Brands;
        }

        [HttpGet] // 1 brand ophalen
        [Route("brands/{name}")]
        public ActionResult Getbrand(string name){
            Brand Brand = Brands.Find(delegate(Brand b){
                return b.Name == name;
            });
            if(Brand != null){
                return new OkObjectResult(Brand);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpGet]
        [Route("brands/{country}")]
        public ActionResult GetBrandByCountry(string country){
            List<Brand> Brands = new List<Brand>();
            foreach(Brand B in CarController.Brands){
                if(B.Country == country) Brands.Add(B);
            }
            if(Brands != null){
                return new OkObjectResult(Brands);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpPost]
        [Route("brands")]
        public ActionResult AddBrands(List<Brand> brands){
            foreach(Brand B in brands){
                if(!Brands.Contains(B)){
                    Brands.Add(B);
                }
            }
            if(Brands != null){
                return new OkObjectResult(Brands);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpGet] // Car Models ophalen
        public ActionResult GetCars(){
            return new OkObjectResult(Cars);
        }

        [HttpGet] // Car Models van een brand ophalen
        [Route("{brand}")]
        public ActionResult GetCars(string brand){
            List<CarModel> Cars = new List<CarModel>(); 
            foreach(CarModel C in CarController.Cars){
                if(C.Brand.Name == brand){
                    Cars.Add(C);
                }
            }
            if(Cars != null){
                return new OkObjectResult(Cars);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpGet] // Car Models van een brand ophalen
        [Route("{name}")]
        public ActionResult GetCar(string name){
            CarModel Car = Cars.Find(delegate(CarModel c){
                return c.Name == name;
            });
            if(Car != null){
                return new OkObjectResult(Car);
            }else{
                return new StatusCodeResult(404);
            }
        }

        [HttpPost]
        public ActionResult AddCars(List<CarModel> cars){
            foreach(CarModel C in cars){
                if(!Cars.Contains(C)){
                    Cars.Add(C);
                }
            }
            if(Cars != null){
                return new OkObjectResult(Cars);
            }else{
                return new StatusCodeResult(404);
            }
        }

        // [HttpDelete]
        // [Route("/{wineId}")]
        // public ActionResult RemoveWine(int wineId){
        //     Wine Wine = Wines.Find(delegate(Wine w){
        //         return w.WineId == wineId;
        //     });
        //     if(Wine != null){
        //         Wines.Remove(Wine);
        //         return new OkObjectResult(Wine);
        //     }else{
        //         return new StatusCodeResult(404);
        //     }
        // }

        // [HttpPut]
        // public ActionResult UpdateWine(Wine wine){
        //     Wine Wine = Wines.Find(delegate(Wine w){
        //         return w.WineId == wine.WineId;
        //     });
        //     if(Wine != null){
        //         Wine.Name = wine.Name;
        //         return new OkObjectResult(wine);
        //     }else{
        //         return new StatusCodeResult(404);
        //     }
        // }
    }
}
