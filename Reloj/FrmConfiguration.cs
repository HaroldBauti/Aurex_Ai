using Aurex.BusinessLayer;
using Aurex.EntityLayer;
using Aurex.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurex
{
    public partial class FrmConfiguration : Form
    {
        User oUser;
        Configuration conf;
        long IdUser;
        SpeechSynthesizer Aurex = new SpeechSynthesizer();
        public FrmConfiguration(int _idUser)
        {
            InitializeComponent();
            IdUser = _idUser;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Aurex.SelectVoice(cbxVoiceAssistant.SelectedItem.ToString());
            if (oUser == null)
            {
                oUser = new User();
                conf = new Configuration();
                oUser.Name = txtName.Text;
                oUser.Email = txtEmail.Text;
                oUser.Password = txtPassword.Text;
                oUser.Gender = cbxGender.SelectedItem.ToString();
                bool newUser= Validation()? new BL_User().SaveUser(oUser, out IdUser):false;
                oUser.Id = (int)IdUser;
                if (newUser)
                {
                    conf.IdUser = IdUser.ToString();
                    conf.City = txtCity.Text;
                    conf.ZipCode = txtZipCode.Text;
                    conf.PortBt = txtPort.Text;
                    conf.AssistantName = txtAssistantName.Text;
                    conf.LowBattery = txtBattery.Value.ToString();
                    conf.VoiceAssistant = cbxVoiceAssistant.SelectedItem.ToString();
                    bool newConf=new BL_Configuration().SaveConfiguration(conf);
                    if (newConf)
                    {
                        Properties.Settings.Default.idUser = IdUser.ToString();
                        Properties.Settings.Default.Save();
                        Aurex.Speak("Configuracion guardada");
                    }
                }
                else { oUser=null; }
            }
            else
            {
                Validation();
                oUser.Name = txtName.Text;
                oUser.Email = txtEmail.Text;
                oUser.Password = txtPassword.Text;
                oUser.Gender = cbxGender.SelectedItem.ToString();
                bool upUser = new BL_User().UpdateUser(oUser);
                if (upUser)
                {
                    conf.IdUser = IdUser.ToString();
                    conf.City = txtCity.Text;
                    conf.ZipCode = txtZipCode.Text;
                    conf.PortBt = txtPort.Text;
                    conf.AssistantName = txtAssistantName.Text;
                    conf.LowBattery = txtBattery.Value.ToString();
                    conf.VoiceAssistant = cbxVoiceAssistant.SelectedItem.ToString();
                }
                bool upConf=new BL_Configuration().UpdateConfiguration(conf);
                if (upUser)
                {
                    Aurex.Speak("Datos actualizados");
                }
            }
        }

        public bool Validation()
        {
            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == string.Empty)
            {
                txtEmail.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                txtPassword.Focus();return false;
            }
            if (txtAssistantName.Text.Trim() == string.Empty)
            {
                txtAssistantName.Focus();return false;
            }
            if (txtCity.Text.Trim() == string.Empty && txtZipCode.Text.Trim()==string.Empty)
            {
                txtCity.Focus();return false;
            }
            if (txtPort.Text.Trim() == string.Empty)
            {
                txtPort.Focus(); return false;
            }

            return true;
        }

        private void FillFields()
        {
            foreach (InstalledVoice voces in Aurex.GetInstalledVoices())
            {
                cbxVoiceAssistant.Items.Add(voces.VoiceInfo.Name);
            }
            if (oUser != null)
            {
                txtName.Text = oUser.Name;
                txtEmail.Text = oUser.Email;
                txtPassword.Text = oUser.Password;
                cbxGender.SelectedItem = oUser.Gender;
                txtAssistantName.Text = conf.AssistantName;
                txtBattery.Value = int.Parse(conf.LowBattery);
                cbxVoiceAssistant.SelectedItem = conf.VoiceAssistant;
                txtCity.Text = conf.City;
                txtZipCode.Text = conf.ZipCode;
                txtPort.Text = conf.PortBt;
                Aurex.SelectVoice(conf.VoiceAssistant);
            }
            else
            {
                cbxGender.SelectedIndex = 0;
                cbxVoiceAssistant.SelectedIndex = 0;
            }
        }

        private void FrmConfiguration_Load(object sender, EventArgs e)
        {
            oUser = new BL_User().LoadUser().Where(u => u.Id == IdUser).FirstOrDefault();
            conf = new BL_Configuration().LoadConfiguration((int)IdUser);
            FillFields();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (oUser != null && conf != null)
            {
                FrmHome hba = new FrmHome(oUser, conf);
                this.Dispose();
                Cache.isActive = null;
                hba.ShowDialog();
            }
            else
            {
                Cache.isActive = null;
                DialogResult r;
                r = MessageBox.Show("¿Desea salir de la aplicación?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (r.ToString() == "Yes")
                {
                    Application.Exit();
                }
            }
        }

        private void cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
