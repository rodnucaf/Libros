using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libros.Model;
using Libros.View;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
            var modelo = new Libro();
            modelo.Id = Convert.ToInt32(view.LibroId);
            modelo.Titulo = view.Titulo;
            modelo.Autor = view.Autor;
            modelo.Genero = view.Genero;

            try
            {

            }
            catch (Exception ex)
            {

                view.IsCorrecto = false;
                view.Mensaje = ex.Message;
            }

        }

        private void BorrarLibroSeleccionado(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AgregarlibroSeleccionadoEditar(object sender, EventArgs e)
        {
            var libro = (Libro)libroBindingSource.Current;
            view.LibroId = libro.Id.ToString();
            view.Titulo = libro.Titulo;
            view.Autor = libro.Autor;
            view.Genero = libro.Genero;
            view.IsEditar = true;
        }

        private void AgregarLibro(object sender, EventArgs e)
        {
            view.IsEditar = false;
        }

        
    }
}
