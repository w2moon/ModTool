using Newtonsoft.Json;
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
        WindowsFormsApplication1.ModTool _modTool;
        int _lastIndex;
        int _tot;
        int _valid;
        public FormLanguage()
        {
            InitializeComponent();
            


        }

        private void listBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = (string)listBoxID.SelectedItem;
            _lastIndex = listBoxID.SelectedIndex;
            lblId.Text = key;
            var old = _src[key];
            if(old != null)
            {
                boxEn.Text = old["en"].ToString();
                boxZh.Text = old["zh"].ToString();

            }
            boxMy.Text = _my[key].ToString();
            boxMy.SelectAll();
        }

        public void save()
        {
            string json = JsonConvert.SerializeObject(_my, Newtonsoft.Json.Formatting.Indented);
            _modTool.SaveModLang(json);
        }

        private void boxMyChanged(object sender, EventArgs e)
        {
            if(listBoxID.SelectedItem == null)
            {
                return;
            }
            string key = (string)listBoxID.SelectedItem;
            if(_my[key].ToString() == "" && boxMy.Text != "")
            {
                _valid++;
                updateNum();
            }
            else if(_my[key].ToString() != "" && boxMy.Text == "")
            {
                _valid--;
                updateNum();
            }
            _my[key] = boxMy.Text;
            save();
        }

        private void boxFilterChanged(object sender, EventArgs e)
        {
            listItems(boxIDFilter.Text, boxTextFilter.Text);
        }

        private void boxTextFilterChanged(object sender, EventArgs e)
        {
            listItems(boxIDFilter.Text,boxTextFilter.Text);
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            listItems(boxIDFilter.Text, boxTextFilter.Text);
        }

        private void listItems(string searchStr,string contentStr)
        {
            bool onlyEmpty = checkBoxOnlyEmpty.Checked;
            listBoxID.Items.Clear();
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
            _tot = 0;
            _valid = 0;
            bool isEmpty = false;
            foreach (var item in _my)
            {
                var key = item.Key;
                if (key == "")
                {
                    continue;
                }
                if(searchStr!="" && !key.Contains(searchStr))
                {
                    continue;
                }
                if (key.ToString().EndsWith(".png"))
                {
                    continue;
                }
                if (_src[key]["en"].ToString().EndsWith(".png"))
                {
                    continue;
                }
                if (_src[key]["zh"].ToString().EndsWith(".png"))
                {
                    continue;
                }

                if (contentStr != "" && !_src[key]["en"].ToString().Contains(contentStr) && !_src[key]["zh"].ToString().Contains(contentStr))
                {
                    continue;
                }
                isEmpty = _my[key] == null || _my[key].ToString() == "";
                if (isEmpty)
                {
                    
                }
                else
                {
                    if (onlyEmpty)
                    {
                        continue;
                    }
                    _valid++;
                }
                _tot++;
                listBoxID.Items.Add(item.Key);
            }

            

            updateNum();

            if(listBoxID.Items.Count == 0)
            {
                boxEn.Text = "";
                boxZh.Text = "";
                boxMy.Text = "";
                lblId.Text = "";
                return;
            }

            listBoxID.SelectedIndex = 0;
        }
        private void updateNum()
        {
            lblNum.Text = "total:" + _tot.ToString()+" remain:"+(_tot - _valid).ToString();
        }

        public void init(JObject src,JObject my,WindowsFormsApplication1.ModTool modTool)
        {
            _src = src;
            _my = my;
            _modTool = modTool;

            

            listBoxID.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxID.DrawItem += new DrawItemEventHandler(this.listBoxID_DrawItem);
            checkBoxOnlyEmpty.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            _lastIndex = 0;
            boxMy.TextChanged += new System.EventHandler(this.boxMyChanged);
            listItems("","");
            boxIDFilter.TextChanged +=  new System.EventHandler(this.boxFilterChanged);
            boxTextFilter.TextChanged += new System.EventHandler(this.boxTextFilterChanged);
        }
        private void listBoxID_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index == -1)
            {
                return;
            }
            Color vColor = e.ForeColor;
            Color vFontColor = e.ForeColor;
            var key = ((ListBox)sender).Items[e.Index].ToString();

                if (_my[key] == null || _my[key].ToString() == "")
                {
                    vColor = Color.Coral;
                    vFontColor = Color.White;
            }
                else
                {
                    vFontColor = Color.Black;
                    vColor = Color.LightGreen;
                }

            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                vFontColor = Color.White;
                e.Graphics.FillRectangle(new SolidBrush(Color.SlateBlue), e.Bounds);
            }

            else
            {
                e.Graphics.FillRectangle(new SolidBrush(vColor), e.Bounds);

            }


            
            
            e.Graphics.DrawString(key, e.Font, new SolidBrush(vFontColor), e.Bounds);

            
            e.DrawFocusRectangle();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(listBoxID.SelectedIndex >= listBoxID.Items.Count-1)
            {
                return;
            }
            listBoxID.SelectedIndex++;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(listBoxID.SelectedIndex <= 0)
            {
                return;
            }
            listBoxID.SelectedIndex--;
        }

     
    }
}
