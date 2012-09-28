using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRSTest.Models.ReadModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// </summary>
    public class CustomerSummaryWebUpdate
    {
        public long Id { get; set; }

        public string Json { get; set; }
    }
}