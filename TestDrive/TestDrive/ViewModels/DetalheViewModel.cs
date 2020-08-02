using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
    {    
        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs => $"Freio ABS - R$ {Veiculo.FREIO_ABS}";
        public string TextoArCondicionado => $"Ar Condicionado - R$ {Veiculo.AR_CONDICIONADO}";
        public string TextoMp3Player => $"MP3 Player - R$ {Veiculo.MP3_PLAYER}";
        public string ValorTotal => Veiculo.PrecoTotalFormatado;

        public ICommand ProximoCommand { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public DetalheViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}