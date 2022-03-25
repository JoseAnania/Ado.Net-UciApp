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
    class GestorEquipo
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<Equipo> ListaEquipo()
        {
            List<Equipo> lista = new List<Equipo>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT codEquipo, nombreEquipo, codPais, anioAlta, ISNULL(anioBaja, 0) FROM Equipo", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string codEquipo = dr.GetString(0);
                    string nombreEquipo = dr.GetString(1);
                    string codPais = dr.GetString(2);
                    DateTime anioAlta = dr.GetDateTime(3);
                    DateTime anioBaja = dr.GetDateTime(4);
                    Equipo e = new Equipo(codEquipo, nombreEquipo, codPais, anioAlta, anioBaja);
                    lista.Add(e);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarEquipo(Equipo nuevoEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Equipo(codEquipo, nombreEquipo, codPais, anioAlta, anioBaja) VALUES(UPPER(@codEquipo), @nombreEquipo, @codPais, @anioAlta, NULL)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codEquipo", nuevoEquipo.CodEquipo));
                comando.Parameters.Add(new SqlParameter("@nombreEquipo", nuevoEquipo.NombreEquipo));
                comando.Parameters.Add(new SqlParameter("@codPais", nuevoEquipo.CodPais));
                comando.Parameters.Add(new SqlParameter("@anioAlta", nuevoEquipo.AnioAlta));
                //comando.Parameters.Add(new SqlParameter("@anioBaja", nuevoEquipo.AnioBaja)); NULL!!
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarEquipo(EquipoDto cambiarEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Equipo SET codEquipo=UPPER(@codEquipo), nombreEquipo=@nombreEquipo, codPais=@codPais, anioAlta=@anioAlta, anioBaja=NULL WHERE codEquipo=@codEquipoAnterior", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codEquipo", cambiarEquipo.CodEquipo));
                comando.Parameters.Add(new SqlParameter("@nombreEquipo", cambiarEquipo.NombreEquipo));
                comando.Parameters.Add(new SqlParameter("@codPais", cambiarEquipo.CodPais));
                comando.Parameters.Add(new SqlParameter("@anioAlta", cambiarEquipo.AnioAlta));
                comando.Parameters.Add(new SqlParameter("@codEquipoAnterior", cambiarEquipo.CodEquipoAnterior));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarEquipo(Equipo borrarEquipo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Equipo WHERE codEquipo=@codEquipo", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codEquipo", borrarEquipo.CodEquipo));
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
