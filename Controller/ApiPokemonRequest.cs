using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Controller
{
    public class ApiPokemonRequest
    {
        public string url { get; set; }

        private int actual = 0;

        public ApiPokemonRequest()
        {
            url = "https://pokeapi.co/api/v2/pokemon?limit=10&offset=";
        }

        public PokeLista ObtenerLista()
        {
            var consutla = (HttpWebRequest)WebRequest.Create(url + actual);
            consutla.MediaType = "Get";
            consutla.ContentType = "application/json";
            consutla.Accept = "application/json";


                try
                {
                    using (WebResponse responde = consutla.GetResponse())
                    {
                        using (Stream stream = responde.GetResponseStream())
                        {
                            if (stream == null)
                            {
                                return null;
                            }
                            using (StreamReader lector = new StreamReader(stream))
                            {
                                string resultado = lector.ReadToEnd();
                                PokeLista pokeL = JsonConvert.DeserializeObject<PokeLista>(resultado);
                                actual += 10;
                                return pokeL;
                            }
                        }

                    }
        
                }
                catch (Exception ex)
                {
                 return null ;
                }
        }
    }
}
