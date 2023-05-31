using BibliotecaModelos;
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
    public class LibrosController : ApiController
    {
        [HttpPost]
        [Route("api/LibrosController/ObtenerLibros")]
        public HttpResponseMessage ObtenerLibros([FromBody]List<Libro> listalibrosApi)
        {
            HttpResponseMessage response = new HttpResponseMessage();


            try
            {
                //llamamos al metodos ObtenerLibros de la capa BL
                List<Libro> listalibros = BibliotecaBL.UsuariosBL.ObtenerLibros(listalibrosApi);

                //Devolvemos el diccionario con toda la información adicional, serializada.
                response.Content = new StringContent(JsonConvert.SerializeObject(listalibros), System.Text.Encoding.UTF8, "application/json");
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