using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Tools
{
    public class Pickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kirtle's Pickaxe");
            Tooltip.SetDefault("A modded pickaxe.");
        }

        public override void SetDefaults()
        {
            item.damage = 2;
            item.melee = true;
            item.width = 15;
            item.height = 15;
            item.useTime = 5;
            item.useAnimation = 5;
            item.pick = 100;    //pickaxe power
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 2;
            item.autoReuse = true;
            item.useTurn = true;
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