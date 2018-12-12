// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Models/Post.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Sharon Goodrich sgoodrich1@cnm.edu

namespace EverythingPizza.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
