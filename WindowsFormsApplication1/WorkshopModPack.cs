using Newtonsoft.Json;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class WorkshopModPack
    {
        public string filename = "Mod/language.workshop.json";
        // string, because this is a ulong and JSON doesn't like em
        public string publishedfileid = "";
        public string contentfolder = "Content";
        public string previewfile = "preview.png";
        public int visibility = (int)(ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic);          // hidden by default!
        public string title = "Language Mod";
        public string description = "This is a language mod.";
        public string metadata = "";
        public List<string> tags = new List<string>();


        public static WorkshopModPack Load(string filename)
        {
            string json;
            using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (TextReader textReader = new StreamReader(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    json = textReader.ReadToEnd();
                }
            }

            WorkshopModPack pack = JsonConvert.DeserializeObject<WorkshopModPack>(json);
            pack.filename = filename;
            if (!pack.tags.Contains("Language"))
            {
                pack.tags.Add("Language");
            }
            return pack;
        }

        public bool HasTag(string tag)
        {
            return tags.Contains(tag);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            using (FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    textWriter.Write(json);
                }
            }
        }
    }
}
