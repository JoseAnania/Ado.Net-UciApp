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
    public partial class VentanaResultadoEtapa : Form
    {
        GestorResultadoEtapa gre = new GestorResultadoEtapa();
        GestorEtapa ge = new GestorEtapa();
        GestorCiclista gci = new GestorCiclista();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaResultadoEtapa()
        {
            InitializeComponent();
            ListarResultadoEtapas();
            ActivarCampos(true);
            OcultarColumnas();
            CargarComboEtapa();
            CargarComboCiclista();
        }
        private void ListarResultadoEtapas()
        {
            List<ResultadoEtapaDto> lista = gre.ListaResultadoEtapa();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Etapa");
            modelo.Columns.Add("Carrera");
            modelo.Columns.Add("Ciclista");
            modelo.Columns.Add("Puesto/Maillot");
            modelo.Columns.Add("Tiempo");
            modelo.Columns.Add("Puntos");

            dgvLista.DataSource = modelo;
            foreach (ResultadoEtapaDto re in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = re.NumeroEtapa;
                fila[1] = re.NombreCarrera;
                fila[2] = re.NomApeCiclista;
                fila[3] = re.PuestoMaillot;
                fila[4] = re.Tiempo;
                fila[5] = re.Puntos;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboEtapa.SelectedIndex = 0;
            cboCiclista.SelectedIndex = 0;
            txtPuesto.Text = "";
            dtpTiempo.Value = DateTime.Now;
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
        private void OcultarColumnas()
        {
            DataGridViewColumn columna = dgvLista.Columns[4];
            DataGridViewColumn columna2 = dgvLista.Columns[5];
            columna.Visible = false;
            columna2.Visible = false;
        }
        private void CargarComboEtapa()
        {
            cboEtapa.Items.Clear();
            List<EtapaDto> lista = ge.ListaEtapa();
            cboEtapa.DataSource = lista;
            cboEtapa.DisplayMember = "numeroEtapa";
            cboEtapa.ValueMember = "idEtapa";
        }
        private void CargarComboCiclista()
        {
            cboCiclista.Items.Clear();
            List<CiclistaDto> lista = gci.ComboCiclista();
            cboCiclista.DataSource = lista;
            cboCiclista.DisplayMember = "nomApeCiclista";
            cboCiclista.ValueMember = "idCiclista";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idEtapa = Convert.ToInt32(cboEtapa.SelectedValue); ;
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string puestoMaillot = txtPuesto.Text;
                DateTime tiempo = dtpTiempo.Value;
                int puntos = Convert.ToInt32(txtPuntos.Text);
                ResultadoEtapa re = new ResultadoEtapa(idEtapa, idCiclista, puestoMaillot, tiempo, puntos);
                gre.AgregarResultadoEtapa(re);
                ListarResultadoEtapas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idEtapa = Convert.ToInt32(cboEtapa.SelectedValue); 
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string puestoMaillot = txtPuesto.Text;
                DateTime tiempo = dtpTiempo.Value;
                int puntos = Convert.ToInt32(txtPuntos.Text);
                ResultadoEtapa re = new ResultadoEtapa(idEtapa, idCiclista, puestoMaillot, tiempo, puntos);
                gre.ModificarResultadoEtapa(re);
                ListarResultadoEtapas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                int idEtapa = Convert.ToInt32(cboEtapa.SelectedValue);
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                string puestoMaillot = "";
                DateTime tiempo = dtpTiempo.Value;
                int puntos = 0;
                ResultadoEtapa re = new ResultadoEtapa(idEtapa, idCiclista, puestoMaillot, tiempo, puntos);
                gre.EliminarResultadoEtapa(re);
                ListarResultadoEtapas();
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
            lblEtapa.Enabled = false;
            cboEtapa.Enabled = false;
            lblCiclista.Enabled = false;
            cboCiclista.Enabled = false;
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
            int numeroEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
            string nomApeCiclista = dgvLista.CurrentRow.Cells[2].Value.ToString();
            string puestoMaillot = dgvLista.CurrentRow.Cells[3].Value.ToString();
            DateTime tiempo = Convert.ToDateTime(dgvLista.CurrentRow.Cells[4].Value.ToString());
            int puntos= Convert.ToInt32(dgvLista.CurrentRow.Cells[5].Value.ToString());
            cboEtapa.Text = numeroEtapa.ToString();
            cboCiclista.Text = nomApeCiclista;
            txtPuesto.Text = puestoMaillot;
            dtpTiempo.Text = Convert.ToDateTime(tiempo).ToString();
            txtPuntos.Text = puntos.ToString();
        }
    }
}
