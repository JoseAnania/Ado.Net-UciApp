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
    class GestorCategoriaEquipo
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<CategoriaEquipo> ListaCategoriaEquipo()
        {
            List<CategoriaEquipo> lista = new List<CategoriaEquipo>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM CategoriaEquipo", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idCategoriaEquipo = Convert.ToInt32(dr.GetInt32(0));
                    string nombreCategoriaEquipo = dr.GetString(1);
                    CategoriaEquipo ce = new CategoriaEquipo(idCategoriaEquipo, nombreCategoriaEquipo);
                    lista.Add(ce);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarCategoriaEquipo(CategoriaEquipo nuevaCategoriaEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO CategoriaEquipo(nombreCategoriaEquipo) VALUES(@nombreCategoriaEquipo)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCategoriaEquipo", nuevaCategoriaEquipo.NombreCategoriaEquipo));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarCategoriaEquipo(CategoriaEquipo cambiarCategoriaEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE CategoriaEquipo SET nombreCategoriaEquipo=@nombreCategoriaEquipo WHERE idCategoriaEquipo=@idCategoriaEquipo", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCategoriaEquipo", cambiarCategoriaEquipo.NombreCategoriaEquipo));
                comando.Parameters.Add(new SqlParameter("@idCategoriaEquipo", cambiarCategoriaEquipo.IdCategoriaEquipo));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarCategoriaEquipo(CategoriaEquipo borrarCategoriaEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM CategoriaEquipo WHERE idCategoriaEquipo=@idCategoriaEquipo", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCategoriaEquipo", borrarCategoriaEquipo.IdCategoriaEquipo));
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
