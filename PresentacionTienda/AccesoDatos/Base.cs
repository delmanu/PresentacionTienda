using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Base
    {
        MySqlConnection con;

        public Base(string s, string u, string p, string bd)
        {
            con = new MySqlConnection($"server={s}; user={u}; password={p}; database={bd};");

        }

        //Insertar, Borrar, Actualizar, ETC.
        public string Comando(string q)
        {
            string rs = "";
            try
            {
                MySqlCommand i = new MySqlCommand(q, con);
                con.Open();
                i.ExecuteNonQuery();
                con.Close();            //Siempre se debe de cerrar la conexion cuando se termine de ejecutar la consulta.
                rs = "Correcto";
            }
            catch (Exception ex)
            {
                con.Close();            //Por seguridad, cerrar siempre la conexion primero.
                rs = ex.Message;
            }
            return rs;
        }

        public DataSet Consultar(string q, string tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(q, con);
                con.Open();
                da.Fill(ds, tabla);
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return ds;
        }
    }
}
