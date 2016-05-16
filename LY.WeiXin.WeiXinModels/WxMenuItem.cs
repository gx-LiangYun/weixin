using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LY.WeiXin.WeiXinModels
{
    public class WxMenuItem
    {
        public string name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string key { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string url { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<WxMenuItem> sub_button { get; set; }
    }
}
