using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;

namespace VstCleaner.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IVstDataProvider _vstDataProvider;
        private VstViewModel _selectedVst;


        public MainViewModel(IVstDataProvider vstDataProvider)
        {
            _vstDataProvider = vstDataProvider;
        }


        public ObservableCollection<VstViewModel> Vsts { get; set; } = new();

        public IEnumerable<Vst> vsts { get; set; }

        public VstViewModel SelectedVst
        {
            get { return _selectedVst; }
            set
            {
                if (_selectedVst != value)
                {
                    _selectedVst = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsVstSelected));
                }
            }
        }

        public bool IsVstSelected => SelectedVst != null;


        static public ContentDialog DisplayUnauthorizedAccessDialog()
        {
            ContentDialog unauthorizedAccessDialog = new ContentDialog()
            {
                Title = "Unauthorized Access",
                Content = "You don't have permissions to delete the file(s). Try running this app as an administrator.",
                CloseButtonText = "Ok"
            };
            return unauthorizedAccessDialog;
        }

        static public ContentDialog DisplayDeleteFileDialog(List<VstViewModel> vstsNotWhitelisted)
        {
            List<string> vstNamesToDelete = vstsNotWhitelisted.Select(o => o.VstName).ToList();
            string vstsToDelete = string.Join("\n", vstNamesToDelete);

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Delete file(s) permanently?",
                Content = $"If you delete the file, you won't be able to recover it. Are you sure you want to delete the follwing?\n\n{vstsToDelete}",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };
            return deleteFileDialog;
        }

        static public void Delete(List<VstViewModel> vstsNotWhitelisted)
        {
            foreach (var vst in vstsNotWhitelisted)
            {
                if (File.Exists(vst.FullPath))
                {
                    File.Delete(vst.FullPath);
                    Debug.WriteLine($"{vst.VstName} was deleted.");
                }
            }
        }

        public void Load(string VstDir)
        {
            if (VstDir != null)
            {
                Vsts.Clear();

                vsts = _vstDataProvider.LoadVsts(VstDir);
                foreach (var vst in vsts)
                {
                    Vsts.Add(new VstViewModel(vst, _vstDataProvider));
                }
            }
        }

    }
}
