using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.Core.Entities
{
    public class BrokerageBranch : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? BranchCode { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsMainBranch { get; set; } = false;

        // Foreign key
        public Guid BrokerageId { get; set; }

        // Navigation property
        public virtual Brokerage Brokerage { get; set; } = null!;
    }
}
