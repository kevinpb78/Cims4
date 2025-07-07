using Cims4.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.Infrastructure.Services
{
    public class MasterGuidGenerator : IGuidGenerator
    {
        public Guid GenerateMasterGuid()
        {
            // Generate a new GUID and take the last 28 characters (excluding hyphens)
            var newGuid = Guid.NewGuid().ToString("N"); // No hyphens format

            // Take last 24 characters (28 - 4 hyphens when formatted)
            var guidSuffix = newGuid.Substring(8);

            // Combine with "00000000" prefix
            var masterGuidString = $"00000000{guidSuffix}";

            // Convert back to GUID format with hyphens
            var formattedGuid = masterGuidString
                .Insert(8, "-")
                .Insert(13, "-")
                .Insert(18, "-")
                .Insert(23, "-");

            return Guid.Parse(formattedGuid);
        }

        public List<Guid> GenerateMasterGuids(int count)
        {
            var guids = new List<Guid>();
            for (int i = 0; i < count; i++)
            {
                guids.Add(GenerateMasterGuid());
            }
            return guids;
        }
    }
}
