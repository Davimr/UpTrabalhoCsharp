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
    /// Lógica interna para WindowPessoaJuridica.xaml
    /// </summary>
    public partial class WindowPessoaJuridica : Window
    {
        public LojaSapatos.PessoaJuridica Cliente { get; set; }
        public ViewModel.ClienteViewModel ClienteViewModel { get; set; }
        public ViewModel.VendaViewModel VendaViewModel { get; set; }
        public Venda VendaSelecionada { get; set; }
        public WindowPessoaJuridica()
        {
            InitializeComponent();
            this.DataContext = this;
            this.ClienteViewModel = new ViewModel.ClienteViewModel();
            this.VendaViewModel = new ViewModel.VendaViewModel();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            ClienteViewModel.ClienteSelecionado = Cliente;
            ClienteViewModel.Remover();

            this.Close();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                this.VendaSelecionada = new Venda();
                this.VendaSelecionada = (LojaSapatos.Venda)e.AddedItems[0];
                this.valorTotal.Text = VendaSelecionada.ValorTotal.ToString();
                this.quantidadeTotal.Text = VendaSelecionada.QuantidadeTotal.ToString();
                this.dataVenda.SelectedDate = VendaSelecionada.DataVenda;
        }
    }
}