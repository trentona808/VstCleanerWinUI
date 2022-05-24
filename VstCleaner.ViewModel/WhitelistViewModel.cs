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
            vDir = VstDataProvider.VstDir;
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

        public void Load()
        {
            var vsts = _vstDataProvider.LoadVsts();

            Vsts.Clear();
            foreach (var vst in vsts)
            {
                Vsts.Add(new VstViewModel(vst, _vstDataProvider));
            }

        }

        public void AddToWhitelist(VstViewModel SelectedVst)
        {
            //var vstToAdd = new Vst();
            //vstToAdd.VstName = SelectedVst.VstName;
            //vstToAdd.FullPath = SelectedVst.FullPath;
            //vstToAdd.IsWhitelisted = true;
            //var test = new WhitelistDataProvider();
            //test.AddToWhitelist(vstToAdd);
            SelectedVst.IsWhitelisted = true;
            Vsts.Add(SelectedVst);



            //Load();

        }


    }
}

