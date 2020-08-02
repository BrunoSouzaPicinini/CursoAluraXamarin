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

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
                $@"
Veiculo: {ViewModel.Veiculo.Nome}
Nome: {ViewModel.Nome}
Fone: {ViewModel.Fone}
E-mail: {ViewModel.Email}
Data Agendamento: {ViewModel.DataAgendamento:dd/MM/yyyy}
Hora Agendamento: {ViewModel.HoraAgendamento}"
                , "Ok");
        }
    }
}