using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
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
        public bool ZoneExample = false;
        public int heroLives = 0;
        public bool Pet = false;
        public bool summonSpiritMinion = false;
        public bool Anneal = true;
        public bool zoneBiome = false;

        public override void ResetEffects()
        {
            Pet = false;
            summonSpiritMinion = false;
            Anneal = false;
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
