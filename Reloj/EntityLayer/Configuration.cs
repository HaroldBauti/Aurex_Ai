using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.EntityLayer
{
    public class Configuration
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PortBt { get; set; }
        public string AssistantName { get; set; }
        public string LowBattery { get; set; }
        public string VoiceAssistant { get; set; }
    }
}
