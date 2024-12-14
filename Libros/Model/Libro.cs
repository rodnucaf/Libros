using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Libros.Model
{
    public class Libro
    {
        //Atributos
        private int id;
        private string titulo;
        private string autor;
        private string genero;

        //Propiedades, validaciones
        [DisplayName("ID Libro")]
        public int Id { get { return id; } set { id = value; } }

        [DisplayName("Título")]
        [Required(ErrorMessage = "Se requiere el título.")]
        [StringLength(3, MinimumLength =50, ErrorMessage = "El título debe tener entre tres y cincuenta caracteres.")]
        public string Titulo { get { return titulo; } set { titulo = value; } }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "Se requiere el autor.")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "El autor debe tener entre tres y cincuenta caracteres.")]
        public string Autor { get { return autor; }set { autor = value; } }

        [DisplayName("Género")]
        [Required(ErrorMessage = "Se requiere el género")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El género debe tener entre tres y cincuenta caracteres.")]
        public string Genero { get { return genero; } set { genero = value; } }




    }
}
