using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;
using Nancy.Security;
using TgGPS.Models;

namespace TgGPS.Modules
{
    public class GpsModule: BaseModule
    {
        public GpsModule() : base("/gps")
        {
            //this.RequiresAuthentication();

            Post["/add"] = x =>
            {
                var gps = this.Bind<Gps>("id");
                var result = Gps.Add(gps);
                return new {result, gps};
            };
        }
    }
}