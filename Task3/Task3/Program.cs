using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            Dictionary<double, string> Rus_Strings =  methods.ParseRus_string(@"SourceRus.txt"); // create dictionary Russian strings
            Dictionary<double, StringAndComment> Eng_Strings = methods.Parse_Eng_string(@"SourceEng.txt"); // create dictionary English strings
            foreach (var e in Rus_Strings)
            {
                foreach(var i in Eng_Strings)
                {
                    if (e.Key == i.Key) Console.WriteLine($"{e.Value} {i.Value.EngString}"); //searching all Eng strings for each Russian string and write it
                }
            }
            Console.ReadKey();
        }
    }
}
