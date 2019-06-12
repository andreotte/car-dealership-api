using CarDealershipAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipAPI.Controllers
{
    public class ValuesController : ApiController
    {
        CarDealershhipDbEntities db = new CarDealershhipDbEntities();

        // GET api/values
        public List<Car> Get()
        {
            List<Car> cars = db.Cars.ToList();
            return cars;
        }

        //GET api/values/5
        public List<Car> Get(string property, string value)
        {
            List<Car> cars = new List<Car>();
            switch (property.ToLower())
            {
                case "make":
                    cars = db.Cars.Where(c => c.Make.ToLower() == value.ToLower()).ToList();
                    break;
                case "model":
                    cars = db.Cars.Where(c => c.Model.ToLower() == value.ToLower()).ToList();
                    break;
                case "color":
                    cars = db.Cars.Where(c => c.Color.ToLower() == value.ToLower()).ToList();
                    break;
                case "year":
                    int valueInt = int.Parse(value);
                    cars = db.Cars.Where(c => c.Year == valueInt).ToList();
                    break;
            }

            return cars;
        }

        // POST api/values
        public void Post(string make, string model, int year, string color)
        {
            Car car = new Car();
            car.Make = make;
            car.Model = model;
            car.Year = year;
            car.Color = color;

            db.Cars.AddOrUpdate(car);
            db.SaveChanges();
        }

        // PUT api/values/5
        public string Put(int id, string property, string value)
        {
            Car car = db.Cars.Find(id);

            if(car == null)
            {
                return $"That doesn't exist";
            }
            switch (property.ToLower())
            {
                case "make":
                    car.Make = value;
                    break;
                case "model":
                    car.Model = value;
                    break;
                case "color":
                    car.Color = value;
                    break;
                case "year":
                    car.Year = int.Parse(value);
                    break;
            }

            db.Cars.AddOrUpdate(car);
            db.SaveChanges();

            return $"No car at id: {id}";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            Car car = db.Cars.Find(id);
            
            if(car == null)
            {
                return "No car at that id";
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return $"Deleted car at id: {id}";

        }
    }
}
