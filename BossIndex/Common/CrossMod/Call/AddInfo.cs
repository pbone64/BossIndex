using System;
using System.Collections.Generic;
using BossIndex.Core.DataStructures;
using PboneLib.Utils;
using Terraria.ModLoader;

namespace BossIndex.Common.CrossMod.Call
{
    /// <summary>
    ///     Handles calls to <c>AddInfo</c>. Adds an entry to the current information engine.
    /// </summary>
    public class AddInfo : BossChecklistCallHandler
    {
        public override IEnumerable<(string, Func<List<object>, object>)> Functions =>
            new (string, Func<List<object>, object>)[]
            {
                ("AddInfo", AddInfoCall)
            };

        #region Mod.Call Methods

        /// <summary>
        ///     Handles <c>Call</c>s pointing to <c>AddInfo</c>.
        /// </summary>
        /// <returns>A tuple containing a string and boolean representing the message and result.</returns>
        internal object AddInfoCall(List<object> args)
        {
            // Mod adding it - Info type - args
            // TODO: What does assert args do if the types I pass in are shorter than the list of args?

            ModCallHelper.AssertArgs(args, typeof(Mod), typeof(string));

            Mod mod = (Mod) args[0];

            string type = (string) args[1];

            List<object> buildArgs = new();

            buildArgs.RemoveRange(0, 2);
            buildArgs.Insert(0, mod.Name); // Mod name should always be the first param

            IBossIndexInfo info = BossIndexMod.InformationFactory.Build(type, args);

            return BossIndexMod.InformationEngine.AddInfo(info);
        }

        #endregion
    }
}