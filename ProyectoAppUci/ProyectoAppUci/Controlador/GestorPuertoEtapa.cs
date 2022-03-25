using ProyectoAppUci.Dto;
using ProyectoAppUci.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAppUci.Controlador
{
    class GestorPuertoEtapa
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<PuertoEtapaDto> ListaPuertoEtapa()
        {
            List<PuertoEtapaDto> lista = new List<PuertoEtapaDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT ep.idEtapa, p.nombrePuerto, c.apellidoCiclista+', '+c.nombreCiclista nomApeCiclista, ep.puesto FROM Puerto p INNER JOIN EtapaPuerto ep ON p.idPuerto=ep.idPuerto INNER JOIN Ciclista c ON c.idCiclista=ep.idCiclista", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idEtapa = Convert.ToInt32(dr.GetInt32(0));
                    string nombrePuerto = dr.GetString(1);
                    string nomApeCiclista = dr.GetString(2);
                    string puesto = dr.GetString(3);
                    PuertoEtapaDto pe = new PuertoEtapaDto(idEtapa, nombrePuerto, nomApeCiclista, puesto);
                    lista.Add(pe);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarPuertoEtapa(PuertoEtapa nuevoPuertoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO EtapaPuerto(idEtapa, idPuerto, idCiclista, puesto) VALUES(@idEtapa, @idPuerto, @idCiclista, @puesto)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idEtapa", nuevoPuertoEtapa.IdEtapa));
                comando.Parameters.Add(new SqlParameter("@idPuerto", nuevoPuertoEtapa.IdPuerto));
                comando.Parameters.Add(new SqlParameter("@idCiclista", nuevoPuertoEtapa.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@puesto", nuevoPuertoEtapa.Puesto));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void EliminarPuertoEtapa(PuertoEtapa borrarPuertoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM EtapaPuerto WHERE idEtapa=@idEtapa and idPuerto=@idPuerto and idCiclista=@idCiclista", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idEtapa", borrarPuertoEtapa.IdEtapa));
                comando.Parameters.Add(new SqlParameter("@idPuerto", borrarPuertoEtapa.IdPuerto));
                comando.Parameters.Add(new SqlParameter("@idCiclista", borrarPuertoEtapa.IdCiclista));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar. Error: " + ex.ToString());
            }
        }
    }
}
