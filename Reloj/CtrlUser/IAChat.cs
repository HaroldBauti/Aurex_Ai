using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurex.CtrlUser
{
    public partial class IAChat : UserControl
    {
        public PictureBox img=new PictureBox();
        public Label label=new Label();
        public Label labelTitle=new Label();
        public IAChat()
        {
            InitializeComponent();
        }

        private void IAChat_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = img.Image;
            label1.Text=labelTitle.Text;
            label2.Text = label.Text;
            label2.Size = label.Size;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
