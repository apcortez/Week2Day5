using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    abstract class Employee : Person
    {
        public SectorEnum Sector { get; set; }
        public RoleEnum Role { get; set; }
        public Dictionary<string, string> Skills = new Dictionary<string, string>();

        public Employee()
        {

        }

        public Employee(string FiscalCode, string FirstName, string LastName, SectorEnum Sector)
            :base(FiscalCode, FirstName, LastName)
        {
            this.Sector = Sector;
        }

        public Employee(string FiscalCode, string FirstName, string LastName, SectorEnum Sector, Dictionary<string, string> Skills)
            : base(FiscalCode, FirstName, LastName)
        {
            this.Sector = Sector;
            this.Skills = Skills;
        }

        public Employee(string FiscalCode, string FirstName, string LastName, RoleEnum Role, SectorEnum Sector, Dictionary<string, string> Skills)
           : base(FiscalCode, FirstName, LastName)
        {
            this.Role = Role;
            this.Sector = Sector;
            this.Skills = Skills;
        }

        public abstract decimal GetSalary();
    }

    enum SectorEnum
    {
        Vendite = 1,
        Amministrazione =2,
        Sviluppo =3
    }

    enum RoleEnum
    {
        Stagista = 1,
        Technician = 2,
        Manager = 3
    }
}
