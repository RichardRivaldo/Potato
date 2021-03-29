using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ns_graph;
using friend;
using FriendExplore;


namespace Stima2
{
    public partial class App : Form
    {
        // Attributes of the form
        private bool bfs = false;
        private bool dfs = false;
        private ns_graph.Graph graph = new ns_graph.Graph();
        private friend.Friend friend = new friend.Friend();
        private FriendExplore.ExploreFunction expFriend = new FriendExplore.ExploreFunction();
        private Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        // Default Init of The App
        public App()
        {
            InitializeComponent();
        }
        private void App_Load(object sender, EventArgs e)
        {
        }

        // Browse Button
        private void Browse_Click(object sender, EventArgs e)
        {
            // Get chosen input file name and directory
            string filename = getFileName();

            // Create a graph from the filename
            if (filename != "") 
            {
                this.CreateGraph(filename);
                List<string> temp = new List<string>();
                Microsoft.Msagl.Drawing.Graph graph = Generate_Graph(temp);
                VisualizeMSAGL(graph);
                this.FileName.Text = filename;
            }
        }

        // Get File Name from Open File Dialog
        private string getFileName()
        {
            // Init Open File Dialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            string fileName = "";

            // Filter only .txt files
            fileDialog.Filter = "Text Files|*.txt";

            // Check if the dialog returns normally
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save and return the file name
                fileName = fileDialog.FileName;
            }
            return fileName;
        }

        // Create a graph from the file
        private void CreateGraph(string filename)
        {
            // Clear fields
            Clear_Fields();
            nameList.Items.Clear();
            targetList.Items.Clear();
            Explore.Items.Clear();

            // Create the graph
            this.graph = this.graph.makeGraphFromText(filename);

            // Add each nodes into the dropdown list
            foreach (Node nodes in this.graph.NodeList)
            {
                nameList.Items.Add(nodes.name);
                targetList.Items.Add(nodes.name);
            }
        }

        // BFS Button
        private void BFS_Click(object sender, EventArgs e)
        {
            // Init Button
            Button btn = sender as Button;

            // Check boolean of both BFS and DFS method
            if (!bfs)
            {
                // Handle when both of the bools are true
                if (dfs)
                {
                    DFS.PerformClick();
                }
                bfs = true;
            }
            else
            {
                bfs = false;
            }

            // Change Colors of the button
            btn.BackColor = Change_Colors();
        }

        // DFS Button
        private void DFS_Click(object sender, EventArgs e)
        {
            // Init Button
            Button btn = sender as Button;

            // Check boolean of both BFS and DFS method
            if (!dfs)
            {
                // Handle when both of the bools are true
                if (bfs)
                {
                    BFS.PerformClick();
                }
                dfs = true;
            }
            else
            {
                dfs = false;
            }

            // Change Colors of the button
            btn.BackColor = Change_Colors();
        }

        // Change Colors function
        private Color Change_Colors()
        {
            if (dfs && !bfs || bfs && !dfs)
            {
                // When the button is selected
                return Color.Navy;
            }
            else
            {
                // When the button is not selected
                return Color.Blue;
            }
        }

        // Get Selected Items of A Combo Box
        private string Get_Selected_Name(ComboBox CB)
        {
            return CB.SelectedItem.ToString();
        }

        // Do Friend Recommendation Feature
        private void Friend_Recommendation(string selected)
        {
            // Create the dict containing friend recommendations
            this.dict = friend.FriendRec(graph, selected);
            string text = default;

            if(dict.Count > 0)
            {
                text += "[WOOHOO! TAKE THESE FRIENDS!]";
                recommendList.Items.Add(text);
                text = default;

                // Print the output into the list box
                foreach (string Key in dict.Keys)
                {
                    // Print the name
                    text += String.Format("{0}", Key);
                    recommendList.Items.Add(text);
                    text = default;

                    // Print the amount of mutuals
                    text += String.Format("{0} mutual friend(s):", dict[Key].Count);
                    recommendList.Items.Add(text);
                    text = default;

                    // Print the name of the mutuals
                    foreach (string listComp in dict[Key])
                    {
                        text += listComp;
                        recommendList.Items.Add(text);
                        text = default;
                    }

                    // Separator
                    recommendList.Items.Add("----------------------------");
                    text = default;
                }
            }
            else
            {
                text += "[OOPSIE! 404 NO RECOMMENDATION D:]";
                recommendList.Items.Add(text);
                text = default;

                text += "Oops, you have to quit your weeb life!";
                recommendList.Items.Add(text);
                text = default;

                text += "Please start a new relationship with others! :D";
                recommendList.Items.Add(text);
                text = default;
            }
        }

