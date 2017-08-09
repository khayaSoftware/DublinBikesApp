using DublinBikesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace DublinBikesApp.Controllers
{
    public class BikesController : ApiController
    {
        static JavaScriptSerializer js = new JavaScriptSerializer();
        Bike[] bikes = js.Deserialize<Bike[]>(GetBikes());
        private static string GetBikes()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://api.jcdecaux.com/vls/v1/stations?contract=dublin&apiKey=e2c9f4b649a49922216ee8d8893988bc2659713b");
                return json;
            }
        }

        public IEnumerable<Bike> GetAllBikes()
        {
            return bikes;
        }

        public IHttpActionResult GetBike(int id)
        {
            var bike = bikes.FirstOrDefault((b) => b.number == id);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }
    }




}
