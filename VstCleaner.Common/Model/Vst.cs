using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VstCleaner.Common.Model
{
    public class Vst
    {
        public string VstName { get; set; }

        public string FullPath { get; set; }

        public bool IsWhitelisted { get; set; }
    }
}