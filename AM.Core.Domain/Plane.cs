using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public enum PlaneType
    {
        BOING,AIRBUS
    }

    public class Plane
    {
        //Properties => declari el variable tek w ya3mlelha get w set teha 
        /* private int capacity;
        public int getCapacity()
        {
            return capacity;
        }
        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }
        */
        public int PlaneId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Capacity doit être un entier positif.")]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType MyPlaneType { get; set; }
        // Relation 1-N : Plane peut avoir plusieurs Flight
        public IList<Flight> Flights { get; set; }

        //Constructor vide
        public Plane()
        {
        }

        //Constructor paramétré
        public Plane(int planeId, int capacity, DateTime manufacturedate, PlaneType pt )
        {
            this.PlaneId = planeId;
            Capacity = capacity;
            ManufactureDate = manufacturedate;
            MyPlaneType = pt;

        }

        public override string ToString()
        {
            return
                $"PlaneId: {PlaneId}, " +
                $"Capacity: {Capacity}, " +
                $"Manufactured: {ManufactureDate.ToShortDateString()}, " +
                $"Plane Type: {MyPlaneType}";
        }




    }

    
}
