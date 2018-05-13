using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class LambentLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lambent Light");
            Tooltip.SetDefault("Crafted by Lisbeth. Indeed, a masterpiece!");
        }

        public override void SetDefaults()
        {
            item.damage = 114;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
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
