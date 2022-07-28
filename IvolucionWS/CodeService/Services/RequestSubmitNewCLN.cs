using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CodeService.Helpers;
using CodeService.Interfaces;

namespace CodeService.Services
{
    public class RequestSubmitNewCLN : IRequestSubmitNewCLN
    {
        public async Task<bool> GetRequestSubmitNewCLN(string url, string apiKey)
        {
            var respuesta = string.Empty;
            var result = false;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Apikey", apiKey);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                respuesta = await response.Content.ReadAsStringAsync();
                result = true;
            }

            return result;
        }
    }
}
