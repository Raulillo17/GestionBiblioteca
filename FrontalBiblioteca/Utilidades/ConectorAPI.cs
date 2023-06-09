﻿using BibliotecaModelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Web.Configuration;

namespace FrontalBiblioteca.Utilidades
{
    public  class ConectorAPI
    {
        /// <summary>
        /// Mantiene en memoria la url de acceso a la API, sacada desde el web.config
        /// </summary>
        static string baseUrlAPI;

        /// <summary>
        /// Constructor estático para inicializar lo necesario
        /// </summary>
        static  ConectorAPI()
        {
            try
            {
                //Crea una instancia de HttpClient en tu controlador. HttpClient es una clase de
                //.NET que te permite enviar solicitudes HTTP a un servidor y recibir respuestas.
                HttpClient httpClient = new HttpClient();

                //En la variable URL tendriamos que poner la direccion hacia la API a la que nos vamos a conectar por ejemplo:
                //String url = "https://api.example.com/mi-api";
                string url = WebConfigurationManager.AppSettings["pathBaseWebApiSql"].ToString();
                baseUrlAPI = url;


                //httpClient.BaseAddress = new Uri(url);
                //httpClient.DefaultRequestHeaders.Accept.Clear();
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage response = await httpClient.GetAsync("baseUrlAPI");
                //if (response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine("Conexion establecida");
                //}

                //Hacemos la llamada a la API
                HttpMethod httpMethod = HttpMethod.Get;
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, baseUrlAPI);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en carga de la ruta de acceso de la API", ex);
            }

            if (!baseUrlAPI.EndsWith("/"))
                baseUrlAPI += "/";
        }

        #region Métodos internos

        /// <summary>
        /// Método interno común para todas las llamadas de tipo GET.
        /// </summary>
        /// <param name="uri">Cadena con la uri relativa de llamada a la API</param>
        /// <param name="segundosTimeout">Establece los segundos de tiempo de espera de la llamada. Opcional. Por defecto, 100</param>
        /// <returns></returns>
        static HttpResponseMessage RespuestaGET(string uri, int segundosTimeout = -1)
        {
            string url = baseUrlAPI + uri;
            using (HttpClient clienteAPI = new HttpClient())
            {
                try
                {
                    if (segundosTimeout != -1)
                        clienteAPI.Timeout = TimeSpan.FromSeconds(segundosTimeout); //Por si hiciera falta reducirlo o aumentarlo, que por defecto es 100 segundos.
                    HttpResponseMessage response = clienteAPI.GetAsync(url).Result;
                    return response;
                }
                catch (Exception ex)
                {
                    string msgError = "Excepción de tipo " + ex.GetType().Name;

                    if (ex is AggregateException && ((AggregateException)ex).InnerExceptions.Count > 1)
                    {
                        foreach (var exc in ((AggregateException)ex).InnerExceptions)
                        {
                            msgError += "\n - " + exc.Message;
                            if (exc.InnerException != null)
                            {
                                msgError += " (" + exc.InnerException.Message;
                                if (exc.InnerException.InnerException != null)
                                {
                                    msgError += " -> " + exc.InnerException.InnerException.Message;
                                }
                                msgError += ")";
                            }
                        }
                    }
                    else
                    {
                        if (!(ex is AggregateException))
                        {
                            msgError += " - " + ex.Message;

                            if (ex.InnerException != null)
                            {
                                msgError += " (" + ex.InnerException.Message;
                                if (ex.InnerException.InnerException != null)
                                {
                                    msgError += " -> " + ex.InnerException.InnerException.Message;
                                }
                                msgError += ")";
                            }
                        }
                        else
                        {
                            if (ex.InnerException != null)
                            {
                                msgError += " - " + ex.InnerException.Message;
                                if (ex.InnerException.InnerException != null)
                                {
                                    msgError += " -> " + ex.InnerException.InnerException.Message;
                                }
                            }
                        }
                    }

                    //LogErrores.EscribirError("ConectorAPI/RespuestaGET", ex, msgError + " en llamada a " + url);
                    throw;
                }
            }
        }

