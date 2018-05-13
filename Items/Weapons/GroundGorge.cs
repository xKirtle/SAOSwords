using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class GroundGorge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ground Gorge");
            Tooltip.SetDefault("Description.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WarAxeoftheNight);
            item.damage = 76;
            item.rare = 8;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
