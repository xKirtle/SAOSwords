    using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class Karakurenai : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Karakurenai");
            Tooltip.SetDefault("Behaves like a Katana but it won't ever break");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 12;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 5000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.SilverBar, 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.TungstenBar, 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
