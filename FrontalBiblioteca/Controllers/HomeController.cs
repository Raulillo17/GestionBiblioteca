using FrontalBiblioteca.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace FrontalBiblioteca.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View("Validacion");
        }

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
                    MessageBox.Show("El usuario introducido no existe en nuestra base de datos, intentelo de nuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return View("Validacion");
                    }
                    else
                    {
                    MessageBox.Show("El usuario introducido es correcto, bienvenid@", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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