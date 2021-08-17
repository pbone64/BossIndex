using System;
using System.Collections.Generic;
using BossIndex.Core.DataStructures;

namespace BossIndex.Core
{
    /// <summary>
    /// The data side of a boss index
    /// </summary>
    public interface IBossIndexInformationEngine
    {
        public IList<IBossIndexInfo> GetAllInfo();

        public (string message, bool result) AddInfo(IBossIndexInfo info)
        public (string message, bool result) ModifyInfo(string modifiedBy, Func<IBossIndexInfo, bool> predicate, Action<IBossIndexInfo> action);

        public void TransferBossInfo(IBossIndexInformationEngine other);
    }
}
