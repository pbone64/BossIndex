using System;
using System.Collections.Generic;
using BossIndex.Core.BossInfoBuilding;
using BossIndex.Core.DataStructures;

namespace BossIndex.Common.CrossMod.WeakRefReconstruction
{
    /// <summary>
    ///     Allows us to reconstruct passed <c>Call</c> arguments into an <see cref="IBossIndexInfoBuilder"/> instance.
    /// </summary>
    // TODO: Provide a way to pass an object independently and convert to IBossIndexInfo.
    public sealed class WeakRefBossIndexInfoBuilder : IBossIndexInfoBuilder
    {
        public Func<List<object>, (string, IList<string>, string, Func<bool>)> BuildFunc { get; }

        public WeakRefBossIndexInfoBuilder(Func<List<object>, (string, IList<string>, string, Func<bool>)> buildFunc)
        {
            BuildFunc = buildFunc;
        }

        public IBossIndexInfo Build(List<object> args)
        {
            (string, IList<string>, string, Func<bool>)? result = BuildFunc?.Invoke(args);

            if (!result.HasValue)
                throw new NullReferenceException("Could not build a weak-ref IBossIndexInfo due to an invalid return value of null.");

            return new WeakRefBossIndexInfo(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4);
        }
    }
}