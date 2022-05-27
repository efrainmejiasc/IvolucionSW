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
#if DEBUG
            var pathLog = System.IO.Path.GetDirectoryName(path);
            pathLog = pathLog + @"\logActivityPatagonian.txt";
#else
            var pathLog = @"C:\logActivityPatagonian.txt.txt";
#endif
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
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
#if DEBUG
            var pathLog = System.IO.Path.GetDirectoryName(path);
            pathLog = pathLog + @"\logActivityPatagonian.txt";
#else
            var pathLog = @"C:\logActivityPatagonian.txt";
#endif

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathLog, true))
            {
                file.WriteLine(lineLog);
                resultado = true;
            }

            return resultado;
        }


        public static bool WriteLogSubmitNewCLNContents(string lineLog)
        {
            var resultado = false;
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
#if DEBUG
            var pathLog = System.IO.Path.GetDirectoryName(path);
            pathLog = pathLog + @"\logActivitySubmitNewCLN.txt";
#else
            var pathLog = @"C:\logActivitySubmitNewCLN.txt";
#endif

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathLog, true))
            {
                file.WriteLine(lineLog);
                resultado = true;
            }

            return resultado;
        }

    }
}