        /// <summary>
        /// Método interno común para todas las llamadas de tipo POST.
        /// </summary>
        /// <param name="uri">Cadena con la uri relativa de llamada a la API</param>
        /// <param name="o">Objeto a pasar para su alta</param>
        /// <param name="segundosTimeout">Establece los segundos de tiempo de espera de la llamada. Opcional. Por defecto, 100</param>
        /// <returns></returns>
        static HttpResponseMessage RespuestaPOST(string uri, object o, int segundosTimeout = -1)
        {
            //Hay que chequear limitaciones de tamaño en el objeto.
            //De momento probado hasta 2Mb y funciona, pero con archivos más grandes no... 
            string url = baseUrlAPI + uri;
            using (HttpClient clienteAPI = new HttpClient())
            {
                try
                {
                    if (segundosTimeout != -1)
                        clienteAPI.Timeout = TimeSpan.FromSeconds(segundosTimeout); //Por si hiciera falta reducirlo o aumentarlo, que por defecto es 100 segundos.
                    HttpResponseMessage response = clienteAPI.PostAsJsonAsync(url, o).Result;
                    return response;
                }
                catch (Exception ex)
                {
                    string msgError = "Excepción de tipo " + ex.GetType().Name;

                    if (ex is AggregateException && ((AggregateException)ex).InnerExceptions.Count > 1)
                    {
                        foreach (var exc in ((AggregateException)ex).InnerExceptions)
                        {
                            msgError += "\n - " + exc.Message;
                            if (exc.InnerException != null)
                            {
                                msgError += " (" + exc.InnerException.Message;
                                if (exc.InnerException.InnerException != null)
                                {
                                    msgError += " -> " + exc.InnerException.InnerException.Message;
                                }
                                msgError += ")";
                            }
                        }
                    }
                    else
                    {
                        if (!(ex is AggregateException))
                        {
                            msgError += " - " + ex.Message;

                            if (ex.InnerException != null)
                            {
                                msgError += " (" + ex.InnerException.Message;
                                if (ex.InnerException.InnerException != null)
                                {
                                    msgError += " -> " + ex.InnerException.InnerException.Message;
                                }
                                msgError += ")";
                            }
                        }
                        else
                        {
                            if (ex.InnerException != null)
                            {
                                msgError += " - " + ex.InnerException.Message;
                                if (ex.InnerException.InnerException != null)
                                {
                                    msgError += " -> " + ex.InnerException.InnerException.Message;
                                }
                            }
                        }
                    }

                    //LogErrores.EscribirError("ConectorAPI/RespuestaPOST", ex, msgError + " en llamada a " + url);
                    throw;
                }
            }
        }

        #endregion

        #region Métodos públicos

        //He dejado un par de ejemplos, uno de GET y otro de POST
        //Lo que se devuelva en cada función lógicamente suele depender de lo que se devuelva desde la API.
        //Eso sí... lo que tiene que coincidir es lo que recibas de la llamada (el contenido del ReadAsAsync) con lo que devuelvas desde la API.
        public static Dictionary<string, object> ValidarLoginUsuario(Dictionary<string, string> infoLogin, out string msgErr)
        {

            Dictionary<string, object> infoAcceso = new Dictionary<string, object>();
            //Dictionary<string, object> infoAcceso = null;
            msgErr = null;

            string uri = "api/UsuariosController/ValidarLoginUsuario";
            HttpResponseMessage response = RespuestaPOST(uri, infoLogin);
            if (response.IsSuccessStatusCode)
            {
              
                //infoAcceso.Add("TieneAcceso", true);
                //infoAcceso.Add("FechaUltimaConexion", DateTime.Now);

                infoAcceso = response.Content.ReadAsAsync<Dictionary<string, object>>().Result;
                if (infoAcceso == null)
                {
                    msgErr = "INFOACCESO vacío. Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
                }
            }
            else
            {
                msgErr = "Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
            }
            return infoAcceso;
        }


        public static List<Persona> VerUsuarios(out string msgErr)
        {
            msgErr = null;
            List<Persona> usuarios = null;

            string uri = "api/UsuariosController/VerUsuarios";
            HttpResponseMessage response = RespuestaGET(uri);

            if (response.IsSuccessStatusCode)
            {
                usuarios = response.Content.ReadAsAsync<List<Persona>>().Result;
                if (usuarios == null)
                {
                    msgErr = "Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
                }
            }
            else
            {
                msgErr = "Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
            }
            return usuarios;
        }

        public static List<Libro> ObtenerLibros(Dictionary<string, string> filtrolibros, out string msgErr)
        {
           
            List<Libro> listalibros = new List<Libro>();
            msgErr = null;
            string uri = "api/LibrosController/ObtenerLibros";
            HttpResponseMessage response = RespuestaPOST(uri, filtrolibros);
            if (response.IsSuccessStatusCode)
            {
                listalibros = response.Content.ReadAsAsync<List<Libro>>().Result;
                if (listalibros == null)
                {
                    msgErr = "Diccionario vacío. Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
                }

               
            }
            else
            {
                msgErr = "Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
            }
            return listalibros;


        }

        public static Libro ObtenerLibroMedianteId(int idlibro, out string msgErr)
        {
            Libro libro = new Libro();
            msgErr = null;
            string uri = "api/LibrosController/ObtenerLibroMedianteId";
            HttpResponseMessage response = RespuestaPOST(uri, idlibro);
            if (response.IsSuccessStatusCode)
            {
                libro = response.Content.ReadAsAsync<Libro>().Result;
                if (libro == null)
                {
                    msgErr = "Diccionario vacío. Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
                }


            }
            else
            {
                msgErr = "Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
            }
            return libro;
        }

        public static List<Libro> ObtenerLibrosFiltrados(Dictionary<string, string> filtros, out string msgErr)
        {
            List<Libro> listalibros = new List<Libro>();
            msgErr = null;
            string uri = "api/LibrosController/ObtenerLibrosFiltrados";
            HttpResponseMessage response = RespuestaPOST(uri, filtros);
            if (response.IsSuccessStatusCode)
            {
                listalibros = response.Content.ReadAsAsync<List<Libro>>().Result;
                if (listalibros == null)
                {
                    msgErr = "Diccionario vacío. Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
                }


            }
            else
            {
                msgErr = "Error en llamada a " + uri + " - Motivo: " + response.ReasonPhrase;
            }
            return listalibros;

            throw new NotImplementedException();
        }


        #endregion
    }
   
}
