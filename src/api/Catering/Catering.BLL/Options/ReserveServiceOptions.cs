using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.BLL.Options
{
    public class ReserveServiceOptions
    {
        public const string Section = "ReserveClient";
        public string Url { get; set; }
        public string Action { get; set; }
    }
}
