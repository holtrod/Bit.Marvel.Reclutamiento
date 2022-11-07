using Bit.Marvel.Reclutamiento.Negocio.Dto;
using Bit.Marvel.Reclutamiento.Presentacion.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Bit.Marvel.Reclutamiento.Presentacion.Servicios
{
    public class ServiciosExternos : IServiciosExternos
    {
        private readonly string _urlBase;
        public ServiciosExternos()
        {
            _urlBase = "";
        }

        

        public MarvelDetailResult<CommicFromList> ConsultarCommics(DtoComicSucursal dtoComicSucursal)
        {
            var respuestaApi = ObtenerRespuestaGet("https://gateway.marvel.com:443/v1/public/comics?orderBy=title&");
            var respuestaMarvel = JsonConvert.DeserializeObject<MarvelResponse<MarvelDetailResult<CommicFromList>>>(respuestaApi.JsonResult);
            if(dtoComicSucursal != null)
            respuestaMarvel.Data.Results = respuestaMarvel.Data.Results.Where(s => !dtoComicSucursal.IdComics.Contains(s.Id));
            return respuestaMarvel.Data;
        }

        public MarvelDetailResult<Personaje> ConsultarPersonajesComic(int id)
        {
            var respuestaApi = ObtenerRespuestaGet($"https://gateway.marvel.com:443/v1/public/comics/{id}/characters?orderBy=name&");
            var respuestaMarvel = JsonConvert.DeserializeObject<MarvelResponse<MarvelDetailResult<Personaje>>>(respuestaApi.JsonResult);

            return respuestaMarvel.Data;
        }

        public MarvelDetailResult<DetalleComic> ConsultarDetalleComic(int id)
        {
            var respuestaApi = ObtenerRespuestaGet($"https://gateway.marvel.com:443/v1/public/comics/{id}?");
            var respuestaMarvel = JsonConvert.DeserializeObject<MarvelResponse<MarvelDetailResult<DetalleComic>>>(respuestaApi.JsonResult);

            return respuestaMarvel.Data;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private static RespuestaApi ObtenerRespuestaGet(string URLApi)
        {
            var publickey = "5052edbf2f7e428cf6dba030c18dc701";
            var privatekey = "3e039926fc80213449febba98e20ff6a44511c6f";
            var ts = DateTime.Now.Ticks;
            var hash = MD5Hash("1"+ privatekey + publickey);
            string resultadoJsonString = "";
            URLApi += $"ts={1}&apikey={publickey}&hash={hash}";

            using (var client = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = client.GetAsync(URLApi).Result)
                    {
                        resultadoJsonString = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                        return new RespuestaApi(response.IsSuccessStatusCode, resultadoJsonString, (int)response.StatusCode);
                    }
                }
                catch (Exception)
                {
                    return new RespuestaApi(false, resultadoJsonString, 504);
                }
            }
        }
    }
    public class RespuestaApi
    {
        public bool IsSuccessful { get; set; }
        public string JsonResult { get; set; }
        public int HttpCode { get; set; }

        public RespuestaApi(bool isSuccessful, string resultJson, int codeHttp)
        {
            this.IsSuccessful = isSuccessful;
            this.JsonResult = resultJson;
            this.HttpCode = codeHttp;
        }
    }
    public class DtoExcepcionComun
    {
        public string titulo { get; set; }
        public string detalle { get; set; }

        public DtoExcepcionComun() { }
        public DtoExcepcionComun(string _titulo, string _detalle)
        {
            this.titulo = _titulo;
            this.detalle = _detalle;
        }
    }
}
