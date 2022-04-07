using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.Stores
{
    public static class DetailNamesStore
    {
        private static List<string> _detailNames = new List<string>
        {
            "nut",
            "screw",
            "panel",
            "engine",
            "software"
        };
        public static List<string> DetailNames { get => _detailNames; }
    }
}
