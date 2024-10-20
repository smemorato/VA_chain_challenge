using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA_chain
{
    internal class Chain
    {
        public Chain(int Index, List<int> VaChain, List<int> AniChain, List<int> NodeOut) 
        {
            this.Index = Index;
            this.VaChain = VaChain;
            this.AniChain = AniChain;
            this.NodeOut = NodeOut;
        }

        public int Index { get; set; }
        public List<int> VaChain { get; set; }
        public List<int> AniChain { get; set; }
        public List<int> NodeOut { get; set; }

    }
}
