using System.Collections.Generic;

namespace BossIndex.Core.DataStructures
{
    public interface IBossIndexInfo
    {
        /// <summary>
        ///     The mod that added this info. Not always the mod that added the boss NPC.
        /// </summary>
        public string AddedBy { get; }

        public IList<string> ModifiedBy { get; }

        public string Type { get; }
        // TODO: GetDescription?

        public bool IsCompleted();
    }
}
