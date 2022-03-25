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
    public partial class VentanaPais : Form
    {
        GestorPais gp = new GestorPais();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaPais()
        {
            InitializeComponent();
            ListarPaises();
            ActivarCampos(true);
        }
        private void ListarPaises()
        {
            List<Pais> lista = gp.ListaPais();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Código");
            modelo.Columns.Add("País");
            dgvLista.DataSource = modelo;
            foreach (Pais p in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = p.CodPais;
                fila[1] = p.NombrePais;
                modelo.Rows.Add(fila);
            }
        }
        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }
        private void ActivarCampos(bool x)
        {
            btnAgregar.Enabled = x;
            btnModificar.Enabled = x;
            btnEliminar.Enabled = x;
            btnSalir.Enabled = x;
            txtCodigo.Enabled = !x;
            txtNombre.Enabled = !x;
            btnAceptar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAgregarClick == true)
            {
                string codPais = txtCodigo.Text;
                string nombrePais = txtNombre.Text;
                Pais p = new Pais(codPais, nombrePais);
                gp.AgregarPais(p);
                ListarPaises();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                string codPais = txtCodigo.Text;
                string nombrePais = txtNombre.Text;
                string codPaisAnterior = dgvLista.CurrentRow.Cells[0].Value.ToString();
                PaisDto p = new PaisDto(codPais, nombrePais, codPaisAnterior);
                gp.ModificarPais(p);
                ListarPaises();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                string codPais = dgvLista.CurrentRow.Cells[0].Value.ToString();
                string nombrePais = "";
                Pais p = new Pais(codPais, nombrePais);
                gp.EliminarPais(p);
                ListarPaises();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ActivarCampos(false);
            btnAgregarClick = false;
            btnModificarClick = false;
            btnEliminarClick = true;
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codPais = dgvLista.CurrentRow.Cells[0].Value.ToString();
            string nombrePais = dgvLista.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombrePais;
            txtCodigo.Text = codPais;
        }
    }
}
