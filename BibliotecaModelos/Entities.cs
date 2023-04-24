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
        public int id { get; set; }
        public string titulo { get; set; }
        public string editorial { get; set; }
        public string autor { get; set; }
        public bool reservado { get; set; }
        public bool comprado { get; set; }
    }

    public class Respuesta
    {
        public List<Libro> ArrayLibros { get; set; }
        public List<Usuario> ArrayUsuarios { get; set; }
    }


}
