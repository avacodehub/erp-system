using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.Tools
{
    public static class IdGenerator
    {

        public static int CreateId(List<int> existing)
        {
            int result = Enumerable.Range(1, existing.Count + 1).First(x => !existing.Contains(x));
            return result;
        }
    }
}
