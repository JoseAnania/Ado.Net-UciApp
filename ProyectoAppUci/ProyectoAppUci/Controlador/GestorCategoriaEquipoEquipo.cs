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
    class GestorCategoriaEquipoEquipo
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<CatEqEqDto> ListaCategoriaEquipoEquipo()
        {
            List<CatEqEqDto> lista = new List<CatEqEqDto>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT cee.codEquipo, ce.nombreCategoriaEquipo, cee.anio FROM CategoriaEquipoEquipo cee INNER JOIN CategoriaEquipo ce ON cee.idCategoriaEquipo=ce.idCategoriaEquipo", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string codEquipo = dr.GetString(0);
                    string nombreCategoriaEquipo = dr.GetString(1);
                    DateTime anio = dr.GetDateTime(2);
                    CatEqEqDto cee = new CatEqEqDto(codEquipo, nombreCategoriaEquipo, anio);
                    lista.Add(cee);
                }
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede mostrar la lista. Error: " + ex.ToString());
            }
            return lista;
        }
        public void AgregarCatEqEq(CategoriaEquipoEquipo nuevaCatEqEq)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO CategoriaEquipoEquipo(codEquipo, idCategoriaEquipo, anio) VALUES(@codEquipo, @idCategoriaEquipo, @anio)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codEquipo", nuevaCatEqEq.CodEquipo));
                comando.Parameters.Add(new SqlParameter("@idCategoriaEquipo", nuevaCatEqEq.IdCategoriaEquipo));
                comando.Parameters.Add(new SqlParameter("@anio", nuevaCatEqEq.Anio));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void EliminarCatEqEq(CategoriaEquipoEquipo borrarCatEqEq)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM CategoriaEquipoEquipo WHERE codEquipo=@codEquipo AND idCategoriaEquipo=@idCategoriaEquipo", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codEquipo", borrarCatEqEq.CodEquipo));
                comando.Parameters.Add(new SqlParameter("@idCategoriaEquipo", borrarCatEqEq.IdCategoriaEquipo));
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
