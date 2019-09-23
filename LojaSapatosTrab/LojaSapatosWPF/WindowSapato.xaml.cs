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
    /// Lógica interna para WindowSapato.xaml
    /// </summary>
    public partial class WindowSapato : Window
    {
        public ViewModel.SapatoViewModel SapatoViewModel { get; set; }
        public WindowSapato()
        {
            InitializeComponent();
            this.SapatoViewModel = new ViewModel.SapatoViewModel();
            this.DataContext = this.SapatoViewModel;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            SapatoViewModel.Salvar();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            SapatoViewModel.Adicionar();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            SapatoViewModel.Remover();
        }
    }
}
