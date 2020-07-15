using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Agendamento Agendamento { get; set; }
        
        public Veiculo Veiculo { get { return Agendamento.Veiculo;} set { Agendamento.Veiculo = value; } }
        public string Nome { get{return Agendamento.Nome;} set{Agendamento.Nome = value;} }
        public string Fone { get{return Agendamento.Fone;} set{Agendamento.Fone = value;} }
        public string Email { get{return Agendamento.Email;} set{Agendamento.Email = value;} }
        public DateTime DataAgendamento { get{return Agendamento.DataAgendamento;} set{Agendamento.DataAgendamento = value;} }
        public TimeSpan HoraAgendamento { get{return Agendamento.HoraAgendamento;} set{Agendamento.HoraAgendamento = value;} }

        public AgendamentoView(Veiculo veiculo)
        {
            Agendamento = new Agendamento{Veiculo = veiculo};
            DataAgendamento = DateTime.Today;
            InitializeComponent();

            BindingContext = this;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", 
                $@"
Veiculo: {Veiculo.Nome}
Nome: {Nome}
Fone: {Fone}
E-mail: {Email}
Data Agendamento: {DataAgendamento:dd/MM/yyyy}
Hora Agendamento: {HoraAgendamento}"
                , "Ok");
        }
    }
}