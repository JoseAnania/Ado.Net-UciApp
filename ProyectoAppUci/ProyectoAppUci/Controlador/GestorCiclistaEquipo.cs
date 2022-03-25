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
    class GestorCiclistaEquipo
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<CiclistaEquipoDto> ListaCiclistaEquipo()
        {
            List<CiclistaEquipoDto> lista = new List<CiclistaEquipoDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT c.apellidoCiclista+', '+c.nombreCiclista AS NomApeCiclista, e.nombreEquipo, ce.anioAlta, ISNULL(ce.anioBaja, 0) FROM Ciclista c INNER JOIN CiclistaEquipo ce ON c.idCiclista=ce.idCiclista INNER JOIN Equipo e ON e.codEquipo=ce.codEquipo", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nomApeCiclista = dr.GetString(0);
                    string nombreEquipo = dr.GetString(1);
                    DateTime anioAlta = dr.GetDateTime(2);
                    DateTime anioBaja = dr.GetDateTime(3);
                    CiclistaEquipoDto ce = new CiclistaEquipoDto(nomApeCiclista, nombreEquipo, anioAlta, anioBaja);
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
        public void AgregarCiclistaEquipo(CiclistaEquipo nuevoCiclistaEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO CiclistaEquipo(idCiclista, codEquipo, anioAlta, anioBaja) VALUES(@idCiclista, @codEquipo, @anioAlta, NULL)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCiclista", nuevoCiclistaEquipo.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@codEquipo", nuevoCiclistaEquipo.CodEquipo));
                comando.Parameters.Add(new SqlParameter("@anioAlta", nuevoCiclistaEquipo.AnioAlta));
                //comando.Parameters.Add(new SqlParameter("@anioBaja", nuevoCiclistaEquipo.AnioBaja)); NULL!!
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void EliminarCiclistaEquipo(CiclistaEquipo borrarCiclistaEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM CiclistaEquipo WHERE idCiclista=@idCiclista AND codEquipo=@codEquipo", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idCiclista", borrarCiclistaEquipo.IdCiclista));
                comando.Parameters.Add(new SqlParameter("@codEquipo", borrarCiclistaEquipo.CodEquipo));
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
