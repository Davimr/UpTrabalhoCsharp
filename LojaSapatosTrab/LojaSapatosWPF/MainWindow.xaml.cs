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

namespace LojaSapatosWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "BtnClientes":
                    Window windowCliente = new WindowClientes();
                    windowCliente.ShowDialog();
                    break;
                case "BtnSapato":
                    Window windowSapato = new WindowSapato();
                    windowSapato.ShowDialog();
                    break;
                case "BtnVendas":
                    Window windowVendas = new WindowSapato();
                    windowVendas.ShowDialog();
                    break;
            }
        }
    }
}
