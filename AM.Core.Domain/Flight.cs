using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        //Properties
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        //Objet plane kol flight andou plane wahda barka 
        public Plane MyPlane { get; set; }
        //Flight contient une liste de passenger 
        public IList<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return
                $"Flight Id: {FlightId}, " +
                $"Departure: {Departure}, " +
                $"Flight to {Destination}, " +
                $"Flight Date: {FlightDate}, " +
                $"Effective Arrival: {EffectiveArrival}, " +
                $"Estimated Duration: {EstimatedDuration}, " +
                $"MyPlane: {MyPlane.ToString()}";
              
        }
    }
}
