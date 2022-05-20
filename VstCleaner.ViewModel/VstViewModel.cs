using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;

namespace VstCleaner.ViewModel
{
    public class VstViewModel : ViewModelBase
    {
        private readonly Vst _vst;
        private readonly IVstDataProvider _vstDataProvider;

        public VstViewModel(Vst vst, IVstDataProvider vstDataProvider)
        {
            _vst = vst;
            _vstDataProvider = vstDataProvider;
        }


        public string VstName
        {
            get { return _vst.VstName; }
            set { _vst.VstName = value; }
        }


        public string FullPath
        {
            get { return _vst.FullPath; }
            set { _vst.FullPath = value; }
        }


        public bool IsWhitelisted
        {
            get { return _vst.IsWhitelisted; }
            set { _vst.IsWhitelisted = value; }
        }







    }
}
