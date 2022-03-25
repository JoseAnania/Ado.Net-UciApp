using ProyectoAppUci.Controlador;
using ProyectoAppUci.Dto;
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
    public partial class VentanaCategoriaEquipoEquipo : Form
    {
        GestorCategoriaEquipoEquipo gcee = new GestorCategoriaEquipoEquipo();
        GestorEquipo ge = new GestorEquipo();
        GestorCategoriaEquipo gce = new GestorCategoriaEquipo();
        private bool btnAgregarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCategoriaEquipoEquipo()
        {
            InitializeComponent();
            ListarCategoriasEqEq();
            ActivarCampos(true);
            OcultarColumnas();
            CargarComboEquipo();
            CargarComboCategoriaEquipo();
        }
        private void ListarCategoriasEqEq()
        {
            List<CatEqEqDto> lista = gcee.ListaCategoriaEquipoEquipo();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Equipo");
            modelo.Columns.Add("Categoría");
            modelo.Columns.Add("Año");
            dgvLista.DataSource = modelo;
            foreach (CatEqEqDto cee in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = cee.CodEquipo;
                fila[1] = cee.NombreCategoriaEquipo;
                fila[2] = cee.Anio;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboEquipo.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            dtpAnio.Value = DateTime.Now;
        }
        private void ActivarCampos(bool x)
        {
            btnAgregar.Enabled = x;
            btnEliminar.Enabled = x;
            btnSalir.Enabled = x;
            pnlDatos.Enabled = !x;
            btnAceptar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }
        private void OcultarColumnas()
        {
            DataGridViewColumn columna = dgvLista.Columns[2];
            columna.Visible = false;
        }
        private void CargarComboEquipo()
        {
            cboEquipo.Items.Clear();
            List<Equipo> lista = ge.ListaEquipo();
            cboEquipo.DataSource = lista;
            cboEquipo.DisplayMember = "nombreEquipo";
            cboEquipo.ValueMember = "codEquipo";
        }
        private void CargarComboCategoriaEquipo()
        {
            cboCategoria.Items.Clear();
            List<CategoriaEquipo> lista = gce.ListaCategoriaEquipo();
            cboCategoria.DataSource = lista;
            cboCategoria.DisplayMember = "nombreCategoriaEquipo";
            cboCategoria.ValueMember = "idCategoriaEquipo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                string codEquipo = Convert.ToString(cboEquipo.SelectedValue);
                int idCategoriaEquipo = Convert.ToInt32(cboCategoria.SelectedValue);
                DateTime anio = dtpAnio.Value;
                CategoriaEquipoEquipo cee = new CategoriaEquipoEquipo(codEquipo, idCategoriaEquipo, anio);
                gcee.AgregarCatEqEq(cee);
                ListarCategoriasEqEq();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                string codEquipo = Convert.ToString(cboEquipo.SelectedValue);
                int idCategoriaEquipo = Convert.ToInt32(cboCategoria.SelectedValue);
                DateTime anio = dtpAnio.Value;
                CategoriaEquipoEquipo cee = new CategoriaEquipoEquipo(codEquipo, idCategoriaEquipo, anio);
                gcee.EliminarCatEqEq(cee);
                ListarCategoriasEqEq();
                LimpiarCampos();
            }
            ActivarCampos(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ActivarCampos(true);
            btnAgregarClick = false;
            btnEliminarClick = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActivarCampos(false);
            btnAgregarClick = true;
            btnEliminarClick = false;
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ActivarCampos(false);
            btnAgregarClick = false;
            btnEliminarClick = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codEquipo = dgvLista.CurrentRow.Cells[0].Value.ToString();
            string nombreCategoriaEquipo = dgvLista.CurrentRow.Cells[1].Value.ToString();
            DateTime anio = Convert.ToDateTime(dgvLista.CurrentRow.Cells[2].Value.ToString());
            cboEquipo.SelectedValue = codEquipo;
            cboCategoria.Text = nombreCategoriaEquipo;
            dtpAnio.Text = Convert.ToDateTime(anio).ToString();
        }
    }
}
