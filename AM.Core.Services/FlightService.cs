﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;


namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }
        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> result = new List<DateTime>();

            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                    result.Add(flight.FlightDate);

            }
            return result;


        }
        public IList<DateTime> GetFlightDatesLINQ(string dest)
        {
            // methode 1 Requete linq intégré 
            return (from flight in Flights
                    where flight.Destination == dest
                    select flight.FlightDate).ToList();

            //Methode 2 Fonction avancé de linq 
            /*return Flights.Where(f=>f.Destination == dest)
                         .Select (f=>f.FlightDate)
                         .ToList();*/

        }
        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            IList<Flight> result1 = new List<Flight>();
            //Methode 1 
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (filterValue == flight.Destination)
                            result1.Add(flight);
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (filterValue == flight.Departure)
                            result1.Add(flight);
                    }
                    break;
                case "FlightId":
                    foreach (var flight in Flights)
                    {
                        if (filterValue.Equals(flight.FlightId.ToString()))
                            result1.Add(flight);
                    }
                    break;
                case "FilghtsDate":
                    foreach (var flight in Flights)
                    {
                        if (filterValue.Equals(flight.FlightDate.ToString()))
                            result1.Add(flight);
                    }
                    break;
                case "EstimationDuration":
                    foreach (var flight in Flights)
                    {
                        if (filterValue.Equals(flight.EstimatedDuration.ToString()))
                            result1.Add(flight);
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (filterValue.Equals(flight.EffectiveArrival.ToString()))
                            result1.Add(flight);
                    }
                    break;
                default:
                    return result1;
            }
            return result1;
            //Methode 2 
            /* foreach (var flight in Flights)
            {
                if(typeof(Flight).GetProperty(filterType).GetValue(flight).ToString() == filterValue)
                    result1.Add(flight);
            }
            return result1;
            */
        }
        public void ShowFlightDetails(Plane plane)
        {
            var flights = Flights.Where(f => f.MyPlane.PlaneId == plane.PlaneId)
                                //.Select(f => (f.FlightDate , f.Destination)); // Console.WriteLine(flights);
                                .Select(f => new { f.FlightDate, f.Destination });
            foreach (var flight in flights)
            {
                Console.WriteLine($"Date {flight.FlightDate},Destination: {flight.Destination}");
            }

        }
        public int GetWeeklyFlightNumber(DateTime date)
        {
            return Flights
                .Where(f => f.FlightDate >= date &&
                            f.FlightDate < date.AddDays(7))
                 .Count();

        }
        public double GetDurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                             .Average(f => f.EstimatedDuration);

        }
        public IList<Flight> SortFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();

        }

        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>()
                                    .OrderBy(p => p.BirthDate) //Order by par defaut acend
                                    .Take(3)
                                    .ToList<Passenger>();
        }

        public void ShowGroupedFlights()
        {
            //IEnumerable<IGrouping<string,Flight>> req = Flights.GroupBy(f => f.Destination); //IEnumerable<IGrouping<string,Flight>> hethi el kol najem nawthouda b var tout simplement 
            var req = Flights.GroupBy(f => f.Destination); 
            foreach (var g in req)
            {
                Console.WriteLine("Destination:"+ g.Key);
                foreach (Flight flight in g)
                {
                    Console.WriteLine("les vols:"  + flight.ToString());
                }
            }
        }
    }
}
