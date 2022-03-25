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
    public partial class VentanaCategoriaPuerto : Form
    {
        GestorCategoriaPuerto gcp = new GestorCategoriaPuerto();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCategoriaPuerto()
        {
            InitializeComponent();
            ListarCategoriaPuertos();
            ActivarCampos(true);
            OcultarColumnas();
        }
        private void ListarCategoriaPuertos()
        {
            List<CategoriaPuerto> lista = gcp.ListaCategoriaPuerto();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Categoría");
            dgvLista.DataSource = modelo;
            foreach (CategoriaPuerto cp in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = cp.IdCategoriaPuerto;
                fila[1] = cp.NombreCategoriaPuerto;
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
                int idCategoriaPuerto = 0;
                string nombreCategoriaPuerto = txtNombre.Text;
                CategoriaPuerto cp = new CategoriaPuerto(idCategoriaPuerto, nombreCategoriaPuerto);
                gcp.AgregarCategoriaPuerto(cp);
                ListarCategoriaPuertos();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idCategoriaPuerto = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCategoriaPuerto = txtNombre.Text;
                CategoriaPuerto cp = new CategoriaPuerto(idCategoriaPuerto, nombreCategoriaPuerto);
                gcp.ModificarCategoriaPuerto(cp);
                ListarCategoriaPuertos();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idCategoriaPuerto = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCategoriaPuerto = "";
                CategoriaPuerto cp = new CategoriaPuerto(idCategoriaPuerto, nombreCategoriaPuerto);
                gcp.EliminarCategoriaPuerto(cp);
                ListarCategoriaPuertos();
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
            string nombreCategoriaPuerto = dgvLista.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombreCategoriaPuerto;
        }
    }
}
