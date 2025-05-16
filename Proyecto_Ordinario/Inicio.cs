using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Ordinario
{
    public partial class Inicio : Form
    {
        Acciones acc = new Acciones();
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DGDatos.DataSource = null;
            DGDatos.DataSource = acc.Consultar();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (acc.ImportardeExcel())
            {
                MessageBox.Show("Importado con exito...");
            }
            else
            {
                MessageBox.Show("Fallo importando...");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (acc.EliminarAuto(Convert.ToInt32(txbIDElim.Text)))
            {
                MessageBox.Show("Eliminado con éxito");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (acc.InsertarAuto(Convert.ToInt32(txbNuevoID.Text), txbMarca.Text, txbModelo.Text, Convert.ToInt32(txbAnio.Text), txbColor.Text, Convert.ToDouble(txbPrecio.Text), txbEstado.Text))
            {
                MessageBox.Show("Agregado con éxito");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int nuevoId = Convert.ToInt32(txbNuevoID.Text);
            string nuevaMarca = txbMarca.Text;
            string nuevoModelo = txbModelo.Text;
            int nuevoAnio = Convert.ToInt32(txbAnio.Text);
            string nuevoColor = txbColor.Text;
            double nuevoPrecio = Convert.ToDouble(txbPrecio.Text);
            string nuevoEstado = txbEstado.Text;
            if (acc.ActualizarAuto(nuevoId, nuevaMarca, nuevoModelo, nuevoAnio, nuevoColor, nuevoPrecio, nuevoEstado))
            {
                MessageBox.Show("Actualizado con éxito");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (acc.ExportarExcel())
            {
                MessageBox.Show("Exportado con exito...");
            }
            else
            {
                MessageBox.Show("Fallo exportando...");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbIDElim.Text = "";
            txbIDActual.Text = "";
            txbNuevoID.Text = "";
            txbMarca.Text = "";
            txbModelo.Text = "";
            txbAnio.Text = "";
            txbColor.Text = "";
            txbPrecio.Text = "";
            txbEstado.Text = "";
        }
    }
}
