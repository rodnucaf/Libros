using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Model
{
    public class Libro
    {
        //Atributos
        private int id;
        private string titulo;
        private string autor;
        private string genero;

        //Propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Titutlo { get { return titulo; } set { titulo = value; } }
        public string Autor { get { return autor; }set { autor = value; } }
        public string Genero { get { return genero; } set { genero = value; } }




    }
}
