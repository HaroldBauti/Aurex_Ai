using Aurex.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurex.DataLayer;

namespace Aurex.BusinessLayer
{
    public class BL_Configuration
    {
        public bool SaveConfiguration(Configuration obj)
        {
            return DL_Configuration.Instance.SaveConfiguration(obj);
        }

        public Configuration LoadConfiguration(int IdUser)
        {
            return DL_Configuration.Instance.LoadConfiguration(IdUser);
        }

        public bool UpdateConfiguration(Configuration obj)
        {
            return DL_Configuration.Instance.UpdateConfiguration(obj);
        }
    }
}
