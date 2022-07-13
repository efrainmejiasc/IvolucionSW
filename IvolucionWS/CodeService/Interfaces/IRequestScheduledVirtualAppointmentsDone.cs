using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeService.Interfaces
{
    public interface IRequestScheduledVirtualAppointmentsDone
    {
        Task<bool> GetRequestSheduleVirtualAppointmensDone(string url);
    }
}
