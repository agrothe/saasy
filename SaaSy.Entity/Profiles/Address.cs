using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Profiles
{
    public class Address
    {
        public long AddressId { get; set; }
        public string AddressText { get; set; }

        // TODO: expand fields if necessary, keeping simaple
        // as text to handle international addresses
    }
}
