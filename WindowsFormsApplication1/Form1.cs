using Excel;
using Newtonsoft.Json;
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

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        WorkshopModPack _pack;
        private UGCUpdateHandle_t currentHandle = UGCUpdateHandle_t.Invalid;
        private const int APP_ID = 550840;
        protected CallResult<CreateItemResult_t> _itemCreated;
        protected CallResult<SubmitItemUpdateResult_t> _itemSubmitted;
        public Form1()
        {
            SteamAPI.Init();
            InitializeComponent();
            InitFolders();
            
            _itemCreated = CallResult<CreateItemResult_t>.Create(OnItemCreated);
            _itemSubmitted = CallResult<SubmitItemUpdateResult_t>.Create(OnItemSubmitted);

            string filename = "Mod/language.workshop.json";

            if (File.Exists(filename))
            {//读取
                _pack = WorkshopModPack.Load(filename);
            }
            else
            {//创建
                _pack = new WorkshopModPack();
                _pack.filename = filename;
                SteamAPICall_t call = SteamUGC.CreateItem(new AppId_t(APP_ID), Steamworks.EWorkshopFileType.k_EWorkshopFileTypeCommunity);
                _itemCreated.Set(call);
                
            }
            
        }

        private void OnItemCreated(CreateItemResult_t callback, bool ioFailure)
        {
            
            if (ioFailure)
            {
                _status.Text = "Error: I/O Failure! :(";
                return;
            }

            switch (callback.m_eResult)
            {
                case EResult.k_EResultInsufficientPrivilege:
                    // you're banned!
                    _status.Text = "Error: Unfortunately, you're banned by the community from uploading to the workshop! Bummer. :(";
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
            }
            
        }
         
        private void InitFolders()
        {
            if (!Directory.Exists("Mod"))
            {
                Directory.CreateDirectory("Mod");
            }

            if (!Directory.Exists("Mod/Content"))
            {
                Directory.CreateDirectory("Mod/Content");
            }
        }

        private void NewMod(string modName)
        {

        }

        private void ProcessLanguage(string filename)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);

            // Choose one of either 1 or 2

            // 2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);



            // 4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //判断Excel文件中是否存在数据表
            if (result.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable sheet = result.Tables[0];

            //判断数据表内是否存在数据
            if (sheet.Rows.Count < 1)
                return;

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
                using (TextWriter textWriter = new StreamWriter(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    textWriter.Write(json);
                }
            }



            // 6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
        }

        private void Submit(object sender, EventArgs e)
        {
            ProcessLanguage("E:/projects/SteamWorkshopUploader/WorkshopContent/testMod/lang/language.xlsx");
        }
    }
}
