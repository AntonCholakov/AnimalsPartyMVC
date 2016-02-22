using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AnimalsParty.Models;

namespace AnimalsParty
{
    public class AnimalsPartyContext : DbContext
    {
        public AnimalsPartyContext() : base("AnimalsPartyDB") { }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}