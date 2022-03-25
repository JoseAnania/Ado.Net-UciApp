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
    class GestorResultadoEtapa
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<ResultadoEtapaDto> ListaResultadoEtapa()
        {
            List<ResultadoEtapaDto> lista = new List<ResultadoEtapaDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT e.numeroEtapa, ca.nombreCarrera, ci.apellidoCiclista+', '+ci.nombreCiclista AS nomApeCiclista, re.puestoMaillot, re.tiempo, re.puntos FROM Etapa e INNER JOIN Carrera ca ON e.idEtapa=ca.idCarrera INNER JOIN ResultadoEtapa re ON e.idEtapa=re.idEtapa INNER JOIN Ciclista ci ON re.idCiclista=ci.idCiclista", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int numeroEtapa = Convert.ToInt32(dr.GetInt32(0));
                    string nombreCarrera = dr.GetString(1);
                    string nomApeCiclista = dr.GetString(2);
                    string puestoMaillot = dr.GetString(3);
                    DateTime tiempo = dr.GetDateTime(4);
                    int puntos = Convert.ToInt32(dr.GetInt32(5));
                    ResultadoEtapaDto re = new ResultadoEtapaDto(numeroEtapa, nombreCarrera, nomApeCiclista, puestoMaillot, tiempo, puntos);
                    lista.Add(re);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarResultadoEtapa(ResultadoEtapa nuevoResultadoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO ResultadoEtapa(idEtapa, idCiclista, puestoMaillot, tiempo, puntos) VALUES(@idEtapa, @idCiclista, @puestoMaillot, @tiempo, @puntos)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idEtapa", nuevoResultadoEtapa.IdEtapa));
                comando.Parameters.Add(new SqlParameter("@idCiclista", nuevoResultadoEtapa.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@puestoMaillot", nuevoResultadoEtapa.PuestoMaillot));
                comando.Parameters.Add(new SqlParameter("@tiempo", nuevoResultadoEtapa.Tiempo));
                comando.Parameters.Add(new SqlParameter("@puntos", nuevoResultadoEtapa.Puntos));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarResultadoEtapa(ResultadoEtapa cambiarResultadoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE ResultadoEtapa SET idEtapa=@idEtapa, idCiclista=@idCiclista, puestoMaillot=@puestoMaillot, tiempo=@tiempo, puntos=@puntos WHERE idEtapa=@idEtapa AND idCiclista=@idCiclista", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idEtapa", cambiarResultadoEtapa.IdEtapa));
                comando.Parameters.Add(new SqlParameter("@idCiclista", cambiarResultadoEtapa.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@puestoMaillot", cambiarResultadoEtapa.PuestoMaillot));
                comando.Parameters.Add(new SqlParameter("@tiempo", cambiarResultadoEtapa.Tiempo));
                comando.Parameters.Add(new SqlParameter("@puntos", cambiarResultadoEtapa.Puntos));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarResultadoEtapa(ResultadoEtapa borrarResultadoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM ResultadoEtapa WHERE idEtapa=@idEtapa AND idCiclista=@idCiclista", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idEtapa", borrarResultadoEtapa.IdEtapa));
                comando.Parameters.Add(new SqlParameter("@idCiclista", borrarResultadoEtapa.IdCiclista));
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
