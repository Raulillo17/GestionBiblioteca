using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }

    }
    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class Libro
    {
        public int idLibro { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Coleccion { get; set; }
        public DateTime? FechaPrimeraEdicion { get; set; }
    }

    public class Respuesta
    {
        public List<Libro> ArrayLibros { get; set; }
        public List<Usuario> ArrayUsuarios { get; set; }
    }


}
