using Nancy;
using Nancy.Authentication.Token;
using TgGPS.Models;

namespace TgGPS.Modules
{
    public class AuthModule : BaseModule
    {
        public AuthModule(ITokenizer tokenizer)
        {
            Get["/login"] = parameters =>
            {
                return View["login"];
            };

            Post["/login"] = x =>
            {
                var username = (string)this.Request.Form.UserName;
                var password = (string)this.Request.Form.Password;

                var userIdentity = User.ValidateUser(username, password);

                if (userIdentity == null)
                    return HttpStatusCode.Unauthorized;

                var user = User.GetUser(username);
                User.RecordUserLoginTime(user);

                var token = tokenizer.Tokenize(userIdentity, Context);

                var resultInfo = new
                {
                    token,
                    userinfo = new
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        Email = user.Email,
                        LastLogin = user.LastLogin
                    }
                };
                //return Negotiate.WithModel(resultInfo).WithMediaRangeModel("application/json", resultInfo);
                return resultInfo;
            };

            Get["/userinfo/{user_id}"] = _ =>
            {
                var user = User.GetUser(_.user_id);

                return
                    new
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        Email = user.Email,
                        LastLogin = user.LastLogin
                    };
            };
        }
    }
}