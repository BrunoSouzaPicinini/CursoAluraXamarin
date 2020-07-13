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

        public string TextoFreioAbs => $"Freio ABS - R$ {FREIO_ABS}";
        public string TextoArCondicionado => $"Ar Condicionado - R$ {AR_CONDICIONADO}";
        public string TextoMp3Player => $"MP3 Player - R$ {MP3_PLAYER}";

        public string ValorTotal =>
            $"Valor Total: R${Veiculo.Preco + (_temFreioAbs ? FREIO_ABS : 0) + (_temArCondicionado ? AR_CONDICIONADO : 0) + (_temMp3Player ? MP3_PLAYER : 0)}";

        private bool _temFreioAbs;

        public bool TemFreioAbs
        {
            get { return _temFreioAbs; }
            set
            {
                _temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool _temArCondicionado;

        public bool TemArCondicionado
        {
            get { return _temArCondicionado; }
            set
            {
                _temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        private bool _temMp3Player;
        public bool TemMp3Player
        {
            get { return _temMp3Player; }
            set
            {
                _temMp3Player = value;
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