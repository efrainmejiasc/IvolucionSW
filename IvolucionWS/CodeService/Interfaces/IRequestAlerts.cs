using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeService.Interfaces
{
    public interface IRequestAlerts
    {
        Task<bool> GetRequestAlerts(string url, string apiKey);
    }
}
