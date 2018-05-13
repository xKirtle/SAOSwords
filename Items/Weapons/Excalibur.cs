using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class Excalibur : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Excalibur");
            Tooltip.SetDefault("Holy Sword. The strongest legendary sword in ALO.");
        }

        public override void SetDefaults()
        {
            item.damage = 119;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 10000;
            item.rare = -12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.GoldBar, 60);
            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
