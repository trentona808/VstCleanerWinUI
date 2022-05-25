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
    public class WhitelistViewModel : ViewModelBase
    {
        private VstViewModel _selectedVst;
        private readonly IVstDataProvider _vstDataProvider;

        public string vDir { get; set; }

        public WhitelistViewModel(IVstDataProvider vstDataProvider)
        {
            _vstDataProvider = vstDataProvider;
        }


        public ObservableCollection<VstViewModel> Vsts { get; set; } = new();

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
            var vsts = _vstDataProvider.LoadVsts(VstDir);

            Vsts.Clear();
            foreach (var vst in vsts)
            {
                Vsts.Add(new VstViewModel(vst, _vstDataProvider));
            }
        }

        public void AddToWhitelist(VstViewModel SelectedVst)
        {
            //Can remove duplicate validation if "isWhitelisted" is removed from model and/or "isWhitelisted" is added to Vsts when loading.
            bool duplicateVst = Vsts.Any(x => x.FullPath == SelectedVst.FullPath);

            if (!duplicateVst)
            {
                SelectedVst.IsWhitelisted = true;
                Vsts.Add(SelectedVst);
            }
            
        }

        public void SaveWhiteList(string jsonPath)
        {
            var list = new List<Vst>();
            foreach (var vst in Vsts)
            {

                list.Add(new Vst() { VstName = vst.VstName, FullPath = vst.FullPath, IsWhitelisted = true });
            }
            WhitelistDataProvider.SaveWhitelist(list, jsonPath);
        }
    }
}

