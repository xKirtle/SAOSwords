using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using SAOSwords.Items.Quest;

namespace SAOSwords
{
    public class SAOSwordsPlayer : ModPlayer
    {
        public bool Pet = false;
        public bool summonSpiritMinion = false;

        public bool zoneBiome = false;

        public override void ResetEffects()
        {
            Pet = false;
            summonSpiritMinion = false;
        }

        public override void SetupStartInventory(IList<Item> items)
        {

            Item item = new Item();
            //item.SetDefaults(mod.ItemType("AnnealBlade"));
            item.SetDefaults(ItemID.MagicMirror);
            item.stack = 1;
            items.Add(item);
        }

        public override void UpdateBiomes()
        {
            zoneBiome = (SAOSwordsWorld.biomeTiles > 50); // Chance 50 to the minimum number of tiles that need to be counted before it is classed as a biome
        }

        public override bool CustomBiomesMatch(Player other)
        {
            SAOSwordsPlayer otherPlayer = other.GetModPlayer<SAOSwordsPlayer>(mod); // This will get other players using the SAOSwordsPlayerClass
            return zoneBiome == otherPlayer.zoneBiome; // This will return true or false depending on other player
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            SAOSwordsPlayer otherPlayer = other.GetModPlayer<SAOSwordsPlayer>(mod);
            otherPlayer.zoneBiome = zoneBiome; // This will set other player's biome to the same as thisPlayer
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = zoneBiome;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            zoneBiome = flags[0];
        }

        public override void UpdateBiomeVisuals()
        {
            
        }

        public override Texture2D GetMapBackgroundImage()
        {
            return null;
        }
    }
}
