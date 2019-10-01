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
using System.Windows.Shapes;

namespace LojaSapatosWPF
{
    /// <summary>
    /// Lógica interna para WindowModelo.xaml
    /// </summary>
    public partial class WindowModelo : Window
    {
        public ViewModel.ModeloViewModel ModeloViewModel { get; set;}
     
    public WindowModelo()
        {
            InitializeComponent();
            this.ModeloViewModel = new ViewModel.ModeloViewModel();
            this.DataContext = this.ModeloViewModel;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ModeloViewModel.Salvar();
            this.Close();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            ModeloViewModel.Adicionar();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = e.AddedItems[0];
            ModeloViewModel.ModeloSelecionado = (LojaSapatos.Modelo)x;
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            ModeloViewModel.Remover();
            this.Close();
        }
    }
}
