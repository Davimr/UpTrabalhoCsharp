using LojaSapatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatosWPF.ViewModel
{
    public class SapatoViewModel
    {
        public ObservableCollection<Sapato> Sapatos { get; set; }
        public Sapato SapatoSelecionado { get; set; }
        private SapatoModel ContextSapato { get; set; }
        public SapatoViewModel()
        {
            Modelo modelo1 = new LojaSapatos.Modelo()
            {
                Cor = "Preto",
                Material = "Couro",
                PossuiCadarco = false,
                Preco = 109.90M,
            };
            Modelo modelo2 = new LojaSapatos.Modelo()
            {
                Cor = "Branco",
                Material = "Tecido",
                PossuiCadarco = true,
                Preco = 99.90M
            };
            Sapato sapato1 = new LojaSapatos.Sapato()
            {
                Tamanho = 40,
                Modelo = modelo2,
                Marca = "Adidas"
            };
            ItemEstoque item1Estoque = new LojaSapatos.ItemEstoque()
            {
                Quantidade = 28,
                Sapato = sapato1,
            };
            

            this.ContextSapato = new SapatoModel();
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextSapato.Sapatos.ToList());

            Sapatos.Add(sapato1);

            SapatoSelecionado = this.Sapatos.FirstOrDefault();
        }

        public void Salvar()
        {
            this.ContextSapato.SaveChanges();
        }

        public void Adicionar()
        {
            Sapato sapato = new LojaSapatos.Sapato();
            this.Sapatos.Add(sapato);
            SapatoSelecionado = sapato;


        }

        public void Remover()
        {
            this.ContextSapato.Sapatos.Remove(SapatoSelecionado);
            this.Sapatos.Remove(SapatoSelecionado);
            SapatoSelecionado = this.Sapatos.FirstOrDefault();
        }
    }
}
