using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace TgGPS.Models
{
    public class Gps
    {
        #region 属性
        public long? Id { get; set; }

        public string UserId { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public DateTime LocationTime { get; set; }

        public string Accuracy { get; set; }

        public string Altitude { get; set; }

        public string Speed { get; set; } 
        #endregion

        public static int Add(Gps gps)
        {
            using (var con = DbUtil.GetConnection())
            {
                const string sql = @"INSERT INTO 
tbGps(UserId, Latitude, Longitude, LocationTime, Accuracy, Altitude, Speed)
values(@UserId, @Latitude, @Longitude, @LocationTime, @Accuracy, @Altitude, @Speed)";
                return con.Execute(sql, gps);
            }
        }
    }
}