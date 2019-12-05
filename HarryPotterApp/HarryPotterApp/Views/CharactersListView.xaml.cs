using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HarryPotterApp.ViewModels;

namespace HarryPotterApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersListView : ContentPage
    {
        CharactersListViewModel vm;

        public CharactersListView()
        {
            InitializeComponent();

            vm = new CharactersListViewModel(Navigation);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SearchByNameCommand.Execute(string.Empty);
        }
    }
}