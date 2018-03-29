﻿using CSNovelCrawler.Class;
using CSNovelCrawler.Core;
using System;
using System.Windows.Forms;
using CSNovelCrawler.Interface;

namespace CSNovelCrawler.UI
{
    public partial class FormNew : Form
    {
        public FormNew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string url in richTextBox1.Lines)
            {
                if (!string.IsNullOrEmpty(url.Trim()))
                {
                    IPlugin plugin = CoreManager.PluginManager.GetPlugin(url.Contains(@".html") ? url : url + @".html");
                    if (plugin != null)
                    {
                        TaskInfo taskInfo = CoreManager.TaskManager.AddTask(plugin, url.Contains(@".html") ? url : url + @".html");
                        CoreManager.TaskManager.AnalysisTask(taskInfo);
                    }

                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
