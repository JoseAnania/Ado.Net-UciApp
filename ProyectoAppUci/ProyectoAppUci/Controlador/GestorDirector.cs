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
    class GestorDirector
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<Director> ListaDirector()
        {
            List<Director> lista = new List<Director>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Director", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idDirector = Convert.ToInt32(dr.GetInt32(0));
                    string nombreDirector = dr.GetString(1);
                    string apellidoDirector = dr.GetString(2);
                    DateTime fechaNacimiento = dr.GetDateTime(3);
                    string codPais = dr.GetString(4);
                    Director d = new Director(idDirector, nombreDirector, apellidoDirector, fechaNacimiento, codPais);
                    lista.Add(d);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public List<DirectorDto>ComboDirector()
        {
            List<DirectorDto> lista = new List<DirectorDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT idDirector, apellidoDirector+', '+nombreDirector AS NomApeDirector FROM Director", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idDirector = Convert.ToInt32(dr.GetInt32(0));
                    string nomApeDirector = dr.GetString(1);
                    DirectorDto d = new DirectorDto(idDirector, nomApeDirector);
                    lista.Add(d);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarDirector(Director nuevoDirector)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Director(nombreDirector, apellidoDirector, fechaNacimiento, codPais) VALUES(@nombreDirector, UPPER(@apellidoDirector), @fechaNacimiento, @codPais)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreDirector", nuevoDirector.NombreDirector));
                comando.Parameters.Add(new SqlParameter("@apellidoDirector", nuevoDirector.ApellidoDirector));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", nuevoDirector.FechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@codPais", nuevoDirector.CodPais));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarDirector(Director cambiarDirector)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Director SET nombreDirector=@nombreDirector, apellidoDirector=UPPER(@apellidoDirector), fechaNacimiento=@fechaNacimiento, codPais=@codPais WHERE idDirector=@idDirector", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreDirector", cambiarDirector.NombreDirector));
                comando.Parameters.Add(new SqlParameter("@apellidoDirector", cambiarDirector.ApellidoDirector));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", cambiarDirector.FechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@codPais", cambiarDirector.CodPais));
                comando.Parameters.Add(new SqlParameter("@idDirector", cambiarDirector.IdDirector));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarDirector(Director borrarDirector)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Director WHERE idDirector=@idDirector", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idDirector", borrarDirector.IdDirector));
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
