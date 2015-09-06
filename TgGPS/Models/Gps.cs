using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TgGPS.Models
{
    public class Gps
    {
        public long? Id { get; set; }

        public string UserId { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public DateTime LocationTime { get; set; }

        public string Accuracy { get; set; }

        public string Altitude { get; set; }

        public string Speed { get; set; }
    }
}