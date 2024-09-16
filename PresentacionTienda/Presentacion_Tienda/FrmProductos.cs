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
    }
}
