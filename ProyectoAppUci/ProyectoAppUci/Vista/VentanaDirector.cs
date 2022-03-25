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
    public partial class VentanaDirector : Form
    {
        GestorDirector gd = new GestorDirector();
        GestorPais gp = new GestorPais();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaDirector()
        {
            InitializeComponent();
            ListarDirectores();
            ActivarCampos(true);
            CargarComboPais();
            OcultarColumnas();
        }
        private void ListarDirectores()
        {
            List<Director> lista = gd.ListaDirector();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Código");
            modelo.Columns.Add("Nombre");
            modelo.Columns.Add("Apellido");
            modelo.Columns.Add("Nacimiento");
            modelo.Columns.Add("País");
            dgvLista.DataSource = modelo;
            foreach (Director d in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = d.IdDirector;
                fila[1] = d.NombreDirector;
                fila[2] = d.ApellidoDirector;
                fila[3] = d.FechaNacimiento;
                fila[4] = d.CodPais;
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
                int idDirector = 0;
                string nombreDirector = txtNombre.Text;
                string apellidoDirector = txtApellido.Text;
                DateTime fechaNacimiento = dtpFecNac.Value;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                Director d = new Director(idDirector, nombreDirector, apellidoDirector, fechaNacimiento, codPais);
                gd.AgregarDirector(d);
                ListarDirectores();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idDirector = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreDirector = txtNombre.Text;
                string apellidoDirector = txtApellido.Text;
                DateTime fechaNacimiento = dtpFecNac.Value;
                string codPais = Convert.ToString(cboPais.SelectedValue);
                Director d = new Director(idDirector, nombreDirector, apellidoDirector, fechaNacimiento, codPais);
                gd.ModificarDirector(d);
                ListarDirectores();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idDirector = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreDirector = "";
                string apellidoDirector = "";
                DateTime fechaNacimiento = dtpFecNac.Value;
                string codPais = "";
                Director d = new Director(idDirector, nombreDirector, apellidoDirector, fechaNacimiento, codPais);
                gd.EliminarDirector(d);
                ListarDirectores();
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
            string nombreDirector = dgvLista.CurrentRow.Cells[1].Value.ToString();
            string apellidoDirector = dgvLista.CurrentRow.Cells[2].Value.ToString();
            DateTime fechaNacimiento = Convert.ToDateTime(dgvLista.CurrentRow.Cells[3].Value.ToString());
            string codPais = dgvLista.CurrentRow.Cells[4].Value.ToString();
            txtNombre.Text = nombreDirector;
            txtApellido.Text = apellidoDirector;
            dtpFecNac.Text = Convert.ToDateTime(fechaNacimiento).ToString();
            cboPais.SelectedValue = codPais;
        }
    }
}
