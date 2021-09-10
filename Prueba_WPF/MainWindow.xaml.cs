using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prueba_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private ObjLista Listado = new ObjLista();
        private void Main_Initialized(object sender, EventArgs e)
        {
            this.Show();
            Listado.RecibirDatos(this);
            MostrarDatos();
        }
        private void MostrarDatos()// carga la lista del formulario toda la lista que hemos recopilado.
        {
            int i = 0;
            Lista.Items.Clear();
            for (i = 0; i < (Listado.Count() - 1); i++)
            {
                Lista.Items.Add(Listado.Nombre(i));
                this.Title = "Añadido personaje:" + Listado.Nombre(i);
            }
        }
        private bool HeightOk(int Altura)
        {
            if (Altura > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool DataOk(string cadena)// devuelve verdadero solo si la cadena no es alguno de estos casos
        {
            switch (cadena.Trim().ToUpper())
            {
                case "N/A": return false;
                case "NONE": return false;
                case "": return false;
                case "NINGUNO": return false;
                case "NINGUNA": return false;
                case "VACIO": return false;
                case "DESCONOCIDO": return false;
                case "UNKNOWN": return false;
                default: return true;
            }
        }
        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LblNombre.Content = "Nombre: " + Listado.Nombre(Lista.SelectedIndex);
            if (DataOk(Listado.Nombre(Lista.SelectedIndex)) == true)
            {
                LblNombre.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                LblNombre.Visibility = System.Windows.Visibility.Hidden;
            }
            LblAltura.Content = "Altura: " + Listado.Altura(Lista.SelectedIndex);
            if (HeightOk(Listado.Altura(Lista.SelectedIndex)) == true)
            {
                LblAltura.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                LblAltura.Visibility = System.Windows.Visibility.Hidden;
            }
            LblColorPelo.Content = "Color de pelo: " + Listado.ColorPelo(Lista.SelectedIndex);
            if (DataOk(Listado.ColorPelo(Lista.SelectedIndex)) == true)
            {
                LblColorPelo.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                LblColorPelo.Visibility = System.Windows.Visibility.Hidden;
            }
            LblGenero.Content = "Género: " + Listado.Genero(Lista.SelectedIndex);
            if (DataOk(Listado.Genero(Lista.SelectedIndex)) == true)
            {
                LblGenero.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                LblGenero.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void BtnSortByName_Click(object sender, RoutedEventArgs e)
        {
            Listado.SortByName();
            MostrarDatos();
        }

        private void BtnSoprtByHeight_Click(object sender, RoutedEventArgs e)
        {
            Listado.SortByHeight();
            MostrarDatos();
        }
    }
}
