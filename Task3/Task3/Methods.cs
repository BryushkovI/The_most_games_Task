using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Methods
    {
        /// <summary>
        /// Create Dictionary with indexes and strings
        /// </summary>
        /// <param name="Path">Path for txt-file</param>
        /// <returns></returns>
        public Dictionary<double, string> ParseRus_string(string Path)
        {
            StreamReader sr = new StreamReader(Path);
            Dictionary<double, string> DictionaryStrings = new Dictionary<double, string>();
            List<string> ListStrings = sr.ReadToEnd().Split('\n').ToList(); // reading all strings from txt-file
            sr.Close(); // close stream
            foreach(var e in ListStrings)
            {
                int letters = 0;
                foreach(var i in e)
                {
                    if (!char.IsPunctuation(i) && !char.IsWhiteSpace(i)) letters++;
                }
                double index = (Math.Pow(letters, 3)) / 2; // count Petrenko index of string
                DictionaryStrings.Add(index, e);
            }
            return DictionaryStrings;
        }
        /// <summary>
        /// Create dictionary with indexes and strings and comments
        /// </summary>
        /// <param name="Path">Path for txt-file</param>
        /// <returns></returns>
        public Dictionary<double,StringAndComment> Parse_Eng_string(string Path)
        {
            StreamReader sr = new StreamReader(Path);
            Dictionary<double, StringAndComment> DictionaryStrings = new Dictionary<double, StringAndComment>();
            List<string> ListStrings = sr.ReadToEnd().Split('\n').ToList(); // read all strings from txt-file
            sr.Close(); // close stream
            foreach(var e in ListStrings)
            {
                StringAndComment stringAndComment = new StringAndComment(e); // create new English string and Comment
                DictionaryStrings.Add(stringAndComment.Index, stringAndComment); // add to Dictionary
            }
            return DictionaryStrings;
        }
    }
}
