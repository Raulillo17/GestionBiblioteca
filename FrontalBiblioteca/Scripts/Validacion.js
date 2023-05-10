//const expresiones{
//    usuario: /^[a-z-0-9\_\-]{8-20}$/
//    contrasena: /^(?=.*[a-zA-Z])(?=.*[!@#$%^&*])[a-zA-Z!@#$%^&*]{6,}$/
//    }






function validarFormulario(e) {
    // Validar que el contenido del nombre está todo en minúsculas y que como mínimo son 8 caracteres
    var usuario = document.getElementById("user").value;
    var password = document.getElementById("password").value;
    var regex = /^(?=.[a-zA-Z])(?=.\d).{6,}$/;
    var msgerror = "";

    if (usuario === password) {
        msgerror = "Usuario y contraseña deben ser diferentes";
        
    }

    else if (usuario !== usuario.toLowerCase() || usuario.length < 8) {
        msgerror = "El nombre de usuario debe estar en minúsculas y tener al menos 8 caracteres.";

        //Esta NO evita el submit
        //return false;
        //Estas SÍ lo evitan
        

    } 
  
    // Validar que la password tiene al menos 6 caracteres, con letras y dígitos
    else if (regex.test(password)) {

        msgerror = "La Contraseña debe tener 6 carcateres con letras y digitos";
    }

    ///// comprobar si la cookie existe
    //else if (document.cookie.indexOf("login_error=true") !== -1) {
    //    // mostrar mensaje de error si la cookie existe
    //    msgerror = "Hubo un error en el inicio de sesión";
    //    // eliminar la cookie
    //    //document.cookie = "login_error=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    //} else {
    //    // crear y enviar la cookie si el usuario existe en la base de datos
    //    var usuarioExiste = true; // aquí se comprueba si el usuario existe en la base de datos
    //    if (usuarioExiste) {
    //        document.cookie = "usuario_login=true; expires=Fri, 31 Dec 9999 23:59:59 UTC; path=/;";
    //    }
    //}

    if (msgerror !== "") {
        e.preventDefault();
        e.returnValue = false;
        var messageContraseña = document.getElementById("lblError");
        messageContraseña.textContent = msgerror;
    } 
    
    

    //No es necesario devolver true. Si no ponemos ninguna de las que lo evitan, se asume que se debe ejecutar el evento (el sumbit en este caso)
    // Si se han superado todas las validaciones, enviar el formulario
    
} 




