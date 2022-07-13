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

        public static string ApiKeyIvolucion = ConfigurationManager.AppSettings["apiKeyIvolucion"];

        public static bool pruebas = Convert.ToBoolean(ConfigurationManager.AppSettings["pruebas"]);
        public static string UrlReportPatagonianPruebas = ConfigurationManager.AppSettings["urlReportPatagonianPruebas"];
        public static string UrlSubmitNewCLNPruebas = ConfigurationManager.AppSettings["urlSubmitNewCLNPruebas"];
        public static string UrlScheduledVirtualAppointmentsDonePruebas = ConfigurationManager.AppSettings["urlScheduledVirtualAppointmentsDonePruebas"];

        public static bool preProduccion = Convert.ToBoolean(ConfigurationManager.AppSettings["preProduccion"]);
        public static string UrlReportPatagonianPreProduccion = ConfigurationManager.AppSettings["urlReportPatagonianPreProduccion"];
        public static string UrlSubmitNewCLNPreProduccion = ConfigurationManager.AppSettings["urlSubmitNewCLNPreProduccion"];
        public static string UrlScheduledVirtualAppointmentsDonePreProduccion = ConfigurationManager.AppSettings["urlScheduledVirtualAppointmentsDonePreProduccion"];

        public static bool produccion = Convert.ToBoolean(ConfigurationManager.AppSettings["produccion"]);
        public static string UrlReportPatagonianProduccion = ConfigurationManager.AppSettings["urlReportPatagonianProduccion"];
        public static string UrlSubmitNewCLNProduccion = ConfigurationManager.AppSettings["urlSubmitNewCLNProduccion"];
        public static string UrlScheduledVirtualAppointmentsDoneProduccion = ConfigurationManager.AppSettings["urlScheduledVirtualAppointmentsDoneProduccion"];

    }
}
