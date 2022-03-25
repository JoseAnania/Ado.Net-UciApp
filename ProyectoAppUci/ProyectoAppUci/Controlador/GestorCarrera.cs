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
    class GestorCarrera
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<CarreraDto> ListaCarrera()
        {
            List<CarreraDto> lista = new List<CarreraDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT c.idCarrera, c.nombreCarrera, c.edicion, cc.nombreCategoriaCarrera, c.fechaInicio, c.fechaFinal, c.codPais FROM Carrera c INNER JOIN CategoriaCarrera cc ON c.idCategoriaCarrera=cc.idCategoriaCarrera", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    int idCarrera = Convert.ToInt32(dr.GetInt32(0));
                    string nombreCarrera = dr.GetString(1);
                    string edicion = dr.GetString(2);
                    string nombreCategoriaCarrera = dr.GetString(3);
                    DateTime fechaInicio = dr.GetDateTime(4);
                    DateTime fechaFinal = dr.GetDateTime(5);
                    string codPais = dr.GetString(6);
                    CarreraDto c = new CarreraDto(idCarrera, nombreCarrera, edicion, nombreCategoriaCarrera, fechaInicio, fechaFinal, codPais);
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
        public void AgregarCarrera(Carrera nuevaCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Carrera(nombreCarrera, edicion, idCategoriaCarrera, fechaInicio, fechaFinal, codPais) VALUES(@nombreCarrera, @edicion, @idCategoriaCarrera, @fechaInicio, @fechaFinal, @codPais)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCarrera", nuevaCarrera.NombreCarrera));
                comando.Parameters.Add(new SqlParameter("@edicion", nuevaCarrera.Edicion));
                comando.Parameters.Add(new SqlParameter("@idCategoriaCarrera", nuevaCarrera.IdCategoriaCarrera));
                comando.Parameters.Add(new SqlParameter("@fechaInicio", nuevaCarrera.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fechaFinal", nuevaCarrera.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@codPais", nuevaCarrera.CodPais));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarCarrera(Carrera cambiarCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Carrera SET nombreCarrera=@nombreCarrera, edicion=@edicion, idCategoriaCarrera=@idCategoriaCarrera, fechaInicio=@fechaInicio, fechaFinal=@fechaFinal, codPais=@codPais WHERE idCarrera=@idCarrera", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombreCarrera", cambiarCarrera.NombreCarrera));
                comando.Parameters.Add(new SqlParameter("@edicion", cambiarCarrera.Edicion));
                comando.Parameters.Add(new SqlParameter("@idCategoriaCarrera", cambiarCarrera.IdCategoriaCarrera));
                comando.Parameters.Add(new SqlParameter("@fechaInicio", cambiarCarrera.FechaInicio));
                comando.Parameters.Add(new SqlParameter("@fechaFinal", cambiarCarrera.FechaFinal));
                comando.Parameters.Add(new SqlParameter("@codPais", cambiarCarrera.CodPais));
                comando.Parameters.Add(new SqlParameter("@idCarrera", cambiarCarrera.IdCarrera));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarCarrera(Carrera borrarCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Carrera WHERE idCarrera=@idCarrera", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCarrera", borrarCarrera.IdCarrera));
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
