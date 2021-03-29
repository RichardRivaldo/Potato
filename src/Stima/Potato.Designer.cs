
namespace Stima2
{
    partial class Apps
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Apps));
            this.Browse = new System.Windows.Forms.Button();
            this.recommendList = new System.Windows.Forms.ListBox();
            this.Recommend = new System.Windows.Forms.Button();
            this.nameList = new System.Windows.Forms.ComboBox();
            this.targetList = new System.Windows.Forms.ComboBox();
            this.Explore = new System.Windows.Forms.ListBox();
            this.Exploring = new System.Windows.Forms.Button();
            this.GraphViz = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.FileName = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DFS2 = new System.Windows.Forms.Button();
            this.BFS2 = new System.Windows.Forms.Button();
            this.POTATO = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.POTATO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.BackColor = System.Drawing.Color.SkyBlue;
            this.Browse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Browse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Browse.FlatAppearance.BorderSize = 0;
            this.Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Browse.Font = new System.Drawing.Font("Javanese Text", 16.2F, System.Drawing.FontStyle.Bold);
            this.Browse.ForeColor = System.Drawing.Color.Navy;
            this.Browse.Location = new System.Drawing.Point(0, 125);
            this.Browse.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(395, 55);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Choose a File";
            this.Browse.UseVisualStyleBackColor = false;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // recommendList
            // 
            this.recommendList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recommendList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.recommendList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recommendList.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold);
            this.recommendList.ForeColor = System.Drawing.Color.DodgerBlue;
            this.recommendList.FormattingEnabled = true;
            this.recommendList.ItemHeight = 45;
            this.recommendList.Location = new System.Drawing.Point(395, 64);
            this.recommendList.Name = "recommendList";
            this.recommendList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.recommendList.Size = new System.Drawing.Size(502, 540);
            this.recommendList.TabIndex = 4;
            // 
            // Recommend
            // 
            this.Recommend.BackColor = System.Drawing.Color.MidnightBlue;
            this.Recommend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Recommend.FlatAppearance.BorderSize = 0;
            this.Recommend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Recommend.ForeColor = System.Drawing.Color.Cyan;
            this.Recommend.Location = new System.Drawing.Point(23, 190);
            this.Recommend.Name = "Recommend";
            this.Recommend.Size = new System.Drawing.Size(336, 94);
            this.Recommend.TabIndex = 6;
            this.Recommend.Text = "Recommend A Friend";
            this.Recommend.UseVisualStyleBackColor = false;
            this.Recommend.Click += new System.EventHandler(this.Recommend_Click);
            // 
            // nameList
            // 
            this.nameList.BackColor = System.Drawing.Color.SteelBlue;
            this.nameList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameList.ForeColor = System.Drawing.Color.Navy;
            this.nameList.FormattingEnabled = true;
            this.nameList.Location = new System.Drawing.Point(143, 310);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(97, 53);
            this.nameList.Sorted = true;
            this.nameList.TabIndex = 8;
            this.nameList.MouseHover += new System.EventHandler(this.nameList_MouseHover);
            // 
            // targetList
            // 
            this.targetList.BackColor = System.Drawing.Color.SteelBlue;
            this.targetList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.targetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetList.ForeColor = System.Drawing.Color.Navy;
            this.targetList.FormattingEnabled = true;
            this.targetList.Location = new System.Drawing.Point(143, 552);
            this.targetList.Name = "targetList";
            this.targetList.Size = new System.Drawing.Size(97, 53);
            this.targetList.TabIndex = 9;
            this.targetList.MouseHover += new System.EventHandler(this.targetList_MouseHover);
            // 
            // Explore
            // 
            this.Explore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.Explore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Explore.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Explore.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Explore.FormattingEnabled = true;
            this.Explore.ItemHeight = 45;
            this.Explore.Location = new System.Drawing.Point(391, 604);
            this.Explore.Name = "Explore";
            this.Explore.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.Explore.Size = new System.Drawing.Size(1009, 135);
            this.Explore.TabIndex = 10;
            // 
            // Exploring
            // 
            this.Exploring.BackColor = System.Drawing.Color.MidnightBlue;
            this.Exploring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exploring.FlatAppearance.BorderSize = 0;
            this.Exploring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exploring.ForeColor = System.Drawing.Color.Cyan;
            this.Exploring.Location = new System.Drawing.Point(23, 634);
            this.Exploring.Name = "Exploring";
            this.Exploring.Size = new System.Drawing.Size(336, 94);
            this.Exploring.TabIndex = 11;
            this.Exploring.Text = "Let\'s Explore!";
            this.Exploring.UseVisualStyleBackColor = false;
            this.Exploring.Click += new System.EventHandler(this.Exploring_Click);
            // 
            // GraphViz
            // 
            this.GraphViz.ArrowheadLength = 10D;
            this.GraphViz.AsyncLayout = false;
            this.GraphViz.AutoScroll = true;
            this.GraphViz.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GraphViz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.GraphViz.BackwardEnabled = false;
            this.GraphViz.BuildHitTree = true;
            this.GraphViz.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.Ranking;
            this.GraphViz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GraphViz.EdgeInsertButtonVisible = false;
            this.GraphViz.FileName = "";
            this.GraphViz.ForwardEnabled = false;
            this.GraphViz.Graph = null;
            this.GraphViz.InsertingEdge = false;
            this.GraphViz.LayoutAlgorithmSettingsButtonVisible = false;
            this.GraphViz.LayoutEditingEnabled = true;
            this.GraphViz.Location = new System.Drawing.Point(898, 64);
            this.GraphViz.LooseOffsetForRouting = 0.25D;
            this.GraphViz.MouseHitDistance = 0.05D;
            this.GraphViz.Name = "GraphViz";
            this.GraphViz.NavigationVisible = false;
            this.GraphViz.NeedToCalculateLayout = true;
            this.GraphViz.OffsetForRelaxingInRouting = 0.6D;
            this.GraphViz.PaddingForEdgeRouting = 8D;
            this.GraphViz.PanButtonPressed = false;
            this.GraphViz.SaveAsImageEnabled = true;
            this.GraphViz.SaveAsMsaglEnabled = false;
            this.GraphViz.SaveButtonVisible = true;
            this.GraphViz.SaveGraphButtonVisible = true;
            this.GraphViz.SaveInVectorFormatEnabled = false;
            this.GraphViz.Size = new System.Drawing.Size(503, 541);
            this.GraphViz.TabIndex = 12;
            this.GraphViz.TightOffsetForRouting = 0.125D;
            this.GraphViz.ToolBarIsVisible = true;
            this.GraphViz.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("GraphViz.Transform")));
            this.GraphViz.UndoRedoButtonsVisible = true;
            this.GraphViz.WindowZoomButtonPressed = false;
            this.GraphViz.ZoomF = 1D;
            this.GraphViz.ZoomWindowThreshold = 0.05D;
            // 
            // FileName
            // 
            this.FileName.BackColor = System.Drawing.Color.DarkBlue;
            this.FileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileName.Font = new System.Drawing.Font("Javanese Text", 18F, System.Drawing.FontStyle.Bold);
            this.FileName.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.FileName.Location = new System.Drawing.Point(391, 0);
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.FileName.Size = new System.Drawing.Size(1010, 66);
            this.FileName.TabIndex = 13;
            this.FileName.Text = "File Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Stima.Properties.Resources.bg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.DFS2);
            this.panel1.Controls.Add(this.BFS2);
            this.panel1.Controls.Add(this.POTATO);
            this.panel1.Controls.Add(this.Recommend);
            this.panel1.Controls.Add(this.Exploring);
            this.panel1.Controls.Add(this.targetList);
            this.panel1.Controls.Add(this.Browse);
            this.panel1.Controls.Add(this.nameList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 740);
            this.panel1.TabIndex = 14;
            // 
            // DFS2
            // 
            this.DFS2.BackColor = System.Drawing.Color.Blue;
            this.DFS2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DFS2.FlatAppearance.BorderSize = 0;
            this.DFS2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DFS2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.DFS2.Location = new System.Drawing.Point(249, 426);
            this.DFS2.Name = "DFS2";
            this.DFS2.Size = new System.Drawing.Size(110, 64);
            this.DFS2.TabIndex = 17;
            this.DFS2.Text = "DFS";
            this.DFS2.UseVisualStyleBackColor = false;
            this.DFS2.Click += new System.EventHandler(this.DFS_Click);
            this.DFS2.MouseHover += new System.EventHandler(this.DFS_MouseHover);
            // 
            // BFS2
            // 
            this.BFS2.BackColor = System.Drawing.Color.Blue;
            this.BFS2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BFS2.FlatAppearance.BorderSize = 0;
            this.BFS2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BFS2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.BFS2.Location = new System.Drawing.Point(23, 426);
            this.BFS2.Name = "BFS2";
            this.BFS2.Size = new System.Drawing.Size(110, 65);
            this.BFS2.TabIndex = 16;
            this.BFS2.Text = "BFS";
            this.BFS2.UseVisualStyleBackColor = false;
            this.BFS2.Click += new System.EventHandler(this.BFS_Click);
            this.BFS2.MouseHover += new System.EventHandler(this.BFS_MouseHover);
            // 
            // POTATO
            // 
            this.POTATO.BackColor = System.Drawing.Color.Transparent;
            this.POTATO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POTATO.Image = global::Stima.Properties.Resources.output_onlinepngtools;
            this.POTATO.Location = new System.Drawing.Point(0, -1);
            this.POTATO.Name = "POTATO";
            this.POTATO.Size = new System.Drawing.Size(397, 126);
            this.POTATO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.POTATO.TabIndex = 15;
            this.POTATO.TabStop = false;
            this.POTATO.Click += new System.EventHandler(this.POTATO_Click);
            this.POTATO.MouseHover += new System.EventHandler(this.POTATO_MouseHover);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Image = global::Stima.Properties.Resources.output_onlinepngtools__2_;
            this.Exit.Location = new System.Drawing.Point(1331, 693);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(96, 51);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit.TabIndex = 9;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseHover += new System.EventHandler(this.Exit_MouseHover);
            // 
            // Apps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1400, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.GraphViz);
            this.Controls.Add(this.Explore);
            this.Controls.Add(this.recommendList);
            this.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.LavenderBlush;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Apps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Potato";
            this.Load += new System.EventHandler(this.App_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.POTATO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.ListBox recommendList;
        private System.Windows.Forms.Button Recommend;
        private System.Windows.Forms.ComboBox nameList;
        private System.Windows.Forms.ComboBox targetList;
        private System.Windows.Forms.ListBox Explore;
        private System.Windows.Forms.Button Exploring;
        private Microsoft.Msagl.GraphViewerGdi.GViewer GraphViz;
        private System.Windows.Forms.RichTextBox FileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox POTATO;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.Button DFS2;
        private System.Windows.Forms.Button BFS2;
    }
}

