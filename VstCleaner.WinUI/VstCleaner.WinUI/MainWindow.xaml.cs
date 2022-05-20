using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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

            ViewModel = new MainViewModel(new VstDataProvider());
            //this.Activated += MainWindow_Activated;

            ViewModel.Load();

            test = "Test";
            //VD = VstDataProvider.VstDir;
            vD = "string";
            DP = new VstDataProvider();
            //vDD = DP.VstDir;
        }



        public MainViewModel ViewModel { get; }

        public string test { get; set; }

        public string VD { get; private set; }

        public string vD { get; set; }
        public VstDataProvider DP { get; private set; }
        public string vDD { get; private set; }


        //void refreshButtonClick(object sender, RoutedEventArgs e)
        //{
        //    myButton.Content = "Clicked";
        //}


    }
}
