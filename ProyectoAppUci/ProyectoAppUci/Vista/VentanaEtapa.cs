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
    public partial class VentanaEtapa : Form
    {
        GestorEtapa ge = new GestorEtapa();
        GestorCarrera gc = new GestorCarrera();
        GestorTipoEtapa gte = new GestorTipoEtapa();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaEtapa()
        {
            InitializeComponent();
            ListarEtapas();
            ActivarCampos(true);
            OcultarColumnas();
            CargarComboCarrera();
            CargarComboTipoEtapa();
        }
        private void ListarEtapas()
        {
            List<EtapaDto> lista = ge.ListaEtapa();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Carrera");
            modelo.Columns.Add("Etapa");
            modelo.Columns.Add("Desde");
            modelo.Columns.Add("Hasta");
            modelo.Columns.Add("Tipo de Etapa");
            modelo.Columns.Add("Fecha");
            modelo.Columns.Add("KM");

            dgvLista.DataSource = modelo;
            foreach (EtapaDto e in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = e.IdEtapa;
                fila[1] = e.IdCarrera;
                fila[2] = e.NumeroEtapa;
                fila[3] = e.Desde;
                fila[4] = e.Hasta;
                fila[5] = e.NombreTipoEtapa;
                fila[6] = e.Fecha;
                fila[7] = e.Km;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboCarrera.SelectedIndex = 0;
            txtNumero.Text = "";
            txtDesde.Text = "";
            txtHasta.Text = "";
            cboTipo.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            txtKm.Text = "";
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
            DataGridViewColumn Columna2 = dgvLista.Columns[1];
            Columna.Visible = false;
            Columna2.Visible = false;
        }
        private void CargarComboCarrera()
        {
            cboCarrera.Items.Clear();
            List<CarreraDto> lista = gc.ListaCarrera();
            cboCarrera.DataSource = lista;
            cboCarrera.DisplayMember = "nombreCarrera";
            cboCarrera.ValueMember = "idCarrera";
        }
        private void CargarComboTipoEtapa()
        {
            cboTipo.Items.Clear();
            List<TipoEtapa> lista = gte.ListaTipoEtapa();
            cboTipo.DataSource = lista;
            cboTipo.DisplayMember = "nombreTipoEtapa";
            cboTipo.ValueMember = "idTipoEtapa";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idEtapa = 0;
                int idCarrera = Convert.ToInt32(cboCarrera.SelectedValue);
                int numeroEtapa = Convert.ToInt32(txtNumero.Text);
                string desde = txtDesde.Text;
                string hasta = txtHasta.Text;
                int idTipoEtapa = Convert.ToInt32(cboTipo.SelectedValue);
                DateTime fecha = dtpFecha.Value;
                int km = Convert.ToInt32(txtKm.Text);
                Etapa et = new Etapa(idEtapa, idCarrera, numeroEtapa, desde, hasta, idTipoEtapa, fecha, km);
                ge.AgregarEtapa(et);
                ListarEtapas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                int idCarrera = Convert.ToInt32(cboCarrera.SelectedValue);
                int numeroEtapa = Convert.ToInt32(txtNumero.Text);
                string desde = txtDesde.Text;
                string hasta = txtHasta.Text;
                int idTipoEtapa = Convert.ToInt32(cboTipo.SelectedValue);
                DateTime fecha = dtpFecha.Value;
                int km = Convert.ToInt32(txtKm.Text);
                Etapa et = new Etapa(idEtapa, idCarrera, numeroEtapa, desde, hasta, idTipoEtapa, fecha, km);
                ge.ModificarEtapa(et);
                ListarEtapas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                int idEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                int idCarrera = 0;
                int numeroEtapa = 0;
                string desde = "";
                string hasta = "";
                int idTipoEtapa = 0;
                DateTime fecha = dtpFecha.Value;
                int km = 0;
                Etapa et = new Etapa(idEtapa, idCarrera, numeroEtapa, desde, hasta, idTipoEtapa, fecha, km);
                ge.EliminarEtapa(et);
                ListarEtapas();
                LimpiarCampos();
                ActivarCampos(true);
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
            int idCarrera =Convert.ToInt32(dgvLista.CurrentRow.Cells[1].Value.ToString());
            int numeroEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[2].Value.ToString());
            string desde = dgvLista.CurrentRow.Cells[3].Value.ToString();
            string hasta = dgvLista.CurrentRow.Cells[4].Value.ToString();
            string nombreTipoEtapa= dgvLista.CurrentRow.Cells[5].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dgvLista.CurrentRow.Cells[6].Value.ToString());
            int km= Convert.ToInt32(dgvLista.CurrentRow.Cells[7].Value.ToString());

            cboCarrera.SelectedValue = idCarrera;
            txtNumero.Text = numeroEtapa.ToString();
            txtDesde.Text = desde;
            txtHasta.Text = hasta;
            cboTipo.Text = nombreTipoEtapa;
            dtpFecha.Text = Convert.ToDateTime(fecha).ToString();
            txtKm.Text = km.ToString();
        }
    }
}
