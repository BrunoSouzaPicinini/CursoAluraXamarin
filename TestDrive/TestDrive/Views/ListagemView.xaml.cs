using System.Collections.Generic;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public string PrecoFormatado => $"R$ {Preco}";
    }

    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            Veiculos = new List<Veiculo>()
            {
                new Veiculo {Nome = "Azera V6", Preco = 60000},
                new Veiculo {Nome = "Fiesta 2.0", Preco = 50000},
                new Veiculo {Nome = "HB20 S", Preco = 40000}
            };

            BindingContext = this;
        }

        private void ListViewVeiculos_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = e.Item as Veiculo;

            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}