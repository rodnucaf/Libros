using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libros.View;
using Libros.Repositories;
using Libros.Model;
using System.Data.SqlClient;


namespace Libros.Presenter
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;

            this.mainView.ShowLibroView += ShowLibrosView;
        }

        private void ShowLibrosView(object sender, EventArgs e)
        {
            ILibroView view = new LibroView();
            ILibroRepository libroRepository = new LibroRepository(sqlConnectionString);
            new LibroPresenter(view, libroRepository);
        }
    }
}
