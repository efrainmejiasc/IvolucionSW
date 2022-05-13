using CodeService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeService.Helpers
{
    public class ToolClass
    {
        public static bool  WriteLogReportPatagonian(ResponseReportPatagonian response)
        {
            var resultado = false;
            var lineLog = string.Empty;
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // var pathLog = System.IO.Path.GetDirectoryName(path + @"C:\logFile.txt");
            var pathLog = @"C:\logFile.txt";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathLog, true))
            {
                if(response == null)
                {
                    lineLog = "Fecha: " + DateTime.Now.ToString() + " " + "Proceso: Todos 400 BadRequest " + "Resultado: false";
                    file.WriteLine(lineLog);
                }
                else if (response.message != null)
                {
                    lineLog = "Fecha: " + DateTime.Now.ToString() + " " + "Proceso: Todos ERROR" + "Resultado: " + response.message;
                    file.WriteLine(lineLog);
                }
                else if(response.message == null)
                {
                   
                    foreach (var x in response.data)
                    {
                        lineLog = "Fecha: " + DateTime.Now.ToString() + " " + "Proceso: " + x.process + " " + "Resultado: " + x.result.ToString();
                        file.WriteLine(lineLog);
                    }
                }

                resultado = true;
            }

            return resultado;
        }

        public static bool WriteLogReportPatagonian(string lineLog)
        {
            var resultado = false;
            var pathLog = @"C:\logFile.txt";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathLog, true))
            {
                file.WriteLine(lineLog);
                resultado = true;
            }

            return resultado;
        }
    }
}
