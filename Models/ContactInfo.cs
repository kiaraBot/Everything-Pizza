// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Models/ContactInfo.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * Author: Alix Field
 * Contact: afield@cnm.edu
 */

namespace EverythingPizza.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public string TypeOfRequest { get; set; }
        public bool IsIdea { get; set; }
        public bool IsConcern { get; set; }
    }
}
