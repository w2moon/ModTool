using Microsoft.Xna.Framework;
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
    public partial class ModView : Form
    {
        string basePath = "Mod/modView/Content/view/";
        string headPath = "template/body/sharkzhiti1";
        string bodyPath = "template/body/Zombie01";
        string legPath = "template/body/sharkzhiti1";
        List<ViewItem> items;
        ViewItem curItem;
        public ModView()
        {
            InitializeComponent();
            imgShower.initHandler += InitEventHandler;
            spineShower.initHandler += InitSpine;
            
        }
        public void InitEventHandler(object sender)
        {
            init();
            UpdateList();
        }
        public void InitSpine(object sender)
        {
            SpineBase sb = new SpineBase(spineShower.GraphicsDevice, headPath + "/sharkzhiti1-1_legs_role.json");
            sb.Play("walk",true);
            sb.SetPosition(new Vector2(200,200));
            spineShower.AddObject(sb);
        }

        public void init()
        {
            
            if (File.Exists(basePath + "viewItems.json"))
            {
                items = ModSelector.loadJson<List<ViewItem>>(basePath + "viewItems.json");
            }
            else
            {
                items = new List<ViewItem>();
            }

            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
             
        }

        private int findItemByName(string folderName)
        {
            for(int i = 0; i < items.Count; ++i)
            {
                if(items[i].path == folderName)
                {
                    return i;
                }
            }
            return -1;
        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string folderName = listBox1.SelectedItem.ToString();
            int idx = findItemByName(folderName);
            

            string path = basePath + folderName + "/" + folderName + ".png";
            
            if (!File.Exists(path))
            {
                imgShower.Clear();
                return;
            }

            imgShower.AddObject(new Sprite(imgShower.GraphicsDevice, path));

        }

        private void UpdateList()
        {
            listBox1.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(basePath);
            var directories = info.GetDirectories();

            var idx = 0;
            foreach (DirectoryInfo directory in directories)
            {

                listBox1.Items.Add(directory.Name);
               
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = idx;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = chooseFileDialog.ShowDialog();
            if(dr != DialogResult.OK)
            {
                return;
            }
            string filename = chooseFileDialog.FileName;
            string dir = Path.GetDirectoryName(filename);
            string onlyfilename = Path.GetFileNameWithoutExtension(filename);
            string ext = Path.GetExtension(filename);

            if(ext!=".png" && ext != ".json")
            {
                MessageBox.Show("need png file or spine json file");
                return;
            }

            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            if (!Directory.Exists(basePath + onlyfilename))
            {
                Directory.CreateDirectory(basePath + onlyfilename);
            }

            File.Copy(filename, basePath + onlyfilename + "/" + Path.GetFileName(filename));
            
        }
    }
}
