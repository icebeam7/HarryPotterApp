//07
using System;
using System.Windows.Input;
using System.Threading.Tasks;

using HarryPotterApp.Models;

using Xamarin.Forms;
using Xamarin.Essentials;

using Acr.UserDialogs;

namespace HarryPotterApp.ViewModels
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
        private CharacterViewModel _characterVM;

        public CharacterViewModel CharacterVM
        {
            get { return _characterVM; }
            set { _characterVM = value; OnPropertyChanged(); }
        }

        public ICommand SaveCharacterCommand { private set; get; }
        public ICommand DeleteCharacterCommand { private set; get; }

        public CharacterDetailsViewModel(CharacterViewModel character)
        {
            CharacterVM = character;
            SaveCharacterCommand = new Command(async () => await SaveCharacter());
            DeleteCharacterCommand = new Command(async () => await DeleteCharacter());
        }

        async Task SaveCharacter()
        {
            var isInsert = false;

            if (string.IsNullOrWhiteSpace(CharacterVM._id))
            {
                CharacterVM._id = Guid.NewGuid().ToString();
                isInsert = true;
            }

            var hpCharacter = CharacterVM.GetCharacter();

            var success = 0;
            var useLocalStorage = Preferences.Get("UsingLocalStorage", true);

            if (useLocalStorage)
            {
                success = await App.Context.SaveItemAsync<HPCharacter>(hpCharacter, isInsert);
            }
            else
            {
                // TODO: Call REST Service here
            }

            await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Saving...", "OK");
        }

        async Task DeleteCharacter()
        {
            var hpCharacter = CharacterVM.GetCharacter();

            var success = 0;
            var useLocalStorage = Preferences.Get("UsingLocalStorage", true);

            if (useLocalStorage)
            {
                success = await App.Context.DeleteItemAsync<HPCharacter>(hpCharacter);
            }
            else
            {
                // TODO: Call REST Service here
            }

            await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Deleting...", "OK");
        }
    }
}
