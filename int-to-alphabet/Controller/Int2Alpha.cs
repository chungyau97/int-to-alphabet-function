using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace int_to_alphabet.Controller
{
    public class Int2Alpha
    {
        const int ColumnBase = 26;
        const int DigitMax = 7; // ceil(log26(Int32.Max))
        const string Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string IntToAlpha(int index)
        {
            try
            {
                if (index <= 0)
                    throw new IndexOutOfRangeException("index must be a positive number");

                if (index <= ColumnBase)
                    return Digits[index - 1].ToString();

                var sb = new StringBuilder().Append(' ', DigitMax);
                var current = index;
                var offset = DigitMax;
                while (current > 0)
                {
                    sb[--offset] = Digits[--current % ColumnBase];
                    current /= ColumnBase;
                }
                return sb.ToString(offset, DigitMax - offset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
