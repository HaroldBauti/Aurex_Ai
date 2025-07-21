using Aurex.EntityLayer;
using Aurex.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurex
{
    public partial class FrmEmail : Form
    {

        User user;
        Configuration conf;
        public FrmEmail(User _user, Configuration _conf)
        {
            InitializeComponent();
            user = _user;
            conf = _conf;
        }
    }
}
