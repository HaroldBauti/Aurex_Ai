using Aurex.BusinessLayer;
using Aurex.EntityLayer;
using Aurex.Utilities;
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
    public partial class FrmCommands : Form
    {
        #region Variables
        int idUser;
        List<Command> list;
        string type;
        int i;
        #endregion

        public FrmCommands(int idU)
        {
            InitializeComponent();
            idUser=idU;
        }

        #region metodos

        bool Update(Command _user)
        {
            bool c = new BL_Commands().UpdateCommand(_user);

            LoadCommandsType();
            return c;
        }
      
        void TextEmail()
        {
            richTextBox1.Visible = false;
            dgvprincipal.Columns[5].HeaderText = "Correo";
            dgvprincipal.Columns[4].HeaderText = "Nombre";

            label2.Text = "NOMBRE";
            label3.Text = "CORREO";
            btnActualizar.Enabled = true;
            btnAgregarComando.Enabled = true;
            btnBorrar.Enabled = true;
        }

        void TextCommands()
        {
            richTextBox1.Visible = false;
            dgvprincipal.Columns[5].HeaderText = "Respuestas";
            dgvprincipal.Columns[4].HeaderText = "Ruta";
            btnActualizar.Enabled = true;
            btnAgregarComando.Enabled = true;
            btnBorrar.Enabled = true;
            label2.Text = "RUTA";
            label3.Text = "RESPUESTAS";
        }

        void Clear()
        {
            txtcomando.Text = "";
            txtruta.Text = "";
            txtrespuesta.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        void CmdSocial()  //mostrar los datos de tipo sociales
        {
            type = "Sociales";

            dgvprincipal.Rows.Clear();
            list.Where(c => c.Type == type).ToList()
                .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

            }));
        }
        
        void LoadCommandsType()
        {
            switch (type)
            {
                case "Paginas Webs":
                    CmdWebPages();
                    break;
                case "Correos":
                    CmdEmails();
                    break;
                case "Bluetooth":
                    CmdBluetooth();
                    break;
                case "Aplicaciones":
                    CmdApps();
                    break;
                case "Carpetas":
                    CmdFolders();
                    break;
                case "Sociales":
                    CmdSocial();
                    break;
            }
        }

        void UpdateTable()
        {
            list = new BL_Commands().LoadCommand(idUser);
            list
               .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

           }));
            

        }

        void CmdFolders()  //mostrar los datos de tipo sociales
        {
            type = "Carpetas";
            dgvprincipal.Rows.Clear();
            list.Where(c => c.Type == type).ToList()
                .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

            }));
        
        }

        void CmdApps()  //mostrar los datos de tipo sociales
        {
            type = "Aplicaciones";

            dgvprincipal.Rows.Clear();
            list.Where(c => c.Type == type).ToList()
                .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

            }));
            
        }

        void CmdBluetooth()  //mostrar los datos de tipo sociales
        {
            type = "Bluetooth";

            dgvprincipal.Rows.Clear();
            list.Where(c => c.Type == type).ToList()
                .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

            }));
        }

        void CmdEmails()  //mostrar los datos de tipo sociales
        {
            type = "Correos";
            dgvprincipal.Rows.Clear();
            list.Where(c => c.Type == type).ToList()
                .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

            }));
        }

        void CmdWebPages()  //mostrar los datos de tipo sociales
        {
            type = "Paginas Webs";
            dgvprincipal.Rows.Clear();

            list.Where(c => c.Type == type).ToList()
                .ForEach(x => dgvprincipal.Rows.Add(new object[]{
                "",
                x.Id,
                x.Type,
                x.Comand,
                x.Path,
                x.Answer

            }));
            
        }
        
        #endregion
        #region eventos

        private void frmComandos_Load(object sender, EventArgs e)
        {
            list = new BL_Commands().LoadCommand(idUser);
            comboBox1.SelectedIndex = 0;
        }

        private void dgvprincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvprincipal.Columns[e.ColumnIndex].Name == "btnSelecionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtInidce.Text = indice.ToString();
                    txtId.Text = dgvprincipal.Rows[indice].Cells["id"].Value.ToString();
                    type = dgvprincipal.Rows[indice].Cells["Tip"].Value.ToString();
                    if (type == "Bluetooth")
                    {
                        comboBox1.SelectedItem = dgvprincipal.Rows[indice].Cells["ruta"].Value.ToString();

                    }
                    else
                    {
                        txtruta.Text = dgvprincipal.Rows[indice].Cells["ruta"].Value.ToString();

                    }
                    txtcomando.Text = dgvprincipal.Rows[indice].Cells["comando"].Value.ToString();
                    txtrespuesta.Text = dgvprincipal.Rows[indice].Cells["respuesta"].Value.ToString();

                }

            }

        }

        private void dgvprincipal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = 28;
                var h = 20;
                var x = e.CellBounds.Left + ((e.CellBounds.Width - w) / 2);
                var y = e.CellBounds.Top + ((e.CellBounds.Height - h) / 2);

                e.Graphics.DrawImage(Properties.Resources.Aurex_ai, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        #endregion
        #region botones

        private void btnPredetinado_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = true;
            comboBox1.Visible = false;
            btnActualizar.Enabled = false;
            btnAgregarComando.Enabled = false;
            btnBorrar.Enabled = false;
            Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            User u = new BL_User().LoadUser().Where(us => us.Id == idUser).FirstOrDefault();
            Configuration c = new BL_Configuration().LoadConfiguration(idUser);
            FrmHome hba = new FrmHome(u, c);
            this.Dispose();
            hba.ShowDialog();
        }

        private void btnSociales_Click(object sender, EventArgs e)
        {
            TextCommands();
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = true;
            comboBox1.Visible = false;
            CmdSocial();
            Clear();
        }

        private void btnAplicaciones_Click(object sender, EventArgs e)
        {
            TextCommands();
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = true;
            comboBox1.Visible = false;
            CmdApps();
            Clear();
        }

        private void btnCarpetas_Click(object sender, EventArgs e)
        {
            TextCommands();
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = true;
            comboBox1.Visible = false;
            CmdFolders();
            Clear();
        }

        private void btnPaginasWeb_Click(object sender, EventArgs e)
        {
            TextCommands();
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = true;
            comboBox1.Visible = false;
            CmdWebPages();
            Clear();
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            TextEmail();
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = true;
            comboBox1.Visible = false;
            CmdEmails();
            Clear();
        }

        private void btnBluetooth_Click(object sender, EventArgs e)
        {
            TextCommands();
            txtId.Text = "";
            txtInidce.Text = "";
            txtruta.Visible = false;
            comboBox1.Visible = true;
            //txtrespuesta.Enabled = false;
            CmdBluetooth();
            Clear();
        }

        private void btnAgregarComando_Click(object sender, EventArgs e)
        {
            if (type == "Bluetooth")
            {
                if ((comboBox1.SelectedItem.ToString() != "luz1" && comboBox1.SelectedItem.ToString() != "luz2" && comboBox1.SelectedItem.ToString() != "luz3" && comboBox1.SelectedItem.ToString() != "luz4" &&
                    comboBox1.SelectedItem.ToString() != "luz5" && comboBox1.SelectedItem.ToString() != "luz6" && comboBox1.SelectedItem.ToString() != "luz7" && comboBox1.SelectedItem.ToString() != "luz8") && txtrespuesta.Text == "")
                {
                    MessageBox.Show("...,Para esta  ruta, es obligatorio colocar una respuesta");
                }
                else
                {
                    if (txtcomando.Text == "" || txtcomando.Text == "  " || txtcomando.Text == null)
                    {
                        MessageBox.Show("Debe colocar un comando");
                    }
                    else
                    {
                        Command c = new Command();
                        c.IdUser = idUser.ToString();
                        c.Type = type;
                        c.Comand = txtcomando.Text;
                        c.Path = comboBox1.SelectedItem.ToString();
                        c.Answer = txtrespuesta.Text;
                        bool ca= new BL_Commands().SaveCommand(c);
                        if (ca) MessageBox.Show("Comando guardado");
                        UpdateTable();
                        Clear();
                    }

                }

            }
            else
            {
                if (txtcomando.Text == "" && txtrespuesta.Text == "")
                {
                    MessageBox.Show("los campos de comando y respuesta no pueden ir vacios");
                }
                else
                {
                    Command c = new Command();
                    c.IdUser = idUser.ToString();
                    c.Type = type;
                    c.Comand = txtcomando.Text;
                    c.Path = txtruta.Text;
                    c.Answer = txtrespuesta.Text;
                    bool cD_Comando = new BL_Commands().SaveCommand(c);
                    if(cD_Comando)
                        MessageBox.Show("Comando guardado");
                    UpdateTable();
                    Clear();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Command cre = new Command();
            cre.Id = int.Parse(txtId.Text);
            cre.IdUser = idUser.ToString();
            cre.Type = type;
            cre.Comand = txtcomando.Text;
            cre.Answer = txtrespuesta.Text;
            cre.Path=(type == "Bluetooth")?
                cre.Path = comboBox1.SelectedItem.ToString():
                cre.Path = txtruta.Text;
            
            dgvprincipal.ClearSelection();

            if (type == "Bluetooth")
            {
                if (txtcomando.Text != "")
                {
                    dgvprincipal[3, i].Value = txtcomando.Text;
                    dgvprincipal[4, i].Value = comboBox1.SelectedItem.ToString();
                    dgvprincipal[5, i].Value = txtrespuesta.Text;
                    Update(cre);
                    Clear();
                    MessageBox.Show("Comando actualizados");
                }
                else
                {
                    MessageBox.Show("no se puede actualizar si hay campos vacion");
                }
            }
            else
            {
                if (txtcomando.Text != "" && txtrespuesta.Text != "")
                {
                    dgvprincipal[3, i].Value = txtcomando.Text;
                    dgvprincipal[4, i].Value = txtruta.Text;
                    dgvprincipal[5, i].Value = txtrespuesta.Text;
                    Update(cre);
                    Clear();
                    MessageBox.Show("Comando actualizados");
                }
                else
                {
                    MessageBox.Show("no se puede actualizar si hay campos vacion");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            dgvprincipal.ClearSelection();

            _= new BL_Commands().DeleteCommand(int.Parse(txtId.Text));
            UpdateTable();
            Clear();
        }

        #endregion

    }
}
