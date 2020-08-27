using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    /// <summary>
    /// Customer class references the Micorosoft Built In Identity User
    /// </summary>
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

    }

    /// <summary>
    /// Application Roles to set a policy the Administrator
    /// </summary>
    public static class ApplicationRoles
    {
        public const string Administrator = "Administrator";

    }
}
