using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VstCleaner.DataAccess;
using VstCleaner.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;


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
            Debug.WriteLine($"Add to whitelist button clicked");
            Whitelist.SaveWhiteList(JsonPath);
        }

        void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Whitelist.RemoveFromWhitelist(Whitelist.SelectedVst);
            Debug.WriteLine($"Remove from whitelist button clicked");
            Whitelist.SaveWhiteList(JsonPath);
        }


        void GetVstDirectory_Click(object sender, RoutedEventArgs e)
        {
            VstDirectory.GetDir();
            Debug.WriteLine($"Get Vst Directory button clicked");
            ViewModel.Load(VstDirectory.VstPath);
        }

        void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Delete(Whitelist.Vsts);
            Debug.WriteLine($"Delete Vsts button clicked");
        }


        private string _jsonPath = @"C:\Users\Trenton\Documents\test.json";

        public string JsonPath
        {
            get { return _jsonPath; }
            set { _jsonPath = value; }
        }



    }
}
