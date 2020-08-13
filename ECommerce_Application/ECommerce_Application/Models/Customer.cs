using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public static class ApplicationRoles
    {
        public const string Administrator = "Administrator";

    }
}
