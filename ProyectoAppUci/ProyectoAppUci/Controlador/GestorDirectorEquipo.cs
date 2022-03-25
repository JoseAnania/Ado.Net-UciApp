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
    class GestorDirectorEquipo
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<DirectorEquipoDto> ListaDirectorEquipo()
        {
            List<DirectorEquipoDto> lista = new List<DirectorEquipoDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT d.apellidoDirector+', '+d.nombreDirector AS NomApeDirector, e.nombreEquipo, de.anioAlta, ISNULL(de.anioBaja, 0) FROM Director d INNER JOIN DirectorEquipo de ON d.idDirector=de.idDirector INNER JOIN Equipo e ON e.codEquipo=de.codEquipo", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nomApeDirector = dr.GetString(0);
                    string nombreEquipo = dr.GetString(1);
                    DateTime anioAlta = dr.GetDateTime(2);
                    DateTime anioBaja = dr.GetDateTime(3);
                    DirectorEquipoDto de = new DirectorEquipoDto(nomApeDirector, nombreEquipo, anioAlta, anioBaja);
                    lista.Add(de);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarDirectorEquipo(DirectorEquipo nuevoDirectorEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO DirectorEquipo(idDirector, codEquipo, anioAlta, anioBaja) VALUES(@idDirector, @codEquipo, @anioAlta, NULL)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idDirector", nuevoDirectorEquipo.IdDirector));
                comando.Parameters.Add(new SqlParameter("@codEquipo", nuevoDirectorEquipo.CodEquipo));
                comando.Parameters.Add(new SqlParameter("@anioAlta", nuevoDirectorEquipo.AnioAlta));
                //comando.Parameters.Add(new SqlParameter("@anioBaja", nuevoDirectorEquipo.AnioBaja)); NULL!!
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void EliminarDirectorEquipo(DirectorEquipo borrarDirectorEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM DirectorEquipo WHERE idDirector=@idDirector AND codEquipo=@codEquipo", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@idDirector", borrarDirectorEquipo.IdDirector));
                comando.Parameters.Add(new SqlParameter("@codEquipo", borrarDirectorEquipo.CodEquipo));
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
