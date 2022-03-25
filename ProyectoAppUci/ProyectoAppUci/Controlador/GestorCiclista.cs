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
    class GestorCiclista
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<Ciclista> ListaCiclista()
        {
            List<Ciclista> lista = new List<Ciclista>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Ciclista", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idCiclista = Convert.ToInt32(dr.GetInt32(0));
                    string nombreCiclista = dr.GetString(1);
                    string apellidoCiclista = dr.GetString(2);
                    DateTime fechaNacimiento = dr.GetDateTime(3);
                    string codPais = dr.GetString(4);
                    Ciclista c = new Ciclista(idCiclista, nombreCiclista, apellidoCiclista, fechaNacimiento, codPais);
                    lista.Add(c);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public List<CiclistaDto> ComboCiclista()
        {
            List<CiclistaDto> lista = new List<CiclistaDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT idCiclista, apellidoCiclista+', '+nombreCiclista AS NomApeCiclista FROM Ciclista", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idCiclista = Convert.ToInt32(dr.GetInt32(0));
                    string nomApeCiclista = dr.GetString(1);
                    CiclistaDto c = new CiclistaDto(idCiclista, nomApeCiclista);
                    lista.Add(c);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarCiclista(Ciclista nuevoCiclista)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Ciclista(nombreCiclista, apellidoCiclista, fechaNacimiento, codPais) VALUES(@nombreCiclista, UPPER(@apellidoCiclista), @fechaNacimiento, @codPais)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCiclista", nuevoCiclista.NombreCiclista));
                comando.Parameters.Add(new SqlParameter("@apellidoCiclista", nuevoCiclista.ApellidoCiclista));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", nuevoCiclista.FechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@codPais", nuevoCiclista.CodPais));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarCiclista(Ciclista cambiarCiclista)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Ciclista SET nombreCiclista=@nombreCiclista, apellidoCiclista=UPPER(@apellidoCiclista), fechaNacimiento=@fechaNacimiento, codPais=@codPais WHERE idCiclista=@idCiclista", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCiclista", cambiarCiclista.NombreCiclista));
                comando.Parameters.Add(new SqlParameter("@apellidoCiclista", cambiarCiclista.ApellidoCiclista));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", cambiarCiclista.FechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@codPais", cambiarCiclista.CodPais));
                comando.Parameters.Add(new SqlParameter("@idCiclista", cambiarCiclista.IdCiclista));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarCiclista(Ciclista borrarCiclista)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Ciclista WHERE idCiclista=@idciclista", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCiclista", borrarCiclista.IdCiclista));
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
