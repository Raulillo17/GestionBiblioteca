using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BibliotecaWebAPI.Controllers
{
    public class LibrosController
    {
        [HttpPost]
        [Route("api/LibrosContoller/ObtenerLibros")]
        public HttpResponseMessage ObtenerLibros([FromBody] Dictionary<String, String> infoAccesoLibros)
        {
            HttpResponseMessage response = new HttpResponseMessage();


            try
            {
                //llamamos al metodos ObtenerLibros de la capa BL
                Dictionary<String, String> infoAuxLibros = BibliotecaBL.UsuariosBL.ObtenerLibros(infoAccesoLibros);

                //Devolvemos el diccionario con toda la información adicional, serializada.
                response.Content = new StringContent(JsonConvert.SerializeObject(infoAuxLibros), System.Text.Encoding.UTF8, "application/json");
                return response;
            }

            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.Conflict;
                response.ReasonPhrase = ex.Message;
                return response;
            }




        }
        }
}