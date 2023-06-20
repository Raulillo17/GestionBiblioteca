using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAL
{
    public class LibrosDAL
    {
        public static Libro ObtenerLibroMedianteId(int idlibro)
        {
            Libro libro = new Libro();

            using (SqlConnection con = new SqlConnection(UtilDAL.CadenaConexion))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = con,
                    //Metemos la query para sacar la informacion que queramos
                    CommandText = "SELECT * FROM Libros Where idLibro = @idlibro"
                };

                command.Parameters.AddWithValue("@idlibro", idlibro);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    libro.idLibro = idlibro;
                    libro.ISBN = reader["ISBN"].ToString();
                    libro.Titulo = reader["Titulo"].ToString();
                    if (reader["Sinopsis"] != DBNull.Value)
                        libro.Sinopsis = reader["Sinopsis"].ToString();
                    if (reader["Autor"] != DBNull.Value)
                        libro.Autor = reader["Autor"].ToString();
                    if (reader["Editorial"] != DBNull.Value)
                        libro.Editorial = reader["Editorial"].ToString();
                    if (reader["Coleccion"] != DBNull.Value)
                        libro.Coleccion = reader["Coleccion"].ToString();
                    if (reader["FechaPrimeraEdicion"] != DBNull.Value)
                        libro.FechaPrimeraEdicion = Convert.ToDateTime(reader["FechaPrimeraEdicion"]);
                }

            }
            return libro;

        }

        public static List<Libro> ObtenerLibros(Dictionary<string, string> filtrolibros)
        {
            var listalibros = new List<Libro>();

            using (SqlConnection con = new SqlConnection(UtilDAL.CadenaConexion))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = con,
                    //Metemos la query para sacar la informacion que queramos
                    CommandText = "SELECT * FROM Libros"
                };


                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var libro = new Libro();

                    libro.idLibro = Convert.ToInt32(reader["idLibro"]);
                    libro.ISBN = reader["ISBN"].ToString();
                    libro.Titulo = reader["Titulo"].ToString();
                    if (reader["Sinopsis"] != DBNull.Value)
                        libro.Sinopsis = reader["Sinopsis"].ToString();
                    if (reader["Autor"] != DBNull.Value)
                        libro.Autor = reader["Autor"].ToString();
                    if (reader["Editorial"] != DBNull.Value)
                        libro.Editorial = reader["Editorial"].ToString();
                    if (reader["Coleccion"] != DBNull.Value)
                        libro.Coleccion = reader["Coleccion"].ToString();
                    if (reader["FechaPrimeraEdicion"] != DBNull.Value)
                        libro.FechaPrimeraEdicion = Convert.ToDateTime(reader["FechaPrimeraEdicion"]);



                    listalibros.Add(libro);
                }
            }

            return listalibros;
        }

        public static List<Libro> ObtenerLibros(string titulo, string autor, string editorial, string coleccion)
        {
            var listalibrosfiltrados = new List<Libro>();

            using (SqlConnection con = new SqlConnection(UtilDAL.CadenaConexion))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = con,
                    //Metemos la query para sacar la informacion que queramos
                    CommandText = "SELECT * FROM Libros WHERE Titulo = @titulo AND Autor = @autor AND Editorial = @editorial AND Coleccion = @coleccion"
            };

                command.Parameters.AddWithValue("@titulo", titulo);
                command.Parameters.AddWithValue("@autor", autor);
                command.Parameters.AddWithValue("@editorial", editorial);
                command.Parameters.AddWithValue("@coleccion", coleccion);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var libro = new Libro();

                    libro.idLibro = Convert.ToInt32(reader["idLibro"]);
                    libro.ISBN = reader["ISBN"].ToString();
                    libro.Titulo = reader["Titulo"].ToString();
                    if (reader["Sinopsis"] != DBNull.Value)
                        libro.Sinopsis = reader["Sinopsis"].ToString();
                    if (reader["Autor"] != DBNull.Value)
                        libro.Autor = reader["Autor"].ToString();
                    if (reader["Editorial"] != DBNull.Value)
                        libro.Editorial = reader["Editorial"].ToString();
                    if (reader["Coleccion"] != DBNull.Value)
                        libro.Coleccion = reader["Coleccion"].ToString();
                    if (reader["FechaPrimeraEdicion"] != DBNull.Value)
                        libro.FechaPrimeraEdicion = Convert.ToDateTime(reader["FechaPrimeraEdicion"]);



                    listalibrosfiltrados.Add(libro);
                }
            }

            return listalibrosfiltrados;
        }
    }
}


//for (var i = 0; i < reader.FieldCount; i++)
//{
//    var columnName = reader.GetName(i);
//    var columnValue = reader.GetValue(i);

//    // Utilizar un switch para asignar los valores a las propiedades según el nombre de la columna
//    switch (columnName)
//    {
//        case "idLibro":
//            libro.idLibro = (int)(columnValue as int?);
//            break;
//        case "ISBN":
//            libro.ISBN = columnValue as string;
//            break;
//        case "Titulo":
//            libro.Titulo = columnValue as string;
//            break;
//        case "Sinopsis":
//            libro.Sinopsis = columnValue as string;
//            break;
//        case "Autor":
//            libro.Autor = columnValue as string;
//            break;
//        case "Editorial":
//            libro.Editorial = columnValue as string;
//            break;
//        case "Coleccion":
//            libro.Coleccion = columnValue as string;
//            break;
//        case "FechaPrimeraEdicion":
//            libro.FechaPrimeraEdicion = columnValue as DateTime?;
//            break;
//    }
//}



//// Crear un objeto para representar el registro
//Libro libro = new Libro();
////Metemos la informacion al diccionario que queramos devolver
//libro.idLibro = reader.GetInt32(reader.GetOrdinal("idLibro"));
//libro.ISBN = reader.GetString(reader.GetOrdinal("ISBN"));
//libro.Titulo = reader.GetString(reader.GetOrdinal("Titulo"));
//if (reader["Sinopsis"] != DBNull.Value)
//{
//    libro.Sinopsis = reader.GetString(reader.GetOrdinal("Sinopsis"));

//}
//if (reader["Autor"] != DBNull.Value)
//{
//    libro.Autor = reader.GetString(reader.GetOrdinal("Autor"));
//}
//if (reader["Editorial"] != DBNull.Value)
//{
//    libro.Editorial = reader.GetString(reader.GetOrdinal("Editorial"));
//}
//if (reader["Coleccion"] != DBNull.Value)
//{
//    libro.Coleccion = reader.GetString(reader.GetOrdinal("Coleccion"));
//}
//if (reader["FechaPrimeraEdicion"] != DBNull.Value)
//{
//    libro.FechaPrimeraEdicion = reader.GetDateTime(reader.GetOrdinal("FechaPrimeraEdicion"));
//}


//listaLibros.Add(libro);

//else
//    //Metemos la informacion al diccionario que queramos devolver
//    diccRetornoLibros.Add("Error", "No se ha conseguido añadir la informacion de los libros");


