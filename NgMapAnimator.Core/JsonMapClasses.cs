using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapAnimator.Core
{
    public class JsonMapClasses
    {
        public static NgMapObj[] ParseMapJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<NgMapObj[]>(json);
            return obj;
        }
        public static string MapObj2Json(NgMapObj obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }
        public static NgMapObj[] LoadMapJson(string jsonFilename)
        {
            var jsonText = File.ReadAllText(jsonFilename);
            return ParseMapJson(jsonText);
        }
    }

    public class NgMapObj
    {
        public string id { get; set; }
        public string img { get; set; }
        public string backLink { get; set; }
        public List<NgMapObjPoint> points { get; set; }
    }

    public class NgMapObjPoint
    {
        public string href { get; set; }
        public string target { get; set; }
        public string label { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
}
