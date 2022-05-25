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


        void addButton_Click(object sender, RoutedEventArgs e)
        {
            Whitelist.AddToWhitelist(ViewModel.SelectedVst);
            Debug.WriteLine($"Add to whitelist button clicked");

        }

        void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Whitelist.SaveWhiteList(JsonPath);
            Debug.WriteLine($"Save whitelist button clicked");

        }

        void getVstDirectory_Click(object sender, RoutedEventArgs e)
        {
            VstDirectory.GetDir();
            Debug.WriteLine($"Get Vst Directory button clicked");
            ViewModel.Load(VstDirectory.VstPath);


        }

        private string _jsonPath = @"C:\Users\Trenton\Documents\test.json";

        public string JsonPath
        {
            get { return _jsonPath; }
            set { _jsonPath = value; }
        }



    }
}
