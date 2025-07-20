using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.EntityLayer
{
    public class Command
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Type { get; set; }
        public string Comand { get; set; }
        public string Path { get; set; }
        public string Answer { get; set; }
    }
}
