using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapAnimator.Core
{
    public static class Utils
    {
        #region =============== useful not only in this application ===================

        public static long ParseThisLong(this string s, long def = 0)
        {
            long ddd;
            return long.TryParse(s, out ddd) ? ddd : def;
        }
        public static int ParseThisInt(this string s, int def = 0)
        {
            int ddd;
            return int.TryParse(s, out ddd) ? ddd : def;
        }
        public static float ParseThisFloat(this string s, float def = 0)
        {
            float ddd;
            return float.TryParse(s, out ddd) ? ddd : def;
        }
        public static double ParseThisDouble(this string s, double def = 0)
        {
            double ddd;
            return double.TryParse(s, out ddd) ? ddd : def;
        }

        public static double LinearX(double x1, double x2, double progressOutOf1)
        {
            return x1 + (x2 - x1) * progressOutOf1;
        }

        #endregion
        
    }
}
