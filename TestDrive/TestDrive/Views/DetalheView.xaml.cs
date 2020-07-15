using System;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs => $"Freio ABS - R$ {Veiculo.FREIO_ABS}";
        public string TextoArCondicionado => $"Ar Condicionado - R$ {Veiculo.AR_CONDICIONADO}";
        public string TextoMp3Player => $"MP3 Player - R$ {Veiculo.MP3_PLAYER}";
        public string ValorTotal => Veiculo.PrecoTotalFormatado;

        public bool TemFreioAbs
        {
            get { return Veiculo.TemFreioAbs; }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get { return Veiculo.TemArCondicionado; }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMp3Player
        {
            get { return Veiculo.TemMP3Player; }
            set
            {
                Veiculo.TemMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;

            BindingContext = this;
        }

        private void ButtonProximo_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}