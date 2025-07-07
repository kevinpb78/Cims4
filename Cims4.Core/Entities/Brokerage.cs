using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.Core.Entities
{
    public class Brokerage : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? TradingAs { get; set; }
        public string? WorkPhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? VatNumber { get; set; }
        public string? IncomeTaxNumber { get; set; }
        public string? Website { get; set; }

        public virtual ICollection<BrokerageBranch> Branches { get; set; } = new List<BrokerageBranch>();
    }
}
