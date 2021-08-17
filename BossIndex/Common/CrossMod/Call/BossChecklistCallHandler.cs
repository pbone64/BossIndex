/*using System;
using System.Collections.Generic;
using PboneLib.Services.CrossMod.Call;
// ReSharper disable VirtualMemberCallInConstructor

namespace BossIndex.Common.CrossMod.Call
{
    /// <summary>
    ///     Class for automatically handling registered functions. Kinda useless.
    /// </summary>
    public abstract class BossChecklistCallHandler : SimpleModCallHandler
    {
        public abstract IEnumerable<(string, Func<List<object>, object>)> Functions { get; }

        protected BossChecklistCallHandler()
        {
            if (Functions is null) return;

            foreach ((string call, Func<List<object>, object> action) in Functions)
                CallFunctions.Add(call, action);
        }
    }
}*/