using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class Liberator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Liberator");
            Tooltip.SetDefault("Best used with a shield!");
        }

        public override void SetDefaults()
        {
            item.damage = 55;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 17;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.CobaltBar, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
