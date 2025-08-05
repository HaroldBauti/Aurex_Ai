
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aurex.Utilities;
using Aurex.EntityLayer;
using System.Net;
using System.Security.Claims;
using Newtonsoft.Json;
using Aurex.BusinessLayer;
using Aurex.Properties;

namespace Aurex
{
    public partial class FrmHome : Form
    {
        bool viernes = false;
        string speech;
        readonly SpeechSynthesizer Aurex = new SpeechSynthesizer();
        readonly string apKey = "ec6e0692c509406d3584c18862823a2b";
        //private SpeechConfig speechSynthesizer;
        bool comandoejecutado = false;
        ComandosGramar cmd = new ComandosGramar();
        SpeechRecognitionEngine reconocedor = new SpeechRecognitionEngine();
        private string porcentaje;
        private string stado;
        private bool r1;
        List<Command> lista; User user;Configuration settings;
        bool b = false;
        private string resultado;

        SerialPort portArduino;
        private string receptor; 
        AUREX_AI _AI;
        public FrmHome(User _user,Configuration c)
        {
            InitializeComponent();
            user = _user;
            settings = c;
            cargargramaticas(); 
            portArduino = new SerialPort();
            portArduino.PortName = settings.PortBt;//el nombre del puerto del bluetoh
            portArduino.BaudRate = 9600;

            portArduino.DataReceived += PortArduino_DataReceived;
            _AI = new AUREX_AI();

        }
        private void PortArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            receptor = portArduino.ReadLine();
            Invoke(new EventHandler(actualizar));
        }
        private void actualizar(object sender, EventArgs e)
        {
            string r = "";
            foreach (char item in receptor)
            {
                r += item;
            }
            if (r1 == false)
            {
                salidadevoz(resultado + r);
            }
        }
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm");
            label2.Text = ":"+DateTime.Now.ToString("sstt");
            int diaSemana = (int)DateTime.Now.DayOfWeek;

