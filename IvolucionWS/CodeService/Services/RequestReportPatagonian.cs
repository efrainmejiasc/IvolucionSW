using CodeService.Helpers;
using CodeService.Interfaces;
using CodeService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeService.Services
{
    public class RequestReportPatagonian: IRequestReportPatagonian
    {
        public async Task<ResponseReportPatagonian> ExecuteReportPatagonian(string url)
        {
            var reportPatagonian = new ResponseReportPatagonian();
            var respuesta = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Apikey", EnviromentVar.ApiKeyIvolucion);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    respuesta = response.Content.ReadAsStringAsync().Result;
                    reportPatagonian = JsonConvert.DeserializeObject<ResponseReportPatagonian>(respuesta);
                }
                else
                    reportPatagonian = null;
            }
            catch(Exception ex) 
            {
                reportPatagonian.message = ex.Message;
            }

            return  reportPatagonian;
        }
    }
}
