using LojaSapatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatosWPF.ViewModel
{
    public class ModeloViewModel
    {
        public ObservableCollection<Modelo> Modelos { get; set; }
        public Modelo ModeloSelecionado { get; set; }
        private SapatoModel ContextModelo { get; set; }
        public ModeloViewModel()
        {
            ContextModelo = new SapatoModel();
            Modelos = new ObservableCollection<Modelo>(ContextModelo.Modelos.ToList());

            ModeloSelecionado = this.Modelos.FirstOrDefault();
        }

        public void Adicionar()
        {
            Modelo modelo = new Modelo();
            this.Modelos.Add(modelo);
            this.ModeloSelecionado = modelo;
            this.ContextModelo.Modelos.Add(modelo);
        }

        public void Remover()
        {
            var modeloDelete = this.ContextModelo.Modelos.Find(ModeloSelecionado.Id);
            this.ContextModelo.Modelos.Remove(modeloDelete);
            this.Salvar();
            Modelos = new ObservableCollection<Modelo>(ContextModelo.Modelos.ToList());
            ModeloSelecionado = this.Modelos.FirstOrDefault();
        }


        public void Salvar()
        {
            this.ContextModelo.SaveChanges();
        }
    }
}
