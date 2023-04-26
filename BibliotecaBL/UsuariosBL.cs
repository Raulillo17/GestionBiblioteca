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
        public static Dictionary<string, string> ValidarLoginUsuario(Dictionary<string, string> infoAcceso)
        {
            Dictionary<string, string> infoLogin;

            //llamamos a la dal y obtener el resultado
            infoLogin = new Dictionary<string, string>(); //esto esta para que compile y no de error pero no deberia ser asi

            return infoLogin;
        }
    }
}
