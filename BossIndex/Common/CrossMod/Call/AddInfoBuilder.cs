using System;
using System.Collections.Generic;
using BossIndex.Common.CrossMod.WeakRefReconstruction;
using BossIndex.Core.BossInfoBuilding;
using PboneLib.Utils;

namespace BossIndex.Common.CrossMod.Call
{
    /// <summary>
    ///     Handles <c>AddInfoBuilder</c> <c>Call</c>s.
    /// </summary>
    public class AddInfoBuilder : BossChecklistCallHandler
    {
        public override IEnumerable<(string, Func<List<object>, object>)> Functions =>
            new (string, Func<List<object>, object>)[]
            {
                ("AddInfoBuilder", AddInfoBuilderCall)
            };

        #region Mod.Call Methods

        /// <summary>
        ///     Adds a <c>Func&lt;List&lt;object&gt;, object&gt;</c> (<see cref="Func{TResult}"/>) and accompanying string to the information factory. <br />
        ///     Converts the function to a <see cref="WeakRefBossIndexInfoBuilder"/>.
        /// </summary>
        internal object AddInfoBuilderCall(List<object> args)
        {
            // Mod adding it - Info type - args
            ModCallHelper.AssertArgs(args, typeof(string), typeof(Func<List<object>, (string, IList<string>, string, Func<bool>)>));

            string type = (string) args[0];

            IBossIndexInfoBuilder builder = new WeakRefBossIndexInfoBuilder((Func<List<object>, (string, IList<string>, string, Func<bool>)>) args[1]);

            BossIndexMod.InformationFactory.RegisterBuilder(type, builder);

            return null;
        }

        #endregion
    }
}