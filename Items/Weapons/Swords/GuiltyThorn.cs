using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class GuiltyThorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guilty Thorn");
            Tooltip.SetDefault("Made out of black metal");
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 22;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = 15000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        /*public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 60);
        } */

        public override void AddRecipes() //ADD ROTTEN CHUNCK WHEN THE SWORD HAS A POISONING EFFECT
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.CrimtaneBar, 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.DemoniteBar, 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
