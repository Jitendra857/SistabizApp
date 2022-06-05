using System;
using System.Collections.Generic;

namespace SistabizApp_New.Models
{
    public partial class TblBillingAddress
    {
        public long BillingAddressId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public long? PaymentId { get; set; }

        public virtual TblUserSubscription Payment { get; set; }
    }
}
