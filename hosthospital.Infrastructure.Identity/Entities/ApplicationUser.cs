﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosthospital.Infrastructure.Identity.Entities
{
   public class ApplicationUser : IdentityUser
    {
        public string? FirtName { get; set; }    
        public string? LastName { get; set; }
    }   
}