            lblLunes.ForeColor = diaSemana == 1 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblMartes.ForeColor = diaSemana == 2 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblMiercoles.ForeColor = diaSemana == 3 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblJueves.ForeColor = diaSemana == 4 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblViernes.ForeColor = diaSemana == 5 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblSabado.ForeColor = diaSemana == 6 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblDomingo.ForeColor = diaSemana == 7 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            
        }
        void VaciarPapeleraReciclaje()
        {
            DirectoryInfo recycleBin = new DirectoryInfo(@"C:\$Recycle.Bin");

            if (recycleBin.Exists)
            {
                foreach (DirectoryInfo dir in recycleBin.GetDirectories())
                {
                    dir.Delete(true);
                }

                Aurex.Speak("Papelera de reciclaje vaciada con éxito");
            }
            else
            {
                Aurex.Speak("La papelera de reciclaje no existe");

            }
        }

        void cargargramaticas()
        {
            cmd.cargarComandosGramar(user.Id);

            reconocedor.LoadGrammar(new Grammar(new Choices(cmd.listCommands.Select(c=>c.Comand).ToArray())));
            reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("Comandodeefecto.txt")))));
            reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Aurex"))));
            //string x = "soy " + user.Name;
            //reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(x))));
            reconocedor.LoadGrammar(Gramaticas.Cargargramaticasweb());
            //reconocedor.LoadGrammar(gramaticas.caragargramaticaescribir());
            /* nombres = new Choices(new string[] { "Harold", "Efrain" });
            GrammarBuilder crearfrase = new GrammarBuilder("mi nombre es");
            crearfrase.Append(nombres);*/

            //Grammar gramaticanombres = new Grammar(crearfrase);
            //reconocedor.LoadGrammar(gramaticanombres);

            Choices buscadores = new Choices(new string[] { "google", "youtube", "facebook" });
            GrammarBuilder buscar = new GrammarBuilder("buscar en");
            buscar.Append(buscadores);
            buscar.AppendDictation();

            Grammar gramaticabuscadores = new Grammar(buscar);
            reconocedor.LoadGrammar(gramaticabuscadores);

            //comandosteclado = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\teclado.txt");

            /*
            foreach (var item in comandosteclado)
            {
                reconocedor.LoadGrammar(new Grammar(new Choices(item.Split(',')[0])));

            }*/

            reconocedor.LoadGrammarAsync(new DictationGrammar());
            reconocedor.RequestRecognizerUpdate();

            reconocedor.SpeechRecognized += reconocedor_SpeeachRecognized;
            Aurex.SpeakStarted += AvHBA_SpeakStarted;
            Aurex.SpeakCompleted += AvHBA_SpeakCompleted;
            //reconocedor.AudioLevelUpdated += reconocedor_AudioLevelUpdated;
            reconocedor.SetInputToDefaultAudioDevice();

            reconocedor.RecognizeAsync(RecognizeMode.Multiple);

        }
        private void AvHBA_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            reconocedor.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void AvHBA_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            reconocedor.RecognizeAsyncCancel();
        }
        void reconocedor_SpeeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            comandoejecutado = false;
            speech = e.Result.Text;
            Console.WriteLine(speech);
            string nombreappk = "Aurex";
            label4.Text=(speech);
            if ((speech == nombreappk || viernes == true) && Cache.isActive == null)
            {
                if (speech == nombreappk)
                {
                    salidadevoz(user.Gender== "Masculino" ? "Si señor " + user.Name : "Si señorita " + user.Name);
                    comandoejecutado = true;
                }
                viernes = true;
                switch (speech)
                {
                    case "Buenos dias":
                        salidadevoz(user.Gender == "Masculino" ? "Buenos dias señor" + user.Name :
                            "buenos dias señorita " + user.Name);
                        comandoejecutado = true;
                        break;
                    case "Buenas tardes":
                        salidadevoz(user.Gender == "Masculino" ? "Buenas tardes señor" + user.Name :
                            "Buenas tardes señorita " + user.Name);
                        comandoejecutado = true;
                        break;
                    case "Buenas noches":
                        salidadevoz(user.Gender == "Masculino" ? "Buenas noches señor" + user.Name :
                            "Buenas noches señorita " + user.Name);
                        comandoejecutado = true;
                        break;
                    case "Bateria":
                        bateria();
                        break;
                    case "Clima":
                        Aurex.Speak("El clima");
                        obtenerclima();
                        comandoejecutado = true;
                        break;
                    
                    case "Eliminar papelera":
                        salidadevoz("eliminando archivos de la papelera de reciclaje");
                        VaciarPapeleraReciclaje();
                        comandoejecutado = true;
                        break;
                    case "Ventana de datos":
                        OpenConfiguration();
                        comandoejecutado = true;
                        break;
                    case "Hasta luego":
                        salidadevoz("Estare esperando nuevas instrucciones");
                        viernes = false;
                        comandoejecutado = true;
                        break;
                    case "Muestrame la ventana de comandos":
                        Aurex.Speak("mostrando ventana de comandos");
                        OpenCommands();
                        comandoejecutado = true;
                        break;
                    case "Minimizar":
                        salidadevoz("Ventana asistente minimizada");
                        this.WindowState = FormWindowState.Minimized;
                        this.Hide();
                        notifyIcon1.Visible = true;
                        comandoejecutado = true;
                        break;
                    case "Tamaño normal":
                        salidadevoz("Ventana tamaño normal");
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        comandoejecutado = true;
                        break;
                    case "Quien te programo":
                        salidadevoz("Fui desarrollado por HBA Tecnología");

                        comandoejecutado = true;
                        break;
                    case "Que hora es":
                        salidadevoz("son las " + DateTime.Now.ToString("hh") + " con " + DateTime.Now.ToString("mm tt"));
                        
                        comandoejecutado = true;
                        break;
                    case "Que fecha estamos":
                        salidadevoz("Estamos " + DateTime.Now.ToLongDateString());
                        comandoejecutado = true;
                        break;
                    case "Que dia es":
                        string dia = DateTime.Now.ToString("dddd");
                        Aurex.SpeakAsync("hoy es " + dia);
                        comandoejecutado = true;
                        break;
                    case "Cerrar asistente":
                        salidadevoz("Hasta pronto" + ". . . . . . . .");
                        ClosePortArduino();
                        Application.Exit();
                        break;
                    case "Apagar equipo":
                        salidadevoz("Apagando equipo , si no quieres apagar el equipo solo di cancelar apagado");
                        Shutdown();
                        comandoejecutado = true;
                        break;
                    case "Cancelar apagado":
                        salidadevoz("Apagar equipo cancelado");
                        NoShutdown();
                        comandoejecutado = true;
                        break;
                    case "Desconectar":
                        salidadevoz(DisconnectBluetooth() ? "Desconectado con casa": "Aun no se a conectado con la casa");
                        comandoejecutado = true;
                        break;

                    case "Ventana de correo":
                        Aurex.Speak("mostrando ventana para enviar correos");
                        OpenEmail();
                        comandoejecutado = true;

                        break;

                    case "Conectar con casa":
                        Aurex.Speak("Conectando con blutu");

                        salidadevoz(ConnectedBluetooth() ? "Conectado con casa" : "Active su Bluetooth o vuelva a intentarlo.");

                        comandoejecutado = true;
                        break;

                }

                if (comandoejecutado == false)
                {
                    ejecutarcomandoAcces(speech);
                }/*
                if (!comandoejecutado)
                {
                    tecladoporvoz(speech);
                    labelreconocimiento.Text = speech;
                    comandoejecutado = true;
                }*/
                if (e.Result.Semantics.ContainsKey("buscador"))
                {
                    buscadorweb(e.Result.Text, e.Result.Semantics["buscador"].Value.ToString());
                }
                if (!comandoejecutado) {
                    if (!confirmacion)
                    {
                        if (!speech.Contains("ok") && !speech.Contains("okey") && !speech.Contains("okei"))
                        {
                            Aurex.Speak("Has dicho: " + speech);
                            speechTemp = speech; // Guarda el comando original
                            confirmacion = true;
                            reconocedor.RecognizeAsync(RecognizeMode.Multiple);
                        }
                    }
                    else
                    {
                        // Ya estamos esperando confirmación
                        if (speech.Contains("sí") || speech.Contains("yes") || speech.Contains("si"))
                        {
                            ComandoNoRegistrado("si"); // usa "si" como señal
                            confirmacion = false;
                        }
                        else if (speech.Contains("no"))
                        {
                            ComandoNoRegistrado("no");
                            confirmacion = false;
                        }
                        else
                        {
                            Aurex.Speak("No entendí. ¿Puedes repetir?");

                            reconocedor.RecognizeAsync(RecognizeMode.Multiple);
                        }

                    }

                }
                
                /*
                if (!comandoejecutado || speech.Contains("escribir"))
                {
                    escribirtex(speech);
                    labelreconocimiento.Text = speech;
                    comandoejecutado = true;
                }

                if (!comandoejecutado || speech.Contains("nombre") || speech.Contains("numero") || speech.Contains("correo"))
                {
                    datospersonales(speech);
                    comandoejecutado = true;
                }*/
            }
        }
        string speechTemp;bool confirmacion=false;
        
        async void ComandoNoRegistrado(string confirmacion)
        {
            if (confirmacion.Equals("si"))
            { // Detiene la escucha
                salidadevoz("Buscando " + speechTemp);
                string res = await _AI.Consultar(speechTemp);
                if (res.Length < 5000)
                {
                    Aurex.Speak(res);
                reconocedor.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
            else
            {
                Aurex.Speak("ok");
                reconocedor.RecognizeAsync(RecognizeMode.Multiple);
            }
                viernes= false;
                comandoejecutado = true;
        }

        bool DisconnectBluetooth()
        {
            if (portArduino.IsOpen)
            {
                btnBluetooth.IconColor= Color.Red;
                portArduino.Close();
                return true;

            }
            else
            {
                return false;
            }
        }

        bool ConnectedBluetooth()
        {
            try
            {
                if (portArduino.IsOpen)
                {
                    return true;
                }
                else
                {
                    portArduino.Open();
                    btnBluetooth.IconColor= Color.LimeGreen;
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        void ejecutarcomandoAcces(string _speech)
        {
            try
            {
                foreach (var item in lista)
                {
                    if (_speech == item.Comand)
                    {
                        if (item.Type == "Bluetooth")
                        {
                            //if (Cache.conectado == true)
                            //{
                            //    puertoarduino.Open();
                            //    Cache.conectado = false;
                            //}
                            //if (puertoarduino.IsOpen)
                            //{
                            //    if (item.respuesta == "" || item.respuesta == " ")
                            //    {
                            //        r1 = false;
                            //        //puertoarduino.Write(item.ruta.ToString());
                            //        resul(item.comando.ToString());

                            //    }
                            //    else
                            //    {
                            //        r1 = true;
                            //        //puertoarduino.Write(item.ruta.ToString());
                            //        salidadevoz(item.respuesta.ToString());
                            //    }
                            //}
                            //else
                            //{
                            //    salidadevoz("Aun no se conectado con la casa");
                            //}
                            comandoejecutado = true;
                        }
                        else
                        {
                            if (item.Path == " " || item.Path == "")
                            {
                                salidadevoz(item.Answer.ToString());
                                comandoejecutado = true;
                            }
                            else
                            {
                                if (item.Comand.Split(' ')[0].ToString() == "Abrir" || item.Comand.Split(' ')[0].ToString() == "abrir")
                                {
                                    salidadevoz(item.Answer.ToString());
                                    Process.Start(item.Answer.ToString());

                                    comandoejecutado = true;
                                }
                                else
                                {
                                    if (item.Comand.Split(' ')[0].ToString() == "Enviar" || item.Comand.Split(' ')[0].ToString() == "enviar")
                                    {

                                        Aurex.Speak("mostrando ventana para enviar correo a " + item.Path.ToString() + " ..................");
                                        //Cache.email = item.respuesta.ToString();
                                        //frmCorreos cor = new frmCorreos(user, settings);
                                        //if (puertoarduino.IsOpen)
                                        //{
                                        //    Cache.conectado = true;
                                        //    puertoarduino.Close();
                                        //}

                                        //cor.Show();
                                        //this.Close();
                                        comandoejecutado = true;

                                    }
                                    else
                                    {
                                        Process[] procesos = Process.GetProcessesByName(item.Path.ToString());


                                        for (int i = 0; i < procesos.Count(); i++)
                                        {

                                            if (item.Path.ToString() == "chrome" && i == 0)
                                            {
                                                salidadevoz(item.Answer.ToString());
                                            }
                                            else
                                            {
                                                if (item.Path.ToString() != "chrome")
                                                {
                                                    salidadevoz(item.Answer.ToString());
                                                }

                                            }
                                            procesos[i].Kill();
                                            comandoejecutado = true;

                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                salidadevoz(ex.Message);
            }

        }

        void buscadorweb(string speech, string explorador)
        {
            //buscar reconocimiento de voz en google

            string frasefinal = speech.Remove(0, 7);

            int iniccio = frasefinal.IndexOf(explorador);
            frasefinal = frasefinal.Remove(iniccio - 3, explorador.Length + 3);
            if (explorador == "google")
            {
                salidadevoz("Buscando " + frasefinal + " en google");
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + frasefinal.Trim());

            }
            if (explorador == "youtube")
            {
                salidadevoz("Buscando " + frasefinal + " en youtube");
                System.Diagnostics.Process.Start("https://www.youtube.com/results?search_query=" + frasefinal.Trim());
            }
            if (explorador == "facebook")
            {
                salidadevoz("Buscando " + frasefinal + " en facebook");
                System.Diagnostics.Process.Start("https://web.facebook.com/search/top?q=" + frasefinal.Trim());
            }
            if (explorador == "instagram")
            {
                System.Diagnostics.Process.Start("https://www.instagram.com/" + frasefinal.Trim().ToLower() + "/");
            }
        }

        void Shutdown()
        {
            ProcessStartInfo inf = new ProcessStartInfo("cmd", "/c shutdown -s -t 30");
            Process pro = new Process();
            pro.StartInfo = inf;
            pro.Start();
        }
        void NoShutdown()
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd", "/c shutdown -a");
            Process proc = new Process();
            proc.StartInfo = info;
            proc.Start();

        }
        void salidadevoz(string texto)
        {
            if (texto == "Hasta pronto" + ". . . . . . . .")
            {
                Aurex.Speak(texto);
            }
            else
            {
                Aurex.SpeakAsync(texto);
            }

        }
        DateTime convertirtiempo(long milisegundos)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddMilliseconds(milisegundos).ToLocalTime();
            return day;
        }
        void bateria()
        {

            Type estado = typeof(PowerStatus);
            PropertyInfo[] propiedades = estado.GetProperties();
            PropertyInfo carga = propiedades[3];
            object valor = carga.GetValue(SystemInformation.PowerStatus, null);
            porcentaje = ((float)valor * 100).ToString();
            PropertyInfo conectado = propiedades[0];
            object conexion = conectado.GetValue(SystemInformation.PowerStatus, null);
            if ((int)conexion == 1)
            {
                stado = " , y cargando";

            }
            else
            {
                stado = " , y no esta cargando";
            }
            salidadevoz("bateria al " + porcentaje + " por ciento, " + stado);
        }

        void LoadWeather()
        {
            try
            {
                WebClient web = new WebClient();
                string url = "";
                if ((settings.City != "") && (settings.City != ""))
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},{1},PE&appid={2}&lang=sp", settings.City, settings.ZipCode, apKey);
                }
                if (settings.City != "")
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},&appid={1}&lang=sp&units", settings.City, apKey);

                }
                if (settings.ZipCode != "")
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?zip={0},PE&appid={1}&lang=sp", settings.ZipCode, apKey);
                }
                var json = web.DownloadString(url);
                Weather.root inf = JsonConvert.DeserializeObject<Weather.root>(json);

                picicono.Visible = true;

                string url_icono = "http://openweathermap.org/img/w/" + inf.weather[0].icon + ".png";
                picicono.ImageLocation = url_icono;
                label5.Text = Math.Round(inf.main.temp - 273.15, 0).ToString() + "C°";
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                salidadevoz(ex.Message);
            }
        }

        void obtenerclima()
        {
            try
            {
                WebClient web = new WebClient();
                string url = "";
                if ((settings.City != "") && (settings.City != ""))
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},{1},PE&appid={2}&lang=sp", settings.City, settings.ZipCode, apKey);
                }
                if (settings.City != "")
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},&appid={1}&lang=sp&units", settings.City, apKey);

                }
                if (settings.ZipCode != "")
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?zip={0},PE&appid={1}&lang=sp", settings.ZipCode, apKey);
                }
                var json = web.DownloadString(url);
                Weather.root inf = JsonConvert.DeserializeObject<Weather.root>(json);

                picicono.Visible = true;

                string url_icono= "http://openweathermap.org/img/w/" + inf.weather[0].icon + ".png";
                picicono.ImageLocation = url_icono;
                label5.Text= Math.Round(inf.main.temp - 273.15, 0).ToString()+"C°";
                salidadevoz("En " + settings.City + " se encuentra " + inf.weather[0].description.ToString() + ", la temperatura es de " + (inf.main.temp - 273.15) + " grados celcious \n" +
                          "velocidad del viento es " + inf.wind.speed.ToString() + " metros por segundo, humedad del " + inf.main.humidity + " por ciento y la presion es de " + inf.main.pressure.ToString() +
                          "\nsalida del sol a las " + convertirtiempo(inf.sys.sunrise).ToShortTimeString().ToString() +
                          ("\nla puesta del sol es a las " + convertirtiempo(inf.sys.sunset).ToShortTimeString().ToString()));

            }
            catch (Exception ex)
            {
                salidadevoz(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Aurex.SelectVoice(settings.VoiceAssistant);
            lista = new BL_Commands().LoadCommand(user.Id);
           
            LoadWeather();

        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIA _form=new FrmIA();
            _form.Show();
        }

        private void BatteryControl_Tick(object sender, EventArgs e)
        {
            string p;
            Type estado = typeof(PowerStatus);
            PropertyInfo[] propiedades = estado.GetProperties();
            PropertyInfo carga = propiedades[3];
            object valor = carga.GetValue(SystemInformation.PowerStatus, null);
            p = ((float)valor * 100).ToString();
            PropertyInfo conectado = propiedades[0];
            object conexion = conectado.GetValue(SystemInformation.PowerStatus, null);

            if ((int)conexion == 1 && p == "100" && b == false)
            {
                salidadevoz("Bateria al cien por ciento, desconecte cargador");
                b = true;
            }
            if (int.Parse(p) < 100)
            {
                b = false;
            }
        }
        void ClosePortArduino()
        {
            if (portArduino.IsOpen)
            {
                portArduino.Close();
            }
        }
        void ValidatePortArduino()
        {
            if (portArduino.IsOpen)
            {
                Cache.conected = true;
                portArduino.Close();
            }
        }
        void OpenCommands()
        {
            ValidatePortArduino();
            FrmCommands conf = new FrmCommands(user.Id);
            Dispose();
            comandoejecutado = true;
            conf.ShowDialog();
        }
        void OpenConfiguration()
        {
            Aurex.Speak("Abriendo Ventana de datos");
            ValidatePortArduino();
            FrmConfiguration conf = new FrmConfiguration(user.Id);
            Dispose();
            comandoejecutado = true;
            conf.ShowDialog();

        }
        void OpenEmail()
        {
            ValidatePortArduino();
            FrmEmail email = new FrmEmail(user,settings);
            Dispose();
            comandoejecutado = true;
            email.ShowDialog();

        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            OpenConfiguration();
        }

        private void btnBluetooth_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnBluetooth_Click(object sender, EventArgs e)
        {
            if (btnBluetooth.IconColor == Color.LimeGreen)
                DisconnectBluetooth();
            else
                ConnectedBluetooth();
        }

        private void btnCommands_Click(object sender, EventArgs e)
        {
            OpenCommands();
        }

        private void btnIA_Click(object sender, EventArgs e)
        {
            OpenEmail();
        }
    }
}
