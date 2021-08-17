using System;
using System.Collections.Generic;
using BossIndex.Core.DataStructures;
using PboneLib.Utils;

namespace BossIndex.Core.BossIndexInfoBuilding.Builders
{
    public class BossInfoBuilder : IBossIndexInfoBuilder
    {
        public IBossIndexInfo Build(List<object> args)
        {
            ModCallHelper.AssertArgs(args, typeof(string), typeof(int), typeof(Func<bool>));

            return new BossInfo((string) args[0], (int) args[1], (Func<bool>) args[2]);
        }
    }
}