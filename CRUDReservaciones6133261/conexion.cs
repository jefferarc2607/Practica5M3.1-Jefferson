using System.Data.OleDb;

namespace CRUDReservaciones6133261
{
    public class conexion
    {
        public static OleDbConnection conec()
        {
            string rutaDB = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\AcessDB\Reservaciones.accdb";
            return new OleDbConnection(rutaDB);
        }
    }
}