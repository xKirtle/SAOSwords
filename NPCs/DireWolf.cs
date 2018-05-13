using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using SAOSwords.Items;

namespace SAOSwords.NPCs
{
	public class DireWolf : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dire Wolf");
			Main.npcFrameCount[npc.type] = 12;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 125;
			npc.damage = 20;
			npc.defense = 15;
			npc.knockBackResist = 0.3f;
			npc.width = 96;
			npc.height = 54;
			animationType = 155;
			npc.aiStyle = 26;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(0, 0, 4, 0);
		}

        public override void NPCLoot()
		{
			if (Main.rand.Next(12) == 0)
            {
	            Item.NewItem(npc.getRect(), mod.ItemType("BlackIronGreatSword"), 1);
            }
		}

        public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				/*for(int i = 0; i < 2; ++i)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/WolfGore{i+1}"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/AlphaWolfGore{i+1}"), 1f);
				}*/
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			// we would like this npc to spawn in the overworld.
			return SpawnCondition.OverworldNight.Chance * 0.1f;
		}
    }
}