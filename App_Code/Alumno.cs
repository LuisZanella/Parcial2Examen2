using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Alumno
/// </summary>
public class Alumno
{
    public long Id_Alumno { get; set; }
    public string Materia { get; set; }
    public string Grupo { get; set; }
    public string Semestre { get; set; }
    public string Computadora { get; set; }
    public bool Estatus { get; set; }
    public Alumno()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}