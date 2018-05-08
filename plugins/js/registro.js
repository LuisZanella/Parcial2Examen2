function btnRegistrarUsuario() {
    var userObj = {
        "Name": $("#txtNameRegistrar").val(),
        "Password": $("#txtPasswordResgitrar").val(),
        "Nick": $("#txtNickRegistrar").val()
    };

    var user = JSON.stringify(userObj);
    console.warn(user);

    user = "{'persona':" + user + "}";

    ajax('Servicio.asmx', 'registrarUsuario', user);

}
function registrarUsuario(response) {
    if (response.d > 0) {
        //se registro bien
        alert("Has sido registrado!!");
        window.location.href = "Principal.aspx";
    } else {
        //no se registro bien
        alert("Error al registrarte, trata mas tarde...");
    }
}
function btnRegresar() {
    window.location.href = "Index.html";
}