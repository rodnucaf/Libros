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
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnLibros.Click += delegate { ShowLibroView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowLibroView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowUserView;
    }
}
