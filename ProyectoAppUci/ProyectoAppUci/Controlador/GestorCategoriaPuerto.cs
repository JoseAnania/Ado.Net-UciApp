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
    class GestorCategoriaPuerto
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<CategoriaPuerto> ListaCategoriaPuerto()
        {
            List<CategoriaPuerto> lista = new List<CategoriaPuerto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM CategoriaPuerto", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idCategoriaPuerto = Convert.ToInt32(dr.GetInt32(0));
                    string nombreCategoriaPuerto = dr.GetString(1);
                    CategoriaPuerto cp = new CategoriaPuerto(idCategoriaPuerto, nombreCategoriaPuerto);
                    lista.Add(cp);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarCategoriaPuerto(CategoriaPuerto nuevaCategoriaPuerto)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO CategoriaPuerto(nombreCategoriaPuerto) VALUES(@nombreCategoriaPuerto)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCategoriaPuerto", nuevaCategoriaPuerto.NombreCategoriaPuerto));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarCategoriaPuerto(CategoriaPuerto cambiarCategoriaPuerto)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE CategoriaPuerto SET nombreCategoriaPuerto=@nombreCategoriaPuerto WHERE idCategoriaPuerto=@idCategoriaPuerto", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCategoriaPuerto", cambiarCategoriaPuerto.NombreCategoriaPuerto));
                comando.Parameters.Add(new SqlParameter("@idCategoriaPuerto", cambiarCategoriaPuerto.IdCategoriaPuerto));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarCategoriaPuerto(CategoriaPuerto borrarCategoriaPuerto)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM CategoriaPuerto WHERE idCategoriaPuerto=@idCategoriaPuerto", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCategoriaPuerto", borrarCategoriaPuerto.IdCategoriaPuerto));
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
