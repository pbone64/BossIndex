using System.Collections.Generic;
using BossIndex.Core.DataStructures;

namespace BossIndex.Core.BossInfoBuilding
{
    public interface IBossIndexInfoBuilder
    {
        // First argument is always the name of the mod adding the info
        public IBossIndexInfo Build(List<object> args);
    }
}