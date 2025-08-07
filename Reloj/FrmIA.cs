using Aurex.BusinessLayer;
using Aurex.CtrlUser;
using Aurex.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Aurex.Utilities.Response;
using static Aurex.Utilities.ResponseImg;

namespace Aurex
{
    public partial class FrmIA : Form
    {
        AUREX_AI _AI;
        public FrmIA()
        {
            InitializeComponent();
            _AI = new AUREX_AI();
        }
        #region Methods
        async Task ConsultarText(string question)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string respuestaModelo = await _AI.Consultar(question);

                DrawMessage(false, respuestaModelo);
            }
            finally
            {
                Cursor = Cursors.Default; // Siempre vuelve al cursor normal, incluso si hay error
            }
        }

        void DrawMessage(bool to,string message)
        {
            Panel panelContainer=new Panel();
            panelContainer.AutoSize = true;
            IAChat chat=new IAChat();
            chat.img.Image = to ? Properties.Resources.Aurex_ai : Properties.Resources.Aurex_ai;
            chat.label.Text = message;
            chat.label.AutoSize = true;
            chat.labelTitle.Text = !to?"Aurex AI":"Tú";
            panelContainer.Controls.Add(chat);
            flowLayoutPanel1.Controls.Add(panelContainer);
        }
        #endregion
        private async void iconButton1_Click(object sender, EventArgs e)
        {
            string query = textBox1.Text;
            DrawMessage(true,query);
            await ConsultarText(query);
        }


        private async void txtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                await ConsultarText(textBox1.Text);
                textBox1.Text = string.Empty;
            }
        }


        private void FrmIA_Load(object sender, EventArgs e)
        {

        }
    }
}
