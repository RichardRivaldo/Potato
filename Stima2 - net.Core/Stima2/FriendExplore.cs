using System;
using System.Collections.Generic;
using ns_graph;

namespace FriendExplore{
    class ExploreFunction{
        public (List<string>, int) FriendExploreBFS(Graph G,Node start,Node finish){//Fitur friendexplore dengan metode BFS

            /*Implemented as a procedure, this procedure will print out the route from start to finish using BFS
            or it will print "Koneksi belum ada, silakan dimulai sendiri" if such connection doesn't exist */

            List<string> solution= new List<string>();
            List<Node> simpulhidup=new List<Node>();
            int degree = 0;

            simpulhidup.Add(start);//add start to simpulhidup
            start.SetVisitedTrue();

            if (start.neighbors.Contains(finish.name)){//if already contained
                int i=0;
                solution.Add(start.name);
                while(!solution.Contains(finish.name)){
                    solution.Add(start.neighbors[i]);
                    i++;
                }
            }
            else{
                int i=0;
                Node curNode=simpulhidup[i]; //init curNode
                // secNode and thirdNode just for temp var
                Node secNode;
                Node thirdNode;
                int countToIncDeg = start.neighbors.Count;  // count to next increment
                int countNeighs = 0;    // count the neighbors of one level
                List<string> degreeCount = new List<string>();  // nodes' name that has been counted the neighbors for degree
                // init degreeCount
                degreeCount.Add(start.name);
                foreach(string n in start.neighbors){
                    degreeCount.Add(n);
                }
                while(curNode.name!=finish.name && i<simpulhidup.Count){
                    foreach(string nameNode in curNode.neighbors){ //this visits each of the nodes in neighbours hence the BFS part
                        secNode = G.NodeList[G.GetIndexFromNodeName(nameNode)];
                        if (!secNode.isVisited) {
                            // get the total neighbors of one level
                            foreach (string n in secNode.neighbors){
                                thirdNode = G.NodeList[G.GetIndexFromNodeName(n)];
                                if (!thirdNode.isVisited && (!degreeCount.Contains(thirdNode.name))) {
                                    degreeCount.Add(thirdNode.name);
                                    countNeighs++;
                                }
                            }

                            // if it is time to increment, inc the degree, reset the counts
                            if (--countToIncDeg == 0){
                                degree++;
                                countToIncDeg = countNeighs; 
                                countNeighs = 0;
                            }
                        }
                        
                        
                        foreach(Node n in G.NodeList){
                            if (nameNode==n.name && !n.isVisited){ //add neighbor nodes to last idx
                                simpulhidup.Add(n);
                                n.SetVisitedTrue(); 
                            }
                        }
                    }

                    i++;
                    if (i >= simpulhidup.Count) { break; }
                    if(!solution.Contains(curNode.name)){
                        solution.Add(curNode.name);//add curNode to solution
                    }
                    curNode=simpulhidup[i];
                }
                //endwhile
                if (curNode.name==finish.name){//check if final node is the goal node
                    solution.Add(curNode.name);
                }

                // the count system is minused one
                degree--;
            }

            if (!solution.Contains(finish.name)){
                solution.Clear();
                Console.WriteLine("Koneksi belum ada, silakan dimulai sendiri");
            }
            else{
                Console.WriteLine("Jalur yang diambil adalah: ");
                foreach (string nameFinal in solution){
                    Console.Write(nameFinal+"-");
                }
                Console.Write("finish");
                Console.Write("\n");
                Console.WriteLine("Derajat pertemanan: "+degree);
            }

            Set_All_Visited_False(G);
            return (solution, degree);
        }

        public List<Node> FriendExploreDFS(Graph G, Node start, Node finish){
            List<Node> history=new List<Node>();
            List<Node> visited=new List<Node>();

            history.Add(start);
            start.SetVisitedTrue();

            int i=0;
            Node curNode=history[i];
            while(!G.isVisitedAll() && !history.Contains(finish)){
                    foreach(Node n in G.NodeList){
                        if (n.neighbors.Contains(curNode.name) && n.isVisited==false){
                            history.Add(n);
                            n.SetVisitedTrue();
                            Console.WriteLine(n.name);
                            i++;
                            break;
                        }
                    }

                    curNode=history[i]; //curNode is last node (hopefully)
                    if (history.Contains(finish)){break;}
                    /*curNode=history[history.Count-1];*/

                    bool isAllNeighborsVisited=true;
                    foreach(string n2 in curNode.neighbors){ //check if all neighbors of current nodes are already visited
                        foreach (Node n3 in G.NodeList)
                        {
                            if (n3.name==n2 && n3.isVisited==false){
                                isAllNeighborsVisited=false;
                            }
                        }
                    }

                    if (isAllNeighborsVisited==true){
                        i--; //i mundur
                        if(i<0){break;} //protection just in case dia ga ketemu node
                        history.Remove(curNode); //remove curNode
                        curNode=history[i]; //reassign
                    }
            }//endwhile
            if (i < 0) { history.Clear(); } //clear history
            Console.WriteLine("Jalur yang diambil: ");
            foreach (Node nodefinal in history){
                    Console.Write(nodefinal.name+"-");
            }
            Console.Write("finish");
            Console.Write("\n");

            Console.WriteLine("Derajat pertemanan: "+(history.Count));

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