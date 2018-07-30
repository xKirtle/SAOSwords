using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Bows
{
    public class FairyBow : ModItem
    {
        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.Phantasm);

            item.damage = 125;
            item.shoot = 20;
            item.shootSpeed = 50f;
            item.useAnimation = 5;
            item.value = 540;
            item.useAmmo = AmmoID.Arrow;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fairy Bow");
            Tooltip.SetDefault("");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
