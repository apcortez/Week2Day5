using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    class Intern : Employee
    {
        public int ContractPeriod { get; set; }

        public Intern()
        {

        }
        public Intern(string FiscalCode, string FirstName, string LastName, RoleEnum Role, SectorEnum Sector, Dictionary<string, string> Skills, int ContractPeriod)
           : base(FiscalCode, FirstName, LastName, Role, Sector, Skills)
        {
            this.ContractPeriod = ContractPeriod;
        }

        public Intern(string FiscalCode, string FirstName, string LastName, SectorEnum Sector, Dictionary<string, string> Skills, int ContractPeriod)
            : base(FiscalCode, FirstName, LastName, Sector, Skills)
        {
            this.Role = RoleEnum.Stagista;
            this.ContractPeriod = ContractPeriod;
        }

        public override decimal GetSalary()
        {
            return 600;
        }
    }
}
