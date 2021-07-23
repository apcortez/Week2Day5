using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    class Menu
    {
        internal static void Start()
        {
            int scelta;

            do
            {
                Console.WriteLine("Benvenuto! Scegli l'operazione da fare:");
                Console.WriteLine("1 - Visualizza tutti gli impiegati");
                Console.WriteLine("2 - Visualizza impiegati di un settore");
                Console.WriteLine("3 - Inserisci nuovo impiegato");
                Console.WriteLine("4 - Elimina un impiegato");
                Console.WriteLine("5 - Visualizza impiegati per stipendio");
                Console.WriteLine("6 - Visualizza impiegati per skill");
                Console.WriteLine("0 - Per uscire");
                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 6)
                {
                    Console.WriteLine("Inserisci un'operazone valida. Riprova: ");
                }
                switch (scelta)
                {
                    case 1:
                        EmployeeManager.ViewAllEmployees();
                        break;
                    case 2:
                        ViewEmployeesBySector();
                        break;
                    case 3:
                        InsertEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        ViewEmployeesBySalary();
                        break;
                    case 6:
                        ViewEmployeesBySkill();
                        break;
                    case 0:
                        break;
                }
                Console.WriteLine("\n");
            } while (scelta != 0);
        }

        private static void ViewEmployeesBySkill()
        {
            string skill;
            do
            {
                Console.WriteLine("Inserisci lo skill da filtrare ");
                skill = Console.ReadLine();
            } while (skill.Length < 1);

            EmployeeManager.ViewBySkill(skill);
        }

        private static void ViewEmployeesBySalary()
        {
            decimal filterSalary;
            Console.WriteLine("Inserire il salario di base da filtrare:");
            while (!decimal.TryParse(Console.ReadLine(), out filterSalary) || filterSalary < 0)
            {
                Console.WriteLine("Devi inserire un importo valido. Riprova: ");
            }

            EmployeeManager.ViewBySalary(filterSalary);


        }

        private static void DeleteEmployee()
        {
            string fiscalCode;
            do
            {
                Console.WriteLine("Inserisci il codice fiscale dell'impiegato da eliminare: ");
                fiscalCode = Console.ReadLine();
            } while (fiscalCode.Length < 0);
            Employee employeeToFind = EmployeeManager.GetByFiscalCode(fiscalCode);
            if (employeeToFind != null)
            {
                EmployeeManager.removeEmployee(employeeToFind);
            }
            else
            {
                Console.WriteLine("Impiegato non trovato.");
            }
        }

        private static void InsertEmployee()
        {
            string fiscalCode, firstName, lastName;
            int role, sector;
            do
            {
                Console.WriteLine("Inserisci il codice fiscale del nuovo impiegato: ");
                fiscalCode = Console.ReadLine();
            } while (fiscalCode.Length < 1); //codice fiscale di solito ha 16 cifre quindi la condizione dovrebbe essere fiscalCode.Length != 16.
                                             //ho scelto <1 per velocizzare la ricerca inserendo un fiscalCode abbreviato

            //se esista già un impiegato con un codice lo segnalo
            //altrimenti lo inserisco
            Employee employeeToFind = EmployeeManager.GetByFiscalCode(fiscalCode);
            if (employeeToFind == null)
            {
                //inserire nome
                do
                {
                    Console.WriteLine("Inserisci il nome: ");
                    firstName = Console.ReadLine();

                } while (firstName.Length == 0);

                //inserire cognome
                do
                {
                    Console.WriteLine("Inserisci il cognome: ");
                    lastName = Console.ReadLine();

                } while (lastName.Length == 0);
                do
                {
                    Console.WriteLine("Inserisci il numero del ruolo del nuovo impiegato: ");
                    Console.WriteLine((int)RoleEnum.Stagista + " - " + RoleEnum.Stagista);
                    Console.WriteLine((int)RoleEnum.Technician + " - " + RoleEnum.Technician);
                    Console.WriteLine((int)RoleEnum.Manager + " - " + RoleEnum.Manager);
                } while (!int.TryParse(Console.ReadLine(), out role) || role < 0 || role > 3);

                do
                {
                    Console.WriteLine("Inserisci il numero del settore del nuovo impiegato: ");
                    Console.WriteLine((int)SectorEnum.Vendite + " - " + SectorEnum.Vendite);
                    Console.WriteLine((int)SectorEnum.Amministrazione + " - " + SectorEnum.Amministrazione);
                    Console.WriteLine((int)SectorEnum.Sviluppo + " - " + SectorEnum.Sviluppo);
                } while (!int.TryParse(Console.ReadLine(), out sector) || sector < 0 || sector > 3);

                //AddSkills(fiscalCode);

                EmployeeManager.addEmployee(fiscalCode, firstName, lastName, role, sector);
             }
             else
             {
                    Console.WriteLine("Mi dispiace. La persona che stai inserendo è già inserito nel sistema.");
             }
        }

        private static void AddSkills(string fiscalCode)
        {
            throw new NotImplementedException();
        }

        private static void ViewEmployeesBySector()
        {
            int choosenSector;
            do
            {
                Console.WriteLine("Inserisci il numero di settore da filtrare: ");
                Console.WriteLine((int)SectorEnum.Vendite + " - " + SectorEnum.Vendite);
                Console.WriteLine((int)SectorEnum.Amministrazione + " - " + SectorEnum.Amministrazione);
                Console.WriteLine((int)SectorEnum.Sviluppo + " - " + SectorEnum.Sviluppo);
            } while (!int.TryParse(Console.ReadLine(), out choosenSector) || choosenSector < 0 || choosenSector > 3);

            EmployeeManager.ViewBySector(choosenSector);
        }
    }
}
