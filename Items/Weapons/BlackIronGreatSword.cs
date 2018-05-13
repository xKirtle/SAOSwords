using Terraria.ID;
using Terraria.ModLoader;

namespace SAOSwords.Items.Weapons
{
    public class BlackIronGreatSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Iron Great Sword");
            Tooltip.SetDefault("Bought from a merchant.");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.melee = true;
            item.width = 45;
            item.height = 41;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes() 
        {
            //SOLD AT THE MERCHANT ?PERHAPS && AND DROPPED FROM 
        }
    }
}

