using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Servicio
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Servicio : System.Web.Services.WebService
{

    public Servicio()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod(EnableSession = true)]
    public void Prueba() { }
    [WebMethod(EnableSession = true)]
    public User iniciarSesion(User Usuario)
    {
        SqlConexion _conexion = new SqlConexion();
        List<SqlParameter> _Parametros = new List<SqlParameter>();
        DataTableReader _dtr = null;
        try
        {
            //Abrir conexion
            _conexion.Conectar(System.Configuration.ConfigurationManager.ConnectionStrings["MiBD"].ToString());
            // Se agregan parámetros a la lista List <SqlParameter>, con los valores para cada parametro que se obtienen de los atributos
            // del objeto Pej.Objeto . Atributo_x
            _Parametros.Add(new SqlParameter("@_Nick", Usuario.Nick));
            _Parametros.Add(new SqlParameter("@_Password", Usuario.Password));
            _conexion.PrepararProcedimiento("sp_LoginUser", _Parametros);
            _dtr = _conexion.EjecutarTableReader();
            if (_dtr.HasRows)
            {
                _dtr.Read();
                User _user = new global::User()
                {
                    Id_User = long.Parse(_dtr["Id_User"].ToString())
                };
                HttpContext.Current.Session["Identificador"] = _user.Id_User;
                return _user;
            }
            else
                throw new Exception("User not found");

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
        finally
        {
            _conexion.Desconectar();
            _conexion = null;
            _dtr = null;
        }
    }
    [WebMethod(EnableSession = true)]
    public long registrarUsuario(User persona)
    {
        SqlConexion _conexion = new SqlConexion();
        List<SqlParameter> _Parametros = new List<SqlParameter>();
        DataTableReader _dtr = null;

        try
        {
            //Se abre conexion
            _conexion.Conectar(System.Configuration.ConfigurationManager.ConnectionStrings["MiBD"].ToString());

            //Se agregan´parametros a la lista List<SqlParameters>, con los valores para cada parametro
            _Parametros.Add(new SqlParameter("@_Name", persona.Name));
            _Parametros.Add(new SqlParameter("@_Nick", persona.Nick));
            _Parametros.Add(new SqlParameter("@_Password", persona.Password));
            _conexion.PrepararProcedimiento("sp_AddUsuario", _Parametros);

            _dtr = _conexion.EjecutarTableReader();
            if (_dtr.HasRows)
            {
                //Leer la informacion
                _dtr.Read();
                //Se crea un objeto de clase usuario
                User _user = new User()
                {
                    Id_User = int.Parse(_dtr["Id_User"].ToString())
                };

                //Se indica que se cierre la tabla
                _dtr.Close();

                //Creamos session con el id del usuario

                HttpContext.Current.Session["Identificador"] = _user.Id_User;
                return _user.Id_User;

            }
            else
            {
                throw new Exception("User not found");
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            _conexion.Desconectar();
            _conexion = null;
            _dtr = null;
        }
    }
    [WebMethod(EnableSession = true)]
    public long registrarAlumno(Alumno persona)
    {
        SqlConexion _conexion = new SqlConexion();
        List<SqlParameter> _Parametros = new List<SqlParameter>();
        DataTableReader _dtr = null;

        try
        {
            //Se abre conexion
            _conexion.Conectar(System.Configuration.ConfigurationManager.ConnectionStrings["MiBD"].ToString());

            //Se agregan´parametros a la lista List<SqlParameters>, con los valores para cada parametro
            _Parametros.Add(new SqlParameter("@_Materia", persona.Materia));
            _Parametros.Add(new SqlParameter("@_Grupo", persona.Grupo));
            _Parametros.Add(new SqlParameter("@_Semestre", persona.Semestre));
            _Parametros.Add(new SqlParameter("@_Computadora", persona.Computadora));
            _conexion.PrepararProcedimiento("sp_InAlumno", _Parametros);

            _dtr = _conexion.EjecutarTableReader();
            if (_dtr.HasRows)
            {
                //Leer la informacion
                _dtr.Read();
                //Se crea un objeto de clase usuario
                Alumno _user = new Alumno()
                {
                    Id_Alumno = int.Parse(_dtr["Id_Alumno"].ToString())
                };

                //Se indica que se cierre la tabla
                _dtr.Close();

                //Creamos session con el id del usuario

                HttpContext.Current.Session["Identificador"] = _user.Id_Alumno;
                return _user.Id_Alumno;

            }
            else
            {
                throw new Exception("User not found");
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            _conexion.Desconectar();
            _conexion = null;
            _dtr = null;
        }
    }

}
