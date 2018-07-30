using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class LambentLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lambent Light");
            Tooltip.SetDefault("Crafted by Lisbeth. Indeed, a masterpiece");
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
            item.value = 330000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.SpectreBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
