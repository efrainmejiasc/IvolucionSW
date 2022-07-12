using CodeService.Helpers;
using CodeService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeService.Services
{
    public class RequestScheduledVirtualAppointmentsDone : IRequestScheduledVirtualAppointmentsDone
    {
        public async Task<bool> GetRequestSheduleVirtualAppointmensDone(string url)
        {
            var respuesta = string.Empty;
            var result = false;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Apikey", EnviromentVar.ApiKeyIvolucion);
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
