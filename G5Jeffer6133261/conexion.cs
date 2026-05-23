using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G5Jeffer6133261
{
    class conexion
    {
        public string servidor, db;
        public string cadena;

        public void conce()
        {
            servidor = "JEFFERSONARCE77\\SQLEXPRESS";  
            db = "DBG5Jeffer6133261";
            cadena = "Server=" + servidor + ";Database=" + db + ";Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
