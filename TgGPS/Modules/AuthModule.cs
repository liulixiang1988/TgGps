using Nancy;
using Nancy.Authentication.Token;
using Nancy.ModelBinding;
using TgGPS.Configs;
using TgGPS.Models;
using TgGPS.Util;
using TgGPS.ViewModels;

namespace TgGPS.Modules
{
    public class AuthModule : BaseModule
    {
        public AuthModule(ITokenizer tokenizer)
        {
            Get["/login"] = parameters => View["login"];

            Post["/login"] = x =>
            {
                var username = (string)Request.Form.UserName;
                var password = (string)Request.Form.Password;

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
                        user.UserId,
                        user.UserName,
                        user.Email,
                        user.LastLogin
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
                        user.UserId,
                        user.UserName,
                        user.Email,
                        user.LastLogin
                    };
            };

            Post["/register"] = _ =>
            {
                var user = this.Bind<User>("Id", "LastLogin");
                if (User.Exists(user))
                {
                    return new {result = 0, msg = "当前用户已经存在"};
                }
                user.Password = CryptoHelper.GetMd5Hash(user.Password);
                var result = User.AddUser(user);
                return new {result, user=user.To<UserViewModel>()};
            };
        }
    }
}