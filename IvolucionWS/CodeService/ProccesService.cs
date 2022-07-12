﻿using CodeService.Helpers;
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
        private readonly IRequestScheduledVirtualAppointmentsDone _requestScheduledVirtualAppointmentsDone;

        public ProccesService()
        {
            this._requestReportPatagonian = new RequestReportPatagonian();
            this._requestSubmitNewCLN = new RequestSubmitNewCLN();
            this._requestScheduledVirtualAppointmentsDone = new RequestScheduledVirtualAppointmentsDone();
        }

        public async Task InitProcessServiceAsync()
        {
            if (EnviromentVar.pruebas)
            {
                ToolClass.WriteLogReportPatagonian("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                var result = await this._requestReportPatagonian.ExecuteReportPatagonian(EnviromentVar.UrlReportPatagonianPruebas);
                ToolClass.WriteLogReportPatagonian(result);
                ToolClass.WriteLogReportPatagonian("Final de servicio pruebas: " + DateTime.Now.ToString());
            }

            if (EnviromentVar.preProduccion)
            {
                ToolClass.WriteLogReportPatagonian("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                var result = await this._requestReportPatagonian.ExecuteReportPatagonian(EnviromentVar.UrlReportPatagonianPreProduccion);
                ToolClass.WriteLogReportPatagonian(result);
                ToolClass.WriteLogReportPatagonian("Final de servicio preproduccion: " + DateTime.Now.ToString());
            }

            if (EnviromentVar.produccion)
            {
                ToolClass.WriteLogReportPatagonian("Inicio de servicio produccion: " + DateTime.Now.ToString());
                var result = await this._requestReportPatagonian.ExecuteReportPatagonian(EnviromentVar.UrlReportPatagonianProduccion);
                ToolClass.WriteLogReportPatagonian(result);
                ToolClass.WriteLogReportPatagonian("Final de servicio produccion: " + DateTime.Now.ToString());
            }

        }

        public async Task InitProcessService2Async()
        {
            if (EnviromentVar.pruebas)
            {
                ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN(EnviromentVar.UrlSubmitNewCLNPruebas);
                var linea = result ? "Solicitud SubmitNewCLNContents pruebas EXITOSA " : "Solicitud SubmitNewCLNContents pruebas FALLIDA ";
                ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
                ToolClass.WriteLogSubmitNewCLNContents("Final de servicio pruebas: " + DateTime.Now.ToString());
            }

            if (EnviromentVar.preProduccion)
            {
                ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN(EnviromentVar.UrlSubmitNewCLNPreProduccion);
                var linea = result ? "Solicitud SubmitNewCLNContents EXITOSA preproduccion " : "Solicitud SubmitNewCLNContents FALLIDA preproduccion ";
                ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
                ToolClass.WriteLogSubmitNewCLNContents("Final de servicio: " + DateTime.Now.ToString());
            }

            if (EnviromentVar.produccion)
            {
                ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio produccion: " + DateTime.Now.ToString());
                var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN(EnviromentVar.UrlSubmitNewCLNProduccion);
                var linea = result ? "Solicitud SubmitNewCLNContents EXITOSA produccion " : "Solicitud SubmitNewCLNContents FALLIDA produccion ";
                ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
                ToolClass.WriteLogSubmitNewCLNContents("Final de servicio produccion: " + DateTime.Now.ToString());
            }

        }

        public async Task InitProcessService3Async()
        {
            if (EnviromentVar.pruebas)
            {
                ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                var result = await this._requestScheduledVirtualAppointmentsDone.GetRequestSheduleVirtualAppointmensDone(EnviromentVar.UrlScheduledVirtualAppointmentsDonePruebas);
                var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA pruebas" : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA pruebas ";
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
                ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio pruebas: " + DateTime.Now.ToString());
            }

            if (EnviromentVar.preProduccion)
            {
                ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                var result = await this._requestScheduledVirtualAppointmentsDone.GetRequestSheduleVirtualAppointmensDone(EnviromentVar.UrlScheduledVirtualAppointmentsDonePreProduccion);
                var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA preproduccion " : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA preproduccion ";
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
                ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio preproduccion: " + DateTime.Now.ToString());
            }

            if (EnviromentVar.produccion)
            {
                ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio produccion: " + DateTime.Now.ToString());
                var result = await this._requestScheduledVirtualAppointmentsDone.GetRequestSheduleVirtualAppointmensDone(EnviromentVar.UrlScheduledVirtualAppointmentsDoneProduccion);
                var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA produccion " : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA produccion ";
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
                ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio produccion: " + DateTime.Now.ToString());
            }
            
        }
    }
}
