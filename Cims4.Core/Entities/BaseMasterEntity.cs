using Cims4.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.Core.Entities
{
    public abstract class BaseMasterEntity
    {
        private static IGuidGenerator? _guidGenerator;

        public static void SetGuidGenerator(IGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }

        protected BaseMasterEntity()
        {
            if (_guidGenerator == null)
                throw new InvalidOperationException("GUID Generator must be set before creating a BaseMasterEntity.");

            Id = _guidGenerator.GenerateMasterGuid();
        }

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }
    }
}
