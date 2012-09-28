using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRSTest.Models.ReadModel
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerSummary
    {
        [Key]
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }
    }
}