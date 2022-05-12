using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeService.Models
{
    public class ResponseReportPatagonian
    {
        public bool succeeded { get; set; }
        public object message { get; set; }
        public object errors { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public string process { get; set; }
        public bool result { get; set; }
    }
}
