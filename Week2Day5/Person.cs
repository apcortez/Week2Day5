using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day5
{
    abstract class Person
    {
        public string FiscalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        
        public Person() { }

        public Person(string FiscalCode, string FirstName, string LastName)
        {
            this.FiscalCode = FiscalCode;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }

}
