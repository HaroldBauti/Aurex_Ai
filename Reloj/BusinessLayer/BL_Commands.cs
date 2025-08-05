using Aurex.DataLayer;
using Aurex.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.BusinessLayer
{
    public class BL_Commands
    {
        public bool SaveCommand(Command obj)
        {
            return new DL_Command().SaveCommand(obj);
        }

        public List<Command> LoadCommand(int IdUser)
        {
            return new DL_Command().LoadCommand(IdUser);
        }

        public bool UpdateCommand(Command obj)
        {
            return new DL_Command().UpdateCommand(obj);
        }

        public bool DeleteCommand(int obj)
        {
            return new DL_Command().DeleteCommand(obj);
        }
    }
}
