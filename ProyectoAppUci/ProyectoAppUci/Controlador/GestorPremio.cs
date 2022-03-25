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
    class GestorPremio
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<Premio> ListaPremio()
        {
            List<Premio> lista = new List<Premio>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Premio", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idPremio = Convert.ToInt32(dr.GetInt32(0));
                    string nombrePremio = dr.GetString(1);
                    Premio p = new Premio(idPremio, nombrePremio);
                    lista.Add(p);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarPremio(Premio nuevoPremio)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Premio(nombrePremio) VALUES(@nombrePremio)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombrePremio", nuevoPremio.NombrePremio));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarPremio(Premio cambiarPremio)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Premio SET nombrePremio=@nombrePremio WHERE idPremio=@idPremio", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombrePremio", cambiarPremio.NombrePremio));
                comando.Parameters.Add(new SqlParameter("@idPremio", cambiarPremio.IdPremio));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarPremio(Premio borrarPremio)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Premio WHERE idPremio=@idPremio", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idPremio", borrarPremio.IdPremio));
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
