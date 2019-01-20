using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W8lessLabs.Blazor.LocalFiles;

namespace tbp.Client
{
    public class LoadedFile
    {
        public SelectedFile SelectedFile { get; set; }
        public bool IsLoaded { get; set; }
        public int LoadedSize { get; set; }
    }
}
