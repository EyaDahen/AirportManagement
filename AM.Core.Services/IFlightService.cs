﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;

namespace AM.Core.Services
{
    public interface IFlightService
    {
        IList<DateTime> GetFlightDates(string destination);
        IList<Flight> GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);

    }
}
