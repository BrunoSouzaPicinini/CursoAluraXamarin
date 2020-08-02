using System;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }
        
        public Veiculo Veiculo { get { return Agendamento.Veiculo;} set { Agendamento.Veiculo = value; } }
        public string Nome { get{return Agendamento.Nome;} set{Agendamento.Nome = value;} }
        public string Fone { get{return Agendamento.Fone;} set{Agendamento.Fone = value;} }
        public string Email { get{return Agendamento.Email;} set{Agendamento.Email = value;} }
        public DateTime DataAgendamento { get{return Agendamento.DataAgendamento;} set{Agendamento.DataAgendamento = value;} }
        public TimeSpan HoraAgendamento { get{return Agendamento.HoraAgendamento;} set{Agendamento.HoraAgendamento = value;} }

        public ICommand AgendarCommand { get; set; }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            Agendamento = new Agendamento{Veiculo = veiculo};
            Agendamento.DataAgendamento = DateTime.Today;
            Agendamento.Veiculo = veiculo;
            
            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(Agendamento, "Agendamento");
            });
        }
    }
}