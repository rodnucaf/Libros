using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Model
{
    public interface ILibroRepository
    {
        void Add(Libro libro);
        void Edit(Libro libro);
        void Delete(int id);

        IEnumerable<Libro> ObtenerTodo();
        IEnumerable<Libro> ObtenerPorValor(string valor);


    }
}
