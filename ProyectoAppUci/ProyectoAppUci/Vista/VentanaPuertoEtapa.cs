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
    public partial class VentanaPuertoEtapa : Form
    {
        GestorPuertoEtapa gpe = new GestorPuertoEtapa();
        GestorEtapa ge = new GestorEtapa();
        GestorPuerto gp = new GestorPuerto();
        GestorCiclista gc = new GestorCiclista();
        private bool btnAgregarClick = false;
        private bool btnEliminarClick = false;
        public VentanaPuertoEtapa()
        {
            InitializeComponent();
            ListarPuertosEtapas();
            ActivarCampos(true);
            OcultarColumnas();
            CargarComboEtapa();
            CargarComboPuerto();
            CargarComboCiclista();
        }
        private void ListarPuertosEtapas()
        {
            List<PuertoEtapaDto> lista = gpe.ListaPuertoEtapa();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Etapa");
            modelo.Columns.Add("Puerto");
            modelo.Columns.Add("Ciclista");
            modelo.Columns.Add("Puesto");
            dgvLista.DataSource = modelo;
            foreach (PuertoEtapaDto pe in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = pe.IdEtapa;
                fila[1] = pe.NombrePuerto;
                fila[2] = pe.nomApeCiclista;
                fila[3] = pe.Puesto;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboEtapa.SelectedIndex = 0;
            cboPuerto.SelectedIndex = 0;
            cboCiclista.SelectedIndex = 0;
            txtPuesto.Text = "";
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
            DataGridViewColumn columna = dgvLista.Columns[0];
            columna.Visible = false;
        }
        private void CargarComboEtapa()
        {
            cboEtapa.Items.Clear();
            List<EtapaDto> lista = ge.ListaEtapa();
            cboEtapa.DataSource = lista;
            cboEtapa.DisplayMember = "numeroEtapa";
            cboEtapa.ValueMember = "idEtapa";
        }
        private void CargarComboPuerto()
        {
            cboPuerto.Items.Clear();
            List<PuertoDto> lista = gp.ListaPuerto();
            cboPuerto.DataSource = lista;
            cboPuerto.DisplayMember = "nombrePuerto";
            cboPuerto.ValueMember = "idPuerto";
        }
        private void CargarComboCiclista()
        {
            cboCiclista.Items.Clear();
            List<CiclistaDto> lista = gc.ComboCiclista();
            cboCiclista.DataSource = lista;
            cboCiclista.DisplayMember = "nomApeCiclista";
            cboCiclista.ValueMember = "idCiclista";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idEtapa = Convert.ToInt32(cboEtapa.SelectedValue);
                int idPuerto = Convert.ToInt32(cboPuerto.SelectedValue);
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string puesto = txtPuesto.Text;
                PuertoEtapa pe = new PuertoEtapa(idEtapa, idPuerto, idCiclista, puesto);
                gpe.AgregarPuertoEtapa(pe);
                ListarPuertosEtapas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                int idEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString()); 
                int idPuerto = Convert.ToInt32(cboPuerto.SelectedValue);
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string puesto = "";
                PuertoEtapa pe = new PuertoEtapa(idEtapa, idPuerto, idCiclista, puesto);
                gpe.EliminarPuertoEtapa(pe);
                ListarPuertosEtapas();
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
            string nombrePuerto = dgvLista.CurrentRow.Cells[1].Value.ToString();
            string nomApeCiclista = dgvLista.CurrentRow.Cells[2].Value.ToString();
            string puesto= dgvLista.CurrentRow.Cells[3].Value.ToString();
            cboPuerto.Text = nombrePuerto;
            cboCiclista.Text = nomApeCiclista;
            txtPuesto.Text = puesto;
        }
    }
}
