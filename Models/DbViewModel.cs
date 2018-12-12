/*  Author: Alix Field
 *  Contact: afield@cnm.edu
 *      This page allows manipulations of database table entities.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverythingPizza.Models
{
    public class DbViewModel
    {
        // List of Pizza Places
        public List<MyPizzaPlaces> MyPizzaPlacesItems { get; set; }

        // List of Comments, or Chats maybe
        public List<CommentDb> CommentDbItems { get; set; }

        // List of Contacts
        public List<ContactInfo> ContactItems { get; set; }
    }
}
