﻿using ProyectoAppUci.Controlador;
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
    public partial class VentanaTipoEtapa : Form
    {
        GestorTipoEtapa gte = new GestorTipoEtapa();
        private bool btnAgregarClick = false;
        private bool btnModificarClick = false;
        private bool btnEliminarClick = false;
        public VentanaTipoEtapa()
        {
            InitializeComponent();
            ListarTipoEtapas();
            ActivarCampos(true);
            OcultarColumnas();
        }
        private void ListarTipoEtapas()
        {
            List<TipoEtapa> lista = gte.ListaTipoEtapa();
            DataTable modelo = new DataTable();
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Tipo de Etapa");
            dgvLista.DataSource = modelo;
            foreach (TipoEtapa te in lista)
            {
                DataRow fila = modelo.NewRow();
                fila[0] = te.IdTipoEtapa;
                fila[1] = te.NombreTipoEtapa;
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
                int idTipoEtapa = 0;
                string nombreTipoEtapa = txtNombre.Text;
                TipoEtapa te = new TipoEtapa(idTipoEtapa, nombreTipoEtapa);
                gte.AgregarTipoEtapa(te);
                ListarTipoEtapas();
                LimpiarCampos();
                ActivarCampos(true);
            }
            if (btnModificarClick == true)
            {
                int idTipoEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreTipoEtapa = txtNombre.Text;
                TipoEtapa te = new TipoEtapa(idTipoEtapa, nombreTipoEtapa);
                gte.ModificarTipoEtapa(te);
                ListarTipoEtapas();
                LimpiarCampos();
            }
            if (btnEliminarClick == true)
            {
                int idTipoEtapa = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                string nombreTipoEtapa = "";
                TipoEtapa te = new TipoEtapa(idTipoEtapa, nombreTipoEtapa);
                gte.EliminarTipoEtapa(te);
                ListarTipoEtapas();
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
            string nombreTipoEtapa = dgvLista.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = nombreTipoEtapa;
        }
    }
}
