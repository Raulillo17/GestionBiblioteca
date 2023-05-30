using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBL
{
    public class UsuariosBL
    {
        public static List<Libro> ObtenerLibros(Dictionary<string, string> infoAccesoLibros)
        {
            List<Libro> listalibros = BibliotecaDAL.UsuariosDAL.ObtenerLibros(); ;

            return listalibros;
        }

        public static Dictionary<string, string> ValidarLoginUsuario(Dictionary<string, string> infoAcceso)
        {
                String nombreUsuario = infoAcceso["Usuario"];
                Dictionary<string, string> infoLogin = BibliotecaDAL.UsuariosDAL.ObtenerCliente(nombreUsuario); ;
                //llamamos a la dal y obtener el resultado
                //infoLogin = new Dictionary<string, string>(); //esto esta para que compile y no de error pero no deberia ser asi

                if (infoLogin.ContainsKey("Existe")){
                infoLogin.Add("Tiene Acceso", "false");
            }
            else
            {
                infoLogin.Add("Tiene Acceso", "true");
            }
            
                return infoLogin;
    
        }

        //public static Dictionary<string, string> ObtenerCliente(Dictionary<string, string> diccRetorno)
        //{

        //    //el diccopnario que recibimos en la parte del metodo tenemos que enviarsela otra vez a la api
        //    var diccionarioDAL = diccRetorno;

        //    return diccionarioDAL;
        //}


    }
}
