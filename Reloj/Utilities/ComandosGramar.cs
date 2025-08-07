using Aurex.BusinessLayer;
using Aurex.EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.Utilities
{
    public class ComandosGramar
    {
        public List<Command> listCommands;

        BL_Commands c = new BL_Commands();
        public void LoadCommandGramar(int idU)
        {
            listCommands = new BL_Commands().LoadCommand(idU);
            try
            {
                if (listCommands.Count == 0)
                {
                    Command ci = new Command();
                    ci.IdUser = idU.ToString();
                    ci.Type = "Aplicaciones";
                    ci.Comand = "Abrir word";
                    ci.Path = "WINWORD.exe";
                    ci.Answer = "Abriendo word";
                    c.SaveCommand(ci);
                }
                

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }
    }
}
