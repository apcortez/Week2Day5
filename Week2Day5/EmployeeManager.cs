using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    class EmployeeManager
    {   
        //prepopolo la lista employees con 1 tecnico, 1 stagista, 1 manager

        static Technician p1 = new Technician()
        {
            FiscalCode = "T123",
            FirstName = "Pippo",
            LastName = "Nero",
            Sector = SectorEnum.Sviluppo,
            Role = RoleEnum.Technician,
            PayPerHour = 8.50m,
            WorkingHours = 200,
            Skills = new Dictionary<string, string>()
            {
                { "MYSQL", "Database, DBMS, RDBMS" },
                { "JAVA", "OOP Programming Language" },
                { ".NET", "Framework" },
                { "C#", "OOP Programming Language" },

            }
        };

        static Intern p2= new Intern()
        {
            FiscalCode = "I123",
            FirstName = "Pluto",
            LastName = "Rossi",
            Sector = SectorEnum.Vendite,
            Role = RoleEnum.Stagista,
            ContractPeriod = 6,
            Skills = new Dictionary<string, string>()
            {
                { "Calculation", "Calculation Descpription" },
                { "Accounting", "Economics Descrption" },
                { "C#", "OOP Programming Language" },

            }
        };

        static Manager p3 = new Manager()
        {
            FiscalCode = "M123",
            FirstName = "Pape",
            LastName = "Verdi",
            Sector = SectorEnum.Amministrazione,
            Role = RoleEnum.Manager,
            BaseSalary = 2500,
            ExtraHours = 15,
            Skills = new Dictionary<string, string>()
            {
                { "Management", "Management Descpription" },
                { "Leadership", "Leadership Descrption" },

            }
        };

        
        static List<Person> employees = new List<Person>
        {
            {p1} , {p2}, {p3}
        };

        internal static void ViewAllEmployees()
        {
            Console.WriteLine("NOME \t\t COGNOME \t\t SETTORE \t\t\t RUOLO \t\t\t\t STIPENDIO");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} \t\t {employee.LastName} \t\t\t {employee.Sector} \t\t\t { employee.Role} \t\t\t { employee.GetSalary()}");
            }
        }

        internal static void ViewBySector(int choosenSector)
        {
            
            Console.WriteLine("NOME \t\t COGNOME \t\t SETTORE \t\t\t RUOLO \t\t\t\t STIPENDIO");
            foreach (Employee employee in employees)
            {
                if ((int)employee.Sector == choosenSector)
                {
                    Console.WriteLine($"{employee.FirstName} \t\t {employee.LastName} \t\t\t {employee.Sector} \t\t\t { employee.Role} \t\t\t { employee.GetSalary()}");
                }
            }
        }

        internal static void ViewBySkill(string skill)
        {

            Console.WriteLine("NOME \t\t COGNOME \t\t SETTORE \t\t STIPENDIO ");
            foreach (Employee employee in employees)
            {
                if (employee.Skills.ContainsKey(skill))
                {
                    Console.WriteLine($"{employee.FirstName} \t\t {employee.LastName} \t\t\t {employee.Sector} \t\t\t { employee.GetSalary()}");
                }
            }
        }

        internal static void ViewBySalary(decimal filterSalary)
        {
            Console.WriteLine("NOME \t\t COGNOME \t\t SETTORE \t\t\t RUOLO \t\t\t\t STIPENDIO");
            foreach (Employee employee in employees)
            {
                if (employee.GetSalary() >=  filterSalary)
                {
                    Console.WriteLine($"{employee.FirstName} \t\t {employee.LastName} \t\t\t {employee.Sector} \t\t\t { employee.Role} \t\t\t { employee.GetSalary()}");
                }
            }
        }

        internal static void removeEmployee(Employee employeeToFind)
        {
            employees.Remove(employeeToFind);
            Console.WriteLine($"L'impiegato '{employeeToFind.FirstName}' '{employeeToFind.LastName}' con codice fiscale '{employeeToFind.FiscalCode}' è stato rimosso con successo!\n");
        }

        internal static Employee GetByFiscalCode(string fiscalCode)
        {
            foreach (Employee employee in employees)
            {
                if (employee.FiscalCode == fiscalCode)
                {
                    return employee;
                }
            }
            return null;
        }

        internal static void addEmployee(string fiscalCode, string firstName, string lastName, int role, int sector)
        {
            Dictionary<string, string> skills = new Dictionary<string, string>();
            Employee employee = null;
            switch (role)
            {
                case 1:
                    //inizializzato che uno stagista ha un contratto di base iniziale di 6 mesi
                    employee = new Intern(fiscalCode, firstName, lastName, (RoleEnum)role,(SectorEnum)sector, skills, 6);
                    break;
                case 2:
                    //inizializzato che un tecnico iniziale abbia una paga di 8euro all'ora
                    employee = new Technician(fiscalCode, firstName, lastName, (RoleEnum)role,(SectorEnum)sector, skills, 8, 0);
                    break;
                case 3:
                    //inizializzato che un manager abbia un salario di base di 2000euro
                    employee = new Manager(fiscalCode, firstName, lastName, (RoleEnum)role, (SectorEnum)sector, skills, 2000, 0);
                    break;

            }

            employees.Add(employee);
            Console.WriteLine($"L'impiegato '{firstName}' '{lastName}' con codice fiscale '{fiscalCode}' è stato aggiunto con successo\n");
        }
    }
}
