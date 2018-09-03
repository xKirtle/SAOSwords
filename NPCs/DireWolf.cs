//This NPC config is credited to Jofairden as the layout of the config was taken from his AlphaWolf!

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
			npc.lifeMax = 50;
			npc.damage = 7;
			npc.defense = 8;
			npc.knockBackResist = 0.3f;
			npc.width = 96;
			npc.height = 54;
			animationType = 155;
			npc.aiStyle = 26;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath5;
            npc.value = Item.buyPrice(0,0,15,0);
		}

        public override void NPCLoot()
		{
			if (Main.rand.Next(26) == 0)
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

				for(int i = 0; i < 3; i++)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DireWolf/DireWolfGore" + (i + 1)), 1f);
				}
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.OverworldNight.Chance * 0.1f;
		}
    }
}