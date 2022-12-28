using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using WikipediaAPI.Models;

namespace WikipediaAPI.Services
{
    public class WikipediaService
    {
        private static HttpClient _client = new HttpClient();
        private static string GetIndexUrl { get; set; } = @"https://en.wikipedia.org/w/api.php?action=query&origin=*&format=json&generator=search&gsrnamespace=0&gsrlimit=5&gsrsearch=";
        private static string GetPageTextUrl { get; set; } = @"https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&pageids=";

        public static async Task<List<WikiModel>> GetPageIndexes(string search)
        {
            string url = GetIndexUrl + $"\'{search}\'";
            //var response = await _client.GetAsync(url);
            var response = Task.Run(() => _client.GetAsync(url)).Result;
            var str = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(str);
            var result = data.query.pages;
            List<WikiModel> models = new List<WikiModel>();
            foreach (var item in result)
            {
                var pageId = (item.Value.pageid).ToString();
                var title = (item.Value.title).ToString();
                var wikiItem = new WikiModel
                {
                    PageId = pageId,
                    Title = title
                };
                models.Add(wikiItem);
            }
            return models;
        }

        public static async Task<WikiText> GetDataByPageId(string pageId)
        {
            var url = GetPageTextUrl + pageId;
            //var response = await _client.GetAsync(url);
            var response = Task.Run(() => _client.GetAsync(url)).Result;
            var str = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(str);

            string title = string.Empty;
            string text = string.Empty;
            var t = data.query.pages;
            foreach (var item in t)
            {
                var c = item;
                foreach (var i in c)
                {
                    var q = i;
                    title = q.title;
                    text = q.extract;
                }
            }   

            var wikiText = new WikiText()
            {
                Text = text,
                Title = title
            };
            return wikiText;
        }
    }
}
