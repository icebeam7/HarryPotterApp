//03 y final
using System;
using System.IO;

using Xamarin.Forms;

using HarryPotterApp.Data;

namespace HarryPotterApp
{
    public partial class App : Application
    {
        private static DatabaseContext context;

        public static DatabaseContext Context
        {
            get
            {
                if (context == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "HarryPotterDB.db3");

                    context = new DatabaseContext(dbPath); 
                }

                return context;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.CharactersListView());
        }
    }
}
