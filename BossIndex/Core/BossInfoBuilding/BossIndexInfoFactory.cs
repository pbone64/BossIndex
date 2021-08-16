using System.Collections.Generic;
using BossIndex.Core.DataStructures;

namespace BossIndex.Core.BossInfoBuilding
{
    public class BossIndexInfoFactory
    {
        public Dictionary<string, IBossIndexInfoBuilder> Builders;

        public BossIndexInfoFactory(bool suppressDefaultInfoTypes = false)
        {
            if (suppressDefaultInfoTypes) return;

            RegisterBuilder("Boss", null);
            RegisterBuilder("Event", null);
            RegisterBuilder("Miniboss", null);
        }

        public void RegisterBuilder(string type, IBossIndexInfoBuilder instance) => Builders.Add(type, instance);

        public IBossIndexInfo Build(string type, List<object> args) => Builders[type].Build(args);
    }
}