using System;
using System.Collections.Generic;
using BossIndex.Core.DataStructures;

namespace BossIndex.Common.CrossMod.WeakRefReconstruction
{
    public class WeakRefBossIndexInfo : IBossIndexInfo
    {
        public string AddedBy { get; }

        public IList<string> ModifiedBy { get; }

        public string Type { get; }

        public Func<bool> IsCompletedFunc { get; }

        public WeakRefBossIndexInfo(string addedBy, IList<string> modifiedBy, string type, Func<bool> isCompleted)
        {
            AddedBy = addedBy;
            ModifiedBy = modifiedBy;
            Type = type;
            IsCompletedFunc = isCompleted;
        }

        public bool IsCompleted() => IsCompletedFunc?.Invoke() ?? false;
    }
}