using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModTool
{
    public partial class FormLanguage : Form
    {
        JObject _src;
        JObject _my;
        public FormLanguage()
        {
            InitializeComponent();
            
           

            
        }

        private void listBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = (string)listBoxID.SelectedItem;
            lblId.Text = key;
            var old = _src[key];
            if(old != null)
            {
                boxEn.Text = old["en"].ToString();
                boxZh.Text = old["zh"].ToString();

            }
            boxMy.Text = _my[key].ToString();
            
        }

        public void save()
        {
            string key = (string)listBoxID.SelectedItem;
        }

        private void boxMyChanged(object sender, EventArgs e)
        {
            string key = (string)listBoxID.SelectedItem;
            _my[key] = boxMy.Text;
            save();
        }

        public void init(JObject src,JObject my)
        {
            _src = src;
            _my = my;
            

            foreach (var item in _src)
            {
                if (item.Key == "")
                {
                    continue;
                }
                if (_my[item.Key] == null)
                {
                    _my[item.Key] = "";
                }
            }

            foreach (var item in _my)
            {
                if(item.Key == "")
                {
                    continue;
                }
                if (item.Key.ToString().EndsWith(".png"))
                {
                    continue;
                }
                listBoxID.Items.Add(item.Key);
            }

            listBoxID.SelectedIndex = 0;
            boxMy.TextChanged += new System.EventHandler(this.boxMyChanged);
        }
    }
}
