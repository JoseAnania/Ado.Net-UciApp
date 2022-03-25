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
    class GestorPais
    {
        private SqlCommand comando;
        private SqlDataReader dr;
        GestorConexion gc = new GestorConexion();
        public List<Pais> ListaPais()
        {
            List<Pais> lista = new List<Pais>();
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("V_ConsultaPais", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string codPais = dr.GetString(0);
                    string nombrePais = dr.GetString(1);
                    Pais p = new Pais(codPais, nombrePais);
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
        public void AgregarPais(Pais nuevoPais)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Pais(codPais, nombrePais) VALUES(UPPER(@codPais), @nombrePais)", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codPais", nuevoPais.CodPais));
                comando.Parameters.Add(new SqlParameter("@nombrePais", nuevoPais.NombrePais));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar. Error: " + ex.ToString());
            }
        }
        public void ModificarPais(PaisDto cambiarPais)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Pais SET codPais=UPPER(@codPais), nombrePais=@nombrePais WHERE codPais=@codPaisAnterior", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@nombrePais", cambiarPais.NombrePais));
                comando.Parameters.Add(new SqlParameter("@codPais", cambiarPais.CodPais));
                comando.Parameters.Add(new SqlParameter("@codPaisAnterior", cambiarPais.codPaisAnterior));
                comando.ExecuteNonQuery();
                gc.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar. Error: " + ex.ToString());
            }
        }
        public void EliminarPais(Pais borrarPais)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Pais WHERE codPais=@codPais", gc.conexion);
                comando.Parameters.Add(new SqlParameter("@codPais", borrarPais.CodPais));
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
