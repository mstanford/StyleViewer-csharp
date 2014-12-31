// ------------------------------------------------------------------------
// 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or
// distribute this software, either in source code form or as a compiled
// binary, for any purpose, commercial or non-commercial, and by any
// means.
// 
// In jurisdictions that recognize copyright laws, the author or authors
// of this software dedicate any and all copyright interest in the
// software to the public domain. We make this dedication for the benefit
// of the public at large and to the detriment of our heirs and
// successors. We intend this dedication to be an overt act of
// relinquishment in perpetuity of all present and future rights to this
// software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org/>
// 
// ------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StyleViewer
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			TreeNode treeNodeAccent = new TreeNode("Accent");
			treeView.Nodes.Add(treeNodeAccent);
			treeNodeAccent.Tag = new int[] { 3, 4, 5, 6, 7, 8, };

			TreeNode treeNodeBlues = new TreeNode("Blues");
			treeView.Nodes.Add(treeNodeBlues);
			treeNodeBlues.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeBrBG = new TreeNode("BrBG");
			treeView.Nodes.Add(treeNodeBrBG);
			treeNodeBrBG.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodeBuGn = new TreeNode("BuGn");
			treeView.Nodes.Add(treeNodeBuGn);
			treeNodeBuGn.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeBuPu = new TreeNode("BuPu");
			treeView.Nodes.Add(treeNodeBuPu);
			treeNodeBuPu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeDark2 = new TreeNode("Dark2");
			treeView.Nodes.Add(treeNodeDark2);
			treeNodeDark2.Tag = new int[] { 3, 4, 5, 6, 7, 8, };

			TreeNode treeNodeGnBu = new TreeNode("GnBu");
			treeView.Nodes.Add(treeNodeGnBu);
			treeNodeGnBu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeGreens = new TreeNode("Greens");
			treeView.Nodes.Add(treeNodeGreens);
			treeNodeGreens.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeGreys = new TreeNode("Greys");
			treeView.Nodes.Add(treeNodeGreys);
			treeNodeGreys.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeOranges = new TreeNode("Oranges");
			treeView.Nodes.Add(treeNodeOranges);
			treeNodeOranges.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeOrRd = new TreeNode("OrRd");
			treeView.Nodes.Add(treeNodeOrRd);
			treeNodeOrRd.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodePaired = new TreeNode("Paired");
			treeView.Nodes.Add(treeNodePaired);
			treeNodePaired.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, };

			TreeNode treeNodePastel1 = new TreeNode("Pastel1");
			treeView.Nodes.Add(treeNodePastel1);
			treeNodePastel1.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodePastel2 = new TreeNode("Pastel2");
			treeView.Nodes.Add(treeNodePastel2);
			treeNodePastel2.Tag = new int[] { 3, 4, 5, 6, 7, 8, };

			TreeNode treeNodePiYG = new TreeNode("PiYG");
			treeView.Nodes.Add(treeNodePiYG);
			treeNodePiYG.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodePRGn = new TreeNode("PRGn");
			treeView.Nodes.Add(treeNodePRGn);
			treeNodePRGn.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodePuBu = new TreeNode("PuBu");
			treeView.Nodes.Add(treeNodePuBu);
			treeNodePuBu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodePuBuGn = new TreeNode("PuBuGn");
			treeView.Nodes.Add(treeNodePuBuGn);
			treeNodePuBuGn.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodePuOr = new TreeNode("PuOr");
			treeView.Nodes.Add(treeNodePuOr);
			treeNodePuOr.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodePuRd = new TreeNode("PuRd");
			treeView.Nodes.Add(treeNodePuRd);
			treeNodePuRd.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodePurples = new TreeNode("Purples");
			treeView.Nodes.Add(treeNodePurples);
			treeNodePurples.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeRdBu = new TreeNode("RdBu");
			treeView.Nodes.Add(treeNodeRdBu);
			treeNodeRdBu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodeRdGy = new TreeNode("RdGy");
			treeView.Nodes.Add(treeNodeRdGy);
			treeNodeRdGy.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodeRdPu = new TreeNode("RdPu");
			treeView.Nodes.Add(treeNodeRdPu);
			treeNodeRdPu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeReds = new TreeNode("Reds");
			treeView.Nodes.Add(treeNodeReds);
			treeNodeReds.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeRdYlBu = new TreeNode("RdYlBu");
			treeView.Nodes.Add(treeNodeRdYlBu);
			treeNodeRdYlBu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodeRdYlGn = new TreeNode("RdYlGn");
			treeView.Nodes.Add(treeNodeRdYlGn);
			treeNodeRdYlGn.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodeSet1 = new TreeNode("Set1");
			treeView.Nodes.Add(treeNodeSet1);
			treeNodeSet1.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeSet2 = new TreeNode("Set2");
			treeView.Nodes.Add(treeNodeSet2);
			treeNodeSet2.Tag = new int[] { 3, 4, 5, 6, 7, 8, };

			TreeNode treeNodeSet3 = new TreeNode("Set3");
			treeView.Nodes.Add(treeNodeSet3);
			treeNodeSet3.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, };

			TreeNode treeNodeSpectral = new TreeNode("Spectral");
			treeView.Nodes.Add(treeNodeSpectral);
			treeNodeSpectral.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, };

			TreeNode treeNodeYlGn = new TreeNode("YlGn");
			treeView.Nodes.Add(treeNodeYlGn);
			treeNodeYlGn.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeYlGnBu = new TreeNode("YlGnBu");
			treeView.Nodes.Add(treeNodeYlGnBu);
			treeNodeYlGnBu.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeYlOrBr = new TreeNode("YlOrBr");
			treeView.Nodes.Add(treeNodeYlOrBr);
			treeNodeYlOrBr.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };

			TreeNode treeNodeYlOrRd = new TreeNode("YlOrRd");
			treeView.Nodes.Add(treeNodeYlOrRd);
			treeNodeYlOrRd.Tag = new int[] { 3, 4, 5, 6, 7, 8, 9, };
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (treeView.SelectedNode == null)
			{
				panel.Brushes = null;
			}
			else
			{
				string name = treeView.SelectedNode.Text;
				int[] an = (int[])treeView.SelectedNode.Tag;
				System.Drawing.Brush[][] brushes = new System.Drawing.Brush[an.Length][];
				for (int i = 0; i < an.Length; i++)
					brushes[i] = Style.Brushes(name, an[i]);
				System.Threading.Interlocked.Exchange(ref panel.Brushes, brushes);
			}
			panel.Invalidate();
		}

	}
}