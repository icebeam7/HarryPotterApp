using System;
using System.Windows.Input;
using System.Threading.Tasks;

using HarryPotterApp.Models;

using Xamarin.Forms;
using Xamarin.Essentials;

using Acr.UserDialogs;
using HarryPotterApp.Services;

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
                var service = new RESTService();
                HPCharacter result;
                if (isInsert)
                    result = await service.AddCharacter(hpCharacter);
                else
                    result = await service.EditCharacter(hpCharacter);
                success = result != null ? 2 : 0;
            }

            await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Saving...", "OK");
        }

        async Task DeleteCharacter()
        {
            var confirm = await UserDialogs.Instance.ConfirmAsync("Are you sure?", "Delete?", "Yes", "No");

            if (confirm)
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
                    var service = new RESTService();
                    var result = await service.DeleteCharacter(hpCharacter._id);
                    success = result ? 2 : 0;
                }

                await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Deleting...", "OK");
            }
        }
    }
}
