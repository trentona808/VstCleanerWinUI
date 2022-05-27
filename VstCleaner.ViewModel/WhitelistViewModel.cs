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
        private VstViewModel _selectedVst;
        private readonly IVstDataProvider _vstDataProvider;

        public string vDir { get; set; }

        public WhitelistViewModel(IVstDataProvider vstDataProvider)
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

        public void Load(string jsonPath)
        {
            vsts = _vstDataProvider.LoadVsts(jsonPath);

            Vsts.Clear();
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

        public static ObservableCollection<VstViewModel> SortByVstName(ObservableCollection<VstViewModel> collectionToSort)
        {
            ObservableCollection<VstViewModel> temp;
            temp = new ObservableCollection<VstViewModel>(collectionToSort.OrderBy(p => p.VstName));
            collectionToSort.Clear();
            foreach (VstViewModel j in temp) collectionToSort.Add(j);
            return collectionToSort;
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

                    list.Add(new Vst() { VstName = vst.VstName, FullPath = vst.FullPath, IsWhitelisted = false });
                }
            }
            WhitelistDataProvider.SaveWhitelist(list, jsonPath);
        }
    }
}

