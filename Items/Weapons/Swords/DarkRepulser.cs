using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class DarkRepulser : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Repulser");
            Tooltip.SetDefault("Crafted by Lisbeth. Indeed, a masterpiece");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 125000;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes() // MAKE ONLY CRAFTABLE BY THE LISBETH NPC (SMH LOL)
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.MythrilBar, 8);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.OrichalcumBar, 8);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
