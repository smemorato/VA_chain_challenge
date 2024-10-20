
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using VA_chain;

internal class Program
{
    private static void Main(string[] args)
    {

        int chain = 30;
        List<Chain>? Chains;
        //List<List<int>>? AuxRelations;
        int[][] AuxRelations;
        List<Node> Nodes;
        using (StreamReader r = new StreamReader("C:\\Users\\Utilizador\\Desktop\\badges\\va_chain\\chains.json"))
        {
            string json = r.ReadToEnd();
            Chains = JsonSerializer.Deserialize<List<Chain>>(json);
        }
        using (StreamReader r = new StreamReader("C:\\Users\\Utilizador\\Desktop\\badges\\va_chain\\relations.json"))
        {
            string json = r.ReadToEnd();
            AuxRelations = JsonSerializer.Deserialize<int[][]>(json);
        }
        using (StreamReader r = new StreamReader("C:\\Users\\Utilizador\\Desktop\\badges\\va_chain\\options.json"))
        {
            string json = r.ReadToEnd();
            Nodes = JsonSerializer.Deserialize<List<Node>>(json);
        }

        int N = AuxRelations.Length;
        int[,] Relations = new int[N, N];

        for (int i = 0; i<N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Relations[i, j] = AuxRelations[i][j];
            }
        }
        for (int i = 0; i < N; i++)
        {

        }
        for (int i = 0; i < Chains.Count; i++)
        {
            Chains[i].NodeOut = Nodes
                    .Where(x => (x.MalId == Nodes[Chains[i].Index].MalId) || (x.VaId == Nodes[Chains[i].Index].VaId))
                    .Select(x => x.Index)
                    .ToList();
        }
        bool found = false;
        List<Chain> Result = new List<Chain>();
        int MaxChain = 0;
        while (found == false)
        {
            int ChainIndex = Chains.Count - 1;
            int Index = Chains[ChainIndex].Index;
            var Options = AuxRelations[Index].Select((value, index) => new { Value = value, Index = index })
                                  .Where(x => (x.Value >= (chain - Chains[ChainIndex].VaChain.Count)) && !Chains[ChainIndex].NodeOut.Contains(x.Index))
                                  .Select(x => x.Index)
                                  .ToArray();

            foreach (int Option in Options)
            {
                List<int> VaChain = new List<int>(Chains[ChainIndex].VaChain);
                List<int> AniChain = new List<int>(Chains[ChainIndex].AniChain);
                VaChain.Add(Nodes[Option].VaId);
                AniChain.Add(Nodes[Option].MalId);
                List<int> NodeOut = Nodes
                    .Where(x => (x.MalId == Nodes[Option].MalId) || (x.VaId == Nodes[Option].VaId))
                    .Select(x => x.Index)
                    .ToList();
                NodeOut = NodeOut.Union(Chains[ChainIndex].NodeOut).ToList();
                Chain newchain = new Chain(Option, VaChain, AniChain, NodeOut);
                Chains.Add(newchain);
                if (VaChain.Count > MaxChain)
                {
                    MaxChain = VaChain.Count;
                }
                if (VaChain.Count >= 40)
                {
                    Result.Add(newchain);
                }
            }
            Chains.RemoveAt(ChainIndex);

        }

    }
}