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
            AssociateAndRaiseViewEvents();
            tabControl.TabPages.Remove(tpDetalle);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnBuscar.Click += delegate { EventBuscar?.Invoke(this, EventArgs.Empty);};
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { EventBuscar?.Invoke(this, EventArgs.Empty); }
            };

            txtBuscar.TextChanged += (s, e) =>
            {
                
                BuscarEvento?.Invoke(this, EventArgs.Empty);
            };
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
        public event EventHandler EventBuscar;
        public event EventHandler EventAgregar;
        public event EventHandler EventEditar;
        public event EventHandler EventBorrar;
        public event EventHandler EventGuardar;
        public event EventHandler EventCancelar;
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

        private static LibroView instancia;
        public static LibroView ObtenerInstancia(Form parentContainer)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new LibroView();
                instancia.MdiParent = parentContainer;
            }
            else
            {
                if (instancia.WindowState==FormWindowState.Minimized)
                { instancia.WindowState = FormWindowState.Maximized; }
                instancia.BringToFront();
            }
            return instancia;
        }

    }
}
