using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        private const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";
        public ObservableCollection<Veiculo> Veiculos { get; set; }

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

        private bool aguarde;
        public bool Aguarde
        {
            get
            {
                return aguarde;
            }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public ListagemViewModel()
        {    
            Veiculos = new ObservableCollection<Veiculo>();
        }

        public async void GetVeiculos()
        {
            Aguarde = true;
            var client = new HttpClient();
            var resultado = await client.GetStringAsync(URL_GET_VEICULOS);
            foreach (var veiculo in JsonConvert.DeserializeObject<Veiculo[]>(resultado))
            {
                Veiculos.Add(veiculo);
            }

            Aguarde = false;
        }
    }
}