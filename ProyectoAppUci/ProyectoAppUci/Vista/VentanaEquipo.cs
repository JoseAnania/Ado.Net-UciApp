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
    public partial class VentanaEquipo : Form
    {
        GestorEquipo ge = new GestorEquipo();
        GestorPais gp = new GestorPais();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaEquipo()
        {
            InitializeComponent();
            ListarEquipos();
            ActivarCampos(true);
            CargarComboPais();
            DesactivarCampos();
            OcultarColumnas();
        }
        private void ListarEquipos()
        {
            List<Equipo> lista = ge.ListaEquipo();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Código UCI");
            modelo.Columns.Add("Equipo");
            modelo.Columns.Add("País");
            modelo.Columns.Add("Alta");
            modelo.Columns.Add("Baja");
            dgvLista.DataSource = modelo;
            foreach (Equipo e in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = e.CodEquipo;
                fila[1] = e.NombreEquipo;
                fila[2] = e.CodPais;
                fila[3] = e.AnioAlta;
                fila[4] = e.AnioBaja;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }
        private void ActivarCampos(bool x)
        {
            btnAgregar.Enabled = x;
            btnModificar.Enabled = x;
            btnEliminar.Enabled = x;
            btnSalir.Enabled = x;
            pnlDatos.Enabled = !x;
            btnAceptar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }
        private void DesactivarCampos()
        {
            lblBaja.Enabled = false;
            dtpBaja.Enabled = false;
        }
        private void CargarComboPais()
        {
            cboPais.Items.Clear();
            List<Pais> lista = gp.ListaPais();
            cboPais.DataSource = lista;
            cboPais.DisplayMember = "nombrePais";
            cboPais.ValueMember = "codPais";
        }
        private void OcultarColumnas()
        {
            DataGridViewColumn columna = dgvLista.Columns[3];
            DataGridViewColumn columna2 = dgvLista.Columns[4];
            columna.Visible = false;
            columna2.Visible = false;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                string codEquipo = txtCodigo.Text;
                string nombreEquipo = txtNombre.Text;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                Equipo eq = new Equipo(codEquipo, nombreEquipo, codPais, anioAlta, anioBaja);
                ge.AgregarEquipo(eq);
                ListarEquipos();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                string codEquipo = txtCodigo.Text;
                string nombreEquipo = txtNombre.Text;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                string codEquipoAnterior = dgvLista.CurrentRow.Cells[0].Value.ToString();
                EquipoDto eq = new EquipoDto(codEquipo, nombreEquipo, codPais, anioAlta, anioBaja, codEquipoAnterior);
                ge.ModificarEquipo(eq);
                ListarEquipos();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                string codEquipo = dgvLista.CurrentRow.Cells[0].Value.ToString();
                string nombreEquipo = "";
                string codPais = "";
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                Equipo eq = new Equipo(codEquipo, nombreEquipo, codPais, anioAlta, anioBaja);
                ge.EliminarEquipo(eq);
                ListarEquipos();
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
            string codEquipo= dgvLista.CurrentRow.Cells[0].Value.ToString();
            string nombreEquipo = dgvLista.CurrentRow.Cells[1].Value.ToString();
            string codPais = dgvLista.CurrentRow.Cells[2].Value.ToString();
            DateTime anioAlta = Convert.ToDateTime(dgvLista.CurrentRow.Cells[3].Value.ToString());
            DateTime anioBaja = Convert.ToDateTime(dgvLista.CurrentRow.Cells[4].Value.ToString());
            txtCodigo.Text = codEquipo;
            txtNombre.Text = nombreEquipo;
            cboPais.SelectedValue = codPais;
            dtpAlta.Text = Convert.ToDateTime(anioAlta).ToString();
            dtpBaja.Text = Convert.ToDateTime(anioBaja).ToString();
        }
    }
}
