using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SAOSwords.Projectiles
{
    public class Pet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            aiType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; // Sets the default cloned pet to false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            SAOSwordsPlayer modPlayer = player.GetModPlayer<SAOSwordsPlayer>(mod);
            if(player.dead)
            {
                modPlayer.Pet = false;
            }
            if(modPlayer.Pet)
            {
                projectile.timeLeft = 2; //Remain at 2 while Pet == true;
            }
        }
    }
}
