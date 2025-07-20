using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.Utilities
{
    public class Comandos
    {
        public int id { get; set; }
        public string idUsuario { get; set; }
        public string tipo { get; set; }
        public string comando { get; set; }
        public string ruta { get; set; }
        public string respuesta { get; set; }
    }
    public class CD_Comando
    {
        string rutas = @"Comandos.txt";
        private List<Comandos> lista = new List<Comandos>();
        public List<Comandos> LeerComandos()
        {
            int contador = 0;
            try
            {
                if (File.Exists(rutas))
                {
                    using (StreamReader reader = new StreamReader(rutas))
                    {
                        while (!reader.EndOfStream)
                        {
                            if (contador != 0)
                            {
                                string linea = reader.ReadLine();
                                string[] datos = linea.Split("*".ToCharArray());
                                Comandos reg = new Comandos();
                                reg.id = int.Parse(datos[0]);
                                reg.idUsuario = datos[1];
                                reg.tipo = datos[2];
                                reg.comando = datos[3];
                                reg.ruta = datos[4];
                                reg.respuesta = datos[5];
                                lista.Add(reg);
                            }
                            else
                            {
                                reader.ReadLine();
                            }
                            contador++; // actualizar el contador
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer el archivo " + ex.Message);
            }


            return lista;
        }

        private string guardarreg(List<Comandos> lcomandos)
        {
            string formatp = "id*idUsuario*tipo*comando*ruta*respuesta";
            foreach (Comandos item in lcomandos)
            {
                formatp += "\r\n" + item.id + "*" + item.idUsuario + "*" + item.tipo + "*" + item.comando + "*" + item.ruta + "*" + item.respuesta;
            }
            return formatp;
        }

        public void registrarComandos(List<Comandos> listaComandos, out string mensaje)
        {
            if (File.Exists(rutas))
            {
                try
                {
                    File.Delete(rutas);
                    StreamWriter escritor = File.AppendText(rutas);
                    CD_Comando al = new CD_Comando();
                    escritor.WriteLine(al.guardarreg(listaComandos));
                    escritor.Flush();
                    escritor.Close();
                    mensaje = "Comando guardado";
                }
                catch (Exception ex)
                {
                    mensaje = "Error" + ex.Message;
                }
            }
            else
            {
                try
                {
                    Stream c = File.Create(rutas);
                    StreamWriter escritor = File.AppendText(rutas);
                    CD_Comando al = new CD_Comando();
                    escritor.WriteLine(al.guardarreg(listaComandos));
                    escritor.Flush();
                    escritor.Close();
                    c.Flush();
                    c.Close();
                    mensaje = "";
                }
                catch (Exception ex)
                {

                    mensaje = "Error" + ex.Message;
                }


            }
        }
    }

    public class ComandosGramar
    {
        List<Comandos> listadecamndo;
        public ArrayList listacomadoS = new ArrayList();
        public ArrayList listacomadoSTEmp = new ArrayList();

        CD_Comando c = new CD_Comando();
        public void cargarComandosGramar(int idU)
        {
            string s;
            listadecamndo = new CD_Comando().LeerComandos();
            try
            {
                int id = listadecamndo.Count + 1;
                if (listadecamndo.Count == 0)
                {
                    Comandos ci = new Comandos();
                    ci.idUsuario = idU.ToString();
                    ci.tipo = "Aplicaciones";
                    ci.comando = "Abrir word";
                    ci.ruta = "WINWORD.exe";
                    ci.respuesta = "Abriendo word";
                    listadecamndo.Add(ci);
                    c.registrarComandos(listadecamndo, out s);
                }
                else
                {
                    Comandos c2 = new CD_Comando().LeerComandos().Where(c => idU.ToString() == c.idUsuario).FirstOrDefault();
                    if (c2 == null)
                    {
                        Comandos ci = new Comandos();
                        ci.idUsuario = idU.ToString();
                        ci.tipo = "Aplicaciones";
                        ci.comando = "Abrir word";
                        ci.ruta = "WINWORD.exe";
                        ci.respuesta = "Abriendo word";
                        listadecamndo.Add(ci);
                        c.registrarComandos(listadecamndo, out s);
                    }
                }
                foreach (var item in listadecamndo)
                {
                    if (item.idUsuario == idU.ToString())
                    {
                        listacomadoS.Add(item.comando);
                    }
                }

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }
    }
}
