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
        private string mensaje;
        private bool esCorrecto;
        private bool isEditar;

        public LibroView()
        {
            InitializeComponent();
        }

        //Propiedades
        public string LibroId
        {
            get { return txtIdLibro.Text; }
            set { txtIdLibro.Text = value; }
        }

        public string Titulo
        {
            get { return txtTitulo.Text; }
            set { txtTitulo.Text = value; }
        }
        public string Autor 
        {
            get { return txtAutor.Text; }
            set { txtAutor.Text = value; }
        }

        public string Genero
        {
            get { return txtGenero.Text; }
            set { txtGenero.Text = value; }
        }

        public string BuscarPorValor
        {
            get { return txtBuscar.Text; }
            set { txtBuscar.Text = value; }
        }

        public bool IsEditar 
        {
            get { return isEditar; }
            set { isEditar = value; }
        }

        public bool IsCorrecto
        {
            get { return esCorrecto; }
            set { esCorrecto = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        //Eventos
        public event EventHandler BuscarEvento;
        public event EventHandler Agregarevento;
        public event EventHandler EditarEvento;
        public event EventHandler BorrarEvento;
        public event EventHandler GuardarEvento;
        public event EventHandler CancelarEvento;

        //Métodos
        public void SetListaLibrosBindingSource(BindingSource listaLibros)
        {
            dgvLibros.DataSource = listaLibros;
        }
        
    }
}
