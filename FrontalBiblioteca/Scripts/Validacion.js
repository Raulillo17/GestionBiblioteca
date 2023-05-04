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

    if (msgerror !== "") {
        e.preventDefault();
        e.returnValue = false;
        var messageContraseña = document.getElementById("lblError");
        messageContraseña.textContent = msgerror;
    } 
    
    

    //No es necesario devolver true. Si no ponemos ninguna de las que lo evitan, se asume que se debe ejecutar el evento (el sumbit en este caso)
    // Si se han superado todas las validaciones, enviar el formulario
    
} 

function checkCookie() {
    //let idcliente = getCookie("user");
    //if (idcliente != "") {
    //    alert("Welcome again " + user);
    //} else {
    //    idcliente = prompt("Please enter your name:", "");
    //    if (idcliente != "" && idcliente != null) {
    //        setCookie("user", user, 365);
    //    }
    //}
}



