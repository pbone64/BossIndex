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

        public string AddedBy { get => _addedBy; }
        public IList<string> ModifiedBy { get => _modifiedBy; }

        /// <summary>
        /// The id of the boss this info represents
        /// </summary>
        public int BossNpcId;
        public Func<bool> CompletedPredicate;

        private string _addedBy;
        private List<string> _modifiedBy;

        public BossInfo(string addedBy, int bossNpcId, Func<bool> completedPredicate)
        {
            BossNpcId = bossNpcId;
            CompletedPredicate = completedPredicate;

            _addedBy = addedBy;
            _modifiedBy = new List<string>();
        }

        public bool IsCompleted() => CompletedPredicate();

        public NPC GetAsNpc() => ContentSamples.NpcsByNetId[BossNpcId];
        public NPCLoot GetLoot(ItemDropDatabase dropDatabase) => new NPCLoot(BossNpcId, dropDatabase);
    }
}
