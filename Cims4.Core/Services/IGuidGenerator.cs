using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.Core.Services
{
    public interface IGuidGenerator
    {
        Guid GenerateMasterGuid();
        List<Guid> GenerateMasterGuids(int count);
    }
}
