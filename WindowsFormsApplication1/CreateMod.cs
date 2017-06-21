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
    public partial class CreateMod : Form
    {
        private string basepath;
        private WorkshopModPack _pack;
        private uint APP_ID = 550840;
        protected CallResult<CreateItemResult_t> _itemCreated;
        private ModSelector selector;
        public CreateMod()
        {
            InitializeComponent();
            basepath = System.Windows.Forms.Application.StartupPath + "/Mod/";
            DirectoryInfo info = new DirectoryInfo(basepath);
            var directories = info.GetDirectories();

            StreamReader objReader = new StreamReader("steam_appid.txt");
            APP_ID = uint.Parse(objReader.ReadLine());

            var prefix = "Mod";
            Dictionary<string,int> names = new Dictionary<string, int>();
            foreach (DirectoryInfo directory in directories)
            {
                names.Add(directory.Name,1);
            }
            var name = "NewMod";
            int idx = 1;
            while (true)
            {
                name = prefix + idx.ToString();
                if (!names.ContainsKey(name))
                {
                    break;
                }
                idx++;
            }
            textName.Text = name;

            _itemCreated = CallResult<CreateItemResult_t>.Create(OnItemCreated);
        }

        public void setSelector(ModSelector sel)
        {
            selector = sel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string filename = basepath + textName.Text+"/"+ textName.Text+ ".workshop.json";

            _pack = new WorkshopModPack();
            _pack.filename = filename;
            SteamAPICall_t call = SteamUGC.CreateItem(new AppId_t(APP_ID), Steamworks.EWorkshopFileType.k_EWorkshopFileTypeCommunity);
            _itemCreated.Set(call);

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnItemCreated(CreateItemResult_t callback, bool ioFailure)
        {

            if (!ioFailure)
            {
                Directory.CreateDirectory(basepath + textName.Text);
                selector.lastChooseName = textName.Text;
                if (callback.m_bUserNeedsToAcceptWorkshopLegalAgreement)
                {//权限授予

                    /*
                     * Include text next to the button that submits an item to the workshop, something to the effect of: “By submitting this item, you agree to the workshop terms of service” (including the link)
        After a user submits an item, open a browser window to the Steam Workshop page for that item by calling:
        SteamFriends()->ActivateGameOverlayToWebPage( const char *pchURL );
        pchURL should be set to steam://url/CommunityFilePage/PublishedFileId_t replacing PublishedFileId_t with the workshop item Id.
        This has the benefit of directing the author to the workshop page so that they can see the item and configure it further if necessary and will make it easy for the user to read and accept the Steam Workshop Legal Agreement.
                     * */

                    //string pchURL = "http://url/CommunityFilePage/" + callback.m_nPublishedFileId.ToString();
                    // SteamFriends.ActivateGameOverlayToWebPage(pchURL);
                    string pchURL = "http://steamcommunity.com/workshop/workshoplegalagreement/?appid=" + APP_ID + "&originpublishedfileid=" + callback.m_nPublishedFileId.ToString();
                    System.Diagnostics.Process.Start(pchURL);
                }

                if (callback.m_eResult == EResult.k_EResultOK)
                {

                    _pack.publishedfileid = callback.m_nPublishedFileId.ToString();
                    _pack.Save();



                }
            }

           

            
            this.Close();

        }
    }
}
