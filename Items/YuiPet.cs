using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SAOSwords.Items
{
    public class YuiPet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yui");
            Tooltip.SetDefault("Summons Yui \nDisclaimer: Sprite is not mine");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("Yui");
            item.buffType = mod.BuffType("YuiBuff");
        }

        public override void UseStyle(Player player)
        {
            if(player.whoAmI == Main.myPlayer && player.itemTime == 0 )
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        // No crafting cause I don't have a sprite of my own yet & not released yet
    }
}
