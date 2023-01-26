using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspBillingSystem2023.DAL.Entities
{
    public class Estate : BaseEntity
    {
        public string Address { get; set; } //Address of the entry
        public int ServiceNumber { get; set; }
        public decimal Total { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
