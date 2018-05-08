using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
        public long Id_User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public bool Estatus { get; set; }
        public string Imagen { get; set; }
}