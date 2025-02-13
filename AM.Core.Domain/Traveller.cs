using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Traveller:Passenger // : pour dire "extend" => traveller herite de passenger
    {
        //Properties
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string GetPassengerType()
        {
            return "I am a Traveller";
        }

        public override string ToString()
        {
            return base.ToString() +
                   $", Nationality: {Nationality}" +
                   $", Health Information: {HealthInformation}";
        }
    }
}
