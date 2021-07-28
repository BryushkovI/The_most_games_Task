using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NTextCat;
using Task1.ViewModels;

namespace Task1.Model
{
    public class Message
    {
        /// <summary>
        /// Text message
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// total of vowels in message
        /// </summary>
        public int Vowels_count { get; set; }
        /// <summary>
        /// total of words in message 
        /// </summary>
        public int Words_count { get; set; }
        public Message(string text)
        {
            Text = Deserialise(text);
            Words_count = Words_Counter(Text);
            Vowels_count = Vowels_Counter(Text);
        }
        /// <summary>
        /// Parse got JSON
        /// </summary>
        /// <param name="JSON"></param>
        /// <returns></returns>
        public string Deserialise(string JSON)
        {
            JToken jToken = JToken.Parse(JSON);
            return jToken["text"].ToString(); //get text token
        }
        /// <summary>
        /// Count total words in message
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int Words_Counter(string text)
        {
            List<string> words = text.Split(" ").ToList();
            int Punct = 0;
            foreach (var e in words)
            {
                if (char.IsPunctuation(e[0]))
                    Punct++; // count words in message

            }
            return words.Count-Punct;
        }
        /// <summary>
        /// Check for vowel
        /// </summary>
        /// <param name="e">Char</param>
        /// <returns></returns>
        private bool isVowel(string e)
        {
            foreach(var i in MainWindowVM.vowels)
            {
                if (e.Equals(i)) return true;
            }
            return false;
        }
        /// <summary>
        /// Count total vowels
        /// </summary>
        /// <param name="text">Message</param>
        /// <returns></returns>
        public int Vowels_Counter(string text)
        {
            int counter = 0;
            foreach(var e in text)
            {
                if (isVowel(e.ToString()))
                    counter++;
            }
            return counter;
        }
    }
}
