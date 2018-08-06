using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using SAOSwords.Items;

namespace SAOSwords
{
    public class SAOSwordsWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            int num = NPC.NewNPC((Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, mod.NPCType("TownNPC"), 0, 0f, 0f, 0f, 0f, 255);
            Main.npc[num].homeTileX = Main.spawnTileX + 5;
            Main.npc[num].homeTileY = Main.spawnTileY;
            Main.npc[num].direction = 1;
            Main.npc[num].homeless = true;
        }
    }
}


