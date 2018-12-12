/*
 *  Author: Alix Field
 *  Contact: afield@cnm.edu
 */

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EverythingPizza.Models;

namespace EverythingPizza.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {    }

        // -------------------------------------------------------------
        // Alix's Databases
            public DbSet<ContactInfo> ContactInfoes { get; set; }
            public DbSet<MyPizzaPlaces> MyPizzaPlaces { get; set; }
        // -------------------------------------------------------------

        //--------------------------------------------------------------
        // Sharon's Databases
            public DbSet<CommentDb> Comments { get; set; }
            public DbSet<Post> Posts { get; set; }
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        // Jonathan's Databases
        //      Seeded the MyPizzaPlaces Data and 
        //      Much More 
        // -------------------------------------------------------------

    }
}
