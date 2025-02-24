using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Staff : Passenger
    {
        //Properties
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }

        [DataType(DataType.Currency,ErrorMessage ="Salaire invalide")]
        public float Salary { get; set; }
        public override string GetPassengerType()
        {
            return base.GetPassengerType() + " I am a Staff Member";
        }

        public override string ToString()
        {
            return base.ToString() +
                    $", Function: {Function}" +
                    $", Employement Date:{EmployementDate}" +
                    $", Salary: {Salary}";
        }


    }
}
