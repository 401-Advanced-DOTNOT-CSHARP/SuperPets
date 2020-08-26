using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    /// <summary>
    /// The order contains the information required for the final checkout for the user
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
