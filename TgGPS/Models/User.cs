﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using TgGPS.Auth;

namespace TgGPS.Models
{
    public class User
    {
        #region 实体属性

        /// <summary>
        ///     id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Org Code
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        ///     user_id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     user_name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     is_active
        /// </summary>
        public byte? IsActive { get; set; }

        /// <summary>
        ///     is_superuser
        /// </summary>
        public byte? IsSuperuser { get; set; }

        /// <summary>
        ///     is_stuff
        /// </summary>
        public byte? IsStuff { get; set; }

        /// <summary>
        ///     email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     last_login
        /// </summary>
        public DateTime? LastLogin { get; set; }

        #endregion

        public static IEnumerable<User> GetAllUsers()
        {
            using (var con = DbUtil.GetConnection())
            {
                return con.Query<User>("select * from tbUser");
            }
        }


        public static User GetUser(string userId)
        {
            using (var con = DbUtil.GetConnection())
            {
                return
                    con.Query<User>("select * from tbUser where UserId=@UserId", new { UserId = userId })
                        .FirstOrDefault();
            }
        }

        public static UserIdentity ValidateUser(string userId, string password)
        {
            using (var con = DbUtil.GetConnection())
            {
                User user = con.Query<User>(
                    "select * from tbUser where UserId = @UserId and password = @password and IsActive=1",
                    new { UserId = userId, password }).FirstOrDefault();
                if (user == null) return null;

                var claims = new List<string>
                {
                    user.IsStuff == 1 ? "stuff" : "non_stuff",
                    user.IsSuperuser == 1 ? "superuser" : "nonsuperuser"
                };
                return new UserIdentity {UserName = user.UserId, Claims = claims};
            }
        }

        public static bool RecordUserLoginTime(User user)
        {
            using (var con = DbUtil.GetConnection())
            {
                return con.Execute("update tbUser set LastLogin=getdate() where UserId=@UserId",
                    new { UserId = user.UserId }) > 0;
            }
        }
    }
}