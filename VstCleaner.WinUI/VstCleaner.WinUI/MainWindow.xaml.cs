using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using VstCleaner.DataAccess;
using VstCleaner.ViewModel;


namespace VstCleaner.WinUI
{

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            Whitelist = new WhitelistViewModel(new WhitelistDataProvider());
            Whitelist.Load(JsonPath);

            ViewModel = new MainViewModel(new VstDataProvider());

            VstDirectory = new DirectoryViewModel();

        }


        public MainViewModel ViewModel { get; }

        public WhitelistViewModel Whitelist { get; }

        public DirectoryViewModel VstDirectory { get; private set; }


        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Whitelist.AddToWhitelist(ViewModel.SelectedVst);
            Whitelist.SaveWhiteList(JsonPath);
        }

        void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Whitelist.RemoveFromWhitelist(Whitelist.SelectedVst);
            Whitelist.SaveWhiteList(JsonPath);
        }


        void GetVstDirectory_Click(object sender, RoutedEventArgs e)
        {
            VstDirectory.GetDir();
            ViewModel.Load(VstDirectory.VstPath);
        }

        async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var VstsNotWhitelisted = ViewModel.Vsts.Except(Whitelist.Vsts).ToList();

            if (VstsNotWhitelisted != null)
            {
                ContentDialog deleteFileDialog = new ContentDialog
                {
                    Title = "Delete file(s) permanently?",
                    Content = "If you delete the file, you won't be able to recover it. Are you sure you want to delete it?",
                    PrimaryButtonText = "Delete",
                    CloseButtonText = "Cancel"
                };

                deleteFileDialog.XamlRoot = this.Content.XamlRoot;

                ContentDialogResult result = await deleteFileDialog.ShowAsync();

                // Delete the file if the user clicked the primary button.
                if (result == ContentDialogResult.Primary)
                {
                    MainViewModel.Delete(VstsNotWhitelisted);
                    ViewModel.Load(VstDirectory.VstPath);
                }

            }
        }


        private string _jsonPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\test.json";
        //private string _jsonPath = @"C:\Users\Trenton\Documents\test.json";

        public string JsonPath
        {
            get { return _jsonPath; }
            set { _jsonPath = value; }
        }

    }
}
