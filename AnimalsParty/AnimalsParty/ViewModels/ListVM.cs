﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.ViewModels
{
    public class ListVM
    {
        public string Search { get; set; }

        public string SortOrder { get; set; }

        public Dictionary<string, object> Props { get; set; }
    }
}