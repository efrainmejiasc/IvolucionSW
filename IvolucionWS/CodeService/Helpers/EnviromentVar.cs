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

        public static string UrlReportPatagonian = ConfigurationManager.AppSettings["urlReportPatagonian"];
        public static int NumDays = Convert.ToInt32(ConfigurationManager.AppSettings["numDays"]);
        public static int MiliseconDay = Convert.ToInt32(ConfigurationManager.AppSettings["miliseconDay "]);
    }
}
