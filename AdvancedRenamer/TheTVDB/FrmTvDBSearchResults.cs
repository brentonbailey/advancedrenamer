using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedRenamer.TheTVDB
{
    public partial class FrmTvDBSearchResults : Form
    {
        /// <summary>
        /// Gets or sets the choosen result
        /// </summary>
        public TvDBSearchResult ChoosenResult { get; private set; }

        public FrmTvDBSearchResults(string searchString, List<TvDBSearchResult> results)
        {
            InitializeComponent();

            txtSearch.Text = searchString;
            PopulateResults(results);
        }

        private void PopulateResults(List<TvDBSearchResult> results)
        {
            listResults.Items.Clear();
            foreach (TvDBSearchResult result in results)
            {
                ListViewItem item = new ListViewItem(result.Title);
                item.ToolTipText = result.Overview;
                item.Tag = result;
                listResults.Items.Add(item);
            }
        }

        private void listShows_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmTvDBSearchResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChoosenResult == null)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            butOK.Enabled = listResults.SelectedItems.Count != 0;
        }

        private void listResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listResults.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag != null && item.Tag is TvDBSearchResult)
            {
                ChoosenResult = (TvDBSearchResult)item.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            ListViewItem item = listResults.SelectedItems[0];
            if (item != null && item.Tag != null && item.Tag is TvDBSearchResult)
            {
                ChoosenResult = (TvDBSearchResult)item.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void listResults_Resize(object sender, EventArgs e)
        {
            listResults.Columns[0].Width = listResults.Width - listResults.Margin.Left - listResults.Margin.Right;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Run a new search
                PopulateResults(TvDBApi.Instance.Search(txtSearch.Text));
            }
        }
    }
}
