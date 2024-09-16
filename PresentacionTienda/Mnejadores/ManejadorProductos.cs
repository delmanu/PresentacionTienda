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
            Tabla.DataSource = b.Consultar($"SELECT * FROM libros WHERE TituloLibro LIKE '%{filtro}%'", "libros").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
            //Tabla.Columns.Insert(9, Boton("Eliminar", Color.Red));
            //Tabla.Columns.Insert(10, Boton("Modificar", Color.Green));
        }

        public string Guardar(TextBox Titulo, TextBox ISBN, TextBox Autor, TextBox Editorial, TextBox Genero, TextBox Idioma, DateTimePicker AñoPublicacion, int Cantidad)
        {
            try
            {
                String fr = $"{AñoPublicacion.Text.Substring(6, 4)}-{AñoPublicacion.Text.Substring(3, 2)}-{AñoPublicacion.Text.Substring(0, 2)}";
                return b.Comando($"INSERT INTO libros VALUES (NULL, '{Titulo.Text}', '{ISBN.Text}', '{Autor.Text}', '{Editorial.Text}', '{Genero.Text}', '{Idioma.Text}', '{fr}', {Cantidad})");
            }
            catch
            {
                return "Ha ocurrido un error";
            }
        }

        public void Borrar(int id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"¿Está seguro de borrar {Dato}?\nUna vez borrado, ¡no se podrá recuperar!", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"delete from libros where idLibro = {id}");
                MessageBox.Show("Registro Eliminado.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(int id, TextBox Titulo, TextBox ISBN, TextBox Autor, TextBox Editorial, TextBox Genero, TextBox Idioma, DateTimePicker AñoPublicacion, TextBox Cantidad)
        {
            String fr = $"{AñoPublicacion.Text.Substring(6, 4)}-{AñoPublicacion.Text.Substring(3, 2)}-{AñoPublicacion.Text.Substring(0, 2)}";
            b.Comando($"update libros set TituloLibro = '{Titulo.Text}', ISBN = '{ISBN.Text}', Autor = '{Autor.Text}', Editorial = '{Editorial.Text}', Genero = '{Genero.Text}', Idioma = '{Idioma.Text}', AñoPublicacion = '{fr}', Cantidad = {int.Parse(Cantidad.Text)} where idLibro = {id}");
            MessageBox.Show("Registro modificado!", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
