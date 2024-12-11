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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Libro libro)
        {
            throw new NotImplementedException();
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
                comando.CommandText = "Select * FROM Libro where Libro_Id=@id or Titulo like @titulo+'%' order by Libro_Id desc";
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
