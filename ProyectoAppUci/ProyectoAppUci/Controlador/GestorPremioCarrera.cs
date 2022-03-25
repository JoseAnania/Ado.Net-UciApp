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
    class GestorPremioCarrera
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<PremioCarreraDto> ListaPremioCarrera()
        {
            List<PremioCarreraDto> lista = new List<PremioCarreraDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT ca.nombreCarrera, ci.apellidoCiclista+', '+ci.nombreCiclista AS ApeNomCiclista, pr.nombrePremio FROM Carrera ca INNER JOIN PremioCarrera pc ON ca.idCarrera=pc.idCarrera INNER JOIN Ciclista ci ON ci.idCiclista=pc.idCiclista INNER JOIN Premio pr ON pr.idPremio=pc.idPremio ", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nombreCarrera = dr.GetString(0);
                    string ApeNomCiclista = dr.GetString(1);
                    string nombrePremio = dr.GetString(2);
                    PremioCarreraDto pc = new PremioCarreraDto(nombreCarrera, ApeNomCiclista, nombrePremio);
                    lista.Add(pc);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarPremioCarrera(PremioCarrera nuevoPremioCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO PremioCarrera(idCarrera, idCiclista, idPremio) VALUES(@idCarrera, @idCiclista, @idPremio)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCarrera", nuevoPremioCarrera.IdCarrera));
                comando.Parameters.Add(new SqlParameter("@idCiclista", nuevoPremioCarrera.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@idPremio", nuevoPremioCarrera.IdPremio));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void EliminarPremioCarrera(PremioCarrera borrarPremioCarrera)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM PremioCarrera WHERE idCarrera=@idCarrera AND idCiclista=@idCiclista AND idPremio=@idPremio", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCarrera", borrarPremioCarrera.IdCarrera));
                comando.Parameters.Add(new SqlParameter("@idCiclista", borrarPremioCarrera.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@idPremio", borrarPremioCarrera.IdPremio));
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
