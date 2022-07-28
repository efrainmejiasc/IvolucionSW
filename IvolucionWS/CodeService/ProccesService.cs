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
        private readonly IRequestScheduledVirtualAppointmentsDone _requestScheduledVirtualAppointmentsDone;
        private readonly IRequestAlerts _requestAlerts;
        private readonly IRequestOffers _requestOffers;


        public ProccesService()
        {
            this._requestReportPatagonian = new RequestReportPatagonian();
            this._requestSubmitNewCLN = new RequestSubmitNewCLN();
            this._requestScheduledVirtualAppointmentsDone = new RequestScheduledVirtualAppointmentsDone();
            this._requestAlerts = new RequestAlerts();
            this._requestOffers = new RequestOffers();
        }

        public async Task InitProcessServiceAsync()
        {
            try
            {
                if (EnviromentVar.pruebas)
                {
                    ToolClass.WriteLogReportPatagonian("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                    var result = await this._requestReportPatagonian.ExecuteReportPatagonian(EnviromentVar.UrlReportPatagonianPruebas,EnviromentVar.ApiKeyIvolucionPruebas);
                    ToolClass.WriteLogReportPatagonian(result);
                    ToolClass.WriteLogReportPatagonian("Final de servicio pruebas: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.preProduccion)
                {
                    ToolClass.WriteLogReportPatagonian("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                    var result = await this._requestReportPatagonian.ExecuteReportPatagonian(EnviromentVar.UrlReportPatagonianPreProduccion, EnviromentVar.ApiKeyIvolucionPreProduccion);
                    ToolClass.WriteLogReportPatagonian(result);
                    ToolClass.WriteLogReportPatagonian("Final de servicio preproduccion: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.produccion)
                {
                    ToolClass.WriteLogReportPatagonian("Inicio de servicio produccion: " + DateTime.Now.ToString());
                    var result = await this._requestReportPatagonian.ExecuteReportPatagonian(EnviromentVar.UrlReportPatagonianProduccion, EnviromentVar.ApiKeyIvolucionProduccion);
                    ToolClass.WriteLogReportPatagonian(result);
                    ToolClass.WriteLogReportPatagonian("Final de servicio produccion: " + DateTime.Now.ToString());
                }
            }
            catch(Exception ex)
            {
                ToolClass.WriteLogReportPatagonian(ex.Message);
            }

        }

        public async Task InitProcessService2Async()
        {
            try
            {
                if (EnviromentVar.pruebas)
                {
                    ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                    var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN(EnviromentVar.UrlSubmitNewCLNPruebas, EnviromentVar.ApiKeyIvolucionPruebas);
                    var linea = result ? "Solicitud SubmitNewCLNContents pruebas EXITOSA " : "Solicitud SubmitNewCLNContents pruebas FALLIDA ";
                    ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogSubmitNewCLNContents("Final de servicio pruebas: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.preProduccion)
                {
                    ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                    var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN(EnviromentVar.UrlSubmitNewCLNPreProduccion, EnviromentVar.ApiKeyIvolucionPreProduccion);
                    var linea = result ? "Solicitud SubmitNewCLNContents EXITOSA preproduccion " : "Solicitud SubmitNewCLNContents FALLIDA preproduccion ";
                    ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogSubmitNewCLNContents("Final de servicio: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.produccion)
                {
                    ToolClass.WriteLogSubmitNewCLNContents("Inicio de servicio produccion: " + DateTime.Now.ToString());
                    var result = await this._requestSubmitNewCLN.GetRequestSubmitNewCLN(EnviromentVar.UrlSubmitNewCLNProduccion, EnviromentVar.ApiKeyIvolucionProduccion);
                    var linea = result ? "Solicitud SubmitNewCLNContents EXITOSA produccion " : "Solicitud SubmitNewCLNContents FALLIDA produccion ";
                    ToolClass.WriteLogSubmitNewCLNContents(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogSubmitNewCLNContents("Final de servicio produccion: " + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                ToolClass.WriteLogSubmitNewCLNContents(ex.Message);
            }
        }

        public async Task InitProcessService3Async()
        {
            try
            {
                if (EnviromentVar.pruebas)
                {
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                    var result = await this._requestScheduledVirtualAppointmentsDone.GetRequestSheduleVirtualAppointmensDone(EnviromentVar.UrlScheduledVirtualAppointmentsDonePruebas, EnviromentVar.ApiKeyIvolucionPruebas);
                    var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA pruebas" : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA pruebas ";
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio pruebas: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.preProduccion)
                {
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                    var result = await this._requestScheduledVirtualAppointmentsDone.GetRequestSheduleVirtualAppointmensDone(EnviromentVar.UrlScheduledVirtualAppointmentsDonePreProduccion, EnviromentVar.ApiKeyIvolucionPreProduccion);
                    var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA preproduccion " : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA preproduccion ";
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio preproduccion: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.produccion)
                {
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone("Inicio de servicio produccion: " + DateTime.Now.ToString());
                    var result = await this._requestScheduledVirtualAppointmentsDone.GetRequestSheduleVirtualAppointmensDone(EnviromentVar.UrlScheduledVirtualAppointmentsDoneProduccion, EnviromentVar.ApiKeyIvolucionProduccion);
                    var linea = result ? "Solicitud Citas de Negocios Virtuales Realizadas EXITOSA produccion " : "Solicitud Citas de Negocios Virtuales Realizadas FALLIDA produccion ";
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogScheduledVirtualAppointmentsDone("Final de servicio produccion: " + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(ex.Message);
            }

        }


        public async Task InitProcessService4Async()
        {
            try
            {
                if (EnviromentVar.pruebas)
                {
                    ToolClass.WriteLogAlerts("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                    var result = await this._requestAlerts.GetRequestAlerts(EnviromentVar.UrlAlertsPruebas, EnviromentVar.ApiKeyIvolucionPruebas);
                    var linea = result ? "Envio de alertas EXITOSA pruebas" : "Envio de alertas Realizadas FALLIDA pruebas ";
                    ToolClass.WriteLogAlerts(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogAlerts("Final de servicio pruebas: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.preProduccion)
                {
                    ToolClass.WriteLogAlerts("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                    var result = await this._requestAlerts.GetRequestAlerts(EnviromentVar.UrlAlertsPreProduccion, EnviromentVar.ApiKeyIvolucionPreProduccion);
                    var linea = result ? "Envio de alertas EXITOSA preproduccion " : "Envio de alertas FALLIDA preproduccion ";
                    ToolClass.WriteLogAlerts(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogAlerts("Final de servicio preproduccion: " + DateTime.Now.ToString());
                }

                if (EnviromentVar.produccion)
                {
                    ToolClass.WriteLogAlerts("Inicio de servicio produccion: " + DateTime.Now.ToString());
                    var result = await this._requestAlerts.GetRequestAlerts(EnviromentVar.UrlAlertsProduccion, EnviromentVar.ApiKeyIvolucionProduccion);
                    var linea = result ? "Envio de alertas EXITOSA produccion " : "Envio de alertas FALLIDA produccion ";
                    ToolClass.WriteLogAlerts(linea + DateTime.Now.ToString());
                    ToolClass.WriteLogAlerts("Final de servicio produccion: " + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                ToolClass.WriteLogAlerts(ex.Message);
            }

        }

        public async Task InitProcessService5Async()
        {
            try
            {
                var currentHour = DateTime.UtcNow.Hour.ToString();
                var lstHour = EnviromentVar.Hours;
                if (lstHour.Contains(currentHour))
                {
                    if (EnviromentVar.pruebas)
                    {
                        ToolClass.WriteLogOffers("Inicio de servicio pruebas: " + DateTime.Now.ToString());
                        var result = await this._requestOffers.GetRequestOffers(EnviromentVar.UrlOffersPruebas, EnviromentVar.ApiKeyIvolucionPruebas);
                        var linea = result ? "Envio de ofertas EXITOSA pruebas" : "Envio de ofertas FALLIDA pruebas ";
                        ToolClass.WriteLogOffers(linea + DateTime.Now.ToString());
                        ToolClass.WriteLogOffers("Final de servicio pruebas: " + DateTime.Now.ToString());
                    }

                    if (EnviromentVar.preProduccion)
                    {
                        ToolClass.WriteLogOffers("Inicio de servicio preproduccion: " + DateTime.Now.ToString());
                        var result = await this._requestOffers.GetRequestOffers(EnviromentVar.UrlOffersPreProduccion, EnviromentVar.ApiKeyIvolucionPreProduccion);
                        var linea = result ? "Envio de ofertas EXITOSA preproduccion " : "Envio de ofertas FALLIDA preproduccion ";
                        ToolClass.WriteLogOffers(linea + DateTime.Now.ToString());
                        ToolClass.WriteLogOffers("Final de servicio preproduccion: " + DateTime.Now.ToString());
                    }

                    if (EnviromentVar.produccion)
                    {
                        ToolClass.WriteLogOffers("Inicio de servicio produccion: " + DateTime.Now.ToString());
                        var result = await this._requestOffers.GetRequestOffers(EnviromentVar.UrlOffersProduccion, EnviromentVar.ApiKeyIvolucionProduccion);
                        var linea = result ? "Envio de ofertas EXITOSA produccion " : "Envio de ofertas FALLIDA produccion ";
                        ToolClass.WriteLogOffers(linea + DateTime.Now.ToString());
                        ToolClass.WriteLogOffers("Final de servicio produccion: " + DateTime.Now.ToString());
                    }
                }
                else
                {
                    ToolClass.WriteLogOffers("Este servicio se ejecuta solo entre " + EnviromentVar.InitOffers + " HORA UTC y " + EnviromentVar.EndOffers + " HORA UTC ");
                }
            }
            catch (Exception ex)
            {
                ToolClass.WriteLogOffers(ex.Message);

            }

        }
    }
}
