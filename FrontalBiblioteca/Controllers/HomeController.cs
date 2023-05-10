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

                    Dictionary<string, string> infoLogin = new Dictionary<string, string>();
                    infoLogin.Add("Usuario", user);
                    infoLogin.Add("Password", password);

                    var infoAcceso = ConectorAPI.ValidarLoginUsuario(infoLogin, out string msgErr);
                    
            
                    if(infoAcceso.ContainsKey("Existe")) {
                        return View("Validacion");
                        
                    }
                    else
                    {
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