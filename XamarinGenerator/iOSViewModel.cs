using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinGenerator
{
    public class iOSViewModel
    {
        public ObservableCollection<ResolutionItem> LaunchRes { get; } = new ObservableCollection<ResolutionItem>(new ResolutionItem[]
        {
            new ResolutionItem(640, 960),
            new ResolutionItem(640, 1136),
            new ResolutionItem(768, 1024),
            new ResolutionItem(1536, 2048),
            new ResolutionItem(1024, 768),
            new ResolutionItem(2048, 1536)
        });

        public ObservableCollection<ResolutionItem> IconRes { get; } = new ObservableCollection<ResolutionItem>(new ResolutionItem[]
        {
            new ResolutionItem(20),
            new ResolutionItem(29),
            new ResolutionItem(40),
            new ResolutionItem(60),
            new ResolutionItem(58),
            new ResolutionItem(76),
            new ResolutionItem(87),
            new ResolutionItem(80),
            new ResolutionItem(120),
            new ResolutionItem(152),
            new ResolutionItem(167),
            new ResolutionItem(180),
            new ResolutionItem(1024)
        });
    }
}
