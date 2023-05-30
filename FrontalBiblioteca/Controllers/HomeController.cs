using BibliotecaModelos;
using FrontalBiblioteca.Utilidades;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace FrontalBiblioteca.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
        
            return View("Validacion");
        }
        [JSInvokable]
        public ActionResult ValidarUsuario(string user, string password)
        {

            //string connectionString = "Nuestra cadena de conexion con el servidor";
            //string consulta = "SELECT * FROM tabla_usuarios WHERE nombre_usuario ="+txtNombre+" AND contrasena = "+ txtPassword + "";
            //bool usuarioExiste = false;

            // using ( SqlConnection connection = new SqlConnection(connectionString))
            {
                
       
                    // Si los valores coinciden, devolvemos "true"
                    ViewBag.Mensaje = "Bienvenido" + user;
                    //Diccionario para meter la informacion que nos viene al logearnos con el submit
                    Dictionary<string, string> infoLogin = new Dictionary<string, string>();
                    //creamos el diccionario idcliente para almacenar el iddelcliente
                    Dictionary<string, string> idcliente = new Dictionary<string, string>();
                    infoLogin.Add("Usuario", user);
                    infoLogin.Add("Password", password);

                    var infoAcceso = ConectorAPI.ValidarLoginUsuario(infoLogin, out string msgErr);
                    
           
                    if(infoAcceso.ContainsValue("false")) {

                    Response.Cookies.Add(new HttpCookie("errorlogin", "Usuario o contraseña incorrectos"));
                    return View("Validacion");
                    

                    }
                    else
                    {
                    //diccionario para almacenar todo lo enviado a traves del navegador
                    Dictionary<string, string> requestform = new Dictionary<string, string>();
                    foreach (var key in Request.Form.Keys)
                    {
                        string keyString = (string)key;
                        string value = Request.Form[keyString];
                        requestform.Add(keyString, value);
                    }

                    var requestformLibros = ConectorAPI.ObtenerLibros(requestform, out string msgErrLibros);

                    //creamos una variable para recoger el valor que contiene la KEY idCliente
                    string idCliente = infoAcceso["idCliente"].ToString();
                    //Creamos una nueva cookie y añadimos la Key idCliente con el valor que contiene la variable idCliente
                    Response.Cookies.Add(new HttpCookie("idCliente", idCliente));

                    return View("Gestion");
                    
                   
                }

                   
                
                    // Si los valores no coinciden, devolvemos "false"                 
                    //Response.Cookies.Add(new HttpCookie("Error", "Usuario o contraseña incorrectos"));

                    //return View("Validacion");
   


            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}