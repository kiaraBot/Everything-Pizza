/*
 * Author: Alix Field & Jonathan McPeak
 * Contact: 
 *      afield@cnm.edu
 *      jmcpeak@cnm.edu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverythingPizza.Models
{
    public class MyPizzaPlaces
    {        
        // Primary Key
        public int MyPizzaPlacesId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
        public double Phone { get; set; }
        public int Votes { get; set; }
        public int TotalVotes { get; set; }
        public string Slogan { get; set; }
        public string Menu { get; set; }
    }
}
