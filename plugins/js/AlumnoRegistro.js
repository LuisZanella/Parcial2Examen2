function btnInsertarAlumno() {
    var grupo = $("#txtGrupo").val(),
        grupo = sha256(grupo);
    var userObj = {
        "Materia": $("#txtMateria").val(),
        "Grupo": grupo,
        "Semestre": $("#txtSemestre").val(),
        "Computadora": $("#txtComputadora").val()

    };

    var persona = JSON.stringify(userObj);

    persona = "{'persona':" + persona + "}";
    ajax('Servicio.asmx', 'registrarAlumno', persona);

}
function registrarAlumno(response) {
    if (response.d > 0) {
        //se registro bien
        alert("Has sido registrado!!");
    } else {
        //no se registro bien
        alert("Error al registrarte, trata mas tarde...");
    }
}