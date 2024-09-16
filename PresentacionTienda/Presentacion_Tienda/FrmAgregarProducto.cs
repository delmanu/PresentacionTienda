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
    public partial class FrmAgregarProducto : Form
    {
        ManejadorProductos mp;
        public FrmAgregarProducto()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
             // Permitir solo números, el punto decimal y la tecla de retroceso
             if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
             {
                e.Handled = true;
             }

             // Solo permitir un punto decimal
             if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
             {
                e.Handled = true;
             }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mp.Guardar(txtNombre, txtDescripcion, txtPrecio));
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
