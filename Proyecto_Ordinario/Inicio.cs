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
    }
}
