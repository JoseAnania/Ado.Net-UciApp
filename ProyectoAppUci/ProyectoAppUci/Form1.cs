using ProyectoAppUci.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAppUci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            VentanaPais vp = new VentanaPais();
            vp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentanaCategoriaEquipo vce = new VentanaCategoriaEquipo();
            vce.ShowDialog();
        }

        private void btnPremio_Click(object sender, EventArgs e)
        {
            VentanaPremio vp = new VentanaPremio();
            vp.ShowDialog();
        }

        private void btnCategoriaPuerto_Click(object sender, EventArgs e)
        {
            VentanaCategoriaPuerto vcp = new VentanaCategoriaPuerto();
            vcp.ShowDialog();
        }

        private void btnCategoriaCarrera_Click(object sender, EventArgs e)
        {
            VentanaCategoriaCarrera vcc = new VentanaCategoriaCarrera();
            vcc.ShowDialog();
        }

        private void btnTipoEtapa_Click(object sender, EventArgs e)
        {
            VentanaTipoEtapa vte = new VentanaTipoEtapa();
            vte.ShowDialog();
        }

        private void btnPuerto_Click(object sender, EventArgs e)
        {
            VentanaPuerto vp = new VentanaPuerto();
            vp.ShowDialog();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            VentanaEquipo ve = new VentanaEquipo();
            ve.ShowDialog();
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            VentanaDirector vd = new VentanaDirector();
            vd.ShowDialog();
        }

        private void btnCiclista_Click(object sender, EventArgs e)
        {
            VentanaCiclista vc = new VentanaCiclista();
            vc.ShowDialog();
        }

        private void btnCarrera_Click(object sender, EventArgs e)
        {
            VentanaCarrera vc = new VentanaCarrera();
            vc.ShowDialog();
        }

        private void btnEtapa_Click(object sender, EventArgs e)
        {
            VentanaEtapa ve = new VentanaEtapa();
            ve.ShowDialog();
        }

        private void btnDirectorEquipo_Click(object sender, EventArgs e)
        {
            VentanaDirectorEquipo vde = new VentanaDirectorEquipo();
            vde.ShowDialog();
        }

        private void btnCiclistaEquipo_Click(object sender, EventArgs e)
        {
            VentanaCiclistaEquipo vce = new VentanaCiclistaEquipo();
            vce.ShowDialog();
        }

        private void btnPuertoEtapa_Click(object sender, EventArgs e)
        {
            VentanaPuertoEtapa vpe = new VentanaPuertoEtapa();
            vpe.ShowDialog();
        }

        private void btnCatEqEq_Click(object sender, EventArgs e)
        {
            VentanaCategoriaEquipoEquipo vcee = new VentanaCategoriaEquipoEquipo();
            vcee.ShowDialog();
        }

        private void btnPremioCarrera_Click(object sender, EventArgs e)
        {
            VentanaPremioCarrera vpc = new VentanaPremioCarrera();
            vpc.ShowDialog();
        }

        private void btnResultadoEtapa_Click(object sender, EventArgs e)
        {
            VentanaResultadoEtapa vre = new VentanaResultadoEtapa();
            vre.ShowDialog();
        }
    }
}