        // Friend Recommendation
        private void Recommend_Click(object sender, EventArgs e)
        {
            // Clear fields
            Clear_Fields();

            if (nameList.SelectedIndex < 0)
            {
                recommendList.Items.Add("Choose a person first!");
            }
            else
            {
                // Do the recommendation
                Friend_Recommendation(Get_Selected_Name(nameList));
            }
        }

        // Friend Exploration Extract to List of String and Degree
        private (List<string>, int) Extract_Exploration(string from, string target)
        {
            List<string> extracted = new List<string>(graph.NodeList.Count);
            ns_graph.Node fromNode = this.graph.NodeList[graph.GetIndexFromNodeName(from)];
            ns_graph.Node targetNode = this.graph.NodeList[graph.GetIndexFromNodeName(target)];

            // Check if BFS is selected
            int degree = 0;
            if (bfs)
            {
                (extracted, degree) = expFriend.FriendExploreBFS(this.graph, fromNode, targetNode);
            }
            // Check if DFS is selected
            else if (dfs)
            {
                List <Node> nodeList= expFriend.FriendExploreDFS(this.graph, fromNode, targetNode);

                // Check if an element exist
                if(nodeList.Count > 0)
                {
                    foreach (Node nodes in nodeList)
                    {
                        extracted.Add(nodes.name);
                    }
                }
                degree = nodeList.Count;
            }

            return (extracted, degree);
        }

        // Friend Exploration
        private void Exploring_Click(object sender, EventArgs e)
        {
            // Clear previous items
            Explore.Items.Clear();

            // Check validity of inputs
            if((bfs || dfs) && nameList.SelectedIndex != -1 && targetList.SelectedIndex != -1)
            {
                string text = default;
                string from = Get_Selected_Name(nameList);
                string target = Get_Selected_Name(targetList);
                (List<string> exploration, int degree) = Extract_Exploration(from, target);

                if(from == target)
                {
                    text += "[BEEPBEEP!!! I\'M STILL HERE!]";
                    Explore.Items.Add(text);
                    text = default;
                    Explore.Items.Add("We are all friend of ourselves ^^");
                }

                // Output the path and degrees
                else if(exploration.Count() > 0)
                {
                    text += "[WHOOSH~~~ HERE WE GO!!!]";
                    Explore.Items.Add(text);
                    text = default;

                    foreach (string names in exploration)
                    {
                        text += names;
                        if (names != exploration.Last())
                        {
                            text += " -> ";
                        }
                    }
                    Explore.Items.Add(text);

                    text = default;
                    text += "Relationship Degree: ";
                    text += degree;
                    
                    Explore.Items.Add(text);

                    // Visualize the graph
                    Microsoft.Msagl.Drawing.Graph graph = Generate_Graph(exploration);
                    VisualizeMSAGL(graph);
                }
                else
                {
                    text += "[BUZZ!!! EXPLORATION NOT FOUND!]";
                    Explore.Items.Add(text);
                    text = default;
                    text += "Oops, our exploration failed.";
                    Explore.Items.Add(text);
                    text = default;
                    text += "Don\'t worry, you've got a friend in me :D";
                    Explore.Items.Add(text);

                    List<string> temp = new List<string>();
                    Microsoft.Msagl.Drawing.Graph graph = Generate_Graph(temp);
                    VisualizeMSAGL(graph);
                }
            }
            else
            {
                // Invalid inputs
                if(!(nameList.SelectedIndex != -1 && targetList.SelectedIndex != -1))
                {
                    Explore.Items.Add("Select all of the fields correctly!");
                }
                else if(!(bfs || dfs))
                {
                    Explore.Items.Add("Select a method to explore!");
                }
            }
        }

        // MSAGL Graph Visualizer
        public void VisualizeMSAGL(Microsoft.Msagl.Drawing.Graph source)
        {
            // Create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();

            // Create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            
            // Set the graph
            GraphViz.Graph = source;
        }

