using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class StringAndComment
    {
        /// <summary>
        /// English string
        /// </summary>
        public string EngString { get; set; }
        /// <summary>
        ///  English comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Summary Ptrenko index of string and comment
        /// </summary>
        public double Index
        {
            get
            {
                int letters = 0;
                foreach (var e in EngString)
                {
                    if (!char.IsPunctuation(e) && !char.IsWhiteSpace(e)) letters++;
                }
                double index = (Math.Pow(letters, 3)) / 2; //count Index of string
                letters = 0;
                foreach(var e in Comment)
                {
                    if (!char.IsPunctuation(e) && !char.IsWhiteSpace(e)) letters++;
                }
                index += (Math.Pow(letters, 3)) / 2; // count index of comment
                return index;
            }
        }

        public StringAndComment(string InputString)
        {
            Splitter(InputString);
        }
        private void Splitter(string inputStiring)
        {
            EngString = inputStiring.Split('|')[0]; //string
            Comment = inputStiring.Split('|')[1]; // comment
        }
    }
}
