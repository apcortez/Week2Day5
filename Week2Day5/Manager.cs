using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    class Manager : Employee
    {
        public decimal ExtraHours { get; set; }
        public decimal BaseSalary { get; set; }

        public Manager()
        {

        }
        public Manager(string FiscalCode, string FirstName, string LastName, RoleEnum Role, SectorEnum Sector, Dictionary<string, string> Skills, decimal BaseSalary, decimal ExtraHours)
           : base(FiscalCode, FirstName, LastName, Role, Sector, Skills)
        {

            this.BaseSalary = BaseSalary;
            this.ExtraHours = ExtraHours;
        }
        public Manager(string FiscalCode, string FirstName, string LastName, SectorEnum Sector, Dictionary<string, string> Skills, decimal BaseSalary, decimal ExtraHours)
            : base(FiscalCode, FirstName, LastName, Sector, Skills)
        {
            this.Role = RoleEnum.Manager;
            this.BaseSalary = BaseSalary;
            this.ExtraHours = ExtraHours;
        }

        public override decimal GetSalary()
        {
            return BaseSalary + (ExtraHours * 10);
        }
    }
}
