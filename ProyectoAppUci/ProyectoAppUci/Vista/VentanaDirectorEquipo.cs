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
    public partial class VentanaDirectorEquipo : Form
    {
        GestorDirectorEquipo gde = new GestorDirectorEquipo();
        GestorDirector gd = new GestorDirector();
        GestorEquipo ge = new GestorEquipo();
        private bool btnAgregarClick = false;
        private bool btnEliminarClick = false;
        public VentanaDirectorEquipo()
        {
            InitializeComponent();
            ListarDirectoresEquipos();
            ActivarCampos(true);
            DesactivarCampos();
            OcultarColumnas();
            CargarComboDirector();
            CargarComboEquipo();
        }
        private void ListarDirectoresEquipos()
        {
            List<DirectorEquipoDto> lista = gde.ListaDirectorEquipo();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Director");
            modelo.Columns.Add("Equipo");
            modelo.Columns.Add("Alta");
            modelo.Columns.Add("Baja");
            dgvLista.DataSource = modelo;
            foreach (DirectorEquipoDto de in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = de.NomApeDirector;
                fila[1] = de.NombreEquipo;
                fila[2] = de.AnioAlta;
                fila[3] = de.AnioBaja;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboDirector.SelectedIndex = 0;
            cboEquipo.SelectedIndex = 0;
            dtpAlta.Value = DateTime.Now;
            dtpBaja.Value = DateTime.Now;
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
        private void DesactivarCampos()
        {
            lblBaja.Enabled = false;
            dtpBaja.Enabled = false;
        }
        private void OcultarColumnas()
        {
            DataGridViewColumn columna = dgvLista.Columns[3];
            columna.Visible = false;
        }
        private void CargarComboDirector()
        {
            cboDirector.Items.Clear();
            List<DirectorDto> lista = gd.ComboDirector();
            cboDirector.DataSource = lista;
            cboDirector.DisplayMember = "nomApeDirector";
            cboDirector.ValueMember = "idDirector";
        }
        private void CargarComboEquipo()
        {
            cboEquipo.Items.Clear();
            List<Equipo> lista = ge.ListaEquipo();
            cboEquipo.DataSource = lista;
            cboEquipo.DisplayMember = "nombreEquipo";
            cboEquipo.ValueMember = "codEquipo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idDirector = Convert.ToInt32(cboDirector.SelectedValue);
                string codEquipo = Convert.ToString(cboEquipo.SelectedValue);
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                DirectorEquipo de = new DirectorEquipo(idDirector, codEquipo, anioAlta, anioBaja);
                gde.AgregarDirectorEquipo(de);
                ListarDirectoresEquipos();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                int idDirector =Convert.ToInt32(cboDirector.SelectedValue);
                string codEquipo = Convert.ToString(cboEquipo.SelectedValue);
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                DirectorEquipo de = new DirectorEquipo(idDirector, codEquipo, anioAlta, anioBaja);
                gde.EliminarDirectorEquipo(de);
                ListarDirectoresEquipos();
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
            string nomApeDirector = dgvLista.CurrentRow.Cells[0].Value.ToString();
            string nombreEquipo = dgvLista.CurrentRow.Cells[1].Value.ToString();
            DateTime anioAlta = Convert.ToDateTime(dgvLista.CurrentRow.Cells[2].Value.ToString());
            DateTime anioBaja = Convert.ToDateTime(dgvLista.CurrentRow.Cells[3].Value.ToString());
            cboDirector.Text = nomApeDirector;
            cboEquipo.Text = nombreEquipo;
            dtpAlta.Text = Convert.ToDateTime(anioAlta).ToString();
            dtpBaja.Text = Convert.ToDateTime(anioBaja).ToString();
        }
    }
}
