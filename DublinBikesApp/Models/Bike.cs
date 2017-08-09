using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinBikesApp.Models
{
    public class Bike
    {
        public int number { get; set; }
        public String status { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
    }
}