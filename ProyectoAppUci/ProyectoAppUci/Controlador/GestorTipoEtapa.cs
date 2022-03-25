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
    class GestorTipoEtapa
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<TipoEtapa> ListaTipoEtapa()
        {
            List<TipoEtapa> lista = new List<TipoEtapa>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM TipoEtapa", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idTipoEtapa = Convert.ToInt32(dr.GetInt32(0));
                    string nombreTipoEtapa = dr.GetString(1);
                    TipoEtapa te = new TipoEtapa(idTipoEtapa, nombreTipoEtapa);
                    lista.Add(te);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarTipoEtapa(TipoEtapa nuevoTipoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO TipoEtapa(nombreTipoEtapa) VALUES(@nombreTipoEtapa)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreTipoEtapa", nuevoTipoEtapa.NombreTipoEtapa));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarTipoEtapa(TipoEtapa cambiarTipoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE TipoEtapa SET nombreTipoEtapa=@nombreTipoEtapa WHERE idTipoEtapa=@idTipoEtapa", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreTipoEtapa", cambiarTipoEtapa.NombreTipoEtapa));
                comando.Parameters.Add(new SqlParameter("@idTipoEtapa", cambiarTipoEtapa.IdTipoEtapa));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarTipoEtapa(TipoEtapa borrarTipoEtapa)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM TipoEtapa WHERE idTipoEtapa=@idTipoEtapa", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idTipoEtapa", borrarTipoEtapa.IdTipoEtapa));
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
