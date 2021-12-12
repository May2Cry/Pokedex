using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokeLista
    {

            [JsonProperty("count")]
            public long count { get; set; }
            [JsonProperty("next")]
            public Uri next { get; set; }
            [JsonProperty("previous")]
            public object previous { get; set; }
            [JsonProperty("results")]
            public List<Pokemon> result { get; set; }
     

        public class Pokemon
        {
            [JsonProperty("name")]

            public string name { get; set; }
            [JsonProperty("url")]
            public Uri url { get; set; }

            public Image getImage()
            {
                string Direccionrecibida = url.ToString();
                Direccionrecibida = Direccionrecibida.Substring(0, Direccionrecibida.Length - 1);
                Direccionrecibida = Direccionrecibida.Substring(Direccionrecibida.LastIndexOf("/"));

                Direccionrecibida = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"+Direccionrecibida+".png";

                var request = WebRequest.Create(Direccionrecibida);

                using (var responde = request.GetResponse())
                {
                    using (var stream = responde.GetResponseStream())
                    {
                        return Bitmap.FromStream(stream);
                    }
                }

                
            } 
        }

    }
}
