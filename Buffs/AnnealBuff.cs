using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;


namespace SAOSwords.Buffs
{
    public class AnnealBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Quest");
            Description.SetDefault("Kill 5 Blue Slimes!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.persistentBuff[Type] = true;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 9999999;
        }
    }
}
