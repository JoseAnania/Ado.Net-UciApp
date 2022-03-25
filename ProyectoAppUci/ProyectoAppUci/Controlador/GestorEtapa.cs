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
    class GestorEtapa
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<EtapaDto> ListaEtapa()
        {
            List<EtapaDto> lista = new List<EtapaDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT e.idEtapa, e.idCarrera, e.numeroEtapa, e.desde, e.hasta, te.nombreTipoEtapa, e.fecha, e.km FROM Etapa e INNER JOIN TipoEtapa te ON e.idTipoEtapa=te.idTipoEtapa", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idEtapa = Convert.ToInt32(dr.GetInt32(0));
                    int idCarrera = Convert.ToInt32(dr.GetInt32(1));
                    int numeroEtapa = Convert.ToInt32(dr.GetInt32(2));
                    string desde = dr.GetString(3);
                    string hasta = dr.GetString(4);
                    string nombreTipoEtapa = dr.GetString(5);
                    DateTime fecha = dr.GetDateTime(6);
                    int km = Convert.ToInt32(dr.GetInt32(7));
                    EtapaDto e = new EtapaDto(idEtapa, idCarrera, numeroEtapa, desde, hasta, nombreTipoEtapa, fecha, km);
                    lista.Add(e);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarEtapa(Etapa nuevaEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Etapa(idCarrera, numeroEtapa, desde, hasta, idTipoEtapa, fecha, km) VALUES(@idCarrera, @numeroEtapa, @desde, @hasta, @idTipoEtapa, @fecha, @km)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCarrera", nuevaEtapa.IdCarrera));
                comando.Parameters.Add(new SqlParameter("@numeroEtapa", nuevaEtapa.NumeroEtapa));
                comando.Parameters.Add(new SqlParameter("@desde", nuevaEtapa.Desde));
                comando.Parameters.Add(new SqlParameter("@hasta", nuevaEtapa.Hasta));
                comando.Parameters.Add(new SqlParameter("@idTipoEtapa", nuevaEtapa.IdTipoEtapa));
                comando.Parameters.Add(new SqlParameter("@fecha", nuevaEtapa.Fecha));
                comando.Parameters.Add(new SqlParameter("@km", nuevaEtapa.Km));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarEtapa(Etapa cambiarEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Etapa SET idCarrera=@idCarrera, numeroEtapa=@numeroEtapa, desde=@desde, hasta=@hasta, idTipoEtapa=@idTipoEtapa, fecha=@fecha, km=@km WHERE idEtapa=@idEtapa", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCarrera", cambiarEtapa.IdCarrera));
                comando.Parameters.Add(new SqlParameter("@numeroEtapa", cambiarEtapa.NumeroEtapa));
                comando.Parameters.Add(new SqlParameter("@desde", cambiarEtapa.Desde));
                comando.Parameters.Add(new SqlParameter("@hasta", cambiarEtapa.Hasta));
                comando.Parameters.Add(new SqlParameter("@idTipoEtapa", cambiarEtapa.IdTipoEtapa));
                comando.Parameters.Add(new SqlParameter("@fecha", cambiarEtapa.Fecha));
                comando.Parameters.Add(new SqlParameter("@km", cambiarEtapa.Km));
                comando.Parameters.Add(new SqlParameter("@idEtapa", cambiarEtapa.IdEtapa));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarEtapa(Etapa borrarEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Etapa WHERE idEtapa=@idEtapa", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idEtapa", borrarEtapa.IdEtapa));
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
