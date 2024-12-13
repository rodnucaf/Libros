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
            btnCerrar.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Buscar
            btnBuscar.Click += delegate { BuscarEvento?.Invoke(this, EventArgs.Empty);};
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { BuscarEvento?.Invoke(this, EventArgs.Empty); }
            };

            txtBuscar.TextChanged += (s, e) =>
            {
                
                BuscarEvento?.Invoke(this, EventArgs.Empty);
            };

            //Agregar
            btnAgregar.Click += delegate
            {
                Agregarevento?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(tpListado);
                tabControl.TabPages.Add(tpDetalle);
                tpDetalle.Text = "Agregar Libro";
            };

            //Modificar
            btnModificar.Click += delegate
            {
                EditarEvento?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(tpListado);
                tabControl.TabPages.Add(tpDetalle);
                tpDetalle.Text = "Editar Libro";
            };
            //GuardarCambios
            btnGuardar.Click += delegate
            {
                GuardarEvento?.Invoke(this, EventArgs.Empty);
                if (esCorrecto)
                {
                    tabControl.TabPages.Remove(tpDetalle);
                    tabControl.TabPages.Add(tpListado);
                }
                MessageBox.Show(mensaje);
            };
            //Eliminar
            btnEliminar.Click += delegate
            {
                BorrarEvento?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(tpDetalle);
                tabControl.TabPages.Add(tpListado);
            };
            //Cancelar
            btnCancelar.Click += delegate
            {   
               var resultado = MessageBox.Show("¿Está seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    CancelarEvento?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(mensaje);                                }
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
        //public event EventHandler EventBuscar;
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
                instancia.FormBorderStyle = FormBorderStyle.None;
                instancia.Dock = DockStyle.Fill;
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
