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
            Tooltip.SetDefault("Swing the item to start your quest!");
        }

        public override void SetDefaults()
        {
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.value = 0;
            item.rare = 9;
            item.UseSound = SoundID.Item4;
            item.autoReuse = false;
            item.noMelee = true;
            item.consumable = true;
            item.buffType = mod.BuffType("AnnealBuff");
            item.buyOnce = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 999999, true);
                Main.NewText("Kill 5 Blue Slimes to earn your reward!", 0, 191, 255);
                Main.NewText("P.S.: They're usually under the florest in the underground!", 144, 238, 144);
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {S
            Tooltip.SetDefault("Kill some Slimes!\nNOT RELEASED YET\nTHIS ITEM IS NOT CRAFTABLE");
        }

        public class QuestSlime : GlobalItem // Makes so the code below works for all melee weapons
        {
            public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
            {
                int bSlime = NPCID.BlueSlime;
                int bannerID = Item.NPCtoBanner(bSlime);
                if (NPC.killCount[bannerID] >= 5 && target.type == NPCID.BlueSlime && target.life <= 0 && player.HasBuff(mod.BuffType("AnnealBuff")))
                {
                    Item.NewItem(target.getRect(), mod.ItemType("AnnealBlade"), 1);
                    player.ClearBuff(mod.BuffType("AnnealBuff"));
                    player.GetModPlayer<SAOSwordsPlayer>(mod).Anneal = false;
                    NPC.killCount[bannerID] -= NPC.killCount[bannerID]; // Resets the Blue Slime killCount to 0
                }
            }
        }
    }
}

