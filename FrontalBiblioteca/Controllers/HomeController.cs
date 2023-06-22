using BibliotecaModelos;
using FrontalBiblioteca.Utilidades;
using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace FrontalBiblioteca.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
        
            return View("Validacion");
        }
        [JSInvokable]
        public ActionResult ValidarUsuario(string user, string password)
        {

            //string connectionString = "Nuestra cadena de conexion con el servidor";
            //string consulta = "SELECT * FROM tabla_usuarios WHERE nombre_usuario ="+txtNombre+" AND contrasena = "+ txtPassword + "";
            //bool usuarioExiste = false;

            // using ( SqlConnection connection = new SqlConnection(connectionString))
            {
                      
                    // Si los valores coinciden, devolvemos "true"
                    ViewBag.Mensaje = "Bienvenido" + user;

                    //Diccionario para meter la informacion que nos viene al logearnos con el submit
                    Dictionary<string, string> infoLogin = new Dictionary<string, string>();

                    //creamos el diccionario idcliente para almacenar el iddelcliente
                    Dictionary<string, string> filtroLibros = new Dictionary<string, string>();


                    //Dictionary<string, object> infoAccesoLibros = new Dictionary<string, object>();
                    infoLogin.Add("Usuario", user);
                    infoLogin.Add("Password", password);

                    //Hacemos una instacia de una lista
                    List<Libro> listalibros = new List<Libro>(); 
                    
                    //llamamos al metodo de la api pasandole el usuario y la contraseña con la que se ha registrado
                    var infoAcceso = ConectorAPI.ValidarLoginUsuario(infoLogin, out string msgErr);

                    object valor;
                    if (infoAcceso.TryGetValue("Tiene acceso", out valor) && valor.ToString() == "false")
                    {
                    Response.Cookies.Add(new HttpCookie("errorlogin", "Usuario o contraseña incorrectos"));
                    return View("Validacion");
                    
                    }
                    else
                    {

                    //creamos una variable para recoger el valor que contiene la KEY idCliente y NombreUsuario                   
                    string idCliente = infoAcceso["idCliente"].ToString();
                    string NombreUsuario = infoAcceso["NombreUsuario"].ToString();


                    //añadimos al diccionario el id del cliente
                    filtroLibros.Add("idCliente", idCliente);
                    filtroLibros.Add("NombreUsuario", NombreUsuario);


                    //llamamos al metodo de la api con los datos que queremos para filtrar en un diccionario
                    listalibros = ConectorAPI.ObtenerLibros(filtroLibros, out string msgErrLibros);

                    //Inicializamos las listas para coger todos los datos
                    List<string> titulosLibros = new List<string>();
                    List<string> autoresLibros = new List<string>();
                    List<string> editorialesLibros = new List<string>();
                    List<string> coleccionesLibros = new List<string>();

                    //hacemos un bucle para recoger los titulos de todos los libros
                    foreach (var libro in listalibros)
                    {
                        if(libro.Titulo != null) {
                        titulosLibros.Add(libro.Titulo);
                        }

                    }

                    //hacemos un bucle para recoger los AUTORES de todos los libros
                    foreach (var libro in listalibros)
                    {
                        if(libro.Autor != null) {
                            autoresLibros.Add(libro.Autor);
                        }
                       

                    }

                    //hacemos un bucle para recoger los editoriales de todos los libros
                    foreach (var libro in listalibros)
                    {
                        if(libro.Editorial != null)
                        {
                            editorialesLibros.Add(libro.Editorial);

                        }
                        

                    }

                    //hacemos un bucle para recoger los colecciones de todos los libros
                    foreach (var libro in listalibros)
                    {
                        if (libro.Autor != null) {
                            coleccionesLibros.Add(libro.Coleccion);
                        }
                      

                    }


                    //pasamos todos los datos a la vista
                    Session["Libros"] = listalibros;
                    ViewData["titulosLibros"] = titulosLibros;
                    ViewData["autoresLibros"] = autoresLibros;
                    ViewData["editorialesLibros"] = editorialesLibros;
                    ViewData["coleccionesLibros"] = coleccionesLibros;


                    //Creamos una nueva cookie y añadimos la Key idCliente con el valor que contiene la variable idCliente
                    Response.Cookies.Add(new HttpCookie("idCliente", idCliente));

                    return View("ListadoLibros");
                    
                   
                }
               
                    // Si los valores no coinciden, devolvemos "false"                 
                    //Response.Cookies.Add(new HttpCookie("Error", "Usuario o contraseña incorrectos"));

                    //return View("Validacion");
   

            }
        }

       

        public ActionResult Detalle(int idlibro)
        {
            //Llamamos al metodo ObtenerLibroMedianteId de la clase Conector API
            var DetalleDelLibro = ConectorAPI.ObtenerLibroMedianteId(idlibro, out string msgErrLibros);
           
            //pasamos mediante ViewData el Detalle del libro que recibimos a traves de su id
            ViewData["DetalleDelLibro"] = DetalleDelLibro;

            return View("DetailLibro");
        }


        public ActionResult Filtrado(string titulo, string autor, string editorial, string coleccion)
        {


            //Hacemos una instacia de una lista
            List<Libro> listalibrosfiltrados = new List<Libro>();
            Dictionary<string, string> filtros = new Dictionary<string, string>();



            if(titulo == "")
            {
                titulo = "%";
                filtros.Add("Titulo", titulo);
            }
            else
            {
                filtros.Add("Titulo", titulo);
               
            }
            if(autor == "") {
                autor = "%";
                filtros.Add("Autor", autor);
            }
            else
            {
                filtros.Add("Autor", autor);
            }
            if(editorial == "") 
            { 
                editorial = "%";
                filtros.Add("Editorial", editorial);
            }
            else
            {
                filtros.Add("Editorial", editorial);
            }
            if(coleccion == "")
            {
                coleccion = "%";
                filtros.Add("Coleccion", coleccion);
            }
            else
            {
                filtros.Add("Coleccion", coleccion);
            }
           
           
            


            List<string> titulosLibros = new List<string>();
            List<string> autoresLibros = new List<string>();
            List<string> editorialesLibros = new List<string>();
            List<string> coleccionesLibros = new List<string>();

            //pasamos todos los datos a la vista
            ViewData["titulosLibros"] = titulosLibros;
            ViewData["autoresLibros"] = autoresLibros;
            ViewData["editorialesLibros"] = editorialesLibros;
            ViewData["coleccionesLibros"] = coleccionesLibros;

            listalibrosfiltrados = ConectorAPI.ObtenerLibrosFiltrados(filtros, out string msgErrLibros);
            ViewData["Librosfiltrados"] = listalibrosfiltrados;
            return View("ListadoLibros");
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