using System;
using System.IO;
using System.Text;

namespace int_to_alphabet
{
    class Program
    {
        const int ColumnBase = 26;
        const int DigitMax = 7; // ceil(log26(Int32.Max))
        const string Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter count of columns:");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("Loop (Y/N):");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y")
            {
                string path = Directory.GetCurrentDirectory();
                string filename = "/result.txt";
                using (StreamWriter writer = File.AppendText(path + filename))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(IndexToColumn(i + 1));
                    }
                }
            }
            else
            {
                Console.WriteLine("Output: " + IndexToColumn(count + 1));
            }

            Console.WriteLine("Complete");
        }
        public static string IndexToColumn(int index)
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
    }
}
