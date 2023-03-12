using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.Helpers
{
    public static class StringHelper
    {
        public static string UnicodeToStr(string unicodeStr)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(unicodeStr))
            {
                string[] strlist = unicodeStr.Replace("&#", "").Replace(";", "").Split('x');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
            return outStr;
        }

    }
}
