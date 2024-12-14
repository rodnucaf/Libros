using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libros.View
{
    public interface ILibroView
    {

        //Propiedades
        string LibroId { get; set; }
        string Titulo { get; set; }
        string Autor { get; set; }
        string Genero { get; set; }

        string BuscarPorValor { get; set; }
        bool IsEditar { get; set; }
        bool IsCorrecto { get; set; }
        string Mensaje { get; set; }

        //Eventos
        event EventHandler BuscarEvento;
        event EventHandler Agregarevento;
        event EventHandler EditarEvento;
        event EventHandler BorrarEvento;
        event EventHandler GuardarEvento;
        event EventHandler CancelarEvento;

        //Métodos
        void SetListaLibrosBindingSource(BindingSource listaLibros);
        void Show();



    }
}
