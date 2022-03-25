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
    public partial class VentanaPremio : Form
    {
        GestorPremio gp = new GestorPremio();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaPremio()
        {
            InitializeComponent();
            ListarPremios();
            ActivarCampos(true);
            OcultarColumnas();
        }
        private void ListarPremios()
        {
            List<Premio> lista = gp.ListaPremio();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Premio");
            dgvLista.DataSource = modelo;
            foreach (Premio p in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = p.IdPremio;
                fila[1] = p.NombrePremio;
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
                int idPremio = 0;
                string nombrePremio = txtNombre.Text;
                Premio p = new Premio(idPremio, nombrePremio);
                gp.AgregarPremio(p);
                ListarPremios();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idPremio = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombrePremio = txtNombre.Text;
                Premio p = new Premio(idPremio, nombrePremio);
                gp.ModificarPremio(p);
                ListarPremios();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idPremio = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombrePremio = "";
                Premio p = new Premio(idPremio, nombrePremio);
                gp.EliminarPremio(p);
                ListarPremios();
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
            string nombreEquipo = dgvLista.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombreEquipo;
        }
    }
}
