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
    public partial class VentanaCarrera : Form
    {
        GestorCarrera gc = new GestorCarrera();
        GestorCategoriaCarrera gcc = new GestorCategoriaCarrera();
        GestorPais gp = new GestorPais();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCarrera()
        {
            InitializeComponent();
            ListarCarreras();
            ActivarCampos(true);
            OcultarColumnas();
            CargarComboCategoriaCarrera();
            CargarComboPais();
        }
        private void ListarCarreras()
        {
            List<CarreraDto> lista = gc.ListaCarrera();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Carrera");
            modelo.Columns.Add("Edición");
            modelo.Columns.Add("Categoría");
            modelo.Columns.Add("Inicio");
            modelo.Columns.Add("Final");
            modelo.Columns.Add("País");

            dgvLista.DataSource = modelo;
            foreach (CarreraDto c in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = c.IdCarrera;
                fila[1] = c.NombreCarrera;
                fila[2] = c.Edicion;
                fila[3] = c.nombreCategoriaCarrera;
                fila[4] = c.FechaInicio;
                fila[5] = c.FechaFinal;
                fila[6] = c.CodPais;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtEdicion.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
        }
        private void ActivarCampos(bool x)
        {
            btnAgregar.Enabled = x;
            btnModificar.Enabled = x;
            btnEliminar.Enabled = x;
            btnSalir.Enabled = x;
            btnAceptar.Enabled = !x;
            btnCancelar.Enabled = !x;
            pnlDatos.Enabled = !x;
        }
        private void OcultarColumnas()
        {
            DataGridViewColumn Columna = dgvLista.Columns[0];
            DataGridViewColumn Columna2 = dgvLista.Columns[4];
            DataGridViewColumn Columna3 = dgvLista.Columns[5];
            Columna.Visible = false;
            Columna2.Visible = false;
            Columna3.Visible = false;
        }
        private void CargarComboCategoriaCarrera()
        {
            cboCategoria.Items.Clear();
            List<CategoriaCarrera> lista = gcc.ListaCategoriaCarrera();
            cboCategoria.DataSource = lista;
            cboCategoria.DisplayMember = "nombreCategoriaCarrera";
            cboCategoria.ValueMember = "idCategoriaCarrera";
        }
        private void CargarComboPais()
        {
            cboPais.Items.Clear();
            List<Pais> lista = gp.ListaPais();
            cboPais.DataSource = lista;
            cboPais.DisplayMember = "nombrePais";
            cboPais.ValueMember = "codPais";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idCarrera = 0;
                string nombreCarrera = txtNombre.Text;
                string edicion = txtEdicion.Text;
                int idCategoriaCarrera = Convert.ToInt32(cboCategoria.SelectedValue);
                DateTime fechaInicio = dtpInicio.Value;
                DateTime fechaFinal = dtpFinal.Value;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                Carrera c = new Carrera(idCarrera, nombreCarrera, edicion, idCategoriaCarrera, fechaInicio, fechaFinal, codPais);
                gc.AgregarCarrera(c);
                ListarCarreras();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idCarrera = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCarrera = txtNombre.Text;
                string edicion = txtEdicion.Text;
                int idCategoriaCarrera = Convert.ToInt32(cboCategoria.SelectedValue);
                DateTime fechaInicio = dtpInicio.Value;
                DateTime fechaFinal = dtpFinal.Value;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                Carrera c = new Carrera(idCarrera, nombreCarrera, edicion, idCategoriaCarrera, fechaInicio, fechaFinal, codPais);
                gc.ModificarCarrera(c);
                ListarCarreras();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idCarrera = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCarrera = "";
                string edicion = "";
                int idCategoriaCarrera = 0;
                DateTime fechaInicio = dtpInicio.Value;
                DateTime fechaFinal = dtpFinal.Value;
                string codPais = "";
                Carrera c = new Carrera(idCarrera, nombreCarrera, edicion, idCategoriaCarrera, fechaInicio, fechaFinal, codPais);
                gc.EliminarCarrera(c);
                ListarCarreras();
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
            string nombreCarrera = dgvLista.CurrentRow.Cells[1].Value.ToString();
            string edicion = dgvLista.CurrentRow.Cells[2].Value.ToString();
            string nombreCategoriaCarrera = dgvLista.CurrentRow.Cells[3].Value.ToString();
            DateTime fechaInicio = Convert.ToDateTime(dgvLista.CurrentRow.Cells[4].Value.ToString());
            DateTime fechaFinal = Convert.ToDateTime(dgvLista.CurrentRow.Cells[5].Value.ToString());
            string codPais = dgvLista.CurrentRow.Cells[6].Value.ToString();
            txtNombre.Text = nombreCarrera;
            txtEdicion.Text = edicion;
            cboCategoria.Text = nombreCategoriaCarrera;
            dtpInicio.Text = Convert.ToDateTime(fechaInicio).ToString();
            dtpFinal.Text = Convert.ToDateTime(fechaFinal).ToString();
            cboPais.SelectedValue = codPais;
        }
    }
}
