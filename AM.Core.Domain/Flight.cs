using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        //Properties
        [ForeignKey("MyPlane")]//esm el prop de navigation
        public int PlaneId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        //Objet plane kol flight andou plane wahda barka 
        //[ForeignKey("PlaneId")]//ou bien hethi wwala illi el fouk Myplane
        public Plane MyPlane { get; set; }
        //Flight contient une liste de passenger 
        public IList<Passenger> Passengers { get; set; }
        public string  Comment { get; set; }

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
