using FrontalBiblioteca.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                // SqlCommand command = new SqlCommand(consulta, connection);
                //command.Parameters.AddWithValue("@user", txtNombre);
                //command.Parameters.AddWithValue("@password", txtPassword);


                //connection.Open();
                // SqlDataReader reader = command.ExecuteReader();

                // if (reader.HasRows)
                // {
                //     usuarioExiste = true;
                //}

                // reader.Close();
                //}


                // if (usuarioExiste)
                // {
                //     ViewBag.Mensaje = "Bienvenido" +txtNombre;
                //     return View("Gestion");
                //  }
                // else

                // {              
                //    return View("Validacion");
                // }

                //// Recibimos el nombre de usuario y la contraseña del formulario
                
               
                    // Si los valores coinciden, devolvemos "true"
                    ViewBag.Mensaje = "Bienvenido" + user;

                    Dictionary<string, string> infoLogin = new Dictionary<string, string>();
                    infoLogin.Add("Usuario", user);
                    infoLogin.Add("Password", password);

                    var infoAcceso = ConectorAPI.ValidarLoginUsuario(infoLogin, out string msgErr);

                    return View("Gestion");
                
                    // Si los valores no coinciden, devolvemos "false"                 
                    //Response.Cookies.Add(new HttpCookie("Error", "Usuario o contraseña incorrectos"));

                    //return View("Validacion");
                




                //// Llamamos al método para validar el usuario y la contraseña
                //bool esValido = ValidarUsuario(nombreUsuario, contrasena);

                //// Si el usuario y la contraseña son válidos, redirigimos al usuario a otra página
                //if (esValido)
                //{
                //    Response.Redirect("Gestion.cshtml");
                //}
                //else
                //{
                //    // Si el usuario y la contraseña no son válidos, mostramos un mensaje de error
                //    Response.Cookies.Add(new HttpCookie("Error", "Usuario o contraseña incorrectos"));
                //}


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