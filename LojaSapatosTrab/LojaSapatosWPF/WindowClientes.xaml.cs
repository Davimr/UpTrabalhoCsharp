using LojaSapatos;
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
            ClienteViewModel.Salvar();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var x = e.AddedItems[0];
            ClienteViewModel.ClienteSelecionado = (LojaSapatos.Pessoa)x;

            Window PaginaEspecifica = CarregarAbaEspecificaPessoa(ClienteViewModel.ClienteSelecionado);
            PaginaEspecifica.ShowDialog();
        }

        static public Window CarregarAbaEspecificaPessoa(Pessoa pessoa)
        {

            if (pessoa is PessoaFisica)
            {
                var PaginaEspecifica = new WindowPessoaFisica();
                PaginaEspecifica.Cliente = (PessoaFisica)pessoa;
                return PaginaEspecifica;

            }
            else if (pessoa is PessoaJuridica)
            {
                var PaginaEspecifica = new WindowPessoaJuridica();
                PaginaEspecifica.Cliente = (PessoaJuridica)pessoa;
                return PaginaEspecifica;
            }
            return null;
        }

        private void btnAddPessoaJuridica_Click(object sender, RoutedEventArgs e)
        {
            this.ClienteViewModel.AdicionarPessoaJuridica();
        }

        private void btnAddPessoaFisica_Click(object sender, RoutedEventArgs e)
        {
            this.ClienteViewModel.AdicionarPessoaFisica();
        }
    }


}
