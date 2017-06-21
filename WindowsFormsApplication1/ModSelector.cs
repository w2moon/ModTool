using Steamworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace ModTool
{
    public partial class ModSelector : Form
    {
        public string lastChooseName = "";
        public ModSelector()
        {
            InitializeComponent();

            if (!SteamAPI.Init())
            {
                MessageBox.Show("Need Steam Opening", "Error");
            }
            if (!Directory.Exists("Mod"))
            {
                Directory.CreateDirectory("Mod");

            }
            StartUpdate();
            UpdateList();


        }
        private void UpdateList()
        {
            modListBox.Items.Clear();
            string basepath = System.Windows.Forms.Application.StartupPath + "/Mod/";
            DirectoryInfo info = new DirectoryInfo(basepath);
            var directories = info.GetDirectories();

            var idx = 0;
            foreach (DirectoryInfo directory in directories)
            {
                
                modListBox.Items.Add(directory.Name);
                if (directory.Name == lastChooseName)
                {
                    idx = modListBox.Items.Count - 1;
                }
            }
            if(modListBox.Items.Count > 0)
            {
                modListBox.SelectedIndex = idx;
            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateMod form = new CreateMod();
            form.setSelector(this);
            form.ShowDialog();
            UpdateList();
        }

        private void StartUpdate()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += Update;
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            SteamAPI.RunCallbacks();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (modListBox.SelectedItem == null)
            {
                return;
            }
            string modName = modListBox.SelectedItem.ToString();
            var form = new WindowsFormsApplication1.ModTool();
            form.setBasePath(System.Windows.Forms.Application.StartupPath + "/Mod/"+modName+"/",modName);
            form.ShowDialog();
        }
    }
}
