using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Aurex.Utilities.Response;

namespace Aurex.BusinessLayer
{
    public class AUREX_AI
    {
        public readonly string apiKey="AIzaSyAlPyUWBmSRAYmwlKo-6G2aUd22Fz2R16k";

        public async Task<string> Consultar(string question)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

            var requestBody = new GeminiRequest
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        parts = new List<Part>
                        {
                            new Part { text = question }
                        }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(requestBody);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();


            GeminiResponse respuesta = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

            // Mostrar solo el texto generado por el modelo
            string respuestaModelo = respuesta.candidates[0].content.parts[0].text;
            return respuestaModelo; 
        }
    }
}
