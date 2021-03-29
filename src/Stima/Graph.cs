using System;
using System.IO;
using System.Collections.Generic;

namespace ns_graph
{
    class Graph
    {
        // attributes
        public List<Node> NodeList;

        // ctor
        public Graph() { NodeList = new List<Node>(); }

        // add a node to the list, if not existed before
        public void AddToList(Node node)
        {
            // check if existed before
            bool isAlreadyExist = false;
            foreach (Node n in NodeList)
            {
                if (n.name == node.name)
                {
                    isAlreadyExist = true;
                }
            };

            // add the node if not
            if (!isAlreadyExist) NodeList.Add(node);
        }

        public int GetIndexFromNodeName(string name)
        {
            // will return -1 when not found
            int res = -1;
            // look for the name
            foreach (Node n in NodeList)
            {
                if (n.name == name)
                {
                    res = NodeList.IndexOf(n);
                }
            };
            return res;
        }

        public void UnvisitAll()
        {
            foreach (var node in NodeList)
            {
                node.isVisited = false;
            }
        }

        public bool isVisitedAll()
        {
            foreach (var node in NodeList)
            {
                if (!node.isVisited) return false;
            }
            return true;
        }

        public Graph makeGraphFromText(string fileName)
        {
            // make new graph
            Graph G = new Graph();

            // read the text file
            string[] lines = File.ReadAllLines(fileName);
            List<string> lineList;

            // iterate each line
            int i = 0;
            foreach (string line in lines)
            {
                lineList = new List<string>(line.Split(' '));
                // ignore the first line
                if (i == 0) i++;
                // read the rest
                else
                {
                    // store the nodes
                    Node x = new Node(lineList[0]);
                    Node y = new Node(lineList[1]);

                    // add the nodes
                    G.AddToList(x);
                    G.AddToList(y);

                    // add the neighbors
                    int idxX = G.GetIndexFromNodeName(lineList[0]);
                    int idxY = G.GetIndexFromNodeName(lineList[1]);
                    G.NodeList[idxX].AddNeighbor(y.name);
                    G.NodeList[idxY].AddNeighbor(x.name);
                }
            }

            // sort the graph
            G.NodeList.Sort((x, y) => x.name.CompareTo(y.name));

            // to test printing each node name, followed by its neighbors
            // G.NodeList.ForEach(delegate(Node n){
            //     Console.Write(n.name);
            //     n.neighbors.ForEach(delegate(string s){
            //         Console.Write(s);
            //     });
            //     Console.WriteLine();
            // });

            return G;
        }
    }

    class Node
    {
        // attributes
        public string name;
        public List<string> neighbors;
        public bool isVisited;
        public List<string> mutuals;
        public List<string> historyPath;

        // ctor
        public Node(string name)
        {
            this.name = name;
            neighbors = new List<string>();
            isVisited = false;
            mutuals = new List<string>();
            historyPath = new List<string>();
        }

        // add new neighbor
        public void AddNeighbor(string neighbor)
        {
            // check if existed before
            bool isAlreadyExist = false;
            foreach (string n in neighbors)
            {
                if (n == neighbor)
                {
                    isAlreadyExist = true;
                }
            };
            // add the neighbor if not
            if (!isAlreadyExist) neighbors.Add(neighbor);
        }

        // remove a specific neighbor
        // neighbor to be removed exist in the neighbors list
        public void RemoveNeighbor(string neighbor) { neighbors.Remove(neighbor); }

        // set visited to be true
        public void SetVisitedTrue()
        {
            if (this.isVisited == false) { this.isVisited = true; }
        }
    }
}
