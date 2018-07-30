using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class Elucidator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elucidator");
            Tooltip.SetDefault("Dropped from a demonic monster at the 50th floor");
        }

        public override void SetDefaults()
        {
            item.damage = 135;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = 500000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.ShroomiteBar, 15);
            recipe.AddIngredient(ItemID.BlackDye, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
