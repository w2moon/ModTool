using Excel;
using ModTool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Steamworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class ModTool : Form
    {
        WorkshopModPack _pack;
        private UGCUpdateHandle_t currentHandle = UGCUpdateHandle_t.Invalid;
        private  uint APP_ID = 550840;
        protected CallResult<CreateItemResult_t> _itemCreated;
        protected CallResult<SubmitItemUpdateResult_t> _itemSubmitted;
        private string basepath = "Mod/";
        public string _appFolder;
        public Dictionary<string, ST_WL_FILE_INFO> _dict;
        public ModTool()
        {
           

            InitializeComponent();

            _dict = new Dictionary<string, ST_WL_FILE_INFO>();

            string langName = System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;

            if(langName == "zh")
            {

            }
            else
            {
                langName = "en";
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langName);
            UpdateUILanguage();

            StreamReader objReader = new StreamReader("steam_appid.txt");
            APP_ID = uint.Parse(objReader.ReadLine());
            
            if (!SteamAPI.Init())
            {
               _status.Text  = "Steam Init Error, Please Open Steam First.";
            }

            if (!SteamApps.BIsAppInstalled(new AppId_t(APP_ID)))
            {
                _status.Text = "Not found installed app in steam.";
            }
            else
            {
                SteamApps.GetAppInstallDir(new AppId_t(APP_ID),out _appFolder, 1024);
                _status.Text = _appFolder;
                loadIndexInfo();
            }

            basepath = System.Windows.Forms.Application.StartupPath + "/Mod/";

            InitFolders();
            
            _itemCreated = CallResult<CreateItemResult_t>.Create(OnItemCreated);
            _itemSubmitted = CallResult<SubmitItemUpdateResult_t>.Create(OnItemSubmitted);

            StartUpdate();

            string filename = basepath+"language.workshop.json";

            if (File.Exists(filename))
            {//读取
                _pack = WorkshopModPack.Load(filename);
                
            }
            else
            {//创建

                CreateMod(filename);
            }
            _title.Text = _pack.title;
            _description.Text = _pack.description;
            _preview.Image =  Image.FromFile(basepath + _pack.previewfile);// basepath + _pack.previewfile;


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

            if (currentHandle != UGCUpdateHandle_t.Invalid)
            {
                UpdateProgressBar(currentHandle);
            }
            
        }

       

            private void CreateMod(string filename)
        {
            _pack = new WorkshopModPack();
            _pack.filename = filename;
            SteamAPICall_t call = SteamUGC.CreateItem(new AppId_t(APP_ID), Steamworks.EWorkshopFileType.k_EWorkshopFileTypeCommunity);
            _itemCreated.Set(call);
        }

        private void OnItemCreated(CreateItemResult_t callback, bool ioFailure)
        {
            
            if (ioFailure)
            {
                _status.Text = "Error: I/O Failure!";
                return;
            }

            switch (callback.m_eResult)
            {
                case EResult.k_EResultInsufficientPrivilege:
                    // you're banned!
                    _status.Text = "Error: Unfortunately, you're banned by the community from uploading to the workshop! Bummer.";
                    break;
                case EResult.k_EResultTimeout:
                    _status.Text = "Error: Timeout :S";
                    break;
                case EResult.k_EResultNotLoggedOn:
                    _status.Text = "Error: You're not logged into Steam!";
                    break;
            }

            if (callback.m_bUserNeedsToAcceptWorkshopLegalAgreement)
            {//权限授予
                _status.Text = "Error: User Need To Accept Legal Agreement!";
                /*
                 * Include text next to the button that submits an item to the workshop, something to the effect of: “By submitting this item, you agree to the workshop terms of service” (including the link)
    After a user submits an item, open a browser window to the Steam Workshop page for that item by calling:
    SteamFriends()->ActivateGameOverlayToWebPage( const char *pchURL );
    pchURL should be set to steam://url/CommunityFilePage/PublishedFileId_t replacing PublishedFileId_t with the workshop item Id.
    This has the benefit of directing the author to the workshop page so that they can see the item and configure it further if necessary and will make it easy for the user to read and accept the Steam Workshop Legal Agreement.
                 * */
            }

            if (callback.m_eResult == EResult.k_EResultOK)
            {
                _status.Text = "Item creation successful! Published Item ID: " + callback.m_nPublishedFileId.ToString();
               
                _pack.publishedfileid = callback.m_nPublishedFileId.ToString();
                _pack.Save();


            }
   
        }

        private void OnItemSubmitted(SubmitItemUpdateResult_t callback, bool ioFailure)
        {
            currentHandle = UGCUpdateHandle_t.Invalid;
            _commit.Enabled = true;
            if (ioFailure)
            {
                _status.Text = "Error: I/O Failure!";
                return;
            }

            switch (callback.m_eResult)
            {
                case EResult.k_EResultOK:
                    _status.Text = "SUCCESS! Item submitted! ";
                    currentHandle = UGCUpdateHandle_t.Invalid;
                    break;
                default:
                    _status.Text = "Upload Fail!" + callback.m_eResult.ToString();
                    break;
            }
            
        }
         
        private void InitFolders()
        {
            if (!Directory.Exists("Mod"))
            {
                Directory.CreateDirectory("Mod");
                
            }

            if (!File.Exists(basepath + "preview.png"))
            {
                File.Copy("template/template.png", basepath + "preview.png", true);
            }

            if (!Directory.Exists(basepath+"Content"))
            {
                Directory.CreateDirectory(basepath+"Content");
            }
        }

        private void NewMod(string modName)
        {

        }

        private bool ProcessLanguage(string filename)
        {
            if (!File.Exists(filename))
            {
                _status.Text = "file not found:"+filename;
                return false;
            }
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);

            // Choose one of either 1 or 2

            // 2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);



            // 4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //判断Excel文件中是否存在数据表
            if (result.Tables.Count < 1)
            {
                _status.Text = "table num < 1";
                return false;
            }
                

            //默认读取第一个数据表
            DataTable sheet = result.Tables[0];

            //判断数据表内是否存在数据
            if (sheet.Rows.Count < 1)
            {
                _status.Text = "row num < 1";
                return false;
            }

            //读取数据表行数和列数
            int rowCount = sheet.Rows.Count;
            int colCount = sheet.Columns.Count;


            Dictionary<string, string> table = new Dictionary<string, string>();

            //读取数据
            for (int i = 1; i < rowCount; i++)
            {
                if (table.ContainsKey(sheet.Rows[i][0].ToString()))
                {
                    continue;
                }
                //添加到表数据中
                table.Add(sheet.Rows[i][0].ToString(), sheet.Rows[i][1].ToString());
            }

            //生成Json字符串
            string json = JsonConvert.SerializeObject(table, Newtonsoft.Json.Formatting.Indented);
            //写入文件
            using (FileStream fileStream = new FileStream(filename.Replace(".xlsx",".json"), FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, new System.Text.UTF8Encoding(false)))
                {
                    textWriter.Write(json);
                }
            }



            // 6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            return true;
        }

        private void Submit(object sender, EventArgs e)
        {
            SaveCurrentModPack();
            if (!ValidateModPack(_pack))
            {
                return;

            }
            _commit.Enabled = false;
            UploadModPack(_pack);
        }

        private void SaveCurrentModPack()
        {
            _pack.title = _title.Text;
            _pack.description = _description.Text;
            _pack.Save();
        }

        public bool ValidateModPack(WorkshopModPack pack)
        {
            _status.Text = "Validating mod pack...";

            /*
            if (pack.HasTag("Language"))
            {
                string langfile = basepath + _pack.contentfolder + "/lang/language.xlsx";
                if (!ProcessLanguage(langfile))
                {
                    return false;
                }
            }
            */

            string path = basepath + pack.previewfile;

            var info = new FileInfo(path);
            if (info.Length >= 1024 * 1024)
            {
                _status.Text = "ERROR: Preview file must be <1MB!";
                return false;
            }

            return true;
        }

        public void UploadModPack(WorkshopModPack pack)
        {
            _status.Text = "Uploading mod pack...";

            ulong ulongId = ulong.Parse(pack.publishedfileid);
            var id = new PublishedFileId_t(ulongId);

            UGCUpdateHandle_t handle = SteamUGC.StartItemUpdate(new AppId_t(APP_ID), id);

            currentHandle = handle;
            SetupModPack(handle, pack);
            SubmitModPack(handle, pack);
        }

        private void SetupModPack(UGCUpdateHandle_t handle, WorkshopModPack pack)
        {
            SteamUGC.SetItemTitle(handle, pack.title);
            SteamUGC.SetItemDescription(handle, pack.description);
            SteamUGC.SetItemVisibility(handle, (ERemoteStoragePublishedFileVisibility)pack.visibility);
            SteamUGC.SetItemContent(handle, basepath + pack.contentfolder);
            SteamUGC.SetItemPreview(handle, basepath + pack.previewfile);
            SteamUGC.SetItemMetadata(handle, pack.metadata);
            SteamUGC.SetItemTags(handle, pack.tags);
        }

        private void SubmitModPack(UGCUpdateHandle_t handle, WorkshopModPack pack)
        {
            SteamAPICall_t call = SteamUGC.SubmitItemUpdate(handle, _changeNote.Text);
            _itemSubmitted.Set(call);
            //In the same way as Creating a Workshop Item, confirm the user has accepted the legal agreement. This is necessary in case where the user didn't initially create the item but is editing an existing item.
        }

        private void UpdateProgressBar(UGCUpdateHandle_t handle)
        {
            ulong bytesDone;
            ulong bytesTotal;
            EItemUpdateStatus status = SteamUGC.GetItemUpdateProgress(handle, out bytesDone, out bytesTotal);

            
            int v = 100;
            if(bytesTotal > 0)
            {
                float progress = (float)bytesDone / (float)bytesTotal;
                v = (int)(progress * 100);
            }
            
            string txt = "";
            switch (status)
            {
                case EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges:
                    txt = "Committing changes...";
                    break;
                case EItemUpdateStatus.k_EItemUpdateStatusInvalid:
                    txt = "Item invalid ... ";
                    break;
                case EItemUpdateStatus.k_EItemUpdateStatusUploadingPreviewFile:
                    txt = "Uploading preview image...";
                    break;
                case EItemUpdateStatus.k_EItemUpdateStatusUploadingContent:
                    txt = "Uploading content...";
                    break;
                case EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig:
                    txt = "Preparing configuration...";
                    break;
                case EItemUpdateStatus.k_EItemUpdateStatusPreparingContent:
                    txt = "Preparing content...";
                    break;
            }
            if(bytesTotal != 0)
            {
                txt += v.ToString() + "%";
            }
            _status.Text = txt;

        }

        private void enToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            UpdateUILanguage();
        }

        private void zhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh");
            UpdateUILanguage();
        }

        private void UpdateUILanguage()
        {
            ResourceManager rm = new ResourceManager(typeof(ModTool));

            _lblTitle.Text = rm.GetString("title");
            _lblDescription.Text = rm.GetString("description");
            _lblChangeNote.Text = rm.GetString("changenote");
            _commit.Text = rm.GetString("submit");
        }

        public JObject loadJsonFromPack(string filename)
        {
            ST_WL_FILE_INFO info;
            if (!_dict.TryGetValue(filename, out info))
            {
                _status.Text = "not found lang file";
                return null;
            }

            byte[] data = unpackBuff(_appFolder + "/" + info.file, info.start, info.size);
            string v = Encoding.Default.GetString(data);
            return (JObject)JsonConvert.DeserializeObject(v);
        }

        public JObject loadJson(string filename)
        {
            string json;
            using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (TextReader textReader = new StreamReader(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    json = textReader.ReadToEnd();
                }
            }
            
            return (JObject)JsonConvert.DeserializeObject(json);
        }

        public void SaveModLang(string json)
        {
            //写入文件
            using (FileStream fileStream = new FileStream(basepath + _pack.contentfolder + "/lang/language.json", FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, new System.Text.UTF8Encoding(false)))
                {
                    textWriter.Write(json);
                }
            }
        }

        private void initModLang(JObject obj)
        {
            string langFolder = basepath + _pack.contentfolder + "/lang";
            if (!Directory.Exists(langFolder))
            {
                Directory.CreateDirectory(langFolder);

            }
            if (obj == null)
            {
                File.Copy("template/lang/language.json", langFolder + "/language.json", false);
                return;
            }
            Dictionary<string, string> table = new Dictionary<string, string>();
            foreach(var item in obj)
            {
                if (table.ContainsKey(item.Key))
                {
                    continue;
                }
                table.Add(item.Key,"");
            }
            //生成Json字符串
            string json = JsonConvert.SerializeObject(table, Newtonsoft.Json.Formatting.Indented);
            SaveModLang(json);
        }

        private void btnModLanguage_Click(object sender, EventArgs e)
        {
            //read new language file
            JObject src = loadJsonFromPack("res/lang/text_zh.json");
            if (src == null)
            {
                src = loadJson(basepath + _pack.contentfolder + "/lang/text_zh.json");
            }
            //read my language file
            string modlangFile = basepath + _pack.contentfolder + "/lang/language.json";
            if (!File.Exists(modlangFile))
            {
                initModLang(src);
            }
            JObject my = loadJson(modlangFile);
            //create newinfo
            FormLanguage form = new FormLanguage();
            form.init(src, my);
            form.ShowDialog();
            
        }

        private byte[] unpackBuff(string filename)
        {
            FileStream fs = File.OpenRead(filename);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            for(int i = 0; i < data.Length; ++i)
            {
                data[i] = (byte)(data[i] << 5 | data[i] >> 3);
            }
            return data;
        }

        private byte[] unpackBuff(string filename,int start,int size)
        {
            FileStream fs = File.OpenRead(filename);
            long a = fs.Length;
            byte[] data = new byte[size];
            fs.Seek(start, SeekOrigin.Begin);
            fs.Read(data, 0, data.Length);
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = (byte)(data[i] << 5 | data[i] >> 3);
            }
            return data;
        }


        private void loadIndexInfo()
        {
            byte[] data = unpackBuff(_appFolder + "/data/lg0.wld");
            using (StreamReader reader = new StreamReader(new MemoryStream(data)))
            {
                while (!reader.EndOfStream)
                {
                    var path = reader.ReadLine();
                    ST_WL_FILE_INFO info;
                    info.file = reader.ReadLine();
                    info.start = int.Parse(reader.ReadLine());
                    info.size = int.Parse(reader.ReadLine());
                    _dict.Add(path, info);
                }
                
            }
        }
    }
}
