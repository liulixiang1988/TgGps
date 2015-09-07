using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TgGPS.Models;
using TgGPS.ViewModels;

namespace TgGPS.Configs
{
    public static class MapsConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<User, UserViewModel>();
        }

        public static T To<T>(this object source)
        {

            return Mapper.Map<T>(source);
        }

        public static IEnumerable<T> To<T>(this IEnumerable<object> source)
        {
            return Mapper.Map<IEnumerable<T>>(source);
        }
    }
}