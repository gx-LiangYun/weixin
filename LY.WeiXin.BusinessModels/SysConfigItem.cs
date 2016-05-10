using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LY.WeiXin.BusinessModels
{
    public class SysConfigItem
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string ItemValue { get; set; }

        public string Description { get; set; }
    }
}
