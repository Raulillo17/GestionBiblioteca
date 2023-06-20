using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                    CommandText = "SELECT * FROM Clientes WHERE NombreUsuario = @usuario"  //AND Password = @password
                };

                command.Parameters.AddWithValue("@usuario", usuario);
                //command.Parameters.AddWithValue("@password", password);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) 
                {
                    diccRetorno.Add("idCliente", reader["id"].ToString());
                    diccRetorno.Add("NombreUsuario", reader["NombreUsuario"].ToString());                 
                   
                    if (reader["FechaBaja"] != DBNull.Value)
                    {
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


    }
}

