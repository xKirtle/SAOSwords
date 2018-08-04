using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons.Swords
{
    public class GuiltyThorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guilty Thorn");
            Tooltip.SetDefault("Made out of dark metal");
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
            item.knockBack = 6;
            item.value = 15000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 420);
        }

        public override void AddRecipes() //ADD ROTTEN CHUNCK WHEN THE SWORD HAS A POISONING EFFECT, done
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.CrimtaneBar, 11);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.DemoniteBar, 11);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
