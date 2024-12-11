using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


using Libros.Model;

namespace Libros.Repositories
{
    public class LibroRepository : BaseRepository, ILibroRepository
    {

        //Constructor
        public LibroRepository(string connectionString)
        {
            this.connectionString = connectionString;
            
        
        }

        //Métodos
        public void Add(Libro libro)
        {
            var listaLibros = new List<Libro>();
            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "Insert into Libro values(@Titulo, @Autor, @Genero)";
                comando.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = libro.Titulo;
                comando.Parameters.Add("@Autor", SqlDbType.NVarChar).Value = libro.Autor;
                comando.Parameters.Add("@Genero", SqlDbType.NVarChar).Value = libro.Genero;
                comando.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            var listaLibros = new List<Libro>();
            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "delete from Libro where Libro_Id=@id)";
                comando.Parameters.Add("@id", SqlDbType.Int).Value = id;  
                comando.ExecuteNonQuery();
            }
        }

        public void Edit(Libro libro)
        {
            var listaLibros = new List<Libro>();
            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "update Libro set Titulo=@titulo, Autor=@autor, Genero=@genero where Libro_Id=@id";
                comando.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = libro.Titulo;
                comando.Parameters.Add("@autor", SqlDbType.NVarChar).Value = libro.Autor;
                comando.Parameters.Add("@genero", SqlDbType.NVarChar).Value = libro.Genero;
                comando.Parameters.Add("id", SqlDbType.Int).Value = libro.Id;

                comando.ExecuteNonQuery();
            }
        }

        public IEnumerable<Libro> ObtenerPorValor(string valor)
        {
            var listaLibros = new List<Libro>();
            int id = int.TryParse(valor, out _) ? Convert.ToInt32(valor) : 0;
            string titulo = valor;
            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "Select * from Libro where Libro_Id=@id or Titulo like @titulo+'%' order by Libro_Id desc";
                comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = titulo;
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var Libro = new Libro();
                        Libro.Id = (int)lector[0];
                        Libro.Titulo = (string)lector[1].ToString();
                        Libro.Autor = (string)lector[2].ToString();
                        Libro.Genero = (string)lector[3].ToString();

                        listaLibros.Add(Libro);
                    }
                }
            }


            return listaLibros;
        }

        public IEnumerable<Libro> ObtenerTodo()
        {
            var listaLibros = new List<Libro>();
            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "Select * FROM Libro order by Libro_Id desc";
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var Libro = new Libro();
                        Libro.Id = (int)lector[0];
                        Libro.Titulo = (string)lector[1].ToString();
                        Libro.Autor = (string)lector[2].ToString();
                        Libro.Genero = (string)lector[3].ToString();

                        listaLibros.Add(Libro);
                    }
                }
            }


                return listaLibros;
        }
    }
}
