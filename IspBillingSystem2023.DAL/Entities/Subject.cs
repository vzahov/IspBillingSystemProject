using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspBillingSystem2023.DAL.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; } // Name of the entry
        public string TaxNumber { get; set; } //EGN or bulstat of the entry
        public string Address { get; set; } // Address of the entry
        public bool IsCompany { get; set; } //type of the entry
    }
}
