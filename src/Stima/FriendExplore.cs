using System;
using System.Collections.Generic;
using ns_graph;

namespace FriendExplore
{
    class ExploreFunction
    {
        public (List<string>, int) FriendExploreBFS(Graph G, Node start, Node finish)
        {//Fitur friendexplore dengan metode BFS

            /*Implemented as a procedure, this procedure will print out the route from start to finish using BFS
            or it will print "Koneksi belum ada, silakan dimulai sendiri" if such connection doesn't exist */

            List<string> solution = new List<string>();
            List<Node> simpulhidup = new List<Node>();
            int degree = 0;

            simpulhidup.Add(start);//add start to simpulhidup
            start.SetVisitedTrue();

            bool notFound = false; // check if node finish is found

            if (start.neighbors.Contains(finish.name))
            {//if already contained
                solution.Add(start.name);
                solution.Add(finish.name);
            }
            else
            {
                int i = 0;
                Node curNode = simpulhidup[i]; //init curNode
                
                while (curNode.name != finish.name && i < simpulhidup.Count)
                {
                    // set currentnode checked visited
                    G.NodeList[G.GetIndexFromNodeName(curNode.name)].SetVisitedTrue();

                    // Console.WriteLine(curNode.name);
                    foreach (string nameNode in curNode.neighbors)
                    { //this visits each of the nodes in neighbours hence the BFS part
                        
                        // add the neighbors node to the simpulHidup if is not visited before
                        if (!G.NodeList[G.GetIndexFromNodeName(nameNode)].isVisited){
                            Node neighNode = new Node(nameNode);
                            // fill the neighbors info
                            foreach(string s in G.NodeList[G.GetIndexFromNodeName(nameNode)].neighbors){
                                neighNode.AddNeighbor(s);
                            }
                            // update the historypath
                            neighNode.historyPath.Add(curNode.name);
                            foreach (string s in curNode.historyPath){
                                neighNode.historyPath.Add(s);
                            }
                            simpulhidup.Add(neighNode);
                        }
                    }
                    i++;
                    if (i >= simpulhidup.Count) { break; }
                    curNode = simpulhidup[i];
                }
                //endwhile
                if (curNode.name == finish.name)
                {//check if final node is the goal node, finalize
                    foreach (string s in curNode.historyPath){
                        solution.Add(s);
                    }
                    solution.Reverse();
                    solution.Add(finish.name);
                }
                else{
                    notFound = true;
                }
            }

            if (notFound)
            {
                solution.Clear();
            }
            else
            {
                // Console.WriteLine("Jalur yang diambil adalah: ");
                foreach (string nameFinal in solution)
                {
                    Console.Write(nameFinal + "-");
                }
            }

            Set_All_Visited_False(G);
            return (solution, solution.Count-2);
        }

        public List<Node> FriendExploreDFS(Graph G, Node start, Node finish)
        {
            List<Node> history = new List<Node>();
            List<Node> visited = new List<Node>();

            history.Add(start);
            start.SetVisitedTrue();

            int i = 0;
            Node curNode = history[i];
            while (!G.isVisitedAll() && !history.Contains(finish))
            {
                foreach (Node n in G.NodeList)
                {
                    if (n.neighbors.Contains(curNode.name) && n.isVisited == false)
                    {
                        history.Add(n);
                        n.SetVisitedTrue();
                        Console.WriteLine(n.name);
                        i++;
                        break;
                    }
                }

                curNode = history[i]; //curNode is last node (hopefully)
                if (history.Contains(finish)) { break; }
                /*curNode=history[history.Count-1];*/

                bool isAllNeighborsVisited = true;
                foreach (string n2 in curNode.neighbors)
                { //check if all neighbors of current nodes are already visited
                    foreach (Node n3 in G.NodeList)
                    {
                        if (n3.name == n2 && n3.isVisited == false)
                        {
                            isAllNeighborsVisited = false;
                        }
                    }
                }

                if (isAllNeighborsVisited == true)
                {
                    i--; //i mundur
                    if (i < 0) { break; } //protection just in case dia ga ketemu node
                    history.Remove(curNode); //remove curNode
                    curNode = history[i]; //reassign
                }
            }//endwhile
            if (i < 0) { history.Clear(); } //clear history
            Console.WriteLine("Jalur yang diambil: ");
            foreach (Node nodefinal in history)
            {
                Console.Write(nodefinal.name + "-");
            }
            Console.Write("finish");
            Console.Write("\n");

            Console.WriteLine("Derajat pertemanan: " + (history.Count));

            Set_All_Visited_False(G);

            return history;
        }

        // Reset all nodes' visited boolean
        public void Set_All_Visited_False(Graph G)
        {
            foreach (Node nodes in G.NodeList)
            {
                nodes.isVisited = false;
            }
        }

        /*public static void Main(string[] args)
        {
            Graph test= new Graph();
            test=test.makeGraphFromText("test.txt");

            ExploreFunction tester=new ExploreFunction();
            foreach(Node n in test.NodeList){
                Console.WriteLine(n.name);
                foreach(string n2 in n.neighbors){
                    Console.Write(n2+" ");
                }
                Console.WriteLine("");
            }

            tester.FriendExploreDFS(test,test.NodeList[0],test.NodeList[3]);
            
        }*/

    }
}
