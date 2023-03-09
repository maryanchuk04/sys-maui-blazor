using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_sys_app.Core
{
    internal static class Comparable
    {
        public static bool SingleCompare(string inp, string mask)
        {
            if (inp.Length < mask.Length)
            {
                return false;
            }

            if (inp.Length >= mask.Length && inp[0] == mask[0])
            {
                return true;
            }

            return false;
        }

        public static bool Compare(List<string> input, List<string> mask)
        {
            if (input.Count < mask.Count)
            {
                return false;
            }

            for (int i = 0; i < mask.Count; i++)
            {
                if (!SingleCompare(input[i], mask[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
