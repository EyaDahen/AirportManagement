// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Reflection;
using AM.Core.Domain;
using Plane = AM.Core.Domain.Plane;
using AM.Data;

Console.WriteLine("Hello, World!");

/***** Plane *****/
        //Constructor par défaut 
        Plane plane1 = new Plane();
        plane1.PlaneId = 1;
        plane1.Capacity = 300;
        plane1.ManufactureDate = new DateTime(2025, 01, 27);
        plane1.MyPlaneType = PlaneType.BOING;
        Console.WriteLine(plane1);

        //Constructeur Paramétré 
        Plane plane2 = new Plane(2,200,DateTime.Now,PlaneType.AIRBUS);
        Console.WriteLine(plane2);

        //Initialiseurs d’objet 
        Plane plane3 = new Plane
        {
            PlaneId = 3,
            Capacity = 100,
            ManufactureDate = new DateTime(2025, 1, 24),
            MyPlaneType = PlaneType.AIRBUS,
        };
        Console.WriteLine(plane3);

/***** Passenger *****/

        Passenger passenger1 = new Passenger { 
                FirstName = "Eya",
                LastName = "Dahen", 
                EmailAddress = "eya.dahen@esprit.tn", 
                BirthDate = new DateTime(2002,5,25) ,
                TelNumber = "50898328", 
                PassportNumber = "FC7453D"
        };
        Staff staff1 = new Staff { 
                FirstName = "Mayssa",
                LastName = "Jdidi",
                EmailAddress = "mayssa.jdidi@esprit.tn",
                BirthDate = new DateTime(2000,7,31),
                TelNumber= "21208911",
                PassportNumber ="TU7643D",

                Function = "Pilot" 
        };
        Traveller traveller1 = new Traveller { 
                FirstName = "Hedi", 
                LastName = "Bouden",
                EmailAddress= "Hedi.bouden@esprit.tn",
                BirthDate= new DateTime(1999,4,25) ,
                TelNumber = "71717171",
                PassportNumber = "FC7463T" ,

                Nationality = "Tunisian"
        };
        Console.WriteLine(traveller1);

        Console.WriteLine(passenger1.GetPassengerType()); // "I am a passenger"
        Console.WriteLine(staff1.GetPassengerType()); // "I am a passenger I am a Staff Member"
        Console.WriteLine(traveller1.GetPassengerType()); // "I am a Traveller"

        //Test de la deuxieme methode 
        Console.WriteLine(passenger1.GetPassengerType2()); // "I am a passenger"
        Console.WriteLine(staff1.GetPassengerType2()); // "I am a passenger I am a Staff Member"
        Console.WriteLine(traveller1.GetPassengerType2()); // "I am a Traveller"

        //Methode 1 tekbel date de naissance w elle stcoke lomer fi age 
        int age = 0 ;
        passenger1.GetAge(passenger1.BirthDate, ref age);
        Console.WriteLine(age);

        //Methode 2 
        passenger1.GetAge(passenger1);
        Console.WriteLine(passenger1.Age);


        Plane plane4 = new Plane
        {
            Capacity = 100,
            ManufactureDate = new DateTime(2025, 1, 24),
            MyPlaneType = PlaneType.AIRBUS,
        };

        Flight flight = new Flight()
        {
            Destination = "Tunis",
            Departure = "Paris",
            FlightDate = new DateTime(2025, 1, 24),
            EffectiveArrival = new DateTime(2025, 1, 24),
            EstimatedDuration = 3,
            MyPlane = plane4,
            Comment = "This is a comment"
        };
        AMContext context = new AMContext();
        context.Flights.Add(flight);
        context.SaveChanges();