using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class DarkRepulser : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Repulser");
            Tooltip.SetDefault("Crafted by Lisbeth. Indeed, a masterpiece!");
        }

        public override void SetDefaults()
        {
            item.damage = 88;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.MythrilBar, 8);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.OrichalcumBar, 8);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
