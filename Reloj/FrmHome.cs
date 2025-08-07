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
using System.Windows.Forms;
using Aurex.Utilities;
using Aurex.EntityLayer;
using System.Net;
using Newtonsoft.Json;
using Aurex.BusinessLayer;

namespace Aurex
{
    public partial class FrmHome : Form
    {
        #region variables
        readonly string apKey = "ec6e0692c509406d3584c18862823a2b";
        private string percentage, state,receptor, speech, 
            resultBluetooth, speechTemp;
        private bool aurex = false,r1,commandExecuted = false, b = false,
            confirmation = false;
        //private SpeechConfig speechSynthesizer;
        readonly SpeechSynthesizer Aurex = new SpeechSynthesizer();
        ComandosGramar cmd = new ComandosGramar();
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        List<Command> list; 
        User user;
        Configuration settings;
        SerialPort portArduino;
        AUREX_AI _AI;
        #endregion

        public FrmHome(User _user,Configuration c)
        {
            InitializeComponent();
            user = _user;
            settings = c;
            LoadGrammar(); 
            portArduino = new SerialPort();
            portArduino.PortName = settings.PortBt;//el nombre del puerto del bluetoh
            portArduino.BaudRate = 9600;

            portArduino.DataReceived += PortArduino_DataReceived;
            _AI = new AUREX_AI();

        }
        
        #region Methods
        private void Update(object sender, EventArgs e)
        {
            string r = "";
            foreach (char item in receptor)
            {
                r += item;
            }
            if (r1 == false)
            {
                VoiceOutput(resultBluetooth + r);
            }
        }

        void EmptyRecyclingBin()
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

