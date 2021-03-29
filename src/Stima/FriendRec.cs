using System;
using System.Collections.Generic;
using ns_graph;

namespace friend
{
    class Friend
    {
        public Dictionary<string, List<string>> FriendRec(Graph G, string nameSelected)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            // get the node user selected
            int idxUser = G.GetIndexFromNodeName(nameSelected);
            Node user = G.NodeList[idxUser];

            foreach (Node n in G.NodeList)
            {
                // iterate each node that is not neighboring the user
                if (!user.neighbors.Contains(n.name))
                {
                    // count each mutual neighbor
                    foreach (string un in user.neighbors)
                    {
                        foreach (string nn in n.neighbors)
                        {
                            if (un == nn && !(n.mutuals.Contains(un))) n.mutuals.Add(un); // add to the mutual array
                        };
                    };
                }
            };

            // ignore the user
            G.NodeList[idxUser].SetVisitedTrue();

            Console.Write("Daftar rekomendasi teman untuk akun ");
            Console.Write(user.name);
            Console.WriteLine(":");
            while (!G.isVisitedAll())
            {
                // get the highest mutual
                string nameMax = "";
                int max = -99;
                foreach (Node n in G.NodeList)
                {
                    int currCount = n.mutuals.Count;
                    if (currCount > max && !n.isVisited)
                    {
                        nameMax = n.name;
                        max = currCount;
                    }
                };

                // mark current node
                int idxMax = G.GetIndexFromNodeName(nameMax);
                G.NodeList[idxMax].SetVisitedTrue();

                // add the mutuals for those with mutual > 0
                if (max != 0)
                {
                    List<string> currMutuals = new List<string>();
                    foreach (string n in G.NodeList[idxMax].mutuals)
                    {
                        currMutuals.Add(n);
                    };

                    dict.Add(nameMax, currMutuals);
                }
            }

            // TESTING : printing each user, followed by its mutual friends with user
            // foreach(string name in dict.Keys){
            //     Console.WriteLine(name);
            //     foreach(string mutual in dict[name]){
            //         Console.WriteLine(mutual);
            //     }
            //     Console.WriteLine();
            // }

            // reset the graph
            G.UnvisitAll();

            return dict;
        }
    }
}