using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libros.View
{
    public partial class LibroView : Form, ILibroView
    {
        public LibroView()
        {
            InitializeComponent();
        }

        public string LibroId
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Titulo
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string Autor 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Genero
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string BuscarPorValor
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsEditar 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsCorrecto
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Mensaje
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public event EventHandler BuscarEvento;
        public event EventHandler Agregarevento;
        public event EventHandler EditarEvento;
        public event EventHandler BorrarEvento;
        public event EventHandler GuardarEvento;
        public event EventHandler CancelarEvento;

        public void SetListaLibrosBindingSource(BindingSource listaLibros)
        {
            throw new NotImplementedException();
        }
    }
}
