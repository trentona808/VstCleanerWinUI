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
        private string _jsonPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\test.json";

        public MainWindow()
        {
            this.InitializeComponent();

            Whitelist = new WhitelistViewModel(new WhitelistDataProvider());
            Whitelist.Load(JsonPath);

            ViewModel = new MainViewModel(new VstDataProvider());

            VstDirectory = new DirectoryViewModel();
        }


        public string JsonPath
        {
            get { return _jsonPath; }
            set { _jsonPath = value; }
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
                var deleteFileDialog = MainViewModel.DisplayDeleteFileDialog(VstsNotWhitelisted);

                deleteFileDialog.XamlRoot = this.Content.XamlRoot;

                ContentDialogResult result = await deleteFileDialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    try
                    {
                        MainViewModel.Delete(VstsNotWhitelisted);
                        ViewModel.Load(VstDirectory.VstPath);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        var unauthorizedAccessDialog = MainViewModel.DisplayUnauthorizedAccessDialog();
                        unauthorizedAccessDialog.XamlRoot = this.Content.XamlRoot;
                        await unauthorizedAccessDialog.ShowAsync();
                    }
                }
            }
        }


    }
}
