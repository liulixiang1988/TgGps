using Nancy;
using TgGPS.Models;

namespace TgGPS.Modules
{
    public class BaseModule : NancyModule
    {
        public User CurrentUser
        {
            get
            {
                if (Context.CurrentUser == null) return null;
                var userName = Context.CurrentUser.UserName;
                return string.IsNullOrWhiteSpace(userName) ? null : User.GetUser(userName);
            }
        }

        public BaseModule(string modulePath) : base(modulePath) { }

        public BaseModule()
        {
            
        }
    }
}