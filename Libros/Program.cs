using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libros.Model;
using Libros.Presenter;
using Libros.Repositories;
using Libros.View;
using System.Configuration;

namespace Libros
{
     static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            ILibroView view = new LibroView();
            ILibroRepository libroRepository = new LibroRepository(sqlConnectionString);
            new LibroPresenter(view, libroRepository);

            Application.Run((Form)view);
        }
    }
}
