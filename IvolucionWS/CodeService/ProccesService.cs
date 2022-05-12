using CodeService.Helpers;
using CodeService.Interfaces;
using CodeService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeService
{
    public class ProccesService
    {
        private readonly IRequestReportPatagonian _requestReportPatagonian;
        public ProccesService()
        {
            this._requestReportPatagonian = new RequestReportPatagonian();
        }

        public async Task InitProcessServiceAsync()
        {
            var result = await this._requestReportPatagonian.ExcuteReportPatagonian();
            ToolClass.WriteLogReportPatagonian(result);
        }
    }
}
