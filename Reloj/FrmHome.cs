using Microsoft.VisualBasic.ApplicationServices;
using Aurex.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<Comandos> lista;
        bool b = false;
        private string resultado;
        private string receptor;
        public FrmHome()
        {
            InitializeComponent();
            cargargramaticas();

            _AI = new AUREX_AI();

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
        void comandos()
        {
            
            foreach (Comandos item in lista)
            {
                if (item.idUsuario != 1.ToString())
                {
                    lista.Remove(item);
                }
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
            cmd.cargarComandosGramar(1);

            reconocedor.LoadGrammar(new Grammar(new Choices(cmd.listacomadoS.ToArray(typeof(string)) as string[])));
            reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("Comandodeefecto.txt")))));
            reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Aurex"))));
            //string x = "soy " + user.nombre;
            //reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(x))));
            reconocedor.LoadGrammar(Gramaticas.Cargargramaticasweb());
            //reconocedor.LoadGrammar(gramaticas.caragargramaticaescribir());
            Choices nombres = new Choices(new string[] { "Harold", "Efrain" });
            GrammarBuilder crearfrase = new GrammarBuilder("mi nombre es");
            crearfrase.Append(nombres);

            Grammar gramaticanombres = new Grammar(crearfrase);
            reconocedor.LoadGrammar(gramaticanombres);

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
                    salidadevoz("Si señor  ");
                    //labelreconocimiento.Text = "";
                    //labelreconocimiento.Text = speech;
                    comandoejecutado = true;
                }
                viernes = true;
                switch (speech)
                {
                    case "Buenos dias":

                        salidadevoz("buenos dias señor");

                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Buenas noches":
                        salidadevoz("buenas noches señor");

                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Bateria":
                        bateria();
                        break;
                    case "Clima":
                        Aurex.Speak("El clima");
                        //obtenerclima();
                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Buenas tardes":
                        salidadevoz("buenas tardes señor");

                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Eliminar papelera":
                        salidadevoz("eliminando archivos de la papelera de reciclaje");
                        VaciarPapeleraReciclaje();
                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Ventana de datos":
                        Aurex.Speak("Abriendo Ventana de datos");
                        //if (puertoarduino.IsOpen)
                        //{
                        //    Cache.conected = true;
                        //    puertoarduino.Close();
                        //}

                        //dat.Show();
                        //this.Close();
                        comandoejecutado = true;
                        break;
                    case "Hasta luego":
                        salidadevoz("Estare esperando nuevas instrucciones");
                        viernes = false;
                        comandoejecutado = true;

                        break;
                    case "Muestrame la ventana de comandos":
                        Aurex.Speak("mostrando ventana de comandos");
                        //if (puertoarduino.IsOpen)
                        //{
                        //    Cache.conectado = true;
                        //    puertoarduino.Close();
                        //}

                        //formularioComandos.Show();
                        //this.Close();
                        comandoejecutado = true;
                        break;
                    case "Minimizar":
                        salidadevoz("Ventana asistente minimizada");
                        this.WindowState = FormWindowState.Minimized;
                        //this.Hide();
                        //notifyIcon1.Visible = true;

                        comandoejecutado = true;
                        break;
                    case "Tamaño normal":
                        salidadevoz("Ventana tamaño normal");
                        this.Show();
                        this.WindowState = FormWindowState.Normal;

                        comandoejecutado = true;
                        break;
                    case "Quien te programo":
                        salidadevoz("Quien me programo es Harold Bautista");

                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Que hora es":
                        //hora();
                        salidadevoz("son las " + DateTime.Now.ToString("hh") + " con " + DateTime.Now.ToString("mm tt"));
                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Que fecha estamos":
                        //fecha();
                        salidadevoz("Estamos " + DateTime.Now.ToLongDateString());
                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Que dia es":
                        string dia = DateTime.Now.ToString("dddd");
                        Aurex.SpeakAsync("hoy es " + dia);
                        //labelreconocimiento.Text = "";
                        //labelreconocimiento.Text = speech;
                        comandoejecutado = true;
                        break;
                    case "Cerrar asistente":
                        salidadevoz("Hasta pronto" + ". . . . . . . .");
                        //if (puertoarduino.IsOpen)
                        //{
                        //    puertoarduino.Close();
                        //}
                        Application.Exit();
                        comandoejecutado = true;
                        break;
                    case "Apagar equipo":
                        ProcessStartInfo inf = new ProcessStartInfo("cmd", "/c shutdown -s -t 30");
                        Process pro = new Process();
                        pro.StartInfo = inf;
                        salidadevoz("Apagando equipo , si no quieres apagar el equipo solo di cancelar apagado");
                        pro.Start();

                        comandoejecutado = true;
                        break;
                    case "Cancelar apagado":
                        ProcessStartInfo info = new ProcessStartInfo("cmd", "/c shutdown -a");
                        Process proc = new Process();
                        proc.StartInfo = info;
                        salidadevoz("Apagar equipo cancelado");
                        proc.Start();

                        comandoejecutado = true;
                        break;
                    case "Desconectar":
                        //if (puertoarduino.IsOpen)
                        //{
                        //    puertoarduino.Close();
                        //    salidadevoz("Desconectado con casa");

                        //    pbxbt.BackgroundImage = Properties.Resources.btdesactivado;

                        //}
                        //else
                        //{
                        //    salidadevoz("Aun no se a conectado con la casa");
                        //}
                        comandoejecutado = true;
                        break;

                    case "Ventana de correo":
                        Aurex.Speak("mostrando ventana para enviar correos");
                        //if (puertoarduino.IsOpen)
                        //{
                        //    Cache.conectado = true;
                        //    puertoarduino.Close();
                        //}

                        //correo.Show();
                        this.Close();

                        comandoejecutado = true;

                        break;

                    case "Conectar con casa":
                        Aurex.Speak("Conectando con blutu");
                        //if (puertoarduino.IsOpen)
                        //{
                        //    salidadevoz("Ya estas conectado");
                        //}
                        //else
                        //{
                        //    try
                        //    {
                        //        puertoarduino.Open();
                        //        salidadevoz("Conectado con casa");
                        //        pbxbt.BackgroundImage = Properties.Resources.btactivado;

                        //    }
                        //    catch (Exception ex)
                        //    {

                        //        salidadevoz(ex.Message + " active su blutu o vuelva a intentarlo");
                        //    }
                        //}
                        comandoejecutado = true;
                        break;

                }

                if (comandoejecutado == false)
                {
                    ejecutarcomandoAcces(speech);
                    //labelreconocimiento.Text = speech;
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
        AUREX_AI _AI;
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
        void resul(string comando)
        {
            resultado = comando;
        }

        void ejecutarcomandoAcces(string _speech)
        {
            try
            {
                foreach (var item in lista)
                {
                    if (_speech == item.comando)
                    {
                        if (item.tipo == "Bluetooth")
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
                            if (item.ruta == " " || item.ruta == "")
                            {
                                salidadevoz(item.respuesta.ToString());
                                comandoejecutado = true;
                            }
                            else
                            {
                                if (item.comando.Split(' ')[0].ToString() == "Abrir" || item.comando.Split(' ')[0].ToString() == "abrir")
                                {
                                    salidadevoz(item.respuesta.ToString());
                                    Process.Start(item.ruta.ToString());

                                    comandoejecutado = true;
                                }
                                else
                                {
                                    if (item.comando.Split(' ')[0].ToString() == "Enviar" || item.comando.Split(' ')[0].ToString() == "enviar")
                                    {

                                        Aurex.Speak("mostrando ventana para enviar correo a " + item.ruta.ToString() + " ..................");
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
                                        Process[] procesos = Process.GetProcessesByName(item.ruta.ToString());


                                        for (int i = 0; i < procesos.Count(); i++)
                                        {

                                            if (item.ruta.ToString() == "chrome" && i == 0)
                                            {
                                                salidadevoz(item.respuesta.ToString());
                                            }
                                            else
                                            {
                                                if (item.ruta.ToString() != "chrome")
                                                {
                                                    salidadevoz(item.respuesta.ToString());
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
        void obtenerclima()
        {

            //api.openweathermap.org/data/2.5/weather?zip={zip code},{country code}&appid={API key}
            //api.openweathermap.org/data/2.5/weather?q={city name},{state code},{country code}&appid={API key}
            /*if (settings.ciudad == "")
            {
                salidadevoz("Aun no a selecionado la ciudad");
            }
            else
            {*/

            try
            {
                WebClient web = new WebClient();
                string url = "";
                /*if ((settings.ciudad != "") && (settings.codPostal != ""))
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},{1},PE&appid={2}&lang=sp", settings.ciudad, settings.codPostal, apKey);
                }
                if (settings.ciudad != "")
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},&appid={1}&lang=sp&units", settings.ciudad, apKey);

                }
                if (settings.codPostal != "")
                {
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?zip={0},PE&appid={1}&lang=sp", settings.codPostal, apKey);
                }*/
                    url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},&appid={1}&lang=sp&units", "Chiclayo", apKey);

                var json = web.DownloadString(url);
                Weather.root inf = JsonConvert.DeserializeObject<Weather.root>(json);

                picicono.Visible = true;

                string url_icono= "http://openweathermap.org/img/w/" + inf.weather[0].icon + ".png";
                picicono.ImageLocation = url_icono;
                label5.Text= Math.Round(inf.main.temp - 273.15, 0).ToString()+"C°";
                /*salidadevoz("En " + "Trujillo" + " se encuentra " + inf.weather[0].description.ToString() + ", la temperatura es de " + Math.Round(inf.main.temp - 273.15, 0) + " grados celcious \n" +
                //salidadevoz("En " + settings.ciudad + " se encuentra " + inf.weather[0].description.ToString() + ", la temperatura es de " + (inf.main.temp - 273.15) + " grados celcious \n" +
                      "velocidad del viento es " + inf.wind.speed.ToString() + " metros por segundo, humedad del " + inf.main.humidity + " por ciento y la presion es de " + inf.main.pressure.ToString() +
                      "\nsalida del sol a las " + convertirtiempo(inf.sys.sunrise).ToShortTimeString().ToString() +
                      ("\nla puesta del sol es a las " + convertirtiempo(inf.sys.sunset).ToShortTimeString().ToString()));
                */


                /*
                using (WebClient web=new WebClient())
                {
                    string url="";
                    if (Settings.Default.Ciudad != "" || Settings.Default.Ciudad != null || Settings.Default.Ciudad != " ")
                    {
                        url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},&appid={1}&lang=sp&units=metric", Properties.Settings.Default.Ciudad, apKey);

                    }
                    if (Properties.Settings.Default.CodigoP == "" || Properties.Settings.Default.CodigoP == null || Properties.Settings.Default.CodigoP == " ")
                    {
                        url = string.Format("https://api.openweathermap.org/data/2.5/weather?zip={0},PE&appid={1}&lang=sp&units=metric", Settings.Default.CodigoP, apKey);
                    }
                    if (Settings.Default.CodigoP != "" || Settings.Default.CodigoP != null || Settings.Default.CodigoP != " "&& Settings.Default.CodigoP != "" || Settings.Default.CodigoP != null || Settings.Default.CodigoP != " ")
                    {
                        url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},{1},PE&appid={2}&lang=sp&units=metric", Settings.Default.Ciudad, Settings.Default.CodigoP, apKey);
                    }
                    var json = web.DownloadString(url);
                    climainf.root inf = JsonConvert.DeserializeObject<climainf.root>(json);

                    picicono.Visible = true;
                    lblciudad.Text = Settings.Default.Ciudad;
                    lblciudad.Visible = true;
                    picicono.ImageLocation = "https://openweathermap.org/img/w/" + inf.weather[0].icon + ".png";
                    AvHBA.Speak(Settings.Default.Ciudad + " se encuentra " + inf.weather[0].description.ToString() + ", la temperatura es de " + (inf.main.temp));


                    AvHBA.Speak("velocidad del viento es " + inf.wind.speed.ToString() + " metros por segundo, humedad del " + inf.main.humidity + " por ciento y la presion es de " + inf.main.pressure.ToString());
                    AvHBA.Speak("amanece a las " + convertirtiempo(inf.sys.sunrise).ToShortTimeString().ToString());
                    AvHBA.Speak("la puesta del sol es a las " + convertirtiempo(inf.sys.sunset).ToShortTimeString().ToString());



                }*/
            }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                    salidadevoz(ex.Message);
                }
            //}
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (InstalledVoice voces in Aurex.GetInstalledVoices())
            {
                Console.WriteLine(voces.VoiceInfo.Name);
                //cbvoces.Items.Add(voces.VoiceInfo.Name);

            }
            lista = new CD_Comando().LeerComandos();
            comandos();
            Aurex.SelectVoice("Microsoft Helena Desktop");
            obtenerclima();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIA _form=new FrmIA();
            _form.Show();
        }
    }
}
