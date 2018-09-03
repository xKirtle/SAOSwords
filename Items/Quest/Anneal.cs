﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
                if (Main.netMode == 1)
                {
                    player.AddBuff(item.buffType, 999999, true);
                    Main.NewText("Kill 5 Slimes to earn your reward!", 0, 191, 255);
                    Main.NewText("P.S.: Slimes can be found across all biomes!", 144, 238, 144);
                    Main.NewText("P.P.S.: THE QUEST MIGHT ONLY WORK FOR THE HOST!\nWAIT FOR THE NEXT PATCH", 255, 53, 53);
                }
                else
                {
                    player.AddBuff(item.buffType, 999999, true);
                    Main.NewText("Kill 5 Slimes to earn your reward!", 0, 191, 255);
                    Main.NewText("P.S.: Slimes can be found across all biomes!", 144, 238, 144);
                }
            }
        }

        public class QuestSlime : GlobalItem // Makes so the code below works for all melee weapons
        {
            public override bool InstancePerEntity // Requirement for the next int (for some reason that is beyond my understandment)
            {
                get
                {
                    return true;
                }
            }

            public override bool CloneNewInstances // Requirement for the next int (for some reason that is beyond my understandment)
            {
                get
                {
                    return true;
                }
            }

            int SlimeKillsLeftUntilAnnealReward = 5; // The little fucker that requires the above methods

            public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
            {
                int bSlime = NPCID.BlueSlime;
                int bannerID = Item.NPCtoBanner(bSlime);
                if (target.type == bSlime && target.life <= 0 && SlimeKillsLeftUntilAnnealReward >= 2 && player.HasBuff(mod.BuffType("AnnealBuff")))
                {
                    SlimeKillsLeftUntilAnnealReward -= 1;
                    Main.NewText("You still need to kill more " + SlimeKillsLeftUntilAnnealReward + " Blue Slimes!", 30, 144, 255);
                }
                else if (target.type == bSlime && target.life <= 0 && player.HasBuff(mod.BuffType("AnnealBuff")) && SlimeKillsLeftUntilAnnealReward == 1)
                {
                    int sword = Item.NewItem(target.getRect(), mod.ItemType("AnnealSword"), 1);
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(Terraria.ID.MessageID.SyncItem, -1, -1, null, sword); // Not giving the item while in a multiplayer 
                    }
                    else
                    {
                        Item.NewItem(target.getRect(), mod.ItemType("AnnealBlade"), 1);
                    }
                    Item.NewItem(target.getRect(), mod.ItemType("AnnealSword"), 1);
                    player.ClearBuff(mod.BuffType("AnnealBuff"));
                    player.GetModPlayer<SAOSwordsPlayer>(mod).Anneal = false;
                    SlimeKillsLeftUntilAnnealReward = 5;
                    Main.NewText("Quest completed!", 0, 191, 255);

                }

                /*if (NPC.killCount[bannerID] >= 5 && target.type == NPCID.BlueSlime && target.life <= 0 && player.HasBuff(mod.BuffType("AnnealBuff")))  // Thanks to jopojelly, Ivysaur97 and Dark;Light for the killCount[bannerID] solution (even though I won't use it)
                  {
                  // Item.NewItem(target.getRect(), mod.ItemType("AnnealBlade"), 1);
                  // player.QuickSpawnItem(mod.ItemType("AnnealBlade"), 1);
                  int number = Item.NewItem(target.getRect(), mod.ItemType("AnnealSword"), 1);
                  if (Main.netMode == 1)
                  {
                      NetMessage.SendData(21, -1, -1, null, number, 1f, 0f, 0f, 0, 0, 0);
                  }
                  else
                  {
                      Item.NewItem(target.getRect(), mod.ItemType("AnnealBlade"), 1);
                  }
                  player.ClearBuff(mod.BuffType("AnnealBuff"));
                  player.GetModPlayer<SAOSwordsPlayer>(mod).Anneal = false;
                  NPC.killCount[bannerID] -= NPC.killCount[bannerID]; // Resets the Blue Slime killCount to 0; Server informs the client the real value and this wont work.
                  }*/
            }
        }
    }
}


