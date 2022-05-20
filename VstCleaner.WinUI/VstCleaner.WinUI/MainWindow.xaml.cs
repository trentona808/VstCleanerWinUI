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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace VstCleaner.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
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

        //private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        //{


        //    if (ViewModel.Vsts.Count == 0)
        //    {
        //        ViewModel.Load();
        //    }
        //}

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
