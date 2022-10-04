using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Employee
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age{ get; set; }
        public virtual decimal Salary { get; set; }
    }
}
