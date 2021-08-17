using System.Collections.Generic;

namespace BossIndex.Core.DataStructures
{
    public interface IBossIndexInfo
    {
        public string Type { get; }

        /// <summary>
        ///     The mod that added this info. Not always the mod that added the boss NPC.
        /// </summary>
        public string AddedBy { get; }
        public IList<string> ModifiedBy { get; }

        // TODO: GetDescription?

        public bool IsCompleted();
    }
}
