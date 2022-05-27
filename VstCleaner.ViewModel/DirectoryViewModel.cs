namespace VstCleaner.ViewModel
{
    public class DirectoryViewModel : ViewModelBase
    {
        private string _vstPath;

        public string VstPath
        {
            get { return _vstPath; }
            set
            {
                if (_vstPath != value)
                {
                    _vstPath = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void GetDir()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                VstPath = dialog.SelectedPath;
            }
        }

    }
}
