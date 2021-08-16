using BossIndex.Core.DataStructures;
using PboneLib.Services.CrossMod.Call;
using PboneLib.Utils;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace BossIndex.Common.CrossMod.Call
{
    public class AddInfo : SimpleModCallHandler
    {
        public AddInfo() : base()
        {
            CallFunctions.Add("AddInfo", AddInfoCall);
        }

        #region Mod.Call Methods
        internal object AddInfoCall(List<object> args)
        {
            // Mod adding it - Info type - args
            // TODO: what does assert args do if the types I pass in are shorter than the list of args?
            ModCallHelper.AssertArgs(args, typeof(Mod), typeof(string));
            Mod mod = (Mod)args[0];
            string type = (string)args[1];

            List<object> buildArgs = new List<object>();
            buildArgs.RemoveRange(0, 2);
            buildArgs.Insert(0, mod.Name); // Mod name should always be the first param

            IBossIndexInfo info = BossIndexMod.InformationFactory.Build(type, args);

            return BossIndexMod.InformationEngine.AddInfo(info);
        }
        #endregion
    }
}
