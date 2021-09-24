using System;
using System.IO;
using System.Text;
using int_to_alphabet.Controller;

namespace int_to_alphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int count = GetCounter();

                string loop = GetLoop();

                Console.WriteLine("Being to convert Int to Alphabet string.");

                GenerateInt2Alpha(count, loop);

                Console.WriteLine("Complete");
            }catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static int GetCounter()
        {
            try
            {
                Console.WriteLine("Enter count:");
                return int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                throw new Exception("Only allow numeric value.");
            }
        }
        private static string GetLoop()
        {
            try
            {
                Console.WriteLine("Loop (Y/N):");
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void GenerateInt2Alpha(int count, string loop)
        {
            try
            {
                Int2Alpha int2alpha = new Int2Alpha();

                if (loop.ToUpper() == "Y")
                {
                    string path = Directory.GetCurrentDirectory();
                    string filename = "/result.txt";
                    using (StreamWriter writer = File.AppendText(path + filename))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            writer.WriteLine(int2alpha.IntToAlpha(i + 1));
                        }
                        Console.WriteLine("Path of generated result:");
                        Console.WriteLine(path + filename);
                    }
                }
                else if(loop.ToUpper() == "N")
                {
                    Console.WriteLine("The count of " + count + " is " + int2alpha.IntToAlpha(count));
                }
                else
                {
                    throw new Exception("Logic is not handled");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
