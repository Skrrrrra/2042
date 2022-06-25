using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchInText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputpath = "D:\\SolutionsForSpaceApp\\2042\\input.txt";
            string outputpath = "D:\\SolutionsForSpaceApp\\2042\\output.txt";

            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();
            string line = "";
            string mask = "";
            using (StreamReader reader = new StreamReader(inputpath))
            {
                line = reader.ReadLine();
                mask = reader.ReadLine();
            }
            int c = 0;
            List<int> output = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                c = 0;
                for (int j = 0; j < mask.Length; j++)
                {
                    if (i + j < line.Length && (mask[j] == '?' || mask[j] == line[i + j]))
                    {
                        c++;
                    }
                    else break;
                }
                if (c == mask.Length) output.Add((i + 1));  
            }
            using(StreamWriter sr = new StreamWriter(outputpath))
            for (int i = 0; i < output.Count; i++)
            {
                sr.Write(output[i].ToString() + " ");
            }
        }
    }
}
