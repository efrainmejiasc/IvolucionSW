using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeService.Helpers
{
    public class EnviromentVar
    {
        private static EnviromentVar valor;

        public static EnviromentVar Instance()
        {
            if ((valor == null))
            {
                valor = new EnviromentVar();
            }
            return valor;
        }

        public static int NumDays = Convert.ToInt32(ConfigurationManager.AppSettings["numDays"]);
        public static int MiliseconDay = Convert.ToInt32(ConfigurationManager.AppSettings["miliseconDay"]);

        public static string ApiKeyIvolucionPruebas = ConfigurationManager.AppSettings["apiKeyIvolucionPruebas"];
        public static string ApiKeyIvolucionPreProduccion = ConfigurationManager.AppSettings["apiKeyIvolucionPreProduccion"];
        public static string ApiKeyIvolucionProduccion = ConfigurationManager.AppSettings["apiKeyIvolucionProduccion"];

        public static bool pruebas = Convert.ToBoolean(ConfigurationManager.AppSettings["pruebas"]);
        public static string UrlReportPatagonianPruebas = ConfigurationManager.AppSettings["urlReportPatagonianPruebas"];
        public static string UrlSubmitNewCLNPruebas = ConfigurationManager.AppSettings["urlSubmitNewCLNPruebas"];
        public static string UrlScheduledVirtualAppointmentsDonePruebas = ConfigurationManager.AppSettings["urlScheduledVirtualAppointmentsDonePruebas"];
        public static string UrlAlertsPruebas = ConfigurationManager.AppSettings["urlAlertsPruebas"];
        public static string UrlOffersPruebas = ConfigurationManager.AppSettings["urlOffersPruebas"];

        public static bool preProduccion = Convert.ToBoolean(ConfigurationManager.AppSettings["preProduccion"]);
        public static string UrlReportPatagonianPreProduccion = ConfigurationManager.AppSettings["urlReportPatagonianPreProduccion"];
        public static string UrlSubmitNewCLNPreProduccion = ConfigurationManager.AppSettings["urlSubmitNewCLNPreProduccion"];
        public static string UrlScheduledVirtualAppointmentsDonePreProduccion = ConfigurationManager.AppSettings["urlScheduledVirtualAppointmentsDonePreProduccion"];
        public static string UrlAlertsPreProduccion = ConfigurationManager.AppSettings["urlAlertsPreProduccion"];
        public static string UrlOffersPreProduccion = ConfigurationManager.AppSettings["urlOffersPreProduccion"];

        public static bool produccion = Convert.ToBoolean(ConfigurationManager.AppSettings["produccion"]);
        public static string UrlReportPatagonianProduccion = ConfigurationManager.AppSettings["urlReportPatagonianProduccion"];
        public static string UrlSubmitNewCLNProduccion = ConfigurationManager.AppSettings["urlSubmitNewCLNProduccion"];
        public static string UrlScheduledVirtualAppointmentsDoneProduccion = ConfigurationManager.AppSettings["urlScheduledVirtualAppointmentsDoneProduccion"];
        public static string UrlAlertsProduccion = ConfigurationManager.AppSettings["urlAlertsProduccion"];
        public static string UrlOffersProduccion = ConfigurationManager.AppSettings["urlOffersProduccion"];

        public static string ExpresionAlerts = ConfigurationManager.AppSettings["expresionAlerts"];
        public static string ExpresionOffers = ConfigurationManager.AppSettings["expresionOffers"];
        public static string ExpresionPatagonian = ConfigurationManager.AppSettings["expresionPatagonian"];
        public static string ExpresionSubmitNewCLN = ConfigurationManager.AppSettings["expresionSubmitNewCLN"];
        public static string ExpresionVirtualAppointments = ConfigurationManager.AppSettings["expresionVirtualAppointments"];
        public static int InitOffers = Convert.ToInt32(ConfigurationManager.AppSettings["initOffers"]);
        public static int EndOffers = Convert.ToInt32(ConfigurationManager.AppSettings["endOffers"]);

        public static string Hours = ConfigurationManager.AppSettings["hours"];
        public static int[]  Hour = {0,1,2,3,4,5,11,12,13,14,15,16,17,18,19,20,21,22,23};

    }
}
