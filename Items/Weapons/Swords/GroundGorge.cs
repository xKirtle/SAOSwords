using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class GroundGorge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ground Gorge");
            Tooltip.SetDefault("A very heavy war Axe");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WarAxeoftheNight);
            item.damage = 30;
            item.axe = 25;
            item.rare = 3;
            item.useAnimation = 45;
            item.knockBack = 6;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.MeteoriteBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
