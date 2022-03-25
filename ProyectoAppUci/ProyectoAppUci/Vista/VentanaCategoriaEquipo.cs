using ProyectoAppUci.Controlador;
using ProyectoAppUci.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAppUci.Vista
{
    public partial class VentanaCategoriaEquipo : Form
    {
        GestorCategoriaEquipo gce = new GestorCategoriaEquipo();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCategoriaEquipo()
        {
            InitializeComponent();
            ListarCategoriaEquipos();
            ActivarCampos(true);
            OcultarColumnas();
        }
        private void ListarCategoriaEquipos()
        {
            List<CategoriaEquipo> lista = gce.ListaCategoriaEquipo();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Categoría");
            dgvLista.DataSource = modelo;
            foreach (CategoriaEquipo ce in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = ce.IdCategoriaEquipo;
                fila[1] = ce.NombreCategoriaEquipo;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
        }
        private void ActivarCampos(bool x)
        {
            btnAgregar.Enabled = x;
            btnModificar.Enabled = x;
            btnEliminar.Enabled = x;
            btnSalir.Enabled = x;
            txtNombre.Enabled = !x;
            btnAceptar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }
        private void OcultarColumnas()
        {
            DataGridViewColumn Column = dgvLista.Columns[0];
            Column.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idCategoriaEquipo = 0;
                string nombreCategoriaEquipo = txtNombre.Text;
                CategoriaEquipo ce = new CategoriaEquipo(idCategoriaEquipo, nombreCategoriaEquipo);
                gce.AgregarCategoriaEquipo(ce);
                ListarCategoriaEquipos();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idCategoriaEquipo = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCategoriaEquipo = txtNombre.Text;
                CategoriaEquipo ce = new CategoriaEquipo(idCategoriaEquipo, nombreCategoriaEquipo);
                gce.ModificarCategoriaEquipo(ce);
                ListarCategoriaEquipos();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idCategoriaEquipo = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCategoriaEquipo = "";
                CategoriaEquipo ce = new CategoriaEquipo(idCategoriaEquipo, nombreCategoriaEquipo);
                gce.EliminarCategoriaEquipo(ce);
                ListarCategoriaEquipos();
                LimpiarCampos();
            }
            ActivarCampos(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ActivarCampos(true);
            btnAgregarClick = false;
            btnModificarClick = false;
            btnEliminarClick = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActivarCampos(false);
            btnAgregarClick = true;
            btnModificarClick = false;
            btnEliminarClick = false;
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActivarCampos(false);
            btnAgregarClick = false;
            btnModificarClick = true;
            btnEliminarClick = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ActivarCampos(false);
            btnAgregarClick = false;
            btnModificarClick = false;
            btnEliminarClick = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreCategoriaEquipo = dgvLista.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombreCategoriaEquipo;
        }
    }
}
