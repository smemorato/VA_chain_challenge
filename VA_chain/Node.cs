using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA_chain
{
    internal class Node
    {
        public Node(int Index, int MalId, int VaId)
        {
            this.Index = Index;
            this.MalId = MalId;
            this.VaId = VaId;
        }

        public int Index { get; set; }
        public int MalId { get; set; }
        public int VaId { get; set; }

    }
}