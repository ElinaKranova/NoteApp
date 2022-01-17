using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    /// <summary>
    /// Класс формы About.
    /// </summary>
    public partial class About : Form
    {
        /// <summary>
        /// Создает экземпляр About.
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            linkEmail.Text = "elinixelka@mail.ru";
            linkGit.Text = "ElinaKrasnova/NoteApp.git";
        }

        private void linkGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/" + linkGit.Text);
        }

        private void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:" + linkEmail.Text);
        }
    }
}
