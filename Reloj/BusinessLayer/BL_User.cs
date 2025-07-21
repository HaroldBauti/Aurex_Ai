using System;
using System.Collections.Generic;
using Aurex.DataLayer;
using Aurex.EntityLayer;

namespace Aurex.BusinessLayer
{
    public class BL_User
    {
        public bool SaveUser(User obj, out long last)
        {
            return DL_User.Instance.SaveUser(obj, out last);
        }

        public List<User> LoadUser()
        {
            return DL_User.Instance.LoadUser();
        }

        public bool UpdateUser(User obj)
        {
            return DL_User.Instance.UpdateUser(obj);
        }
    }
}
