using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejadores
{
    public class ManejadorProductos
    {
        Base b = new Base("localhost", "root", "", "tienda");

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"SELECT * FROM productos WHERE nombre LIKE '%{filtro}%'", "productos").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();

        }

        public string Guardar(TextBox nombre, TextBox descripcion, TextBox precio)
        {
            try
            {
                return b.Comando($"INSERT INTO productos (nombre, descripcion, precio) VALUES ('{nombre.Text}', '{descripcion.Text}', {double.Parse(precio.Text)})");
            }
            catch
            {
                return "Ha ocurrido un error";
            }
        }
    }
}
