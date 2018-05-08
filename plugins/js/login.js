function btnIniciarSesion() {
    var userObj = {
        "Password": $("#txtPassword").val(),
        "Nick": $("#txtNick").val()
    };

    var user = JSON.stringify(userObj);

    user = "{'Usuario':" + user + "}";
    ajax('Servicio.asmx', 'iniciarSesion', user);
}
function iniciarSesion(response) {
    if (response.d.Id_User > 0) window.location.href = "Principal.aspx";
}
function btnRegistrarse() {
    window.location.href = "Registrarme.html";
}

