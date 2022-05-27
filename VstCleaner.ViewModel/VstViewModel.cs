using System;
using VstCleaner.Common.DataProvider;
using VstCleaner.Common.Model;

namespace VstCleaner.ViewModel
{
    public class VstViewModel : ViewModelBase, IEquatable<VstViewModel>
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
            set
            {
                if (_vst.VstName != value)
                {
                    _vst.VstName = value;
                    RaisePropertyChanged();
                }
            }
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

        public bool Equals(VstViewModel other)
        {
            if (other is null)
                return false;
            return this.VstName == other.VstName && this.FullPath == other.FullPath && this.IsWhitelisted == other.IsWhitelisted;
        }


        public override bool Equals(object obj) => Equals(obj as VstViewModel);
        public override int GetHashCode() => (VstName, FullPath, IsWhitelisted).GetHashCode();

    }
}
