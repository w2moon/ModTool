using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static string langName;
        public static JObject lang;
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

            langName = System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
            string str;
            using (FileStream fileStream = new FileStream("template/lang.json", FileMode.Open, FileAccess.Read))
            {
                using (TextReader textReader = new StreamReader(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    str = textReader.ReadToEnd();
                }
            }

            lang  = (JObject)JsonConvert.DeserializeObject(str);

            if (langName == "zh")
            {
            }
            else
            {
                if (lang[langName] == null)
                {
                    langName = "en";
                }

            }
            UpdateUILanguage();

        }

        public static string getLang(string name)
        {
            return lang[name][langName].ToString();
        }

        public static T loadJson<T>(string filename)
        {
            string json;
            using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (TextReader textReader = new StreamReader(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    json = textReader.ReadToEnd();
                }
            }

           return JsonConvert.DeserializeObject<T>(json);
        }

        public void UpdateUILanguage()
        {
            this.Text = getLang("modSelector");
            btnNew.Text = getLang("new");
            btnEdit.Text = getLang("edit");
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
