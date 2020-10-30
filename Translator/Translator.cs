using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TranslatorService
{
    public static class Translator
    {
        private static readonly string Key = Environment.GetEnvironmentVariable("translatorKey", EnvironmentVariableTarget.User);

        public static async Task<string> Translate(string textToTranslate, string fromLanguage)
        {
            var body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using var client = new HttpClient();
            using var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from={fromLanguage}&to=pt-br"),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Ocp-Apim-Subscription-Key", Key);
            request.Headers.Add("Ocp-Apim-Subscription-Region", "brazilsouth");

            var response = await client.SendAsync(request).ConfigureAwait(false);
        
            var result = await response.Content.ReadAsStringAsync();
            var translations = JsonConvert.DeserializeObject<List<Results>>(result);
            return translations.FirstOrDefault()?.Translations.FirstOrDefault()?.Text;
        }

        private class Results
        {
            public IList<Translation> Translations { get; set; }
        }

        private class Translation
        {
            public string Text { get; set; }
        }
    }
}