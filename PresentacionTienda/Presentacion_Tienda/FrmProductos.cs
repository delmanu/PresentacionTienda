using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace Presentacion_Tienda
{
    public partial class FrmProductos : Form
    {
        ManejadorProductos mp;
        int fila, columna, id;  string nombre, descripcion; double costo;
        public FrmProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            mp.Mostrar(dtgvProductos, txtBuscar.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto fap = new FrmAgregarProducto(); //XD
            fap.ShowDialog();
            mp.Mostrar(dtgvProductos, txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mp.Mostrar(dtgvProductos, txtBuscar.Text);
        }

        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            if (columna >= 0 && fila > -1)
            {
                btnEliminar.Enabled = true; btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false; btnModificar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
            nombre = dtgvProductos.Rows[fila].Cells[1].Value.ToString();
            mp.Borrar(id, nombre);
            mp.Mostrar(dtgvProductos, txtBuscar.Text);

        }
    }
}