        // Create Graph Source for MSAGL
        public Microsoft.Msagl.Drawing.Graph Generate_Graph(List<string> sourceList)
        {
            // Init a list of tuple that contains two string
            // to check which edge is used in the generated BFS/DFS path
            List<Tuple<string, string>> temp = new List<Tuple<string, string>>();

            // Check the choosen methods and generate a list of edges in the path of each method
            if (dfs)
            {
                // For DFS, just combine nodes[n] with nodes[n + 1] from the generated path
                for (int i = 0; i < sourceList.Count - 1; i++)
                {
                    Tuple<string, string> edge = new Tuple<string, string>(sourceList[i], sourceList[i + 1]);
                    temp.Add(edge);
                }
            }
            else if (bfs)
            {
                // Init a copy of the generated path list
                List<string> temp2 = new List<string>(sourceList);

                // Combine the nodes in the list
                foreach (string nodes in sourceList)
                {
                    foreach (string nodes2 in sourceList)
                    {
                        // Init two nodes to check if these two nodes have a relationship in the graph
                        ns_graph.Node node = this.graph.NodeList[this.graph.GetIndexFromNodeName(nodes)];
                        ns_graph.Node node2 = this.graph.NodeList[this.graph.GetIndexFromNodeName(nodes2)];

                        // Check if the latter node is part of the first node's neighbor
                        // Also check if the node is still in the copy of path list
                        if (node.neighbors.Contains(nodes2) && temp2.Contains(nodes2))
                        {
                            // Remove the node from the copy list to avoid duplicates and unwanted edges
                            temp2.Remove(nodes2);

                            // Init and insert the tuple to the list
                            Tuple<string, string> edge = new Tuple<string, string>(nodes, nodes2);
                            temp.Add(edge);
                        }
                    }
                }
            }

            // Init list to check doubled neighbors
            List<string> printed = new List<string>();

            // Init Graph
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            // iterate for each node in graph
            foreach (Node n in this.graph.NodeList)
            {
                // Add and color the nodes
                printed.Add(n.name);
                var Node = graph.AddNode(n.name);
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
                // Check if the node is a chosen path
                if (sourceList.Contains(n.name))
                {
                    // Get nodes in the graph from the name of the node
                    Node = graph.FindNode(n.name);
                    Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Orange;
                }
                else
                {
                    Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.CornflowerBlue;
                }

                // iterate for each neighbor
                foreach (string n2 in n.neighbors)
                {
                    // Add edges to the graph
                    if (!printed.Contains(n2))
                    {
                        // Add and color the edges without any arrow
                        var Edge = graph.AddEdge(n.name, n2);
                        Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        Edge.Attr.LineWidth = 2;

                        // Init 2 tuples of possible edges (reversed and not)
                        Tuple<string, string> tempEdge = new Tuple<string, string>(n.name, n2);
                        Tuple<string, string> tempEdgeRev = new Tuple<string, string>(n2, n.name);

                        // Check if the temp contains the generated BFS/DFS path
                        // If yes, color it with different color than the rest
                        if (temp.Contains(tempEdge) || temp.Contains(tempEdgeRev))
                        {
                            Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Crimson;
                        }
                        else
                        {
                            Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.MidnightBlue;
                        }
                    }
                }
            }

            return graph;
        }

        // Clear Fields
        private void Clear_Fields()
        {
            // Clear the recommendation list items
            recommendList.Items.Clear();

            // Clear the K-V in the dict
            this.dict.Clear();

            // Clear the mutual(s) list
            foreach (Node nodes in graph.NodeList)
            {
                nodes.mutuals.Clear();
            }
        }

        // Exit Button
        private void Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you! ~_~");
            // Simply close the program
            this.Close();
        }

        // Mouse Hovering Methods
        private void BFS_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.BFS, "-Breadth First Search-");
        }
        private void DFS_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.DFS, "-Depth First Search-");
        }
        private void nameList_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.nameList, "Select a name you want to recommend to :D");
        }
        private void targetList_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.targetList, "Select the target of your exploration~");
        }
        private void Exit_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.Exit, "Heyo! My name is Exit ^^ Don\'t press me :<");
        }

        // POTATO Events :D
        private void POTATO_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.POTATO, "POTATO FANS CLUB ULULULULULU");
        }

        private void POTATO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("~WE ARE POTATOES~" +
                "\nHizkia" +
                "\nBilly" +
                "\nRichard");
        }
    }
}