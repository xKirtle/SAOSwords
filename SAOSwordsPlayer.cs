using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace SAOSwords
{
    public class SAOSwordsPlayer : ModPlayer
    {
        public bool Zone = false;
        public int heroLives = 0;
        public bool Yui = false;
        public bool summonSpiritMinion = false;
        public bool Anneal = true;
        public bool zoneBiome = false;
        public int SlimeKillsLeftUntilAnnealReward = 5;
        //public int testreward = 5;

        public override void ResetEffects()
        {
            SlimeKillsLeftUntilAnnealReward = 0;
            Yui = false;
            summonSpiritMinion = false;
            Anneal = false;
            //testreward = 0;
        }

        public override void SetupStartInventory(IList<Item> items)
        {

            Item item = new Item();
            //item.SetDefaults(mod.ItemType("AnnealBlade"));
            item.SetDefaults(ItemID.MagicMirror);
            item.stack = 1;
            items.Add(item);
        }
    }
}
