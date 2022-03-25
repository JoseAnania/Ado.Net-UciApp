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
    class GestorCategoriaCarrera
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<CategoriaCarrera> ListaCategoriaCarrera()
        {
            List<CategoriaCarrera> lista = new List<CategoriaCarrera>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM CategoriaCarrera", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idCategoriaCarrera = Convert.ToInt32(dr.GetInt32(0));
                    string nombreCategoriaCarrera = dr.GetString(1);
                    CategoriaCarrera cc = new CategoriaCarrera(idCategoriaCarrera, nombreCategoriaCarrera);
                    lista.Add(cc);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarCategoriaCarrera(CategoriaCarrera nuevaCategoriaCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO CategoriaCarrera(nombreCategoriaCarrera) VALUES(@nombreCategoriaCarrera)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCategoriaCarrera", nuevaCategoriaCarrera.NombreCategoriaCarrera));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarCategoriaCarrera(CategoriaCarrera cambiarCategoriaCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE CategoriaCarrera SET nombreCategoriaCarrera=@nombreCategoriaCarrera WHERE idCategoriaCarrera=@idCategoriaCarrera", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCategoriaCarrera", cambiarCategoriaCarrera.NombreCategoriaCarrera));
                comando.Parameters.Add(new SqlParameter("@idCategoriaCarrera", cambiarCategoriaCarrera.IdCategoriaCarrera));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarCategoriaCarrera(CategoriaCarrera borrarCategoriaCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM CategoriaCarrera WHERE idCategoriaCarrera=@idCategoriaCarrera", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCategoriaCarrera", borrarCategoriaCarrera.IdCategoriaCarrera));
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
