﻿// Sprite is not mine
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SAOSwords.Projectiles
{
    public class Yui : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BabyHornet);
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            aiType = ProjectileID.BabyHornet;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.hornet = false; // Sets the default cloned pet to false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            SAOSwordsPlayer modPlayer = player.GetModPlayer<SAOSwordsPlayer>(mod);
            if(player.dead)
            {
                modPlayer.Yui = false;
            }
            if(modPlayer.Yui)
            {
                projectile.timeLeft = 2; //Remain at 2 while Pet == true;
            }
        }
    }
}

// Disclaimer: Sprite used is not mine!
