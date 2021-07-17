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
        public static ObservableCollection<int> ParseId(this string Input_id)
        {
            List<string> vs = Input_id.Split(new char[] {',',';'}).ToList();
            ObservableCollection<int> List_Id = new();
            foreach(var e in vs)
            {
                if (!List_Id.Contains(int.Parse(e)))
                    List_Id.Add(int.Parse(e));
            }
            return List_Id;
        }
    }
    public class Methods
    {
        async static public void Get(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"http://tmgwebtest.azurewebsites.net/api/textstrings/{id}?"))
                {
                    request.Headers.TryAddWithoutValidation("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");
                    HttpResponseMessage message = await httpClient.SendAsync(request);
                    string s = await message.Content.ReadAsStringAsync();
                    MainWindowVM._messages.Add(new Message(s));
                }
            }
        }

        public Message GetMessage(string GotJSON)
        {
            
            Message message = new Message("");

            return message;
        }

    }
}
