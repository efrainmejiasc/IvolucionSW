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
        private readonly IRequestSubmitNewCLN _requestSubmitNewCLN;

        public ProccesService()
        {
            this._requestReportPatagonian = new RequestReportPatagonian();
            this._requestSubmitNewCLN = new RequestSubmitNewCLN();
        }

        public async Task InitProcessServiceAsync()
        {
            ToolClass.WriteLogReportPatagonian("Inicio de servicio: " + DateTime.Now.ToString());
            var result = await this._requestReportPatagonian.ExcuteReportPatagonian();
            ToolClass.WriteLogReportPatagonian(result);
            ToolClass.WriteLogReportPatagonian("Final de servicio: " + DateTime.Now.ToString());
        }

        public async Task InitProcessService2Async()
        {
            ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio: " + DateTime.Now.ToString());
            var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN();
            var linea = result ? "Solicitud SubmitNewCLNContents EXITOSA " : "Solicitud SubmitNewCLNContents FALLIDA ";
            ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
            ToolClass.WriteLogSubmitNewCLNContents("Final de servicio: " + DateTime.Now.ToString());
        }

        public async Task InitProcessService3Async()
        {
            ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio: " + DateTime.Now.ToString());
            var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN();
            var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA " : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA ";
            ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
            ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio: " + DateTime.Now.ToString());
        }
    }
}
