using CarDealershipAPI.Models;
using System;
using System.Collections.Generic;
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
