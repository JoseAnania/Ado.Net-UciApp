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
    class GestorPuerto
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<PuertoDto> ListaPuerto()
        {
            List<PuertoDto> lista = new List<PuertoDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT p.idPuerto, p.nombrePuerto, p.altura, cp.nombreCategoriaPuerto  FROM Puerto p INNER JOIN CategoriaPuerto cp ON p.idCategoriaPuerto=cp.idCategoriaPuerto ", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idPuerto = Convert.ToInt32(dr.GetInt32(0));
                    string nombrePuerto = dr.GetString(1);
                    int altura = Convert.ToInt32(dr.GetInt32(2));
                    string nombreCategoriaPuerto = dr.GetString(3);
                    PuertoDto p = new PuertoDto(idPuerto, nombrePuerto, altura, nombreCategoriaPuerto);
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
        public void AgregarPuerto(Puerto nuevoPuerto)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Puerto(nombrePuerto, altura, idCategoriaPuerto) VALUES(@nombrePuerto, @altura, @idCategoriaPuerto)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombrePuerto", nuevoPuerto.NombrePuerto));
                comando.Parameters.Add(new SqlParameter("@altura", nuevoPuerto.Altura));
                comando.Parameters.Add(new SqlParameter("@idCategoriaPuerto", nuevoPuerto.IdCategoriaPuerto));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarPuerto(Puerto cambiarPuerto)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Puerto SET nombrePuerto=@nombrePuerto, altura=@altura, idCategoriaPuerto=@idCategoriaPuerto WHERE idPuerto=@idPuerto", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombrePuerto", cambiarPuerto.NombrePuerto));
                comando.Parameters.Add(new SqlParameter("@altura", cambiarPuerto.Altura));
                comando.Parameters.Add(new SqlParameter("@idCategoriaPuerto", cambiarPuerto.IdCategoriaPuerto));
                comando.Parameters.Add(new SqlParameter("@idPuerto", cambiarPuerto.IdPuerto));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarPuerto(Puerto borrarPuerto)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Puerto WHERE idPuerto=@idPuerto", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idPuerto", borrarPuerto.IdPuerto));
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