        void LoadGrammar()
        {
            cmd.LoadCommandGramar(user.Id);

            recognizer.LoadGrammar(new Grammar(new Choices(cmd.listCommands.Select(c => c.Comand).ToArray())));
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("Comandodeefecto.txt")))));
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Aurex"))));
            //string x = "soy " + user.Name;
            //reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(x))));
            recognizer.LoadGrammar(Gramaticas.LoadGrammarWeb());
            //reconocedor.LoadGrammar(gramaticas.caragargramaticaescribir());
            /* nombres = new Choices(new string[] { "Harold", "Efrain" });
            GrammarBuilder crearfrase = new GrammarBuilder("mi nombre es");
            crearfrase.Append(nombres);*/

            //Grammar gramaticanombres = new Grammar(crearfrase);
            //reconocedor.LoadGrammar(gramaticanombres);

            Choices searchEngines = new Choices(new string[] { "google", "youtube", "facebook" });
            GrammarBuilder search = new GrammarBuilder("buscar en");
            search.Append(searchEngines);
            search.AppendDictation();

            Grammar grammarSearchEngines = new Grammar(search);
            recognizer.LoadGrammar(grammarSearchEngines);

            //comandosteclado = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\teclado.txt");

            /*
            foreach (var item in comandosteclado)
            {
                reconocedor.LoadGrammar(new Grammar(new Choices(item.Split(',')[0])));

            }*/

            recognizer.LoadGrammarAsync(new DictationGrammar());
            recognizer.RequestRecognizerUpdate();

            recognizer.SpeechRecognized += reconocedor_SpeeachRecognized;
            Aurex.SpeakStarted += AvHBA_SpeakStarted;
            Aurex.SpeakCompleted += AvHBA_SpeakCompleted;
            //reconocedor.AudioLevelUpdated += reconocedor_AudioLevelUpdated;
            recognizer.SetInputToDefaultAudioDevice();

            recognizer.RecognizeAsync(RecognizeMode.Multiple);

        }

        async void UnregisteredCommand(string _confirmation)
        {
            if (_confirmation.Equals("si"))
            { // Detiene la escucha
                VoiceOutput("Buscando " + speechTemp);
                string res = await _AI.Consultar(speechTemp);
                if (res.Length < 5000)
                {
                    Aurex.Speak(res);
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
            else
            {
                Aurex.Speak("ok");
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            aurex = false;
            commandExecuted = true;
        }

        bool DisconnectBluetooth()
        {
            if (portArduino.IsOpen)
            {
                btnBluetooth.IconColor = Color.Red;
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
                    btnBluetooth.IconColor = Color.LimeGreen;
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        void Result(string comando)
        {
            resultBluetooth = comando;
        }

        void ExecuteAccessCommand(string _speech)
        {
            try
            {
                foreach (var item in list)
                {
                    if (_speech == item.Comand)
                    {
                        if (item.Type == "Bluetooth")
                        {
                            ValidatePortArduino();
                            if (portArduino.IsOpen)
                            {
                                if (item.Answer == "" || item.Answer == " ")
                                {
                                    r1 = false;
                                    portArduino.Write(item.Answer.ToString());
                                    Result(item.Comand.ToString());
                                }
                                else
                                {
                                    r1 = true;
                                    portArduino.Write(item.Answer.ToString());
                                    VoiceOutput(item.Answer.ToString());
                                }
                            }
                            else
                            {
                                VoiceOutput("Aun no se conectado con la casa");
                            }
                            commandExecuted = true;
                        }
                        else
                        {
                            if (item.Path == " " || item.Path == "")
                            {
                                VoiceOutput(item.Answer.ToString());
                                commandExecuted = true;
                            }
                            else
                            {
                                if (item.Comand.Split(' ')[0].ToString() == "Abrir" || item.Comand.Split(' ')[0].ToString() == "abrir")
                                {
                                    VoiceOutput(item.Answer.ToString());
                                    Process.Start(item.Answer.ToString());

                                    commandExecuted = true;
                                }
                                else
                                {
                                    if (item.Comand.Split(' ')[0].ToString() == "Enviar" || item.Comand.Split(' ')[0].ToString() == "enviar")
                                    {

                                        Aurex.Speak("mostrando ventana para enviar correo a " + item.Path.ToString() + " ..................");
                                        Cache.email = item.Answer.ToString();
                                        
                                        OpenEmail();
                                        commandExecuted = true;

                                    }
                                    else
                                    {
                                        Process[] procesos = Process.GetProcessesByName(item.Path.ToString());


                                        for (int i = 0; i < procesos.Count(); i++)
                                        {

                                            if (item.Path.ToString() == "chrome" && i == 0)
                                            {
                                                VoiceOutput(item.Answer.ToString());
                                            }
                                            else
                                            {
                                                if (item.Path.ToString() != "chrome")
                                                {
                                                    VoiceOutput(item.Answer.ToString());
                                                }

                                            }
                                            procesos[i].Kill();
                                            commandExecuted = true;

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
                VoiceOutput(ex.Message);
            }

        }

        void SearchWeb(string speech, string explorador)
        {
            //buscar reconocimiento de voz en google

            string frasefinal = speech.Remove(0, 7);

            int iniccio = frasefinal.IndexOf(explorador);
            frasefinal = frasefinal.Remove(iniccio - 3, explorador.Length + 3);
            if (explorador == "google")
            {
                VoiceOutput("Buscando " + frasefinal + " en google");
                Process.Start("https://www.google.com/search?q=" + frasefinal.Trim());

            }
            if (explorador == "youtube")
            {
                VoiceOutput("Buscando " + frasefinal + " en youtube");
                Process.Start("https://www.youtube.com/results?search_query=" + frasefinal.Trim());
            }
            if (explorador == "facebook")
            {
                VoiceOutput("Buscando " + frasefinal + " en facebook");
                Process.Start("https://web.facebook.com/search/top?q=" + frasefinal.Trim());
            }
            if (explorador == "instagram")
            {
                Process.Start("https://www.instagram.com/" + frasefinal.Trim().ToLower() + "/");
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

        void VoiceOutput(string _text)
        {
            if (_text == "Hasta pronto" + ". . . . . . . .")
            {
                Aurex.Speak(_text);
            }
            else
            {
                Aurex.SpeakAsync(_text);
            }

        }

        DateTime convertirtiempo(long milisegundos)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddMilliseconds(milisegundos).ToLocalTime();
            return day;
        }

        void Battery()
        {

            Type estado = typeof(PowerStatus);
            PropertyInfo[] propiedades = estado.GetProperties();
            PropertyInfo carga = propiedades[3];
            object valor = carga.GetValue(SystemInformation.PowerStatus, null);
            percentage = ((float)valor * 100).ToString();
            PropertyInfo conectado = propiedades[0];
            object conexion = conectado.GetValue(SystemInformation.PowerStatus, null);
            if ((int)conexion == 1)
            {
                state = " , y cargando";

            }
            else
            {
                state = " , y no esta cargando";
            }
            VoiceOutput("bateria al " + percentage + " por ciento, " + state);
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
                VoiceOutput(ex.Message);
            }
        }

        void GetWeather()
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
                VoiceOutput("En " + settings.City + " se encuentra " + inf.weather[0].description.ToString() + ", la temperatura es de " + (inf.main.temp - 273.15) + " grados celcious \n" +
                          "velocidad del viento es " + inf.wind.speed.ToString() + " metros por segundo, humedad del " + inf.main.humidity + " por ciento y la presion es de " + inf.main.pressure.ToString() +
                          "\nsalida del sol a las " + convertirtiempo(inf.sys.sunrise).ToShortTimeString().ToString() +
                          ("\nla puesta del sol es a las " + convertirtiempo(inf.sys.sunset).ToShortTimeString().ToString()));

            }
            catch (Exception ex)
            {
                VoiceOutput(ex.Message);
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
            conf.Show();
            this.Close();
            commandExecuted = true;
        }
        void OpenIA()
        {
            ValidatePortArduino();
            FrmIA obj = new FrmIA();
            obj.Show();
            this.Close();
            commandExecuted = true;
        }
        void OpenConfiguration()
        {
            Aurex.Speak("Abriendo Ventana de datos");
            ValidatePortArduino();
            FrmConfiguration conf = new FrmConfiguration(user.Id);
            conf.Show();
            this.Close();
            commandExecuted = true;

        }

        void OpenEmail()
        {
            ValidatePortArduino();
            FrmEmail email = new FrmEmail(user, settings);
            email.Show();
            this.Close();
            commandExecuted = true;

        }
        #endregion

        #region Events
        private void PortArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            receptor = portArduino.ReadLine();
            Invoke(new EventHandler(Update));
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm");
            label2.Text = ":" + DateTime.Now.ToString("sstt");
            int diaSemana = (int)DateTime.Now.DayOfWeek;

            lblLunes.ForeColor = diaSemana == 1 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblMartes.ForeColor = diaSemana == 2 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblMiercoles.ForeColor = diaSemana == 3 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblJueves.ForeColor = diaSemana == 4 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblViernes.ForeColor = diaSemana == 5 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblSabado.ForeColor = diaSemana == 6 ? Color.Cyan : Color.FromArgb(176, 190, 197);
            lblDomingo.ForeColor = diaSemana == 7 ? Color.Cyan : Color.FromArgb(176, 190, 197);

        }

        void reconocedor_SpeeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            commandExecuted = false;
            speech = e.Result.Text;
            string nombreappk = settings.AssistantName;

            if ((speech == nombreappk || aurex == true) && Cache.isActive == null)
            {
                if (speech == nombreappk)
                {
                    VoiceOutput(user.Gender == "Masculino" ? "Si señor " + user.Name : "Si señorita " + user.Name);
                    commandExecuted = true;
                }
                aurex = true;
                switch (speech)
                {
                    case "Buenos dias":
                        VoiceOutput(user.Gender == "Masculino" ? "Buenos dias señor" + user.Name :
                            "buenos dias señorita " + user.Name);
                        commandExecuted = true;
                        break;
                    case "Buenas tardes":
                        VoiceOutput(user.Gender == "Masculino" ? "Buenas tardes señor" + user.Name :
                            "Buenas tardes señorita " + user.Name);
                        commandExecuted = true;
                        break;
                    case "Buenas noches":
                        VoiceOutput(user.Gender == "Masculino" ? "Buenas noches señor" + user.Name :
                            "Buenas noches señorita " + user.Name);
                        commandExecuted = true;
                        break;
                    case "Bateria":
                        Battery();
                        break;
                    case "Clima":
                        Aurex.Speak("El clima");
                        GetWeather();
                        commandExecuted = true;
                        break;

                    case "Eliminar papelera":
                        VoiceOutput("eliminando archivos de la papelera de reciclaje");
                        EmptyRecyclingBin();
                        commandExecuted = true;
                        break;
                    case "Ventana de datos":
                        OpenConfiguration();
                        commandExecuted = true;
                        break;
                    case "Hasta luego":
                        VoiceOutput("Estare esperando nuevas instrucciones");
                        aurex = false;
                        commandExecuted = true;
                        break;
                    case "Muestrame la ventana de comandos":
                        Aurex.Speak("mostrando ventana de comandos");
                        OpenCommands();
                        commandExecuted = true;
                        break;
                    case "Minimizar":
                        VoiceOutput("Ventana asistente minimizada");
                        this.WindowState = FormWindowState.Minimized;
                        this.Hide();
                        notifyIcon1.Visible = true;
                        commandExecuted = true;
                        break;
                    case "Tamaño normal":
                        VoiceOutput("Ventana tamaño normal");
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        commandExecuted = true;
                        break;
                    case "Quien te programo":
                        VoiceOutput("Fui desarrollado por HBA Tecnología");
                        commandExecuted = true;
                        break;
                    case "Que hora es":
                        VoiceOutput("son las " + DateTime.Now.ToString("hh") + " con " + DateTime.Now.ToString("mm tt"));
                        commandExecuted = true;
                        break;
                    case "Que fecha estamos":
                        VoiceOutput("Estamos " + DateTime.Now.ToLongDateString());
                        commandExecuted = true;
                        break;
                    case "Que dia es":
                        string dia = DateTime.Now.ToString("dddd");
                        Aurex.SpeakAsync("hoy es " + dia);
                        commandExecuted = true;
                        break;
                    case "Cerrar asistente":
                        VoiceOutput("Hasta pronto" + ". . . . . . . .");
                        ClosePortArduino();
                        Application.Exit();
                        break;
                    case "Apagar equipo":
                        VoiceOutput("Apagando equipo , si no quieres apagar el equipo solo di cancelar apagado");
                        Shutdown();
                        commandExecuted = true;
                        break;
                    case "Cancelar apagado":
                        VoiceOutput("Apagar equipo cancelado");
                        NoShutdown();
                        commandExecuted = true;
                        break;
                    case "Desconectar":
                        VoiceOutput(DisconnectBluetooth() ? "Desconectado con casa" : "Aun no se a conectado con la casa");
                        commandExecuted = true;
                        break;

                    case "Ventana de correo":
                        Aurex.Speak("mostrando ventana para enviar correos");
                        OpenEmail();
                        commandExecuted = true;

                        break;

                    case "Conectar con casa":
                        Aurex.Speak("Conectando con blutu");
                        VoiceOutput(ConnectedBluetooth() ? "Conectado con casa" : "Active su Bluetooth o vuelva a intentarlo.");
                        commandExecuted = true;
                        break;

                }

                if (commandExecuted == false)
                {
                    ExecuteAccessCommand(speech);
                }/*
                if (!comandoejecutado)
                {
                    tecladoporvoz(speech);
                    labelreconocimiento.Text = speech;
                    comandoejecutado = true;
                }*/
                if (e.Result.Semantics.ContainsKey("buscador"))
                {
                    SearchWeb(e.Result.Text, e.Result.Semantics["buscador"].Value.ToString());
                }
                if (!commandExecuted)
                {
                    if (!confirmation)
                    {
                        if (!speech.Contains("ok") && !speech.Contains("okey") && !speech.Contains("okei"))
                        {
                            Aurex.Speak("Has dicho: " + speech);
                            speechTemp = speech; // Guarda el comando original
                            confirmation = true;
                            recognizer.RecognizeAsync(RecognizeMode.Multiple);
                        }
                    }
                    else
                    {
                        // Ya estamos esperando confirmación
                        if (speech.Contains("sí") || speech.Contains("yes") || speech.Contains("si"))
                        {
                            UnregisteredCommand("si"); // usa "si" como señal
                            confirmation = false;
                        }
                        else if (speech.Contains("no"))
                        {
                            UnregisteredCommand("no");
                            confirmation = false;
                        }
                        else
                        {
                            Aurex.Speak("No entendí. ¿Puedes repetir?");
                            recognizer.RecognizeAsync(RecognizeMode.Multiple);
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

        private void AvHBA_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void AvHBA_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            recognizer.RecognizeAsyncCancel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Aurex.SelectVoice(settings.VoiceAssistant);
            list = new BL_Commands().LoadCommand(user.Id);
            LoadWeather();

        }

        #endregion

        #region Buttons

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ClosePortArduino();
            Application.Exit();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            OpenEmail();
        }
        private void BatteryControl_Tick(object sender, EventArgs e)
        {
            string p;
            Type estado = typeof(PowerStatus);
            PropertyInfo[] properties = estado.GetProperties();
            PropertyInfo load = properties[3];
            object valor = load.GetValue(SystemInformation.PowerStatus, null);
            p = ((float)valor * 100).ToString();
            PropertyInfo conectado = properties[0];
            object conexion = conectado.GetValue(SystemInformation.PowerStatus, null);

            if ((int)conexion == 1 && p == "100" && b == false)
            {
                VoiceOutput("Bateria al cien por ciento, desconecte cargador");
                b = true;
            }
            if (int.Parse(p) < 100)
            {
                b = false;
            }
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
            OpenIA();
        }

        #endregion

    }
}
