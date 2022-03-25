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
    public partial class VentanaPremioCarrera : Form
    {
        GestorPremioCarrera gpc = new GestorPremioCarrera();
        GestorCarrera gca = new GestorCarrera();
        GestorCiclista gci = new GestorCiclista();
        GestorPremio gp = new GestorPremio();
        private bool btnAgregarClick = false;
        private bool btnEliminarClick = false;
        public VentanaPremioCarrera()
        {
            InitializeComponent();
            ListarPremioCarreras();
            ActivarCampos(true);
            CargarComboCarrera();
            CargarComboCiclista();
            CargarComboPremio();
        }
        private void ListarPremioCarreras()
        {
            List<PremioCarreraDto> lista = gpc.ListaPremioCarrera();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Carrera");
            modelo.Columns.Add("Ciclista");
            modelo.Columns.Add("Premio");
            dgvLista.DataSource = modelo;
            foreach (PremioCarreraDto pc in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = pc.NombreCarrera;
                fila[1] = pc.ApeNomCiclista;
                fila[2] = pc.NombrePremio;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            cboCarrera.SelectedIndex = 0;
            cboCiclista.SelectedIndex = 0;
            cboPremio.SelectedIndex = 0;
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
        private void CargarComboCarrera()
        {
            cboCarrera.Items.Clear();
            List<CarreraDto> lista = gca.ListaCarrera();
            cboCarrera.DataSource = lista;
            cboCarrera.DisplayMember = "nombreCarrera";
            cboCarrera.ValueMember = "idCarrera";
        }
        private void CargarComboCiclista()
        {
            cboCiclista.Items.Clear();
            List<CiclistaDto> lista = gci.ComboCiclista();
            cboCiclista.DataSource = lista;
            cboCiclista.DisplayMember = "nomApeCiclista";
            cboCiclista.ValueMember = "idCiclista";
        }
        private void CargarComboPremio()
        {
            cboPremio.Items.Clear();
            List<Premio> lista = gp.ListaPremio();
            cboPremio.DataSource = lista;
            cboPremio.DisplayMember = "nombrePremio";
            cboPremio.ValueMember = "idPremio";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idCarrera = Convert.ToInt32(cboCarrera.SelectedValue);
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                int idPremio = Convert.ToInt32(cboPremio.SelectedValue);
                PremioCarrera pc = new PremioCarrera(idCarrera, idCiclista, idPremio);
                gpc.AgregarPremioCarrera(pc);
                ListarPremioCarreras();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnEliminarClick == true)
            {
                int idCarrera = Convert.ToInt32(cboCarrera.SelectedValue);
                int idCiclista = Convert.ToInt32(cboCiclista.SelectedValue);
                int idPremio = Convert.ToInt32(cboPremio.SelectedValue);
                PremioCarrera pc = new PremioCarrera(idCarrera, idCiclista, idPremio);
                gpc.EliminarPremioCarrera(pc);
                ListarPremioCarreras();
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
            string nombreCarrera = dgvLista.CurrentRow.Cells[0].Value.ToString();
            string apeNomCiclista = dgvLista.CurrentRow.Cells[1].Value.ToString();
            string nombrePremio = dgvLista.CurrentRow.Cells[2].Value.ToString();
            cboCarrera.Text = nombreCarrera;
            cboCiclista.Text = apeNomCiclista;
            cboPremio.Text = nombrePremio;
        }
    }
}
