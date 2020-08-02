using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        
        public AgendamentoView(Veiculo veiculo)
        {
            ViewModel = new AgendamentoViewModel(veiculo);
            InitializeComponent();

            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", (msg) =>
            {
                DisplayAlert("Agendamento",
                $@"
Veiculo: {ViewModel.Agendamento.Veiculo.Nome}
Nome: {ViewModel.Agendamento.Nome}
Fone: {ViewModel.Agendamento.Fone}
E-mail: {ViewModel.Agendamento.Email}
Data Agendamento: {ViewModel.Agendamento.DataAgendamento:dd/MM/yyyy}
Hora Agendamento: {ViewModel.Agendamento.HoraAgendamento}"
                , "Ok");    
            });
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }
    }
}