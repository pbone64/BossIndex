using BossIndex.Core.DataStructures;
using System.Collections.Generic;

namespace BossIndex.Core.BossInfoBuilding
{
    public interface IBossIndexInfoBuilder
    {
        // First arg is always the name of the mod adding the info
        public IBossIndexInfo Build(List<object> args);
    }
}
