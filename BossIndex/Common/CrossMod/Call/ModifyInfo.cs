using System;
using System.Collections.Generic;
using BossIndex.Core.DataStructures;
using PboneLib.Utils;
using Terraria.ModLoader;

namespace BossIndex.Common.CrossMod.Call
{
    /// <summary>
    ///     Handles <c>ModifyInfo</c> <c>Call</c>s.
    /// </summary>
    public class ModifyInfo : BossChecklistCallHandler
    {
        public override IEnumerable<(string, Func<List<object>, object>)> Functions =>
            new (string, Func<List<object>, object>)[]
            {
                ("ModifyInfo", ModifyInfoCall)
            };

        #region Mod.Call Methods

        /// <summary>
        ///     Handles modification of information from the information engine.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>A tuple containing a string and boolean representing the message and result.</returns>
        internal object ModifyInfoCall(List<object> args)
        {
            // Mod modifying it - Predicate to find info - Action to modify info
            // We permit the usage of objects instead of the types we're specifically supplying.
            ModCallHelper.AssertArgs(args, typeof(Mod), typeof(Func<object, bool>), typeof(Action<object>));
            Mod mod = (Mod) args[0];
            Func<object, bool> predicate = args[0] as Func<object, bool>;
            Action<object> action = (Action<object>) args[1];

            return BossIndexMod.InformationEngine.ModifyInfo(mod.Name, predicate, action);
        }

        #endregion
    }
}