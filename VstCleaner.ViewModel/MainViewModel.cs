using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;

namespace VstCleaner.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private VstViewModel _selectedVst;
        private readonly IVstDataProvider _vstDataProvider;

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

        public void Load(string VstDir)
        {
            vsts = _vstDataProvider.LoadVsts(VstDir);

            Vsts.Clear();
            foreach (var vst in vsts)
            {
                Vsts.Add(new VstViewModel(vst, _vstDataProvider));
            }
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

    }
}
