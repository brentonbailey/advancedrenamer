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
    public partial class FrmRenamePattern : Form
    {

        public string Pattern { get; set; }

        public FrmRenamePattern(string pattern)
        {
            InitializeComponent();
            Pattern = pattern;
            richTextRenamePattern.Text = pattern;
            richTextRenamePattern.Focus();
        }


        private void linkLabelShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertText(linkLabelShow.Text, Color.Blue);
            richTextRenamePattern.Focus();
        }

        private void linkLabelEpisode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertText(linkLabelEpisode.Text, Color.Blue);
            richTextRenamePattern.Focus();
        }

        private void linkLabelSeason_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertText(linkLabelSeason.Text, Color.Blue);
            richTextRenamePattern.Focus();
        }

        private void linkLabelTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InsertText(linkLabelTitle.Text, Color.Blue);
            richTextRenamePattern.Focus();
        }

        private void InsertText(string text, Color color)
        {
            richTextRenamePattern.SelectionLength = 0;
            richTextRenamePattern.SelectionColor = color;
            richTextRenamePattern.SelectedText = text;
            richTextRenamePattern.SelectionColor = richTextRenamePattern.ForeColor;
        }

        private void richTextRenamePattern_TextChanged(object sender, EventArgs e)
        {
            Pattern = richTextRenamePattern.Text;
        }
    }
}
