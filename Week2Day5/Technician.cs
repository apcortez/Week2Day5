using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    class Technician : Employee
    {   
        public decimal PayPerHour { get; set; }
        public decimal WorkingHours { get; set; }

        public Technician()
        {

        }
        public Technician(string FiscalCode, string FirstName, string LastName,RoleEnum Role, SectorEnum Sector, Dictionary<string, string> Skills, decimal PayPerHour, decimal WorkingHours)
           : base(FiscalCode, FirstName, LastName, Role, Sector, Skills)
        {

            this.PayPerHour = PayPerHour;
            this.WorkingHours = WorkingHours;
        }
        public Technician(string FiscalCode, string FirstName, string LastName, SectorEnum Sector, Dictionary<string, string> Skills, decimal PayPerHour, decimal WorkingHours)
            :base(FiscalCode, FirstName, LastName, Sector, Skills)
        {
            this.Role = RoleEnum.Technician;
            this.PayPerHour = PayPerHour;
            this.WorkingHours = WorkingHours;
        }

        public override decimal GetSalary()
        {
            return WorkingHours * PayPerHour;
        }
    }
}
