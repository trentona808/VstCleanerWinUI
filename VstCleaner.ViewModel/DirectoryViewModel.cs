using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VstCleaner.ViewModel
{
    public class DirectoryViewModel : ViewModelBase
    {
        public DirectoryViewModel()
        {
        }

        //public string VstDir()
        //{

        //    string path = string.Empty;


        //    using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
        //    {
        //        dialog.IsFolderPicker = true;
        //        dialog.Multiselect = false;
        //        dialog.DefaultDirectory = this.OutputPathBox.Text;
        //        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        //        {
        //            path = dialog.FileName;
        //        }
        //    }
 
        //}

        public void GetDir()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                VstPath = dialog.SelectedPath;
            }

            //return VstPath;
        }

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
                    //RaisePropertyChanged(nameof(IsVstSelected));
                }
            }
        }

    }
}
