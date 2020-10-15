using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Models
{
    public class EmployeeCompany
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Employee Employee { get; set; }
    }
}
