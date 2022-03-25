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
    public partial class VentanaCiclista : Form
    {
        GestorCiclista gc = new GestorCiclista();
        GestorPais gp = new GestorPais();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaCiclista()
        {
            InitializeComponent();
            ListarCiclistas();
            ActivarCampos(true);
            CargarComboPais();
            OcultarColumnas();
        }
        private void ListarCiclistas()
        {
            List<Ciclista> lista = gc.ListaCiclista();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Código");
            modelo.Columns.Add("Nombre");
            modelo.Columns.Add("Apellido");
            modelo.Columns.Add("Nacimiento");
            modelo.Columns.Add("País");
            dgvLista.DataSource = modelo;
            foreach (Ciclista c in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = c.IdCiclista;
                fila[1] = c.NombreCiclista;
                fila[2] = c.ApellidoCiclista;
                fila[3] = c.FechaNacimiento;
                fila[4] = c.CodPais;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
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
            DataGridViewColumn columna = dgvLista.Columns[0];
            DataGridViewColumn columna2 = dgvLista.Columns[3];
            columna.Visible = false;
            columna2.Visible = false;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idCiclista = 0;
                string nombreCiclista = txtNombre.Text;
                string apellidoCiclista = txtApellido.Text;
                DateTime fechaNacimiento = dtpFecNac.Value;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                Ciclista c = new Ciclista(idCiclista, nombreCiclista, apellidoCiclista, fechaNacimiento, codPais);
                gc.AgregarCiclista(c);
                ListarCiclistas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idCiclista = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCiclista = txtNombre.Text;
                string apellidoCiclista = txtApellido.Text;
                DateTime fechaNacimiento = dtpFecNac.Value;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                Ciclista c = new Ciclista(idCiclista, nombreCiclista, apellidoCiclista, fechaNacimiento, codPais);
                gc.ModificarCiclista(c);
                ListarCiclistas();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idCiclista = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreCiclista = "";
                string apellidoCiclista = "";
                DateTime fechaNacimiento = dtpFecNac.Value;
                string codPais = "";
                Ciclista c = new Ciclista(idCiclista, nombreCiclista, apellidoCiclista, fechaNacimiento, codPais);
                gc.EliminarCiclista(c);
                ListarCiclistas();
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
            string nombreCiclista = dgvLista.CurrentRow.Cells[1].Value.ToString();
            string apellidoCiclista = dgvLista.CurrentRow.Cells[2].Value.ToString();
            DateTime fechaNacimiento = Convert.ToDateTime(dgvLista.CurrentRow.Cells[3].Value.ToString());
            string codPais = dgvLista.CurrentRow.Cells[4].Value.ToString();
            txtNombre.Text = nombreCiclista;
            txtApellido.Text = apellidoCiclista;
            dtpFecNac.Text = Convert.ToDateTime(fechaNacimiento).ToString();
            cboPais.SelectedValue = codPais;
        }
    }
}
