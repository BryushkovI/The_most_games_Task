using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task1.ViewModels;

namespace Task1.Model
{
    public static class ExtMethods
    {
        /// <summary>
        /// Parse input Id
        /// </summary>
        /// <param name="Input_id">Id string</param>
        /// <returns></returns>
        public static ObservableCollection<int> ParseId(this string Input_id)
        {
            List<string> vs = Input_id.Split(new char[] {',',';'}).ToList(); //List of splitters
            ObservableCollection<int> List_Id = new(); // Correct ID list
            string ErrorsId = "";
            foreach(var e in vs)
            {
                try
                {
                    if (!List_Id.Contains(int.Parse(e)) && int.Parse(e) < 21 && int.Parse(e) > 0)
                        List_Id.Add(int.Parse(e));
                    else
                    {
                        ErrorsId = $"{ErrorsId} " + int.Parse(e);
                    }
                }
                catch (FormatException)
                {
                    ErrorsId = $"{ErrorsId} " + e;
                }
            }
            if (ErrorsId.Length > 1) MessageBox.Show($"Были введены неверные id:{ErrorsId}");
            return List_Id;
        }
    }
    public class Methods
    {
        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="id">Id</param>
        async static public void Get(int id)
        {
            using var httpClient = new HttpClient();
            try
            {
                using var request = new HttpRequestMessage(new HttpMethod("GET"), $"http://tmgwebtest.azurewebsites.net/api/textstrings/{id}?");
                request.Headers.TryAddWithoutValidation("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");
                HttpResponseMessage message = await httpClient.SendAsync(request); // getting message from server
                string s = await message.Content.ReadAsStringAsync(); // convert to string
                MainWindowVM._messages.Add(new Message(s)); // adding to message list
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Get all vowels
        /// </summary>
        /// <param name="Path">Path for txt-file</param>
        /// <returns></returns>
        public static List<string> Alph(string Path)
        {
            StreamReader sr = new(Path);
            string str = sr.ReadToEnd(); // read all strings
            List<string> vs1 = str.Split("\r\n").ToList(); // create list of Vowels
            return vs1;
        }

    }
}