using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class GroundGorge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ground Gorge");
            Tooltip.SetDefault("A war Axe.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WarAxeoftheNight);
            item.damage = 76;
            item.rare = 8;
            item.knockBack = 12;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.MeteoriteBar, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
