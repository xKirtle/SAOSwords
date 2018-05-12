using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class Karakurenai : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Karakurenai");
            Tooltip.SetDefault("Description.");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = 10000;
            item.rare = 2;
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
