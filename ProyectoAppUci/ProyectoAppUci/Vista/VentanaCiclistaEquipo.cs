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
    public partial class VentanaCiclistaEquipo : Form
    {
        GestorCiclistaEquipo gce = new GestorCiclistaEquipo();
        GestorCiclista gc = new GestorCiclista();
        GestorEquipo ge = new GestorEquipo();
        private bool btnAgregarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCiclistaEquipo()
        {
            InitializeComponent();
            ListarCiclistasEquipos();
            ActivarCampos(true);
            DesactivarCampos();
            OcultarColumnas();
            CargarComboCiclista();
            CargarComboEquipo();
        }
        private void ListarCiclistasEquipos()
        {
            List<CiclistaEquipoDto> lista = gce.ListaCiclistaEquipo();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Ciclista");
            modelo.Columns.Add("Equipo");
            modelo.Columns.Add("Alta");
            modelo.Columns.Add("Baja");
            dgvLista.DataSource = modelo;
            foreach (CiclistaEquipoDto ce in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = ce.NomApeCiclista;
                fila[1] = ce.NombreEquipo;
                fila[2] = ce.AnioAlta;
                fila[3] = ce.AnioBaja;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboCiclista.SelectedIndex = 0;
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
        private void CargarComboCiclista()
        {
            cboCiclista.Items.Clear();
            List<CiclistaDto> lista = gc.ComboCiclista();
            cboCiclista.DataSource = lista;
            cboCiclista.DisplayMember = "nomApeCiclista";
            cboCiclista.ValueMember = "idCiclista";
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
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string codEquipo = Convert.ToString(cboEquipo.SelectedValue);
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                CiclistaEquipo ce = new CiclistaEquipo(idCiclista, codEquipo, anioAlta, anioBaja);
                gce.AgregarCiclistaEquipo(ce);
                ListarCiclistasEquipos();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string codEquipo = Convert.ToString(cboEquipo.SelectedValue);
                DateTime anioAlta = dtpAlta.Value;
                DateTime anioBaja = dtpBaja.Value;
                CiclistaEquipo ce = new CiclistaEquipo(idCiclista, codEquipo, anioAlta, anioBaja);
                gce.EliminarCiclistaEquipo(ce);
                ListarCiclistasEquipos();
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
            string nomApeCiclista = dgvLista.CurrentRow.Cells[0].Value.ToString();
            string nombreEquipo = dgvLista.CurrentRow.Cells[1].Value.ToString();
            DateTime anioAlta = Convert.ToDateTime(dgvLista.CurrentRow.Cells[2].Value.ToString());
            DateTime anioBaja = Convert.ToDateTime(dgvLista.CurrentRow.Cells[3].Value.ToString());
            cboCiclista.Text = nomApeCiclista;
            cboEquipo.Text = nombreEquipo;
            dtpAlta.Text = Convert.ToDateTime(anioAlta).ToString();
            dtpBaja.Text = Convert.ToDateTime(anioBaja).ToString();
        }
    }
}
