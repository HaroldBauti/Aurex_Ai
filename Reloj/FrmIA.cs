using Aurex.BusinessLayer;
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
        string apiKey = "AIzaSyAlPyUWBmSRAYmwlKo-6G2aUd22Fz2R16k";
        async void ConsultarImg(string question)
        {

            //var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash-preview-image-generation:generateContent?key={apiKey}";
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash-preview-image-generation:generateContent?key={apiKey}";

            var requestBody = new ImageRequest
            {
                contents = new List<ContentImg>
            {
                new ContentImg
                {
                    parts = new List<PartImg>
                    {
                        new PartImg
                        {
                            text = question
                        }
                    }
                }
            },
                generationConfig = new GenerationConfig
                {
                    responseModalities = new List<string> { "TEXT", "IMAGE" }
                }
            };

            string json = JsonConvert.SerializeObject(requestBody);

             var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar
                var result = JsonConvert.DeserializeObject<ImageResponse>(responseBody);
                var part = result?.candidates?[0]?.content?.parts?[0];

                if (!string.IsNullOrEmpty(part?.data))
                {
                    // Imagen recibida
                    byte[] imageBytes = Convert.FromBase64String(part.data);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else if (!string.IsNullOrEmpty(part?.data))
                {
                    // 👀 Muestra el texto que Gemini te devolvió
                    MessageBox.Show("Texto en vez de imagen:\n" + part.data);
                }
                else
                {
                    MessageBox.Show("No se recibió ni imagen ni texto válido.");
                }
                /*string base64Image = result.candidates[0].content.parts[0].data;
                Console.WriteLine(base64Image);
                // Guardar imagen
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                using (var ms = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }*/
                //File.WriteAllBytes("gemini-image.png", imageBytes);

                Console.WriteLine("Imagen generada y guardada como 'gemini-image.png'");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        async void ConsultarText(string question)
        {
            string respuestaModelo=await _AI.Consultar(question);
            Console.WriteLine("Respuesta del modelo:");
            Console.WriteLine(respuestaModelo);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ConsultarImg(txtQuestion.Text);
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ConsultarText(txtQuestion.Text);
            }
        }
    }
}
