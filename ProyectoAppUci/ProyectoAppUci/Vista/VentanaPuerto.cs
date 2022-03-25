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
    public partial class VentanaPuerto : Form
    {
        GestorPuerto gp = new GestorPuerto();
        GestorCategoriaPuerto gcp = new GestorCategoriaPuerto();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaPuerto()
        {
            InitializeComponent();
            ListarPuertos();
            ActivarCampos(true);
            OcultarColumnas();
            CargarComboCategoriaPuerto();
        }
        private void ListarPuertos()
        {
            List<PuertoDto> lista = gp.ListaPuerto();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Puerto");
            modelo.Columns.Add("Altura");
            modelo.Columns.Add("Categoría");

            dgvLista.DataSource = modelo;
            foreach (PuertoDto p in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = p.IdPuerto;
                fila[1] = p.NombrePuerto;
                fila[2] = p.Altura;
                fila[3] = p.nombreCategoriaPuerto;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtAltura.Text = "";
            cboCategoria.SelectedIndex = 0;
        }
        private void ActivarCampos(bool x)
        {
            btnAgregar.Enabled = x;
            btnModificar.Enabled = x;
            btnEliminar.Enabled = x;
            btnSalir.Enabled = x;
            txtNombre.Enabled = !x;
            txtAltura.Enabled = !x;
            cboCategoria.Enabled = !x;
            btnAceptar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }
        private void OcultarColumnas()
        {
            DataGridViewColumn Column = dgvLista.Columns[0];
            Column.Visible = false;
        }
        private void CargarComboCategoriaPuerto()
        {
            cboCategoria.Items.Clear();
            List<CategoriaPuerto> lista = gcp.ListaCategoriaPuerto();
            cboCategoria.DataSource = lista;
            cboCategoria.DisplayMember = "nombreCategoriaPuerto";
            cboCategoria.ValueMember = "idCategoriaPuerto";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                int idPuerto = 0;
                string nombrePuerto = txtNombre.Text;
                int altura = Convert.ToInt32(txtAltura.Text);
                int idCategoriaPuerto = Convert.ToInt32(cboCategoria.SelectedValue);
                Puerto p = new Puerto(idPuerto, nombrePuerto, altura, idCategoriaPuerto);
                gp.AgregarPuerto(p);
                ListarPuertos();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idPuerto = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombrePuerto = txtNombre.Text;
                int altura = Convert.ToInt32(txtAltura.Text);
                int idCategoriaPuerto = Convert.ToInt32(cboCategoria.SelectedValue);
                Puerto p = new Puerto(idPuerto, nombrePuerto, altura, idCategoriaPuerto);
                gp.ModificarPuerto(p);
                ListarPuertos();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idPuerto = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombrePuerto = "";
                int altura = 0;
                int idCategoriaPuerto = 0;
                Puerto p = new Puerto(idPuerto, nombrePuerto, altura, idCategoriaPuerto);
                gp.EliminarPuerto(p);
                ListarPuertos();
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
            int altura = Convert.ToInt32(dgvLista.CurrentRow.Cells[2].Value.ToString());
            string nombreCategoriaPuerto = dgvLista.CurrentRow.Cells[3].Value.ToString();
            txtNombre.Text = nombreEquipo;
            txtAltura.Text = altura.ToString();
            cboCategoria.Text = nombreCategoriaPuerto;
        }
    }
}
