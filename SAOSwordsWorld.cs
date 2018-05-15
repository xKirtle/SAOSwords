using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;

using System;
using Terraria.ModLoader.IO;
using System.IO;

namespace SAOSwords
{
    public class SAOSwordsWorld : ModWorld
    {
        public static int biomeTiles = 0;
        // Stuff added with the Boss
        public static bool downedTutorialBoss = false; // Downed Tutorial Boss

        public override void Initialize()
        {
            downedTutorialBoss = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedTutorialBoss) downed.Add("tutorial");

            return new TagCompound
            {
                {"downed", downed }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedTutorialBoss = downed.Contains("tutorial");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if(loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedTutorialBoss = flags[0];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedTutorialBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedTutorialBoss = flags[0];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if(ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Tutorial Mod Ores", delegate (GenerationProgress progress)
                {
                    progress.Message = "Generating Tutorial Ores";
                    for(int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
                    {
                        WorldGen.TileRunner(
                            WorldGen.genRand.Next(0, Main.maxTilesX), // X Coord of the tile
                            WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY), // Y Coord of the tile
                            (double)WorldGen.genRand.Next(3, 6), // Strength (High = more)
                            WorldGen.genRand.Next(2, 6), // Steps 
                            mod.TileType("TutorialOreTile"), // The tile type that will be spawned
                            false, // Add Tile ???
                            0f, // Speed X ???
                            0f, // Speed Y ???
                            false, // noYChange ??? 
                            true); // Overrides existing tiles
                    }
                }));
            }
            int GraniteIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Granite"));
            if(GraniteIndex != -1)
            {
                tasks.Insert(GraniteIndex + 1, new PassLegacy("Tutorial Basic Biome", delegate (GenerationProgress progress)
                {
                    progress.Message = "Generating Custom Biome";
                    for (int i = 0; i < 4; i++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(100, 200), WorldGen.genRand.Next(50, 150), mod.TileType("TutorialBiomeTile"), true, 0f, 0f, false, true);
                    }
                }));
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            biomeTiles = tileCounts[mod.TileType("TutorialBiomeTile")];
        }

        public override void ResetNearbyTileEffects()
        {
            biomeTiles = 0;
        }
    }
}
