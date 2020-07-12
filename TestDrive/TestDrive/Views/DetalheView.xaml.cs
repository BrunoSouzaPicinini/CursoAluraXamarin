using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;

        public string TextoFreioABS => $"Freio ABS - R$ {FREIO_ABS}";
        public string TextoArCondicionado => $"Ar Condicionado - R$ {AR_CONDICIONADO}";
        public string TextoMp3Player => $"MP3 Player - R$ {MP3_PLAYER}";

        public string ValorTotal =>
            $"Valor Total: R${Veiculo.Preco + (temFreioABS ? FREIO_ABS : 0) + (temArCondicionado ? AR_CONDICIONADO : 0) + (temMP3Player ? MP3_PLAYER : 0)}";

        private bool temFreioABS;

        public bool TemFreioABS
        {
            get { return temFreioABS; }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool temArCondicionado;

        public bool TemArCondicionado
        {
            get { return temArCondicionado; }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool temMP3Player;
        public bool TemMP3Player
        {
            get { return temMP3Player; }
            set
            {
                temMP3Player = value;
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