using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;
using VstCleaner.DataAccess;

namespace VstCleaner.ViewModel
{
    public class WhitelistViewModel : ViewModelBase
    {
        private readonly IVstDataProvider _vstDataProvider;
        private VstViewModel _selectedVst;


        public WhitelistViewModel(IVstDataProvider vstDataProvider)
        {
            _vstDataProvider = vstDataProvider;
        }


        public ObservableCollection<VstViewModel> Vsts { get; set; } = new();
        
        public IEnumerable<Vst> vsts { get; set;  }

        public bool IsVstSelected => SelectedVst != null;

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


        public void Load(string jsonPath)
        {
            Vsts.Clear();

            vsts = _vstDataProvider.LoadVsts(jsonPath);
            foreach (var vst in vsts)
            {
                Vsts.Add(new VstViewModel(vst, _vstDataProvider));
            }
        }

        public void AddToWhitelist(VstViewModel selectedVst)
        {
            if (selectedVst != null)
            {
                if (Vsts == null)
                    Vsts.Add(selectedVst);

                else
                {
                    bool duplicateVst = Vsts.Any(x => x.FullPath == selectedVst.FullPath);

                    if (!duplicateVst)
                    {
                        Vsts.Add(selectedVst);
                    }
                }
            }
            WhitelistViewModel.SortByVstName(Vsts);
        }


        public void RemoveFromWhitelist(VstViewModel selectedVst)
        {
            Vsts.Remove(selectedVst);
        }

        public void SaveWhiteList(string jsonPath)
        {
            var list = new List<Vst>();

            if (Vsts != null)
            {
                foreach (var vst in Vsts)
                {
                    list.Add(new Vst() { VstName = vst.VstName, FullPath = vst.FullPath });
                }
            }
            WhitelistDataProvider.SaveWhitelist(list, jsonPath);
        }

        private static ObservableCollection<VstViewModel> SortByVstName(ObservableCollection<VstViewModel> collectionToSort)
        {
            ObservableCollection<VstViewModel> temp;
            temp = new ObservableCollection<VstViewModel>(collectionToSort.OrderBy(p => p.VstName));
            collectionToSort.Clear();
            foreach (VstViewModel j in temp) collectionToSort.Add(j);
            return collectionToSort;
        }

    }
}

