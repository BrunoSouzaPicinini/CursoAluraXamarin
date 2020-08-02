using System.Collections.Generic;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemViewModel()
        {
            Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}