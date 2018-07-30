using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SAOSwords.Items
{
    public class PetItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yui");
            Tooltip.SetDefault("Summons Yui");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WispinaBottle);
            item.shoot = mod.ProjectileType("Pet");
            item.buffType = mod.BuffType("PetBuff");
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
