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
    /// Lógica interna para WindowVendas.xaml
    /// </summary>
    public partial class WindowVendas : Window
    {
        public ViewModel.VendaViewModel VendaViewModel { get; set; }
        public WindowVendas()
        {
            InitializeComponent();
            this.VendaViewModel = new ViewModel.VendaViewModel();
            this.DataContext = this.VendaViewModel;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            VendaViewModel.Salvar();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            VendaViewModel.Adicionar();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            VendaViewModel.Remover();
        }
    }
}
