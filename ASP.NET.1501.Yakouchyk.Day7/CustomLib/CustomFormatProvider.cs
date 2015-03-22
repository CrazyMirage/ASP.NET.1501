using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public CustomFormatProvider()
            : this(CultureInfo.CurrentCulture)
        { }

        public CustomFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "hex" || !(arg is int))
                return string.Format(parent, "{0:" + format + "}", arg);

            return FormatHex((int)arg);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        private string FormatHex(int number)
        {

            string[] hexNumbers = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split();
            char minus = '-';
            int mask = 0xF;
            int shift = 4;

            StringBuilder result = new StringBuilder();
            int i = (sizeof(int) * 2) - 1;

            if (number < 0)
            {
                number = ~number + 1;
                result.Append(minus);
            }

            bool flag = false;
            for (; i >= 0; i--)
            {
                int counted = (number >> (shift * i)) & mask;
                if (flag)
                {
                    result.Append(hexNumbers[counted]);
                }
                else
                {
                    if (counted != 0)
                    {
                        result.Append(hexNumbers[counted]);
                        flag = true;
                    }
                }
            }
            if (!flag) result.Append(hexNumbers[0]);

            return result.ToString();
        }
    }
}
