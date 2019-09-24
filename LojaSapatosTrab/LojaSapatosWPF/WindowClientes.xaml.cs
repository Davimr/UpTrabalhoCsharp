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
    /// Lógica interna para WindowClientes.xaml
    /// </summary>
    public partial class WindowClientes : Window
    {
        public ViewModel.ClienteViewModel ClienteViewModel { get; set; }
        public WindowClientes()
        {
            InitializeComponent();
            this.ClienteViewModel = new ViewModel.ClienteViewModel();
            this.DataContext = this.ClienteViewModel;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ClienteViewModel.Salvar();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            ClienteViewModel.Adicionar();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            ClienteViewModel.Remover();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var x = e.AddedItems[0];
            ClienteViewModel.ClienteSelecionado = (LojaSapatos.Pessoa)x;
        }
    }
}
