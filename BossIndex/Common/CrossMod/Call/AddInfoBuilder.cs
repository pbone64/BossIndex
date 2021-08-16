using BossIndex.Core.BossInfoBuilding;
using PboneLib.Services.CrossMod.Call;
using PboneLib.Utils;
using System.Collections.Generic;

namespace BossIndex.Common.CrossMod.Call
{
    public class AddInfoBuilder : SimpleModCallHandler
    {
        public AddInfoBuilder() : base()
        {
            CallFunctions.Add("AddInfoBuilder", AddInfoBuilderCall);
        }

        #region Mod.Call Methods
        internal object AddInfoBuilderCall(List<object> args)
        {
            // Mod adding it - Info type - args
            ModCallHelper.AssertArgs(args, typeof(string), typeof(IBossIndexInfoBuilder));
            string type = (string)args[0];
            IBossIndexInfoBuilder builder = (IBossIndexInfoBuilder)args[1];

            BossIndexMod.InformationFactory.RegisterBuilder(type, builder);

            return null;
        }
        #endregion
    }
}
