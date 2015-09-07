using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TgGPS.ViewModels
{
    public class UserViewModel
    {
        #region 实体属性
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

        #endregion
    }
}