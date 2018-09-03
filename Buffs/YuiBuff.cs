using Terraria;
using Terraria.ModLoader;

namespace SAOSwords.Buffs
{
    public class YuiBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Yui");
            Description.SetDefault("A happy AI that follows you everywhere!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;                   // Sets the buff time to cover 24h
            player.GetModPlayer<SAOSwordsPlayer>(mod).Yui = true; // Sets the pet to true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Yui")] <= 0; // Sets to true if count is less than or equal to 0
            if(petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Yui"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
