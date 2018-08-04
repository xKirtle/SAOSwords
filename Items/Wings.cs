using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items
{
    [AutoloadEquip(EquipType.Wings)]
    public class Wings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Custom Wings");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SpookyWings);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 180; // Spooky Wings last 3s in the air
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
        ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            item.CloneDefaults(ItemID.SpookyWings);
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            item.CloneDefaults(ItemID.SpookyWings);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}