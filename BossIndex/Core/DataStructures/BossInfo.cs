using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossIndex.Core.DataStructures
{
    /// <summary>
    /// Contains information about a registered boss
    /// </summary>
    public class BossInfo : IBossIndexInfo
    {
        public string Type => "Boss";

        public string AddedBy { get; }
        public IList<string> ModifiedBy { get; }

        /// <summary>
        ///     The ID of the boss this info represents.
        /// </summary>
        public int BossNpcId;

        public Func<bool> CompletedPredicate;

        public BossInfo(string addedBy, int bossNpcId, Func<bool> completedPredicate)
        {
            BossNpcId = bossNpcId;
            CompletedPredicate = completedPredicate;

            AddedBy = addedBy;
            ModifiedBy = new List<string>();
        }

        public bool IsCompleted() => CompletedPredicate();

        public NPC GetAsNpc() => ContentSamples.NpcsByNetId[BossNpcId];
        public NPCLoot GetLoot(ItemDropDatabase dropDatabase) => new(BossNpcId, dropDatabase);
    }
}