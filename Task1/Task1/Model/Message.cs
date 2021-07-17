using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Task1.Model
{
    public class Message
    {
        public string Text { get; set; }
        public int Vowels_count { get; set; }
        public int Words_count { get; set; }
        public Message(string text)
        {
            Text = Deserialise(text);
            Words_count = Words_Counter(Text);
        }
        public string Deserialise(string JSON)
        {
            JToken jToken = JToken.Parse(JSON);
            return jToken["text"].ToString();
        }
        public int Words_Counter(string text)
        {
            List<string> words = text.Split(" ").ToList();
            int Punct = 0;
            foreach (var e in words)
            {
                if (char.IsPunctuation(e[0]))
                    Punct++;

            }
            return words.Count-Punct;
        }
    }
}
