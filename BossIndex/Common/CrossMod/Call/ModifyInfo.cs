using BossIndex.Core.DataStructures;
using PboneLib.Services.CrossMod.Call;
using PboneLib.Utils;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace BossIndex.Common.CrossMod.Call
{
    public class ModifyInfo : SimpleModCallHandler
    {
        public ModifyInfo() : base()
        {
            CallFunctions.Add("ModifyInfo", ModifyInfoCall);
        }

        #region Mod.Call Methods
        internal object ModifyInfoCall(List<object> args)
        {
            // Mod modiyfing it - Predicate to find info - Action to modify info
            ModCallHelper.AssertArgs(args, typeof(Mod), typeof(Func<IBossIndexInfo, bool>), typeof(Action<IBossIndexInfo>));
            Mod mod = (Mod)args[0];
            Func<IBossIndexInfo, bool> predicate = (Func<IBossIndexInfo, bool>)args[0];
            Action<IBossIndexInfo> action = (Action<IBossIndexInfo>)args[1];

            return BossIndexMod.InformationEngine.ModifyInfo(mod.Name, predicate, action);
        }
        #endregion
    }
}
