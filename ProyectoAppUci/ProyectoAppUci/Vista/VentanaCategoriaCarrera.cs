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
    public partial class VentanaCategoriaCarrera : Form
    {
        GestorCategoriaCarrera gcc = new GestorCategoriaCarrera();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCategoriaCarrera()
        {
            InitializeComponent();
            ListarCategoriaCarreras();
            ActivarCampos(true);
            OcultarColumnas();
        }
        private void ListarCategoriaCarreras()
        {
            List<CategoriaCarrera> lista = gcc.ListaCategoriaCarrera();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Categoría");
            dgvLista.DataSource = modelo;
            foreach (CategoriaCarrera cc in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = cc.IdCategoriaCarrera;
                fila[1] = cc.NombreCategoriaCarrera;
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
                int idCategoriaCarrera = 0;
                string nombreCategoriaCarrera = txtNombre.Text;
                CategoriaCarrera cc = new CategoriaCarrera(idCategoriaCarrera, nombreCategoriaCarrera);
                gcc.AgregarCategoriaCarrera(cc);
                ListarCategoriaCarreras();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idCategoriaCarrera = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCategoriaCarrera = txtNombre.Text;
                CategoriaCarrera cc = new CategoriaCarrera(idCategoriaCarrera, nombreCategoriaCarrera);
                gcc.ModificarCategoriaCarrera(cc);
                ListarCategoriaCarreras();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idCategoriaCarrera = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCategoriaCarrera = "";
                CategoriaCarrera cc = new CategoriaCarrera(idCategoriaCarrera, nombreCategoriaCarrera);
                gcc.EliminarCategoriaCarrera(cc);
                ListarCategoriaCarreras();
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
            string nombreCategoriaCarrera = dgvLista.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombreCategoriaCarrera;
        }
    }
}
