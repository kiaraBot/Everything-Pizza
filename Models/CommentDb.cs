// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Models/CommentDb.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverythingPizza.Models
{
    public class CommentDb
    {
        // Primary Key
        public int CommentDbID { get; set; }
        public string Comment { get; set; }
    }
}
