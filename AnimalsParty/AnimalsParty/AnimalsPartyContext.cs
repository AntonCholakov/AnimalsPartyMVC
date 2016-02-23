﻿using System;
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

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}