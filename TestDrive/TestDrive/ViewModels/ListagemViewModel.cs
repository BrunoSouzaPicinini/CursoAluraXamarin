using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado { get; set; }

        public Veiculo VeiculoSelecionado
        {
            get => veiculoSelecionado;
            set
            {
                veiculoSelecionado = value;
                if(value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel()
        {
            Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}