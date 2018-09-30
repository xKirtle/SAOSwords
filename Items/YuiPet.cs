using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SAOSwords.Items
{
    public class YuiPet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yui's Heart");
            Tooltip.SetDefault("Summons a pet fairy");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Nectar);
            item.shoot = mod.ProjectileType("Yui");
            item.buffType = mod.BuffType("YuiBuff");
            item.value = 10000;
        }

        public override void UseStyle(Player player)
        {
            if(player.whoAmI == Main.myPlayer && player.itemTime == 0 )
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}

// Disclaimer: Sprite used is not mine!
