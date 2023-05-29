using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAL
{
    public class UsuariosDAL
    {
        public static Dictionary<string, string> ObtenerCliente(string usuario)
        {
            Dictionary<string, string> diccRetorno = new Dictionary<string, string>();
            

            using (SqlConnection con = new SqlConnection(UtilDAL.CadenaConexion))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = con,
                    //Metemos la query para sacar la informacion que queramos
                    CommandText = "SELECT * FROM Clientes WHERE NombreUsuario = @usuario"
                };

                command.Parameters.AddWithValue("@usuario", usuario);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) //Podría usar un while, pero asumimos que sólo habrá uno con ese nombre de usuario
                {
                    diccRetorno.Add("Password", reader["Password"].ToString());
                    if (reader["FechaBaja"] != DBNull.Value) { 
                        diccRetorno.Add("FechaBaja", reader["FechaBaja"].ToString());
                    }                   
                }
                else
                    diccRetorno.Add("Existe", Boolean.FalseString);

                reader.Close();
                con.Close();
            }
            return diccRetorno;
        }

        public static Dictionary<string, string> ObtenerLibros()
        {
            Dictionary<string, string> diccRetornoLibros = new Dictionary<string, string>();

            using (SqlConnection con = new SqlConnection(UtilDAL.CadenaConexion))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = con,
                    //Metemos la query para sacar la informacion que queramos
                    //CommandText = "SELECT * FROM Libros "
                };



                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) //Podría usar un while, pero asumimos que sólo habrá uno con ese nombre de usuario
                {
                   //Metemos la informacion al diccionario que queramos devolver
                }
                else
                    //Metemos la informacion al diccionario que queramos devolver
                   

                reader.Close();
                con.Close();
            }


            return diccRetornoLibros;
        }
    }
}
