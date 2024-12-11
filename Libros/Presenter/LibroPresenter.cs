using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libros.Model;
using Libros.View;

namespace Libros.Presenter
{
    public class LibroPresenter
    {
        private ILibroView view;
        private ILibroRepository repository;
        private BindingSource libroBindingSource;
        private IEnumerable<Libro> listaLibro;

        //Constructor
        public LibroPresenter(ILibroView view, ILibroRepository repository)
        {
            this.libroBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Suscribir métodos EventHandler a los métodos View
            this.view.BuscarEvento += BuscarLibro;
            this.view.Agregarevento += AgregarLibro;
            this.view.EditarEvento += AgregarlibroSeleccionadoEditar;
            this.view.BorrarEvento += BorrarLibroSeleccionado;
            this.view.GuardarEvento += GuardarLibroSeleccionado;
            this.view.CancelarEvento += CancelarAccion;
            //Libros Binding Source
            this.view.SetListaLibrosBindingSource(libroBindingSource);
            //Cargar lista
            CargarListaLibros();
            //Mostrar
            this.view.Show();


        }

        //Métodos
        private void CargarListaLibros()
        {
            listaLibro = repository.ObtenerTodo();
            libroBindingSource.DataSource = listaLibro;
        }

        private void BuscarLibro(object sender, EventArgs e)
        {
            bool vacio = string.IsNullOrWhiteSpace(this.view.BuscarPorValor);

            if (vacio == false)
            {
                listaLibro = repository.ObtenerPorValor(this.view.BuscarPorValor);
            }
            else
            {
                listaLibro = repository.ObtenerTodo();
                
            }
            libroBindingSource.DataSource = listaLibro;
        }

        private void CancelarAccion(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GuardarLibroSeleccionado(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BorrarLibroSeleccionado(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AgregarlibroSeleccionadoEditar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AgregarLibro(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
