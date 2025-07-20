using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.EntityLayer
{
    public class Gramaticas
    {
        static public Grammar Cargargramaticasweb()
        {
            Choices webs = new Choices(new string[] { "google", "youtube", "wikipedia", "facebook", "instagram" });
            GrammarBuilder frasesWeb = new GrammarBuilder("buscar");
            frasesWeb.AppendDictation();
            frasesWeb.Append("en");

            frasesWeb.Append(new SemanticResultKey("buscador", webs));

            Grammar gwebs = new Grammar(frasesWeb);

            return gwebs;
        }
        static public Grammar Caragargramaticaescribir()
        {
            //Choices dictar = new Choices(new string[]);
            GrammarBuilder fraseescribir = new GrammarBuilder("escribir");
            fraseescribir.AppendDictation();

            //fraseescribir.Append(new SemanticResultKey("texto",dictar));

            Grammar ges = new Grammar(fraseescribir);

            return ges;
        }
    }
}
