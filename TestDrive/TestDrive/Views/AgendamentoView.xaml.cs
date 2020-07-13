using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public DateTime DataAgendamento { get; set; } = DateTime.Today;
        public TimeSpan HoraAgendamento { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();

            Veiculo = veiculo;
            BindingContext = this;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", 
                $@"Nome: {Nome}
Fone: {Fone}
E-mail: {Email}
Data Agendamento: {DataAgendamento:dd/MM/yyyy}
Hora Agendamento: {HoraAgendamento}"
                , "Ok");
        }
    }
}