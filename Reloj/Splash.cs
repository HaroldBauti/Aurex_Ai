using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurex.BusinessLayer;
using Aurex.DataLayer;
using System.Windows.Forms;
using Aurex.EntityLayer;
using Newtonsoft.Json.Linq;
using FontAwesome.Sharp;
using System.Speech.Synthesis;
using Aurex.IU.Modal;

namespace Aurex
{
    public partial class Splash : Form
    {
        private static User user;
        private static Configuration configuration;
        private static List<User> users;
        static string voz;
        SpeechSynthesizer Aurex = new SpeechSynthesizer();
        int idUsuario;
        int valuep = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            CreateDB.CreateDBAndTables();
            
            users = new BL_User().LoadUser();
            try
            {
                
                if (users.Count() == 0)
                {
                    Aurex.Speak("Aun no a registrado sus datos, vamos a registrarlos");

                    timer1.Start();
                }
                else
                {
                    if (Properties.Settings.Default.idUser == null || Properties.Settings.Default.idUser == "" || Properties.Settings.Default.idUser == " ")
                    {
                        user = new User();
                        timer1.Start();
                    }
                    else
                    {
                        user = new BL_User().LoadUser().Where(u => u.Id == int.Parse(Properties.Settings.Default.idUser)).FirstOrDefault();
                        if (user == null)
                        {
                            user = new User();
                            Properties.Settings.Default.idUser = null;
                            Properties.Settings.Default.Save();
                            timer1.Start();

                        }
                        configuration = new BL_Configuration().LoadConfiguration(idUsuario);
                       
                        voz = configuration.VoiceAssistant;
                        Aurex.SelectVoice(voz);
                        if (user.Gender == "Masculino")
                        {
                            Aurex.Speak("Bienvenido de nuevo señor , " + user.Name);
                            saludar();
                            Aurex.Speak("Cargando base de datos");
                            timer1.Start();
                        }
                        else
                        {
                            Aurex.Speak("Bienvenida de nuevo señorita , " + user.Name);

                            saludar();
                            Aurex.Speak("Cargando base de datos");

                            timer1.Start();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Aurex.Speak(ex.Message);
            }
        }
        void saludar()
        {
            if (DateTime.Now.ToString("tt").ToUpper() =="AM")
            {
                Aurex.SpeakAsync("Buenos dias, son las " + DateTime.Now.ToString("hh") + " horas con " + DateTime.Now.ToString("mm") + " minutos");

            }
            else
            {
                if (DateTime.Now.Hour < 19)
                {
                    Aurex.SpeakAsync("Buenos tardes, son las " + DateTime.Now.ToString("hh") + " horas con " + DateTime.Now.ToString("mm") + " minutos");

                }
                else
                {
                    Aurex.SpeakAsync("Buenos noches, son las " + DateTime.Now.ToString("hh") + " horas con " + DateTime.Now.ToString("mm") + " minutos");

                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            valuep += 2;
            bunifuCircleProgressbar1.Value = valuep;

            if (bunifuCircleProgressbar1.Value == 100)
            {
                timer1.Stop();
                if (user == null)
                {
                    FrmConfiguration conf = new FrmConfiguration(0, 0);

                    Dispose();
                    conf.ShowDialog();
                }
                else
                {
                    if (Properties.Settings.Default.idUser == null || Properties.Settings.Default.idUser == "" || Properties.Settings.Default.idUser == " ")
                    {
                        Dispose();
                        Md_Login _login = new Md_Login();
                        Aurex.SpeakAsync("Ingrese su nombre");
                        _login.ShowDialog();
                    }
                    else
                    {
                        Dispose();
                        FrmHome _home = new FrmHome(user, configuration);
                        Aurex.SpeakAsync("Base de datos cargados");
                        _home.ShowDialog();
                    }
                }
                bunifuCircleProgressbar1.Value = 0;
            }
        }
    }
}
