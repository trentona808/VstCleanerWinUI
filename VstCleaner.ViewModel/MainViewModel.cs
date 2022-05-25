using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;
using VstCleaner.DataAccess;


namespace VstCleaner.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private VstViewModel _selectedVst;
        private readonly IVstDataProvider _vstDataProvider;

        public string vDir { get; set; }

        public MainViewModel(IVstDataProvider vstDataProvider)
        {
            _vstDataProvider = vstDataProvider;
        }


        public ObservableCollection<VstViewModel> Vsts { get; set;  } = new();

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


        public void Delete(IEnumerable<Vst> Whitelist)
        {
            IEnumerable<Vst> VstsNotWhitelisted = vsts.Except(Whitelist);
            VstDataProvider.Delete(VstsNotWhitelisted);

        }
    }
}
