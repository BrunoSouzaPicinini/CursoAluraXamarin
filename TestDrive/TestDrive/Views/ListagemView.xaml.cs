using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            Veiculos = new ListagemVeiculos().Veiculos;

            BindingContext = this;
        }

        private void ListViewVeiculos_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = e.Item as Veiculo;

            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}