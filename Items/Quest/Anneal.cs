using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SAOSwords.Items;
using SAOSwords.Items.Quest;
using Microsoft.Xna.Framework;

namespace SAOSwords.Items.Quest
{
    public class Anneal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("First Quest");
            Tooltip.SetDefault("Kill some Slimes!");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 0;
            item.value = 0;
            item.rare = 9;
            item.UseSound = SoundID.Item4;
            item.autoReuse = false;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            base.MeleeEffects(player, hitbox);
            player.QuickSpawnItem(mod.ItemType("AnnealBlade"));
        }

    }
}

