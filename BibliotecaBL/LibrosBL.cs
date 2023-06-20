using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBL
{
    public class LibrosBL
    {
        public static Libro ObtenerLibroMedianteId(int idlibro)
        {
            
            var libro = BibliotecaDAL.LibrosDAL.ObtenerLibroMedianteId(idlibro);

            return libro;
        }

        public static List<Libro> ObtenerLibros(Dictionary<string, string> filtrolibros)
        {
            //String idcliente = filtrolibros["idCliente"];
            List<Libro> listalibros = BibliotecaDAL.LibrosDAL.ObtenerLibros(filtrolibros);


            return listalibros;
        }

        public static List<Libro> ObtenerLibrosFiltrados(Dictionary<string, string> filtros)
        {
            string titulo = filtros["Titulo"];
            string autor = filtros["Autor"];
            string editorial = filtros["Editorial"];
            string coleccion = filtros["Coleccion"];

            List<Libro> listalibrosfiltrados = BibliotecaDAL.LibrosDAL.ObtenerLibros(titulo, autor, editorial, coleccion);
            return listalibrosfiltrados;
        }
    }
}
