using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using HarryPotterApp.Models;

using Xamarin.Forms;
using Xamarin.Essentials;

namespace HarryPotterApp.ViewModels
{
    public class CharactersListViewModel : BaseViewModel
    {
        private ObservableCollection<CharacterViewModel> _characters;

        public ObservableCollection<CharacterViewModel> Characters
        {
            get { return _characters; }
            set { _characters = value; OnPropertyChanged(); }
        }

        private CharacterViewModel _selectedCharacter;

        public CharacterViewModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { _selectedCharacter = value; OnPropertyChanged(); }
        }

        private bool _useLocalStorage;

        public bool UseLocalStorage
        {
            get { return _useLocalStorage; }
            set { _useLocalStorage = value; OnPropertyChanged(); }
        }

        public ICommand SearchByNameCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }
        public ICommand AddNewCharacterCommand { private set; get; }
        public ICommand SetStorageCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public CharactersListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            UseLocalStorage = Preferences.Get("UsingLocalStorage", true);

            SearchByNameCommand = new Command<string>(async (name) => await LoadData(name));
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));
            AddNewCharacterCommand = new Command<Type>(async (pageType) => await AddNewCharacter(pageType));
            SetStorageCommand = new Command(() => SetStorage());
        }

        async Task LoadData(string name)
        {
            Characters = new ObservableCollection<CharacterViewModel>();
            List<HPCharacter> hpCharacters = new List<HPCharacter>();

            if (UseLocalStorage)
            {
                hpCharacters = string.IsNullOrWhiteSpace(name)
                    ? await App.Context.GetItemsAsync<HPCharacter>()
                    : await App.Context.FilterItemsAsync<HPCharacter>("HPCharacter", $"name LIKE '{name}'");
            }
            else
            {
                // TODO: Call REST Service here
            }

            foreach (var item in hpCharacters)
                Characters.Add(new CharacterViewModel(item));
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedCharacter != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.BindingContext = new CharacterDetailsViewModel(SelectedCharacter);
                await Navigation.PushAsync(page);

                SelectedCharacter = null;
            }
        }

        async Task AddNewCharacter(Type pageType)
        {
            SelectedCharacter = null;

            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = new CharacterDetailsViewModel(new CharacterViewModel());
            await Navigation.PushAsync(page);
        }

        void SetStorage()
        {
            Preferences.Set("UsingLocalStorage", UseLocalStorage);
            Task.Run(async () => await LoadData(string.Empty));
        }
    }
}
