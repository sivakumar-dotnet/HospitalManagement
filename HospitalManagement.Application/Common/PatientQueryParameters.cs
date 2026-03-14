using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Common
{
    public class PatientQueryParameters :PaginationParameters
    {
        public string? Gender { get; set; }
    }
}
